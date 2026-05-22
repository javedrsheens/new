<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubcategories
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
        grpSubcategoryDetails = New GroupBox()
        btnClear = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        btnSave = New Button()
        chkActive = New CheckBox()
        txtDescription = New TextBox()
        txtSubcategoryName = New TextBox()
        cboCategory = New ComboBox()
        lblDescription = New Label()
        lblRequired = New Label()
        lblSubcategoryIDValue = New Label()
        lblSubcategoryName = New Label()
        lblCategory = New Label()
        lblSubcategoryID = New Label()
        grpSubcategoryList = New GroupBox()
        dgvSubcategories = New DataGridView()
        lblTotalSubcategories = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnExport = New Button()
        btnShowAll = New Button()
        btnSearch = New Button()
        btnClose = New Button()
        grpSubcategoryDetails.SuspendLayout()
        grpSubcategoryList.SuspendLayout()
        CType(dgvSubcategories, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'grpSubcategoryDetails
        '
        grpSubcategoryDetails.BackColor = Color.White
        grpSubcategoryDetails.Controls.Add(btnClear)
        grpSubcategoryDetails.Controls.Add(btnDelete)
        grpSubcategoryDetails.Controls.Add(btnUpdate)
        grpSubcategoryDetails.Controls.Add(btnSave)
        grpSubcategoryDetails.Controls.Add(chkActive)
        grpSubcategoryDetails.Controls.Add(txtDescription)
        grpSubcategoryDetails.Controls.Add(txtSubcategoryName)
        grpSubcategoryDetails.Controls.Add(cboCategory)
        grpSubcategoryDetails.Controls.Add(lblDescription)
        grpSubcategoryDetails.Controls.Add(lblRequired)
        grpSubcategoryDetails.Controls.Add(lblSubcategoryIDValue)
        grpSubcategoryDetails.Controls.Add(lblSubcategoryName)
        grpSubcategoryDetails.Controls.Add(lblCategory)
        grpSubcategoryDetails.Controls.Add(lblSubcategoryID)
        grpSubcategoryDetails.Location = New Point(10, 10)
        grpSubcategoryDetails.Name = "grpSubcategoryDetails"
        grpSubcategoryDetails.Size = New Size(950, 220)
        grpSubcategoryDetails.TabIndex = 0
        grpSubcategoryDetails.TabStop = False
        grpSubcategoryDetails.Text = "Subcategory Details"
        '
        'btnClear
        '
        btnClear.Location = New Point(448, 172)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(90, 32)
        btnClear.TabIndex = 7
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        btnDelete.Location = New Point(338, 172)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(90, 32)
        btnDelete.TabIndex = 6
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        btnUpdate.Location = New Point(228, 172)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(90, 32)
        btnUpdate.TabIndex = 5
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        btnSave.Location = New Point(118, 172)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(90, 32)
        btnSave.TabIndex = 4
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        chkActive.AutoSize = True
        chkActive.Checked = True
        chkActive.CheckState = CheckState.Checked
        chkActive.Location = New Point(406, 118)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(56, 19)
        chkActive.TabIndex = 3
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        txtDescription.Location = New Point(118, 112)
        txtDescription.MaxLength = 500
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(250, 42)
        txtDescription.TabIndex = 2
        '
        'txtSubcategoryName
        '
        txtSubcategoryName.Location = New Point(118, 69)
        txtSubcategoryName.MaxLength = 100
        txtSubcategoryName.Name = "txtSubcategoryName"
        txtSubcategoryName.Size = New Size(250, 23)
        txtSubcategoryName.TabIndex = 1
        '
        'cboCategory
        '
        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(576, 69)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(250, 23)
        cboCategory.TabIndex = 0
        '
        'lblDescription
        '
        lblDescription.AutoSize = True
        lblDescription.Location = New Point(45, 115)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(67, 15)
        lblDescription.TabIndex = 0
        lblDescription.Text = "Description"
        '
        'lblRequired
        '
        lblRequired.AutoSize = True
        lblRequired.ForeColor = Color.Red
        lblRequired.Location = New Point(374, 72)
        lblRequired.Name = "lblRequired"
        lblRequired.Size = New Size(12, 15)
        lblRequired.TabIndex = 0
        lblRequired.Text = "*"
        '
        'lblSubcategoryIDValue
        '
        lblSubcategoryIDValue.AutoSize = True
        lblSubcategoryIDValue.Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold)
        lblSubcategoryIDValue.Location = New Point(118, 29)
        lblSubcategoryIDValue.Name = "lblSubcategoryIDValue"
        lblSubcategoryIDValue.Size = New Size(120, 21)
        lblSubcategoryIDValue.TabIndex = 0
        lblSubcategoryIDValue.Text = "Auto Generated"
        '
        'lblSubcategoryName
        '
        lblSubcategoryName.AutoSize = True
        lblSubcategoryName.Location = New Point(7, 72)
        lblSubcategoryName.Name = "lblSubcategoryName"
        lblSubcategoryName.Size = New Size(105, 15)
        lblSubcategoryName.TabIndex = 0
        lblSubcategoryName.Text = "Subcategory Name"
        '
        'lblCategory
        '
        lblCategory.AutoSize = True
        lblCategory.Location = New Point(521, 72)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(55, 15)
        lblCategory.TabIndex = 0
        lblCategory.Text = "Category"
        '
        'lblSubcategoryID
        '
        lblSubcategoryID.AutoSize = True
        lblSubcategoryID.Location = New Point(27, 31)
        lblSubcategoryID.Name = "lblSubcategoryID"
        lblSubcategoryID.Size = New Size(85, 15)
        lblSubcategoryID.TabIndex = 0
        lblSubcategoryID.Text = "Subcategory ID"
        '
        'grpSubcategoryList
        '
        grpSubcategoryList.BackColor = Color.White
        grpSubcategoryList.Controls.Add(dgvSubcategories)
        grpSubcategoryList.Controls.Add(lblTotalSubcategories)
        grpSubcategoryList.Controls.Add(lblSearch)
        grpSubcategoryList.Controls.Add(txtSearch)
        grpSubcategoryList.Controls.Add(btnExport)
        grpSubcategoryList.Controls.Add(btnShowAll)
        grpSubcategoryList.Controls.Add(btnSearch)
        grpSubcategoryList.Location = New Point(10, 240)
        grpSubcategoryList.Name = "grpSubcategoryList"
        grpSubcategoryList.Size = New Size(950, 340)
        grpSubcategoryList.TabIndex = 1
        grpSubcategoryList.TabStop = False
        grpSubcategoryList.Text = "Subcategories List"
        '
        'dgvSubcategories
        '
        dgvSubcategories.AllowUserToAddRows = False
        dgvSubcategories.BackgroundColor = Color.White
        dgvSubcategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSubcategories.Location = New Point(20, 95)
        dgvSubcategories.Name = "dgvSubcategories"
        dgvSubcategories.ReadOnly = True
        dgvSubcategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSubcategories.Size = New Size(910, 230)
        dgvSubcategories.TabIndex = 4
        '
        'lblTotalSubcategories
        '
        lblTotalSubcategories.AutoSize = True
        lblTotalSubcategories.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblTotalSubcategories.Location = New Point(380, 39)
        lblTotalSubcategories.Name = "lblTotalSubcategories"
        lblTotalSubcategories.Size = New Size(142, 21)
        lblTotalSubcategories.TabIndex = 0
        lblTotalSubcategories.Text = "Total Subcategories"
        '
        'lblSearch
        '
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI Semibold", 11.25!, FontStyle.Bold)
        lblSearch.Location = New Point(20, 40)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(55, 20)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search"
        '
        'txtSearch
        '
        txtSearch.Location = New Point(84, 39)
        txtSearch.MaxLength = 100
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(250, 23)
        txtSearch.TabIndex = 0
        '
        'btnExport
        '
        btnExport.Location = New Point(850, 35)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(80, 32)
        btnExport.TabIndex = 3
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        '
        'btnShowAll
        '
        btnShowAll.Location = New Point(760, 35)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(80, 32)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "Show All"
        btnShowAll.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        btnSearch.Location = New Point(670, 35)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(80, 32)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Location = New Point(870, 590)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 32)
        btnClose.TabIndex = 2
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'frmSubcategories
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(972, 634)
        Controls.Add(btnClose)
        Controls.Add(grpSubcategoryList)
        Controls.Add(grpSubcategoryDetails)
        Font = New Font("Segoe UI", 9.0!)
        Name = "frmSubcategories"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Subcategories"
        grpSubcategoryDetails.ResumeLayout(False)
        grpSubcategoryDetails.PerformLayout()
        grpSubcategoryList.ResumeLayout(False)
        grpSubcategoryList.PerformLayout()
        CType(dgvSubcategories, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpSubcategoryDetails As GroupBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtSubcategoryName As TextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblRequired As Label
    Friend WithEvents lblSubcategoryIDValue As Label
    Friend WithEvents lblSubcategoryName As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblSubcategoryID As Label
    Friend WithEvents grpSubcategoryList As GroupBox
    Friend WithEvents dgvSubcategories As DataGridView
    Friend WithEvents lblTotalSubcategories As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClose As Button
End Class
