Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Text

Public Class frmpurchasereturn
    ' ================================================
    ' DATABASE & CONFIGURATION
    ' ================================================
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer = 1

    ' ================================================
    ' DATA TABLE
    ' ================================================
    Private returnTable As New DataTable()

    ' ================================================
    ' CALCULATION VARIABLES
    ' ================================================
    Private calculatedSubtotal As Decimal = 0
    Private calculatedDiscount As Decimal = 0
    Private calculatedTax As Decimal = 0
    Private calculatedNetTotal As Decimal = 0

    ' ================================================
    ' EDIT / DELETE TRACKING
    ' ================================================
    Private currentEditReturnID As Integer = 0
    Private isEditMode As Boolean = False

    ' ================================================
    ' PRINT
    ' ================================================
    Private printLines As New List(Of String)()

#Region "Form Load & Initialization"

    Private Sub frmpurchasereturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupReturnTable()
            LoadSuppliers()
            LoadPaymentStatus()
            GenerateNewReturnNo()
            dtpPurchaseDate.Value = DateTime.Now
            txtQuantity.Text = "1"
            txtProductID.Focus()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupReturnTable()
        returnTable.Columns.Clear()
        returnTable.Columns.Add("ProductID", GetType(String))
        returnTable.Columns.Add("Barcode", GetType(String))
        returnTable.Columns.Add("ProductName", GetType(String))
        returnTable.Columns.Add("Quantity", GetType(Decimal))
        returnTable.Columns.Add("UnitPrice", GetType(Decimal))
        returnTable.Columns.Add("TotalPrice", GetType(Decimal))

        dgvPurchaseItems.DataSource = returnTable
        dgvPurchaseItems.DefaultCellStyle.Font = New Font("Segoe UI", 10)
        dgvPurchaseItems.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

        With dgvPurchaseItems
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOliveGreen
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew
        End With
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim dt As New DataTable()
                dt.Columns.Add("SupplierID", GetType(Integer))
                dt.Columns.Add("SupplierName", GetType(String))
                dt.Rows.Add(0, "-- Select Supplier --")

                Dim adapter As New MySqlDataAdapter(
                    "SELECT SupplierID, SupplierName FROM suppliers WHERE IsActive = 1 ORDER BY SupplierName", conn)
                adapter.Fill(dt)

                cboSupplier.DataSource = dt
                cboSupplier.DisplayMember = "SupplierName"
                cboSupplier.ValueMember = "SupplierID"
                cboSupplier.SelectedValue = 0
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPaymentStatus()
        cboPaymentStatus.Items.Clear()
        cboPaymentStatus.Items.AddRange(New String() {"Completed", "Pending", "Partial"})
        cboPaymentStatus.SelectedIndex = 0
    End Sub

    Private Sub GenerateNewReturnNo()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM purchase_returns WHERE YEAR(ReturnDate) = YEAR(NOW())", conn)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                txtPurchaseNo.Text = $"PR-{DateTime.Now.Year}-{(count + 1):D4}"
            End Using
        Catch ex As Exception
            txtPurchaseNo.Text = $"PR-{DateTime.Now.Year}-0001"
        End Try
    End Sub

#End Region

#Region "Product Search & Add"

    Private Sub btnSearchProduct_Click(sender As Object, e As EventArgs) Handles btnSearchProduct.Click
        SearchAndAddProduct()
    End Sub

    Private Sub txtProductID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductID.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchAndAddProduct()
        End If
    End Sub

    Private Sub SearchAndAddProduct()
        Dim searchTerm As String = txtProductID.Text.Trim()
        If String.IsNullOrEmpty(searchTerm) Then
            MessageBox.Show("Enter product barcode or ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT ProductID, Barcode, ProductName, CostPrice FROM products " &
                                    "WHERE IsActive = 1 AND (Barcode = @Exact OR ProductName LIKE @Like OR CAST(ProductID AS CHAR) = @Exact) " &
                                    "ORDER BY CASE WHEN Barcode = @Exact THEN 0 ELSE 1 END LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Exact", searchTerm)
                    cmd.Parameters.AddWithValue("@Like", $"%{searchTerm}%")
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim productID = reader("ProductID").ToString()
                            Dim barcode = reader("Barcode").ToString()
                            Dim productName = reader("ProductName").ToString()
                            Dim unitPrice As Decimal = Convert.ToDecimal(reader("CostPrice"))

                            txtProductName.Text = productName
                            txtUnitPrice.Text = unitPrice.ToString("N2")

                            ' Check if already in grid
                            For Each row As DataRow In returnTable.Rows
                                If row("ProductID").ToString() = productID Then
                                    Dim qty As Decimal = Convert.ToDecimal(row("Quantity"))
                                    Dim requestedQty As Decimal = 1
                                    If Not Decimal.TryParse(txtQuantity.Text, requestedQty) Then requestedQty = 1
                                    row("Quantity") = qty + requestedQty
                                    row("TotalPrice") = Convert.ToDecimal(row("Quantity")) * Convert.ToDecimal(row("UnitPrice"))
                                    RecalculateTotals()
                                    txtProductID.Clear()
                                    txtProductName.Clear()
                                    txtProductID.Focus()
                                    Return
                                End If
                            Next
                        Else
                            MessageBox.Show("Product not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtProductID.SelectAll()
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        Dim searchTerm As String = txtProductID.Text.Trim()
        If String.IsNullOrEmpty(searchTerm) Then
            MessageBox.Show("Search for a product first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim qty As Decimal = 1
        If Not Decimal.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Enter a valid quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return
        End If

        Dim unitPrice As Decimal = 0
        If Not Decimal.TryParse(txtUnitPrice.Text, unitPrice) OrElse unitPrice < 0 Then
            unitPrice = 0
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT ProductID, Barcode, ProductName FROM products " &
                                    "WHERE IsActive = 1 AND (Barcode = @Exact OR ProductName LIKE @Like OR CAST(ProductID AS CHAR) = @Exact) " &
                                    "ORDER BY CASE WHEN Barcode = @Exact THEN 0 ELSE 1 END LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Exact", searchTerm)
                    cmd.Parameters.AddWithValue("@Like", $"%{searchTerm}%")
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim productID = reader("ProductID").ToString()
                            Dim barcode = reader("Barcode").ToString()
                            Dim productName = reader("ProductName").ToString()

                            ' Check if already in grid
                            For Each row As DataRow In returnTable.Rows
                                If row("ProductID").ToString() = productID Then
                                    row("Quantity") = Convert.ToDecimal(row("Quantity")) + qty
                                    row("TotalPrice") = Convert.ToDecimal(row("Quantity")) * Convert.ToDecimal(row("UnitPrice"))
                                    RecalculateTotals()
                                    ClearProductFields()
                                    Return
                                End If
                            Next

                            returnTable.Rows.Add(productID, barcode, productName, qty, unitPrice, qty * unitPrice)
                            RecalculateTotals()
                            ClearProductFields()
                        Else
                            MessageBox.Show("Product not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearProductFields()
        txtProductID.Clear()
        txtProductName.Clear()
        txtUnitPrice.Clear()
        txtQuantity.Text = "1"
        txtProductID.Focus()
    End Sub

#End Region

#Region "Totals"

    Private Sub RecalculateTotals()
        calculatedSubtotal = 0
        For Each row As DataRow In returnTable.Rows
            calculatedSubtotal += Convert.ToDecimal(row("TotalPrice"))
        Next

        calculatedDiscount = 0
        calculatedTax = 0
        calculatedNetTotal = calculatedSubtotal - calculatedDiscount + calculatedTax

        lblSubtotal.Text = calculatedSubtotal.ToString("N2")
        lblDiscount.Text = calculatedDiscount.ToString("N2")
        lblTax.Text = calculatedTax.ToString("N2")
        lblNetTotal.Text = calculatedNetTotal.ToString("N2")
    End Sub

    Private Sub dgvPurchaseItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchaseItems.CellValueChanged
        If e.RowIndex < 0 Then Return
        Try
            Dim row = returnTable.Rows(e.RowIndex)
            row("TotalPrice") = Convert.ToDecimal(row("Quantity")) * Convert.ToDecimal(row("UnitPrice"))
            RecalculateTotals()
        Catch
        End Try
    End Sub

#End Region

#Region "Remove Item"

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvPurchaseItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Select an item to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim rowIdx As Integer = dgvPurchaseItems.SelectedRows(0).Index
        returnTable.Rows.RemoveAt(rowIdx)
        RecalculateTotals()
    End Sub

#End Region

#Region "Save Return"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateSave() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using tran = conn.BeginTransaction()
                    Try
                        Dim supplierID As Integer = If(cboSupplier.SelectedValue IsNot Nothing AndAlso
                                                        CInt(cboSupplier.SelectedValue) > 0,
                                                        CInt(cboSupplier.SelectedValue), 0)
                        Dim invoiceRef As String = TextBox1.Text.Trim()
                        Dim notes As String = txtNotes.Text.Trim()
                        Dim payStatus As String = cboPaymentStatus.Text

                        ' Insert purchase_returns header
                        Dim insertRet As New MySqlCommand(
                            "INSERT INTO purchase_returns (ReturnNo, ReturnDate, SupplierID, InvoiceRef, " &
                            "SubTotal, NetAmount, Reason, Remarks, UserID) " &
                            "VALUES (@RNo, @RDate, @SuppID, @InvRef, @Sub, @Net, @Reason, @Notes, @UID)", conn, tran)
                        insertRet.Parameters.AddWithValue("@RNo", txtPurchaseNo.Text.Trim())
                        insertRet.Parameters.AddWithValue("@RDate", dtpPurchaseDate.Value)
                        insertRet.Parameters.AddWithValue("@SuppID", If(supplierID > 0, CObj(supplierID), DBNull.Value))
                        insertRet.Parameters.AddWithValue("@InvRef", If(String.IsNullOrEmpty(invoiceRef), DBNull.Value, CObj(invoiceRef)))
                        insertRet.Parameters.AddWithValue("@Sub", calculatedSubtotal)
                        insertRet.Parameters.AddWithValue("@Net", calculatedNetTotal)
                        insertRet.Parameters.AddWithValue("@Reason", payStatus)
                        insertRet.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, CObj(notes)))
                        insertRet.Parameters.AddWithValue("@UID", CurrentUserID)
                        insertRet.ExecuteNonQuery()

                        Dim returnID As Long = insertRet.LastInsertedId

                        ' Insert items and update stock
                        For Each row As DataRow In returnTable.Rows
                            Dim insertItem As New MySqlCommand(
                                "INSERT INTO purchase_return_items (ReturnID, ProductID, Quantity, UnitPrice, Amount) " &
                                "VALUES (@RID, @PID, @Qty, @Price, @Amt)", conn, tran)
                            insertItem.Parameters.AddWithValue("@RID", returnID)
                            insertItem.Parameters.AddWithValue("@PID", row("ProductID").ToString())
                            insertItem.Parameters.AddWithValue("@Qty", Convert.ToDecimal(row("Quantity")))
                            insertItem.Parameters.AddWithValue("@Price", Convert.ToDecimal(row("UnitPrice")))
                            insertItem.Parameters.AddWithValue("@Amt", Convert.ToDecimal(row("TotalPrice")))
                            insertItem.ExecuteNonQuery()

                            ' Decrease stock (returning to supplier reduces inventory)
                            Dim updStock As New MySqlCommand(
                                "UPDATE products SET Stock = Stock - @Qty WHERE ProductID = @PID", conn, tran)
                            updStock.Parameters.AddWithValue("@Qty", Convert.ToDecimal(row("Quantity")))
                            updStock.Parameters.AddWithValue("@PID", row("ProductID").ToString())
                            updStock.ExecuteNonQuery()
                        Next

                        ' Daybook entry
                        Dim daybook As New MySqlCommand(
                            "INSERT INTO daybook (TransactionDate, TransactionType, Description, DebitAmount, CreditAmount, ReferenceNo, PaymentMethod, UserID) " &
                            "VALUES (@Date, 'Purchase Return', @Desc, @Debit, 0, @RefNo, @PayM, @UID)", conn, tran)
                        daybook.Parameters.AddWithValue("@Date", dtpPurchaseDate.Value)
                        daybook.Parameters.AddWithValue("@Desc", $"Purchase Return {txtPurchaseNo.Text}")
                        daybook.Parameters.AddWithValue("@Debit", calculatedNetTotal)
                        daybook.Parameters.AddWithValue("@RefNo", txtPurchaseNo.Text.Trim())
                        daybook.Parameters.AddWithValue("@PayM", "Return")
                        daybook.Parameters.AddWithValue("@UID", CurrentUserID)
                        daybook.ExecuteNonQuery()

                        ' Activity log
                        Dim log As New MySqlCommand(
                            "INSERT INTO activity_log (UserID, Action, TableName, RecordID, Description) " &
                            "VALUES (@UID, 'INSERT', 'purchase_returns', @RID, @Desc)", conn, tran)
                        log.Parameters.AddWithValue("@UID", CurrentUserID)
                        log.Parameters.AddWithValue("@RID", returnID.ToString())
                        log.Parameters.AddWithValue("@Desc", $"Purchase Return {txtPurchaseNo.Text} saved.")
                        log.ExecuteNonQuery()

                        tran.Commit()
                        MessageBox.Show($"Purchase return '{txtPurchaseNo.Text}' saved successfully!",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearAll()
                    Catch ex As Exception
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving return: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateSave() As Boolean
        If returnTable.Rows.Count = 0 Then
            MessageBox.Show("Add at least one product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtPurchaseNo.Text) Then
            MessageBox.Show("Return number is missing.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

#End Region

#Region "Clear & Close"

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        If returnTable.Rows.Count > 0 Then
            If MessageBox.Show("Clear all items?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return
        End If
        ClearAll()
    End Sub

    Private Sub ClearAll()
        returnTable.Rows.Clear()
        RecalculateTotals()
        GenerateNewReturnNo()
        dtpPurchaseDate.Value = DateTime.Now
        cboSupplier.SelectedValue = 0
        cboPaymentStatus.SelectedIndex = 0
        TextBox1.Clear()
        txtNotes.Clear()
        ClearProductFields()
        currentEditReturnID = 0
        isEditMode = False
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnminimize_Click(sender As Object, e As EventArgs) Handles btnminimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region

#Region "Print"

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If returnTable.Rows.Count = 0 Then
            MessageBox.Show("No items to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        BuildPrintLines()
        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintPageHandler
        Dim preview As New PrintPreviewDialog()
        preview.Document = pd
        preview.ShowDialog()
    End Sub

    Private Sub BuildPrintLines()
        printLines.Clear()
        printLines.Add("===== PURCHASE RETURN =====")
        printLines.Add($"Return No : {txtPurchaseNo.Text}")
        printLines.Add($"Date      : {dtpPurchaseDate.Value:dd-MM-yyyy}")
        printLines.Add($"Supplier  : {cboSupplier.Text}")
        printLines.Add($"Ref Invoice: {TextBox1.Text}")
        printLines.Add("---------------------------")
        For Each row As DataRow In returnTable.Rows
            printLines.Add($"{row("ProductName")}")
            printLines.Add($"  Qty: {row("Quantity"):N2}  x  {row("UnitPrice"):N2}  =  {row("TotalPrice"):N2}")
        Next
        printLines.Add("---------------------------")
        printLines.Add($"Subtotal  : {calculatedSubtotal:N2}")
        printLines.Add($"Net Total : {calculatedNetTotal:N2}")
        printLines.Add("===========================")
    End Sub

    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        Dim yPos As Single = e.MarginBounds.Top
        Dim font As New Font("Courier New", 9)
        For Each line As String In printLines
            e.Graphics.DrawString(line, font, Brushes.Black, e.MarginBounds.Left, yPos)
            yPos += font.GetHeight(e.Graphics) + 2
            If yPos > e.MarginBounds.Bottom Then Exit For
        Next
    End Sub

#End Region

#Region "Generate & Supplier helpers"

    Private Sub btnGeneratePurchaseNo_Click(sender As Object, e As EventArgs) Handles btnGeneratePurchaseNo.Click
        GenerateNewReturnNo()
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        Dim frmSupp As New frmSuppliers()
        frmSupp.ShowDialog()
        LoadSuppliers()
    End Sub

    Private Sub btnPrintBarcodes_Click(sender As Object, e As EventArgs) Handles btnPrintBarcodes.Click
        If returnTable.Rows.Count = 0 Then
            MessageBox.Show("Add items to the return before printing barcodes.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Collect label data from current return items
        Dim labelItems As New List(Of String())()
        For Each row As DataRow In returnTable.Rows
            labelItems.Add(New String() {
                row("ProductName").ToString(),
                row("Barcode").ToString(),
                Convert.ToDecimal(row("UnitPrice")).ToString("N2")
            })
        Next

        Const LabelsPerPage As Integer = 10   ' 2 columns × 5 rows
        Dim pageIndex As Integer = 0

        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage,
            Sub(s As Object, args As PrintPageEventArgs)
                Dim lm As Single = args.MarginBounds.Left
                Dim tm As Single = args.MarginBounds.Top
                Dim colWidth As Single = args.MarginBounds.Width / 2
                Dim labelWidth As Single = colWidth - 8
                Dim labelHeight As Single = 95
                Dim rowGap As Single = 10

                Dim startIdx As Integer = pageIndex * LabelsPerPage
                Dim printedOnPage As Integer = 0

                Do While startIdx + printedOnPage < labelItems.Count AndAlso printedOnPage < LabelsPerPage
                    Dim r As Integer = printedOnPage \ 2
                    Dim c As Integer = printedOnPage Mod 2
                    Dim lx As Single = lm + c * colWidth + 4
                    Dim ly As Single = tm + r * (labelHeight + rowGap)
                    Dim item = labelItems(startIdx + printedOnPage)
                    DrawBarcodeLabel(args.Graphics, item(0), item(1), item(2), lx, ly, labelWidth, labelHeight)
                    printedOnPage += 1
                Loop

                pageIndex += 1
                args.HasMorePages = (pageIndex * LabelsPerPage) < labelItems.Count
            End Sub

        Dim preview As New PrintPreviewDialog()
        preview.Width = 900
        preview.Height = 700
        preview.Document = pd
        preview.ShowDialog()
    End Sub

    ''' <summary>Draws one barcode label box at the specified location.</summary>
    Private Sub DrawBarcodeLabel(g As Graphics, productName As String, barcodeText As String, price As String,
                                  x As Single, y As Single, w As Single, h As Single)
        ' Border
        g.DrawRectangle(Pens.Black, x, y, w, h)

        ' Product name (bold, truncated)
        Dim maxName As String = If(productName.Length > 38, productName.Substring(0, 38), productName)
        Using nameFont As New Font("Segoe UI", 7, FontStyle.Bold)
            g.DrawString(maxName, nameFont, Brushes.Black, New RectangleF(x + 3, y + 3, w - 6, 14))
        End Using

        ' Barcode bars
        Dim barY As Single = y + 20
        Dim barH As Single = h - 46
        DrawBarcodeLines(g, barcodeText, x + 4, barY, w - 8, barH)

        ' Barcode text centred below bars
        Using codeFont As New Font("Courier New", 6.5F)
            Dim sf As New StringFormat() With {.Alignment = StringAlignment.Center}
            g.DrawString(barcodeText, codeFont, Brushes.Black,
                         New RectangleF(x + 3, barY + barH + 2, w - 6, 12), sf)
        End Using

        ' Price right-aligned at bottom
        Using priceFont As New Font("Segoe UI", 8, FontStyle.Bold)
            Dim sf As New StringFormat() With {.Alignment = StringAlignment.Far}
            g.DrawString($"Rs. {price}", priceFont, Brushes.Black,
                         New RectangleF(x + 3, y + h - 16, w - 6, 14), sf)
        End Using
    End Sub

    ''' <summary>
    ''' Draws bar lines that represent the barcode value.
    ''' Each character produces 7 alternating bar/space elements based on its
    ''' lower 7 bits (1 = wide bar, 0 = narrow bar), giving a deterministic
    ''' visual barcode suitable for internal label printing.
    ''' </summary>
    Private Sub DrawBarcodeLines(g As Graphics, barcodeText As String,
                                  x As Single, y As Single, w As Single, h As Single)
        If String.IsNullOrWhiteSpace(barcodeText) Then Return

        ' Calculate total unit count to determine unit pixel width
        Dim totalUnits As Integer = 0
        For Each c As Char In barcodeText
            Dim v As Integer = Asc(c) And &H7F
            For bit As Integer = 6 To 0 Step -1
                totalUnits += If(((v >> bit) And 1) = 1, 3, 1)
            Next
            totalUnits += 1   ' inter-character narrow gap
        Next
        If totalUnits = 0 Then Return

        Dim unitPx As Single = w / totalUnits
        Dim cx As Single = x

        For Each c As Char In barcodeText
            Dim v As Integer = Asc(c) And &H7F
            Dim drawBar As Boolean = True
            For bit As Integer = 6 To 0 Step -1
                Dim isWide As Boolean = ((v >> bit) And 1) = 1
                Dim bw As Single = If(isWide, unitPx * 3, unitPx)
                If drawBar Then
                    g.FillRectangle(Brushes.Black, cx, y, bw, h)
                End If
                cx += bw
                drawBar = Not drawBar
            Next
            cx += unitPx   ' inter-character gap (always white)
        Next
    End Sub

#End Region

#Region "Delete Return"

    Private Sub btnDeletePurchase_Click(sender As Object, e As EventArgs) Handles btnDeletePurchase.Click
        Dim returnNo As String = txtDeletePurchaseNo.Text.Trim()
        If String.IsNullOrEmpty(returnNo) Then
            MessageBox.Show("Enter the return number to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDeletePurchaseNo.Focus()
            Return
        End If

        If MessageBox.Show($"Delete purchase return '{returnNo}'?{vbCrLf}Stock adjustments will NOT be reversed automatically.",
                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim findCmd As New MySqlCommand(
                    "SELECT ReturnID FROM purchase_returns WHERE ReturnNo = @RNo", conn)
                findCmd.Parameters.AddWithValue("@RNo", returnNo)
                Dim retID = findCmd.ExecuteScalar()
                If retID Is Nothing OrElse IsDBNull(retID) Then
                    MessageBox.Show("Return number not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim delItems As New MySqlCommand(
                    "DELETE FROM purchase_return_items WHERE ReturnID = @RID", conn)
                delItems.Parameters.AddWithValue("@RID", CInt(retID))
                delItems.ExecuteNonQuery()

                Dim delRet As New MySqlCommand(
                    "DELETE FROM purchase_returns WHERE ReturnID = @RID", conn)
                delRet.Parameters.AddWithValue("@RID", CInt(retID))
                delRet.ExecuteNonQuery()

                MessageBox.Show("Return deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDeletePurchaseNo.Clear()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting return: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditPurchase_Click(sender As Object, e As EventArgs) Handles btnEditPurchase.Click
        MessageBox.Show("To edit a return, delete it and re-enter.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region
End Class
