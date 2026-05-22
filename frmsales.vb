Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Text

Public Class frmsales
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer
    Public CurrentUserName As String

    Private saleTable As DataTable
    Private heldSaleTable As DataTable = Nothing
    Private heldInvoiceNo As String = String.Empty
    Private heldCustomerID As Integer = 0
    Private heldPaidAmount As Decimal = 0D
    Private heldPaymentMethod As String = "Cash"
    Private lastPrintedLines As List(Of String) = New List(Of String)()
    Private currentInvoiceNo As String = String.Empty

    Private Sub frmsales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitializeSaleTable()
            SetupSaleGrid()
            LoadCustomers()
            GenerateInvoiceNumber()
            UpdateDateTime()
            tmrClock.Start()
            ApplyPaymentMode()
            UpdateTotals()
            txtBarcode.Focus()
        Catch ex As Exception
            MessageBox.Show($"Error loading sales form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeSaleTable()
        saleTable = New DataTable()
        saleTable.Columns.Add("ProductID", GetType(Integer))
        saleTable.Columns.Add("Barcode", GetType(String))
        saleTable.Columns.Add("ProductName", GetType(String))
        saleTable.Columns.Add("Qty", GetType(Decimal))
        saleTable.Columns.Add("Rate", GetType(Decimal))
        saleTable.Columns.Add("Discount", GetType(Decimal))
        saleTable.Columns.Add("Amount", GetType(Decimal))
        dgvSaleItems.AutoGenerateColumns = False
        dgvSaleItems.DataSource = saleTable
    End Sub

    Private Sub SetupSaleGrid()
        With dgvSaleItems
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.Fixed3D
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        End With

        colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colRate.DefaultCellStyle.Format = "N2"
        colDiscount.DefaultCellStyle.Format = "N2"
        colAmount.DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub LoadCustomers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim dt As New DataTable()
                dt.Columns.Add("CustomerID", GetType(Integer))
                dt.Columns.Add("CustomerName", GetType(String))
                dt.Rows.Add(0, "Walk In Customer")

                Dim adapter As New MySqlDataAdapter("SELECT CustomerID, CustomerName FROM customers WHERE IsActive = 1 ORDER BY CustomerName", conn)
                adapter.Fill(dt)

                cboCustomer.DataSource = dt
                cboCustomer.DisplayMember = "CustomerName"
                cboCustomer.ValueMember = "CustomerID"
                cboCustomer.SelectedValue = 0
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateInvoiceNumber()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT COUNT(*) + 1 FROM sales WHERE YEAR(SaleDate) = @SaleYear"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@SaleYear", DateTime.Now.Year)
                    Dim seq As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    currentInvoiceNo = $"INV-{DateTime.Now:yyyy}-{seq:0000}"
                    lblInvoiceNo.Text = currentInvoiceNo
                End Using
            End Using
        Catch
            currentInvoiceNo = $"INV-{DateTime.Now:yyyy}-{DateTime.Now:HHmm}"
            lblInvoiceNo.Text = currentInvoiceNo
        End Try
    End Sub

    Private Sub UpdateDateTime()
        lblDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt")
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        UpdateDateTime()
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            AddItemFromInputs()
        End If
    End Sub

    Private Sub txtProductSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            AddItemFromInputs()
        End If
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        AddItemFromInputs()
    End Sub

    Private Sub AddItemFromInputs()
        Dim quantity As Decimal = numQty.Value
        If Not String.IsNullOrWhiteSpace(txtBarcode.Text) Then
            LookupAndAddProduct(txtBarcode.Text.Trim(), quantity)
        ElseIf Not String.IsNullOrWhiteSpace(txtProductSearch.Text) Then
            LookupAndAddProduct(txtProductSearch.Text.Trim(), quantity)
        Else
            MessageBox.Show("Enter barcode or product search text.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LookupAndAddProduct(searchText As String, quantity As Decimal)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT ProductID, Barcode, ProductName, UnitPrice, Stock " &
                                    "FROM products " &
                                    "WHERE IsActive = 1 AND (Barcode = @ExactSearch OR ProductName LIKE @LikeSearch OR Barcode LIKE @LikeSearch) " &
                                    "ORDER BY CASE WHEN Barcode = @ExactSearch THEN 0 WHEN ProductName LIKE @LikeSearch THEN 1 ELSE 2 END, ProductName LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ExactSearch", searchText)
                    cmd.Parameters.AddWithValue("@LikeSearch", $"%{searchText}%")

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim productID As Integer = Convert.ToInt32(reader("ProductID"))
                            Dim barcode As String = reader("Barcode").ToString()
                            Dim productName As String = reader("ProductName").ToString()
                            Dim rate As Decimal = Convert.ToDecimal(reader("UnitPrice"))
                            Dim stock As Decimal = Convert.ToDecimal(reader("Stock"))
                            AddProductToGrid(productID, barcode, productName, rate, quantity, stock)
                        Else
                            MessageBox.Show("Product not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddProductToGrid(productID As Integer, barcode As String, productName As String, rate As Decimal, quantity As Decimal, availableStock As Decimal)
        Try
            For Each row As DataRow In saleTable.Rows
                If Convert.ToInt32(row("ProductID")) = productID Then
                    Dim newQty As Decimal = Convert.ToDecimal(row("Qty")) + quantity
                    If newQty > availableStock Then
                        MessageBox.Show("Insufficient stock for selected quantity.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                    row("Qty") = newQty
                    RecalculateRow(row)
                    UpdateTotals()
                    ClearScanInputs()
                    Return
                End If
            Next

            If quantity > availableStock Then
                MessageBox.Show("Insufficient stock for selected quantity.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim newRow = saleTable.NewRow()
            newRow("ProductID") = productID
            newRow("Barcode") = barcode
            newRow("ProductName") = productName
            newRow("Qty") = quantity
            newRow("Rate") = rate
            newRow("Discount") = 0D
            newRow("Amount") = quantity * rate
            saleTable.Rows.Add(newRow)
            UpdateTotals()
            ClearScanInputs()
        Catch ex As Exception
            MessageBox.Show($"Error adding item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearScanInputs()
        txtBarcode.Clear()
        txtProductSearch.Clear()
        numQty.Value = 1D
        txtBarcode.Focus()
    End Sub

    Private Sub dgvSaleItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSaleItems.CellEndEdit
        If e.RowIndex < 0 Then Return
        Try
            Dim row = saleTable.Rows(e.RowIndex)
            Dim qty As Decimal
            Dim discount As Decimal

            If Not Decimal.TryParse(If(dgvSaleItems.Rows(e.RowIndex).Cells("colQty").Value, "0").ToString(), qty) OrElse qty <= 0D Then
                qty = 1D
                row("Qty") = qty
            End If

            If Not Decimal.TryParse(If(dgvSaleItems.Rows(e.RowIndex).Cells("colDiscount").Value, "0").ToString(), discount) OrElse discount < 0D Then
                discount = 0D
                row("Discount") = discount
            End If

            Dim availableStock As Decimal = GetAvailableStock(Convert.ToInt32(row("ProductID")))
            If qty > availableStock Then
                MessageBox.Show("Entered quantity exceeds available stock.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                row("Qty") = availableStock
            End If

            RecalculateRow(row)
            UpdateTotals()
        Catch ex As Exception
            MessageBox.Show($"Error updating item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetAvailableStock(productID As Integer) As Decimal
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Using cmd As New MySqlCommand("SELECT COALESCE(Stock,0) FROM products WHERE ProductID = @ProductID", conn)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                Return Convert.ToDecimal(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Private Sub RecalculateRow(row As DataRow)
        Dim qty As Decimal = Convert.ToDecimal(row("Qty"))
        Dim rate As Decimal = Convert.ToDecimal(row("Rate"))
        Dim discount As Decimal = Convert.ToDecimal(row("Discount"))
        Dim gross As Decimal = qty * rate
        If discount > gross Then discount = gross
        row("Discount") = discount
        row("Amount") = gross - discount
    End Sub

    Private Sub UpdateTotals()
        Dim subtotal As Decimal = 0D
        Dim totalDiscount As Decimal = 0D
        Dim netAmount As Decimal = 0D

        For Each row As DataRow In saleTable.Rows
            subtotal += Convert.ToDecimal(row("Qty")) * Convert.ToDecimal(row("Rate"))
            totalDiscount += Convert.ToDecimal(row("Discount"))
            netAmount += Convert.ToDecimal(row("Amount"))
        Next

        lblSubTotal.Text = subtotal.ToString("N2")
        lblDiscountTotal.Text = totalDiscount.ToString("N2")
        lblNetAmount.Text = netAmount.ToString("N2")
        ApplyPaymentMode()
        CalculateChange()
    End Sub

    Private Sub CalculateChange()
        Dim netAmount As Decimal = ParseAmount(lblNetAmount.Text)
        Dim paidAmount As Decimal = ParseAmount(txtPaidAmount.Text)

        If rbCredit.Checked Then
            lblChange.Text = "0.00"
        Else
            Dim changeAmount As Decimal = paidAmount - netAmount
            If changeAmount < 0D Then changeAmount = 0D
            lblChange.Text = changeAmount.ToString("N2")
        End If
    End Sub

    Private Function ParseAmount(textValue As String) As Decimal
        Dim value As Decimal = 0D
        Decimal.TryParse(textValue, value)
        Return value
    End Function

    Private Sub PaymentMethod_CheckedChanged(sender As Object, e As EventArgs) Handles rbCash.CheckedChanged, rbCredit.CheckedChanged, rbBank.CheckedChanged
        ApplyPaymentMode()
        CalculateChange()
    End Sub

    Private Sub ApplyPaymentMode()
        Dim netAmount As Decimal = ParseAmount(lblNetAmount.Text)
        If rbCredit.Checked Then
            txtPaidAmount.Text = "0.00"
            txtPaidAmount.ReadOnly = True
        Else
            txtPaidAmount.ReadOnly = False
            If ParseAmount(txtPaidAmount.Text) = 0D AndAlso netAmount > 0D Then
                txtPaidAmount.Text = netAmount.ToString("N2")
            End If
        End If
    End Sub

    Private Sub txtPaidAmount_TextChanged(sender As Object, e As EventArgs) Handles txtPaidAmount.TextChanged
        CalculateChange()
    End Sub

    Private Function GetPaymentMethod() As String
        If rbCredit.Checked Then Return "Credit"
        If rbBank.Checked Then Return "Bank"
        Return "Cash"
    End Function

    Private Function ValidateSale() As Boolean
        If saleTable.Rows.Count = 0 Then
            MessageBox.Show("Add at least one item.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not rbCredit.Checked Then
            Dim netAmount As Decimal = ParseAmount(lblNetAmount.Text)
            Dim paidAmount As Decimal = ParseAmount(txtPaidAmount.Text)
            If paidAmount < netAmount Then
                MessageBox.Show("Paid amount cannot be less than net amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPaidAmount.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Function GetOrCreateAccountID(conn As MySqlConnection, transaction As MySqlTransaction, accountCode As String, accountName As String, accountType As String) As Integer
        Using cmd As New MySqlCommand("SELECT AccountID FROM accounts WHERE AccountName=@AccountName LIMIT 1", conn, transaction)
            cmd.Parameters.AddWithValue("@AccountName", accountName)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                Return Convert.ToInt32(result)
            End If
        End Using

        Using cmd As New MySqlCommand("INSERT INTO accounts (AccountCode, AccountName, AccountType, ParentAccountID, OpeningBalance, IsActive, CreatedDate) VALUES (@AccountCode, @AccountName, @AccountType, NULL, 0, 1, NOW())", conn, transaction)
            cmd.Parameters.AddWithValue("@AccountCode", accountCode)
            cmd.Parameters.AddWithValue("@AccountName", accountName)
            cmd.Parameters.AddWithValue("@AccountType", accountType)
            cmd.ExecuteNonQuery()
            Return Convert.ToInt32(cmd.LastInsertedId)
        End Using
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateSale() Then Return

        Dim subtotal As Decimal = ParseAmount(lblSubTotal.Text)
        Dim totalDiscount As Decimal = ParseAmount(lblDiscountTotal.Text)
        Dim netAmount As Decimal = ParseAmount(lblNetAmount.Text)
        Dim paymentMethod As String = GetPaymentMethod()
        Dim paidAmount As Decimal = If(paymentMethod = "Credit", 0D, ParseAmount(txtPaidAmount.Text))
        Dim changeAmount As Decimal = If(paymentMethod = "Credit", 0D, ParseAmount(lblChange.Text))
        Dim saleStatus As String = If(paymentMethod = "Credit", "Credit", "Paid")
        Dim customerValue As Object = If(cboCustomer.SelectedValue Is Nothing OrElse Convert.ToInt32(cboCustomer.SelectedValue) = 0, CType(DBNull.Value, Object), cboCustomer.SelectedValue)
        Dim saleID As Integer = 0
        Dim receiptSnapshot As DataTable = saleTable.Copy()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        For Each row As DataRow In saleTable.Rows
                            Using stockCmd As New MySqlCommand("SELECT COALESCE(Stock,0) FROM products WHERE ProductID=@ProductID", conn, transaction)
                                stockCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row("ProductID")))
                                Dim currentStock As Decimal = Convert.ToDecimal(stockCmd.ExecuteScalar())
                                If Convert.ToDecimal(row("Qty")) > currentStock Then
                                    Throw New Exception($"Insufficient stock for product '{row("ProductName")}'.")
                                End If
                            End Using
                        Next

                        Dim saleSql As String = "INSERT INTO sales (InvoiceNo, SaleDate, CustomerID, SubTotal, DiscountAmount, NetAmount, PaidAmount, ChangeAmount, PaymentMethod, Status, UserID) VALUES (@InvoiceNo, NOW(), @CustomerID, @SubTotal, @DiscountAmount, @NetAmount, @PaidAmount, @ChangeAmount, @PaymentMethod, @Status, @UserID)"
                        Using saleCmd As New MySqlCommand(saleSql, conn, transaction)
                            saleCmd.Parameters.AddWithValue("@InvoiceNo", currentInvoiceNo)
                            saleCmd.Parameters.AddWithValue("@CustomerID", customerValue)
                            saleCmd.Parameters.AddWithValue("@SubTotal", subtotal)
                            saleCmd.Parameters.AddWithValue("@DiscountAmount", totalDiscount)
                            saleCmd.Parameters.AddWithValue("@NetAmount", netAmount)
                            saleCmd.Parameters.AddWithValue("@PaidAmount", paidAmount)
                            saleCmd.Parameters.AddWithValue("@ChangeAmount", changeAmount)
                            saleCmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                            saleCmd.Parameters.AddWithValue("@Status", saleStatus)
                            saleCmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            saleCmd.ExecuteNonQuery()
                            saleID = Convert.ToInt32(saleCmd.LastInsertedId)
                        End Using

                        For Each row As DataRow In saleTable.Rows
                            Using itemCmd As New MySqlCommand("INSERT INTO sales_items (SaleID, ProductID, Quantity, UnitPrice, Discount, Amount) VALUES (@SaleID, @ProductID, @Quantity, @UnitPrice, @Discount, @Amount)", conn, transaction)
                                itemCmd.Parameters.AddWithValue("@SaleID", saleID)
                                itemCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row("ProductID")))
                                itemCmd.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(row("Qty")))
                                itemCmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(row("Rate")))
                                itemCmd.Parameters.AddWithValue("@Discount", Convert.ToDecimal(row("Discount")))
                                itemCmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(row("Amount")))
                                itemCmd.ExecuteNonQuery()
                            End Using

                            Using stockCmd As New MySqlCommand("UPDATE products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID", conn, transaction)
                                stockCmd.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(row("Qty")))
                                stockCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row("ProductID")))
                                stockCmd.ExecuteNonQuery()
                            End Using
                        Next

                        Dim journalID As Integer
                        Using journalCmd As New MySqlCommand("INSERT INTO journal_entries (EntryDate, Description, ReferenceType, ReferenceID, UserID) VALUES (NOW(), @Description, @ReferenceType, @ReferenceID, @UserID)", conn, transaction)
                            journalCmd.Parameters.AddWithValue("@Description", $"Sale Invoice {currentInvoiceNo}")
                            journalCmd.Parameters.AddWithValue("@ReferenceType", "Sales")
                            journalCmd.Parameters.AddWithValue("@ReferenceID", saleID)
                            journalCmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            journalCmd.ExecuteNonQuery()
                            journalID = Convert.ToInt32(journalCmd.LastInsertedId)
                        End Using

                        Dim debitAccountID As Integer
                        If paymentMethod = "Cash" Then
                            debitAccountID = GetOrCreateAccountID(conn, transaction, "1000", "Cash In Hand", "Asset")
                        ElseIf paymentMethod = "Bank" Then
                            debitAccountID = GetOrCreateAccountID(conn, transaction, "1010", "Bank Account", "Asset")
                        Else
                            debitAccountID = GetOrCreateAccountID(conn, transaction, "1100", "Accounts Receivable", "Asset")
                        End If
                        Dim salesAccountID As Integer = GetOrCreateAccountID(conn, transaction, "4000", "Sales Income", "Income")

                        Using detailCmd As New MySqlCommand("INSERT INTO journal_details (JournalID, AccountID, DebitAmount, CreditAmount, Description) VALUES (@JournalID, @AccountID, @DebitAmount, @CreditAmount, @Description)", conn, transaction)
                            detailCmd.Parameters.Add("@JournalID", MySqlDbType.Int32)
                            detailCmd.Parameters.Add("@AccountID", MySqlDbType.Int32)
                            detailCmd.Parameters.Add("@DebitAmount", MySqlDbType.Decimal)
                            detailCmd.Parameters.Add("@CreditAmount", MySqlDbType.Decimal)
                            detailCmd.Parameters.Add("@Description", MySqlDbType.VarChar)

                            detailCmd.Parameters("@JournalID").Value = journalID
                            detailCmd.Parameters("@AccountID").Value = debitAccountID
                            detailCmd.Parameters("@DebitAmount").Value = netAmount
                            detailCmd.Parameters("@CreditAmount").Value = 0D
                            detailCmd.Parameters("@Description").Value = $"Debit for sale {currentInvoiceNo}"
                            detailCmd.ExecuteNonQuery()

                            detailCmd.Parameters("@JournalID").Value = journalID
                            detailCmd.Parameters("@AccountID").Value = salesAccountID
                            detailCmd.Parameters("@DebitAmount").Value = 0D
                            detailCmd.Parameters("@CreditAmount").Value = netAmount
                            detailCmd.Parameters("@Description").Value = $"Credit sales income for {currentInvoiceNo}"
                            detailCmd.ExecuteNonQuery()
                        End Using

                        Using daybookCmd As New MySqlCommand("INSERT INTO daybook (TransactionDate, TransactionType, Description, DebitAmount, CreditAmount, ReferenceNo, PaymentMethod, UserID) VALUES (NOW(), @TransactionType, @Description, @DebitAmount, @CreditAmount, @ReferenceNo, @PaymentMethod, @UserID)", conn, transaction)
                            daybookCmd.Parameters.AddWithValue("@TransactionType", "Sales")
                            daybookCmd.Parameters.AddWithValue("@Description", $"Sales invoice {currentInvoiceNo}")
                            daybookCmd.Parameters.AddWithValue("@DebitAmount", If(paymentMethod = "Credit", 0D, netAmount))
                            daybookCmd.Parameters.AddWithValue("@CreditAmount", 0D)
                            daybookCmd.Parameters.AddWithValue("@ReferenceNo", currentInvoiceNo)
                            daybookCmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                            daybookCmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            daybookCmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                    Catch
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            BuildReceiptLines(receiptSnapshot, paymentMethod, subtotal, totalDiscount, netAmount, paidAmount, changeAmount)
            MessageBox.Show("Sale saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ShowPrintPreview()
            ClearSale(True)
        Catch ex As Exception
            MessageBox.Show($"Error saving sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuildReceiptLines(items As DataTable, paymentMethod As String, subtotal As Decimal, totalDiscount As Decimal, netAmount As Decimal, paidAmount As Decimal, changeAmount As Decimal)
        lastPrintedLines = New List(Of String) From {
            "FAMILY CHOICE SHOP",
            "POS SALES RECEIPT",
            "----------------------------------------",
            $"Invoice : {currentInvoiceNo}",
            $"Date    : {DateTime.Now:dd-MMM-yyyy hh:mm tt}",
            $"Cashier : {If(String.IsNullOrWhiteSpace(CurrentUserName), "User", CurrentUserName)}",
            $"Customer: {cboCustomer.Text}",
            "----------------------------------------"
        }

        For Each row As DataRow In items.Rows
            lastPrintedLines.Add(row("ProductName").ToString())
            lastPrintedLines.Add($"{Convert.ToDecimal(row("Qty")):N2} x {Convert.ToDecimal(row("Rate")):N2}  Disc:{Convert.ToDecimal(row("Discount")):N2}  Amt:{Convert.ToDecimal(row("Amount")):N2}")
        Next

        lastPrintedLines.Add("----------------------------------------")
        lastPrintedLines.Add($"Sub Total : {subtotal:N2}")
        lastPrintedLines.Add($"Discount  : {totalDiscount:N2}")
        lastPrintedLines.Add($"Net Total : {netAmount:N2}")
        lastPrintedLines.Add($"Paid      : {paidAmount:N2}")
        lastPrintedLines.Add($"Change    : {changeAmount:N2}")
        lastPrintedLines.Add($"Payment   : {paymentMethod}")
        lastPrintedLines.Add("----------------------------------------")
        lastPrintedLines.Add("Thank you for shopping!")
    End Sub

    Private Sub ShowPrintPreview()
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintReceiptPage
            Dim preview As New PrintPreviewDialog()
            preview.Document = printDoc
            preview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show($"Sale saved, but print preview failed: {ex.Message}", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub PrintReceiptPage(sender As Object, e As PrintPageEventArgs)
        Dim yPos As Integer = 20
        For Each line As String In lastPrintedLines
            e.Graphics.DrawString(line, New Font("Consolas", 9), Brushes.Black, 20, yPos)
            yPos += 20
        Next
    End Sub

    Private Sub btnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        Try
            If saleTable.Rows.Count > 0 Then
                heldSaleTable = saleTable.Copy()
                heldInvoiceNo = currentInvoiceNo
                heldCustomerID = If(cboCustomer.SelectedValue Is Nothing, 0, Convert.ToInt32(cboCustomer.SelectedValue))
                heldPaidAmount = ParseAmount(txtPaidAmount.Text)
                heldPaymentMethod = GetPaymentMethod()
                ClearSale(True)
                btnHold.Text = "Resume Hold"
                MessageBox.Show("Current sale moved to hold.", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf heldSaleTable IsNot Nothing AndAlso heldSaleTable.Rows.Count > 0 Then
                saleTable = heldSaleTable.Copy()
                dgvSaleItems.DataSource = saleTable
                currentInvoiceNo = heldInvoiceNo
                lblInvoiceNo.Text = currentInvoiceNo
                cboCustomer.SelectedValue = heldCustomerID
                txtPaidAmount.Text = heldPaidAmount.ToString("N2")
                Select Case heldPaymentMethod
                    Case "Credit"
                        rbCredit.Checked = True
                    Case "Bank"
                        rbBank.Checked = True
                    Case Else
                        rbCash.Checked = True
                End Select
                heldSaleTable = Nothing
                heldInvoiceNo = String.Empty
                btnHold.Text = "Hold"
                UpdateTotals()
                MessageBox.Show("Held sale resumed.", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No held sale available.", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error processing hold sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearSale(generateNewInvoice As Boolean)
        saleTable = New DataTable()
        InitializeSaleTable()
        cboCustomer.SelectedValue = 0
        rbCash.Checked = True
        txtPaidAmount.Text = "0.00"
        lblChange.Text = "0.00"
        UpdateTotals()
        If generateNewInvoice Then GenerateInvoiceNumber()
        btnHold.Text = If(heldSaleTable IsNot Nothing AndAlso heldSaleTable.Rows.Count > 0, "Resume Hold", "Hold")
        txtBarcode.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearSale(False)
    End Sub

    Private Sub btnNewSale_Click(sender As Object, e As EventArgs) Handles btnNewSale.Click
        ClearSale(True)
    End Sub

    Private Sub dgvSaleItems_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSaleItems.KeyDown
        If e.KeyCode = Keys.Delete AndAlso dgvSaleItems.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvSaleItems.SelectedRows
                If row.Index >= 0 AndAlso row.Index < saleTable.Rows.Count Then
                    saleTable.Rows.RemoveAt(row.Index)
                End If
            Next
            UpdateTotals()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
