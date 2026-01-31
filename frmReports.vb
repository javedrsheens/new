Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Diagnostics

Public Class frmReports
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date range
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Now

        ' Load first report by default
        LoadSalesReport()
    End Sub

    ' ============================================
    ' TAB 1: SALES REPORT
    ' ============================================

    Private Sub tabSales_Enter(sender As Object, e As EventArgs) Handles tabSales.Enter
        LoadSalesReport()
    End Sub

    Private Sub btnLoadSalesReport_Click(sender As Object, e As EventArgs) Handles btnLoadSalesReport.Click
        LoadSalesReport()
    End Sub

    Private Sub LoadSalesReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          s.InvoiceNo AS 'Invoice No',
                                          DATE_FORMAT(s.SaleDate, '%d-%m-%Y %h:%i %p') AS 'Date & Time',
                                          c.CustomerName AS 'Customer',
                                          s.TotalAmount AS 'Total',
                                          s.DiscountAmount AS 'Discount',
                                          s.TaxAmount AS 'Tax',
                                          s.NetAmount AS 'Net Amount',
                                          s.PaymentMethod AS 'Payment',
                                          s.PaymentStatus AS 'Status',
                                          u.FullName AS 'Cashier'
                                      FROM sales s
                                      LEFT JOIN customers c ON s.CustomerID = c.CustomerID
                                      LEFT JOIN users u ON s.CashierID = u.UserID
                                      WHERE DATE(s.SaleDate) BETWEEN @FromDate AND @ToDate
                                      ORDER BY s.SaleDate DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvSalesReport.DataSource = dt
                FormatSalesGrid()
                CalculateSalesSummary(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading sales report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatSalesGrid()
        With dgvSalesReport
            If .Columns.Count > 0 Then
                .Columns("Total").DefaultCellStyle.Format = "N2"
                .Columns("Discount").DefaultCellStyle.Format = "N2"
                .Columns("Tax").DefaultCellStyle.Format = "N2"
                .Columns("Net Amount").DefaultCellStyle.Format = "N2"

                .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Discount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Tax").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Net Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        End With
    End Sub

    Private Sub CalculateSalesSummary(dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim totalSales As Decimal = 0
            Dim totalDiscount As Decimal = 0
            Dim totalTax As Decimal = 0
            Dim netAmount As Decimal = 0

            For Each row As DataRow In dt.Rows
                totalSales += Convert.ToDecimal(row("Total"))
                totalDiscount += Convert.ToDecimal(row("Discount"))
                totalTax += Convert.ToDecimal(row("Tax"))
                netAmount += Convert.ToDecimal(row("Net Amount"))
            Next

            lblSalesTotalSales.Text = $"₹ {totalSales:N2}"
            lblSalesDiscount.Text = $"₹ {totalDiscount:N2}"
            lblSalesTax.Text = $"₹ {totalTax:N2}"
            lblSalesNetAmount.Text = $"₹ {netAmount:N2}"
            lblSalesTransactions.Text = dt.Rows.Count.ToString()
        Else
            lblSalesTotalSales.Text = "₹ 0.00"
            lblSalesDiscount.Text = "₹ 0.00"
            lblSalesTax.Text = "₹ 0.00"
            lblSalesNetAmount.Text = "₹ 0.00"
            lblSalesTransactions.Text = "0"
        End If
    End Sub

    ' ============================================
    ' TAB 2: PURCHASE REPORT
    ' ============================================

    Private Sub tabPurchase_Enter(sender As Object, e As EventArgs) Handles tabPurchase.Enter
        LoadPurchaseReport()
    End Sub

    Private Sub btnLoadPurchaseReport_Click(sender As Object, e As EventArgs) Handles btnLoadPurchaseReport.Click
        LoadPurchaseReport()
    End Sub

    Private Sub LoadPurchaseReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          p.PurchaseNo AS 'Purchase No',
                                          DATE_FORMAT(p.PurchaseDate, '%d-%m-%Y') AS 'Date',
                                          s.SupplierName AS 'Supplier',
                                          p.TotalAmount AS 'Total',
                                          p.TaxAmount AS 'Tax',
                                          p.NetAmount AS 'Net Amount',
                                          p.PaidAmount AS 'Paid',
                                          p.DueAmount AS 'Due',
                                          p.PaymentStatus AS 'Status',
                                          u.FullName AS 'Created By'
                                      FROM purchases p
                                      LEFT JOIN suppliers s ON p.SupplierID = s.SupplierID
                                      LEFT JOIN users u ON p.CreatedBy = u.UserID
                                      WHERE DATE(p.PurchaseDate) BETWEEN @FromDate AND @ToDate
                                      ORDER BY p.PurchaseDate DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvPurchaseReport.DataSource = dt
                FormatPurchaseGrid()
                CalculatePurchaseSummary(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading purchase report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatPurchaseGrid()
        With dgvPurchaseReport
            If .Columns.Count > 0 Then
                .Columns("Total").DefaultCellStyle.Format = "N2"
                .Columns("Tax").DefaultCellStyle.Format = "N2"
                .Columns("Net Amount").DefaultCellStyle.Format = "N2"
                .Columns("Paid").DefaultCellStyle.Format = "N2"
                .Columns("Due").DefaultCellStyle.Format = "N2"

                .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Tax").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Net Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Paid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Due").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ' Highlight pending payments
                For Each row As DataGridViewRow In .Rows
                    If row.Cells("Status").Value IsNot Nothing Then
                        If row.Cells("Status").Value.ToString() = "Pending" Then
                            row.DefaultCellStyle.BackColor = Color.LightCoral
                        ElseIf row.Cells("Status").Value.ToString() = "Partial" Then
                            row.DefaultCellStyle.BackColor = Color.LightYellow
                        End If
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub CalculatePurchaseSummary(dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim totalPurchase As Decimal = 0
            Dim totalPaid As Decimal = 0
            Dim totalDue As Decimal = 0

            For Each row As DataRow In dt.Rows
                totalPurchase += Convert.ToDecimal(row("Net Amount"))
                totalPaid += Convert.ToDecimal(row("Paid"))
                totalDue += Convert.ToDecimal(row("Due"))
            Next

            lblPurchaseTotal.Text = $"₹ {totalPurchase:N2}"
            lblPurchasePaid.Text = $"₹ {totalPaid:N2}"
            lblPurchaseDue.Text = $"₹ {totalDue:N2}"
            lblPurchaseCount.Text = dt.Rows.Count.ToString()
        Else
            lblPurchaseTotal.Text = "₹ 0.00"
            lblPurchasePaid.Text = "₹ 0.00"
            lblPurchaseDue.Text = "₹ 0.00"
            lblPurchaseCount.Text = "0"
        End If
    End Sub

    ' ============================================
    ' TAB 3: STOCK REPORT
    ' ============================================

    Private Sub tabStock_Enter(sender As Object, e As EventArgs) Handles tabStock.Enter
        LoadStockReport()
    End Sub

    Private Sub btnLoadStockReport_Click(sender As Object, e As EventArgs) Handles btnLoadStockReport.Click
        LoadStockReport()
    End Sub

    Private Sub LoadStockReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          p.ProductID AS 'Product ID',
                                          p.ProductName AS 'Product Name',
                                          c.CategoryName AS 'Category',
                                          p.Stock AS 'Current Stock',
                                          p.MinStock AS 'Min Stock',
                                          p.MaxStock AS 'Max Stock',
                                          p.Unit AS 'Unit',
                                          p.UnitPrice AS 'Price',
                                          p.CostPrice AS 'Cost',
                                          (p.Stock * p.CostPrice) AS 'Stock Value',
                                          CASE 
                                              WHEN p.Stock <= 0 THEN 'Out of Stock'
                                              WHEN p.Stock <= p.MinStock THEN 'Low Stock'
                                              WHEN p.Stock >= p.MaxStock THEN 'Overstock'
                                              ELSE 'Normal'
                                          END AS 'Status'
                                      FROM products p
                                      LEFT JOIN categories c ON p.CategoryID = c.CategoryID
                                      WHERE p.IsActive = TRUE
                                      ORDER BY p.Stock ASC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvStockReport.DataSource = dt
                FormatStockGrid()
                CalculateStockSummary(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading stock report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatStockGrid()
        With dgvStockReport
            If .Columns.Count > 0 Then
                .Columns("Price").DefaultCellStyle.Format = "N2"
                .Columns("Cost").DefaultCellStyle.Format = "N2"
                .Columns("Stock Value").DefaultCellStyle.Format = "N2"

                .Columns("Current Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Cost").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Stock Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ' Highlight rows based on status
                For Each row As DataGridViewRow In .Rows
                    If row.Cells("Status").Value IsNot Nothing Then
                        Select Case row.Cells("Status").Value.ToString()
                            Case "Out of Stock"
                                row.DefaultCellStyle.BackColor = Color.LightCoral
                            Case "Low Stock"
                                row.DefaultCellStyle.BackColor = Color.LightYellow
                            Case "Overstock"
                                row.DefaultCellStyle.BackColor = Color.LightBlue
                        End Select
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub CalculateStockSummary(dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim totalItems As Integer = dt.Rows.Count
            Dim totalStockValue As Decimal = 0
            Dim lowStockItems As Integer = 0
            Dim outOfStockItems As Integer = 0

            For Each row As DataRow In dt.Rows
                totalStockValue += Convert.ToDecimal(row("Stock Value"))

                Dim status As String = row("Status").ToString()
                If status = "Low Stock" Then lowStockItems += 1
                If status = "Out of Stock" Then outOfStockItems += 1
            Next

            lblStockTotalItems.Text = totalItems.ToString()
            lblStockValue.Text = $"₹ {totalStockValue:N2}"
            lblStockLowStock.Text = lowStockItems.ToString()
            lblStockOutOfStock.Text = outOfStockItems.ToString()
        Else
            lblStockTotalItems.Text = "0"
            lblStockValue.Text = "₹ 0.00"
            lblStockLowStock.Text = "0"
            lblStockOutOfStock.Text = "0"
        End If
    End Sub

    ' ============================================
    ' TAB 4: PROFIT REPORT
    ' ============================================

    Private Sub tabProfit_Enter(sender As Object, e As EventArgs) Handles tabProfit.Enter
        LoadProfitReport()
    End Sub

    Private Sub btnLoadProfitReport_Click(sender As Object, e As EventArgs) Handles btnLoadProfitReport.Click
        LoadProfitReport()
    End Sub

    Private Sub LoadProfitReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          sd.ProductID AS 'Product ID',
                                          sd.ProductName AS 'Product Name',
                                          SUM(sd.Quantity) AS 'Qty Sold',
                                          p.CostPrice AS 'Cost Price',
                                          AVG(sd.UnitPrice) AS 'Selling Price',
                                          SUM(sd.TotalPrice) AS 'Total Sales',
                                          SUM(sd.Quantity * p.CostPrice) AS 'Total Cost',
                                          SUM(sd.TotalPrice - (sd.Quantity * p.CostPrice)) AS 'Profit',
                                          ROUND(((AVG(sd.UnitPrice) - p.CostPrice) / p.CostPrice * 100), 2) AS 'Profit %'
                                      FROM sale_details sd
                                      INNER JOIN sales s ON sd.SaleID = s.SaleID
                                      INNER JOIN products p ON sd.ProductID = p.ProductID
                                      WHERE DATE(s.SaleDate) BETWEEN @FromDate AND @ToDate
                                      GROUP BY sd.ProductID, sd.ProductName, p.CostPrice
                                      ORDER BY Profit DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvProfitReport.DataSource = dt
                FormatProfitGrid()
                CalculateProfitSummary(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading profit report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatProfitGrid()
        With dgvProfitReport
            If .Columns.Count > 0 Then
                .Columns("Cost Price").DefaultCellStyle.Format = "N2"
                .Columns("Selling Price").DefaultCellStyle.Format = "N2"
                .Columns("Total Sales").DefaultCellStyle.Format = "N2"
                .Columns("Total Cost").DefaultCellStyle.Format = "N2"
                .Columns("Profit").DefaultCellStyle.Format = "N2"
                .Columns("Profit %").DefaultCellStyle.Format = "N2"

                .Columns("Qty Sold").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cost Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Selling Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total Sales").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total Cost").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Profit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Profit %").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ' Highlight profitable items
                For Each row As DataGridViewRow In .Rows
                    If row.Cells("Profit").Value IsNot Nothing Then
                        Dim profit As Decimal = Convert.ToDecimal(row.Cells("Profit").Value)
                        If profit > 0 Then
                            row.Cells("Profit").Style.ForeColor = Color.Green
                            row.Cells("Profit").Style.Font = New Font(dgvProfitReport.Font, FontStyle.Bold)
                        ElseIf profit < 0 Then
                            row.Cells("Profit").Style.ForeColor = Color.Red
                        End If
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub CalculateProfitSummary(dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim totalSales As Decimal = 0
            Dim totalCost As Decimal = 0
            Dim totalProfit As Decimal = 0

            For Each row As DataRow In dt.Rows
                totalSales += Convert.ToDecimal(row("Total Sales"))
                totalCost += Convert.ToDecimal(row("Total Cost"))
                totalProfit += Convert.ToDecimal(row("Profit"))
            Next

            Dim profitPercent As Decimal = If(totalCost > 0, (totalProfit / totalCost) * 100, 0)

            lblProfitTotalSales.Text = $"₹ {totalSales:N2}"
            lblProfitTotalCost.Text = $"₹ {totalCost:N2}"
            lblProfitTotalProfit.Text = $"₹ {totalProfit:N2}"
            lblProfitPercent.Text = $"{profitPercent:N2}%"
        Else
            lblProfitTotalSales.Text = "₹ 0.00"
            lblProfitTotalCost.Text = "₹ 0.00"
            lblProfitTotalProfit.Text = "₹ 0.00"
            lblProfitPercent.Text = "0.00%"
        End If
    End Sub

    ' ============================================
    ' TAB 5: SUPPLIER PERFORMANCE REPORT
    ' ============================================

    Private Sub tabSupplier_Enter(sender As Object, e As EventArgs) Handles tabSupplier.Enter
        LoadSupplierReport()
    End Sub

    Private Sub btnLoadSupplierReport_Click(sender As Object, e As EventArgs) Handles btnLoadSupplierReport.Click
        LoadSupplierReport()
    End Sub

    Private Sub LoadSupplierReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          s.SupplierName AS 'Supplier',
                                          s.ContactPerson AS 'Contact Person',
                                          s.Phone,
                                          COUNT(p.PurchaseID) AS 'Total Purchases',
                                          SUM(p.NetAmount) AS 'Total Amount',
                                          SUM(p.PaidAmount) AS 'Total Paid',
                                          SUM(p.DueAmount) AS 'Total Due',
                                          AVG(p.NetAmount) AS 'Avg Purchase',
                                          DATE_FORMAT(MAX(p.PurchaseDate), '%d-%m-%Y') AS 'Last Purchase'
                                      FROM suppliers s
                                      LEFT JOIN purchases p ON s.SupplierID = p.SupplierID
                                      WHERE s.IsActive = TRUE
                                      GROUP BY s.SupplierID, s.SupplierName, s.ContactPerson, s.Phone
                                      ORDER BY SUM(p.NetAmount) DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvSupplierReport.DataSource = dt
                FormatSupplierGrid()
                CalculateSupplierSummary(dt)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading supplier report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatSupplierGrid()
        With dgvSupplierReport
            If .Columns.Count > 0 Then
                .Columns("Total Amount").DefaultCellStyle.Format = "N2"
                .Columns("Total Paid").DefaultCellStyle.Format = "N2"
                .Columns("Total Due").DefaultCellStyle.Format = "N2"
                .Columns("Avg Purchase").DefaultCellStyle.Format = "N2"

                .Columns("Total Purchases").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Total Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total Paid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Total Due").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Avg Purchase").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ' Highlight suppliers with due payments
                For Each row As DataGridViewRow In .Rows
                    If row.Cells("Total Due").Value IsNot Nothing Then
                        Dim dueAmount As Decimal = Convert.ToDecimal(row.Cells("Total Due").Value)
                        If dueAmount > 0 Then
                            row.Cells("Total Due").Style.BackColor = Color.LightCoral
                            row.Cells("Total Due").Style.Font = New Font(dgvSupplierReport.Font, FontStyle.Bold)
                        End If
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub CalculateSupplierSummary(dt As DataTable)
        If dt.Rows.Count > 0 Then
            Dim totalSuppliers As Integer = dt.Rows.Count
            Dim totalAmount As Decimal = 0
            Dim totalPaid As Decimal = 0
            Dim totalDue As Decimal = 0
            Dim totalPurchases As Integer = 0

            For Each row As DataRow In dt.Rows
                If row("Total Amount") IsNot DBNull.Value Then
                    totalAmount += Convert.ToDecimal(row("Total Amount"))
                End If
                If row("Total Paid") IsNot DBNull.Value Then
                    totalPaid += Convert.ToDecimal(row("Total Paid"))
                End If
                If row("Total Due") IsNot DBNull.Value Then
                    totalDue += Convert.ToDecimal(row("Total Due"))
                End If
                If row("Total Purchases") IsNot DBNull.Value Then
                    totalPurchases += Convert.ToInt32(row("Total Purchases"))
                End If
            Next

            lblSupplierCount.Text = totalSuppliers.ToString()
            lblSupplierTotalAmount.Text = $"₹ {totalAmount:N2}"
            lblSupplierTotalPaid.Text = $"₹ {totalPaid:N2}"
            lblSupplierTotalDue.Text = $"₹ {totalDue:N2}"
            lblSupplierTotalPurchases.Text = totalPurchases.ToString()
        Else
            lblSupplierCount.Text = "0"
            lblSupplierTotalAmount.Text = "₹ 0.00"
            lblSupplierTotalPaid.Text = "₹ 0.00"
            lblSupplierTotalDue.Text = "₹ 0.00"
            lblSupplierTotalPurchases.Text = "0"
        End If
    End Sub

    ' ============================================
    ' TAB 6: TOP SELLING PRODUCTS
    ' ============================================

    Private Sub tabTopProducts_Enter(sender As Object, e As EventArgs) Handles tabTopProducts.Enter
        LoadTopProducts()
    End Sub

    Private Sub btnLoadTopProducts_Click(sender As Object, e As EventArgs) Handles btnLoadTopProducts.Click
        LoadTopProducts()
    End Sub

    Private Sub LoadTopProducts()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          sd.ProductID AS 'Product ID',
                                          sd.ProductName AS 'Product Name',
                                          SUM(sd.Quantity) AS 'Total Qty Sold',
                                          SUM(sd.TotalPrice) AS 'Total Revenue',
                                          COUNT(DISTINCT sd.SaleID) AS 'No. of Sales',
                                          AVG(sd.UnitPrice) AS 'Avg Price'
                                      FROM sale_details sd
                                      INNER JOIN sales s ON sd.SaleID = s.SaleID
                                      WHERE DATE(s.SaleDate) BETWEEN @FromDate AND @ToDate
                                      GROUP BY sd.ProductID, sd.ProductName
                                      ORDER BY SUM(sd.Quantity) DESC
                                      LIMIT 50"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvTopProducts.DataSource = dt

                With dgvTopProducts
                    If .Columns.Count > 0 Then
                        .Columns("Total Revenue").DefaultCellStyle.Format = "N2"
                        .Columns("Avg Price").DefaultCellStyle.Format = "N2"
                        .Columns("Total Qty Sold").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns("Total Revenue").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("No. of Sales").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns("Avg Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                End With

                ' Calculate summary
                If dt.Rows.Count > 0 Then
                    Dim totalRevenue As Decimal = 0
                    For Each row As DataRow In dt.Rows
                        totalRevenue += Convert.ToDecimal(row("Total Revenue"))
                    Next
                    lblTopProductsRevenue.Text = $"Total Revenue: ₹ {totalRevenue:N2}"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading top products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================
    ' TAB 7: PAYMENT METHOD REPORT
    ' ============================================

    Private Sub tabPaymentMethod_Enter(sender As Object, e As EventArgs) Handles tabPaymentMethod.Enter
        LoadPaymentMethodReport()
    End Sub

    Private Sub btnLoadPaymentReport_Click(sender As Object, e As EventArgs) Handles btnLoadPaymentReport.Click
        LoadPaymentMethodReport()
    End Sub

    Private Sub LoadPaymentMethodReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          PaymentMethod AS 'Payment Method',
                                          COUNT(*) AS 'Transactions',
                                          SUM(NetAmount) AS 'Total Amount',
                                          AVG(NetAmount) AS 'Average Amount',
                                          MIN(NetAmount) AS 'Min Amount',
                                          MAX(NetAmount) AS 'Max Amount'
                                      FROM sales
                                      WHERE DATE(SaleDate) BETWEEN @FromDate AND @ToDate
                                      GROUP BY PaymentMethod
                                      ORDER BY SUM(NetAmount) DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvPaymentReport.DataSource = dt

                With dgvPaymentReport
                    If .Columns.Count > 0 Then
                        .Columns("Total Amount").DefaultCellStyle.Format = "N2"
                        .Columns("Average Amount").DefaultCellStyle.Format = "N2"
                        .Columns("Min Amount").DefaultCellStyle.Format = "N2"
                        .Columns("Max Amount").DefaultCellStyle.Format = "N2"

                        .Columns("Transactions").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns("Total Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Average Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Min Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Max Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                End With
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading payment report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================
    ' TAB 8: CATEGORY WISE SALES
    ' ============================================

    Private Sub tabCategorySales_Enter(sender As Object, e As EventArgs) Handles tabCategorySales.Enter
        LoadCategorySalesReport()
    End Sub

    Private Sub btnLoadCategoryReport_Click(sender As Object, e As EventArgs) Handles btnLoadCategoryReport.Click
        LoadCategorySalesReport()
    End Sub

    Private Sub LoadCategorySalesReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          c.CategoryName AS 'Category',
                                          COUNT(DISTINCT sd.SaleID) AS 'Transactions',
                                          SUM(sd.Quantity) AS 'Items Sold',
                                          SUM(sd.TotalPrice) AS 'Revenue',
                                          AVG(sd.UnitPrice) AS 'Avg Price'
                                      FROM sale_details sd
                                      INNER JOIN products p ON sd.ProductID = p.ProductID
                                      INNER JOIN categories c ON p.CategoryID = c.CategoryID
                                      INNER JOIN sales s ON sd.SaleID = s.SaleID
                                      WHERE DATE(s.SaleDate) BETWEEN @FromDate AND @ToDate
                                      GROUP BY c.CategoryName
                                      ORDER BY SUM(sd.TotalPrice) DESC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCategoryReport.DataSource = dt

                With dgvCategoryReport
                    If .Columns.Count > 0 Then
                        .Columns("Revenue").DefaultCellStyle.Format = "N2"
                        .Columns("Avg Price").DefaultCellStyle.Format = "N2"

                        .Columns("Transactions").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns("Items Sold").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns("Revenue").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns("Avg Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                End With
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading category report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============================================
    ' EXPORT FUNCTIONS
    ' ============================================

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportCurrentReport()
    End Sub

    Private Sub ExportCurrentReport()
        Try
            ' Get active tab's DataGridView
            Dim dgv As DataGridView = Nothing
            Dim reportName As String = ""

            Select Case TabControl1.SelectedIndex
                Case 0
                    dgv = dgvSalesReport
                    reportName = "Sales_Report"
                Case 1
                    dgv = dgvPurchaseReport
                    reportName = "Purchase_Report"
                Case 2
                    dgv = dgvStockReport
                    reportName = "Stock_Report"
                Case 3
                    dgv = dgvProfitReport
                    reportName = "Profit_Report"
                Case 4
                    dgv = dgvSupplierReport
                    reportName = "Supplier_Performance_Report"
                Case 5
                    dgv = dgvTopProducts
                    reportName = "Top_Products_Report"
                Case 6
                    dgv = dgvPaymentReport
                    reportName = "Payment_Method_Report"
                Case 7
                    dgv = dgvCategoryReport
                    reportName = "Category_Sales_Report"
            End Select

            If dgv Is Nothing OrElse dgv.Rows.Count = 0 Then
                MessageBox.Show("No data to export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Save file dialog
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            sfd.FileName = $"{reportName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                ExportDataGridViewToCSV(dgv, sfd.FileName)
                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Ask to open file
                If MessageBox.Show("Do you want to open the file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(sfd.FileName)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show($"Error exporting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportDataGridViewToCSV(dgv As DataGridView, filePath As String)
        Dim csv As New System.Text.StringBuilder()

        ' Add report title
        csv.AppendLine($"Report Generated: {DateTime.Now:dd-MM-yyyy HH:mm:ss}")
        csv.AppendLine($"Period: {dtpFromDate.Value:dd-MM-yyyy} to {dtpToDate.Value:dd-MM-yyyy}")
        csv.AppendLine()

        ' Add headers
        For i As Integer = 0 To dgv.Columns.Count - 1
            If dgv.Columns(i).Visible Then
                csv.Append(dgv.Columns(i).HeaderText)
                If i < dgv.Columns.Count - 1 Then
                    csv.Append(",")
                End If
            End If
        Next
        csv.AppendLine()

        ' Add rows
        For Each row As DataGridViewRow In dgv.Rows
            For i As Integer = 0 To dgv.Columns.Count - 1
                If dgv.Columns(i).Visible Then
                    Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString().Replace(",", ";"), "")
                    csv.Append(cellValue)
                    If i < dgv.Columns.Count - 1 Then
                        csv.Append(",")
                    End If
                End If
            Next
            csv.AppendLine()
        Next

        System.IO.File.WriteAllText(filePath, csv.ToString())
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MessageBox.Show("Print feature - To be implemented with Crystal Reports or reporting library", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class