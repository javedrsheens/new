<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountLedger
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
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
        btnSearch = New Button()
        dtpToDate = New DateTimePicker()
        dtpFromDate = New DateTimePicker()
        cboAccount = New ComboBox()
        lblToDate = New Label()
        lblFromDate = New Label()
        lblAccount = New Label()
        dgvLedger = New DataGridView()
        grpSummary = New GroupBox()
        lblClosingBalance = New Label()
        lblTotalCredit = New Label()
        lblTotalDebit = New Label()
        lblOpeningBalance = New Label()
        grpFilters.SuspendLayout()
        CType(dgvLedger, ComponentModel.ISupportInitialize).BeginInit()
        grpSummary.SuspendLayout()
        SuspendLayout()
        grpFilters.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpFilters.Controls.Add(btnClose)
        grpFilters.Controls.Add(btnPrint)
        grpFilters.Controls.Add(btnExport)
        grpFilters.Controls.Add(btnSearch)
        grpFilters.Controls.Add(dtpToDate)
        grpFilters.Controls.Add(dtpFromDate)
        grpFilters.Controls.Add(cboAccount)
        grpFilters.Controls.Add(lblToDate)
        grpFilters.Controls.Add(lblFromDate)
        grpFilters.Controls.Add(lblAccount)
        grpFilters.Location = New Point(12, 12)
        grpFilters.Size = New Size(1006, 90)
        grpFilters.Text = "Ledger Filters"
        lblAccount.AutoSize = True
        lblAccount.Location = New Point(18, 28)
        lblAccount.Text = "Account"
        cboAccount.DropDownStyle = ComboBoxStyle.DropDownList
        cboAccount.Location = New Point(72, 24)
        cboAccount.Size = New Size(280, 23)
        lblFromDate.AutoSize = True
        lblFromDate.Location = New Point(370, 28)
        lblFromDate.Text = "From"
        dtpFromDate.Format = DateTimePickerFormat.Short
        dtpFromDate.Location = New Point(410, 24)
        lblToDate.AutoSize = True
        lblToDate.Location = New Point(562, 28)
        lblToDate.Text = "To"
        dtpToDate.Format = DateTimePickerFormat.Short
        dtpToDate.Location = New Point(590, 24)
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSearch.Location = New Point(18, 54)
        btnSearch.Size = New Size(90, 28)
        btnSearch.Text = "Search"
        btnExport.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnExport.Location = New Point(754, 35)
        btnExport.Size = New Size(80, 32)
        btnExport.Text = "Export"
        btnPrint.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnPrint.Location = New Point(842, 35)
        btnPrint.Size = New Size(80, 32)
        btnPrint.Text = "Print"
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(930, 35)
        btnClose.Size = New Size(60, 32)
        btnClose.Text = "Close"
        dgvLedger.AllowUserToAddRows = False
        dgvLedger.BackgroundColor = Color.White
        dgvLedger.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLedger.Location = New Point(12, 114)
        dgvLedger.ReadOnly = True
        dgvLedger.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvLedger.Size = New Size(1006, 395)
        grpSummary.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpSummary.Controls.Add(lblClosingBalance)
        grpSummary.Controls.Add(lblTotalCredit)
        grpSummary.Controls.Add(lblTotalDebit)
        grpSummary.Controls.Add(lblOpeningBalance)
        grpSummary.Location = New Point(12, 520)
        grpSummary.Size = New Size(1006, 80)
        grpSummary.Text = "Summary"
        lblOpeningBalance.AutoSize = True
        lblOpeningBalance.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblOpeningBalance.Location = New Point(20, 34)
        lblOpeningBalance.Text = "Opening Balance: 0.00"
        lblTotalDebit.AutoSize = True
        lblTotalDebit.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblTotalDebit.Location = New Point(290, 34)
        lblTotalDebit.Text = "Total Debit: 0.00"
        lblTotalCredit.AutoSize = True
        lblTotalCredit.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblTotalCredit.Location = New Point(520, 34)
        lblTotalCredit.Text = "Total Credit: 0.00"
        lblClosingBalance.AutoSize = True
        lblClosingBalance.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
        lblClosingBalance.Location = New Point(750, 34)
        lblClosingBalance.Text = "Closing Balance: 0.00"
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1030, 612)
        Controls.Add(grpSummary)
        Controls.Add(dgvLedger)
        Controls.Add(grpFilters)
        Font = New Font("Segoe UI", 9F)
        Name = "frmAccountLedger"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Account Ledger"
        grpFilters.ResumeLayout(False)
        grpFilters.PerformLayout()
        CType(dgvLedger, ComponentModel.ISupportInitialize).EndInit()
        grpSummary.ResumeLayout(False)
        grpSummary.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents cboAccount As ComboBox
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblFromDate As Label
    Friend WithEvents lblAccount As Label
    Friend WithEvents dgvLedger As DataGridView
    Friend WithEvents grpSummary As GroupBox
    Friend WithEvents lblClosingBalance As Label
    Friend WithEvents lblTotalCredit As Label
    Friend WithEvents lblTotalDebit As Label
    Friend WithEvents lblOpeningBalance As Label
End Class
