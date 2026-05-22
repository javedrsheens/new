<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        grpCompany = New GroupBox()
        btnSaveCompany = New Button()
        txtCompanyEmail = New TextBox()
        txtCompanyPhone = New TextBox()
        txtCompanyAddress = New TextBox()
        txtCompanyName = New TextBox()
        lblCompanyEmail = New Label()
        lblCompanyPhone = New Label()
        lblCompanyAddress = New Label()
        lblCompanyName = New Label()
        grpDatabase = New GroupBox()
        btnRestore = New Button()
        btnBackup = New Button()
        grpSecurity = New GroupBox()
        btnChangePassword = New Button()
        txtConfirmPassword = New TextBox()
        txtNewPassword = New TextBox()
        txtCurrentPassword = New TextBox()
        lblConfirmPassword = New Label()
        lblNewPassword = New Label()
        lblCurrentPassword = New Label()
        grpPrinter = New GroupBox()
        btnTestPrint = New Button()
        btnSavePrinter = New Button()
        cboPaperSize = New ComboBox()
        txtPrinterName = New TextBox()
        lblPaperSize = New Label()
        lblPrinterName = New Label()
        grpReset = New GroupBox()
        btnResetData = New Button()
        btnClose = New Button()
        grpCompany.SuspendLayout()
        grpDatabase.SuspendLayout()
        grpSecurity.SuspendLayout()
        grpPrinter.SuspendLayout()
        grpReset.SuspendLayout()
        SuspendLayout()
        '
        'grpCompany
        '
        grpCompany.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpCompany.Controls.Add(btnSaveCompany)
        grpCompany.Controls.Add(txtCompanyEmail)
        grpCompany.Controls.Add(txtCompanyPhone)
        grpCompany.Controls.Add(txtCompanyAddress)
        grpCompany.Controls.Add(txtCompanyName)
        grpCompany.Controls.Add(lblCompanyEmail)
        grpCompany.Controls.Add(lblCompanyPhone)
        grpCompany.Controls.Add(lblCompanyAddress)
        grpCompany.Controls.Add(lblCompanyName)
        grpCompany.Location = New Point(12, 12)
        grpCompany.Name = "grpCompany"
        grpCompany.Size = New Size(548, 210)
        grpCompany.TabIndex = 0
        grpCompany.TabStop = False
        grpCompany.Text = "Company Info"
        '
        'btnSaveCompany
        '
        btnSaveCompany.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSaveCompany.Location = New Point(418, 162)
        btnSaveCompany.Name = "btnSaveCompany"
        btnSaveCompany.Size = New Size(100, 32)
        btnSaveCompany.TabIndex = 4
        btnSaveCompany.Text = "Save"
        btnSaveCompany.UseVisualStyleBackColor = True
        '
        'txtCompanyEmail
        '
        txtCompanyEmail.Location = New Point(122, 126)
        txtCompanyEmail.Name = "txtCompanyEmail"
        txtCompanyEmail.Size = New Size(396, 23)
        txtCompanyEmail.TabIndex = 3
        '
        'txtCompanyPhone
        '
        txtCompanyPhone.Location = New Point(122, 94)
        txtCompanyPhone.Name = "txtCompanyPhone"
        txtCompanyPhone.Size = New Size(396, 23)
        txtCompanyPhone.TabIndex = 2
        '
        'txtCompanyAddress
        '
        txtCompanyAddress.Location = New Point(122, 62)
        txtCompanyAddress.Name = "txtCompanyAddress"
        txtCompanyAddress.Size = New Size(396, 23)
        txtCompanyAddress.TabIndex = 1
        '
        'txtCompanyName
        '
        txtCompanyName.Location = New Point(122, 30)
        txtCompanyName.Name = "txtCompanyName"
        txtCompanyName.Size = New Size(396, 23)
        txtCompanyName.TabIndex = 0
        '
        'lblCompanyEmail
        '
        lblCompanyEmail.AutoSize = True
        lblCompanyEmail.Location = New Point(74, 130)
        lblCompanyEmail.Name = "lblCompanyEmail"
        lblCompanyEmail.Size = New Size(36, 15)
        lblCompanyEmail.TabIndex = 0
        lblCompanyEmail.Text = "Email"
        '
        'lblCompanyPhone
        '
        lblCompanyPhone.AutoSize = True
        lblCompanyPhone.Location = New Point(69, 98)
        lblCompanyPhone.Name = "lblCompanyPhone"
        lblCompanyPhone.Size = New Size(41, 15)
        lblCompanyPhone.TabIndex = 0
        lblCompanyPhone.Text = "Phone"
        '
        'lblCompanyAddress
        '
        lblCompanyAddress.AutoSize = True
        lblCompanyAddress.Location = New Point(61, 66)
        lblCompanyAddress.Name = "lblCompanyAddress"
        lblCompanyAddress.Size = New Size(49, 15)
        lblCompanyAddress.TabIndex = 0
        lblCompanyAddress.Text = "Address"
        '
        'lblCompanyName
        '
        lblCompanyName.AutoSize = True
        lblCompanyName.Location = New Point(15, 34)
        lblCompanyName.Name = "lblCompanyName"
        lblCompanyName.Size = New Size(95, 15)
        lblCompanyName.TabIndex = 0
        lblCompanyName.Text = "Company Name"
        '
        'grpDatabase
        '
        grpDatabase.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpDatabase.Controls.Add(btnRestore)
        grpDatabase.Controls.Add(btnBackup)
        grpDatabase.Location = New Point(578, 12)
        grpDatabase.Name = "grpDatabase"
        grpDatabase.Size = New Size(260, 210)
        grpDatabase.TabIndex = 1
        grpDatabase.TabStop = False
        grpDatabase.Text = "Database"
        '
        'btnRestore
        '
        btnRestore.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnRestore.Location = New Point(34, 102)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(190, 45)
        btnRestore.TabIndex = 1
        btnRestore.Text = "Restore Database"
        btnRestore.UseVisualStyleBackColor = True
        '
        'btnBackup
        '
        btnBackup.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnBackup.Location = New Point(34, 42)
        btnBackup.Name = "btnBackup"
        btnBackup.Size = New Size(190, 45)
        btnBackup.TabIndex = 0
        btnBackup.Text = "Backup Database"
        btnBackup.UseVisualStyleBackColor = True
        '
        'grpSecurity
        '
        grpSecurity.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        grpSecurity.Controls.Add(btnChangePassword)
        grpSecurity.Controls.Add(txtConfirmPassword)
        grpSecurity.Controls.Add(txtNewPassword)
        grpSecurity.Controls.Add(txtCurrentPassword)
        grpSecurity.Controls.Add(lblConfirmPassword)
        grpSecurity.Controls.Add(lblNewPassword)
        grpSecurity.Controls.Add(lblCurrentPassword)
        grpSecurity.Location = New Point(12, 236)
        grpSecurity.Name = "grpSecurity"
        grpSecurity.Size = New Size(548, 190)
        grpSecurity.TabIndex = 2
        grpSecurity.TabStop = False
        grpSecurity.Text = "Security"
        '
        'btnChangePassword
        '
        btnChangePassword.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnChangePassword.Location = New Point(379, 137)
        btnChangePassword.Name = "btnChangePassword"
        btnChangePassword.Size = New Size(139, 34)
        btnChangePassword.TabIndex = 3
        btnChangePassword.Text = "Change Password"
        btnChangePassword.UseVisualStyleBackColor = True
        '
        'txtConfirmPassword
        '
        txtConfirmPassword.Location = New Point(161, 96)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.Size = New Size(357, 23)
        txtConfirmPassword.TabIndex = 2
        txtConfirmPassword.UseSystemPasswordChar = True
        '
        'txtNewPassword
        '
        txtNewPassword.Location = New Point(161, 62)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.Size = New Size(357, 23)
        txtNewPassword.TabIndex = 1
        txtNewPassword.UseSystemPasswordChar = True
        '
        'txtCurrentPassword
        '
        txtCurrentPassword.Location = New Point(161, 28)
        txtCurrentPassword.Name = "txtCurrentPassword"
        txtCurrentPassword.Size = New Size(357, 23)
        txtCurrentPassword.TabIndex = 0
        txtCurrentPassword.UseSystemPasswordChar = True
        '
        'lblConfirmPassword
        '
        lblConfirmPassword.AutoSize = True
        lblConfirmPassword.Location = New Point(56, 100)
        lblConfirmPassword.Name = "lblConfirmPassword"
        lblConfirmPassword.Size = New Size(99, 15)
        lblConfirmPassword.TabIndex = 0
        lblConfirmPassword.Text = "Confirm Password"
        '
        'lblNewPassword
        '
        lblNewPassword.AutoSize = True
        lblNewPassword.Location = New Point(75, 66)
        lblNewPassword.Name = "lblNewPassword"
        lblNewPassword.Size = New Size(80, 15)
        lblNewPassword.TabIndex = 0
        lblNewPassword.Text = "New Password"
        '
        'lblCurrentPassword
        '
        lblCurrentPassword.AutoSize = True
        lblCurrentPassword.Location = New Point(65, 32)
        lblCurrentPassword.Name = "lblCurrentPassword"
        lblCurrentPassword.Size = New Size(90, 15)
        lblCurrentPassword.TabIndex = 0
        lblCurrentPassword.Text = "Current Password"
        '
        'grpPrinter
        '
        grpPrinter.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        grpPrinter.Controls.Add(btnTestPrint)
        grpPrinter.Controls.Add(btnSavePrinter)
        grpPrinter.Controls.Add(cboPaperSize)
        grpPrinter.Controls.Add(txtPrinterName)
        grpPrinter.Controls.Add(lblPaperSize)
        grpPrinter.Controls.Add(lblPrinterName)
        grpPrinter.Location = New Point(578, 236)
        grpPrinter.Name = "grpPrinter"
        grpPrinter.Size = New Size(260, 190)
        grpPrinter.TabIndex = 3
        grpPrinter.TabStop = False
        grpPrinter.Text = "Printer"
        '
        'btnTestPrint
        '
        btnTestPrint.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnTestPrint.Location = New Point(134, 129)
        btnTestPrint.Name = "btnTestPrint"
        btnTestPrint.Size = New Size(90, 34)
        btnTestPrint.TabIndex = 3
        btnTestPrint.Text = "Test Print"
        btnTestPrint.UseVisualStyleBackColor = True
        '
        'btnSavePrinter
        '
        btnSavePrinter.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnSavePrinter.Location = New Point(34, 129)
        btnSavePrinter.Name = "btnSavePrinter"
        btnSavePrinter.Size = New Size(90, 34)
        btnSavePrinter.TabIndex = 2
        btnSavePrinter.Text = "Save"
        btnSavePrinter.UseVisualStyleBackColor = True
        '
        'cboPaperSize
        '
        cboPaperSize.DropDownStyle = ComboBoxStyle.DropDownList
        cboPaperSize.FormattingEnabled = True
        cboPaperSize.Location = New Point(34, 88)
        cboPaperSize.Name = "cboPaperSize"
        cboPaperSize.Size = New Size(190, 23)
        cboPaperSize.TabIndex = 1
        '
        'txtPrinterName
        '
        txtPrinterName.Location = New Point(34, 40)
        txtPrinterName.Name = "txtPrinterName"
        txtPrinterName.Size = New Size(190, 23)
        txtPrinterName.TabIndex = 0
        '
        'lblPaperSize
        '
        lblPaperSize.AutoSize = True
        lblPaperSize.Location = New Point(34, 70)
        lblPaperSize.Name = "lblPaperSize"
        lblPaperSize.Size = New Size(57, 15)
        lblPaperSize.TabIndex = 0
        lblPaperSize.Text = "Paper Size"
        '
        'lblPrinterName
        '
        lblPrinterName.AutoSize = True
        lblPrinterName.Location = New Point(34, 22)
        lblPrinterName.Name = "lblPrinterName"
        lblPrinterName.Size = New Size(71, 15)
        lblPrinterName.TabIndex = 0
        lblPrinterName.Text = "Printer Name"
        '
        'grpReset
        '
        grpReset.BackColor = Color.MistyRose
        grpReset.Controls.Add(btnResetData)
        grpReset.Location = New Point(12, 439)
        grpReset.Name = "grpReset"
        grpReset.Size = New Size(826, 86)
        grpReset.TabIndex = 4
        grpReset.TabStop = False
        grpReset.Text = "Reset"
        '
        'btnResetData
        '
        btnResetData.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        btnResetData.ForeColor = Color.Maroon
        btnResetData.Location = New Point(20, 30)
        btnResetData.Name = "btnResetData"
        btnResetData.Size = New Size(248, 40)
        btnResetData.TabIndex = 0
        btnResetData.Text = "Clear All Transactional Data"
        btnResetData.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(373, 538)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 34)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(852, 584)
        Controls.Add(btnClose)
        Controls.Add(grpReset)
        Controls.Add(grpPrinter)
        Controls.Add(grpSecurity)
        Controls.Add(grpDatabase)
        Controls.Add(grpCompany)
        Font = New Font("Segoe UI", 9F)
        Name = "frmSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        grpCompany.ResumeLayout(False)
        grpCompany.PerformLayout()
        grpDatabase.ResumeLayout(False)
        grpSecurity.ResumeLayout(False)
        grpSecurity.PerformLayout()
        grpPrinter.ResumeLayout(False)
        grpPrinter.PerformLayout()
        grpReset.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpCompany As GroupBox
    Friend WithEvents btnSaveCompany As Button
    Friend WithEvents txtCompanyEmail As TextBox
    Friend WithEvents txtCompanyPhone As TextBox
    Friend WithEvents txtCompanyAddress As TextBox
    Friend WithEvents txtCompanyName As TextBox
    Friend WithEvents lblCompanyEmail As Label
    Friend WithEvents lblCompanyPhone As Label
    Friend WithEvents lblCompanyAddress As Label
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents grpDatabase As GroupBox
    Friend WithEvents btnRestore As Button
    Friend WithEvents btnBackup As Button
    Friend WithEvents grpSecurity As GroupBox
    Friend WithEvents btnChangePassword As Button
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents txtCurrentPassword As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents lblCurrentPassword As Label
    Friend WithEvents grpPrinter As GroupBox
    Friend WithEvents btnTestPrint As Button
    Friend WithEvents btnSavePrinter As Button
    Friend WithEvents cboPaperSize As ComboBox
    Friend WithEvents txtPrinterName As TextBox
    Friend WithEvents lblPaperSize As Label
    Friend WithEvents lblPrinterName As Label
    Friend WithEvents grpReset As GroupBox
    Friend WithEvents btnResetData As Button
    Friend WithEvents btnClose As Button
End Class
