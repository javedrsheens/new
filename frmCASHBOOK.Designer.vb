<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCASHBOOK
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        grpFilters = New GroupBox()
        btnClose = New Button()
        btnPrint = New Button()
        btnExport = New Button()
        btnThisMonth = New Button()
        btnToday = New Button()
        btnSearch = New Button()
        cboType = New ComboBox()
        lblType = New Label()
        dtpToDate = New DateTimePicker()
        dtpFromDate = New DateTimePicker()
        lblToDate = New Label()
        lblFromDate = New Label()
        dgvCashBook = New DataGridView()
        grpSummary = New GroupBox()
        lblClosingBalance = New Label()
        lblTotalCashOut = New Label()
        lblTotalCashIn = New Label()
        lblOpeningBalance = New Label()
        grpFilters.SuspendLayout()
        CType(dgvCashBook, ComponentModel.ISupportInitialize).BeginInit()
        grpSummary.SuspendLayout()
        SuspendLayout()
        grpFilters.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpFilters.Controls.Add(btnClose)
        grpFilters.Controls.Add(btnPrint)
        grpFilters.Controls.Add(btnExport)
        grpFilters.Controls.Add(btnThisMonth)
        grpFilters.Controls.Add(btnToday)
        grpFilters.Controls.Add(btnSearch)
        grpFilters.Controls.Add(cboType)
        grpFilters.Controls.Add(lblType)
        grpFilters.Controls.Add(dtpToDate)
        grpFilters.Controls.Add(dtpFromDate)
        grpFilters.Controls.Add(lblToDate)
        grpFilters.Controls.Add(lblFromDate)
        grpFilters.Location = New Point(12, 12)
        grpFilters.Name = "grpFilters"
        grpFilters.Size = New Size(1020, 90)
        grpFilters.TabIndex = 0
        grpFilters.TabStop = False
        grpFilters.Text = "Filters"
        lblFromDate.AutoSize = True
        lblFromDate.Location = New Point(18, 27)
        lblFromDate.Text = "From Date"
        dtpFromDate.Format = DateTimePickerFormat.Short
        dtpFromDate.Location = New Point(86, 23)
        lblToDate.AutoSize = True
        lblToDate.Location = New Point(230, 27)
        lblToDate.Text = "To Date"
        dtpToDate.Format = DateTimePickerFormat.Short
        dtpToDate.Location = New Point(285, 23)
        lblType.AutoSize = True
        lblType.Location = New Point(432, 27)
        lblType.Text = "Type"
        cboType.DropDownStyle = ComboBoxStyle.DropDownList
        cboType.Location = New Point(468, 23)
        cboType.Size = New Size(140, 23)
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSearch.Location = New Point(18, 52)
        btnSearch.Size = New Size(90, 28)
        btnSearch.Text = "Search"
        btnToday.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnToday.Location = New Point(118, 52)
        btnToday.Size = New Size(90, 28)
        btnToday.Text = "Today"
        btnThisMonth.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnThisMonth.Location = New Point(218, 52)
        btnThisMonth.Size = New Size(100, 28)
        btnThisMonth.Text = "This Month"
        btnExport.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnExport.Location = New Point(760, 35)
        btnExport.Size = New Size(80, 32)
        btnExport.Text = "Export"
        btnPrint.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnPrint.Location = New Point(850, 35)
        btnPrint.Size = New Size(80, 32)
        btnPrint.Text = "Print"
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(940, 35)
        btnClose.Size = New Size(70, 32)
        btnClose.Text = "Close"
        dgvCashBook.AllowUserToAddRows = False
        dgvCashBook.BackgroundColor = Color.White
        dgvCashBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCashBook.Location = New Point(12, 114)
        dgvCashBook.Name = "dgvCashBook"
        dgvCashBook.ReadOnly = True
        dgvCashBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCashBook.Size = New Size(1020, 395)
        grpSummary.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpSummary.Controls.Add(lblClosingBalance)
        grpSummary.Controls.Add(lblTotalCashOut)
        grpSummary.Controls.Add(lblTotalCashIn)
        grpSummary.Controls.Add(lblOpeningBalance)
        grpSummary.Location = New Point(12, 520)
        grpSummary.Name = "grpSummary"
        grpSummary.Size = New Size(1020, 80)
        grpSummary.TabIndex = 2
        grpSummary.TabStop = False
        grpSummary.Text = "Summary"
        lblOpeningBalance.AutoSize = True
        lblOpeningBalance.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblOpeningBalance.Location = New Point(20, 34)
        lblOpeningBalance.Text = "Opening Balance: 0.00"
        lblTotalCashIn.AutoSize = True
        lblTotalCashIn.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblTotalCashIn.Location = New Point(280, 34)
        lblTotalCashIn.Text = "Total Cash In: 0.00"
        lblTotalCashOut.AutoSize = True
        lblTotalCashOut.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblTotalCashOut.Location = New Point(520, 34)
        lblTotalCashOut.Text = "Total Cash Out: 0.00"
        lblClosingBalance.AutoSize = True
        lblClosingBalance.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblClosingBalance.Location = New Point(770, 34)
        lblClosingBalance.Text = "Closing Balance: 0.00"
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1046, 612)
        Controls.Add(grpSummary)
        Controls.Add(dgvCashBook)
        Controls.Add(grpFilters)
        Font = New Font("Segoe UI", 9F)
        Name = "frmCASHBOOK"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Cash Book"
        grpFilters.ResumeLayout(False)
        grpFilters.PerformLayout()
        CType(dgvCashBook, ComponentModel.ISupportInitialize).EndInit()
        grpSummary.ResumeLayout(False)
        grpSummary.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnThisMonth As Button
    Friend WithEvents btnToday As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents cboType As ComboBox
    Friend WithEvents lblType As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblFromDate As Label
    Friend WithEvents dgvCashBook As DataGridView
    Friend WithEvents grpSummary As GroupBox
    Friend WithEvents lblClosingBalance As Label
    Friend WithEvents lblTotalCashOut As Label
    Friend WithEvents lblTotalCashIn As Label
    Friend WithEvents lblOpeningBalance As Label
End Class
