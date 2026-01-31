<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpurchasereturn
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
        txtUnitPrice = New TextBox()
        lblDiscountLabel = New Label()
        lblDiscount = New Label()
        btnRemoveItem = New Button()
        btnPrint = New Button()
        btnAddProduct = New Button()
        Label6 = New Label()
        txtProductID = New TextBox()
        btnSave = New Button()
        txtQuantity = New TextBox()
        lblTaxLabel = New Label()
        btnClearAll = New Button()
        lblSubtotal = New Label()
        lblSubtotalLabel = New Label()
        btnSearchProduct = New Button()
        GroupBox1 = New GroupBox()
        lblTax = New Label()
        lblNetTotal = New Label()
        lblNetTotalLabel = New Label()
        Label2 = New Label()
        txtProductName = New TextBox()
        lblProductName = New Label()
        lblQuantity = New Label()
        dgvPurchaseItems = New DataGridView()
        grpPurchaseHeader = New GroupBox()
        TextBox1 = New TextBox()
        Panel1 = New Panel()
        btnminimize = New Button()
        btnClose = New Button()
        btnDeletePurchase = New Button()
        btnEditPurchase = New Button()
        Label1 = New Label()
        btnPrintBarcodes = New Button()
        txtNotes = New TextBox()
        txtDeletePurchaseNo = New TextBox()
        cboPaymentStatus = New ComboBox()
        lblPaymentStatus = New Label()
        cboSupplier = New ComboBox()
        lblSupplier = New Label()
        dtpPurchaseDate = New DateTimePicker()
        Label3 = New Label()
        lblPurchaseDate = New Label()
        btnAddSupplier = New Button()
        btnGeneratePurchaseNo = New Button()
        txtPurchaseNo = New TextBox()
        lblPurchaseNo = New Label()
        panelSummary = New Panel()
        GroupBox1.SuspendLayout()
        CType(dgvPurchaseItems, ComponentModel.ISupportInitialize).BeginInit()
        grpPurchaseHeader.SuspendLayout()
        panelSummary.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtUnitPrice
        ' 
        txtUnitPrice.Location = New Point(90, 285)
        txtUnitPrice.Name = "txtUnitPrice"
        txtUnitPrice.Size = New Size(150, 23)
        txtUnitPrice.TabIndex = 45
        ' 
        ' lblDiscountLabel
        ' 
        lblDiscountLabel.AutoSize = True
        lblDiscountLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiscountLabel.Location = New Point(15, 16)
        lblDiscountLabel.Name = "lblDiscountLabel"
        lblDiscountLabel.Size = New Size(63, 17)
        lblDiscountLabel.TabIndex = 4
        lblDiscountLabel.Text = "Discount"
        ' 
        ' lblDiscount
        ' 
        lblDiscount.AutoSize = True
        lblDiscount.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiscount.Location = New Point(98, 16)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(33, 17)
        lblDiscount.TabIndex = 5
        lblDiscount.Text = "0.00"
        ' 
        ' btnRemoveItem
        ' 
        btnRemoveItem.Font = New Font("Segoe UI", 12F)
        btnRemoveItem.Location = New Point(-4, 461)
        btnRemoveItem.Name = "btnRemoveItem"
        btnRemoveItem.Size = New Size(247, 50)
        btnRemoveItem.TabIndex = 36
        btnRemoveItem.Text = "RemoveItem"
        btnRemoveItem.UseVisualStyleBackColor = True
        ' 
        ' btnPrint
        ' 
        btnPrint.Font = New Font("Segoe UI", 12F)
        btnPrint.Location = New Point(-4, 531)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(247, 50)
        btnPrint.TabIndex = 43
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = True
        ' 
        ' btnAddProduct
        ' 
        btnAddProduct.Font = New Font("Segoe UI", 12F)
        btnAddProduct.Location = New Point(-4, 321)
        btnAddProduct.Name = "btnAddProduct"
        btnAddProduct.Size = New Size(247, 50)
        btnAddProduct.TabIndex = 37
        btnAddProduct.Text = "Add"
        btnAddProduct.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(-4, 157)
        Label6.Name = "Label6"
        Label6.Size = New Size(71, 30)
        Label6.TabIndex = 32
        Label6.Text = " Product ID/" & vbCrLf & " Barcode:"
        ' 
        ' txtProductID
        ' 
        txtProductID.Location = New Point(90, 165)
        txtProductID.Name = "txtProductID"
        txtProductID.Size = New Size(150, 23)
        txtProductID.TabIndex = 35
        ' 
        ' btnSave
        ' 
        btnSave.Font = New Font("Segoe UI", 12F)
        btnSave.Location = New Point(-4, 391)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(247, 50)
        btnSave.TabIndex = 39
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(90, 245)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(150, 23)
        txtQuantity.TabIndex = 42
        ' 
        ' lblTaxLabel
        ' 
        lblTaxLabel.AutoSize = True
        lblTaxLabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTaxLabel.Location = New Point(26, 33)
        lblTaxLabel.Name = "lblTaxLabel"
        lblTaxLabel.Size = New Size(29, 17)
        lblTaxLabel.TabIndex = 2
        lblTaxLabel.Text = "Tax"
        ' 
        ' btnClearAll
        ' 
        btnClearAll.Font = New Font("Segoe UI", 12F)
        btnClearAll.Location = New Point(-7, 601)
        btnClearAll.Name = "btnClearAll"
        btnClearAll.Size = New Size(253, 53)
        btnClearAll.TabIndex = 41
        btnClearAll.Text = "ClearAll"
        btnClearAll.UseVisualStyleBackColor = True
        ' 
        ' lblSubtotal
        ' 
        lblSubtotal.AutoSize = True
        lblSubtotal.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSubtotal.Location = New Point(15, 71)
        lblSubtotal.Name = "lblSubtotal"
        lblSubtotal.Size = New Size(55, 30)
        lblSubtotal.TabIndex = 1
        lblSubtotal.Text = "0.00"
        ' 
        ' lblSubtotalLabel
        ' 
        lblSubtotalLabel.AutoSize = True
        lblSubtotalLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSubtotalLabel.Location = New Point(6, 50)
        lblSubtotalLabel.Name = "lblSubtotalLabel"
        lblSubtotalLabel.Size = New Size(75, 21)
        lblSubtotalLabel.TabIndex = 0
        lblSubtotalLabel.Text = "Subtotal"
        ' 
        ' btnSearchProduct
        ' 
        btnSearchProduct.Location = New Point(158, 133)
        btnSearchProduct.Name = "btnSearchProduct"
        btnSearchProduct.Size = New Size(80, 25)
        btnSearchProduct.TabIndex = 38
        btnSearchProduct.Text = "Search"
        btnSearchProduct.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lblDiscountLabel)
        GroupBox1.Controls.Add(lblDiscount)
        GroupBox1.Controls.Add(lblTaxLabel)
        GroupBox1.Controls.Add(lblSubtotal)
        GroupBox1.Controls.Add(lblSubtotalLabel)
        GroupBox1.Controls.Add(lblTax)
        GroupBox1.Location = New Point(32, 374)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(80, 124)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        GroupBox1.Text = "GroupBox1"
        GroupBox1.Visible = False
        ' 
        ' lblTax
        ' 
        lblTax.AutoSize = True
        lblTax.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTax.Location = New Point(98, 33)
        lblTax.Name = "lblTax"
        lblTax.Size = New Size(33, 17)
        lblTax.TabIndex = 3
        lblTax.Text = "0.00"
        ' 
        ' lblNetTotal
        ' 
        lblNetTotal.AutoSize = True
        lblNetTotal.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNetTotal.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        lblNetTotal.Location = New Point(5, 183)
        lblNetTotal.Name = "lblNetTotal"
        lblNetTotal.Size = New Size(76, 40)
        lblNetTotal.TabIndex = 7
        lblNetTotal.Text = "0.00"
        ' 
        ' lblNetTotalLabel
        ' 
        lblNetTotalLabel.AutoSize = True
        lblNetTotalLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNetTotalLabel.Location = New Point(38, 24)
        lblNetTotalLabel.Name = "lblNetTotalLabel"
        lblNetTotalLabel.Size = New Size(76, 21)
        lblNetTotalLabel.TabIndex = 6
        lblNetTotalLabel.Text = "NetTotal"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(13, 286)
        Label2.Name = "Label2"
        Label2.Size = New Size(33, 15)
        Label2.TabIndex = 44
        Label2.Text = "Price"
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(90, 205)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(150, 23)
        txtProductName.TabIndex = 40
        ' 
        ' lblProductName
        ' 
        lblProductName.AutoSize = True
        lblProductName.Location = New Point(-7, 206)
        lblProductName.Name = "lblProductName"
        lblProductName.Size = New Size(81, 15)
        lblProductName.TabIndex = 33
        lblProductName.Text = "ProductName"
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(3, 246)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(53, 15)
        lblQuantity.TabIndex = 34
        lblQuantity.Text = "Quantity"
        ' 
        ' dgvPurchaseItems
        ' 
        dgvPurchaseItems.BackgroundColor = Color.White
        dgvPurchaseItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPurchaseItems.Location = New Point(353, 129)
        dgvPurchaseItems.Name = "dgvPurchaseItems"
        dgvPurchaseItems.Size = New Size(832, 526)
        dgvPurchaseItems.TabIndex = 30
        ' 
        ' grpPurchaseHeader
        ' 
        grpPurchaseHeader.BackColor = Color.DodgerBlue
        grpPurchaseHeader.Controls.Add(TextBox1)
        grpPurchaseHeader.Controls.Add(Panel1)
        grpPurchaseHeader.Controls.Add(btnminimize)
        grpPurchaseHeader.Controls.Add(btnClose)
        grpPurchaseHeader.Controls.Add(btnDeletePurchase)
        grpPurchaseHeader.Controls.Add(btnEditPurchase)
        grpPurchaseHeader.Controls.Add(Label1)
        grpPurchaseHeader.Controls.Add(btnPrintBarcodes)
        grpPurchaseHeader.Controls.Add(txtNotes)
        grpPurchaseHeader.Controls.Add(txtDeletePurchaseNo)
        grpPurchaseHeader.Controls.Add(cboPaymentStatus)
        grpPurchaseHeader.Controls.Add(lblPaymentStatus)
        grpPurchaseHeader.Controls.Add(cboSupplier)
        grpPurchaseHeader.Controls.Add(lblSupplier)
        grpPurchaseHeader.Controls.Add(dtpPurchaseDate)
        grpPurchaseHeader.Controls.Add(Label3)
        grpPurchaseHeader.Controls.Add(lblPurchaseDate)
        grpPurchaseHeader.Controls.Add(btnAddSupplier)
        grpPurchaseHeader.Controls.Add(btnGeneratePurchaseNo)
        grpPurchaseHeader.Controls.Add(txtPurchaseNo)
        grpPurchaseHeader.Controls.Add(lblPurchaseNo)
        grpPurchaseHeader.FlatStyle = FlatStyle.Popup
        grpPurchaseHeader.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpPurchaseHeader.Location = New Point(-4, 6)
        grpPurchaseHeader.Name = "grpPurchaseHeader"
        grpPurchaseHeader.Size = New Size(1195, 123)
        grpPurchaseHeader.TabIndex = 29
        grpPurchaseHeader.TabStop = False
        grpPurchaseHeader.Text = "Purchase Details"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(416, 86)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(305, 25)
        TextBox1.TabIndex = 15
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(4, 122)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(249, 553)
        Panel1.TabIndex = 14
        ' 
        ' btnminimize
        ' 
        btnminimize.BackColor = Color.Green
        btnminimize.Location = New Point(1133, 12)
        btnminimize.Name = "btnminimize"
        btnminimize.Size = New Size(25, 25)
        btnminimize.TabIndex = 13
        btnminimize.Text = "---"
        btnminimize.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnClose.Location = New Point(1164, 12)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(28, 25)
        btnClose.TabIndex = 12
        btnClose.Text = "X"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnDeletePurchase
        ' 
        btnDeletePurchase.BackColor = Color.Red
        btnDeletePurchase.Location = New Point(920, 68)
        btnDeletePurchase.Name = "btnDeletePurchase"
        btnDeletePurchase.Size = New Size(105, 50)
        btnDeletePurchase.TabIndex = 12
        btnDeletePurchase.Text = "Delete Invoice"
        btnDeletePurchase.UseVisualStyleBackColor = False
        ' 
        ' btnEditPurchase
        ' 
        btnEditPurchase.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnEditPurchase.Location = New Point(919, 12)
        btnEditPurchase.Name = "btnEditPurchase"
        btnEditPurchase.Size = New Size(105, 50)
        btnEditPurchase.TabIndex = 12
        btnEditPurchase.Text = "Edit Invoice"
        btnEditPurchase.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(372, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 17)
        Label1.TabIndex = 11
        Label1.Text = "Note"
        ' 
        ' btnPrintBarcodes
        ' 
        btnPrintBarcodes.BackColor = Color.Azure
        btnPrintBarcodes.FlatStyle = FlatStyle.Popup
        btnPrintBarcodes.Location = New Point(265, 86)
        btnPrintBarcodes.Name = "btnPrintBarcodes"
        btnPrintBarcodes.Size = New Size(96, 25)
        btnPrintBarcodes.TabIndex = 11
        btnPrintBarcodes.Text = "PrintBarcodes"
        btnPrintBarcodes.UseVisualStyleBackColor = False
        ' 
        ' txtNotes
        ' 
        txtNotes.Location = New Point(416, 57)
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(305, 25)
        txtNotes.TabIndex = 10
        ' 
        ' txtDeletePurchaseNo
        ' 
        txtDeletePurchaseNo.Location = New Point(727, 58)
        txtDeletePurchaseNo.Name = "txtDeletePurchaseNo"
        txtDeletePurchaseNo.Size = New Size(150, 25)
        txtDeletePurchaseNo.TabIndex = 10
        ' 
        ' cboPaymentStatus
        ' 
        cboPaymentStatus.FormattingEnabled = True
        cboPaymentStatus.Location = New Point(103, 86)
        cboPaymentStatus.Name = "cboPaymentStatus"
        cboPaymentStatus.Size = New Size(150, 25)
        cboPaymentStatus.TabIndex = 9
        ' 
        ' lblPaymentStatus
        ' 
        lblPaymentStatus.AutoSize = True
        lblPaymentStatus.Location = New Point(8, 89)
        lblPaymentStatus.Name = "lblPaymentStatus"
        lblPaymentStatus.Size = New Size(62, 17)
        lblPaymentStatus.TabIndex = 8
        lblPaymentStatus.Text = "Payment"
        ' 
        ' cboSupplier
        ' 
        cboSupplier.FormattingEnabled = True
        cboSupplier.Location = New Point(103, 56)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(150, 25)
        cboSupplier.TabIndex = 7
        ' 
        ' lblSupplier
        ' 
        lblSupplier.AutoSize = True
        lblSupplier.Location = New Point(8, 59)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(57, 17)
        lblSupplier.TabIndex = 6
        lblSupplier.Text = "Supplier"
        ' 
        ' dtpPurchaseDate
        ' 
        dtpPurchaseDate.Location = New Point(416, 26)
        dtpPurchaseDate.Name = "dtpPurchaseDate"
        dtpPurchaseDate.Size = New Size(305, 25)
        dtpPurchaseDate.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(749, 34)
        Label3.Name = "Label3"
        Label3.Size = New Size(111, 17)
        Label3.TabIndex = 0
        Label3.Text = "Enter Invoice NO"
        ' 
        ' lblPurchaseDate
        ' 
        lblPurchaseDate.AutoSize = True
        lblPurchaseDate.Location = New Point(371, 32)
        lblPurchaseDate.Name = "lblPurchaseDate"
        lblPurchaseDate.Size = New Size(39, 17)
        lblPurchaseDate.TabIndex = 4
        lblPurchaseDate.Text = "Date:"
        ' 
        ' btnAddSupplier
        ' 
        btnAddSupplier.BackColor = Color.Azure
        btnAddSupplier.FlatStyle = FlatStyle.Popup
        btnAddSupplier.Location = New Point(265, 56)
        btnAddSupplier.Name = "btnAddSupplier"
        btnAddSupplier.Size = New Size(96, 25)
        btnAddSupplier.TabIndex = 3
        btnAddSupplier.Text = "AddSupplier"
        btnAddSupplier.UseVisualStyleBackColor = False
        ' 
        ' btnGeneratePurchaseNo
        ' 
        btnGeneratePurchaseNo.BackColor = Color.Azure
        btnGeneratePurchaseNo.FlatStyle = FlatStyle.Popup
        btnGeneratePurchaseNo.Location = New Point(265, 26)
        btnGeneratePurchaseNo.Name = "btnGeneratePurchaseNo"
        btnGeneratePurchaseNo.Size = New Size(96, 25)
        btnGeneratePurchaseNo.TabIndex = 3
        btnGeneratePurchaseNo.Text = "Generate"""
        btnGeneratePurchaseNo.UseVisualStyleBackColor = False
        ' 
        ' txtPurchaseNo
        ' 
        txtPurchaseNo.Location = New Point(103, 26)
        txtPurchaseNo.Name = "txtPurchaseNo"
        txtPurchaseNo.ReadOnly = True
        txtPurchaseNo.Size = New Size(150, 25)
        txtPurchaseNo.TabIndex = 1
        ' 
        ' lblPurchaseNo
        ' 
        lblPurchaseNo.AutoSize = True
        lblPurchaseNo.Location = New Point(8, 29)
        lblPurchaseNo.Name = "lblPurchaseNo"
        lblPurchaseNo.Size = New Size(88, 17)
        lblPurchaseNo.TabIndex = 0
        lblPurchaseNo.Text = "Purchase No:"
        ' 
        ' panelSummary
        ' 
        panelSummary.BackColor = Color.White
        panelSummary.Controls.Add(GroupBox1)
        panelSummary.Controls.Add(lblNetTotal)
        panelSummary.Controls.Add(lblNetTotalLabel)
        panelSummary.Location = New Point(1030, 128)
        panelSummary.Name = "panelSummary"
        panelSummary.Size = New Size(161, 527)
        panelSummary.TabIndex = 31
        ' 
        ' frmPurchaseReturn
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 661)
        Controls.Add(txtUnitPrice)
        Controls.Add(btnRemoveItem)
        Controls.Add(btnPrint)
        Controls.Add(btnAddProduct)
        Controls.Add(Label6)
        Controls.Add(txtProductID)
        Controls.Add(btnSave)
        Controls.Add(txtQuantity)
        Controls.Add(btnClearAll)
        Controls.Add(btnSearchProduct)
        Controls.Add(Label2)
        Controls.Add(txtProductName)
        Controls.Add(lblProductName)
        Controls.Add(lblQuantity)
        Controls.Add(dgvPurchaseItems)
        Controls.Add(grpPurchaseHeader)
        Controls.Add(panelSummary)
        Name = "frmPurchaseReturn"
        Text = "frmpurchasereturn"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgvPurchaseItems, ComponentModel.ISupportInitialize).EndInit()
        grpPurchaseHeader.ResumeLayout(False)
        grpPurchaseHeader.PerformLayout()
        panelSummary.ResumeLayout(False)
        panelSummary.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents lblDiscountLabel As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents lblTaxLabel As Label
    Friend WithEvents btnClearAll As Button
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents lblSubtotalLabel As Label
    Friend WithEvents btnSearchProduct As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTax As Label
    Friend WithEvents lblNetTotal As Label
    Friend WithEvents lblNetTotalLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents lblProductName As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents dgvPurchaseItems As DataGridView
    Friend WithEvents grpPurchaseHeader As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnminimize As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnDeletePurchase As Button
    Friend WithEvents btnEditPurchase As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPrintBarcodes As Button
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents txtDeletePurchaseNo As TextBox
    Friend WithEvents cboPaymentStatus As ComboBox
    Friend WithEvents lblPaymentStatus As Label
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents dtpPurchaseDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPurchaseDate As Label
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents btnGeneratePurchaseNo As Button
    Friend WithEvents txtPurchaseNo As TextBox
    Friend WithEvents lblPurchaseNo As Label
    Friend WithEvents panelSummary As Panel
End Class
