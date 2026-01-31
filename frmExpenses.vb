Imports MySql.Data.MySqlClient

Public Class frmExpenses
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer
    Private isEditMode As Boolean = False
    Private selectedExpenseID As Integer = 0

    Private Sub frmExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadExpenseCategories()
        LoadPaymentMethods()
        LoadExpenses()
        SetupDataGridView()
        ClearFields()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        dtpExpenseDate.Value = DateTime.Now

        ' Set date range for filtering
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Now
    End Sub

    Private Sub SetupDataGridView()
        With dgvExpenses
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub LoadExpenseCategories()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT ExpenseCategoryID, CategoryName FROM expense_categories WHERE IsActive = TRUE ORDER BY CategoryName"
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                cboCategory.DataSource = dt
                cboCategory.DisplayMember = "CategoryName"
                cboCategory.ValueMember = "ExpenseCategoryID"
                cboCategory.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPaymentMethods()
        cboPaymentMethod.Items.Clear()
        cboPaymentMethod.Items.AddRange(New String() {"Cash", "Bank Transfer", "Cheque", "Card", "UPI"})
        cboPaymentMethod.SelectedIndex = 0
    End Sub

    Private Sub LoadExpenses()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          e.ExpenseID,
                                          DATE_FORMAT(e.ExpenseDate, '%d-%m-%Y') AS 'Date',
                                          ec.CategoryName AS 'Category',
                                          e.Description,
                                          e.Amount,
                                          e.PaymentMethod AS 'Payment',
                                          u. FullName AS 'Recorded By',
                                          DATE_FORMAT(e.CreatedDate, '%d-%m-%Y %h:%i %p') AS 'Created On'
                                      FROM expenses e
                                      LEFT JOIN expense_categories ec ON e.ExpenseCategoryID = ec.ExpenseCategoryID
                                      LEFT JOIN users u ON e.RecordedBy = u.UserID
                                      WHERE DATE(e.ExpenseDate) BETWEEN @FromDate AND @ToDate
                                      ORDER BY e. ExpenseDate DESC, e.CreatedDate DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvExpenses.DataSource = dt
                FormatExpenseGrid()
                CalculateExpenseSummary()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading expenses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatExpenseGrid()
        With dgvExpenses
            If .Columns.Count > 0 Then
                .Columns("ExpenseID").Visible = False
                .Columns("Date").Width = 100
                .Columns("Category").Width = 150
                .Columns("Description").Width = 250
                .Columns("Amount").Width = 120
                .Columns("Payment").Width = 100
                .Columns("Recorded By").Width = 150
                .Columns("Created On").Width = 150

                .Columns("Amount").DefaultCellStyle.Format = "N2"
                .Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Amount").DefaultCellStyle.Font = New Font(dgvExpenses.Font, FontStyle.Bold)
            End If
        End With
    End Sub

    Private Sub CalculateExpenseSummary()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          COUNT(*) AS TotalCount,
                                          COALESCE(SUM(Amount), 0) AS TotalAmount
                                      FROM expenses
                                      WHERE DATE(ExpenseDate) BETWEEN @FromDate AND @ToDate"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                conn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    lblTotalExpenses.Text = $"Total Expenses: {reader("TotalCount")}"
                    lblTotalAmount.Text = $"Total Amount: ₹ {Convert.ToDecimal(reader("TotalAmount")):N2}"
                End If

                reader.Close()

                ' Load category-wise summary
                LoadCategoryWiseSummary()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error calculating summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCategoryWiseSummary()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          ec.CategoryName AS 'Category',
                                          COUNT(*) AS 'Count',
                                          SUM(e.Amount) AS 'Amount'
                                      FROM expenses e
                                      INNER JOIN expense_categories ec ON e.ExpenseCategoryID = ec.ExpenseCategoryID
                                      WHERE DATE(e.ExpenseDate) BETWEEN @FromDate AND @ToDate
                                      GROUP BY ec.CategoryName
                                      ORDER BY SUM(e.Amount) DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCategorySummary.DataSource = dt

                With dgvCategorySummary
                    If .Columns.Count > 0 Then
                        .Columns("Amount").DefaultCellStyle.Format = "N2"
                        .Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If
                End With
            End Using
        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateFields() Then
            SaveExpense()
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        If cboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select an expense category", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Please enter a description", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAmount.Text) OrElse Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Return False
        End If

        If Convert.ToDecimal(txtAmount.Text) <= 0 Then
            MessageBox.Show("Amount must be greater than zero", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SaveExpense()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "INSERT INTO expenses (ExpenseCategoryID, Amount, ExpenseDate, Description, PaymentMethod, RecordedBy)
                                      VALUES (@CategoryID, @Amount, @ExpenseDate, @Description, @PaymentMethod, @RecordedBy)"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@CategoryID", cboCategory.SelectedValue)
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
                cmd.Parameters.AddWithValue("@ExpenseDate", dtpExpenseDate.Value.Date)
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@PaymentMethod", cboPaymentMethod.Text)
                cmd.Parameters.AddWithValue("@RecordedBy", CurrentUserID)

                conn.Open()
                cmd.ExecuteNonQuery()

                Dim expenseID As Integer = CInt(cmd.LastInsertedId)

                ' Add to DayBook
                AddToDayBook(expenseID, Convert.ToDecimal(txtAmount.Text), txtDescription.Text, cboPaymentMethod.Text, conn)

                MessageBox.Show("Expense saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadExpenses()
                ClearFields()
                txtDescription.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddToDayBook(expenseID As Integer, amount As Decimal, description As String, paymentMethod As String, conn As MySqlConnection)
        Try
            Dim query As String = "INSERT INTO daybook (TransactionType, ReferenceType, ReferenceID, Description, CreditAmount, PaymentMethod, RecordedBy)
                                  VALUES ('Expense', 'Expense', @ExpenseID, @Description, @Amount, @PaymentMethod, @UserID)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@ExpenseID", expenseID)
            cmd.Parameters.AddWithValue("@Description", $"Expense - {description}")
            cmd.Parameters.AddWithValue("@Amount", amount)
            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
            cmd.Parameters.AddWithValue("@UserID", CurrentUserID)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ' Silent fail - daybook is secondary
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateFields() Then
            UpdateExpense()
        End If
    End Sub

    Private Sub UpdateExpense()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "UPDATE expenses SET 
                                      ExpenseCategoryID = @CategoryID,
                                      Amount = @Amount,
                                      ExpenseDate = @ExpenseDate,
                                      Description = @Description,
                                      PaymentMethod = @PaymentMethod
                                      WHERE ExpenseID = @ExpenseID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ExpenseID", selectedExpenseID)
                cmd.Parameters.AddWithValue("@CategoryID", cboCategory.SelectedValue)
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(txtAmount.Text))
                cmd.Parameters.AddWithValue("@ExpenseDate", dtpExpenseDate.Value.Date)
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@PaymentMethod", cboPaymentMethod.Text)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Expense updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadExpenses()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedExpenseID = 0 Then
            MessageBox.Show("Please select an expense to delete", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Are you sure you want to delete this expense?{vbCrLf}Description: {txtDescription.Text}{vbCrLf}Amount: ₹{txtAmount.Text}", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteExpense()
        End If
    End Sub

    Private Sub DeleteExpense()
        Try
            Using conn As New MySqlConnection(connectionString)
                ' Hard delete (you can change to soft delete if needed)
                Dim query As String = "DELETE FROM expenses WHERE ExpenseID = @ExpenseID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ExpenseID", selectedExpenseID)

                conn.Open()
                cmd.ExecuteNonQuery()

                ' Also delete from daybook
                Dim daybookQuery As String = "DELETE FROM daybook WHERE ReferenceType = 'Expense' AND ReferenceID = @ExpenseID"
                Dim cmdDaybook As New MySqlCommand(daybookQuery, conn)
                cmdDaybook.Parameters.AddWithValue("@ExpenseID", selectedExpenseID)
                cmdDaybook.ExecuteNonQuery()

                MessageBox.Show("Expense deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadExpenses()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvExpenses_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvExpenses.Rows(e.RowIndex)

                selectedExpenseID = Convert.ToInt32(row.Cells("ExpenseID").Value)
                cboCategory.Text = row.Cells("Category").Value.ToString()
                txtDescription.Text = row.Cells("Description").Value.ToString()
                txtAmount.Text = Convert.ToDecimal(row.Cells("Amount").Value).ToString("0.00")
                cboPaymentMethod.Text = row.Cells("Payment").Value.ToString()
                dtpExpenseDate.Value = Convert.ToDateTime(row.Cells("Date").Value)

                ' Enable edit/delete buttons
                isEditMode = True
                btnSave.Enabled = False
                btnUpdate.Enabled = True
                btnDelete.Enabled = True

            Catch ex As Exception
                MessageBox.Show($"Error loading expense details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        cboCategory.SelectedIndex = -1
        txtDescription.Clear()
        txtAmount.Clear()
        cboPaymentMethod.SelectedIndex = 0
        dtpExpenseDate.Value = DateTime.Now

        selectedExpenseID = 0
        isEditMode = False

        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False

        txtDescription.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadExpenses()
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        dtpFromDate.Value = DateTime.Now.Date
        dtpToDate.Value = DateTime.Now.Date
        LoadExpenses()
    End Sub

    Private Sub btnThisWeek_Click(sender As Object, e As EventArgs) Handles btnThisWeek.Click
        dtpFromDate.Value = DateTime.Now.AddDays(-7).Date
        dtpToDate.Value = DateTime.Now.Date
        LoadExpenses()
    End Sub

    Private Sub btnThisMonth_Click(sender As Object, e As EventArgs) Handles btnThisMonth.Click
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Now.Date
        LoadExpenses()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToCSV()
    End Sub

    Private Sub ExportToCSV()
        Try
            If dgvExpenses.Rows.Count = 0 Then
                MessageBox.Show("No data to export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            sfd.FileName = $"Expenses_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim csv As New System.Text.StringBuilder()

                ' Add report header
                csv.AppendLine($"Expense Report")
                csv.AppendLine($"Period: {dtpFromDate.Value: dd-MM-yyyy} to {dtpToDate.Value:dd-MM-yyyy}")
                csv.AppendLine($"Generated: {DateTime.Now:dd-MM-yyyy HH:mm: ss}")
                csv.AppendLine()

                ' Add headers
                For i As Integer = 0 To dgvExpenses.Columns.Count - 1
                    If dgvExpenses.Columns(i).Visible Then
                        csv.Append(dgvExpenses.Columns(i).HeaderText)
                        If i < dgvExpenses.Columns.Count - 1 Then
                            csv.Append(",")
                        End If
                    End If
                Next
                csv.AppendLine()

                ' Add rows
                For Each row As DataGridViewRow In dgvExpenses.Rows
                    For i As Integer = 0 To dgvExpenses.Columns.Count - 1
                        If dgvExpenses.Columns(i).Visible Then
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString().Replace(",", ";"), "")
                            csv.Append(cellValue)
                            If i < dgvExpenses.Columns.Count - 1 Then
                                csv.Append(",")
                            End If
                        End If
                    Next
                    csv.AppendLine()
                Next

                ' Add summary
                csv.AppendLine()
                csv.AppendLine($"Total Expenses,{lblTotalExpenses.Text}")
                csv.AppendLine($"Total Amount,{lblTotalAmount.Text}")

                System.IO.File.WriteAllText(sfd.FileName, csv.ToString())

                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If MessageBox.Show("Do you want to open the file? ", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(sfd.FileName)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show($"Error exporting:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Amount textbox - allow only numbers and decimal
    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress, cboPaymentMethod.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "."c AndAlso txtAmount.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnManageCategories_Click(sender As Object, e As EventArgs) Handles btnManageCategories.Click
        Dim frmCat As New frmExpenseCategories()
        frmCat.ShowDialog()
        LoadExpenseCategories() ' Reload after closing
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class