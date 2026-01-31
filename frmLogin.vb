Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        txtUsername.Focus()
        txtPassword.UseSystemPasswordChar = True
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrEmpty(txtusername.Text.Trim()) Then
            MessageBox.Show("Please enter username", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtusername.Focus()
            Return
        End If

        If String.IsNullOrEmpty(txtpassword.Text) Then
            MessageBox.Show("Please enter password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtpassword.Focus()
            Return
        End If

        AuthenticateUser()
    End Sub

    Private Sub AuthenticateUser()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT UserID, Username, FullName, Role, IsActive 
                                      FROM users 
                                      WHERE Username = @Username 
                                      AND Password = @Password"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", txtusername.Text.Trim())
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text)

                conn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    If Convert.ToBoolean(reader("IsActive")) = False Then
                        MessageBox.Show("Your account is inactive. Contact administrator.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        reader.Close()
                        Return
                    End If

                    ' Get user details
                    Dim userID As Integer = Convert.ToInt32(reader("UserID"))
                    Dim username As String = reader("Username").ToString()
                    Dim fullName As String = reader("FullName").ToString()
                    Dim role As String = reader("Role").ToString()

                    reader.Close()

                    ' Update last login
                    Dim updateQuery As String = "UPDATE users SET LastLogin = NOW() WHERE UserID = @UserID"
                    Dim cmdUpdate As New MySqlCommand(updateQuery, conn)
                    cmdUpdate.Parameters.AddWithValue("@UserID", userID)
                    cmdUpdate.ExecuteNonQuery()

                    ' Log activity
                    LogActivity(userID, "Login", "users", userID.ToString(), "User logged in", conn)

                    ' Hide login form
                    Me.Hide()

                    ' Open dashboard - FIXED VERSION
                    Try
                        Dim frmDash As New frmMainDashboard()
                        frmDash.CurrentUserID = userID
                        frmDash.CurrentUserName = fullName
                        frmDash.CurrentUserRole = role
                        frmDash.ShowDialog()
                    Catch ex As Exception
                        MessageBox.Show($"Error opening dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Show()
                        Return
                    End Try

                    ' Clear fields and close login
                    txtusername.Clear()
                    txtpassword.Clear()
                    Me.Close()

                Else
                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtpassword.Clear()
                    txtusername.Focus()
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show($"Database Error: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogActivity(userID As Integer, action As String, tableName As String, recordID As String, description As String, conn As MySqlConnection)
        Try
            Dim query As String = "INSERT INTO activity_log (UserID, Action, TableName, RecordID, Description) 
                                  VALUES (@UserID, @Action, @TableName, @RecordID, @Description)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@UserID", userID)
            cmd.Parameters.AddWithValue("@Action", action)
            cmd.Parameters.AddWithValue("@TableName", tableName)
            cmd.Parameters.AddWithValue("@RecordID", recordID)
            cmd.Parameters.AddWithValue("@Description", description)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            ' Silent fail for logging
        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtpassword.Focus()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtpassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class

