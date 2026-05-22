Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text

Public Class frmSettings
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer
    Private testPrintText As String = "TEST PRINT"

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CreateSettingsTableIfMissing()
            LoadSettings()
            LoadPaperSizes()
        Catch ex As Exception
            MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateSettingsTableIfMissing()
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim sql As String = "CREATE TABLE IF NOT EXISTS settings (KeyName VARCHAR(100) PRIMARY KEY, KeyValue TEXT, UpdatedOn DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function GetSettingValue(keyName As String) As String
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Using cmd As New MySqlCommand("SELECT KeyValue FROM settings WHERE KeyName=@KeyName LIMIT 1", conn)
                cmd.Parameters.AddWithValue("@KeyName", keyName)
                Dim result = cmd.ExecuteScalar()
                Return If(result Is Nothing, String.Empty, result.ToString())
            End Using
        End Using
    End Function

    Private Sub SaveSettingValue(keyName As String, keyValue As String)
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Using cmd As New MySqlCommand("INSERT INTO settings (KeyName, KeyValue) VALUES (@KeyName, @KeyValue) ON DUPLICATE KEY UPDATE KeyValue=@KeyValue, UpdatedOn=NOW()", conn)
                cmd.Parameters.AddWithValue("@KeyName", keyName)
                cmd.Parameters.AddWithValue("@KeyValue", keyValue)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub LoadSettings()
        txtCompanyName.Text = GetSettingValue("CompanyName")
        txtCompanyAddress.Text = GetSettingValue("CompanyAddress")
        txtCompanyPhone.Text = GetSettingValue("CompanyPhone")
        txtCompanyEmail.Text = GetSettingValue("CompanyEmail")
        txtPrinterName.Text = GetSettingValue("PrinterName")
    End Sub

    Private Sub LoadPaperSizes()
        cboPaperSize.Items.Clear()
        cboPaperSize.Items.AddRange(New String() {"A4", "A5", "Receipt 80mm", "Receipt 58mm"})
        Dim savedPaperSize = GetSettingValue("PaperSize")
        If Not String.IsNullOrWhiteSpace(savedPaperSize) AndAlso cboPaperSize.Items.Contains(savedPaperSize) Then
            cboPaperSize.SelectedItem = savedPaperSize
        Else
            cboPaperSize.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSaveCompany_Click(sender As Object, e As EventArgs) Handles btnSaveCompany.Click
        Try
            SaveSettingValue("CompanyName", txtCompanyName.Text.Trim())
            SaveSettingValue("CompanyAddress", txtCompanyAddress.Text.Trim())
            SaveSettingValue("CompanyPhone", txtCompanyPhone.Text.Trim())
            SaveSettingValue("CompanyEmail", txtCompanyEmail.Text.Trim())
            MessageBox.Show("Company settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error saving company settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "SQL files (*.sql)|*.sql"
            sfd.FileName = $"posdb_backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql"
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim psi As New ProcessStartInfo("cmd.exe", $"/c mysqldump --user=root --password=Ayyaan@8941 --host=localhost --port=3306 posdb > ""{sfd.FileName}""")
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            Dim proc = Process.Start(psi)
            proc.WaitForExit()

            If proc.ExitCode = 0 Then
                MessageBox.Show("Database backup completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Backup command completed with an error.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error backing up database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Filter = "SQL files (*.sql)|*.sql"
            If ofd.ShowDialog() <> DialogResult.OK Then Return

            If MessageBox.Show("Restoring database will overwrite existing data. Continue?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

            Dim psi As New ProcessStartInfo("cmd.exe", $"/c mysql --user=root --password=Ayyaan@8941 --host=localhost --port=3306 posdb < ""{ofd.FileName}""")
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            Dim proc = Process.Start(psi)
            proc.WaitForExit()

            If proc.ExitCode = 0 Then
                MessageBox.Show("Database restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Restore command completed with an error.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error restoring database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function HashPassword(password As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password))
            Return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant()
        End Using
    End Function

    Private Function ResolveCurrentUserID() As Integer
        If CurrentUserID > 0 Then Return CurrentUserID
        Dim dashboard = Application.OpenForms.OfType(Of frmMainDashboard)().FirstOrDefault()
        If dashboard IsNot Nothing Then Return dashboard.CurrentUserID
        Return 0
    End Function

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim userID As Integer = ResolveCurrentUserID()
        If userID = 0 Then
            MessageBox.Show("Unable to determine current user.", "Security", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtCurrentPassword.Text) OrElse String.IsNullOrWhiteSpace(txtNewPassword.Text) OrElse String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            MessageBox.Show("Please complete all password fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("New password and confirm password do not match.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim currentHash As String = HashPassword(txtCurrentPassword.Text.Trim())
                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE UserID=@UserID AND Password=@PasswordHash", conn)
                    checkCmd.Parameters.AddWithValue("@UserID", userID)
                    checkCmd.Parameters.AddWithValue("@PasswordHash", currentHash)
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) = 0 Then
                        MessageBox.Show("Current password is incorrect.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                Using updateCmd As New MySqlCommand("UPDATE users SET Password=@PasswordHash WHERE UserID=@UserID", conn)
                    updateCmd.Parameters.AddWithValue("@PasswordHash", HashPassword(txtNewPassword.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@UserID", userID)
                    updateCmd.ExecuteNonQuery()
                End Using
            End Using

            txtCurrentPassword.Clear()
            txtNewPassword.Clear()
            txtConfirmPassword.Clear()
            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSavePrinter_Click(sender As Object, e As EventArgs) Handles btnSavePrinter.Click
        Try
            SaveSettingValue("PrinterName", txtPrinterName.Text.Trim())
            SaveSettingValue("PaperSize", cboPaperSize.Text)
            MessageBox.Show("Printer settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error saving printer settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTestPrint_Click(sender As Object, e As EventArgs) Handles btnTestPrint.Click
        Try
            Dim printDoc As New PrintDocument()
            If Not String.IsNullOrWhiteSpace(txtPrinterName.Text) Then
                printDoc.PrinterSettings.PrinterName = txtPrinterName.Text.Trim()
            End If

            AddHandler printDoc.PrintPage,
                Sub(s, args)
                    args.Graphics.DrawString(testPrintText, New Font("Segoe UI", 18, FontStyle.Bold), Brushes.Black, 40, 60)
                End Sub

            printDoc.Print()
            MessageBox.Show("Test print sent to printer.", "Printer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error printing test page: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnResetData_Click(sender As Object, e As EventArgs) Handles btnResetData.Click
        If MessageBox.Show("This will clear sales, purchases, expenses, journals and daybook data. Continue?", "First Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return
        If MessageBox.Show("Please confirm again to permanently clear transactional data.", "Second Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        Dim commands As String() = {
                            "DELETE FROM sales_items",
                            "DELETE FROM sales",
                            "DELETE FROM purchase_items",
                            "DELETE FROM purchases",
                            "DELETE FROM expenses",
                            "DELETE FROM journal_details",
                            "DELETE FROM journal_entries",
                            "DELETE FROM daybook"
                        }

                        For Each sql As String In commands
                            Using cmd As New MySqlCommand(sql, conn, transaction)
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        transaction.Commit()
                    Catch
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("Transactional data cleared successfully!", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error clearing transactional data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
