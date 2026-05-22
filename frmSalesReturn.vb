Imports MySql.Data.MySqlClient

Public Class frmSalesReturn
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property CurrentUserID As Integer

    Private returnTable As DataTable
    Private currentReturnNo As String = String.Empty

    Private Sub frmSalesReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitializeReturnTable()
            SetupReturnGrid()
            LoadCustomers()
            LoadReturnReasons()
            GenerateReturnNumber()
            UpdateDateTime()
            tmrClock.Start()
            UpdateTotals()
            txtBarcode.Focus()
        Catch ex As Exception
            MessageBox.Show($"Error loading sales return form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeReturnTable()
        returnTable = New DataTable()
        returnTable.Columns.Add("ProductID", GetType(Integer))
        returnTable.Columns.Add("Barcode", GetType(String))
        returnTable.Columns.Add("ProductName", GetType(String))
        returnTable.Columns.Add("Qty", GetType(Decimal))
        returnTable.Columns.Add("Rate", GetType(Decimal))
        returnTable.Columns.Add("Discount", GetType(Decimal))
        returnTable.Columns.Add("Amount", GetType(Decimal))
        dgvReturnItems.AutoGenerateColumns = False
        dgvReturnItems.DataSource = returnTable
    End Sub

    Private Sub SetupReturnGrid()
        With dgvReturnItems
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = False
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

        colBarcode.ReadOnly = True
        colProductName.ReadOnly = True
        colQty.ReadOnly = False
        colRate.ReadOnly = True
        colDiscount.ReadOnly = True
        colAmount.ReadOnly = True

        colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colQty.DefaultCellStyle.Format = "N2"
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

    Private Sub LoadReturnReasons()
        cboReturnReason.Items.Clear()
        cboReturnReason.Items.AddRange(New String() {"Wrong Product", "Damaged", "Overcharged", "Customer Changed Mind", "Other"})
        If cboReturnReason.Items.Count > 0 Then cboReturnReason.SelectedIndex = 0
    End Sub

    Private Sub GenerateReturnNumber()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) + 1 FROM sales_returns WHERE YEAR(ReturnDate) = @ReturnYear", conn)
                    cmd.Parameters.AddWithValue("@ReturnYear", DateTime.Now.Year)
                    Dim seq As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    currentReturnNo = $"RET-{DateTime.Now:yyyy}-{seq:0000}"
                    lblReturnNo.Text = currentReturnNo
                End Using
            End Using
        Catch
            currentReturnNo = $"RET-{DateTime.Now:yyyy}-{DateTime.Now:HHmm}"
            lblReturnNo.Text = currentReturnNo
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
                Dim sql As String = "SELECT ProductID, Barcode, ProductName, UnitPrice " &
                                    "FROM products " &
                                    "WHERE IsActive = 1 AND (Barcode = @ExactSearch OR ProductName LIKE @LikeSearch OR Barcode LIKE @LikeSearch) " &
                                    "ORDER BY CASE WHEN Barcode = @ExactSearch THEN 0 ELSE 1 END, ProductName LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ExactSearch", searchText)
                    cmd.Parameters.AddWithValue("@LikeSearch", $"%{searchText}%")
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            AddProductToGrid(Convert.ToInt32(reader("ProductID")), reader("Barcode").ToString(), reader("ProductName").ToString(), Convert.ToDecimal(reader("UnitPrice")), quantity)
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

    Private Sub AddProductToGrid(productID As Integer, barcode As String, productName As String, rate As Decimal, quantity As Decimal)
        Try
            For Each row As DataRow In returnTable.Rows
                If Convert.ToInt32(row("ProductID")) = productID Then
                    row("Qty") = Convert.ToDecimal(row("Qty")) + quantity
                    RecalculateRow(row)
                    UpdateTotals()
                    ClearScanInputs()
                    Return
                End If
            Next

            Dim newRow As DataRow = returnTable.NewRow()
            newRow("ProductID") = productID
            newRow("Barcode") = barcode
            newRow("ProductName") = productName
            newRow("Qty") = quantity
            newRow("Rate") = rate
            newRow("Discount") = 0D
            newRow("Amount") = (quantity * rate)
            returnTable.Rows.Add(newRow)
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

    Private Sub dgvReturnItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReturnItems.CellEndEdit
        If e.RowIndex < 0 OrElse e.RowIndex >= returnTable.Rows.Count Then Return
        Try
            Dim row As DataRow = returnTable.Rows(e.RowIndex)
            Dim qty As Decimal
            If Not Decimal.TryParse(If(dgvReturnItems.Rows(e.RowIndex).Cells("colQty").Value, "0").ToString(), qty) OrElse qty <= 0D Then
                qty = 1D
            End If
            row("Qty") = qty
            RecalculateRow(row)
            UpdateTotals()
        Catch ex As Exception
            MessageBox.Show($"Error updating item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
        Dim subTotal As Decimal = 0D
        Dim discountTotal As Decimal = 0D
        Dim netTotal As Decimal = 0D

        For Each row As DataRow In returnTable.Rows
            subTotal += Convert.ToDecimal(row("Qty")) * Convert.ToDecimal(row("Rate"))
            discountTotal += Convert.ToDecimal(row("Discount"))
            netTotal += Convert.ToDecimal(row("Amount"))
        Next

        lblSubTotal.Text = subTotal.ToString("N2")
        lblDiscount.Text = discountTotal.ToString("N2")
        lblNetTotal.Text = netTotal.ToString("N2")
    End Sub

    Private Function ValidateReturn() As Boolean
        If returnTable.Rows.Count = 0 Then
            MessageBox.Show("Add at least one item.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtInvoiceRef.Text) Then
            MessageBox.Show("Enter original invoice reference.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceRef.Focus()
            Return False
        End If

        If cboReturnReason.SelectedIndex < 0 Then
            MessageBox.Show("Select a return reason.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnReason.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function GetOrCreateAccountID(conn As MySqlConnection, transaction As MySqlTransaction, accountCode As String, accountName As String, accountType As String) As Integer
        Using cmd As New MySqlCommand("SELECT AccountID FROM accounts WHERE AccountName = @AccountName LIMIT 1", conn, transaction)
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

    Private Function ParseAmount(valueText As String) As Decimal
        Dim amount As Decimal = 0D
        Decimal.TryParse(valueText, amount)
        Return amount
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateReturn() Then Return

        Dim subTotal As Decimal = ParseAmount(lblSubTotal.Text)
        Dim netAmount As Decimal = ParseAmount(lblNetTotal.Text)
        Dim customerID As Integer = If(cboCustomer.SelectedValue Is Nothing, 0, Convert.ToInt32(cboCustomer.SelectedValue))
        Dim customerValue As Object = If(customerID <= 0, CType(DBNull.Value, Object), customerID)
        Dim returnID As Integer = 0

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        Dim headerSql As String = "INSERT INTO sales_returns (ReturnNo, ReturnDate, CustomerID, InvoiceRef, SubTotal, NetAmount, Reason, Remarks, UserID) VALUES (@ReturnNo, NOW(), @CustomerID, @InvoiceRef, @SubTotal, @NetAmount, @Reason, @Remarks, @UserID)"
                        Using cmd As New MySqlCommand(headerSql, conn, transaction)
                            cmd.Parameters.AddWithValue("@ReturnNo", currentReturnNo)
                            cmd.Parameters.AddWithValue("@CustomerID", customerValue)
                            cmd.Parameters.AddWithValue("@InvoiceRef", txtInvoiceRef.Text.Trim())
                            cmd.Parameters.AddWithValue("@SubTotal", subTotal)
                            cmd.Parameters.AddWithValue("@NetAmount", netAmount)
                            cmd.Parameters.AddWithValue("@Reason", cboReturnReason.Text)
                            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim())
                            cmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            cmd.ExecuteNonQuery()
                            returnID = Convert.ToInt32(cmd.LastInsertedId)
                        End Using

                        For Each row As DataRow In returnTable.Rows
                            Using itemCmd As New MySqlCommand("INSERT INTO sales_return_items (ReturnID, ProductID, Qty, Rate, Discount, Amount) VALUES (@ReturnID, @ProductID, @Qty, @Rate, @Discount, @Amount)", conn, transaction)
                                itemCmd.Parameters.AddWithValue("@ReturnID", returnID)
                                itemCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row("ProductID")))
                                itemCmd.Parameters.AddWithValue("@Qty", Convert.ToDecimal(row("Qty")))
                                itemCmd.Parameters.AddWithValue("@Rate", Convert.ToDecimal(row("Rate")))
                                itemCmd.Parameters.AddWithValue("@Discount", Convert.ToDecimal(row("Discount")))
                                itemCmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(row("Amount")))
                                itemCmd.ExecuteNonQuery()
                            End Using

                            Using stockCmd As New MySqlCommand("UPDATE products SET Stock = Stock + @Qty WHERE ProductID = @ProductID", conn, transaction)
                                stockCmd.Parameters.AddWithValue("@Qty", Convert.ToDecimal(row("Qty")))
                                stockCmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row("ProductID")))
                                stockCmd.ExecuteNonQuery()
                            End Using
                        Next

                        Dim journalID As Integer
                        Using journalCmd As New MySqlCommand("INSERT INTO journal_entries (EntryDate, Description, ReferenceType, ReferenceID, UserID) VALUES (NOW(), @Description, @ReferenceType, @ReferenceID, @UserID)", conn, transaction)
                            journalCmd.Parameters.AddWithValue("@Description", $"Sales return {currentReturnNo}")
                            journalCmd.Parameters.AddWithValue("@ReferenceType", "Sales Return")
                            journalCmd.Parameters.AddWithValue("@ReferenceID", returnID)
                            journalCmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            journalCmd.ExecuteNonQuery()
                            journalID = Convert.ToInt32(journalCmd.LastInsertedId)
                        End Using

                        Dim salesAccountID As Integer = GetOrCreateAccountID(conn, transaction, "4000", "Sales", "Income")
                        Dim reverseAccountID As Integer
                        If customerID <= 0 Then
                            reverseAccountID = GetOrCreateAccountID(conn, transaction, "1000", "Cash In Hand", "Asset")
                        Else
                            reverseAccountID = GetOrCreateAccountID(conn, transaction, "1100", "Accounts Receivable", "Asset")
                        End If

                        Using detailCmd As New MySqlCommand("INSERT INTO journal_details (JournalID, AccountID, DebitAmount, CreditAmount, Description) VALUES (@JournalID, @AccountID, @DebitAmount, @CreditAmount, @Description)", conn, transaction)
                            detailCmd.Parameters.Add("@JournalID", MySqlDbType.Int32)
                            detailCmd.Parameters.Add("@AccountID", MySqlDbType.Int32)
                            detailCmd.Parameters.Add("@DebitAmount", MySqlDbType.Decimal)
                            detailCmd.Parameters.Add("@CreditAmount", MySqlDbType.Decimal)
                            detailCmd.Parameters.Add("@Description", MySqlDbType.VarChar)

                            detailCmd.Parameters("@JournalID").Value = journalID
                            detailCmd.Parameters("@AccountID").Value = salesAccountID
                            detailCmd.Parameters("@DebitAmount").Value = netAmount
                            detailCmd.Parameters("@CreditAmount").Value = 0D
                            detailCmd.Parameters("@Description").Value = $"Reverse sales for {currentReturnNo}"
                            detailCmd.ExecuteNonQuery()

                            detailCmd.Parameters("@JournalID").Value = journalID
                            detailCmd.Parameters("@AccountID").Value = reverseAccountID
                            detailCmd.Parameters("@DebitAmount").Value = 0D
                            detailCmd.Parameters("@CreditAmount").Value = netAmount
                            detailCmd.Parameters("@Description").Value = $"Reverse cash/receivable for {currentReturnNo}"
                            detailCmd.ExecuteNonQuery()
                        End Using

                        Using daybookCmd As New MySqlCommand("INSERT INTO daybook (TransactionDate, TransactionType, Description, DebitAmount, CreditAmount, ReferenceNo, PaymentMethod, UserID) VALUES (NOW(), @TransactionType, @Description, @DebitAmount, @CreditAmount, @ReferenceNo, @PaymentMethod, @UserID)", conn, transaction)
                            daybookCmd.Parameters.AddWithValue("@TransactionType", "Sales Return")
                            daybookCmd.Parameters.AddWithValue("@Description", $"Sales return {currentReturnNo}")
                            daybookCmd.Parameters.AddWithValue("@DebitAmount", 0D)
                            daybookCmd.Parameters.AddWithValue("@CreditAmount", netAmount)
                            daybookCmd.Parameters.AddWithValue("@ReferenceNo", currentReturnNo)
                            daybookCmd.Parameters.AddWithValue("@PaymentMethod", "Return")
                            daybookCmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            daybookCmd.ExecuteNonQuery()
                        End Using

                        Using logCmd As New MySqlCommand("INSERT INTO activity_log (UserID, Action, TableName, RecordID, Description) VALUES (@UserID, @Action, @TableName, @RecordID, @Description)", conn, transaction)
                            logCmd.Parameters.AddWithValue("@UserID", CurrentUserID)
                            logCmd.Parameters.AddWithValue("@Action", "Insert")
                            logCmd.Parameters.AddWithValue("@TableName", "sales_returns")
                            logCmd.Parameters.AddWithValue("@RecordID", returnID.ToString())
                            logCmd.Parameters.AddWithValue("@Description", $"Created sales return {currentReturnNo}")
                            logCmd.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                    Catch
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("Sales return saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show($"Error saving sales return: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearForm(generateNewNumber As Boolean)
        returnTable.Rows.Clear()
        cboCustomer.SelectedValue = 0
        txtInvoiceRef.Clear()
        If cboReturnReason.Items.Count > 0 Then cboReturnReason.SelectedIndex = 0
        txtRemarks.Clear()
        txtBarcode.Clear()
        txtProductSearch.Clear()
        numQty.Value = 1D
        UpdateTotals()
        If generateNewNumber Then GenerateReturnNumber()
        txtBarcode.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm(False)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub dgvReturnItems_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvReturnItems.KeyDown
        If e.KeyCode = Keys.Delete AndAlso dgvReturnItems.SelectedRows.Count > 0 Then
            For Each gridRow As DataGridViewRow In dgvReturnItems.SelectedRows
                If gridRow.Index >= 0 AndAlso gridRow.Index < returnTable.Rows.Count Then
                    returnTable.Rows.RemoveAt(gridRow.Index)
                End If
            Next
            UpdateTotals()
        End If
    End Sub
End Class
