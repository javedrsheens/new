Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class frmSuppliers
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private selectedSupplierID As Integer = 0

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        With dgvSuppliers
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

    Private Sub LoadSuppliers(Optional searchText As String = "")
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As New StringBuilder()
                sql.AppendLine("SELECT SupplierID,")
                sql.AppendLine("       SupplierName AS 'Supplier Name',")
                sql.AppendLine("       ContactPerson AS 'Contact Person',")
                sql.AppendLine("       Phone,")
                sql.AppendLine("       City,")
                sql.AppendLine("       Balance,")
                sql.AppendLine("       CASE WHEN IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active'")
                sql.AppendLine("FROM suppliers")

                Dim adapter As New MySqlDataAdapter()
                adapter.SelectCommand = New MySqlCommand()
                adapter.SelectCommand.Connection = conn

                If String.IsNullOrWhiteSpace(searchText) Then
                    sql.AppendLine("ORDER BY SupplierName")
                Else
                    sql.AppendLine("WHERE SupplierName LIKE @Search")
                    sql.AppendLine("   OR ContactPerson LIKE @Search")
                    sql.AppendLine("   OR Phone LIKE @Search")
                    sql.AppendLine("   OR City LIKE @Search")
                    sql.AppendLine("ORDER BY SupplierName")
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", $"%{searchText.Trim()}%")
                End If

                adapter.SelectCommand.CommandText = sql.ToString()

                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvSuppliers.DataSource = dt
                FormatGrid()
                lblTotalSuppliers.Text = If(String.IsNullOrWhiteSpace(searchText), $"Total Suppliers: {dt.Rows.Count}", $"Found Suppliers: {dt.Rows.Count}")
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If dgvSuppliers.Columns.Count = 0 Then Return

            If dgvSuppliers.Columns.Contains("SupplierID") Then
                dgvSuppliers.Columns("SupplierID").Visible = False
            End If

            If dgvSuppliers.Columns.Contains("Supplier Name") Then dgvSuppliers.Columns("Supplier Name").Width = 230
            If dgvSuppliers.Columns.Contains("Contact Person") Then dgvSuppliers.Columns("Contact Person").Width = 180
            If dgvSuppliers.Columns.Contains("Phone") Then dgvSuppliers.Columns("Phone").Width = 120
            If dgvSuppliers.Columns.Contains("City") Then dgvSuppliers.Columns("City").Width = 120
            If dgvSuppliers.Columns.Contains("Balance") Then
                dgvSuppliers.Columns("Balance").Width = 110
                dgvSuppliers.Columns("Balance").DefaultCellStyle.Format = "N2"
                dgvSuppliers.Columns("Balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If dgvSuppliers.Columns.Contains("Active") Then dgvSuppliers.Columns("Active").Width = 80
        Catch
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            MessageBox.Show("Enter supplier name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim checkSql As String = "SELECT COUNT(*) FROM suppliers WHERE SupplierName = @SupplierName"
                Using checkCmd As New MySqlCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim())
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Supplier name already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtSupplierName.Focus()
                        Return
                    End If
                End Using

                Dim sql As String = "INSERT INTO suppliers (SupplierName, ContactPerson, Phone, Email, Address, City, Balance, IsActive, CreatedDate) " &
                                    "VALUES (@SupplierName, @ContactPerson, @Phone, @Email, @Address, @City, @Balance, @IsActive, NOW())"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                    cmd.Parameters.AddWithValue("@Balance", 0D)
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Supplier saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error saving supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedSupplierID = 0 Then
            MessageBox.Show("Please select a supplier", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim checkSql As String = "SELECT COUNT(*) FROM suppliers WHERE SupplierName = @SupplierName AND SupplierID <> @SupplierID"
                Using checkCmd As New MySqlCommand(checkSql, conn)
                    checkCmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@SupplierID", selectedSupplierID)
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Supplier name already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtSupplierName.Focus()
                        Return
                    End If
                End Using

                Dim sql As String = "UPDATE suppliers SET SupplierName=@SupplierName, ContactPerson=@ContactPerson, Phone=@Phone, Email=@Email, Address=@Address, City=@City, IsActive=@IsActive WHERE SupplierID=@SupplierID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@SupplierID", selectedSupplierID)
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim())
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error updating supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedSupplierID = 0 Then
            MessageBox.Show("Please select a supplier", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Delete supplier '{txtSupplierName.Text}'?{vbCrLf}{vbCrLf}This will deactivate the supplier.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "UPDATE suppliers SET IsActive = 0 WHERE SupplierID = @SupplierID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@SupplierID", selectedSupplierID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSuppliers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvSuppliers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSuppliers.CellClick
        If e.RowIndex < 0 Then Return

        Try
            Dim supplierID As Integer = Convert.ToInt32(dgvSuppliers.Rows(e.RowIndex).Cells("SupplierID").Value)
            LoadSupplierDetails(supplierID)
        Catch ex As Exception
            MessageBox.Show($"Error loading supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSupplierDetails(supplierID As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT SupplierID, SupplierName, ContactPerson, Phone, Email, Address, City, Balance, IsActive FROM suppliers WHERE SupplierID = @SupplierID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID)
                    conn.Open()

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            selectedSupplierID = Convert.ToInt32(reader("SupplierID"))
                            lblSupplierIDValue.Text = selectedSupplierID.ToString()
                            txtSupplierName.Text = reader("SupplierName").ToString()
                            txtContactPerson.Text = reader("ContactPerson").ToString()
                            txtPhone.Text = reader("Phone").ToString()
                            txtEmail.Text = reader("Email").ToString()
                            txtAddress.Text = reader("Address").ToString()
                            txtCity.Text = reader("City").ToString()
                            txtBalance.Text = Convert.ToDecimal(If(IsDBNull(reader("Balance")), 0D, reader("Balance"))).ToString("0.00")
                            chkActive.Checked = Convert.ToBoolean(reader("IsActive"))
                        End If
                    End Using
                End Using
            End Using

            btnSave.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Catch ex As Exception
            MessageBox.Show($"Error loading supplier details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SearchSuppliers()
        LoadSuppliers(txtSearch.Text)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchSuppliers()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchSuppliers()
        End If
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadSuppliers()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvSuppliers.Rows.Count = 0 Then
                MessageBox.Show("No data to export", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = $"Suppliers_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim csv As New StringBuilder()
            For Each col As DataGridViewColumn In dgvSuppliers.Columns
                If col.Visible Then csv.Append(col.HeaderText & ",")
            Next
            csv.AppendLine()

            For Each row As DataGridViewRow In dgvSuppliers.Rows
                For Each col As DataGridViewColumn In dgvSuppliers.Columns
                    If col.Visible Then
                        csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                    End If
                Next
                csv.AppendLine()
            Next

            File.WriteAllText(sfd.FileName, csv.ToString())
            MessageBox.Show("Export completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error exporting suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtSupplierName.Clear()
        txtContactPerson.Clear()
        txtPhone.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        txtCity.Clear()
        txtBalance.Text = "0.00"
        chkActive.Checked = True
        selectedSupplierID = 0
        lblSupplierIDValue.Text = "Auto Generated"
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtSupplierName.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
