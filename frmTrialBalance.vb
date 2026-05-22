Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class frmTrialBalance
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property CurrentUserID As Integer

    Private trialBalanceTable As DataTable

    Private Sub frmTrialBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupGrid()
            dtpAsOf.Value = DateTime.Today
            GenerateTrialBalance()
        Catch ex As Exception
            MessageBox.Show($"Error loading trial balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        With dgvTrialBalance
            .AutoGenerateColumns = False
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
        colDebit.DefaultCellStyle.Format = "N2"
        colCredit.DefaultCellStyle.Format = "N2"
        colDebit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colCredit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub GenerateTrialBalance()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT a.AccountCode, a.AccountName, a.AccountType, " &
                                    "COALESCE(SUM(CASE WHEN je.JournalID IS NOT NULL THEN jd.DebitAmount ELSE 0 END),0) AS TotalDebit, " &
                                    "COALESCE(SUM(CASE WHEN je.JournalID IS NOT NULL THEN jd.CreditAmount ELSE 0 END),0) AS TotalCredit " &
                                    "FROM accounts a " &
                                    "LEFT JOIN journal_details jd ON a.AccountID = jd.AccountID " &
                                    "LEFT JOIN journal_entries je ON jd.JournalID = je.JournalID AND DATE(je.EntryDate) <= @AsOf " &
                                    "WHERE a.IsActive = 1 " &
                                    "GROUP BY a.AccountID, a.AccountCode, a.AccountName, a.AccountType " &
                                    "ORDER BY a.AccountType, a.AccountCode"

                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@AsOf", dtpAsOf.Value.Date)
                Dim sourceTable As New DataTable()
                adapter.Fill(sourceTable)

                trialBalanceTable = New DataTable()
                trialBalanceTable.Columns.Add("AccountCode", GetType(String))
                trialBalanceTable.Columns.Add("AccountName", GetType(String))
                trialBalanceTable.Columns.Add("AccountType", GetType(String))
                trialBalanceTable.Columns.Add("Debit", GetType(Decimal))
                trialBalanceTable.Columns.Add("Credit", GetType(Decimal))

                Dim totalDebit As Decimal = 0D
                Dim totalCredit As Decimal = 0D

                For Each row As DataRow In sourceTable.Rows
                    Dim accountType As String = row("AccountType").ToString()
                    Dim rawDebit As Decimal = Convert.ToDecimal(row("TotalDebit"))
                    Dim rawCredit As Decimal = Convert.ToDecimal(row("TotalCredit"))
                    Dim displayDebit As Decimal = 0D
                    Dim displayCredit As Decimal = 0D

                    If accountType = "Asset" OrElse accountType = "Expense" Then
                        Dim balance As Decimal = rawDebit - rawCredit
                        If balance >= 0D Then
                            displayDebit = balance
                        Else
                            displayCredit = Math.Abs(balance)
                        End If
                    Else
                        Dim balance As Decimal = rawCredit - rawDebit
                        If balance >= 0D Then
                            displayCredit = balance
                        Else
                            displayDebit = Math.Abs(balance)
                        End If
                    End If

                    If displayDebit > 0D OrElse displayCredit > 0D Then
                        trialBalanceTable.Rows.Add(row("AccountCode").ToString(), row("AccountName").ToString(), accountType, displayDebit, displayCredit)
                        totalDebit += displayDebit
                        totalCredit += displayCredit
                    End If
                Next

                dgvTrialBalance.DataSource = trialBalanceTable
                ApplyRowColors()
                lblTotalDebit.Text = $"Total Debit: {totalDebit:N2}"
                lblTotalCredit.Text = $"Total Credit: {totalCredit:N2}"
                If Math.Round(totalDebit, 2) = Math.Round(totalCredit, 2) Then
                    lblBalanceCheck.Text = "✅ Balanced"
                    lblBalanceCheck.ForeColor = Color.DarkGreen
                Else
                    lblBalanceCheck.Text = "❌ Not Balanced"
                    lblBalanceCheck.ForeColor = Color.DarkRed
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error generating trial balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyRowColors()
        For Each row As DataGridViewRow In dgvTrialBalance.Rows
            If row.Cells("colAccountType").Value Is Nothing Then Continue For
            Select Case row.Cells("colAccountType").Value.ToString()
                Case "Asset"
                    row.DefaultCellStyle.BackColor = Color.LightBlue
                Case "Liability"
                    row.DefaultCellStyle.BackColor = Color.LightPink
                Case "Equity"
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                Case "Income"
                    row.DefaultCellStyle.BackColor = Color.LightYellow
                Case "Expense"
                    row.DefaultCellStyle.BackColor = Color.LightCoral
            End Select
        Next
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateTrialBalance()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvTrialBalance.Rows.Count = 0 Then
                MessageBox.Show("No trial balance data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV files (*.csv)|*.csv"
                sfd.FileName = $"TrialBalance_{dtpAsOf.Value:yyyyMMdd}.csv"
                If sfd.ShowDialog() <> DialogResult.OK Then Return

                Dim csv As New StringBuilder()
                For Each col As DataGridViewColumn In dgvTrialBalance.Columns
                    csv.Append(col.HeaderText & ",")
                Next
                csv.AppendLine()

                For Each row As DataGridViewRow In dgvTrialBalance.Rows
                    If row.IsNewRow Then Continue For
                    For Each col As DataGridViewColumn In dgvTrialBalance.Columns
                        csv.Append(If(row.Cells(col.Index).Value, "").ToString().Replace(",", ";") & ",")
                    Next
                    csv.AppendLine()
                Next

                File.WriteAllText(sfd.FileName, csv.ToString())
                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error exporting trial balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage,
                Sub(s, args)
                    Dim y As Integer = 25
                    args.Graphics.DrawString("Trial Balance", New Font("Segoe UI", 16, FontStyle.Bold), Brushes.Black, 30, y)
                    y += 30
                    args.Graphics.DrawString($"As Of: {dtpAsOf.Value:dd-MMM-yyyy}", New Font("Segoe UI", 10), Brushes.Black, 30, y)
                    y += 25
                    For Each line As String In {lblTotalDebit.Text, lblTotalCredit.Text, lblBalanceCheck.Text}
                        args.Graphics.DrawString(line, New Font("Segoe UI", 10), Brushes.Black, 30, y)
                        y += 20
                    Next
                End Sub
            Using preview As New PrintPreviewDialog()
                preview.Document = printDoc
                preview.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error printing trial balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
