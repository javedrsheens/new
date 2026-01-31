Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmCategories
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=posdb;Uid=root;Pwd=Ayyaan@8941;"

    ' Form state
    Private selectedCategoryID As Integer = 0
    Private isEditMode As Boolean = False

    ' ================================================
    ' FORM LOAD
    ' ================================================
    Private Sub frmCategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadCategories()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' SETUP GRID
    ' ================================================
    Private Sub SetupGrid()
        If dgvCategories Is Nothing Then Return

        With dgvCategories
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
    ' LOAD CATEGORIES
    ' ================================================
    Private Sub LoadCategories()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT 
                    c.CategoryID,
                    c.CategoryName AS 'Category Name',
                    c.Description,
                    COUNT(p.ProductID) AS 'Products',
                    CASE WHEN c.IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active',
                    DATE_FORMAT(c.CreatedDate, '%d-%m-%Y') AS 'Created'
                FROM categories c
                LEFT JOIN products p ON c.CategoryID = p.CategoryID
                GROUP BY c.CategoryID, c. CategoryName, c.Description, c.IsActive, c.CreatedDate
                ORDER BY c.CategoryName"

                Dim adapter As New MySqlDataAdapter(sql, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCategories.DataSource = dt
                FormatGrid()

                lblTotalCategories.Text = $"Total Categories: {dt.Rows.Count}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If dgvCategories.Columns.Count = 0 Then Return

            With dgvCategories
                ' Hide ID column
                If .Columns.Contains("CategoryID") Then
                    .Columns("CategoryID").Visible = False
                End If

                ' Set widths
                If .Columns.Contains("Category Name") Then
                    .Columns("Category Name").Width = 200
                End If

                If .Columns.Contains("Description") Then
                    .Columns("Description").Width = 300
                End If

                If .Columns.Contains("Products") Then
                    .Columns("Products").Width = 100
                    .Columns("Products").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

                If .Columns.Contains("Active") Then
                    .Columns("Active").Width = 80
                    .Columns("Active").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

                If .Columns.Contains("Created") Then
                    .Columns("Created").Width = 120
                End If
            End With
        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    ' ================================================
    ' SAVE CATEGORY
    ' ================================================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                ' Check for duplicate
                Dim checkSql As String = "SELECT COUNT(*) FROM categories WHERE CategoryName = @Name"
                Dim cmdCheck As New MySqlCommand(checkSql, conn)
                cmdCheck.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim())

                conn.Open()
                Dim count = Convert.ToInt32(cmdCheck.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Category name already exists!", "Duplicate",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCategoryName.Focus()
                    txtCategoryName.SelectAll()
                    Return
                End If

                ' Insert
                Dim sql As String = "INSERT INTO categories (CategoryName, Description, IsActive) 
                                    VALUES (@Name, @Desc, @Active)"

                Dim cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@Active", chkActive.Checked)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Category saved successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadCategories()
                ClearFields()
                txtCategoryName.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving:  {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' UPDATE CATEGORY
    ' ================================================
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedCategoryID = 0 Then
            MessageBox.Show("Please select a category", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Check for duplicate (excluding current)
                Dim checkSql As String = "SELECT COUNT(*) FROM categories 
                                         WHERE CategoryName = @Name AND CategoryID <> @ID"
                Dim cmdCheck As New MySqlCommand(checkSql, conn)
                cmdCheck.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim())
                cmdCheck.Parameters.AddWithValue("@ID", selectedCategoryID)

                Dim count = Convert.ToInt32(cmdCheck.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Category name already exists!", "Duplicate",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCategoryName.Focus()
                    Return
                End If

                ' Update
                Dim sql As String = "UPDATE categories SET 
                                    CategoryName = @Name,
                                    Description = @Desc,
                                    IsActive = @Active
                                    WHERE CategoryID = @ID"

                Dim cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ID", selectedCategoryID)
                cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@Active", chkActive.Checked)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Category updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadCategories()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' DELETE CATEGORY
    ' ================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedCategoryID = 0 Then
            MessageBox.Show("Please select a category", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result = MessageBox.Show($"Delete category '{txtCategoryName.Text}'?{vbCrLf}{vbCrLf}Note: This will deactivate the category.",
                                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Check if category has products
                Dim checkSql As String = "SELECT COUNT(*) FROM products WHERE CategoryID = @ID"
                Dim cmdCheck As New MySqlCommand(checkSql, conn)
                cmdCheck.Parameters.AddWithValue("@ID", selectedCategoryID)

                Dim productCount = Convert.ToInt32(cmdCheck.ExecuteScalar())

                If productCount > 0 Then
                    MessageBox.Show($"Cannot delete! {vbCrLf}This category has {productCount} product(s).{vbCrLf}{vbCrLf}The category will be deactivated instead.",
                                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                ' Soft delete (deactivate)
                Dim sql As String = "UPDATE categories SET IsActive = 0 WHERE CategoryID = @ID"
                Dim cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ID", selectedCategoryID)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Category deleted successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadCategories()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' GRID CLICK
    ' ================================================
    Private Sub dgvCategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategories.CellClick
        If e.RowIndex < 0 Then Return

        Try
            Dim row = dgvCategories.Rows(e.RowIndex)

            selectedCategoryID = GetCellValue(Of Integer)(row, "CategoryID")
            lblCategoryIDValue.Text = selectedCategoryID.ToString()
            txtCategoryName.Text = GetCellValue(Of String)(row, "Category Name")
            txtDescription.Text = GetCellValue(Of String)(row, "Description")

            Dim activeStr = GetCellValue(Of String)(row, "Active")
            chkActive.Checked = (activeStr = "Yes")

            isEditMode = True
            btnSave.Enabled = False
            btnUpdate.Enabled = True
            btnDelete.Enabled = True

        Catch ex As Exception
            MessageBox.Show($"Error loading category: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCellValue(Of T)(row As DataGridViewRow, columnName As String) As T
        Try
            If Not row.DataGridView.Columns.Contains(columnName) Then
                Return Nothing
            End If

            Dim cell = row.Cells(columnName)
            If cell.Value Is Nothing OrElse IsDBNull(cell.Value) Then
                Return Nothing
            End If

            Return CType(cell.Value, T)
        Catch
            Return Nothing
        End Try
    End Function

    ' ================================================
    ' SEARCH
    ' ================================================
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchCategories()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchCategories()
        End If
    End Sub

    Private Sub SearchCategories()
        Try
            Dim searchText = txtSearch.Text.Trim()

            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT 
                    c.CategoryID,
                    c.CategoryName AS 'Category Name',
                    c.Description,
                    COUNT(p. ProductID) AS 'Products',
                    CASE WHEN c.IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active',
                    DATE_FORMAT(c.CreatedDate, '%d-%m-%Y') AS 'Created'
                FROM categories c
                LEFT JOIN products p ON c. CategoryID = p.CategoryID
                WHERE c.CategoryName LIKE @Search 
                   OR c.Description LIKE @Search
                GROUP BY c.CategoryID, c. CategoryName, c.Description, c.IsActive, c.CreatedDate
                ORDER BY c.CategoryName"

                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Search", $"%{searchText}%")

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCategories.DataSource = dt
                FormatGrid()

                lblTotalCategories.Text = $"Found:  {dt.Rows.Count} categories"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadCategories()
    End Sub

    ' ================================================
    ' EXPORT
    ' ================================================
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvCategories.Rows.Count = 0 Then
                MessageBox.Show("No data to export", "Info",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = $"Categories_{DateTime.Now:yyyyMMdd}. csv"

            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim csv As New Text.StringBuilder()

            ' Headers
            For i = 0 To dgvCategories.Columns.Count - 1
                If dgvCategories.Columns(i).Visible Then
                    csv.Append(dgvCategories.Columns(i).HeaderText & ",")
                End If
            Next
            csv.AppendLine()

            ' Rows
            For Each row As DataGridViewRow In dgvCategories.Rows
                For i = 0 To dgvCategories.Columns.Count - 1
                    If dgvCategories.Columns(i).Visible Then
                        Dim val = If(row.Cells(i).Value?.ToString(), "")
                        csv.Append(val.Replace(",", ";") & ",")
                    End If
                Next
                csv.AppendLine()
            Next

            File.WriteAllText(sfd.FileName, csv.ToString())

            MessageBox.Show("Export completed!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error exporting: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ================================================
    ' HELPERS
    ' ================================================
    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
            MessageBox.Show("Enter category name", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearFields()
        txtCategoryName.Clear()
        txtDescription.Clear()
        chkActive.Checked = True

        selectedCategoryID = 0
        lblCategoryIDValue.Text = "Auto Generated"
        isEditMode = False

        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False

        txtCategoryName.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lblTotalCategories_Click(sender As Object, e As EventArgs) Handles lblTotalCategories.Click

    End Sub
End Class