Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text

Public Class frmProductHistory
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property CurrentUserID As Integer

    Private selectedProductID As Integer = 0
    Private selectedProductName As String = String.Empty
    Private selectedProductBarcode As String = String.Empty
    Private selectedCurrentStock As Decimal = 0D

    Private Sub frmProductHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
            dtpToDate.Value = DateTime.Today
            cboHistoryType.Items.Clear()
            cboHistoryType.Items.AddRange(New String() {"All", "Purchase", "Sale", "Sale Return", "Purchase Return"})
            cboHistoryType.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show($"Error loading product history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        With dgvHistory
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

    Private Sub btnSearchProduct_Click(sender As Object, e As EventArgs) Handles btnSearchProduct.Click
        SearchProduct()
    End Sub

    Private Sub txtProductSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            SearchProduct()
        End If
    End Sub

    Private Sub SearchProduct()
        If String.IsNullOrWhiteSpace(txtProductSearch.Text) Then
            MessageBox.Show("Enter product barcode or name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductSearch.Focus()
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT ProductID, Barcode, ProductName, Stock FROM products WHERE IsActive = 1 AND (Barcode = @ExactSearch OR Barcode LIKE @LikeSearch OR ProductName LIKE @LikeSearch) ORDER BY CASE WHEN Barcode = @ExactSearch THEN 0 ELSE 1 END, ProductName LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ExactSearch", txtProductSearch.Text.Trim())
                    cmd.Parameters.AddWithValue("@LikeSearch", $"%{txtProductSearch.Text.Trim()}%")
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            selectedProductID = Convert.ToInt32(reader("ProductID"))
                            selectedProductBarcode = reader("Barcode").ToString()
                            selectedProductName = reader("ProductName").ToString()
                            selectedCurrentStock = Convert.ToDecimal(reader("Stock"))
                            lblProductInfo.Text = $"Product: {selectedProductName} | Barcode: {selectedProductBarcode} | Current Stock: {selectedCurrentStock:N2}"
                            LoadHistory()
                        Else
                            MessageBox.Show("Product not found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadHistory()
        If selectedProductID = 0 Then
            MessageBox.Show("Please search and select a product first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim parts As New List(Of String)()
            Dim historyType As String = cboHistoryType.Text

            If historyType = "All" OrElse historyType = "Purchase" Then
                parts.Add("SELECT p.PurchaseDate AS TranDate, 'Purchase' AS Type, p.InvoiceNo AS ReferenceNo, pi.Quantity AS QtyIn, 0 AS QtyOut, pi.UnitPrice AS UnitPrice, pi.Amount AS Total, '' AS Remarks FROM purchase_items pi INNER JOIN purchases p ON pi.PurchaseID = p.PurchaseID WHERE pi.ProductID = @PID AND DATE(p.PurchaseDate) BETWEEN @FromDate AND @ToDate")
            End If
            If historyType = "All" OrElse historyType = "Sale" Then
                parts.Add("SELECT s.SaleDate AS TranDate, 'Sale' AS Type, s.InvoiceNo AS ReferenceNo, 0 AS QtyIn, si.Quantity AS QtyOut, si.UnitPrice AS UnitPrice, si.Amount AS Total, '' AS Remarks FROM sales_items si INNER JOIN sales s ON si.SaleID = s.SaleID WHERE si.ProductID = @PID AND DATE(s.SaleDate) BETWEEN @FromDate AND @ToDate")
            End If
            If historyType = "All" OrElse historyType = "Sale Return" Then
                parts.Add("SELECT sr.ReturnDate AS TranDate, 'Sale Return' AS Type, sr.ReturnNo AS ReferenceNo, sri.Qty AS QtyIn, 0 AS QtyOut, sri.Rate AS UnitPrice, sri.Amount AS Total, COALESCE(sr.Remarks, sr.Reason, '') AS Remarks FROM sales_return_items sri INNER JOIN sales_returns sr ON sri.ReturnID = sr.ReturnID WHERE sri.ProductID = @PID AND DATE(sr.ReturnDate) BETWEEN @FromDate AND @ToDate")
            End If
            If historyType = "All" OrElse historyType = "Purchase Return" Then
                parts.Add("SELECT pr.ReturnDate AS TranDate, 'Purchase Return' AS Type, pr.ReturnNo AS ReferenceNo, 0 AS QtyIn, pri.Quantity AS QtyOut, pri.UnitPrice AS UnitPrice, pri.Amount AS Total, COALESCE(pr.Remarks, pr.Reason, '') AS Remarks FROM purchase_return_items pri INNER JOIN purchase_returns pr ON pri.ReturnID = pr.ReturnID WHERE pri.ProductID = @PID AND DATE(pr.ReturnDate) BETWEEN @FromDate AND @ToDate")
            End If

            If parts.Count = 0 Then
                dgvHistory.DataSource = Nothing
                Return
            End If

            Dim sql As String = "SELECT DATE_FORMAT(h.TranDate, '%d-%m-%Y %H:%i') AS `Date`, h.Type, h.ReferenceNo AS `Reference#`, h.QtyIn AS `Qty In`, h.QtyOut AS `Qty Out`, 0 AS `Balance`, h.UnitPrice AS `Unit Price`, h.Total, h.Remarks FROM (" & String.Join(" UNION ALL ", parts) & ") h ORDER BY h.TranDate, h.ReferenceNo"

            Using conn As New MySqlConnection(connectionString)
                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@PID", selectedProductID)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim totalIn As Decimal = 0D
                Dim totalOut As Decimal = 0D
                For Each row As DataRow In dt.Rows
                    totalIn += Convert.ToDecimal(row("Qty In"))
                    totalOut += Convert.ToDecimal(row("Qty Out"))
                Next

                Dim openingStock As Decimal = selectedCurrentStock - totalIn + totalOut
                Dim runningBalance As Decimal = openingStock
                For Each row As DataRow In dt.Rows
                    runningBalance += Convert.ToDecimal(row("Qty In")) - Convert.ToDecimal(row("Qty Out"))
                    row("Balance") = runningBalance
                Next

                dgvHistory.DataSource = dt
                FormatGrid()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading product history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        Try
            For Each name As String In {"Qty In", "Qty Out", "Balance", "Unit Price", "Total"}
                If dgvHistory.Columns.Contains(name) Then
                    dgvHistory.Columns(name).DefaultCellStyle.Format = "N2"
                    dgvHistory.Columns(name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next
            If dgvHistory.Columns.Contains("Date") Then dgvHistory.Columns("Date").Width = 135
            If dgvHistory.Columns.Contains("Type") Then dgvHistory.Columns("Type").Width = 120
            If dgvHistory.Columns.Contains("Reference#") Then dgvHistory.Columns("Reference#").Width = 120
            If dgvHistory.Columns.Contains("Remarks") Then dgvHistory.Columns("Remarks").Width = 220
        Catch
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadHistory()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvHistory.Rows.Count = 0 Then
                MessageBox.Show("No history available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV files (*.csv)|*.csv"
                sfd.FileName = $"ProductHistory_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
                If sfd.ShowDialog() <> DialogResult.OK Then Return

                Dim csv As New StringBuilder()
                For Each col As DataGridViewColumn In dgvHistory.Columns
                    csv.Append(col.HeaderText & ",")
                Next
                csv.AppendLine()

                For Each row As DataGridViewRow In dgvHistory.Rows
                    If row.IsNewRow Then Continue For
                    For Each col As DataGridViewColumn In dgvHistory.Columns
                        csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                    Next
                    csv.AppendLine()
                Next

                File.WriteAllText(sfd.FileName, csv.ToString())
                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error exporting product history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
