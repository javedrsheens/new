<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenseCategories
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        grpCategoryDetails = New GroupBox()
        btnCLEAR = New Button()
        btnUPDATE = New Button()
        btnSave = New Button()
        chkActive = New CheckBox()
        txtDescription = New TextBox()
        txtCategoryName = New TextBox()
        Label1 = New Label()
        lblCategoryName = New Label()
        dgvCategories = New DataGridView()
        panelInfo = New Panel()
        TotalCategories = New Label()
        btnClose = New Button()
        lblTotalCategories = New Label()
        grpCategoryDetails.SuspendLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).BeginInit()
        panelInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' grpCategoryDetails
        ' 
        grpCategoryDetails.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        grpCategoryDetails.Controls.Add(btnCLEAR)
        grpCategoryDetails.Controls.Add(btnUPDATE)
        grpCategoryDetails.Controls.Add(btnSave)
        grpCategoryDetails.Controls.Add(chkActive)
        grpCategoryDetails.Controls.Add(txtDescription)
        grpCategoryDetails.Controls.Add(txtCategoryName)
        grpCategoryDetails.Controls.Add(Label1)
        grpCategoryDetails.Controls.Add(lblCategoryName)
        grpCategoryDetails.Location = New Point(10, 10)
        grpCategoryDetails.Name = "grpCategoryDetails"
        grpCategoryDetails.Size = New Size(670, 160)
        grpCategoryDetails.TabIndex = 0
        grpCategoryDetails.TabStop = False
        grpCategoryDetails.Text = "GroupBox1"
        ' 
        ' btnCLEAR
        ' 
        btnCLEAR.Location = New Point(201, 101)
        btnCLEAR.Name = "btnCLEAR"
        btnCLEAR.Size = New Size(68, 48)
        btnCLEAR.TabIndex = 8
        btnCLEAR.Text = "🔄 Clear"
        btnCLEAR.UseVisualStyleBackColor = True
        ' 
        ' btnUPDATE
        ' 
        btnUPDATE.Location = New Point(111, 101)
        btnUPDATE.Name = "btnUPDATE"
        btnUPDATE.Size = New Size(68, 48)
        btnUPDATE.TabIndex = 6
        btnUPDATE.Text = "✏️ Update"
        btnUPDATE.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(37, 101)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(68, 48)
        btnSave.TabIndex = 7
        btnSave.Text = "💾 Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Location = New Point(291, 21)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(85, 19)
        chkActive.TabIndex = 3
        chkActive.Text = "CheckBox1"
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(111, 57)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(155, 23)
        txtDescription.TabIndex = 2
        ' 
        ' txtCategoryName
        ' 
        txtCategoryName.Location = New Point(111, 19)
        txtCategoryName.Name = "txtCategoryName"
        txtCategoryName.Size = New Size(155, 23)
        txtCategoryName.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(13, 57)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 15)
        Label1.TabIndex = 0
        Label1.Text = "Description"
        ' 
        ' lblCategoryName
        ' 
        lblCategoryName.AutoSize = True
        lblCategoryName.Location = New Point(13, 26)
        lblCategoryName.Name = "lblCategoryName"
        lblCategoryName.Size = New Size(90, 15)
        lblCategoryName.TabIndex = 0
        lblCategoryName.Text = "Category Name"
        ' 
        ' dgvCategories
        ' 
        DataGridViewCellStyle4.BackColor = Color.LightGray
        dgvCategories.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        dgvCategories.BackgroundColor = Color.White
        dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCategories.Location = New Point(10, 200)
        dgvCategories.Name = "dgvCategories"
        dgvCategories.ReadOnly = True
        dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCategories.Size = New Size(670, 220)
        dgvCategories.TabIndex = 1
        ' 
        ' panelInfo
        ' 
        panelInfo.Controls.Add(lblTotalCategories)
        panelInfo.Controls.Add(TotalCategories)
        panelInfo.Location = New Point(10, 430)
        panelInfo.Name = "panelInfo"
        panelInfo.Size = New Size(580, 30)
        panelInfo.TabIndex = 2
        ' 
        ' TotalCategories
        ' 
        TotalCategories.AutoSize = True
        TotalCategories.Location = New Point(13, 7)
        TotalCategories.Name = "TotalCategories"
        TotalCategories.Size = New Size(88, 15)
        TotalCategories.TabIndex = 0
        TotalCategories.Text = "TotalCategories"
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(594, 430)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(84, 30)
        btnClose.TabIndex = 3
        btnClose.Text = "❌ Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblTotalCategories
        ' 
        lblTotalCategories.AutoSize = True
        lblTotalCategories.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalCategories.Location = New Point(111, 7)
        lblTotalCategories.Name = "lblTotalCategories"
        lblTotalCategories.Size = New Size(135, 17)
        lblTotalCategories.TabIndex = 0
        lblTotalCategories.Text = """Total Categories: 0"""
        ' 
        ' frmExpenseCategories
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(684, 461)
        Controls.Add(btnClose)
        Controls.Add(panelInfo)
        Controls.Add(dgvCategories)
        Controls.Add(grpCategoryDetails)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmExpenseCategories"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Manage Expense Categories"
        grpCategoryDetails.ResumeLayout(False)
        grpCategoryDetails.PerformLayout()
        CType(dgvCategories, ComponentModel.ISupportInitialize).EndInit()
        panelInfo.ResumeLayout(False)
        panelInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents grpCategoryDetails As GroupBox
    Friend WithEvents lblCategoryName As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtCategoryName As TextBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents btnUPDATE As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCLEAR As Button
    Friend WithEvents dgvCategories As DataGridView
    Friend WithEvents panelInfo As Panel
    Friend WithEvents TotalCategories As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTotalCategories As Label
End Class
