Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class frmSubcategories
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private selectedSubcategoryID As Integer = 0

    Private Sub frmSubcategories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadCategories()
            LoadSubcategories()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        With dgvSubcategories
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

    Private Sub LoadCategories()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim adapter As New MySqlDataAdapter("SELECT CategoryID, CategoryName FROM categories WHERE IsActive = 1 ORDER BY CategoryName", conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                cboCategory.DataSource = dt
                cboCategory.DisplayMember = "CategoryName"
                cboCategory.ValueMember = "CategoryID"
                cboCategory.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSubcategories(Optional searchText As String = "")
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As New StringBuilder()
                sql.AppendLine("SELECT sc.SubcategoryID,")
                sql.AppendLine("       sc.SubcategoryName AS 'Subcategory Name',")
                sql.AppendLine("       c.CategoryName AS 'Category',")
                sql.AppendLine("       sc.Description,")
                sql.AppendLine("       COUNT(p.ProductID) AS 'Products Count',")
                sql.AppendLine("       CASE WHEN sc.IsActive = 1 THEN 'Yes' ELSE 'No' END AS 'Active',")
                sql.AppendLine("       DATE_FORMAT(sc.CreatedDate, '%d-%m-%Y') AS 'Created'")
                sql.AppendLine("FROM subcategories sc")
                sql.AppendLine("LEFT JOIN categories c ON sc.CategoryID = c.CategoryID")
                sql.AppendLine("LEFT JOIN products p ON sc.SubcategoryID = p.SubcategoryID")
                sql.AppendLine("WHERE 1=1")
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    sql.AppendLine("  AND (sc.SubcategoryName LIKE @Search OR c.CategoryName LIKE @Search OR sc.Description LIKE @Search)")
                End If
                sql.AppendLine("GROUP BY sc.SubcategoryID, sc.SubcategoryName, c.CategoryName, sc.Description, sc.IsActive, sc.CreatedDate")
                sql.AppendLine("ORDER BY sc.SubcategoryName")

                Dim adapter As New MySqlDataAdapter(sql.ToString(), conn)
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", $"%{searchText.Trim()}%")
                End If

                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvSubcategories.DataSource = dt
                FormatGrid()
                lblTotalSubcategories.Text = $"Total Subcategories: {dt.Rows.Count}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading subcategories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If dgvSubcategories.Columns.Count = 0 Then Return
            If dgvSubcategories.Columns.Contains("SubcategoryID") Then dgvSubcategories.Columns("SubcategoryID").Visible = False
            If dgvSubcategories.Columns.Contains("Subcategory Name") Then dgvSubcategories.Columns("Subcategory Name").Width = 200
            If dgvSubcategories.Columns.Contains("Category") Then dgvSubcategories.Columns("Category").Width = 160
            If dgvSubcategories.Columns.Contains("Description") Then dgvSubcategories.Columns("Description").Width = 220
            If dgvSubcategories.Columns.Contains("Products Count") Then
                dgvSubcategories.Columns("Products Count").Width = 110
                dgvSubcategories.Columns("Products Count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If dgvSubcategories.Columns.Contains("Active") Then dgvSubcategories.Columns("Active").Width = 80
            If dgvSubcategories.Columns.Contains("Created") Then dgvSubcategories.Columns("Created").Width = 110
        Catch
        End Try
    End Sub

    Private Function ValidateFields() As Boolean
        If cboCategory.SelectedValue Is Nothing OrElse cboCategory.SelectedIndex < 0 Then
            MessageBox.Show("Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSubcategoryName.Text) Then
            MessageBox.Show("Subcategory name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSubcategoryName.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM subcategories WHERE SubcategoryName = @Name AND CategoryID = @CategoryID", conn)
                    checkCmd.Parameters.AddWithValue("@Name", txtSubcategoryName.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(cboCategory.SelectedValue))
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Subcategory already exists in selected category.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtSubcategoryName.Focus()
                        Return
                    End If
                End Using

                Dim sql As String = "INSERT INTO subcategories (SubcategoryName, CategoryID, Description, IsActive, CreatedDate) VALUES (@Name, @CategoryID, @Description, @IsActive, NOW())"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Name", txtSubcategoryName.Text.Trim())
                    cmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(cboCategory.SelectedValue))
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Subcategory saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSubcategories()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error saving subcategory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If selectedSubcategoryID = 0 Then
            MessageBox.Show("Please select a subcategory.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not ValidateFields() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM subcategories WHERE SubcategoryName = @Name AND CategoryID = @CategoryID AND SubcategoryID <> @ID", conn)
                    checkCmd.Parameters.AddWithValue("@Name", txtSubcategoryName.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(cboCategory.SelectedValue))
                    checkCmd.Parameters.AddWithValue("@ID", selectedSubcategoryID)
                    If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Subcategory already exists in selected category.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtSubcategoryName.Focus()
                        Return
                    End If
                End Using

                Dim sql As String = "UPDATE subcategories SET SubcategoryName=@Name, CategoryID=@CategoryID, Description=@Description, IsActive=@IsActive WHERE SubcategoryID=@ID"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ID", selectedSubcategoryID)
                    cmd.Parameters.AddWithValue("@Name", txtSubcategoryName.Text.Trim())
                    cmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(cboCategory.SelectedValue))
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Subcategory updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSubcategories()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error updating subcategory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedSubcategoryID = 0 Then
            MessageBox.Show("Please select a subcategory.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Deactivate subcategory '{txtSubcategoryName.Text}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE subcategories SET IsActive = 0 WHERE SubcategoryID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", selectedSubcategoryID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Subcategory deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSubcategories()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show($"Error deleting subcategory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvSubcategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubcategories.CellClick
        If e.RowIndex < 0 Then Return
        Try
            selectedSubcategoryID = Convert.ToInt32(dgvSubcategories.Rows(e.RowIndex).Cells("SubcategoryID").Value)
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT SubcategoryName, CategoryID, Description, IsActive FROM subcategories WHERE SubcategoryID = @ID", conn)
                    cmd.Parameters.AddWithValue("@ID", selectedSubcategoryID)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblSubcategoryIDValue.Text = selectedSubcategoryID.ToString()
                            txtSubcategoryName.Text = reader("SubcategoryName").ToString()
                            cboCategory.SelectedValue = Convert.ToInt32(reader("CategoryID"))
                            txtDescription.Text = reader("Description").ToString()
                            chkActive.Checked = Convert.ToBoolean(reader("IsActive"))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading subcategory details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        selectedSubcategoryID = 0
        lblSubcategoryIDValue.Text = "Auto Generated"
        txtSubcategoryName.Clear()
        txtDescription.Clear()
        chkActive.Checked = True
        cboCategory.SelectedIndex = -1
        txtSearch.Clear()
        txtSubcategoryName.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadSubcategories(txtSearch.Text.Trim())
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadSubcategories()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvSubcategories.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV files (*.csv)|*.csv"
                sfd.FileName = $"Subcategories_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                If sfd.ShowDialog() <> DialogResult.OK Then Return

                Dim csv As New StringBuilder()
                For Each col As DataGridViewColumn In dgvSubcategories.Columns
                    If col.Visible Then csv.Append(col.HeaderText & ",")
                Next
                csv.AppendLine()

                For Each row As DataGridViewRow In dgvSubcategories.Rows
                    If row.IsNewRow Then Continue For
                    For Each col As DataGridViewColumn In dgvSubcategories.Columns
                        If col.Visible Then
                            Dim value As String = If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";")
                            csv.Append(value & ",")
                        End If
                    Next
                    csv.AppendLine()
                Next

                File.WriteAllText(sfd.FileName, csv.ToString())
                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error exporting subcategories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
