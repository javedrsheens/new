<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentMethods
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
        lblMethodName = New Label()
        txtMethodName = New TextBox()
        lblDisplayOrder = New Label()
        numDisplayOrder = New NumericUpDown()
        chkIsActive = New CheckBox()
        chkIsCreditMethod = New CheckBox()
        lblNotes = New Label()
        txtNotes = New TextBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnClose = New Button()
        btnDelete = New Button()
        btnEdit = New Button()
        btnAddNew = New Button()
        dgvPaymentMethods = New DataGridView()
        btnRefresh = New Button()
        GroupBox1.SuspendLayout()
        CType(numDisplayOrder, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        CType(dgvPaymentMethods, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(txtNotes)
        GroupBox1.Controls.Add(lblNotes)
        GroupBox1.Controls.Add(chkIsCreditMethod)
        GroupBox1.Controls.Add(chkIsActive)
        GroupBox1.Controls.Add(numDisplayOrder)
        GroupBox1.Controls.Add(lblDisplayOrder)
        GroupBox1.Controls.Add(txtMethodName)
        GroupBox1.Controls.Add(lblMethodName)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(584, 170)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Add new Payment Method"
        ' 
        ' lblMethodName
        ' 
        lblMethodName.AutoSize = True
        lblMethodName.Location = New Point(12, 50)
        lblMethodName.Name = "lblMethodName"
        lblMethodName.Size = New Size(175, 21)
        lblMethodName.TabIndex = 0
        lblMethodName.Text = "PaymentMethodName"
        ' 
        ' txtMethodName
        ' 
        txtMethodName.Location = New Point(196, 44)
        txtMethodName.Name = "txtMethodName"
        txtMethodName.Size = New Size(239, 29)
        txtMethodName.TabIndex = 1
        ' 
        ' lblDisplayOrder
        ' 
        lblDisplayOrder.AutoSize = True
        lblDisplayOrder.Location = New Point(46, 89)
        lblDisplayOrder.Name = "lblDisplayOrder"
        lblDisplayOrder.Size = New Size(105, 21)
        lblDisplayOrder.TabIndex = 2
        lblDisplayOrder.Text = "DisplayOrder"
        ' 
        ' numDisplayOrder
        ' 
        numDisplayOrder.Location = New Point(196, 87)
        numDisplayOrder.Name = "numDisplayOrder"
        numDisplayOrder.Size = New Size(239, 29)
        numDisplayOrder.TabIndex = 3
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Location = New Point(452, 85)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(107, 25)
        chkIsActive.TabIndex = 4
        chkIsActive.Text = "CheckBox1"
        chkIsActive.UseVisualStyleBackColor = True
        ' 
        ' chkIsCreditMethod
        ' 
        chkIsCreditMethod.AutoSize = True
        chkIsCreditMethod.Location = New Point(452, 126)
        chkIsCreditMethod.Name = "chkIsCreditMethod"
        chkIsCreditMethod.Size = New Size(107, 25)
        chkIsCreditMethod.TabIndex = 5
        chkIsCreditMethod.Text = "CheckBox1"
        chkIsCreditMethod.UseVisualStyleBackColor = True
        ' 
        ' lblNotes
        ' 
        lblNotes.AutoSize = True
        lblNotes.Location = New Point(83, 124)
        lblNotes.Name = "lblNotes"
        lblNotes.Size = New Size(54, 21)
        lblNotes.TabIndex = 6
        lblNotes.Text = "Notes"
        ' 
        ' txtNotes
        ' 
        txtNotes.Location = New Point(196, 124)
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(239, 29)
        txtNotes.TabIndex = 7
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = Color.WhiteSmoke
        TableLayoutPanel1.ColumnCount = 5
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.Controls.Add(btnDelete, 2, 0)
        TableLayoutPanel1.Controls.Add(btnEdit, 1, 0)
        TableLayoutPanel1.Controls.Add(btnAddNew, 0, 0)
        TableLayoutPanel1.Controls.Add(btnClose, 3, 0)
        TableLayoutPanel1.Controls.Add(btnRefresh, 4, 0)
        TableLayoutPanel1.Dock = DockStyle.Bottom
        TableLayoutPanel1.Location = New Point(0, 495)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(584, 66)
        TableLayoutPanel1.TabIndex = 4
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.DodgerBlue
        btnClose.FlatStyle = FlatStyle.Popup
        btnClose.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnClose.ForeColor = Color.Black
        btnClose.Location = New Point(351, 3)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(110, 60)
        btnClose.TabIndex = 4
        btnClose.Text = "CLOSE"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.DodgerBlue
        btnDelete.FlatStyle = FlatStyle.Popup
        btnDelete.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnDelete.ForeColor = Color.Black
        btnDelete.Location = New Point(235, 3)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(110, 60)
        btnDelete.TabIndex = 4
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.DodgerBlue
        btnEdit.FlatStyle = FlatStyle.Popup
        btnEdit.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnEdit.ForeColor = Color.Black
        btnEdit.Location = New Point(119, 3)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(110, 60)
        btnEdit.TabIndex = 4
        btnEdit.Text = "EDIT"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnAddNew
        ' 
        btnAddNew.BackColor = Color.DodgerBlue
        btnAddNew.FlatStyle = FlatStyle.Popup
        btnAddNew.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnAddNew.ForeColor = Color.Black
        btnAddNew.Location = New Point(3, 3)
        btnAddNew.Name = "btnAddNew"
        btnAddNew.Size = New Size(110, 60)
        btnAddNew.TabIndex = 4
        btnAddNew.Text = "ADD"
        btnAddNew.UseVisualStyleBackColor = False
        ' 
        ' dgvPaymentMethods
        ' 
        dgvPaymentMethods.AllowUserToAddRows = False
        dgvPaymentMethods.AllowUserToDeleteRows = False
        dgvPaymentMethods.BackgroundColor = Color.White
        dgvPaymentMethods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPaymentMethods.Dock = DockStyle.Fill
        dgvPaymentMethods.Location = New Point(0, 170)
        dgvPaymentMethods.Name = "dgvPaymentMethods"
        dgvPaymentMethods.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPaymentMethods.Size = New Size(584, 325)
        dgvPaymentMethods.TabIndex = 5
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.DodgerBlue
        btnRefresh.FlatStyle = FlatStyle.Popup
        btnRefresh.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnRefresh.ForeColor = Color.Black
        btnRefresh.Location = New Point(467, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(106, 60)
        btnRefresh.TabIndex = 5
        btnRefresh.Text = "REFRESH"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' frmPaymentMethods
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(584, 561)
        Controls.Add(dgvPaymentMethods)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(GroupBox1)
        Name = "frmPaymentMethods"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Payment Methods Management"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(numDisplayOrder, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        CType(dgvPaymentMethods, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtMethodName As TextBox
    Friend WithEvents lblMethodName As Label
    Friend WithEvents lblDisplayOrder As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents chkIsCreditMethod As CheckBox
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents numDisplayOrder As NumericUpDown
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents dgvPaymentMethods As DataGridView
    Friend WithEvents btnRefresh As Button
End Class
