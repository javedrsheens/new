Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class frmStockTracking
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property CurrentUserID As Integer

    Private Sub frmStockTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            LoadCategories()
            LoadSuppliers()
            LoadStock()
        Catch ex As Exception
            MessageBox.Show($"Error loading stock tracking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        With dgvStock
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
                Dim dt As New DataTable()
                dt.Columns.Add("CategoryID", GetType(Integer))
                dt.Columns.Add("CategoryName", GetType(String))
                dt.Rows.Add(0, "All Categories")

                Dim adapter As New MySqlDataAdapter("SELECT CategoryID, CategoryName FROM categories WHERE IsActive = 1 ORDER BY CategoryName", conn)
                adapter.Fill(dt)

                cboFilterCategory.DataSource = dt
                cboFilterCategory.DisplayMember = "CategoryName"
                cboFilterCategory.ValueMember = "CategoryID"
                cboFilterCategory.SelectedValue = 0
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim dt As New DataTable()
                dt.Columns.Add("SupplierID", GetType(Integer))
                dt.Columns.Add("SupplierName", GetType(String))
                dt.Rows.Add(0, "All Suppliers")

                Dim adapter As New MySqlDataAdapter("SELECT SupplierID, SupplierName FROM suppliers WHERE IsActive = 1 ORDER BY SupplierName", conn)
                adapter.Fill(dt)

                cboFilterSupplier.DataSource = dt
                cboFilterSupplier.DisplayMember = "SupplierName"
                cboFilterSupplier.ValueMember = "SupplierID"
                cboFilterSupplier.SelectedValue = 0
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStock(Optional resetFilters As Boolean = False)
        If resetFilters Then
            cboFilterCategory.SelectedValue = 0
            cboFilterSupplier.SelectedValue = 0
            txtSearch.Clear()
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT p.ProductID, p.Barcode, p.ProductName, c.CategoryName AS Category, s.SupplierName AS Supplier, " &
                                    "p.Stock AS CurrentStock, p.MinStock, p.CostPrice, p.UnitPrice AS SalePrice, " &
                                    "(p.Stock * p.CostPrice) AS StockValue, (p.Stock * p.UnitPrice) AS SaleValue " &
                                    "FROM products p " &
                                    "LEFT JOIN categories c ON p.CategoryID = c.CategoryID " &
                                    "LEFT JOIN suppliers s ON p.SupplierID = s.SupplierID " &
                                    "WHERE p.IsActive = TRUE " &
                                    "AND (@CategoryID = 0 OR p.CategoryID = @CategoryID) " &
                                    "AND (@SupplierID = 0 OR p.SupplierID = @SupplierID) " &
                                    "AND (@SearchText = '' OR p.Barcode LIKE @LikeSearch OR p.ProductName LIKE @LikeSearch) " &
                                    "ORDER BY p.ProductName"

                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(If(cboFilterCategory.SelectedValue Is Nothing, 0, cboFilterCategory.SelectedValue)))
                adapter.SelectCommand.Parameters.AddWithValue("@SupplierID", Convert.ToInt32(If(cboFilterSupplier.SelectedValue Is Nothing, 0, cboFilterSupplier.SelectedValue)))
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", txtSearch.Text.Trim())
                adapter.SelectCommand.Parameters.AddWithValue("@LikeSearch", $"%{txtSearch.Text.Trim()}%")

                Dim dt As New DataTable()
                adapter.Fill(dt)
                If Not dt.Columns.Contains("Status") Then dt.Columns.Add("Status", GetType(String))

                For Each row As DataRow In dt.Rows
                    Dim stock As Decimal = Convert.ToDecimal(row("CurrentStock"))
                    Dim minStock As Decimal = Convert.ToDecimal(row("MinStock"))
                    If stock <= 0 Then
                        row("Status") = "Out of Stock"
                    ElseIf stock <= minStock Then
                        row("Status") = "Low Stock"
                    Else
                        row("Status") = "Normal"
                    End If
                Next

                dgvStock.DataSource = dt
                FormatGrid()
                UpdateSummary(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            If dgvStock.Columns.Count = 0 Then Return
            If dgvStock.Columns.Contains("ProductID") Then dgvStock.Columns("ProductID").Visible = False
            If dgvStock.Columns.Contains("Barcode") Then dgvStock.Columns("Barcode").Width = 110
            If dgvStock.Columns.Contains("ProductName") Then dgvStock.Columns("ProductName").Width = 190
            If dgvStock.Columns.Contains("Category") Then dgvStock.Columns("Category").Width = 120
            If dgvStock.Columns.Contains("Supplier") Then dgvStock.Columns("Supplier").Width = 130
            If dgvStock.Columns.Contains("CurrentStock") Then dgvStock.Columns("CurrentStock").Width = 90
            If dgvStock.Columns.Contains("MinStock") Then dgvStock.Columns("MinStock").Width = 80
            For Each columnName As String In {"CostPrice", "SalePrice", "StockValue", "SaleValue"}
                If dgvStock.Columns.Contains(columnName) Then
                    dgvStock.Columns(columnName).DefaultCellStyle.Format = "N2"
                    dgvStock.Columns(columnName).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvStock.Columns(columnName).Width = 95
                End If
            Next
            If dgvStock.Columns.Contains("Status") Then dgvStock.Columns("Status").Width = 110

            For Each gridRow As DataGridViewRow In dgvStock.Rows
                If gridRow.Cells("Status").Value Is Nothing Then Continue For
                Select Case gridRow.Cells("Status").Value.ToString()
                    Case "Out of Stock"
                        gridRow.DefaultCellStyle.BackColor = Color.LightCoral
                    Case "Low Stock"
                        gridRow.DefaultCellStyle.BackColor = Color.LightYellow
                End Select
            Next
        Catch
        End Try
    End Sub

    Private Sub UpdateSummary(dt As DataTable)
        Dim totalItems As Integer = dt.Rows.Count
        Dim totalStockValue As Decimal = 0D
        Dim totalSaleValue As Decimal = 0D
        Dim lowStockCount As Integer = 0

        For Each row As DataRow In dt.Rows
            totalStockValue += Convert.ToDecimal(row("StockValue"))
            totalSaleValue += Convert.ToDecimal(row("SaleValue"))
            If row("Status").ToString() = "Low Stock" OrElse row("Status").ToString() = "Out of Stock" Then
                lowStockCount += 1
            End If
        Next

        lblTotalItems.Text = $"Total Items: {totalItems}"
        lblTotalStockValue.Text = $"Total Stock Value: {totalStockValue:N2}"
        lblTotalSaleValue.Text = $"Total Sale Value: {totalSaleValue:N2}"
        lblLowStockCount.Text = $"Low Stock Count: {lowStockCount}"
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoadStock()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        LoadStock(True)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvStock.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV files (*.csv)|*.csv"
                sfd.FileName = $"StockTracking_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                If sfd.ShowDialog() <> DialogResult.OK Then Return

                Dim csv As New StringBuilder()
                For Each col As DataGridViewColumn In dgvStock.Columns
                    If col.Visible Then csv.Append(col.HeaderText & ",")
                Next
                csv.AppendLine()

                For Each row As DataGridViewRow In dgvStock.Rows
                    If row.IsNewRow Then Continue For
                    For Each col As DataGridViewColumn In dgvStock.Columns
                        If col.Visible Then csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                    Next
                    csv.AppendLine()
                Next

                File.WriteAllText(sfd.FileName, csv.ToString())
                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error exporting stock tracking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
