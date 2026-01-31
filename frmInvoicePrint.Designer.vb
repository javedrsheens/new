<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoicePrint
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
        lblTitle = New Label()
        cboPrintFormat = New ComboBox()
        btnPrint = New Button()
        btnCopy = New Button()
        btnEmail = New Button()
        btnClose = New Button()
        txtInvoicePreview = New TextBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Navy
        Panel1.Controls.Add(lblTitle)
        Panel1.Dock = DockStyle.Top
        Panel1.ForeColor = Color.Moccasin
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(784, 50)
        Panel1.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = SystemColors.Control
        lblTitle.Location = New Point(12, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(200, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Invoice Print Preview"
        ' 
        ' cboPrintFormat
        ' 
        cboPrintFormat.FormattingEnabled = True
        cboPrintFormat.Items.AddRange(New Object() {"Thermal 80mm", "Thermal 58mm", "A4 Format"})
        cboPrintFormat.Location = New Point(12, 60)
        cboPrintFormat.Name = "cboPrintFormat"
        cboPrintFormat.Size = New Size(200, 23)
        cboPrintFormat.TabIndex = 2
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.White
        btnPrint.ForeColor = Color.Black
        btnPrint.Location = New Point(220, 60)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(100, 30)
        btnPrint.TabIndex = 3
        btnPrint.Text = "Print"
        btnPrint.TextAlign = ContentAlignment.MiddleRight
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnCopy
        ' 
        btnCopy.BackColor = Color.White
        btnCopy.ForeColor = Color.Black
        btnCopy.Location = New Point(330, 60)
        btnCopy.Name = "btnCopy"
        btnCopy.Size = New Size(100, 30)
        btnCopy.TabIndex = 3
        btnCopy.Text = "Copy"
        btnCopy.UseVisualStyleBackColor = False
        ' 
        ' btnEmail
        ' 
        btnEmail.BackColor = Color.White
        btnEmail.ForeColor = Color.Black
        btnEmail.Location = New Point(430, 60)
        btnEmail.Name = "btnEmail"
        btnEmail.Size = New Size(100, 30)
        btnEmail.TabIndex = 3
        btnEmail.Text = "Email"
        btnEmail.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.White
        btnClose.ForeColor = Color.Black
        btnClose.Location = New Point(530, 60)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 30)
        btnClose.TabIndex = 3
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' txtInvoicePreview
        ' 
        txtInvoicePreview.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtInvoicePreview.Location = New Point(10, 100)
        txtInvoicePreview.Multiline = True
        txtInvoicePreview.Name = "txtInvoicePreview"
        txtInvoicePreview.ReadOnly = True
        txtInvoicePreview.ScrollBars = ScrollBars.Both
        txtInvoicePreview.Size = New Size(770, 750)
        txtInvoicePreview.TabIndex = 4
        ' 
        ' frmInvoicePrint
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(784, 749)
        Controls.Add(cboPrintFormat)
        Controls.Add(txtInvoicePreview)
        Controls.Add(btnClose)
        Controls.Add(btnEmail)
        Controls.Add(btnCopy)
        Controls.Add(btnPrint)
        Controls.Add(Panel1)
        Name = "frmInvoicePrint"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Print"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents cboPrintFormat As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnCopy As Button
    Private WithEvents btnEmail As Button
    Private WithEvents btnClose As Button
    Friend WithEvents txtInvoicePreview As TextBox
End Class
