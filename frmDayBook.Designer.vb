<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDayBook
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        GroupBox1 = New GroupBox()
        cboTransactionType = New ComboBox()
        btnToday = New Button()
        btnThisMonth = New Button()
        btnThisWeek = New Button()
        btnYesterday = New Button()
        btnPrint = New Button()
        btnExport = New Button()
        btnShowAll = New Button()
        btnSearch = New Button()
        dtpToDate = New DateTimePicker()
        dtpFromDate = New DateTimePicker()
        lblToDate = New Label()
        lblTransType = New Label()
        lblFromDate = New Label()
        Panel1 = New Panel()
        Label1 = New Label()
        lblOpeningBalance = New Label()
        panelSummary = New Panel()
        btnClose = New Button()
        lblClosingBalance = New Label()
        lblTotalCredit = New Label()
        lblTotalDebit = New Label()
        Label4 = New Label()
        Label2 = New Label()
        lblTotal = New Label()
        Panel3 = New Panel()
        dgvDayBook = New DataGridView()
        GroupBox1.SuspendLayout()
        Panel1.SuspendLayout()
        panelSummary.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvDayBook, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.LightBlue
        GroupBox1.Controls.Add(cboTransactionType)
        GroupBox1.Controls.Add(btnToday)
        GroupBox1.Controls.Add(btnThisMonth)
        GroupBox1.Controls.Add(btnThisWeek)
        GroupBox1.Controls.Add(btnYesterday)
        GroupBox1.Controls.Add(btnPrint)
        GroupBox1.Controls.Add(btnExport)
        GroupBox1.Controls.Add(btnShowAll)
        GroupBox1.Controls.Add(btnSearch)
        GroupBox1.Controls.Add(dtpToDate)
        GroupBox1.Controls.Add(dtpFromDate)
        GroupBox1.Controls.Add(lblToDate)
        GroupBox1.Controls.Add(lblTransType)
        GroupBox1.Controls.Add(lblFromDate)
        GroupBox1.Location = New Point(10, 10)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1170, 120)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        ' 
        ' cboTransactionType
        ' 
        cboTransactionType.DropDownStyle = ComboBoxStyle.DropDownList
        cboTransactionType.FormattingEnabled = True
        cboTransactionType.Location = New Point(660, 61)
        cboTransactionType.Name = "cboTransactionType"
        cboTransactionType.Size = New Size(121, 23)
        cboTransactionType.TabIndex = 3
        ' 
        ' btnToday
        ' 
        btnToday.Location = New Point(59, 60)
        btnToday.Name = "btnToday"
        btnToday.Size = New Size(75, 23)
        btnToday.TabIndex = 2
        btnToday.Text = "📅 Today"
        btnToday.UseVisualStyleBackColor = True
        ' 
        ' btnThisMonth
        ' 
        btnThisMonth.Location = New Point(383, 60)
        btnThisMonth.Name = "btnThisMonth"
        btnThisMonth.Size = New Size(75, 23)
        btnThisMonth.TabIndex = 2
        btnThisMonth.Text = "ThisMonth"
        btnThisMonth.UseVisualStyleBackColor = True
        ' 
        ' btnThisWeek
        ' 
        btnThisWeek.Location = New Point(281, 60)
        btnThisWeek.Name = "btnThisWeek"
        btnThisWeek.Size = New Size(75, 23)
        btnThisWeek.TabIndex = 2
        btnThisWeek.Text = "ThisWeek"
        btnThisWeek.UseVisualStyleBackColor = True
        ' 
        ' btnYesterday
        ' 
        btnYesterday.Location = New Point(179, 60)
        btnYesterday.Name = "btnYesterday"
        btnYesterday.Size = New Size(75, 23)
        btnYesterday.TabIndex = 2
        btnYesterday.Text = "Yesterday"
        btnYesterday.UseVisualStyleBackColor = True
        ' 
        ' btnPrint
        ' 
        btnPrint.Location = New Point(1076, 83)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(75, 23)
        btnPrint.TabIndex = 2
        btnPrint.Text = "🖨️ Print"
        btnPrint.UseVisualStyleBackColor = True
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(995, 83)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(75, 23)
        btnExport.TabIndex = 2
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnShowAll
        ' 
        btnShowAll.Location = New Point(914, 83)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(75, 23)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(660, 22)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dtpToDate
        ' 
        dtpToDate.Format = DateTimePickerFormat.Short
        dtpToDate.Location = New Point(417, 19)
        dtpToDate.Name = "dtpToDate"
        dtpToDate.Size = New Size(200, 23)
        dtpToDate.TabIndex = 1
        ' 
        ' dtpFromDate
        ' 
        dtpFromDate.Format = DateTimePickerFormat.Short
        dtpFromDate.Location = New Point(108, 19)
        dtpFromDate.Name = "dtpFromDate"
        dtpFromDate.Size = New Size(200, 23)
        dtpFromDate.TabIndex = 1
        ' 
        ' lblToDate
        ' 
        lblToDate.AutoSize = True
        lblToDate.Location = New Point(356, 19)
        lblToDate.Name = "lblToDate"
        lblToDate.Size = New Size(43, 15)
        lblToDate.TabIndex = 0
        lblToDate.Text = "ToDate"
        ' 
        ' lblTransType
        ' 
        lblTransType.AutoSize = True
        lblTransType.Location = New Point(581, 69)
        lblTransType.Name = "lblTransType"
        lblTransType.Size = New Size(58, 15)
        lblTransType.TabIndex = 0
        lblTransType.Text = "TransType"
        ' 
        ' lblFromDate
        ' 
        lblFromDate.AutoSize = True
        lblFromDate.Location = New Point(37, 19)
        lblFromDate.Name = "lblFromDate"
        lblFromDate.Size = New Size(59, 15)
        lblFromDate.TabIndex = 0
        lblFromDate.Text = "FromDate"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblOpeningBalance)
        Panel1.Location = New Point(10, 140)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1170, 47)
        Panel1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(59, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(134, 15)
        Label1.TabIndex = 0
        Label1.Text = """Cash Opening Balance:"
        ' 
        ' lblOpeningBalance
        ' 
        lblOpeningBalance.AutoSize = True
        lblOpeningBalance.Location = New Point(247, 14)
        lblOpeningBalance.Name = "lblOpeningBalance"
        lblOpeningBalance.Size = New Size(182, 15)
        lblOpeningBalance.TabIndex = 0
        lblOpeningBalance.Text = """Cash Opening Balance: RS: 0.00"""
        ' 
        ' panelSummary
        ' 
        panelSummary.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        panelSummary.Controls.Add(btnClose)
        panelSummary.Controls.Add(lblClosingBalance)
        panelSummary.Controls.Add(lblTotalCredit)
        panelSummary.Controls.Add(lblTotalDebit)
        panelSummary.Controls.Add(Label4)
        panelSummary.Controls.Add(Label2)
        panelSummary.Controls.Add(lblTotal)
        panelSummary.Dock = DockStyle.Bottom
        panelSummary.Location = New Point(0, 587)
        panelSummary.Name = "panelSummary"
        panelSummary.Size = New Size(1184, 74)
        panelSummary.TabIndex = 2
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(1097, 25)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(75, 23)
        btnClose.TabIndex = 1
        btnClose.Text = "❌ Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblClosingBalance
        ' 
        lblClosingBalance.AutoSize = True
        lblClosingBalance.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblClosingBalance.Location = New Point(561, 23)
        lblClosingBalance.Name = "lblClosingBalance"
        lblClosingBalance.Size = New Size(41, 21)
        lblClosingBalance.TabIndex = 0
        lblClosingBalance.Text = "0.00"
        ' 
        ' lblTotalCredit
        ' 
        lblTotalCredit.AutoSize = True
        lblTotalCredit.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblTotalCredit.Location = New Point(368, 23)
        lblTotalCredit.Name = "lblTotalCredit"
        lblTotalCredit.Size = New Size(41, 21)
        lblTotalCredit.TabIndex = 0
        lblTotalCredit.Text = "0.00"
        ' 
        ' lblTotalDebit
        ' 
        lblTotalDebit.AutoSize = True
        lblTotalDebit.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblTotalDebit.Location = New Point(118, 23)
        lblTotalDebit.Name = "lblTotalDebit"
        lblTotalDebit.Size = New Size(41, 21)
        lblTotalDebit.TabIndex = 0
        lblTotalDebit.Text = "0.00"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label4.Location = New Point(427, 23)
        Label4.Name = "Label4"
        Label4.Size = New Size(128, 21)
        Label4.TabIndex = 0
        Label4.Text = "Closing Balance:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label2.Location = New Point(225, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 21)
        Label2.TabIndex = 0
        Label2.Text = "Total Credit"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblTotal.Location = New Point(21, 24)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(85, 21)
        lblTotal.TabIndex = 0
        lblTotal.Text = "TotalDebit"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(dgvDayBook)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 193)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1184, 394)
        Panel3.TabIndex = 3
        ' 
        ' dgvDayBook
        ' 
        dgvDayBook.BackgroundColor = Color.White
        dgvDayBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDayBook.Dock = DockStyle.Fill
        dgvDayBook.Location = New Point(0, 0)
        dgvDayBook.Name = "dgvDayBook"
        dgvDayBook.Size = New Size(1184, 394)
        dgvDayBook.TabIndex = 0
        ' 
        ' frmDayBook
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1184, 661)
        Controls.Add(Panel3)
        Controls.Add(panelSummary)
        Controls.Add(Panel1)
        Controls.Add(GroupBox1)
        Name = "frmDayBook"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Day Book - Daily Transactions"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        panelSummary.ResumeLayout(False)
        panelSummary.PerformLayout()
        Panel3.ResumeLayout(False)
        CType(dgvDayBook, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents lblFromDate As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents btnToday As Button
    Friend WithEvents btnYesterday As Button
    Friend WithEvents btnThisMonth As Button
    Friend WithEvents btnThisWeek As Button
    Friend WithEvents lblTransType As Label
    Friend WithEvents cboTransactionType As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblOpeningBalance As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents panelSummary As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dgvDayBook As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents lblClosingBalance As Label
    Friend WithEvents lblTotalCredit As Label
    Friend WithEvents lblTotalDebit As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotal As Label
End Class
