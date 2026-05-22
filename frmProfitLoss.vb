Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class frmProfitLoss
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer

    Private Sub frmProfitLoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Today
        GenerateReport()
    End Sub

    Private Sub GenerateReport()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim salesIncome As Decimal = GetScalar(conn, "SELECT COALESCE(SUM(NetAmount),0) FROM sales WHERE DATE(SaleDate) BETWEEN @FromDate AND @ToDate")
                Dim purchaseCost As Decimal = GetScalar(conn, "SELECT COALESCE(SUM(pi.Amount),0) FROM purchase_items pi INNER JOIN purchases p ON pi.PurchaseID=p.PurchaseID WHERE DATE(p.PurchaseDate) BETWEEN @FromDate AND @ToDate")
                Dim grossProfit As Decimal = salesIncome - purchaseCost
                Dim expenseTable As New DataTable()
                Dim expenseAdapter As New MySqlDataAdapter("SELECT IFNULL(ec.CategoryName, CONCAT('Category #', e.ExpenseCategoryID)) AS CategoryName, COALESCE(SUM(e.Amount),0) AS Amount FROM expenses e LEFT JOIN expense_categories ec ON e.ExpenseCategoryID = ec.ExpenseCategoryID WHERE DATE(e.ExpenseDate) BETWEEN @FromDate AND @ToDate GROUP BY IFNULL(ec.CategoryName, CONCAT('Category #', e.ExpenseCategoryID)) ORDER BY Amount DESC", conn)
                expenseAdapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                expenseAdapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)
                expenseAdapter.Fill(expenseTable)
                Dim totalExpenses As Decimal = 0D
                For Each row As DataRow In expenseTable.Rows
                    totalExpenses += Convert.ToDecimal(row("Amount"))
                Next
                Dim netProfit As Decimal = grossProfit - totalExpenses
                Dim reportTable As New DataTable()
                reportTable.Columns.Add("Particular", GetType(String))
                reportTable.Columns.Add("Amount", GetType(Decimal))
                reportTable.Rows.Add("SALES INCOME", salesIncome)
                reportTable.Rows.Add("LESS: Purchase Cost (COGS)", purchaseCost)
                reportTable.Rows.Add("GROSS PROFIT", grossProfit)
                reportTable.Rows.Add("LESS: Expenses", 0D)
                For Each row As DataRow In expenseTable.Rows
                    reportTable.Rows.Add("   " & row("CategoryName").ToString(), Convert.ToDecimal(row("Amount")))
                Next
                reportTable.Rows.Add("TOTAL EXPENSES", totalExpenses)
                reportTable.Rows.Add("NET PROFIT", netProfit)
                dgvProfitLoss.DataSource = reportTable
                If dgvProfitLoss.Columns.Contains("Amount") Then
                    dgvProfitLoss.Columns("Amount").DefaultCellStyle.Format = "N2"
                    dgvProfitLoss.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvProfitLoss.Columns("Amount").Width = 150
                End If
                If dgvProfitLoss.Columns.Contains("Particular") Then dgvProfitLoss.Columns("Particular").Width = 650
                lblGrossProfit.Text = $"Gross Profit: {grossProfit:N2}"
                lblTotalExpenses.Text = $"Total Expenses: {totalExpenses:N2}"
                lblNetProfit.Text = $"Net Profit: {netProfit:N2}"
                lblNetProfit.ForeColor = If(netProfit >= 0D, Color.DarkGreen, Color.DarkRed)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error generating profit && loss report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetScalar(conn As MySqlConnection, sql As String) As Decimal
        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
            cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)
            Return Convert.ToDecimal(cmd.ExecuteScalar())
        End Using
    End Function

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateReport()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvProfitLoss.Rows.Count = 0 Then Return
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = $"ProfitLoss_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Return
            Dim csv As New StringBuilder()
            For Each col As DataGridViewColumn In dgvProfitLoss.Columns
                csv.Append(col.HeaderText & ",")
            Next
            csv.AppendLine()
            For Each row As DataGridViewRow In dgvProfitLoss.Rows
                For Each col As DataGridViewColumn In dgvProfitLoss.Columns
                    csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                Next
                csv.AppendLine()
            Next
            File.WriteAllText(sfd.FileName, csv.ToString())
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error exporting report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage,
                Sub(s, args)
                    Dim y As Integer = 25
                    args.Graphics.DrawString("Profit && Loss Report", New Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, 30, y)
                    y += 35
                    args.Graphics.DrawString($"Period: {dtpFromDate.Value:dd-MMM-yyyy} to {dtpToDate.Value:dd-MMM-yyyy}", New Font("Segoe UI", 10), Brushes.Black, 30, y)
                    y += 35
                    For Each row As DataGridViewRow In dgvProfitLoss.Rows
                        If y > 1000 Then Exit For
                        args.Graphics.DrawString(If(row.Cells(0).Value, "").ToString(), New Font("Segoe UI", 9), Brushes.Black, 30, y)
                        args.Graphics.DrawString(If(row.Cells(1).Value, "").ToString(), New Font("Segoe UI", 9), Brushes.Black, 650, y)
                        y += 22
                    Next
                End Sub
            Dim preview As New PrintPreviewDialog()
            preview.Document = printDoc
            preview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show($"Error printing report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
