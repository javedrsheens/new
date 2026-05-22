<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccounts
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
        grpAccountDetails = New GroupBox()
        chkActive = New CheckBox()
        txtOpeningBalance = New TextBox()
        cboParentAccount = New ComboBox()
        cboAccountType = New ComboBox()
        txtAccountName = New TextBox()
        txtAccountCode = New TextBox()
        lblOpeningBalance = New Label()
        lblParentAccount = New Label()
        lblAccountType = New Label()
        lblAccountNameReq = New Label()
        lblAccountCodeReq = New Label()
        lblAccountName = New Label()
        lblAccountCode = New Label()
        lblAccountIDValue = New Label()
        lblAccountID = New Label()
        btnClear = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        btnSave = New Button()
        grpAccountList = New GroupBox()
        dgvAccounts = New DataGridView()
        lblTotalAccounts = New Label()
        lblSearch = New Label()
        txtSearch = New TextBox()
        btnExport = New Button()
        btnShowAll = New Button()
        btnSearch = New Button()
        btnClose = New Button()
        grpAccountDetails.SuspendLayout()
        grpAccountList.SuspendLayout()
        CType(dgvAccounts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'grpAccountDetails
        '
        grpAccountDetails.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpAccountDetails.Controls.Add(chkActive)
        grpAccountDetails.Controls.Add(txtOpeningBalance)
        grpAccountDetails.Controls.Add(cboParentAccount)
        grpAccountDetails.Controls.Add(cboAccountType)
        grpAccountDetails.Controls.Add(txtAccountName)
        grpAccountDetails.Controls.Add(txtAccountCode)
        grpAccountDetails.Controls.Add(lblOpeningBalance)
        grpAccountDetails.Controls.Add(lblParentAccount)
        grpAccountDetails.Controls.Add(lblAccountType)
        grpAccountDetails.Controls.Add(lblAccountNameReq)
        grpAccountDetails.Controls.Add(lblAccountCodeReq)
        grpAccountDetails.Controls.Add(lblAccountName)
        grpAccountDetails.Controls.Add(lblAccountCode)
        grpAccountDetails.Controls.Add(lblAccountIDValue)
        grpAccountDetails.Controls.Add(lblAccountID)
        grpAccountDetails.Controls.Add(btnClear)
        grpAccountDetails.Controls.Add(btnDelete)
        grpAccountDetails.Controls.Add(btnUpdate)
        grpAccountDetails.Controls.Add(btnSave)
        grpAccountDetails.Location = New Point(10, 10)
        grpAccountDetails.Name = "grpAccountDetails"
        grpAccountDetails.Size = New Size(980, 230)
        grpAccountDetails.TabIndex = 0
        grpAccountDetails.TabStop = False
        grpAccountDetails.Text = "Account Details"
        '
        'chkActive
        '
        chkActive.AutoSize = True
        chkActive.Checked = True
        chkActive.CheckState = CheckState.Checked
        chkActive.Location = New Point(691, 121)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(67, 19)
        chkActive.TabIndex = 5
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        '
        'txtOpeningBalance
        '
        txtOpeningBalance.Location = New Point(691, 77)
        txtOpeningBalance.Name = "txtOpeningBalance"
        txtOpeningBalance.Size = New Size(180, 23)
        txtOpeningBalance.TabIndex = 4
        txtOpeningBalance.Text = "0.00"
        txtOpeningBalance.TextAlign = HorizontalAlignment.Right
        '
        'cboParentAccount
        '
        cboParentAccount.DropDownStyle = ComboBoxStyle.DropDownList
        cboParentAccount.FormattingEnabled = True
        cboParentAccount.Location = New Point(420, 117)
        cboParentAccount.Name = "cboParentAccount"
        cboParentAccount.Size = New Size(190, 23)
        cboParentAccount.TabIndex = 3
        '
        'cboAccountType
        '
        cboAccountType.DropDownStyle = ComboBoxStyle.DropDownList
        cboAccountType.FormattingEnabled = True
        cboAccountType.Location = New Point(420, 77)
        cboAccountType.Name = "cboAccountType"
        cboAccountType.Size = New Size(190, 23)
        cboAccountType.TabIndex = 2
        '
        'txtAccountName
        '
        txtAccountName.Location = New Point(122, 117)
        txtAccountName.MaxLength = 100
        txtAccountName.Name = "txtAccountName"
        txtAccountName.Size = New Size(190, 23)
        txtAccountName.TabIndex = 1
        '
        'txtAccountCode
        '
        txtAccountCode.Location = New Point(122, 77)
        txtAccountCode.MaxLength = 20
        txtAccountCode.Name = "txtAccountCode"
        txtAccountCode.Size = New Size(190, 23)
        txtAccountCode.TabIndex = 0
        '
        'lblOpeningBalance
        '
        lblOpeningBalance.AutoSize = True
        lblOpeningBalance.Location = New Point(597, 81)
        lblOpeningBalance.Name = "lblOpeningBalance"
        lblOpeningBalance.Size = New Size(90, 15)
        lblOpeningBalance.TabIndex = 0
        lblOpeningBalance.Text = "Opening Balace"
        '
        'lblParentAccount
        '
        lblParentAccount.AutoSize = True
        lblParentAccount.Location = New Point(336, 121)
        lblParentAccount.Name = "lblParentAccount"
        lblParentAccount.Size = New Size(81, 15)
        lblParentAccount.TabIndex = 0
        lblParentAccount.Text = "Parent Account"
        '
        'lblAccountType
        '
        lblAccountType.AutoSize = True
        lblAccountType.Location = New Point(341, 81)
        lblAccountType.Name = "lblAccountType"
        lblAccountType.Size = New Size(76, 15)
        lblAccountType.TabIndex = 0
        lblAccountType.Text = "Account Type"
        '
        'lblAccountNameReq
        '
        lblAccountNameReq.AutoSize = True
        lblAccountNameReq.ForeColor = Color.Red
        lblAccountNameReq.Location = New Point(315, 121)
        lblAccountNameReq.Name = "lblAccountNameReq"
        lblAccountNameReq.Size = New Size(11, 15)
        lblAccountNameReq.TabIndex = 0
        lblAccountNameReq.Text = "*"
        '
        'lblAccountCodeReq
        '
        lblAccountCodeReq.AutoSize = True
        lblAccountCodeReq.ForeColor = Color.Red
        lblAccountCodeReq.Location = New Point(315, 81)
        lblAccountCodeReq.Name = "lblAccountCodeReq"
        lblAccountCodeReq.Size = New Size(11, 15)
        lblAccountCodeReq.TabIndex = 0
        lblAccountCodeReq.Text = "*"
        '
        'lblAccountName
        '
        lblAccountName.AutoSize = True
        lblAccountName.Location = New Point(39, 121)
        lblAccountName.Name = "lblAccountName"
        lblAccountName.Size = New Size(83, 15)
        lblAccountName.TabIndex = 0
        lblAccountName.Text = "Account Name"
        '
        'lblAccountCode
        '
        lblAccountCode.AutoSize = True
        lblAccountCode.Location = New Point(43, 81)
        lblAccountCode.Name = "lblAccountCode"
        lblAccountCode.Size = New Size(79, 15)
        lblAccountCode.TabIndex = 0
        lblAccountCode.Text = "Account Code"
        '
        'lblAccountIDValue
        '
        lblAccountIDValue.AutoSize = True
        lblAccountIDValue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblAccountIDValue.Location = New Point(122, 32)
        lblAccountIDValue.Name = "lblAccountIDValue"
        lblAccountIDValue.Size = New Size(120, 21)
        lblAccountIDValue.TabIndex = 0
        lblAccountIDValue.Text = "Auto Generated"
        '
        'lblAccountID
        '
        lblAccountID.AutoSize = True
        lblAccountID.Location = New Point(54, 33)
        lblAccountID.Name = "lblAccountID"
        lblAccountID.Size = New Size(68, 15)
        lblAccountID.TabIndex = 0
        lblAccountID.Text = "Account ID"
        '
        'btnClear
        '
        btnClear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClear.Location = New Point(446, 170)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(80, 32)
        btnClear.TabIndex = 9
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        btnDelete.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnDelete.Location = New Point(340, 170)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(80, 32)
        btnDelete.TabIndex = 8
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        btnUpdate.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnUpdate.Location = New Point(234, 170)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(80, 32)
        btnUpdate.TabIndex = 7
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        btnSave.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSave.Location = New Point(128, 170)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(80, 32)
        btnSave.TabIndex = 6
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        '
        'grpAccountList
        '
        grpAccountList.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpAccountList.Controls.Add(dgvAccounts)
        grpAccountList.Controls.Add(lblTotalAccounts)
        grpAccountList.Controls.Add(lblSearch)
        grpAccountList.Controls.Add(txtSearch)
        grpAccountList.Controls.Add(btnExport)
        grpAccountList.Controls.Add(btnShowAll)
        grpAccountList.Controls.Add(btnSearch)
        grpAccountList.Location = New Point(10, 250)
        grpAccountList.Name = "grpAccountList"
        grpAccountList.Size = New Size(980, 355)
        grpAccountList.TabIndex = 1
        grpAccountList.TabStop = False
        grpAccountList.Text = "Accounts List"
        '
        'dgvAccounts
        '
        dgvAccounts.AllowUserToAddRows = False
        dgvAccounts.BackgroundColor = Color.White
        dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAccounts.Location = New Point(18, 95)
        dgvAccounts.Name = "dgvAccounts"
        dgvAccounts.ReadOnly = True
        dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAccounts.Size = New Size(942, 240)
        dgvAccounts.TabIndex = 6
        '
        'lblTotalAccounts
        '
        lblTotalAccounts.AutoSize = True
        lblTotalAccounts.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblTotalAccounts.Location = New Point(333, 39)
        lblTotalAccounts.Name = "lblTotalAccounts"
        lblTotalAccounts.Size = New Size(125, 21)
        lblTotalAccounts.TabIndex = 0
        lblTotalAccounts.Text = "Total Accounts: 0"
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
        'btnExport
        '
        btnExport.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnExport.Location = New Point(875, 33)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(85, 32)
        btnExport.TabIndex = 3
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        '
        'btnShowAll
        '
        btnShowAll.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnShowAll.Location = New Point(774, 33)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(85, 32)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSearch.Location = New Point(673, 33)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(85, 32)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(454, 615)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 34)
        btnClose.TabIndex = 2
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'frmAccounts
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1004, 661)
        Controls.Add(btnClose)
        Controls.Add(grpAccountList)
        Controls.Add(grpAccountDetails)
        Font = New Font("Segoe UI", 9F)
        Name = "frmAccounts"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Chart Of Accounts"
        grpAccountDetails.ResumeLayout(False)
        grpAccountDetails.PerformLayout()
        grpAccountList.ResumeLayout(False)
        grpAccountList.PerformLayout()
        CType(dgvAccounts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpAccountDetails As GroupBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtOpeningBalance As TextBox
    Friend WithEvents cboParentAccount As ComboBox
    Friend WithEvents cboAccountType As ComboBox
    Friend WithEvents txtAccountName As TextBox
    Friend WithEvents txtAccountCode As TextBox
    Friend WithEvents lblOpeningBalance As Label
    Friend WithEvents lblParentAccount As Label
    Friend WithEvents lblAccountType As Label
    Friend WithEvents lblAccountNameReq As Label
    Friend WithEvents lblAccountCodeReq As Label
    Friend WithEvents lblAccountName As Label
    Friend WithEvents lblAccountCode As Label
    Friend WithEvents lblAccountIDValue As Label
    Friend WithEvents lblAccountID As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents grpAccountList As GroupBox
    Friend WithEvents dgvAccounts As DataGridView
    Friend WithEvents lblTotalAccounts As Label
    Friend WithEvents lblSearch As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnExport As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClose As Button
End Class
