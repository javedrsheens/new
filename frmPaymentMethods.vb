Imports MySql.Data.MySqlClient

Public Class frmPaymentMethods
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private selectedMethodID As Integer = 0
    Private isEditMode As Boolean = False

    ' ================================================
    ' FORM LOAD
    ' ================================================
    Private Sub frmPaymentMethods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadPaymentMethods()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' SETUP GRID
    ' ================================================
    Private Sub SetupGrid()
        With dgvPaymentMethods
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

    ' ================================================
    ' LOAD PAYMENT METHODS
    ' ================================================
    Private Sub LoadPaymentMethods()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT PaymentMethodID,
                                            MethodName AS 'Method Name',
                                            DisplayOrder AS 'Display Order',
                                            CASE WHEN IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active',
                                            Notes
                                     FROM payment_methods
                                     ORDER BY DisplayOrder, MethodName"
                Dim adapter As New MySqlDataAdapter(sql, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvPaymentMethods.DataSource = dt

                If dgvPaymentMethods.Columns.Contains("PaymentMethodID") Then
                    dgvPaymentMethods.Columns("PaymentMethodID").Visible = False
                End If
                If dgvPaymentMethods.Columns.Contains("Method Name") Then
                    dgvPaymentMethods.Columns("Method Name").Width = 160
                End If
                If dgvPaymentMethods.Columns.Contains("Display Order") Then
                    dgvPaymentMethods.Columns("Display Order").Width = 110
                    dgvPaymentMethods.Columns("Display Order").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
                If dgvPaymentMethods.Columns.Contains("Active") Then
                    dgvPaymentMethods.Columns("Active").Width = 80
                    dgvPaymentMethods.Columns("Active").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If
                If dgvPaymentMethods.Columns.Contains("Notes") Then
                    dgvPaymentMethods.Columns("Notes").Width = 200
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading payment methods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' ADD NEW
    ' ================================================
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM payment_methods WHERE MethodName = @Name", conn)
                checkCmd.Parameters.AddWithValue("@Name", txtMethodName.Text.Trim())
                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Payment method name already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtMethodName.Focus()
                    Return
                End If

                Dim cmd As New MySqlCommand(
                    "INSERT INTO payment_methods (MethodName, DisplayOrder, IsActive, Notes) " &
                    "VALUES (@Name, @Order, @Active, @Notes)", conn)
                cmd.Parameters.AddWithValue("@Name", txtMethodName.Text.Trim())
                cmd.Parameters.AddWithValue("@Order", CInt(numDisplayOrder.Value))
                cmd.Parameters.AddWithValue("@Active", If(chkIsActive.Checked, 1, 0))
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                cmd.ExecuteNonQuery()

                MessageBox.Show("Payment method added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPaymentMethods()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error adding payment method: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' EDIT / UPDATE
    ' ================================================
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedMethodID = 0 Then
            MessageBox.Show("Please select a payment method to edit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim checkCmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM payment_methods WHERE MethodName = @Name AND PaymentMethodID <> @ID", conn)
                checkCmd.Parameters.AddWithValue("@Name", txtMethodName.Text.Trim())
                checkCmd.Parameters.AddWithValue("@ID", selectedMethodID)
                If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Payment method name already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtMethodName.Focus()
                    Return
                End If

                Dim cmd As New MySqlCommand(
                    "UPDATE payment_methods SET MethodName=@Name, DisplayOrder=@Order, IsActive=@Active, Notes=@Notes " &
                    "WHERE PaymentMethodID=@ID", conn)
                cmd.Parameters.AddWithValue("@Name", txtMethodName.Text.Trim())
                cmd.Parameters.AddWithValue("@Order", CInt(numDisplayOrder.Value))
                cmd.Parameters.AddWithValue("@Active", If(chkIsActive.Checked, 1, 0))
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim())
                cmd.Parameters.AddWithValue("@ID", selectedMethodID)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Payment method updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPaymentMethods()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating payment method: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' DELETE
    ' ================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedMethodID = 0 Then
            MessageBox.Show("Please select a payment method to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Delete payment method '{txtMethodName.Text}'?{vbCrLf}This will deactivate it.",
                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("UPDATE payment_methods SET IsActive = 0 WHERE PaymentMethodID = @ID", conn)
                cmd.Parameters.AddWithValue("@ID", selectedMethodID)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Payment method deactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPaymentMethods()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting payment method: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' GRID CLICK – POPULATE FIELDS
    ' ================================================
    Private Sub dgvPaymentMethods_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentMethods.CellClick
        If e.RowIndex < 0 Then Return

        Try
            Dim row = dgvPaymentMethods.Rows(e.RowIndex)
            selectedMethodID = Convert.ToInt32(row.Cells("PaymentMethodID").Value)
            txtMethodName.Text = row.Cells("Method Name").Value?.ToString()
            numDisplayOrder.Value = Convert.ToDecimal(row.Cells("Display Order").Value)
            chkIsActive.Checked = (row.Cells("Active").Value?.ToString() = "Yes")
            txtNotes.Text = If(row.Cells("Notes").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Notes").Value),
                               row.Cells("Notes").Value.ToString(), "")
            isEditMode = True
        Catch ex As Exception
            MessageBox.Show($"Error loading row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' REFRESH
    ' ================================================
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadPaymentMethods()
        ClearFields()
    End Sub

    ' ================================================
    ' CLOSE
    ' ================================================
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ================================================
    ' HELPERS
    ' ================================================
    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtMethodName.Text) Then
            MessageBox.Show("Enter payment method name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMethodName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ClearFields()
        txtMethodName.Clear()
        numDisplayOrder.Value = 0
        chkIsActive.Checked = True
        chkIsCreditMethod.Checked = False
        txtNotes.Clear()
        selectedMethodID = 0
        isEditMode = False
        txtMethodName.Focus()
    End Sub
End Class
