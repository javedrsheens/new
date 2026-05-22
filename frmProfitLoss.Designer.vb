<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfitLoss
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
        btnPrintPreview = New Button()
        btnExport = New Button()
        btnGenerate = New Button()
        dtpToDate = New DateTimePicker()
        dtpFromDate = New DateTimePicker()
        lblToDate = New Label()
        lblFromDate = New Label()
        dgvProfitLoss = New DataGridView()
        grpSummary = New GroupBox()
        lblNetProfit = New Label()
        lblTotalExpenses = New Label()
        lblGrossProfit = New Label()
        grpFilters.SuspendLayout()
        CType(dgvProfitLoss, ComponentModel.ISupportInitialize).BeginInit()
        grpSummary.SuspendLayout()
        SuspendLayout()
        grpFilters.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpFilters.Controls.Add(btnClose)
        grpFilters.Controls.Add(btnPrintPreview)
        grpFilters.Controls.Add(btnExport)
        grpFilters.Controls.Add(btnGenerate)
        grpFilters.Controls.Add(dtpToDate)
        grpFilters.Controls.Add(dtpFromDate)
        grpFilters.Controls.Add(lblToDate)
        grpFilters.Controls.Add(lblFromDate)
        grpFilters.Location = New Point(12, 12)
        grpFilters.Size = New Size(860, 88)
        grpFilters.Text = "Report Filters"
        lblFromDate.AutoSize = True
        lblFromDate.Location = New Point(22, 28)
        lblFromDate.Text = "From Date"
        dtpFromDate.Format = DateTimePickerFormat.Short
        dtpFromDate.Location = New Point(90, 24)
        lblToDate.AutoSize = True
        lblToDate.Location = New Point(250, 28)
        lblToDate.Text = "To Date"
        dtpToDate.Format = DateTimePickerFormat.Short
        dtpToDate.Location = New Point(302, 24)
        btnGenerate.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnGenerate.Location = New Point(22, 52)
        btnGenerate.Size = New Size(90, 28)
        btnGenerate.Text = "Generate"
        btnExport.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnExport.Location = New Point(596, 28)
        btnExport.Size = New Size(80, 32)
        btnExport.Text = "Export CSV"
        btnPrintPreview.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnPrintPreview.Location = New Point(686, 28)
        btnPrintPreview.Size = New Size(90, 32)
        btnPrintPreview.Text = "Print Preview"
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(786, 28)
        btnClose.Size = New Size(60, 32)
        btnClose.Text = "Close"
        dgvProfitLoss.AllowUserToAddRows = False
        dgvProfitLoss.BackgroundColor = Color.White
        dgvProfitLoss.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProfitLoss.Location = New Point(12, 112)
        dgvProfitLoss.ReadOnly = True
        dgvProfitLoss.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProfitLoss.Size = New Size(860, 330)
        grpSummary.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpSummary.Controls.Add(lblNetProfit)
        grpSummary.Controls.Add(lblTotalExpenses)
        grpSummary.Controls.Add(lblGrossProfit)
        grpSummary.Location = New Point(12, 454)
        grpSummary.Size = New Size(860, 82)
        grpSummary.Text = "Summary"
        lblGrossProfit.AutoSize = True
        lblGrossProfit.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblGrossProfit.ForeColor = Color.DarkBlue
        lblGrossProfit.Location = New Point(20, 34)
        lblGrossProfit.Text = "Gross Profit: 0.00"
        lblTotalExpenses.AutoSize = True
        lblTotalExpenses.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTotalExpenses.ForeColor = Color.DarkRed
        lblTotalExpenses.Location = New Point(310, 34)
        lblTotalExpenses.Text = "Total Expenses: 0.00"
        lblNetProfit.AutoSize = True
        lblNetProfit.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblNetProfit.ForeColor = Color.DarkGreen
        lblNetProfit.Location = New Point(610, 34)
        lblNetProfit.Text = "Net Profit: 0.00"
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(884, 548)
        Controls.Add(grpSummary)
        Controls.Add(dgvProfitLoss)
        Controls.Add(grpFilters)
        Font = New Font("Segoe UI", 9F)
        Name = "frmProfitLoss"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Profit && Loss"
        grpFilters.ResumeLayout(False)
        grpFilters.PerformLayout()
        CType(dgvProfitLoss, ComponentModel.ISupportInitialize).EndInit()
        grpSummary.ResumeLayout(False)
        grpSummary.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnGenerate As Button
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblFromDate As Label
    Friend WithEvents dgvProfitLoss As DataGridView
    Friend WithEvents grpSummary As GroupBox
    Friend WithEvents lblNetProfit As Label
    Friend WithEvents lblTotalExpenses As Label
    Friend WithEvents lblGrossProfit As Label
End Class
