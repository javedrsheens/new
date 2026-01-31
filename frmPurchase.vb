Imports MySql.Data.MySqlClient

Public Class frmPurchase
    ' ================================================
    ' DATABASE & CONFIGURATION
    ' ================================================
    Private ReadOnly connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer

    ' ================================================
    ' DATA TABLES
    ' ================================================
    Private purchaseTable As New DataTable()

    ' ================================================
    ' EDIT MODE VARIABLES
    ' ================================================
    Private currentEditPurchaseID As Integer = 0
    Private isEditMode As Boolean = False

    ' ================================================
    ' CALCULATION VARIABLES
    ' ================================================
    Private calculatedSubtotal As Decimal = 0
    Private calculatedTax As Decimal = 0
    Private calculatedDiscount As Decimal = 0
    Private calculatedNetTotal As Decimal = 0

#Region "Form Load & Initialization"

    Private Sub frmPurchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupPurchaseTable()
            LoadSuppliers()
            LoadPaymentStatus()
            GenerateNewPurchaseNo()
            dtpPurchaseDate.Value = DateTime.Now
            txtQuantity.Text = "1"
            txtProductID.Focus()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupPurchaseTable()
        purchaseTable.Columns.Clear()

        ' Add columns - Store ProductID internally, display Barcode
        purchaseTable.Columns.Add("ProductID", GetType(String))      ' Hidden - for database operations
        purchaseTable.Columns.Add("Barcode", GetType(String))        ' Visible - display in grid
        purchaseTable.Columns.Add("ProductName", GetType(String))
        purchaseTable.Columns.Add("Quantity", GetType(Integer))
        purchaseTable.Columns.Add("UnitPrice", GetType(Decimal))
        purchaseTable.Columns.Add("Total", GetType(Decimal))

        dgvPurchaseItems.DataSource = purchaseTable

        ' Set font: 12pt Semi-Bold
        dgvPurchaseItems.DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        dgvPurchaseItems.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)

        With dgvPurchaseItems
            ' Hide ProductID column (used internally only)
            .Columns("ProductID").Visible = False

            ' Barcode column - 150 width
            .Columns("Barcode").HeaderText = "Barcode"
            .Columns("Barcode").Width = 150
            .Columns("Barcode").ReadOnly = True

            ' Product Name - 200 width
            .Columns("ProductName").HeaderText = "Product Name"
            .Columns("ProductName").Width = 200
            .Columns("ProductName").ReadOnly = True

            ' Quantity - 50 width
            .Columns("Quantity").HeaderText = "Qty"
            .Columns("Quantity").Width = 100
            .Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Quantity").ReadOnly = False

            ' Unit Price - 100 width
            .Columns("UnitPrice").HeaderText = "Price (₹)"
            .Columns("UnitPrice").Width = 125
            .Columns("UnitPrice").DefaultCellStyle.Format = "N2"
            .Columns("UnitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("UnitPrice").ReadOnly = False

            ' Total - 100 width
            .Columns("Total").HeaderText = "Total (₹)"
            .Columns("Total").Width = 125
            .Columns("Total").DefaultCellStyle.Format = "N2"
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").ReadOnly = True

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .BackgroundColor = Color.White
            .RowHeadersWidth = 30
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End With
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT SupplierID, SupplierName, Phone 
                                      FROM suppliers 
                                      WHERE IsActive = TRUE 
                                      ORDER BY SupplierName"
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("SupplierID") = 0
                emptyRow("SupplierName") = "-- Select Supplier --"
                emptyRow("Phone") = ""
                dt.Rows.InsertAt(emptyRow, 0)

                cboSupplier.DataSource = dt
                cboSupplier.DisplayMember = "SupplierName"
                cboSupplier.ValueMember = "SupplierID"
                cboSupplier.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPaymentStatus()
        cboPaymentStatus.Items.Clear()
        cboPaymentStatus.Items.AddRange(New String() {"Paid", "Pending", "Partial"})
        cboPaymentStatus.SelectedIndex = 1
    End Sub

    Private Sub GenerateNewPurchaseNo()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT CONCAT('PUR', LPAD(COALESCE(MAX(CAST(SUBSTRING(PurchaseNo, 4) AS UNSIGNED)), 0) + 1, 6, '0')) 
                                      FROM purchases"
                Dim cmd As New MySqlCommand(query, conn)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                txtPurchaseNo.Text = If(result IsNot Nothing, result.ToString(), "PUR000001")
            End Using
        Catch ex As Exception
            txtPurchaseNo.Text = "PUR000001"
        End Try
    End Sub

#End Region

#Region "Window Controls"

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        If purchaseTable.Rows.Count > 0 Then
            If MessageBox.Show("There are unsaved items. Are you sure you want to close?",
                             "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If
        End If
        Close
    End Sub

#End Region

#Region "Product Search & Auto-Load"

    Private Sub txtProductID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductID.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not String.IsNullOrWhiteSpace(txtProductID.Text) Then
                SearchAndLoadProduct(txtProductID.Text.Trim())
                txtQuantity.Focus()
                txtQuantity.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtProductID_Leave(sender As Object, e As EventArgs) Handles txtProductID.Leave
        If Not String.IsNullOrWhiteSpace(txtProductID.Text) Then
            SearchAndLoadProduct(txtProductID.Text.Trim())
        End If
    End Sub

    Private Sub btnSearchProduct_Click(sender As Object, e As EventArgs) Handles btnSearchProduct.Click
        SearchAndLoadProduct(txtProductID.Text.Trim())
    End Sub

    Private Sub SearchAndLoadProduct(searchValue As String)
        If String.IsNullOrWhiteSpace(searchValue) Then
            MessageBox.Show("Please enter Barcode", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                ' Search by Barcode OR ProductID
                Dim query As String = "SELECT ProductID, Barcode, ProductName, CostPrice, Stock 
                                      FROM products 
                                      WHERE (Barcode = @SearchValue OR ProductID = @SearchValue) 
                                      AND IsActive = TRUE"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SearchValue", searchValue)
                conn.Open()

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Product found
                        Dim productID As String = reader("ProductID").ToString()
                        Dim barcode As String = If(IsDBNull(reader("Barcode")), productID, reader("Barcode").ToString())
                        Dim productName As String = reader("ProductName").ToString()
                        Dim costPrice As Decimal = Convert.ToDecimal(reader("CostPrice"))
                        Dim stock As Integer = Convert.ToInt32(reader("Stock"))

                        ' Display BARCODE in txtProductID (not ProductID)
                        txtProductID.Text = barcode
                        txtProductID.Tag = productID  ' Store ProductID in Tag for database operations
                        txtProductName.Text = $"{productName} (Stock: {stock})"
                        txtUnitPrice.Text = costPrice.ToString("0.00")

                        ' Visual feedback - green
                        txtProductID.BackColor = Color.LightGreen

                        ' Reset color after 1 second
                        Dim resetTimer As New Timer With {.Interval = 1000}
                        AddHandler resetTimer.Tick, Sub(s, ev)
                                                        txtProductID.BackColor = Color.White
                                                        resetTimer.Stop()
                                                        resetTimer.Dispose()
                                                    End Sub
                        resetTimer.Start()

                        txtQuantity.Focus()
                        txtQuantity.SelectAll()
                    Else
                        ' Not found
                        txtProductID.BackColor = Color.LightCoral
                        txtProductID.Tag = Nothing
                        txtProductName.Clear()
                        txtUnitPrice.Clear()

                        MessageBox.Show($"Product with barcode '{searchValue}' not found!", "Not Found",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim resetTimer As New Timer With {.Interval = 1000}
                        AddHandler resetTimer.Tick, Sub(s, ev)
                                                        txtProductID.BackColor = Color.White
                                                        resetTimer.Stop()
                                                        resetTimer.Dispose()
                                                    End Sub
                        resetTimer.Start()

                        txtProductID.SelectAll()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching product: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Add Product to Grid"

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        AddProductToGrid()
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtUnitPrice.Focus()
            txtUnitPrice.SelectAll()
        End If
    End Sub

    Private Sub txtUnitPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnitPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            AddProductToGrid()
        End If
    End Sub

    Private Sub AddProductToGrid()
        If Not ValidateProductFields() Then Return

        Try
            ' Get ProductID from Tag (stored during search)
            Dim productID As String = If(txtProductID.Tag IsNot Nothing, txtProductID.Tag.ToString(), txtProductID.Text.Trim())
            Dim barcode As String = txtProductID.Text.Trim()  ' Display barcode in grid
            Dim productName As String = txtProductName.Text.Trim()

            ' Remove stock info from product name
            If productName.Contains("(Stock:") Then
                productName = productName.Substring(0, productName.IndexOf("(Stock:")).Trim()
            End If

            Dim quantity As Integer = Convert.ToInt32(txtQuantity.Text)
            Dim unitPrice As Decimal = Convert.ToDecimal(txtUnitPrice.Text)
            Dim total As Decimal = quantity * unitPrice

            ' Check if product already exists (by ProductID)
            Dim existingRow As DataRow = Nothing
            For Each row As DataRow In purchaseTable.Rows
                If row("ProductID").ToString() = productID Then
                    existingRow = row
                    Exit For
                End If
            Next

            If existingRow IsNot Nothing Then
                ' Update existing
                Dim currentQty As Integer = Convert.ToInt32(existingRow("Quantity"))
                Dim newQty As Integer = currentQty + quantity
                existingRow("Quantity") = newQty
                existingRow("UnitPrice") = unitPrice
                existingRow("Total") = newQty * unitPrice
            Else
                ' Add new row:  ProductID (hidden), Barcode (visible), Name, Qty, Price, Total
                purchaseTable.Rows.Add(productID, barcode, productName, quantity, unitPrice, total)
            End If

            CalculateTotals()
            ClearProductFields()
            txtProductID.Focus()

        Catch ex As Exception
            MessageBox.Show($"Error adding product: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateProductFields() As Boolean
        If String.IsNullOrWhiteSpace(txtProductID.Text) OrElse txtProductID.Tag Is Nothing Then
            MessageBox.Show("Please scan or enter a valid barcode first", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse Not IsNumeric(txtQuantity.Text) OrElse
           Convert.ToInt32(txtQuantity.Text) <= 0 Then
            MessageBox.Show("Please enter valid quantity (greater than 0)", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantity.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse Not IsNumeric(txtUnitPrice.Text) OrElse
           Convert.ToDecimal(txtUnitPrice.Text) <= 0 Then
            MessageBox.Show("Please enter valid price (greater than 0)", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitPrice.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearProductFields()
        txtProductID.Clear()
        txtProductID.Tag = Nothing
        txtProductName.Clear()
        txtQuantity.Text = "1"
        txtUnitPrice.Clear()
        txtProductID.BackColor = Color.White
    End Sub

#End Region

#Region "Grid Management"

    Private Sub dgvPurchaseItems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPurchaseItems.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.RowIndex < purchaseTable.Rows.Count Then
            Try
                Dim qty As Integer = Convert.ToInt32(purchaseTable.Rows(e.RowIndex)("Quantity"))
                Dim price As Decimal = Convert.ToDecimal(purchaseTable.Rows(e.RowIndex)("UnitPrice"))
                purchaseTable.Rows(e.RowIndex)("Total") = qty * price
                CalculateTotals()
            Catch ex As Exception
                MessageBox.Show("Invalid value entered", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvPurchaseItems.SelectedRows.Count > 0 Then
            If MessageBox.Show("Remove selected item?", "Confirm",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dgvPurchaseItems.Rows.RemoveAt(dgvPurchaseItems.SelectedRows(0).Index)
                CalculateTotals()
            End If
        Else
            MessageBox.Show("Please select an item to remove", "Info",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        If purchaseTable.Rows.Count > 0 Then
            If MessageBox.Show("Clear all items? ", "Confirm",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                purchaseTable.Clear()
                CalculateTotals()
            End If
        End If
    End Sub

#End Region

#Region "Calculations"

    Private Sub CalculateTotals()
        Try
            calculatedSubtotal = 0
            calculatedTax = 0
            calculatedDiscount = 0

            For Each row As DataRow In purchaseTable.Rows
                calculatedSubtotal += Convert.ToDecimal(row("Total"))
            Next

            calculatedNetTotal = calculatedSubtotal + calculatedTax - calculatedDiscount

            lblSubtotal.Text = $"₹ {calculatedSubtotal:N2}"
            lblTax.Text = $"₹ {calculatedTax:N2}"
            lblDiscount.Text = $"₹ {calculatedDiscount:N2}"
            lblNetTotal.Text = $"₹ {calculatedNetTotal:N2}"

        Catch ex As Exception
            calculatedSubtotal = 0
            calculatedTax = 0
            calculatedDiscount = 0
            calculatedNetTotal = 0

            lblSubtotal.Text = "₹ 0.00"
            lblTax.Text = "₹ 0.00"
            lblDiscount.Text = "₹ 0.00"
            lblNetTotal.Text = "₹ 0.00"
        End Try
    End Sub

#End Region

#Region "Save Purchase"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidatePurchase() Then
            SavePurchase()
        End If
    End Sub

    Private Function ValidatePurchase() As Boolean
        If calculatedNetTotal <= 0 Then
            MessageBox.Show("Total amount must be greater than zero", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboSupplier.SelectedIndex = 0 OrElse Convert.ToInt32(cboSupplier.SelectedValue) = 0 Then
            MessageBox.Show("Please select a supplier", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSupplier.Focus()
            Return False
        End If

        If purchaseTable.Rows.Count = 0 Then
            MessageBox.Show("Please add at least one product", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SavePurchase()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                Try
                    Dim totalAmount As Decimal = calculatedSubtotal
                    Dim taxAmount As Decimal = calculatedTax
                    Dim discountAmount As Decimal = calculatedDiscount
                    Dim netAmount As Decimal = calculatedNetTotal

                    Dim paidAmount As Decimal = If(cboPaymentStatus.Text = "Paid", netAmount, 0)
                    Dim dueAmount As Decimal = netAmount - paidAmount

                    Dim purchaseID As Integer = currentEditPurchaseID

                    If isEditMode AndAlso currentEditPurchaseID > 0 Then
                        UpdateExistingPurchase(conn, transaction, purchaseID, totalAmount, taxAmount,
                                             discountAmount, netAmount, paidAmount, dueAmount)
                    Else
                        purchaseID = InsertNewPurchase(conn, transaction, totalAmount, taxAmount,
                                                      discountAmount, netAmount, paidAmount, dueAmount)
                    End If

                    InsertPurchaseDetailsAndUpdateStock(conn, transaction, purchaseID)
                    InsertDaybookEntry(conn, transaction, purchaseID, netAmount)

                    transaction.Commit()

                    Dim actionText As String = If(isEditMode, "updated", "saved")
                    MessageBox.Show($"Purchase {actionText} successfully! {vbCrLf}Purchase No: {txtPurchaseNo.Text}{vbCrLf}Total Amount: ₹ {netAmount:N2}",
                                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If MessageBox.Show("Do you want to print the purchase order?", "Print",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PrintPurchase(purchaseID)
                    End If

                    ResetForm()

                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving purchase: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function InsertNewPurchase(conn As MySqlConnection, transaction As MySqlTransaction,
                                      totalAmount As Decimal, taxAmount As Decimal, discountAmount As Decimal,
                                      netAmount As Decimal, paidAmount As Decimal, dueAmount As Decimal) As Integer
        Dim query As String = "INSERT INTO purchases 
                               (PurchaseNo, SupplierID, PurchaseDate, TotalAmount, TaxAmount, DiscountAmount, 
                                NetAmount, PaidAmount, DueAmount, PaymentStatus, Notes, CreatedBy)
                               VALUES 
                               (@PurchaseNo, @SupplierID, @PurchaseDate, @TotalAmount, @TaxAmount, @DiscountAmount,
                                @NetAmount, @PaidAmount, @DueAmount, @PaymentStatus, @Notes, @CreatedBy);
                               SELECT LAST_INSERT_ID();"

        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@PurchaseNo", txtPurchaseNo.Text)
            cmd.Parameters.AddWithValue("@SupplierID", cboSupplier.SelectedValue)
            cmd.Parameters.AddWithValue("@PurchaseDate", dtpPurchaseDate.Value.Date)
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
            cmd.Parameters.AddWithValue("@TaxAmount", taxAmount)
            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount)
            cmd.Parameters.AddWithValue("@NetAmount", netAmount)
            cmd.Parameters.AddWithValue("@PaidAmount", paidAmount)
            cmd.Parameters.AddWithValue("@DueAmount", dueAmount)
            cmd.Parameters.AddWithValue("@PaymentStatus", cboPaymentStatus.Text)
            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
            cmd.Parameters.AddWithValue("@CreatedBy", CurrentUserID)

            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Sub UpdateExistingPurchase(conn As MySqlConnection, transaction As MySqlTransaction, purchaseID As Integer,
                                      totalAmount As Decimal, taxAmount As Decimal, discountAmount As Decimal,
                                      netAmount As Decimal, paidAmount As Decimal, dueAmount As Decimal)
        ' Restore stock
        Using cmd As New MySqlCommand("UPDATE products p INNER JOIN purchase_details pd ON p.ProductID = pd.ProductID SET p.Stock = p.Stock - pd.Quantity WHERE pd.PurchaseID = @PurchaseID", conn, transaction)
            cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
            cmd.ExecuteNonQuery()
        End Using

        ' Delete old details
        Using cmd As New MySqlCommand("DELETE FROM purchase_details WHERE PurchaseID = @PurchaseID", conn, transaction)
            cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
            cmd.ExecuteNonQuery()
        End Using

        ' Delete history & daybook
        Try
            Using cmd As New MySqlCommand("DELETE FROM stock_history WHERE ReferenceID = @PurchaseID AND TransactionType = 'Purchase'", conn, transaction)
                cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        End Try

        Try
            Using cmd As New MySqlCommand("DELETE FROM daybook WHERE ReferenceType = 'Purchase' AND ReferenceID = @PurchaseID", conn, transaction)
                cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        End Try

        ' Update header
        Dim updateQuery As String = "UPDATE purchases SET 
                                     SupplierID = @SupplierID, PurchaseDate = @PurchaseDate,
                                     TotalAmount = @TotalAmount, TaxAmount = @TaxAmount,
                                     DiscountAmount = @DiscountAmount, NetAmount = @NetAmount,
                                     PaidAmount = @PaidAmount, DueAmount = @DueAmount,
                                     PaymentStatus = @PaymentStatus, Notes = @Notes
                                     WHERE PurchaseID = @PurchaseID"

        Using cmd As New MySqlCommand(updateQuery, conn, transaction)
            cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
            cmd.Parameters.AddWithValue("@SupplierID", cboSupplier.SelectedValue)
            cmd.Parameters.AddWithValue("@PurchaseDate", dtpPurchaseDate.Value.Date)
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
            cmd.Parameters.AddWithValue("@TaxAmount", taxAmount)
            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount)
            cmd.Parameters.AddWithValue("@NetAmount", netAmount)
            cmd.Parameters.AddWithValue("@PaidAmount", paidAmount)
            cmd.Parameters.AddWithValue("@DueAmount", dueAmount)
            cmd.Parameters.AddWithValue("@PaymentStatus", cboPaymentStatus.Text)
            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub InsertPurchaseDetailsAndUpdateStock(conn As MySqlConnection, transaction As MySqlTransaction, purchaseID As Integer)
        For Each row As DataRow In purchaseTable.Rows
            ' Get ProductID from hidden column
            Dim productID As String = row("ProductID").ToString()
            Dim productName As String = row("ProductName").ToString()
            Dim quantity As Integer = Convert.ToInt32(row("Quantity"))
            Dim unitPrice As Decimal = Convert.ToDecimal(row("UnitPrice"))
            Dim totalPrice As Decimal = Convert.ToDecimal(row("Total"))

            ' Insert detail
            Dim detailQuery As String = "INSERT INTO purchase_details 
                                         (PurchaseID, ProductID, ProductName, Quantity, UnitPrice, TotalPrice)
                                         VALUES (@PurchaseID, @ProductID, @ProductName, @Quantity, @UnitPrice, @TotalPrice)"
            Using cmd As New MySqlCommand(detailQuery, conn, transaction)
                cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                cmd.Parameters.AddWithValue("@ProductName", productName)
                cmd.Parameters.AddWithValue("@Quantity", quantity)
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice)
                cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                cmd.ExecuteNonQuery()
            End Using

            ' Update stock
            Using cmd As New MySqlCommand("UPDATE products SET Stock = Stock + @Quantity WHERE ProductID = @ProductID", conn, transaction)
                cmd.Parameters.AddWithValue("@Quantity", quantity)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                cmd.ExecuteNonQuery()
            End Using

            ' Stock history
            Try
                Using cmd As New MySqlCommand("INSERT INTO stock_history (ProductID, TransactionType, QuantityChanged, ReferenceID) VALUES (@ProductID, 'Purchase', @Quantity, @PurchaseID)", conn, transaction)
                    cmd.Parameters.AddWithValue("@ProductID", productID)
                    cmd.Parameters.AddWithValue("@Quantity", quantity)
                    cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                    cmd.ExecuteNonQuery()
                End Using
            Catch
            End Try
        Next
    End Sub

    Private Sub InsertDaybookEntry(conn As MySqlConnection, transaction As MySqlTransaction, purchaseID As Integer, netAmount As Decimal)
        Try
            Dim query As String = "INSERT INTO daybook 
                                  (TransactionType, ReferenceType, ReferenceNo, ReferenceID, PartyName, 
                                   Description, CreditAmount, PaymentMethod, RecordedBy)
                                  VALUES 
                                  ('Purchase', 'Purchase', @PurchaseNo, @PurchaseID, @SupplierName, 
                                   @Description, @Amount, 'Cash', @UserID)"
            Using cmd As New MySqlCommand(query, conn, transaction)
                cmd.Parameters.AddWithValue("@PurchaseNo", txtPurchaseNo.Text)
                cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                cmd.Parameters.AddWithValue("@SupplierName", cboSupplier.Text)
                cmd.Parameters.AddWithValue("@Description", $"Purchase - {txtPurchaseNo.Text}")
                cmd.Parameters.AddWithValue("@Amount", netAmount)
                cmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

#End Region

#Region "Edit Purchase"

    Private Sub btnEditPurchase_Click(sender As Object, e As EventArgs) Handles btnEditPurchase.Click
        EditPurchase()
    End Sub

    Private Sub EditPurchase()
        Dim purchaseNo As String = txtDeletePurchaseNo.Text.Trim()

        If String.IsNullOrWhiteSpace(purchaseNo) Then
            MessageBox.Show("Please enter Purchase Number", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDeletePurchaseNo.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT p.PurchaseID, p.PurchaseNo, p.SupplierID, p.PurchaseDate, 
                                         p.PaymentStatus, p.Notes, s. SupplierName, p.NetAmount
                                  FROM purchases p
                                  INNER JOIN suppliers s ON p. SupplierID = s. SupplierID
                                  WHERE p.PurchaseNo = @PurchaseNo"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@PurchaseNo", purchaseNo)
                    conn.Open()

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim purchaseID As Integer = Convert.ToInt32(reader("PurchaseID"))
                            Dim supplierID As Integer = Convert.ToInt32(reader("SupplierID"))
                            Dim purchaseDate As DateTime = Convert.ToDateTime(reader("PurchaseDate"))
                            Dim paymentStatus As String = reader("PaymentStatus").ToString()
                            Dim notes As String = If(IsDBNull(reader("Notes")), "", reader("Notes").ToString())
                            Dim supplierName As String = reader("SupplierName").ToString()
                            Dim netAmount As Decimal = Convert.ToDecimal(reader("NetAmount"))

                            Dim result = MessageBox.Show($"Edit Purchase: {purchaseNo}{vbCrLf}Supplier: {supplierName}{vbCrLf}Amount: ₹ {netAmount:N2}{vbCrLf}Date: {purchaseDate:dd-MMM-yyyy}{vbCrLf}{vbCrLf}Continue?",
                                               "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If result = DialogResult.Yes Then
                                reader.Close()
                                LoadPurchaseForEdit(purchaseID, purchaseNo, supplierID, purchaseDate, paymentStatus, notes)
                                txtDeletePurchaseNo.Clear()
                            End If
                        Else
                            MessageBox.Show($"Purchase '{purchaseNo}' not found!", "Not Found",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtDeletePurchaseNo.Focus()
                            txtDeletePurchaseNo.SelectAll()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading purchase: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPurchaseForEdit(purchaseID As Integer, purchaseNo As String, supplierID As Integer,
                                   purchaseDate As DateTime, paymentStatus As String, notes As String)
        Try
            purchaseTable.Clear()

            Using conn As New MySqlConnection(connectionString)
                ' Load details with barcode
                Dim query As String = "SELECT pd.ProductID, COALESCE(p. Barcode, pd.ProductID) AS Barcode, 
                                      pd.ProductName, pd. Quantity, pd.UnitPrice, pd.TotalPrice
                                      FROM purchase_details pd
                                      LEFT JOIN products p ON pd. ProductID = p.ProductID
                                      WHERE pd.PurchaseID = @PurchaseID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                    conn.Open()

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            purchaseTable.Rows.Add(
                                reader("ProductID").ToString(),
                                reader("Barcode").ToString(),
                                reader("ProductName").ToString(),
                                Convert.ToInt32(reader("Quantity")),
                                Convert.ToDecimal(reader("UnitPrice")),
                                Convert.ToDecimal(reader("TotalPrice"))
                            )
                        End While
                    End Using
                End Using
            End Using

            txtPurchaseNo.Text = purchaseNo
            txtPurchaseNo.ReadOnly = True
            cboSupplier.SelectedValue = supplierID
            dtpPurchaseDate.Value = purchaseDate
            cboPaymentStatus.Text = paymentStatus
            txtNotes.Text = notes

            currentEditPurchaseID = purchaseID
            isEditMode = True

            CalculateTotals()

            MessageBox.Show($"Purchase '{purchaseNo}' loaded. {vbCrLf}Make changes and click Save.",
                  "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtProductID.Focus()

        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Delete Purchase"

    Private Sub btnDeletePurchase_Click(sender As Object, e As EventArgs) Handles btnDeletePurchase.Click
        DeletePurchase()
    End Sub

    Private Sub DeletePurchase()
        Dim purchaseNo As String = txtDeletePurchaseNo.Text.Trim()

        If String.IsNullOrWhiteSpace(purchaseNo) Then
            MessageBox.Show("Please enter Purchase Number", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDeletePurchaseNo.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT p.PurchaseID, p.NetAmount, s.SupplierName, p.PurchaseDate, p.PaymentStatus
                                     FROM purchases p
                                     INNER JOIN suppliers s ON p. SupplierID = s. SupplierID
                                     WHERE p.PurchaseNo = @PurchaseNo"

                Dim purchaseID As Integer
                Dim amount As Decimal
                Dim supplierName As String
                Dim purchaseDate As DateTime
                Dim paymentStatus As String

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@PurchaseNo", purchaseNo)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            MessageBox.Show($"Purchase '{purchaseNo}' not found!", "Not Found",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtDeletePurchaseNo.Focus()
                            txtDeletePurchaseNo.SelectAll()
                            Return
                        End If

                        purchaseID = Convert.ToInt32(reader("PurchaseID"))
                        amount = Convert.ToDecimal(reader("NetAmount"))
                        supplierName = reader("SupplierName").ToString()
                        purchaseDate = Convert.ToDateTime(reader("PurchaseDate"))
                        paymentStatus = reader("PaymentStatus").ToString()
                    End Using
                End Using

                Dim result = MessageBox.Show($"⚠️ DELETE PURCHASE{vbCrLf}{vbCrLf}Purchase No: {purchaseNo}{vbCrLf}Supplier:  {supplierName}{vbCrLf}Amount: ₹ {amount:N2}{vbCrLf}Status: {paymentStatus}{vbCrLf}Date: {purchaseDate:dd-MMM-yyyy}{vbCrLf}{vbCrLf}This will reduce stock. {vbCrLf}Cannot be undone! {vbCrLf}{vbCrLf}Continue? ",
                                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.No Then Return

                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                Try
                    Using cmd As New MySqlCommand("UPDATE products p INNER JOIN purchase_details pd ON p.ProductID = pd.ProductID SET p.Stock = p. Stock - pd.Quantity WHERE pd.PurchaseID = @PurchaseID", conn, transaction)
                        cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New MySqlCommand("DELETE FROM purchase_details WHERE PurchaseID = @PurchaseID", conn, transaction)
                        cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Try
                        Using cmd As New MySqlCommand("DELETE FROM stock_history WHERE ReferenceID = @PurchaseID AND TransactionType = 'Purchase'", conn, transaction)
                            cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch
                    End Try

                    Try
                        Using cmd As New MySqlCommand("DELETE FROM daybook WHERE ReferenceType = 'Purchase' AND ReferenceID = @PurchaseID", conn, transaction)
                            cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch
                    End Try

                    Using cmd As New MySqlCommand("DELETE FROM purchases WHERE PurchaseID = @PurchaseID", conn, transaction)
                        cmd.Parameters.AddWithValue("@PurchaseID", purchaseID)
                        cmd.ExecuteNonQuery()
                    End Using

                    transaction.Commit()

                    MessageBox.Show($"Purchase '{purchaseNo}' deleted! {vbCrLf}Stock reduced. {vbCrLf}Daybook entry removed.",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    txtDeletePurchaseNo.Clear()

                Catch ex As Exception
                    transaction.Rollback()
                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting purchase: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Helper Functions & Events"

    Private Sub btnGeneratePurchaseNo_Click(sender As Object, e As EventArgs) Handles btnGeneratePurchaseNo.Click
        GenerateNewPurchaseNo()
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        Dim frmSupp As New frmSuppliers()
        frmSupp.ShowDialog()
        LoadSuppliers()
    End Sub

    Private Sub PrintPurchase(purchaseID As Integer)
        MessageBox.Show("Print feature - To be implemented", "Info",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ResetForm()
        purchaseTable.Clear()
        GenerateNewPurchaseNo()
        cboSupplier.SelectedIndex = 0
        cboPaymentStatus.SelectedIndex = 1
        txtNotes.Clear()
        dtpPurchaseDate.Value = DateTime.Now
        ClearProductFields()

        calculatedSubtotal = 0
        calculatedTax = 0
        calculatedDiscount = 0
        calculatedNetTotal = 0

        CalculateTotals()

        currentEditPurchaseID = 0
        isEditMode = False
        txtPurchaseNo.ReadOnly = False

        txtProductID.Focus()
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso txtUnitPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDeletePurchaseNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDeletePurchaseNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If MessageBox.Show("Edit or Delete?", "Action", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question) = DialogResult.Yes Then
                EditPurchase()
            Else
                DeletePurchase()
            End If
        End If
    End Sub

    Private Sub txtDeletePurchaseNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDeletePurchaseNo.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs) Handles txtProductID.TextChanged
        ' Future:  Auto-complete
    End Sub

    Private Sub lblNetTotalLabel_Click(sender As Object, e As EventArgs) Handles lblNetTotalLabel.Click

    End Sub

#End Region

End Class