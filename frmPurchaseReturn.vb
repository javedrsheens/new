Imports MySql.Data.MySqlClient

Public Class frmPurchaseReturn
    ' ================================================
    ' DATABASE & CONFIGURATION
    ' ================================================
    Private ReadOnly connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer = 1

    ' ================================================
    ' DATA TABLES
    ' ================================================
    Private returnTable As New DataTable()

    ' ================================================
    ' EDIT MODE VARIABLES
    ' ================================================
    Private currentEditReturnID As Integer = 0
    Private isEditMode As Boolean = False

    ' ================================================
    ' CALCULATION VARIABLES
    ' ================================================
    Private calculatedSubtotal As Decimal = 0
    Private calculatedTax As Decimal = 0
    Private calculatedDiscount As Decimal = 0
    Private calculatedNetTotal As Decimal = 0

#Region "Form Load & Initialization"

    Private Sub frmPurchaseReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        dgvPurchaseItems.DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        dgvPurchaseItems.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)

        With dgvPurchaseItems
            .Columns("ProductID").Visible = False

            .Columns("Barcode").HeaderText = "Barcode"
            .Columns("Barcode").Width = 120
            .Columns("Barcode").ReadOnly = True

            .Columns("ProductName").HeaderText = "Product Name"
            .Columns("ProductName").Width = 250
            .Columns("ProductName").ReadOnly = True

            .Columns("Quantity").HeaderText = "Qty"
            .Columns("Quantity").Width = 80
            .Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Quantity").ReadOnly = False

            .Columns("UnitPrice").HeaderText = "Price (₹)"
            .Columns("UnitPrice").Width = 120
            .Columns("UnitPrice").DefaultCellStyle.Format = "N2"
            .Columns("UnitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("UnitPrice").ReadOnly = False

            .Columns("TotalPrice").HeaderText = "Total (₹)"
            .Columns("TotalPrice").Width = 120
            .Columns("TotalPrice").DefaultCellStyle.Format = "N2"
            .Columns("TotalPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("TotalPrice").ReadOnly = True

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .BackgroundColor = Color.MistyRose
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
        cboPaymentStatus.Items.AddRange(New String() {"Pending", "Paid", "Partial"})
        cboPaymentStatus.SelectedIndex = 0
    End Sub

    Private Sub GenerateNewReturnNo()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT CONCAT('PUR', LPAD(COALESCE(MAX(CAST(SUBSTRING(PurchaseNo, 4) AS UNSIGNED)), 0) + 1, 7, '0')) 
                                      FROM purchases 
                                      WHERE TransactionType = 'Return'"

                Dim cmd As New MySqlCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                txtPurchaseNo.Text = If(result IsNot Nothing, result.ToString(), "PUR0000001")
            End Using
        Catch ex As Exception
            txtPurchaseNo.Text = "PUR" & DateTime.Now.ToString("yyyyMMddHHmmss")
        End Try
    End Sub

#End Region

#Region "Window Controls"

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnminimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If returnTable.Rows.Count > 0 Then
            If MessageBox.Show("There are unsaved items. Are you sure you want to close?",
                             "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If
        End If
        Me.Close()
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

    Private Sub btnSearchProduct_Click(sender As Object, e As EventArgs) Handles btnSearchProduct.Click
        SearchAndLoadProduct(txtProductID.Text.Trim())
    End Sub

    Private Sub SearchAndLoadProduct(searchValue As String)
        If String.IsNullOrWhiteSpace(searchValue) Then
            MessageBox.Show("Please enter Barcode or Product ID", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                ' ✅ Match your database structure exactly
                Dim query As String = "SELECT ProductID, Barcode, ProductName, CostPrice, Stock 
                                      FROM products 
                                      WHERE (Barcode = @SearchValue OR ProductID = @SearchValue) 
                                      AND IsActive = TRUE"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SearchValue", searchValue)
                conn.Open()

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim productID As String = reader("ProductID").ToString()
                        Dim barcode As String = If(IsDBNull(reader("Barcode")), productID, reader("Barcode").ToString())
                        Dim productName As String = reader("ProductName").ToString()
                        Dim costPrice As Decimal = Convert.ToDecimal(reader("CostPrice"))
                        Dim stock As Decimal = Convert.ToDecimal(reader("Stock"))

                        txtProductID.Text = barcode
                        txtProductID.Tag = productID
                        txtProductName.Text = $"{productName} (Stock: {stock})"
                        txtUnitPrice.Text = costPrice.ToString("0.00")

                        txtProductID.BackColor = Color.LightGreen
                        Dim resetTimer As New Timer With {.Interval = 800}
                        AddHandler resetTimer.Tick, Sub(s, ev)
                                                        txtProductID.BackColor = Color.White
                                                        resetTimer.Stop()
                                                        resetTimer.Dispose()
                                                    End Sub
                        resetTimer.Start()

                        txtQuantity.Focus()
                        txtQuantity.SelectAll()
                    Else
                        txtProductID.BackColor = Color.LightCoral
                        txtProductID.Tag = Nothing
                        txtProductName.Clear()
                        txtUnitPrice.Clear()

                        MessageBox.Show($"Product '{searchValue}' not found!", "Not Found",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Dim resetTimer As New Timer With {.Interval = 800}
                        AddHandler resetTimer.Tick, Sub(s, ev)
                                                        txtProductID.BackColor = Color.White
                                                        resetTimer.Stop()
                                                        resetTimer.Dispose()
                                                    End Sub
                        resetTimer.Start()
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
            Dim productID As String = If(txtProductID.Tag IsNot Nothing, txtProductID.Tag.ToString(), txtProductID.Text.Trim())
            Dim barcode As String = txtProductID.Text.Trim()
            Dim productName As String = txtProductName.Text.Trim()

            If productName.Contains("(Stock:") Then
                productName = productName.Substring(0, productName.IndexOf("(Stock:")).Trim()
            End If

            Dim quantity As Decimal = Convert.ToDecimal(txtQuantity.Text)
            Dim unitPrice As Decimal = Convert.ToDecimal(txtUnitPrice.Text)
            Dim totalPrice As Decimal = quantity * unitPrice

            ' Check if product already exists
            Dim existingRow As DataRow = Nothing
            For Each row As DataRow In returnTable.Rows
                If row("ProductID").ToString() = productID Then
                    existingRow = row
                    Exit For
                End If
            Next

            If existingRow IsNot Nothing Then
                Dim currentQty As Decimal = Convert.ToDecimal(existingRow("Quantity"))
                Dim newQty As Decimal = currentQty + quantity
                existingRow("Quantity") = newQty
                existingRow("UnitPrice") = unitPrice
                existingRow("TotalPrice") = newQty * unitPrice
            Else
                returnTable.Rows.Add(productID, barcode, productName, quantity, unitPrice, totalPrice)
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
            MessageBox.Show("Please scan or search a valid product first", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtQuantity.Text) OrElse Not IsNumeric(txtQuantity.Text) OrElse
           Convert.ToDecimal(txtQuantity.Text) <= 0 Then
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
        If e.RowIndex >= 0 AndAlso e.RowIndex < returnTable.Rows.Count Then
            Try
                Dim qty As Decimal = Convert.ToDecimal(returnTable.Rows(e.RowIndex)("Quantity"))
                Dim price As Decimal = Convert.ToDecimal(returnTable.Rows(e.RowIndex)("UnitPrice"))
                returnTable.Rows(e.RowIndex)("TotalPrice") = qty * price
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
        If returnTable.Rows.Count > 0 Then
            If MessageBox.Show("Clear all items?", "Confirm",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                returnTable.Clear()
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

            For Each row As DataRow In returnTable.Rows
                calculatedSubtotal += Convert.ToDecimal(row("TotalPrice"))
            Next

            calculatedNetTotal = calculatedSubtotal + calculatedTax - calculatedDiscount

            lblSubtotal.Text = $"₹ {calculatedSubtotal:N2}"
            lblTax.Text = $"₹ {calculatedTax:N2}"
            lblDiscount.Text = $"₹ {calculatedDiscount:N2}"
            lblNetTotal.Text = $"₹ {calculatedNetTotal:N2}"

        Catch ex As Exception
            lblSubtotal.Text = "₹ 0.00"
            lblTax.Text = "₹ 0.00"
            lblDiscount.Text = "₹ 0.00"
            lblNetTotal.Text = "₹ 0.00"
        End Try
    End Sub

#End Region

#Region "Save Purchase Return"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SavePurchaseReturn()
    End Sub

    Private Sub SavePurchaseReturn()
        Try
            ' ✅ VALIDATION
            If returnTable.Rows.Count = 0 Then
                MessageBox.Show("Please add at least one product to return", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If cboSupplier.SelectedValue Is Nothing OrElse Convert.ToInt32(cboSupplier.SelectedValue) = 0 Then
                MessageBox.Show("Please select a supplier", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSupplier.Focus()
                Return
            End If

            If calculatedNetTotal <= 0 Then
                MessageBox.Show("Total amount must be greater than zero", "Validation",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim supplierID As Integer = Convert.ToInt32(cboSupplier.SelectedValue)

            ' ✅ CONFIRMATION
            Dim confirmMsg As String = $"Save Purchase Return?{vbCrLf}{vbCrLf}" &
                                       $"Return No: {txtPurchaseNo.Text}{vbCrLf}" &
                                       $"Supplier: {cboSupplier.Text}{vbCrLf}" &
                                       $"Items: {returnTable.Rows.Count}{vbCrLf}" &
                                       $"Total: ₹{calculatedNetTotal:N2}{vbCrLf}{vbCrLf}" &
                                       $"This will REDUCE stock."

            If MessageBox.Show(confirmMsg, "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                Try
                    ' ============================================
                    ' STEP 1: Insert Purchase Return Header
                    ' ============================================
                    Dim headerQuery As String = "INSERT INTO purchases 
                        (PurchaseNo, TransactionType, SupplierID, PurchaseDate, 
                         TotalAmount, TaxAmount, DiscountAmount, NetAmount, 
                         PaidAmount, DueAmount, PaymentStatus, Notes, CreatedBy, CreatedDate)
                        VALUES 
                        (@PurchaseNo, 'Return', @SupplierID, @PurchaseDate, 
                         @TotalAmount, @TaxAmount, @DiscountAmount, @NetAmount, 
                         @PaidAmount, @DueAmount, @PaymentStatus, @Notes, @CreatedBy, NOW());
                        SELECT LAST_INSERT_ID();"

                    Dim cmdHeader As New MySqlCommand(headerQuery, conn, transaction)
                    cmdHeader.Parameters.AddWithValue("@PurchaseNo", txtPurchaseNo.Text)
                    cmdHeader.Parameters.AddWithValue("@SupplierID", supplierID)
                    cmdHeader.Parameters.AddWithValue("@PurchaseDate", dtpPurchaseDate.Value.Date)
                    cmdHeader.Parameters.AddWithValue("@TotalAmount", calculatedSubtotal)
                    cmdHeader.Parameters.AddWithValue("@TaxAmount", calculatedTax)
                    cmdHeader.Parameters.AddWithValue("@DiscountAmount", calculatedDiscount)
                    cmdHeader.Parameters.AddWithValue("@NetAmount", calculatedNetTotal)
                    cmdHeader.Parameters.AddWithValue("@PaidAmount", 0)
                    cmdHeader.Parameters.AddWithValue("@DueAmount", calculatedNetTotal)
                    cmdHeader.Parameters.AddWithValue("@PaymentStatus", cboPaymentStatus.Text)
                    cmdHeader.Parameters.AddWithValue("@Notes", txtNotes.Text)
                    cmdHeader.Parameters.AddWithValue("@CreatedBy", CurrentUserID)

                    Dim purchaseID As Integer = Convert.ToInt32(cmdHeader.ExecuteScalar())
                    Debug.WriteLine($"✅ Purchase Return Header Saved - ID: {purchaseID}")

                    ' ============================================
                    ' STEP 2: Insert Return Items & Update Stock
                    ' ============================================
                    For Each row As DataRow In returnTable.Rows
                        Dim productID As String = row("ProductID").ToString()
                        Dim productName As String = row("ProductName").ToString()
                        Dim quantity As Decimal = Convert.ToDecimal(row("Quantity"))
                        Dim unitPrice As Decimal = Convert.ToDecimal(row("UnitPrice"))
                        Dim totalPrice As Decimal = Convert.ToDecimal(row("TotalPrice"))

                        ' 2a. Insert detail
                        Dim detailQuery As String = "INSERT INTO purchase_details 
                            (PurchaseID, ProductID, ProductName, Quantity, UnitPrice, TotalPrice)
                            VALUES (@PurchaseID, @ProductID, @ProductName, @Quantity, @UnitPrice, @TotalPrice)"

                        Dim cmdDetail As New MySqlCommand(detailQuery, conn, transaction)
                        cmdDetail.Parameters.AddWithValue("@PurchaseID", purchaseID)
                        cmdDetail.Parameters.AddWithValue("@ProductID", productID)
                        cmdDetail.Parameters.AddWithValue("@ProductName", productName)
                        cmdDetail.Parameters.AddWithValue("@Quantity", quantity)
                        cmdDetail.Parameters.AddWithValue("@UnitPrice", unitPrice)
                        cmdDetail.Parameters.AddWithValue("@TotalPrice", totalPrice)
                        cmdDetail.ExecuteNonQuery()

                        Debug.WriteLine($"  → Detail saved: {productID} x {quantity}")

                        ' 2b. Update products table (SUBTRACT stock)
                        Dim updateProductQuery As String = "UPDATE products 
                            SET Stock = Stock - @Quantity 
                            WHERE ProductID = @ProductID"

                        Dim cmdProduct As New MySqlCommand(updateProductQuery, conn, transaction)
                        cmdProduct.Parameters.AddWithValue("@Quantity", quantity)
                        cmdProduct.Parameters.AddWithValue("@ProductID", productID)
                        cmdProduct.ExecuteNonQuery()

                        Debug.WriteLine($"  → Products stock updated: -{quantity}")

                        ' 2c. Update stock table if exists
                        Try
                            Dim updateStockQuery As String = "UPDATE stock 
                                SET Quantity = Quantity - @Quantity 
                                WHERE ProductID = @ProductID"

                            Dim cmdStock As New MySqlCommand(updateStockQuery, conn, transaction)
                            cmdStock.Parameters.AddWithValue("@Quantity", quantity)
                            cmdStock.Parameters.AddWithValue("@ProductID", productID)
                            Dim rowsAffected As Integer = cmdStock.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                Debug.WriteLine($"  → Stock table updated: -{quantity}")
                            End If
                        Catch
                            ' Stock table may not exist
                        End Try

                        ' 2d. Log stock movement if table exists
                        Try
                            Dim movementQuery As String = "INSERT INTO stock_movements 
                                (StockID, ProductID, MovementType, MovementDate,
                                 QuantityChanged, UnitCost, ReferenceType, ReferenceID, 
                                 ReferenceNo, Reason, CreatedBy)
                                SELECT 
                                    s.StockID, @ProductID, 'RETURN', NOW(),
                                    -@Quantity, @UnitPrice, 'RETURN', @PurchaseID,
                                    @PurchaseNo, 'Purchase Return', @CreatedBy
                                FROM stock s
                                WHERE s.ProductID = @ProductID
                                LIMIT 1"

                            Dim cmdMovement As New MySqlCommand(movementQuery, conn, transaction)
                            cmdMovement.Parameters.AddWithValue("@ProductID", productID)
                            cmdMovement.Parameters.AddWithValue("@Quantity", quantity)
                            cmdMovement.Parameters.AddWithValue("@UnitPrice", unitPrice)
                            cmdMovement.Parameters.AddWithValue("@PurchaseID", purchaseID)
                            cmdMovement.Parameters.AddWithValue("@PurchaseNo", txtPurchaseNo.Text)
                            cmdMovement.Parameters.AddWithValue("@CreatedBy", CurrentUserID)
                            cmdMovement.ExecuteNonQuery()

                            Debug.WriteLine($"  → Movement logged")
                        Catch
                            ' stock_movements may not exist
                        End Try
                    Next

                    ' ============================================
                    ' COMMIT TRANSACTION
                    ' ============================================
                    transaction.Commit()

                    MessageBox.Show($"✅ Purchase Return Saved Successfully!{vbCrLf}{vbCrLf}" &
                                   $"Return No: {txtPurchaseNo.Text}{vbCrLf}" &
                                   $"Items: {returnTable.Rows.Count}{vbCrLf}" &
                                   $"Total: ₹{calculatedNetTotal:N2}",
                                   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ClearForm()

                Catch ex As Exception
                    transaction.Rollback()
                    Debug.WriteLine($"❌ Transaction Error: {ex.Message}")
                    Throw
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error saving purchase return:{vbCrLf}{vbCrLf}{ex.Message}",
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Helper Functions"

    Private Sub ClearForm()
        returnTable.Clear()
        GenerateNewReturnNo()
        cboSupplier.SelectedIndex = 0
        cboPaymentStatus.SelectedIndex = 0
        txtNotes.Clear()
        dtpPurchaseDate.Value = DateTime.Now
        ClearProductFields()
        CalculateTotals()
        currentEditReturnID = 0
        isEditMode = False
        txtPurchaseNo.ReadOnly = False
        txtProductID.Focus()
    End Sub

    Private Sub btnGeneratePurchaseNo_Click(sender As Object, e As EventArgs) Handles btnGeneratePurchaseNo.Click
        GenerateNewReturnNo()
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        Try
            Dim frmSupp As New frmSuppliers()
            frmSupp.ShowDialog()
            LoadSuppliers()
        Catch ex As Exception
            MessageBox.Show("Supplier form not available", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If
    End Sub

#End Region

End Class