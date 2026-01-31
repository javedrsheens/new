<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenses
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
        grpExpenseEntry = New GroupBox()
        btnCLEAR = New Button()
        btnDELETE = New Button()
        btnUPDATE = New Button()
        btnSave = New Button()
        txtAmount = New TextBox()
        txtDescription = New TextBox()
        btnManageCategories = New Button()
        cboPaymentMethod = New ComboBox()
        cboCategory = New ComboBox()
        dtpExpenseDate = New DateTimePicker()
        Label5 = New Label()
        Label4 = New Label()
        lblDescription = New Label()
        lblCategory = New Label()
        Label1 = New Label()
        grpFilter = New GroupBox()
        btnSearch = New Button()
        Label9 = New Label()
        btnExport = New Button()
        btnThisMonth = New Button()
        btnThisWeek = New Button()
        btnToday = New Button()
        dtpToDate = New DateTimePicker()
        dtpFromDate = New DateTimePicker()
        Label7 = New Label()
        Label8 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        lblTotalAmount = New Label()
        Label3 = New Label()
        Label2 = New Label()
        lblTotalExpenses = New Label()
        dgvExpenses = New DataGridView()
        GroupBox1 = New GroupBox()
        dgvCategorySummary = New DataGridView()
        btnClose = New Button()
        grpExpenseEntry.SuspendLayout()
        grpFilter.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dgvExpenses, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(dgvCategorySummary, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' grpExpenseEntry
        ' 
        grpExpenseEntry.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        grpExpenseEntry.Controls.Add(btnCLEAR)
        grpExpenseEntry.Controls.Add(btnDELETE)
        grpExpenseEntry.Controls.Add(btnUPDATE)
        grpExpenseEntry.Controls.Add(btnSave)
        grpExpenseEntry.Controls.Add(txtAmount)
        grpExpenseEntry.Controls.Add(txtDescription)
        grpExpenseEntry.Controls.Add(btnManageCategories)
        grpExpenseEntry.Controls.Add(cboPaymentMethod)
        grpExpenseEntry.Controls.Add(cboCategory)
        grpExpenseEntry.Controls.Add(dtpExpenseDate)
        grpExpenseEntry.Controls.Add(Label5)
        grpExpenseEntry.Controls.Add(Label4)
        grpExpenseEntry.Controls.Add(lblDescription)
        grpExpenseEntry.Controls.Add(lblCategory)
        grpExpenseEntry.Controls.Add(Label1)
        grpExpenseEntry.Location = New Point(0, 54)
        grpExpenseEntry.Name = "grpExpenseEntry"
        grpExpenseEntry.Size = New Size(380, 254)
        grpExpenseEntry.TabIndex = 0
        grpExpenseEntry.TabStop = False
        grpExpenseEntry.Text = "Add/Edit Expense"
        ' 
        ' btnCLEAR
        ' 
        btnCLEAR.Location = New Point(264, 200)
        btnCLEAR.Name = "btnCLEAR"
        btnCLEAR.Size = New Size(68, 48)
        btnCLEAR.TabIndex = 4
        btnCLEAR.Text = "🔄 Clear"
        btnCLEAR.UseVisualStyleBackColor = True
        ' 
        ' btnDELETE
        ' 
        btnDELETE.Location = New Point(179, 200)
        btnDELETE.Name = "btnDELETE"
        btnDELETE.Size = New Size(68, 48)
        btnDELETE.TabIndex = 4
        btnDELETE.Text = "🗑️ Delete"
        btnDELETE.UseVisualStyleBackColor = True
        ' 
        ' btnUPDATE
        ' 
        btnUPDATE.Location = New Point(96, 200)
        btnUPDATE.Name = "btnUPDATE"
        btnUPDATE.Size = New Size(68, 48)
        btnUPDATE.TabIndex = 4
        btnUPDATE.Text = "✏️ Update"
        btnUPDATE.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(6, 200)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(68, 48)
        btnSave.TabIndex = 4
        btnSave.Text = "💾 Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txtAmount
        ' 
        txtAmount.Location = New Point(101, 136)
        txtAmount.Name = "txtAmount"
        txtAmount.Size = New Size(254, 23)
        txtAmount.TabIndex = 3
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(101, 103)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(254, 23)
        txtDescription.TabIndex = 3
        ' 
        ' btnManageCategories
        ' 
        btnManageCategories.Location = New Point(285, 63)
        btnManageCategories.Name = "btnManageCategories"
        btnManageCategories.Size = New Size(65, 25)
        btnManageCategories.TabIndex = 2
        btnManageCategories.Text = "manage catgery"
        btnManageCategories.UseVisualStyleBackColor = True
        ' 
        ' cboPaymentMethod
        ' 
        cboPaymentMethod.FormattingEnabled = True
        cboPaymentMethod.Location = New Point(96, 169)
        cboPaymentMethod.Name = "cboPaymentMethod"
        cboPaymentMethod.Size = New Size(180, 23)
        cboPaymentMethod.TabIndex = 1
        ' 
        ' cboCategory
        ' 
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(100, 63)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(180, 23)
        cboCategory.TabIndex = 1
        ' 
        ' dtpExpenseDate
        ' 
        dtpExpenseDate.Location = New Point(100, 28)
        dtpExpenseDate.Name = "dtpExpenseDate"
        dtpExpenseDate.Size = New Size(250, 23)
        dtpExpenseDate.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(15, 169)
        Label5.Name = "Label5"
        Label5.Size = New Size(73, 20)
        Label5.TabIndex = 0
        Label5.Text = "Payment:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(0, 137)
        Label4.Name = "Label4"
        Label4.Size = New Size(99, 20)
        Label4.TabIndex = 0
        Label4.Text = "Amount (RS):"
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDescription.Location = New Point(0, 102)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(91, 20)
        lblDescription.TabIndex = 0
        lblDescription.Text = "Description:"
        ' 
        ' lblCategory
        ' 
        lblCategory.AutoSize = True
        lblCategory.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCategory.Location = New Point(9, 66)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(76, 20)
        lblCategory.TabIndex = 0
        lblCategory.Text = "Category:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(15, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(45, 20)
        Label1.TabIndex = 0
        Label1.Text = "Date:"
        ' 
        ' grpFilter
        ' 
        grpFilter.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        grpFilter.Controls.Add(btnSearch)
        grpFilter.Controls.Add(Label9)
        grpFilter.Controls.Add(btnExport)
        grpFilter.Controls.Add(btnThisMonth)
        grpFilter.Controls.Add(btnThisWeek)
        grpFilter.Controls.Add(btnToday)
        grpFilter.Controls.Add(dtpToDate)
        grpFilter.Controls.Add(dtpFromDate)
        grpFilter.Controls.Add(Label7)
        grpFilter.Controls.Add(Label8)
        grpFilter.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpFilter.Location = New Point(395, 58)
        grpFilter.Name = "grpFilter"
        grpFilter.Size = New Size(786, 136)
        grpFilter.TabIndex = 1
        grpFilter.TabStop = False
        grpFilter.Text = "Filter Expenses"
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(693, 11)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 61)
        btnSearch.TabIndex = 6
        btnSearch.Text = "🔍 Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(353, 29)
        Label9.Name = "Label9"
        Label9.Size = New Size(30, 21)
        Label9.TabIndex = 5
        Label9.Text = "TO"
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(547, 65)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(137, 49)
        btnExport.TabIndex = 4
        btnExport.Text = "📤 Export CSV"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnThisMonth
        ' 
        btnThisMonth.Location = New Point(396, 66)
        btnThisMonth.Name = "btnThisMonth"
        btnThisMonth.Size = New Size(137, 49)
        btnThisMonth.TabIndex = 4
        btnThisMonth.Text = "📅 This Month"
        btnThisMonth.UseVisualStyleBackColor = True
        ' 
        ' btnThisWeek
        ' 
        btnThisWeek.Location = New Point(246, 65)
        btnThisWeek.Name = "btnThisWeek"
        btnThisWeek.Size = New Size(137, 49)
        btnThisWeek.TabIndex = 4
        btnThisWeek.Text = "📆 This Week"
        btnThisWeek.UseVisualStyleBackColor = True
        ' 
        ' btnToday
        ' 
        btnToday.Location = New Point(99, 65)
        btnToday.Name = "btnToday"
        btnToday.Size = New Size(137, 49)
        btnToday.TabIndex = 4
        btnToday.Text = "📅 Today"
        btnToday.UseVisualStyleBackColor = True
        ' 
        ' dtpToDate
        ' 
        dtpToDate.Location = New Point(387, 25)
        dtpToDate.Name = "dtpToDate"
        dtpToDate.Size = New Size(300, 29)
        dtpToDate.TabIndex = 1
        ' 
        ' dtpFromDate
        ' 
        dtpFromDate.Location = New Point(66, 25)
        dtpFromDate.Name = "dtpFromDate"
        dtpFromDate.Size = New Size(284, 29)
        dtpFromDate.TabIndex = 1
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(9, 86)
        Label7.Name = "Label7"
        Label7.Size = New Size(87, 20)
        Label7.TabIndex = 0
        Label7.Text = "Quick Filter"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(15, 30)
        Label8.Name = "Label8"
        Label8.Size = New Size(45, 20)
        Label8.TabIndex = 0
        Label8.Text = "Date:"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveCaptionText
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1184, 55)
        Panel1.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSteelBlue
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(lblTotalAmount)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(lblTotalExpenses)
        Panel2.ForeColor = SystemColors.ControlLight
        Panel2.Location = New Point(0, 308)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(380, 80)
        Panel2.TabIndex = 3
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.AutoSize = True
        lblTotalAmount.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalAmount.ForeColor = Color.Red
        lblTotalAmount.Location = New Point(144, 38)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(23, 25)
        lblTotalAmount.TabIndex = 0
        lblTotalAmount.Text = "0"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(-1, 38)
        Label3.Name = "Label3"
        Label3.Size = New Size(118, 21)
        Label3.TabIndex = 0
        Label3.Text = "Total Amount:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(3, 2)
        Label2.Name = "Label2"
        Label2.Size = New Size(126, 21)
        Label2.TabIndex = 0
        Label2.Text = "Total Expenses:"
        ' 
        ' lblTotalExpenses
        ' 
        lblTotalExpenses.AutoSize = True
        lblTotalExpenses.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalExpenses.ForeColor = SystemColors.ActiveCaptionText
        lblTotalExpenses.Location = New Point(144, 2)
        lblTotalExpenses.Name = "lblTotalExpenses"
        lblTotalExpenses.Size = New Size(19, 21)
        lblTotalExpenses.TabIndex = 0
        lblTotalExpenses.Text = "0"
        ' 
        ' dgvExpenses
        ' 
        dgvExpenses.AllowUserToAddRows = False
        dgvExpenses.BackgroundColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        dgvExpenses.BorderStyle = BorderStyle.Fixed3D
        dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvExpenses.GridColor = Color.DarkGray
        dgvExpenses.Location = New Point(395, 200)
        dgvExpenses.Name = "dgvExpenses"
        dgvExpenses.ReadOnly = True
        dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvExpenses.Size = New Size(789, 178)
        dgvExpenses.TabIndex = 4
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(dgvCategorySummary)
        GroupBox1.Location = New Point(-2, 391)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(380, 160)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        GroupBox1.Text = "Category-wise Summary"
        ' 
        ' dgvCategorySummary
        ' 
        dgvCategorySummary.AllowUserToAddRows = False
        dgvCategorySummary.BackgroundColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        dgvCategorySummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCategorySummary.Location = New Point(11, 22)
        dgvCategorySummary.Name = "dgvCategorySummary"
        dgvCategorySummary.Size = New Size(360, 125)
        dgvCategorySummary.TabIndex = 0
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(1052, 651)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(111, 48)
        btnClose.TabIndex = 6
        btnClose.Text = "❌ Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmExpenses
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 711)
        Controls.Add(btnClose)
        Controls.Add(GroupBox1)
        Controls.Add(dgvExpenses)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(grpFilter)
        Controls.Add(grpExpenseEntry)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "frmExpenses"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmExpenses"
        grpExpenseEntry.ResumeLayout(False)
        grpExpenseEntry.PerformLayout()
        grpFilter.ResumeLayout(False)
        grpFilter.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(dgvExpenses, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        CType(dgvCategorySummary, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpExpenseEntry As GroupBox
    Friend WithEvents dtpExpenseDate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnManageCategories As Button
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents cboPaymentMethod As ComboBox
    Friend WithEvents btnCLEAR As Button
    Friend WithEvents btnDELETE As Button
    Friend WithEvents btnUPDATE As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents grpFilter As GroupBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnThisMonth As Button
    Friend WithEvents btnThisWeek As Button
    Friend WithEvents btnToday As Button
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotalExpenses As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvExpenses As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvCategorySummary As DataGridView
    Friend WithEvents btnClose As Button
End Class
