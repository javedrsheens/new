Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class frmAccountLedger
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer

    Private Sub frmAccountLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Today
        SetupGrid()
        LoadAccounts()
        LoadLedger()
    End Sub

    Private Sub SetupGrid()
        With dgvLedger
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

    Private Sub LoadAccounts()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim adapter As New MySqlDataAdapter("SELECT AccountID, CONCAT(AccountCode, ' - ', AccountName) AS AccountDisplay FROM accounts WHERE IsActive = 1 ORDER BY AccountCode", conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                cboAccount.DataSource = dt
                cboAccount.DisplayMember = "AccountDisplay"
                cboAccount.ValueMember = "AccountID"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLedger()
        If cboAccount.SelectedValue Is Nothing Then Return
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim accountID As Integer = Convert.ToInt32(cboAccount.SelectedValue)
                Dim openingBalance As Decimal = 0D
                Using openingCmd As New MySqlCommand("SELECT COALESCE(OpeningBalance, 0) FROM accounts WHERE AccountID=@AccountID", conn)
                    openingCmd.Parameters.AddWithValue("@AccountID", accountID)
                    openingBalance = Convert.ToDecimal(openingCmd.ExecuteScalar())
                End Using
                Using priorCmd As New MySqlCommand("SELECT COALESCE(SUM(DebitAmount - CreditAmount),0) FROM journal_details jd INNER JOIN journal_entries je ON jd.JournalID=je.JournalID WHERE jd.AccountID=@AccountID AND DATE(je.EntryDate) < @FromDate", conn)
                    priorCmd.Parameters.AddWithValue("@AccountID", accountID)
                    priorCmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                    openingBalance += Convert.ToDecimal(priorCmd.ExecuteScalar())
                End Using
                Dim sql As String = "SELECT DATE_FORMAT(je.EntryDate,'%d-%m-%Y') AS 'Date', je.JournalID, je.Description, jd.DebitAmount AS 'Debit', jd.CreditAmount AS 'Credit' FROM journal_details jd INNER JOIN journal_entries je ON jd.JournalID=je.JournalID WHERE jd.AccountID=@AccountID AND DATE(je.EntryDate) BETWEEN @FromDate AND @ToDate ORDER BY je.EntryDate, je.JournalID, jd.DetailID"
                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@AccountID", accountID)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dt.Columns.Add("Balance", GetType(Decimal))
                Dim runningBalance = openingBalance
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
                dgvLedger.DataSource = dt
                For Each name As String In {"Debit", "Credit", "Balance"}
                    If dgvLedger.Columns.Contains(name) Then
                        dgvLedger.Columns(name).DefaultCellStyle.Format = "N2"
                        dgvLedger.Columns(name).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                Next
                If dgvLedger.Columns.Contains("Description") Then dgvLedger.Columns("Description").Width = 400
                lblOpeningBalance.Text = $"Opening Balance: {openingBalance:N2}"
                lblTotalDebit.Text = $"Total Debit: {totalDebit:N2}"
                lblTotalCredit.Text = $"Total Credit: {totalCredit:N2}"
                lblClosingBalance.Text = $"Closing Balance: {runningBalance:N2}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading ledger: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadLedger()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvLedger.Rows.Count = 0 Then Return
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = $"Ledger_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            If sfd.ShowDialog() <> DialogResult.OK Then Return
            Dim csv As New StringBuilder()
            For Each col As DataGridViewColumn In dgvLedger.Columns
                csv.Append(col.HeaderText & ",")
            Next
            csv.AppendLine()
            For Each row As DataGridViewRow In dgvLedger.Rows
                For Each col As DataGridViewColumn In dgvLedger.Columns
                    csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                Next
                csv.AppendLine()
            Next
            File.WriteAllText(sfd.FileName, csv.ToString())
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error exporting ledger: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage,
                Sub(s, args)
                    Dim y As Integer = 25
                    args.Graphics.DrawString("Account Ledger", New Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, 30, y)
                    y += 35
                    For Each line As String In {lblOpeningBalance.Text, lblTotalDebit.Text, lblTotalCredit.Text, lblClosingBalance.Text}
                        args.Graphics.DrawString(line, New Font("Segoe UI", 10), Brushes.Black, 30, y)
                        y += 22
                    Next
                End Sub
            Dim preview As New PrintPreviewDialog()
            preview.Document = printDoc
            preview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show($"Error printing ledger: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
