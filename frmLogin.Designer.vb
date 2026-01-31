<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Panel1 = New Panel()
        Label3 = New Label()
        Panel2 = New Panel()
        Label5 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        txtusername = New TextBox()
        txtpassword = New TextBox()
        btnLogin = New Button()
        btnExit = New Button()
        chkShowPassword = New CheckBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Purple
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(422, 56)
        Panel1.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(3, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(162, 25)
        Label3.TabIndex = 0
        Label3.Text = "Plz Enter Your ID"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Purple
        Panel2.Controls.Add(Label5)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 514)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(422, 42)
        Panel2.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.ButtonFace
        Label5.Location = New Point(0, 16)
        Label5.Name = "Label5"
        Label5.Size = New Size(170, 17)
        Label5.TabIndex = 0
        Label5.Text = "Develpor:       javed Nawaz"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 152)
        Label1.Name = "Label1"
        Label1.Size = New Size(118, 25)
        Label1.TabIndex = 2
        Label1.Text = "USERNAME:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(12, 200)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 25)
        Label2.TabIndex = 2
        Label2.Text = "PASSWORD:"
        ' 
        ' txtusername
        ' 
        txtusername.Location = New Point(149, 154)
        txtusername.Name = "txtusername"
        txtusername.Size = New Size(189, 23)
        txtusername.TabIndex = 0
        ' 
        ' txtpassword
        ' 
        txtpassword.Location = New Point(149, 202)
        txtpassword.Name = "txtpassword"
        txtpassword.Size = New Size(189, 23)
        txtpassword.TabIndex = 1
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.Lime
        btnLogin.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnLogin.Location = New Point(59, 303)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(135, 39)
        btnLogin.TabIndex = 2
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnExit.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnExit.Location = New Point(215, 303)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(135, 39)
        btnExit.TabIndex = 3
        btnExit.Text = "EXIT"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' chkShowPassword
        ' 
        chkShowPassword.AutoSize = True
        chkShowPassword.Location = New Point(307, 234)
        chkShowPassword.Name = "chkShowPassword"
        chkShowPassword.Size = New Size(85, 19)
        chkShowPassword.TabIndex = 5
        chkShowPassword.Text = "CheckBox1"
        chkShowPassword.UseVisualStyleBackColor = True
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(422, 556)
        Controls.Add(chkShowPassword)
        Controls.Add(btnExit)
        Controls.Add(btnLogin)
        Controls.Add(txtpassword)
        Controls.Add(txtusername)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmLogin"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtusername As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
End Class
