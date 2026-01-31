Imports MySql.Data.MySqlClient

Public Class frmExpenseCategories
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private selectedCategoryID As Integer = 0

    Private Sub frmExpenseCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        ClearFields()
    End Sub

    Private Sub LoadCategories()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          ExpenseCategoryID AS 'ID',
                                          CategoryName AS 'Category Name',
                                          Description,
                                          IsActive AS 'Active'
                                      FROM expense_categories
                                      ORDER BY CategoryName"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCategories.DataSource = dt

                With dgvCategories
                    .Columns("ID").Visible = False
                    .Columns("Category Name").Width = 200
                    .Columns("Description").Width = 300
                    .Columns("Active").Width = 80
                End With

                lblTotalCategories.Text = $"Total Categories: {dt.Rows.Count}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
            MessageBox.Show("Please enter category name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "INSERT INTO expense_categories (CategoryName, Description, IsActive) VALUES (@Name, @Description, @IsActive)"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Category saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCategories()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click
        If selectedCategoryID = 0 Then
            MessageBox.Show("Please select a category to update", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "UPDATE expense_categories SET CategoryName = @Name, Description = @Description, IsActive = @IsActive WHERE ExpenseCategoryID = @ID"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", selectedCategoryID)
                cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCategories()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategories.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvCategories.Rows(e.RowIndex)
            selectedCategoryID = Convert.ToInt32(row.Cells("ID").Value)
            txtCategoryName.Text = row.Cells("Category Name").Value.ToString()
            txtDescription.Text = If(row.Cells("Description").Value IsNot Nothing, row.Cells("Description").Value.ToString(), "")
            chkActive.Checked = Convert.ToBoolean(row.Cells("Active").Value)

            btnUPDATE.Enabled = True
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnCLEAR.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtCategoryName.Clear()
        txtDescription.Clear()
        chkActive.Checked = True
        selectedCategoryID = 0
        btnUPDATE.Enabled = False
        txtCategoryName.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class