Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class frmCASHBOOK
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer

    Private Sub frmCASHBOOK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboType.Items.AddRange(New String() {"All Types", "Sales", "Purchase", "Expense", "Receipt", "Payment", "Journal"})
        cboType.SelectedIndex = 0
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Today
        SetupGrid()
        LoadCashBook()
    End Sub

    Private Sub SetupGrid()
        With dgvCashBook
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        End With
    End Sub

    Private Sub LoadCashBook()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim openingBalance As Decimal = 0D
                Dim openingSql As String = "SELECT COALESCE(SUM(jd.DebitAmount - jd.CreditAmount),0) + COALESCE(MAX(a.OpeningBalance),0) FROM journal_details jd INNER JOIN journal_entries je ON jd.JournalID=je.JournalID INNER JOIN accounts a ON jd.AccountID=a.AccountID WHERE a.AccountName='Cash In Hand' AND DATE(je.EntryDate) < @FromDate"
                Using openCmd As New MySqlCommand(openingSql, conn)
                    openCmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                    openingBalance = Convert.ToDecimal(openCmd.ExecuteScalar())
                End Using

                Dim sql As New StringBuilder()
                sql.AppendLine("SELECT DATE_FORMAT(je.EntryDate, '%d-%m-%Y') AS 'Date',")
                sql.AppendLine("       je.Description AS 'Description',")
                sql.AppendLine("       CONCAT(je.ReferenceType, '-', je.ReferenceID) AS 'Voucher#',")
                sql.AppendLine("       jd.DebitAmount AS 'Debit',")
                sql.AppendLine("       jd.CreditAmount AS 'Credit'")
                sql.AppendLine("FROM journal_details jd")
                sql.AppendLine("INNER JOIN journal_entries je ON jd.JournalID = je.JournalID")
                sql.AppendLine("INNER JOIN accounts a ON jd.AccountID = a.AccountID")
                sql.AppendLine("WHERE a.AccountName = 'Cash In Hand'")
                sql.AppendLine("  AND DATE(je.EntryDate) BETWEEN @FromDate AND @ToDate")
                If cboType.SelectedIndex > 0 Then
                    sql.AppendLine("  AND je.ReferenceType = @ReferenceType")
                End If
                sql.AppendLine("ORDER BY je.EntryDate, je.JournalID, jd.DetailID")

                Dim adapter As New MySqlDataAdapter(sql.ToString(), conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)
                If cboType.SelectedIndex > 0 Then
                    adapter.SelectCommand.Parameters.AddWithValue("@ReferenceType", cboType.Text)
                End If

                Dim dt As New DataTable()
                adapter.Fill(dt)
                If Not dt.Columns.Contains("Balance") Then dt.Columns.Add("Balance", GetType(Decimal))

                Dim runningBalance As Decimal = openingBalance
                Dim totalDebit As Decimal = 0D
                Dim totalCredit As Decimal = 0D
                For Each row As DataRow In dt.Rows
                    Dim debit = Convert.ToDecimal(row("Debit"))
                    Dim credit = Convert.ToDecimal(row("Credit"))
                    runningBalance += debit - credit
                    row("Balance") = runningBalance
                    totalDebit += debit
                    totalCredit += credit
                Next

                dgvCashBook.DataSource = dt
                FormatGrid()
                lblOpeningBalance.Text = $"Opening Balance: {openingBalance:N2}"
                lblTotalCashIn.Text = $"Total Cash In: {totalDebit:N2}"
                lblTotalCashOut.Text = $"Total Cash Out: {totalCredit:N2}"
                lblClosingBalance.Text = $"Closing Balance: {runningBalance:N2}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading cash book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        For Each name As String In {"Debit", "Credit", "Balance"}
            If dgvCashBook.Columns.Contains(name) Then
                dgvCashBook.Columns(name).DefaultCellStyle.Format = "N2"
                dgvCashBook.Columns(name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        If dgvCashBook.Columns.Contains("Description") Then dgvCashBook.Columns("Description").Width = 360
        If dgvCashBook.Columns.Contains("Voucher#") Then dgvCashBook.Columns("Voucher#").Width = 140
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadCashBook()
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        dtpFromDate.Value = DateTime.Today
        dtpToDate.Value = DateTime.Today
        LoadCashBook()
    End Sub

    Private Sub btnThisMonth_Click(sender As Object, e As EventArgs) Handles btnThisMonth.Click
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Today
        LoadCashBook()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvCashBook.Rows.Count = 0 Then Return
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = $"CashBook_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Return
            Dim csv As New StringBuilder()
            For Each col As DataGridViewColumn In dgvCashBook.Columns
                csv.Append(col.HeaderText & ",")
            Next
            csv.AppendLine()
            For Each row As DataGridViewRow In dgvCashBook.Rows
                For Each col As DataGridViewColumn In dgvCashBook.Columns
                    csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                Next
                csv.AppendLine()
            Next
            File.WriteAllText(sfd.FileName, csv.ToString())
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error exporting cash book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage,
                Sub(s, args)
                    Dim y As Integer = 25
                    args.Graphics.DrawString("Cash Book Report", New Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, 30, y)
                    y += 35
                    For Each line As String In {lblOpeningBalance.Text, lblTotalCashIn.Text, lblTotalCashOut.Text, lblClosingBalance.Text}
                        args.Graphics.DrawString(line, New Font("Segoe UI", 10), Brushes.Black, 30, y)
                        y += 22
                    Next
                End Sub
            Dim preview As New PrintPreviewDialog()
            preview.Document = printDoc
            preview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show($"Error printing cash book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
