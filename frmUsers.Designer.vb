<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        grpUserDetails = New GroupBox()
        chkActive = New CheckBox()
        cboRole = New ComboBox()
        txtEmail = New TextBox()
        txtFullName = New TextBox()
        txtPassword = New TextBox()
        txtUsername = New TextBox()
        lblRole = New Label()
        lblEmail = New Label()
        lblFullNameRequired = New Label()
        lblUsernameRequired = New Label()
        lblFullName = New Label()
        lblPassword = New Label()
        lblUsername = New Label()
        lblUserIDValue = New Label()
        lblUserID = New Label()
        btnClear = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        btnSave = New Button()
        grpUserList = New GroupBox()
        dgvUsers = New DataGridView()
        lblTotalUsers = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnShowAll = New Button()
        btnSearch = New Button()
        btnClose = New Button()
        grpUserDetails.SuspendLayout()
        grpUserList.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'grpUserDetails
        '
        grpUserDetails.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpUserDetails.Controls.Add(chkActive)
        grpUserDetails.Controls.Add(cboRole)
        grpUserDetails.Controls.Add(txtEmail)
        grpUserDetails.Controls.Add(txtFullName)
        grpUserDetails.Controls.Add(txtPassword)
        grpUserDetails.Controls.Add(txtUsername)
        grpUserDetails.Controls.Add(lblRole)
        grpUserDetails.Controls.Add(lblEmail)
        grpUserDetails.Controls.Add(lblFullNameRequired)
        grpUserDetails.Controls.Add(lblUsernameRequired)
        grpUserDetails.Controls.Add(lblFullName)
        grpUserDetails.Controls.Add(lblPassword)
        grpUserDetails.Controls.Add(lblUsername)
        grpUserDetails.Controls.Add(lblUserIDValue)
        grpUserDetails.Controls.Add(lblUserID)
        grpUserDetails.Controls.Add(btnClear)
        grpUserDetails.Controls.Add(btnDelete)
        grpUserDetails.Controls.Add(btnUpdate)
        grpUserDetails.Controls.Add(btnSave)
        grpUserDetails.Location = New Point(10, 10)
        grpUserDetails.Name = "grpUserDetails"
        grpUserDetails.Size = New Size(970, 225)
        grpUserDetails.TabIndex = 0
        grpUserDetails.TabStop = False
        grpUserDetails.Text = "User Details"
        '
        'chkActive
        '
        chkActive.AutoSize = True
        chkActive.Checked = True
        chkActive.CheckState = CheckState.Checked
        chkActive.Location = New Point(694, 118)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(67, 19)
        chkActive.TabIndex = 5
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        '
        'cboRole
        '
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(694, 74)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(190, 23)
        cboRole.TabIndex = 4
        '
        'txtEmail
        '
        txtEmail.Location = New Point(420, 118)
        txtEmail.MaxLength = 100
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(190, 23)
        txtEmail.TabIndex = 3
        '
        'txtFullName
        '
        txtFullName.Location = New Point(420, 74)
        txtFullName.MaxLength = 100
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(190, 23)
        txtFullName.TabIndex = 2
        '
        'txtPassword
        '
        txtPassword.Location = New Point(126, 118)
        txtPassword.MaxLength = 255
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(190, 23)
        txtPassword.TabIndex = 1
        txtPassword.UseSystemPasswordChar = True
        '
        'txtUsername
        '
        txtUsername.Location = New Point(126, 74)
        txtUsername.MaxLength = 50
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(190, 23)
        txtUsername.TabIndex = 0
        '
        'lblRole
        '
        lblRole.AutoSize = True
        lblRole.Location = New Point(661, 78)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(30, 15)
        lblRole.TabIndex = 0
        lblRole.Text = "Role"
        '
        'lblEmail
        '
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(381, 122)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(36, 15)
        lblEmail.TabIndex = 0
        lblEmail.Text = "Email"
        '
        'lblFullNameRequired
        '
        lblFullNameRequired.AutoSize = True
        lblFullNameRequired.ForeColor = Color.Red
        lblFullNameRequired.Location = New Point(613, 78)
        lblFullNameRequired.Name = "lblFullNameRequired"
        lblFullNameRequired.Size = New Size(11, 15)
        lblFullNameRequired.TabIndex = 0
        lblFullNameRequired.Text = "*"
        '
        'lblUsernameRequired
        '
        lblUsernameRequired.AutoSize = True
        lblUsernameRequired.ForeColor = Color.Red
        lblUsernameRequired.Location = New Point(319, 78)
        lblUsernameRequired.Name = "lblUsernameRequired"
        lblUsernameRequired.Size = New Size(11, 15)
        lblUsernameRequired.TabIndex = 0
        lblUsernameRequired.Text = "*"
        '
        'lblFullName
        '
        lblFullName.AutoSize = True
        lblFullName.Location = New Point(356, 78)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(61, 15)
        lblFullName.TabIndex = 0
        lblFullName.Text = "Full Name"
        '
        'lblPassword
        '
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(69, 122)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(57, 15)
        lblPassword.TabIndex = 0
        lblPassword.Text = "Password"
        '
        'lblUsername
        '
        lblUsername.AutoSize = True
        lblUsername.Location = New Point(63, 78)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(63, 15)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username"
        '
        'lblUserIDValue
        '
        lblUserIDValue.AutoSize = True
        lblUserIDValue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblUserIDValue.Location = New Point(126, 30)
        lblUserIDValue.Name = "lblUserIDValue"
        lblUserIDValue.Size = New Size(120, 21)
        lblUserIDValue.TabIndex = 0
        lblUserIDValue.Text = "Auto Generated"
        '
        'lblUserID
        '
        lblUserID.AutoSize = True
        lblUserID.Location = New Point(82, 31)
        lblUserID.Name = "lblUserID"
        lblUserID.Size = New Size(44, 15)
        lblUserID.TabIndex = 0
        lblUserID.Text = "User ID"
        '
        'btnClear
        '
        btnClear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClear.Location = New Point(438, 170)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 32)
        btnClear.TabIndex = 9
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        btnDelete.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnDelete.Location = New Point(332, 170)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 32)
        btnDelete.TabIndex = 8
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        btnUpdate.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnUpdate.Location = New Point(226, 170)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(80, 32)
        btnUpdate.TabIndex = 7
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        btnSave.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSave.Location = New Point(120, 170)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(80, 32)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        '
        'grpUserList
        '
        grpUserList.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpUserList.Controls.Add(dgvUsers)
        grpUserList.Controls.Add(lblTotalUsers)
        grpUserList.Controls.Add(lblSearch)
        grpUserList.Controls.Add(txtSearch)
        grpUserList.Controls.Add(btnShowAll)
        grpUserList.Controls.Add(btnSearch)
        grpUserList.Location = New Point(10, 245)
        grpUserList.Name = "grpUserList"
        grpUserList.Size = New Size(970, 335)
        grpUserList.TabIndex = 1
        grpUserList.TabStop = False
        grpUserList.Text = "Users List"
        '
        'dgvUsers
        '
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.BackgroundColor = Color.White
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.Location = New Point(18, 92)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.ReadOnly = True
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.Size = New Size(932, 225)
        dgvUsers.TabIndex = 5
        '
        'lblTotalUsers
        '
        lblTotalUsers.AutoSize = True
        lblTotalUsers.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTotalUsers.Location = New Point(324, 39)
        lblTotalUsers.Name = "lblTotalUsers"
        lblTotalUsers.Size = New Size(100, 21)
        lblTotalUsers.TabIndex = 0
        lblTotalUsers.Text = "Total Users: 0"
        '
        'lblSearch
        '
        lblSearch.AutoSize = True
        lblSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        lblSearch.Location = New Point(20, 39)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(55, 20)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search"
        '
        'txtSearch
        '
        txtSearch.Location = New Point(86, 37)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(220, 23)
        txtSearch.TabIndex = 0
        '
        'btnShowAll
        '
        btnShowAll.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnShowAll.Location = New Point(865, 33)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(85, 32)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSearch.Location = New Point(764, 33)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(85, 32)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(450, 590)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 34)
        btnClose.TabIndex = 2
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'frmUsers
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(994, 636)
        Controls.Add(btnClose)
        Controls.Add(grpUserList)
        Controls.Add(grpUserDetails)
        Font = New Font("Segoe UI", 9F)
        Name = "frmUsers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User Management"
        grpUserDetails.ResumeLayout(False)
        grpUserDetails.PerformLayout()
        grpUserList.ResumeLayout(False)
        grpUserList.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpUserDetails As GroupBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblFullNameRequired As Label
    Friend WithEvents lblUsernameRequired As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblUserIDValue As Label
    Friend WithEvents lblUserID As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents grpUserList As GroupBox
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClose As Button
End Class
