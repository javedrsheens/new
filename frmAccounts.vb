Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class frmAccounts
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private selectedAccountID As Integer = 0

    Private Sub frmAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadAccountTypes()
            LoadParentAccounts()
            LoadAccounts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAccountTypes()
        cboAccountType.Items.Clear()
        cboAccountType.Items.AddRange(New String() {"Asset", "Liability", "Equity", "Income", "Expense"})
        cboAccountType.SelectedIndex = 0
    End Sub

    Private Sub SetupGrid()
        With dgvAccounts
            .AutoGenerateColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
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
    End Sub

    Private Sub LoadParentAccounts()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim dt As New DataTable()
                dt.Columns.Add("AccountID", GetType(Integer))
                dt.Columns.Add("AccountName", GetType(String))
                Dim blankRow = dt.NewRow()
                blankRow("AccountID") = 0
                blankRow("AccountName") = "<None>"
                dt.Rows.Add(blankRow)

                Dim sql As String = "SELECT AccountID, AccountName FROM accounts WHERE IsActive = 1 ORDER BY AccountName"
                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.Fill(dt)

                cboParentAccount.DataSource = dt
                cboParentAccount.DisplayMember = "AccountName"
                cboParentAccount.ValueMember = "AccountID"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading parent accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAccounts(Optional searchText As String = "")
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As New StringBuilder()
                sql.AppendLine("SELECT a.AccountID,")
                sql.AppendLine("       a.AccountCode AS 'Account Code',")
                sql.AppendLine("       a.AccountName AS 'Account Name',")
                sql.AppendLine("       a.AccountType AS 'Account Type',")
                sql.AppendLine("       IFNULL(p.AccountName, '') AS 'Parent Account',")
                sql.AppendLine("       a.ParentAccountID,")
                sql.AppendLine("       a.OpeningBalance AS 'Opening Balance',")
                sql.AppendLine("       CASE WHEN a.IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active'")
                sql.AppendLine("FROM accounts a")
                sql.AppendLine("LEFT JOIN accounts p ON a.ParentAccountID = p.AccountID")

                Dim adapter As New MySqlDataAdapter()
                adapter.SelectCommand = New MySqlCommand()
                adapter.SelectCommand.Connection = conn

                If String.IsNullOrWhiteSpace(searchText) Then
                    sql.AppendLine("ORDER BY a.AccountCode")
                Else
                    sql.AppendLine("WHERE a.AccountCode LIKE @Search OR a.AccountName LIKE @Search")
                    sql.AppendLine("ORDER BY a.AccountCode")
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", $"%{searchText.Trim()}%")
                End If

                adapter.SelectCommand.CommandText = sql.ToString()
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvAccounts.DataSource = dt
                FormatGrid()
                lblTotalAccounts.Text = If(String.IsNullOrWhiteSpace(searchText), $"Total Accounts: {dt.Rows.Count}", $"Found Accounts: {dt.Rows.Count}")
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If dgvAccounts.Columns.Count = 0 Then Return
            If dgvAccounts.Columns.Contains("AccountID") Then dgvAccounts.Columns("AccountID").Visible = False
            If dgvAccounts.Columns.Contains("ParentAccountID") Then dgvAccounts.Columns("ParentAccountID").Visible = False
            If dgvAccounts.Columns.Contains("Account Code") Then dgvAccounts.Columns("Account Code").Width = 120
            If dgvAccounts.Columns.Contains("Account Name") Then dgvAccounts.Columns("Account Name").Width = 220
            If dgvAccounts.Columns.Contains("Account Type") Then dgvAccounts.Columns("Account Type").Width = 120
            If dgvAccounts.Columns.Contains("Parent Account") Then dgvAccounts.Columns("Parent Account").Width = 180
            If dgvAccounts.Columns.Contains("Opening Balance") Then
                dgvAccounts.Columns("Opening Balance").Width = 120
                dgvAccounts.Columns("Opening Balance").DefaultCellStyle.Format = "N2"
                dgvAccounts.Columns("Opening Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If dgvAccounts.Columns.Contains("Active") Then dgvAccounts.Columns("Active").Width = 80
        Catch
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtAccountCode.Text) Then
            MessageBox.Show("Enter account code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountCode.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAccountName.Text) Then
            MessageBox.Show("Enter account name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountName.Focus()
            Return False
        End If

        Dim amount As Decimal
        If Not Decimal.TryParse(txtOpeningBalance.Text, amount) Then
            MessageBox.Show("Enter valid opening balance", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOpeningBalance.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM accounts WHERE AccountCode=@Code OR AccountName=@Name", conn)
                    checkCmd.Parameters.AddWithValue("@Code", txtAccountCode.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@Name", txtAccountName.Text.Trim())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Account code or name already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                Dim sql As String = "INSERT INTO accounts (AccountCode, AccountName, AccountType, ParentAccountID, OpeningBalance, IsActive, CreatedDate) VALUES (@AccountCode, @AccountName, @AccountType, @ParentAccountID, @OpeningBalance, @IsActive, NOW())"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AccountCode", txtAccountCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text.Trim())
                    cmd.Parameters.AddWithValue("@AccountType", cboAccountType.Text)
                    cmd.Parameters.AddWithValue("@ParentAccountID", If(Convert.ToInt32(cboParentAccount.SelectedValue) = 0, CType(DBNull.Value, Object), cboParentAccount.SelectedValue))
                    cmd.Parameters.AddWithValue("@OpeningBalance", Convert.ToDecimal(txtOpeningBalance.Text))
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Account saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadParentAccounts()
            LoadAccounts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error saving account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedAccountID = 0 Then
            MessageBox.Show("Please select an account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM accounts WHERE (AccountCode=@Code OR AccountName=@Name) AND AccountID<>@AccountID", conn)
                    checkCmd.Parameters.AddWithValue("@Code", txtAccountCode.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@Name", txtAccountName.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@AccountID", selectedAccountID)
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Account code or name already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                Dim sql As String = "UPDATE accounts SET AccountCode=@AccountCode, AccountName=@AccountName, AccountType=@AccountType, ParentAccountID=@ParentAccountID, OpeningBalance=@OpeningBalance, IsActive=@IsActive WHERE AccountID=@AccountID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@AccountID", selectedAccountID)
                    cmd.Parameters.AddWithValue("@AccountCode", txtAccountCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text.Trim())
                    cmd.Parameters.AddWithValue("@AccountType", cboAccountType.Text)
                    cmd.Parameters.AddWithValue("@ParentAccountID", If(Convert.ToInt32(cboParentAccount.SelectedValue) = 0, CType(DBNull.Value, Object), cboParentAccount.SelectedValue))
                    cmd.Parameters.AddWithValue("@OpeningBalance", Convert.ToDecimal(txtOpeningBalance.Text))
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Account updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadParentAccounts()
            LoadAccounts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error updating account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedAccountID = 0 Then
            MessageBox.Show("Please select an account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Delete account '{txtAccountName.Text}'?{vbCrLf}{vbCrLf}This will deactivate the account.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE accounts SET IsActive = 0 WHERE AccountID = @AccountID", conn)
                    cmd.Parameters.AddWithValue("@AccountID", selectedAccountID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Account deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadParentAccounts()
            LoadAccounts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error deleting account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvAccounts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccounts.CellClick
        If e.RowIndex < 0 Then Return

        Try
            Dim row = dgvAccounts.Rows(e.RowIndex)
            selectedAccountID = Convert.ToInt32(row.Cells("AccountID").Value)
            lblAccountIDValue.Text = selectedAccountID.ToString()
            txtAccountCode.Text = row.Cells("Account Code").Value.ToString()
            txtAccountName.Text = row.Cells("Account Name").Value.ToString()
            cboAccountType.Text = row.Cells("Account Type").Value.ToString()
            txtOpeningBalance.Text = Convert.ToDecimal(row.Cells("Opening Balance").Value).ToString("0.00")
            chkActive.Checked = row.Cells("Active").Value.ToString() = "Yes"

            If row.Cells("ParentAccountID").Value Is Nothing OrElse IsDBNull(row.Cells("ParentAccountID").Value) Then
                cboParentAccount.SelectedValue = 0
            Else
                cboParentAccount.SelectedValue = Convert.ToInt32(row.Cells("ParentAccountID").Value)
            End If

            btnSave.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Catch ex As Exception
            MessageBox.Show($"Error loading account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchAccounts()
        LoadAccounts(txtSearch.Text)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchAccounts()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchAccounts()
        End If
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadAccounts()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvAccounts.Rows.Count = 0 Then
                MessageBox.Show("No data to export", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = $"Accounts_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim csv As New StringBuilder()
            For Each col As DataGridViewColumn In dgvAccounts.Columns
                If col.Visible Then csv.Append(col.HeaderText & ",")
            Next
            csv.AppendLine()

            For Each row As DataGridViewRow In dgvAccounts.Rows
                For Each col As DataGridViewColumn In dgvAccounts.Columns
                    If col.Visible Then csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                Next
                csv.AppendLine()
            Next

            File.WriteAllText(sfd.FileName, csv.ToString())
            MessageBox.Show("Export completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error exporting accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtAccountCode.Clear()
        txtAccountName.Clear()
        LoadAccountTypes()
        LoadParentAccounts()
        cboParentAccount.SelectedValue = 0
        txtOpeningBalance.Text = "0.00"
        chkActive.Checked = True
        selectedAccountID = 0
        lblAccountIDValue.Text = "Auto Generated"
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtAccountCode.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
