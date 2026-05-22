<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuppliers
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
        grpSupplierDetails = New GroupBox()
        chkActive = New CheckBox()
        txtBalance = New TextBox()
        txtCity = New TextBox()
        txtAddress = New TextBox()
        txtEmail = New TextBox()
        txtPhone = New TextBox()
        txtContactPerson = New TextBox()
        txtSupplierName = New TextBox()
        lblBalance = New Label()
        lblCity = New Label()
        lblAddress = New Label()
        lblEmail = New Label()
        lblPhone = New Label()
        lblContactPerson = New Label()
        lblRequired = New Label()
        lblSupplierIDValue = New Label()
        lblSupplierName = New Label()
        lblSupplierID = New Label()
        btnClear = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        btnSave = New Button()
        grpSupplierList = New GroupBox()
        dgvSuppliers = New DataGridView()
        lblTotalSuppliers = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnExport = New Button()
        btnShowAll = New Button()
        btnSearch = New Button()
        btnClose = New Button()
        grpSupplierDetails.SuspendLayout()
        grpSupplierList.SuspendLayout()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'grpSupplierDetails
        '
        grpSupplierDetails.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpSupplierDetails.Controls.Add(chkActive)
        grpSupplierDetails.Controls.Add(txtBalance)
        grpSupplierDetails.Controls.Add(txtCity)
        grpSupplierDetails.Controls.Add(txtAddress)
        grpSupplierDetails.Controls.Add(txtEmail)
        grpSupplierDetails.Controls.Add(txtPhone)
        grpSupplierDetails.Controls.Add(txtContactPerson)
        grpSupplierDetails.Controls.Add(txtSupplierName)
        grpSupplierDetails.Controls.Add(lblBalance)
        grpSupplierDetails.Controls.Add(lblCity)
        grpSupplierDetails.Controls.Add(lblAddress)
        grpSupplierDetails.Controls.Add(lblEmail)
        grpSupplierDetails.Controls.Add(lblPhone)
        grpSupplierDetails.Controls.Add(lblContactPerson)
        grpSupplierDetails.Controls.Add(lblRequired)
        grpSupplierDetails.Controls.Add(lblSupplierIDValue)
        grpSupplierDetails.Controls.Add(lblSupplierName)
        grpSupplierDetails.Controls.Add(lblSupplierID)
        grpSupplierDetails.Controls.Add(btnClear)
        grpSupplierDetails.Controls.Add(btnDelete)
        grpSupplierDetails.Controls.Add(btnUpdate)
        grpSupplierDetails.Controls.Add(btnSave)
        grpSupplierDetails.Location = New Point(10, 10)
        grpSupplierDetails.Name = "grpSupplierDetails"
        grpSupplierDetails.Size = New Size(1010, 250)
        grpSupplierDetails.TabIndex = 0
        grpSupplierDetails.TabStop = False
        grpSupplierDetails.Text = "Supplier Details"
        '
        'chkActive
        '
        chkActive.AutoSize = True
        chkActive.Checked = True
        chkActive.CheckState = CheckState.Checked
        chkActive.Location = New Point(770, 34)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(67, 19)
        chkActive.TabIndex = 7
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        '
        'txtBalance
        '
        txtBalance.Location = New Point(770, 78)
        txtBalance.Name = "txtBalance"
        txtBalance.ReadOnly = True
        txtBalance.Size = New Size(180, 23)
        txtBalance.TabIndex = 99
        txtBalance.TabStop = False
        txtBalance.Text = "0.00"
        txtBalance.TextAlign = HorizontalAlignment.Right
        '
        'txtCity
        '
        txtCity.Location = New Point(436, 158)
        txtCity.MaxLength = 50
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(220, 23)
        txtCity.TabIndex = 5
        '
        'txtAddress
        '
        txtAddress.Location = New Point(436, 114)
        txtAddress.MaxLength = 255
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(514, 23)
        txtAddress.TabIndex = 4
        '
        'txtEmail
        '
        txtEmail.Location = New Point(436, 74)
        txtEmail.MaxLength = 100
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(220, 23)
        txtEmail.TabIndex = 3
        '
        'txtPhone
        '
        txtPhone.Location = New Point(144, 154)
        txtPhone.MaxLength = 20
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(200, 23)
        txtPhone.TabIndex = 2
        '
        'txtContactPerson
        '
        txtContactPerson.Location = New Point(144, 114)
        txtContactPerson.MaxLength = 100
        txtContactPerson.Name = "txtContactPerson"
        txtContactPerson.Size = New Size(200, 23)
        txtContactPerson.TabIndex = 1
        '
        'txtSupplierName
        '
        txtSupplierName.Location = New Point(144, 74)
        txtSupplierName.MaxLength = 100
        txtSupplierName.Name = "txtSupplierName"
        txtSupplierName.Size = New Size(200, 23)
        txtSupplierName.TabIndex = 0
        '
        'lblBalance
        '
        lblBalance.AutoSize = True
        lblBalance.Location = New Point(705, 82)
        lblBalance.Name = "lblBalance"
        lblBalance.Size = New Size(46, 15)
        lblBalance.TabIndex = 0
        lblBalance.Text = "Balance"
        '
        'lblCity
        '
        lblCity.AutoSize = True
        lblCity.Location = New Point(397, 162)
        lblCity.Name = "lblCity"
        lblCity.Size = New Size(26, 15)
        lblCity.TabIndex = 0
        lblCity.Text = "City"
        '
        'lblAddress
        '
        lblAddress.AutoSize = True
        lblAddress.Location = New Point(372, 118)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(49, 15)
        lblAddress.TabIndex = 0
        lblAddress.Text = "Address"
        '
        'lblEmail
        '
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(384, 78)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(36, 15)
        lblEmail.TabIndex = 0
        lblEmail.Text = "Email"
        '
        'lblPhone
        '
        lblPhone.AutoSize = True
        lblPhone.Location = New Point(100, 158)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(41, 15)
        lblPhone.TabIndex = 0
        lblPhone.Text = "Phone"
        '
        'lblContactPerson
        '
        lblContactPerson.AutoSize = True
        lblContactPerson.Location = New Point(53, 118)
        lblContactPerson.Name = "lblContactPerson"
        lblContactPerson.Size = New Size(88, 15)
        lblContactPerson.TabIndex = 0
        lblContactPerson.Text = "Contact Person"
        '
        'lblRequired
        '
        lblRequired.AutoSize = True
        lblRequired.ForeColor = Color.Red
        lblRequired.Location = New Point(349, 78)
        lblRequired.Name = "lblRequired"
        lblRequired.Size = New Size(11, 15)
        lblRequired.TabIndex = 0
        lblRequired.Text = "*"
        '
        'lblSupplierIDValue
        '
        lblSupplierIDValue.AutoSize = True
        lblSupplierIDValue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplierIDValue.Location = New Point(144, 30)
        lblSupplierIDValue.Name = "lblSupplierIDValue"
        lblSupplierIDValue.Size = New Size(120, 21)
        lblSupplierIDValue.TabIndex = 0
        lblSupplierIDValue.Text = "Auto Generated"
        '
        'lblSupplierName
        '
        lblSupplierName.AutoSize = True
        lblSupplierName.Location = New Point(56, 78)
        lblSupplierName.Name = "lblSupplierName"
        lblSupplierName.Size = New Size(85, 15)
        lblSupplierName.TabIndex = 0
        lblSupplierName.Text = "Supplier Name"
        '
        'lblSupplierID
        '
        lblSupplierID.AutoSize = True
        lblSupplierID.Location = New Point(76, 31)
        lblSupplierID.Name = "lblSupplierID"
        lblSupplierID.Size = New Size(65, 15)
        lblSupplierID.TabIndex = 0
        lblSupplierID.Text = "Supplier ID"
        '
        'btnClear
        '
        btnClear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClear.Location = New Point(470, 200)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 32)
        btnClear.TabIndex = 11
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        btnDelete.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnDelete.Location = New Point(360, 200)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 32)
        btnDelete.TabIndex = 10
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        btnUpdate.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnUpdate.Location = New Point(250, 200)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(80, 32)
        btnUpdate.TabIndex = 9
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        btnSave.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSave.Location = New Point(140, 200)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(80, 32)
        btnSave.TabIndex = 8
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        '
        'grpSupplierList
        '
        grpSupplierList.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpSupplierList.Controls.Add(dgvSuppliers)
        grpSupplierList.Controls.Add(lblTotalSuppliers)
        grpSupplierList.Controls.Add(lblSearch)
        grpSupplierList.Controls.Add(txtSearch)
        grpSupplierList.Controls.Add(btnExport)
        grpSupplierList.Controls.Add(btnShowAll)
        grpSupplierList.Controls.Add(btnSearch)
        grpSupplierList.Location = New Point(10, 270)
        grpSupplierList.Name = "grpSupplierList"
        grpSupplierList.Size = New Size(1010, 360)
        grpSupplierList.TabIndex = 1
        grpSupplierList.TabStop = False
        grpSupplierList.Text = "Suppliers List"
        '
        'dgvSuppliers
        '
        dgvSuppliers.AllowUserToAddRows = False
        dgvSuppliers.BackgroundColor = Color.White
        dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSuppliers.Location = New Point(18, 95)
        dgvSuppliers.Name = "dgvSuppliers"
        dgvSuppliers.ReadOnly = True
        dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSuppliers.Size = New Size(972, 245)
        dgvSuppliers.TabIndex = 6
        '
        'lblTotalSuppliers
        '
        lblTotalSuppliers.AutoSize = True
        lblTotalSuppliers.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTotalSuppliers.Location = New Point(370, 40)
        lblTotalSuppliers.Name = "lblTotalSuppliers"
        lblTotalSuppliers.Size = New Size(131, 21)
        lblTotalSuppliers.TabIndex = 0
        lblTotalSuppliers.Text = "Total Suppliers: 0"
        '
        'lblSearch
        '
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        lblSearch.Location = New Point(20, 40)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(55, 20)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search"
        '
        'txtSearch
        '
        txtSearch.Location = New Point(90, 38)
        txtSearch.MaxLength = 100
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(235, 23)
        txtSearch.TabIndex = 0
        '
        'btnExport
        '
        btnExport.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnExport.Location = New Point(910, 34)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(80, 32)
        btnExport.TabIndex = 3
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        '
        'btnShowAll
        '
        btnShowAll.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnShowAll.Location = New Point(815, 34)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(80, 32)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSearch.Location = New Point(720, 34)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(80, 32)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(470, 640)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 34)
        btnClose.TabIndex = 2
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'frmSuppliers
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1034, 686)
        Controls.Add(btnClose)
        Controls.Add(grpSupplierList)
        Controls.Add(grpSupplierDetails)
        Font = New Font("Segoe UI", 9F)
        Name = "frmSuppliers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Supplier Management"
        grpSupplierDetails.ResumeLayout(False)
        grpSupplierDetails.PerformLayout()
        grpSupplierList.ResumeLayout(False)
        grpSupplierList.PerformLayout()
        CType(dgvSuppliers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpSupplierDetails As GroupBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtBalance As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtContactPerson As TextBox
    Friend WithEvents txtSupplierName As TextBox
    Friend WithEvents lblBalance As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblContactPerson As Label
    Friend WithEvents lblRequired As Label
    Friend WithEvents lblSupplierIDValue As Label
    Friend WithEvents lblSupplierName As Label
    Friend WithEvents lblSupplierID As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents grpSupplierList As GroupBox
    Friend WithEvents dgvSuppliers As DataGridView
    Friend WithEvents lblTotalSuppliers As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClose As Button
End Class
