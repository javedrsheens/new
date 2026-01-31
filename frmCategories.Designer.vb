<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategories
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
        grpCategoryDetails = New GroupBox()
        btnClear = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        btnSave = New Button()
        chkActive = New CheckBox()
        txtDescription = New TextBox()
        txtCategoryName = New TextBox()
        lblDescription = New Label()
        lblRequired = New Label()
        lblCategoryIDValue = New Label()
        lblCategoryName = New Label()
        lblCategoryID = New Label()
        grpCategoryList = New GroupBox()
        dgvCategories = New DataGridView()
        lblTotalCategories = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnExport = New Button()
        btnShowAll = New Button()
        btnSearch = New Button()
        btnClose = New Button()
        grpCategoryDetails.SuspendLayout()
        grpCategoryList.SuspendLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' grpCategoryDetails
        ' 
        grpCategoryDetails.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpCategoryDetails.Controls.Add(btnClear)
        grpCategoryDetails.Controls.Add(btnDelete)
        grpCategoryDetails.Controls.Add(btnUpdate)
        grpCategoryDetails.Controls.Add(btnSave)
        grpCategoryDetails.Controls.Add(chkActive)
        grpCategoryDetails.Controls.Add(txtDescription)
        grpCategoryDetails.Controls.Add(txtCategoryName)
        grpCategoryDetails.Controls.Add(lblDescription)
        grpCategoryDetails.Controls.Add(lblRequired)
        grpCategoryDetails.Controls.Add(lblCategoryIDValue)
        grpCategoryDetails.Controls.Add(lblCategoryName)
        grpCategoryDetails.Controls.Add(lblCategoryID)
        grpCategoryDetails.Location = New Point(10, 10)
        grpCategoryDetails.Name = "grpCategoryDetails"
        grpCategoryDetails.Size = New Size(870, 220)
        grpCategoryDetails.TabIndex = 0
        grpCategoryDetails.TabStop = False
        grpCategoryDetails.Text = "Category Details"
        ' 
        ' btnClear
        ' 
        btnClear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClear.Location = New Point(435, 174)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 32)
        btnClear.TabIndex = 3
        btnClear.Text = "btnClear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(324, 174)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 32)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(220, 174)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(80, 32)
        btnUpdate.TabIndex = 3
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(111, 174)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(80, 32)
        btnSave.TabIndex = 3
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Checked = True
        chkActive.CheckState = CheckState.Checked
        chkActive.Location = New Point(324, 118)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(69, 19)
        chkActive.TabIndex = 2
        chkActive.Text = """Active"""
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(136, 114)
        txtDescription.MaxLength = 100
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(164, 23)
        txtDescription.TabIndex = 1
        ' 
        ' txtCategoryName
        ' 
        txtCategoryName.Location = New Point(136, 69)
        txtCategoryName.MaxLength = 100
        txtCategoryName.Name = "txtCategoryName"
        txtCategoryName.Size = New Size(164, 23)
        txtCategoryName.TabIndex = 1
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.BackColor = Color.Transparent
        lblDescription.Location = New Point(46, 117)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(67, 15)
        lblDescription.TabIndex = 0
        lblDescription.Text = "Description"
        ' 
        ' lblRequired
        ' 
        lblRequired.AutoSize = True
        lblRequired.BackColor = Color.Gray
        lblRequired.Location = New Point(324, 72)
        lblRequired.Name = "lblRequired"
        lblRequired.Size = New Size(12, 15)
        lblRequired.TabIndex = 0
        lblRequired.Text = "*"
        ' 
        ' lblCategoryIDValue
        ' 
        lblCategoryIDValue.AutoSize = True
        lblCategoryIDValue.BackColor = Color.Gray
        lblCategoryIDValue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCategoryIDValue.Location = New Point(136, 29)
        lblCategoryIDValue.Name = "lblCategoryIDValue"
        lblCategoryIDValue.Size = New Size(41, 21)
        lblCategoryIDValue.TabIndex = 0
        lblCategoryIDValue.Text = "0.00"
        ' 
        ' lblCategoryName
        ' 
        lblCategoryName.AutoSize = True
        lblCategoryName.Location = New Point(26, 77)
        lblCategoryName.Name = "lblCategoryName"
        lblCategoryName.Size = New Size(87, 15)
        lblCategoryName.TabIndex = 0
        lblCategoryName.Text = "CategoryName"
        ' 
        ' lblCategoryID
        ' 
        lblCategoryID.AutoSize = True
        lblCategoryID.Location = New Point(47, 29)
        lblCategoryID.Name = "lblCategoryID"
        lblCategoryID.Size = New Size(66, 15)
        lblCategoryID.TabIndex = 0
        lblCategoryID.Text = "CategoryID"
        ' 
        ' grpCategoryList
        ' 
        grpCategoryList.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpCategoryList.Controls.Add(dgvCategories)
        grpCategoryList.Controls.Add(lblTotalCategories)
        grpCategoryList.Controls.Add(lblSearch)
        grpCategoryList.Controls.Add(txtSearch)
        grpCategoryList.Controls.Add(btnExport)
        grpCategoryList.Controls.Add(btnShowAll)
        grpCategoryList.Controls.Add(btnSearch)
        grpCategoryList.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpCategoryList.Location = New Point(10, 240)
        grpCategoryList.Name = "grpCategoryList"
        grpCategoryList.Size = New Size(870, 340)
        grpCategoryList.TabIndex = 1
        grpCategoryList.TabStop = False
        grpCategoryList.Text = "Categories List"
        ' 
        ' dgvCategories
        ' 
        dgvCategories.AllowUserToAddRows = False
        dgvCategories.BackgroundColor = Color.White
        dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCategories.Location = New Point(20, 95)
        dgvCategories.Name = "dgvCategories"
        dgvCategories.ReadOnly = True
        dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCategories.Size = New Size(830, 230)
        dgvCategories.TabIndex = 4
        ' 
        ' lblTotalCategories
        ' 
        lblTotalCategories.AutoSize = True
        lblTotalCategories.BackColor = Color.Gray
        lblTotalCategories.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalCategories.Location = New Point(372, 39)
        lblTotalCategories.Name = "lblTotalCategories"
        lblTotalCategories.Size = New Size(50, 25)
        lblTotalCategories.TabIndex = 0
        lblTotalCategories.Text = "0.00"
        ' 
        ' lblSearch
        ' 
        lblSearch.AutoSize = True
        lblSearch.BackColor = Color.Gray
        lblSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSearch.Location = New Point(26, 44)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(55, 20)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(111, 39)
        txtSearch.MaxLength = 100
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(230, 25)
        txtSearch.TabIndex = 1
        ' 
        ' btnExport
        ' 
        btnExport.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.Location = New Point(755, 34)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(80, 32)
        btnExport.TabIndex = 3
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnShowAll
        ' 
        btnShowAll.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnShowAll.Location = New Point(655, 34)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(80, 32)
        btnShowAll.TabIndex = 3
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearch.Location = New Point(555, 34)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(80, 32)
        btnSearch.TabIndex = 3
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Location = New Point(406, 571)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(80, 32)
        btnClose.TabIndex = 3
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' frmCategories
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(884, 611)
        Controls.Add(grpCategoryList)
        Controls.Add(grpCategoryDetails)
        Controls.Add(btnClose)
        Name = "frmCategories"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Category Management"
        grpCategoryDetails.ResumeLayout(False)
        grpCategoryDetails.PerformLayout()
        grpCategoryList.ResumeLayout(False)
        grpCategoryList.PerformLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpCategoryDetails As GroupBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtCategoryName As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblRequired As Label
    Friend WithEvents lblCategoryIDValue As Label
    Friend WithEvents lblCategoryName As Label
    Friend WithEvents lblCategoryID As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents grpCategoryList As GroupBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblTotalCategories As Label
    Friend WithEvents dgvCategories As DataGridView
    Friend WithEvents btnClose As Button
End Class
