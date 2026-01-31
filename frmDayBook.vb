Imports MySql.Data.MySqlClient

Public Class frmDayBook
    Private connectionString As String = "Server=localhost;Database=posdb;Uid=root;Pwd=Ayyaan@8941;"

    Private Sub frmDayBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadTransactionTypes()

        ' Set default dates
        dtpFromDate.Value = DateTime.Now.Date
        dtpToDate.Value = DateTime.Now.Date

        LoadDayBook()
    End Sub

    Private Sub SetupDataGridView()
        With dgvDayBook
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .BackgroundColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        End With
    End Sub

    Private Sub LoadTransactionTypes()
        cboTransactionType.Items.Clear()
        cboTransactionType.Items.AddRange(New String() {
            "All Types",
            "Sales",
            "Purchase",
            "Expense",
            "Receipt",
            "Payment"
        })
        cboTransactionType.SelectedIndex = 0
    End Sub

    Private Sub LoadDayBook()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Calculate opening balance from previous transactions
                Dim openingBalance As Decimal = CalculateOpeningBalance(conn)
                lblOpeningBalance.Text = $"Opening Balance: ₹ {openingBalance:N2}"

                ' Build query based on filters
                Dim query As String = "SELECT 
                                          DATE_FORMAT(TransactionDate, '%d-%m-%Y') AS 'Date',
                                          DATE_FORMAT(TransactionDate, '%h:%i %p') AS 'Time',
                                          TransactionType AS 'Type',
                                          CONCAT(Description, 
                                                 CASE 
                                                    WHEN ReferenceNo IS NOT NULL 
                                                    THEN CONCAT(' - ', ReferenceNo) 
                                                    ELSE '' 
                                                 END) AS 'Description',
                                          COALESCE(DebitAmount, 0) AS 'Debit',
                                          COALESCE(CreditAmount, 0) AS 'Credit',
                                          PaymentMethod AS 'Payment'
                                      FROM daybook
                                      WHERE DATE(TransactionDate) BETWEEN @FromDate AND @ToDate "

                ' Add transaction type filter
                If cboTransactionType.SelectedIndex > 0 Then
                    query &= " AND TransactionType = @TransType"
                End If

                query &= " ORDER BY TransactionDate ASC, DayBookID ASC"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)
                adapter.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date)

                If cboTransactionType.SelectedIndex > 0 Then
                    adapter.SelectCommand.Parameters.AddWithValue("@TransType", cboTransactionType.Text)
                End If

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvDayBook.DataSource = dt
                FormatGrid()
                CalculateSummary(dt, openingBalance)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading day book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CalculateOpeningBalance(conn As MySqlConnection) As Decimal
        Try
            ' Calculate opening balance from all previous transactions before the selected date
            Dim query As String = "SELECT 
                                      COALESCE(SUM(DebitAmount), 0) - COALESCE(SUM(CreditAmount), 0) AS Balance
                                  FROM daybook
                                  WHERE DATE(TransactionDate) < @FromDate"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date)

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToDecimal(result)
            End If

            Return 0
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub FormatGrid()
        With dgvDayBook
            If .Columns.Count > 0 Then
                .Columns("Date").Width = 100
                .Columns("Time").Width = 80
                .Columns("Type").Width = 100
                .Columns("Description").Width = 350
                .Columns("Debit").Width = 120
                .Columns("Credit").Width = 120
                .Columns("Payment").Width = 100

                ' Format amounts
                .Columns("Debit").DefaultCellStyle.Format = "N2"
                .Columns("Credit").DefaultCellStyle.Format = "N2"
                .Columns("Debit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Credit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                ' Color code transaction types
                For Each row As DataGridViewRow In .Rows
                    If row.Cells("Type").Value IsNot Nothing Then
                        Select Case row.Cells("Type").Value.ToString()
                            Case "Sales"
                                row.Cells("Debit").Style.ForeColor = Color.Green
                                row.Cells("Debit").Style.Font = New Font(dgvDayBook.Font, FontStyle.Bold)
                            Case "Purchase"
                                row.Cells("Credit").Style.ForeColor = Color.Blue
                            Case "Expense"
                                row.Cells("Credit").Style.ForeColor = Color.Red
                        End Select
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub CalculateSummary(dt As DataTable, openingBalance As Decimal)
        Dim totalDebit As Decimal = 0
        Dim totalCredit As Decimal = 0

        For Each row As DataRow In dt.Rows
            totalDebit += Convert.ToDecimal(row("Debit"))
            totalCredit += Convert.ToDecimal(row("Credit"))
        Next

        Dim closingBalance As Decimal = openingBalance + totalDebit - totalCredit

        lblTotalDebit.Text = $"Total Debit: ₹ {totalDebit:N2}"
        lblTotalDebit.Font = New Font(lblTotalDebit.Font, FontStyle.Bold)
        lblTotalDebit.ForeColor = Color.Green

        lblTotalCredit.Text = $"Total Credit: ₹ {totalCredit:N2}"
        lblTotalCredit.Font = New Font(lblTotalCredit.Font, FontStyle.Bold)
        lblTotalCredit.ForeColor = Color.Red

        lblClosingBalance.Text = $"Closing Balance: ₹ {closingBalance:N2}"
        lblClosingBalance.Font = New Font(lblClosingBalance.Font.FontFamily, 14, FontStyle.Bold)
        lblClosingBalance.ForeColor = If(closingBalance >= 0, Color.DarkGreen, Color.DarkRed)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadDayBook()
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        dtpFromDate.Value = DateTime.Now.Date
        dtpToDate.Value = DateTime.Now.Date
        LoadDayBook()
    End Sub

    Private Sub btnYesterday_Click(sender As Object, e As EventArgs) Handles btnYesterday.Click
        dtpFromDate.Value = DateTime.Now.AddDays(-1).Date
        dtpToDate.Value = DateTime.Now.AddDays(-1).Date
        LoadDayBook()
    End Sub

    Private Sub btnThisWeek_Click(sender As Object, e As EventArgs) Handles btnThisWeek.Click
        dtpFromDate.Value = DateTime.Now.AddDays(-7).Date
        dtpToDate.Value = DateTime.Now.Date
        LoadDayBook()
    End Sub

    Private Sub btnThisMonth_Click(sender As Object, e As EventArgs) Handles btnThisMonth.Click
        dtpFromDate.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpToDate.Value = DateTime.Now.Date
        LoadDayBook()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        cboTransactionType.SelectedIndex = 0
        LoadDayBook()
    End Sub

    Private Sub cboTransactionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTransactionType.SelectedIndexChanged
        If cboTransactionType.SelectedIndex >= 0 Then
            LoadDayBook()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToCSV()
    End Sub

    Private Sub ExportToCSV()
        Try
            If dgvDayBook.Rows.Count = 0 Then
                MessageBox.Show("No data to export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            sfd.FileName = $"DayBook_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim csv As New System.Text.StringBuilder()

                ' Add header info
                csv.AppendLine("Day Book Report")
                csv.AppendLine($"Period: {dtpFromDate.Value:dd-MM-yyyy} to {dtpToDate.Value:dd-MM-yyyy}")
                csv.AppendLine($"Generated: {DateTime.Now:dd-MM-yyyy HH:mm: ss}")
                csv.AppendLine()
                csv.AppendLine(lblOpeningBalance.Text)
                csv.AppendLine()

                ' Add column headers
                For i As Integer = 0 To dgvDayBook.Columns.Count - 1
                    csv.Append(dgvDayBook.Columns(i).HeaderText)
                    If i < dgvDayBook.Columns.Count - 1 Then csv.Append(",")
                Next
                csv.AppendLine()

                ' Add rows
                For Each row As DataGridViewRow In dgvDayBook.Rows
                    For i As Integer = 0 To dgvDayBook.Columns.Count - 1
                        Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing,
                                                     row.Cells(i).Value.ToString().Replace(",", ";"), "")
                        csv.Append(cellValue)
                        If i < dgvDayBook.Columns.Count - 1 Then csv.Append(",")
                    Next
                    csv.AppendLine()
                Next

                ' Add summary
                csv.AppendLine()
                csv.AppendLine(lblTotalDebit.Text)
                csv.AppendLine(lblTotalCredit.Text)
                csv.AppendLine(lblClosingBalance.Text)

                System.IO.File.WriteAllText(sfd.FileName, csv.ToString())

                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If MessageBox.Show("Do you want to open the file? ", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(sfd.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintDayBook()
    End Sub

    Private Sub PrintDayBook()
        Try
            Dim printDoc As New Printing.PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintPage

            Dim printPreview As New PrintPreviewDialog()
            printPreview.Document = printDoc
            printPreview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show($"Error printing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        Dim titleFont As New Font("Arial", 16, FontStyle.Bold)
        Dim headerFont As New Font("Arial", 12, FontStyle.Bold)
        Dim normalFont As New Font("Arial", 10)
        Dim smallFont As New Font("Arial", 8)
        Dim blackBrush As New SolidBrush(Color.Black)

        Dim yPos As Integer = 50
        Dim leftMargin As Integer = 50

        ' Print title
        e.Graphics.DrawString("Day Book Report", titleFont, blackBrush, leftMargin, yPos)
        yPos += 40

        ' Print date range
        e.Graphics.DrawString($"Period: {dtpFromDate.Value:dd-MM-yyyy} to {dtpToDate.Value:dd-MM-yyyy}",
                            normalFont, blackBrush, leftMargin, yPos)
        yPos += 25

        ' Print opening balance
        e.Graphics.DrawString(lblOpeningBalance.Text, normalFont, blackBrush, leftMargin, yPos)
        yPos += 40

        ' Print column headers
        e.Graphics.DrawString("Date", headerFont, blackBrush, leftMargin, yPos)
        e.Graphics.DrawString("Time", headerFont, blackBrush, leftMargin + 80, yPos)
        e.Graphics.DrawString("Type", headerFont, blackBrush, leftMargin + 140, yPos)
        e.Graphics.DrawString("Description", headerFont, blackBrush, leftMargin + 220, yPos)
        e.Graphics.DrawString("Debit", headerFont, blackBrush, leftMargin + 450, yPos)
        e.Graphics.DrawString("Credit", headerFont, blackBrush, leftMargin + 550, yPos)
        yPos += 25

        e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, 750, yPos)
        yPos += 10

        ' Print data rows
        For Each row As DataGridViewRow In dgvDayBook.Rows
            If yPos > 950 Then Exit For

            e.Graphics.DrawString(row.Cells("Date").Value.ToString(), smallFont, blackBrush, leftMargin, yPos)
            e.Graphics.DrawString(row.Cells("Time").Value.ToString(), smallFont, blackBrush, leftMargin + 80, yPos)
            e.Graphics.DrawString(row.Cells("Type").Value.ToString(), smallFont, blackBrush, leftMargin + 140, yPos)

            Dim desc As String = row.Cells("Description").Value.ToString()
            If desc.Length > 30 Then desc = desc.Substring(0, 30) & "..."
            e.Graphics.DrawString(desc, smallFont, blackBrush, leftMargin + 220, yPos)

            e.Graphics.DrawString(Convert.ToDecimal(row.Cells("Debit").Value).ToString("N2"),
                                smallFont, blackBrush, leftMargin + 450, yPos)
            e.Graphics.DrawString(Convert.ToDecimal(row.Cells("Credit").Value).ToString("N2"),
                                smallFont, blackBrush, leftMargin + 550, yPos)

            yPos += 20
        Next

        ' Print summary
        yPos += 20
        e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, 750, yPos)
        yPos += 15

        e.Graphics.DrawString(lblTotalDebit.Text, headerFont, blackBrush, leftMargin, yPos)
        yPos += 25
        e.Graphics.DrawString(lblTotalCredit.Text, headerFont, blackBrush, leftMargin, yPos)
        yPos += 25
        e.Graphics.DrawString(lblClosingBalance.Text, headerFont, blackBrush, leftMargin, yPos)

        e.Graphics.DrawString($"Printed on:  {DateTime.Now:dd-MM-yyyy HH:mm:ss}",
                            smallFont, blackBrush, leftMargin, 1050)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvDayBook_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDayBook.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvDayBook.Rows(e.RowIndex)
            Dim details As String = $"Transaction Details:{vbCrLf}{vbCrLf}" &
                                  $"Date: {row.Cells("Date").Value}{vbCrLf}" &
                                  $"Time: {row.Cells("Time").Value}{vbCrLf}" &
                                  $"Type: {row.Cells("Type").Value}{vbCrLf}" &
                                  $"Description: {row.Cells("Description").Value}{vbCrLf}" &
                                  $"Debit: ₹ {Convert.ToDecimal(row.Cells("Debit").Value):N2}{vbCrLf}" &
                                  $"Credit: ₹ {Convert.ToDecimal(row.Cells("Credit").Value):N2}{vbCrLf}" &
                                  $"Payment Method: {row.Cells("Payment").Value}"

            MessageBox.Show(details, "Transaction Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class