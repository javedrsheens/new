Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class frmUsers
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private selectedUserID As Integer = 0

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadRoles()
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRoles()
        cboRole.Items.Clear()
        cboRole.Items.AddRange(New String() {"Admin", "Manager", "Cashier", "Staff"})
        cboRole.SelectedIndex = 2
    End Sub

    Private Sub SetupGrid()
        With dgvUsers
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

    Private Sub LoadUsers(Optional searchText As String = "")
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As New StringBuilder()
                sql.AppendLine("SELECT UserID,")
                sql.AppendLine("       Username,")
                sql.AppendLine("       FullName AS 'Full Name',")
                sql.AppendLine("       Email,")
                sql.AppendLine("       Role,")
                sql.AppendLine("       CASE WHEN IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active',")
                sql.AppendLine("       IFNULL(DATE_FORMAT(LastLogin, '%d-%m-%Y %h:%i %p'), '') AS 'Last Login'")
                sql.AppendLine("FROM users")

                Dim adapter As New MySqlDataAdapter()
                adapter.SelectCommand = New MySqlCommand()
                adapter.SelectCommand.Connection = conn

                If String.IsNullOrWhiteSpace(searchText) Then
                    sql.AppendLine("ORDER BY FullName")
                Else
                    sql.AppendLine("WHERE Username LIKE @Search OR FullName LIKE @Search")
                    sql.AppendLine("ORDER BY FullName")
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", $"%{searchText.Trim()}%")
                End If

                adapter.SelectCommand.CommandText = sql.ToString()

                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvUsers.DataSource = dt
                FormatGrid()
                lblTotalUsers.Text = If(String.IsNullOrWhiteSpace(searchText), $"Total Users: {dt.Rows.Count}", $"Found Users: {dt.Rows.Count}")
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If dgvUsers.Columns.Count = 0 Then Return
            If dgvUsers.Columns.Contains("UserID") Then dgvUsers.Columns("UserID").Visible = False
            If dgvUsers.Columns.Contains("Username") Then dgvUsers.Columns("Username").Width = 130
            If dgvUsers.Columns.Contains("Full Name") Then dgvUsers.Columns("Full Name").Width = 180
            If dgvUsers.Columns.Contains("Email") Then dgvUsers.Columns("Email").Width = 190
            If dgvUsers.Columns.Contains("Role") Then dgvUsers.Columns("Role").Width = 110
            If dgvUsers.Columns.Contains("Active") Then dgvUsers.Columns("Active").Width = 80
            If dgvUsers.Columns.Contains("Last Login") Then dgvUsers.Columns("Last Login").Width = 160
        Catch
        End Try
    End Sub

    Private Function ValidateFields(Optional requirePassword As Boolean = True) As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Enter username", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Enter full name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return False
        End If

        If requirePassword AndAlso String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Enter password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        If cboRole.SelectedIndex = -1 Then
            MessageBox.Show("Select role", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function HashPassword(password As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant()
        End Using
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields(True) Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim checkSql As String = "SELECT COUNT(*) FROM users WHERE Username = @Username"
                Using checkCmd As New MySqlCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtUsername.Focus()
                        Return
                    End If
                End Using

                Dim sql As String = "INSERT INTO users (Username, Password, FullName, Email, Role, IsActive, CreatedDate) VALUES (@Username, @Password, @FullName, @Email, @Role, @IsActive, NOW())"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text.Trim()))
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Role", cboRole.Text)
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error saving user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedUserID = 0 Then
            MessageBox.Show("Please select a user", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateFields(False) Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim checkSql As String = "SELECT COUNT(*) FROM users WHERE Username = @Username AND UserID <> @UserID"
                Using checkCmd As New MySqlCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@UserID", selectedUserID)
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtUsername.Focus()
                        Return
                    End If
                End Using

                Dim sql As New StringBuilder()
                sql.Append("UPDATE users SET Username=@Username, FullName=@FullName, Email=@Email, Role=@Role, IsActive=@IsActive")
                If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                    sql.Append(", Password=@Password")
                End If
                sql.Append(" WHERE UserID=@UserID")

                Using cmd As New MySqlCommand(sql.ToString(), conn)
                    cmd.Parameters.AddWithValue("@UserID", selectedUserID)
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Role", cboRole.Text)
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text.Trim()))
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedUserID = 0 Then
            MessageBox.Show("Please select a user", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Delete user '{txtUsername.Text}'?{vbCrLf}{vbCrLf}This will deactivate the user.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "UPDATE users SET IsActive = 0 WHERE UserID = @UserID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UserID", selectedUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex < 0 Then Return

        Try
            selectedUserID = Convert.ToInt32(dgvUsers.Rows(e.RowIndex).Cells("UserID").Value)
            lblUserIDValue.Text = selectedUserID.ToString()
            txtUsername.Text = dgvUsers.Rows(e.RowIndex).Cells("Username").Value.ToString()
            txtFullName.Text = dgvUsers.Rows(e.RowIndex).Cells("Full Name").Value.ToString()
            txtEmail.Text = dgvUsers.Rows(e.RowIndex).Cells("Email").Value.ToString()
            cboRole.Text = dgvUsers.Rows(e.RowIndex).Cells("Role").Value.ToString()
            chkActive.Checked = dgvUsers.Rows(e.RowIndex).Cells("Active").Value.ToString() = "Yes"
            txtPassword.Clear()
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Catch ex As Exception
            MessageBox.Show($"Error loading user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchUsers()
        LoadUsers(txtSearch.Text)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchUsers()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchUsers()
        End If
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadUsers()
    End Sub

    Private Sub ClearFields()
        txtUsername.Clear()
        txtPassword.Clear()
        txtFullName.Clear()
        txtEmail.Clear()
        LoadRoles()
        chkActive.Checked = True
        selectedUserID = 0
        lblUserIDValue.Text = "Auto Generated"
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtUsername.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
