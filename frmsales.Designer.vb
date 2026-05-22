<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsales
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
        components = New ComponentModel.Container()
        pnlTop = New Panel()
        lblDateTime = New Label()
        lblInvoiceNo = New Label()
        lblTitle = New Label()
        pnlLeft = New Panel()
        lblQty = New Label()
        numQty = New NumericUpDown()
        txtProductSearch = New TextBox()
        lblProductSearch = New Label()
        dgvSaleItems = New DataGridView()
        colBarcode = New DataGridViewTextBoxColumn()
        colProductName = New DataGridViewTextBoxColumn()
        colQty = New DataGridViewTextBoxColumn()
        colRate = New DataGridViewTextBoxColumn()
        colDiscount = New DataGridViewTextBoxColumn()
        colAmount = New DataGridViewTextBoxColumn()
        colProductID = New DataGridViewTextBoxColumn()
        btnAddItem = New Button()
        txtBarcode = New TextBox()
        lblBarcode = New Label()
        pnlRight = New Panel()
        btnNewSale = New Button()
        btnClose = New Button()
        btnClear = New Button()
        btnHold = New Button()
        btnSave = New Button()
        lblChangeCaption = New Label()
        lblChange = New Label()
        txtPaidAmount = New TextBox()
        lblPaidAmount = New Label()
        rbBank = New RadioButton()
        rbCredit = New RadioButton()
        rbCash = New RadioButton()
        lblPaymentMethod = New Label()
        lblNetAmount = New Label()
        lblNetCaption = New Label()
        lblDiscountTotal = New Label()
        lblDiscountCaption = New Label()
        lblSubTotal = New Label()
        lblSubTotalCaption = New Label()
        cboCustomer = New ComboBox()
        lblCustomer = New Label()
        tmrClock = New Timer(components)
        pnlTop.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(numQty, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvSaleItems, ComponentModel.ISupportInitialize).BeginInit()
        pnlRight.SuspendLayout()
        SuspendLayout()
        '
        'pnlTop
        '
        pnlTop.BackColor = Color.Navy
        pnlTop.Controls.Add(lblDateTime)
        pnlTop.Controls.Add(lblInvoiceNo)
        pnlTop.Controls.Add(lblTitle)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Location = New Point(0, 0)
        pnlTop.Name = "pnlTop"
        pnlTop.Size = New Size(1224, 80)
        pnlTop.TabIndex = 0
        '
        'lblDateTime
        '
        lblDateTime.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblDateTime.AutoSize = True
        lblDateTime.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        lblDateTime.ForeColor = Color.White
        lblDateTime.Location = New Point(899, 45)
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New Size(90, 19)
        lblDateTime.TabIndex = 0
        lblDateTime.Text = "Date && Time"
        '
        'lblInvoiceNo
        '
        lblInvoiceNo.AutoSize = True
        lblInvoiceNo.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblInvoiceNo.ForeColor = Color.White
        lblInvoiceNo.Location = New Point(20, 44)
        lblInvoiceNo.Name = "lblInvoiceNo"
        lblInvoiceNo.Size = New Size(112, 21)
        lblInvoiceNo.TabIndex = 0
        lblInvoiceNo.Text = "INV-0000-0000"
        '
        'lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(14, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(335, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "POS Sales - Family Choice Shop"
        '
        'pnlLeft
        '
        pnlLeft.BackColor = Color.White
        pnlLeft.BorderStyle = BorderStyle.FixedSingle
        pnlLeft.Controls.Add(lblQty)
        pnlLeft.Controls.Add(numQty)
        pnlLeft.Controls.Add(txtProductSearch)
        pnlLeft.Controls.Add(lblProductSearch)
        pnlLeft.Controls.Add(dgvSaleItems)
        pnlLeft.Controls.Add(btnAddItem)
        pnlLeft.Controls.Add(txtBarcode)
        pnlLeft.Controls.Add(lblBarcode)
        pnlLeft.Location = New Point(12, 93)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(806, 575)
        pnlLeft.TabIndex = 1
        '
        'lblQty
        '
        lblQty.AutoSize = True
        lblQty.Location = New Point(615, 20)
        lblQty.Name = "lblQty"
        lblQty.Size = New Size(26, 15)
        lblQty.TabIndex = 0
        lblQty.Text = "Qty"
        '
        'numQty
        '
        numQty.DecimalPlaces = 2
        numQty.Location = New Point(650, 16)
        numQty.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        numQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numQty.Name = "numQty"
        numQty.Size = New Size(72, 23)
        numQty.TabIndex = 2
        numQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtProductSearch
        '
        txtProductSearch.Location = New Point(121, 53)
        txtProductSearch.Name = "txtProductSearch"
        txtProductSearch.Size = New Size(601, 23)
        txtProductSearch.TabIndex = 3
        '
        'lblProductSearch
        '
        lblProductSearch.AutoSize = True
        lblProductSearch.Location = New Point(24, 57)
        lblProductSearch.Name = "lblProductSearch"
        lblProductSearch.Size = New Size(87, 15)
        lblProductSearch.TabIndex = 0
        lblProductSearch.Text = "Product Search"
        '
        'dgvSaleItems
        '
        dgvSaleItems.AllowUserToAddRows = False
        dgvSaleItems.BackgroundColor = Color.White
        dgvSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSaleItems.Columns.AddRange(New DataGridViewColumn() {colBarcode, colProductName, colQty, colRate, colDiscount, colAmount, colProductID})
        dgvSaleItems.Location = New Point(18, 98)
        dgvSaleItems.Name = "dgvSaleItems"
        dgvSaleItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvSaleItems.Size = New Size(769, 457)
        dgvSaleItems.TabIndex = 5
        '
        'colBarcode
        '
        colBarcode.DataPropertyName = "Barcode"
        colBarcode.HeaderText = "Barcode"
        colBarcode.Name = "colBarcode"
        colBarcode.ReadOnly = True
        colBarcode.Width = 120
        '
        'colProductName
        '
        colProductName.DataPropertyName = "ProductName"
        colProductName.HeaderText = "Product Name"
        colProductName.Name = "colProductName"
        colProductName.ReadOnly = True
        colProductName.Width = 230
        '
        'colQty
        '
        colQty.DataPropertyName = "Qty"
        colQty.HeaderText = "Qty"
        colQty.Name = "colQty"
        colQty.Width = 80
        '
        'colRate
        '
        colRate.DataPropertyName = "Rate"
        colRate.HeaderText = "Rate"
        colRate.Name = "colRate"
        colRate.ReadOnly = True
        colRate.Width = 90
        '
        'colDiscount
        '
        colDiscount.DataPropertyName = "Discount"
        colDiscount.HeaderText = "Discount"
        colDiscount.Name = "colDiscount"
        colDiscount.Width = 90
        '
        'colAmount
        '
        colAmount.DataPropertyName = "Amount"
        colAmount.HeaderText = "Amount"
        colAmount.Name = "colAmount"
        colAmount.ReadOnly = True
        colAmount.Width = 110
        '
        'colProductID
        '
        colProductID.DataPropertyName = "ProductID"
        colProductID.HeaderText = "ProductID"
        colProductID.Name = "colProductID"
        colProductID.Visible = False
        '
        'btnAddItem
        '
        btnAddItem.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnAddItem.Location = New Point(728, 15)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(59, 61)
        btnAddItem.TabIndex = 4
        btnAddItem.Text = "Add"
        btnAddItem.UseVisualStyleBackColor = True
        '
        'txtBarcode
        '
        txtBarcode.Location = New Point(121, 16)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(480, 23)
        txtBarcode.TabIndex = 1
        '
        'lblBarcode
        '
        lblBarcode.AutoSize = True
        lblBarcode.Location = New Point(24, 20)
        lblBarcode.Name = "lblBarcode"
        lblBarcode.Size = New Size(50, 15)
        lblBarcode.TabIndex = 0
        lblBarcode.Text = "Barcode"
        '
        'pnlRight
        '
        pnlRight.BackColor = Color.White
        pnlRight.BorderStyle = BorderStyle.FixedSingle
        pnlRight.Controls.Add(btnNewSale)
        pnlRight.Controls.Add(btnClose)
        pnlRight.Controls.Add(btnClear)
        pnlRight.Controls.Add(btnHold)
        pnlRight.Controls.Add(btnSave)
        pnlRight.Controls.Add(lblChangeCaption)
        pnlRight.Controls.Add(lblChange)
        pnlRight.Controls.Add(txtPaidAmount)
        pnlRight.Controls.Add(lblPaidAmount)
        pnlRight.Controls.Add(rbBank)
        pnlRight.Controls.Add(rbCredit)
        pnlRight.Controls.Add(rbCash)
        pnlRight.Controls.Add(lblPaymentMethod)
        pnlRight.Controls.Add(lblNetAmount)
        pnlRight.Controls.Add(lblNetCaption)
        pnlRight.Controls.Add(lblDiscountTotal)
        pnlRight.Controls.Add(lblDiscountCaption)
        pnlRight.Controls.Add(lblSubTotal)
        pnlRight.Controls.Add(lblSubTotalCaption)
        pnlRight.Controls.Add(cboCustomer)
        pnlRight.Controls.Add(lblCustomer)
        pnlRight.Location = New Point(830, 93)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(382, 575)
        pnlRight.TabIndex = 2
        '
        'btnNewSale
        '
        btnNewSale.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnNewSale.Location = New Point(24, 505)
        btnNewSale.Name = "btnNewSale"
        btnNewSale.Size = New Size(156, 42)
        btnNewSale.TabIndex = 10
        btnNewSale.Text = "New Sale"
        btnNewSale.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClose.Location = New Point(198, 505)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(156, 42)
        btnClose.TabIndex = 11
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        btnClear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnClear.Location = New Point(198, 445)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(156, 42)
        btnClear.TabIndex = 9
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        '
        'btnHold
        '
        btnHold.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold)
        btnHold.Location = New Point(24, 445)
        btnHold.Name = "btnHold"
        btnHold.Size = New Size(156, 42)
        btnHold.TabIndex = 8
        btnHold.Text = "Hold"
        btnHold.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        btnSave.Font = New Font("Segoe UI Semibold", 10.5F, FontStyle.Bold)
        btnSave.Location = New Point(24, 383)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(330, 48)
        btnSave.TabIndex = 7
        btnSave.Text = "Save && Print"
        btnSave.UseVisualStyleBackColor = True
        '
        'lblChangeCaption
        '
        lblChangeCaption.AutoSize = True
        lblChangeCaption.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        lblChangeCaption.Location = New Point(24, 335)
        lblChangeCaption.Name = "lblChangeCaption"
        lblChangeCaption.Size = New Size(61, 20)
        lblChangeCaption.TabIndex = 0
        lblChangeCaption.Text = "Change"
        '
        'lblChange
        '
        lblChange.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblChange.ForeColor = Color.DarkGreen
        lblChange.Location = New Point(181, 333)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(173, 23)
        lblChange.TabIndex = 0
        lblChange.Text = "0.00"
        lblChange.TextAlign = ContentAlignment.MiddleRight
        '
        'txtPaidAmount
        '
        txtPaidAmount.Location = New Point(181, 291)
        txtPaidAmount.Name = "txtPaidAmount"
        txtPaidAmount.Size = New Size(173, 23)
        txtPaidAmount.TabIndex = 6
        txtPaidAmount.Text = "0.00"
        txtPaidAmount.TextAlign = HorizontalAlignment.Right
        '
        'lblPaidAmount
        '
        lblPaidAmount.AutoSize = True
        lblPaidAmount.Location = New Point(24, 295)
        lblPaidAmount.Name = "lblPaidAmount"
        lblPaidAmount.Size = New Size(72, 15)
        lblPaidAmount.TabIndex = 0
        lblPaidAmount.Text = "Paid Amount"
        '
        'rbBank
        '
        rbBank.AutoSize = True
        rbBank.Location = New Point(267, 244)
        rbBank.Name = "rbBank"
        rbBank.Size = New Size(50, 19)
        rbBank.TabIndex = 5
        rbBank.Text = "Bank"
        rbBank.UseVisualStyleBackColor = True
        '
        'rbCredit
        '
        rbCredit.AutoSize = True
        rbCredit.Location = New Point(181, 244)
        rbCredit.Name = "rbCredit"
        rbCredit.Size = New Size(58, 19)
        rbCredit.TabIndex = 4
        rbCredit.Text = "Credit"
        rbCredit.UseVisualStyleBackColor = True
        '
        'rbCash
        '
        rbCash.AutoSize = True
        rbCash.Checked = True
        rbCash.Location = New Point(113, 244)
        rbCash.Name = "rbCash"
        rbCash.Size = New Size(50, 19)
        rbCash.TabIndex = 3
        rbCash.TabStop = True
        rbCash.Text = "Cash"
        rbCash.UseVisualStyleBackColor = True
        '
        'lblPaymentMethod
        '
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Location = New Point(24, 246)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(92, 15)
        lblPaymentMethod.TabIndex = 0
        lblPaymentMethod.Text = "Payment Method"
        '
        'lblNetAmount
        '
        lblNetAmount.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblNetAmount.ForeColor = Color.Maroon
        lblNetAmount.Location = New Point(181, 181)
        lblNetAmount.Name = "lblNetAmount"
        lblNetAmount.Size = New Size(173, 30)
        lblNetAmount.TabIndex = 0
        lblNetAmount.Text = "0.00"
        lblNetAmount.TextAlign = ContentAlignment.MiddleRight
        '
        'lblNetCaption
        '
        lblNetCaption.AutoSize = True
        lblNetCaption.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        lblNetCaption.Location = New Point(24, 187)
        lblNetCaption.Name = "lblNetCaption"
        lblNetCaption.Size = New Size(89, 20)
        lblNetCaption.TabIndex = 0
        lblNetCaption.Text = "Net Amount"
        '
        'lblDiscountTotal
        '
        lblDiscountTotal.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblDiscountTotal.Location = New Point(181, 138)
        lblDiscountTotal.Name = "lblDiscountTotal"
        lblDiscountTotal.Size = New Size(173, 23)
        lblDiscountTotal.TabIndex = 0
        lblDiscountTotal.Text = "0.00"
        lblDiscountTotal.TextAlign = ContentAlignment.MiddleRight
        '
        'lblDiscountCaption
        '
        lblDiscountCaption.AutoSize = True
        lblDiscountCaption.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        lblDiscountCaption.Location = New Point(24, 141)
        lblDiscountCaption.Name = "lblDiscountCaption"
        lblDiscountCaption.Size = New Size(68, 20)
        lblDiscountCaption.TabIndex = 0
        lblDiscountCaption.Text = "Discount"
        '
        'lblSubTotal
        '
        lblSubTotal.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        lblSubTotal.Location = New Point(181, 95)
        lblSubTotal.Name = "lblSubTotal"
        lblSubTotal.Size = New Size(173, 23)
        lblSubTotal.TabIndex = 0
        lblSubTotal.Text = "0.00"
        lblSubTotal.TextAlign = ContentAlignment.MiddleRight
        '
        'lblSubTotalCaption
        '
        lblSubTotalCaption.AutoSize = True
        lblSubTotalCaption.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        lblSubTotalCaption.Location = New Point(24, 98)
        lblSubTotalCaption.Name = "lblSubTotalCaption"
        lblSubTotalCaption.Size = New Size(73, 20)
        lblSubTotalCaption.TabIndex = 0
        lblSubTotalCaption.Text = "Sub Total"
        '
        'cboCustomer
        '
        cboCustomer.DropDownStyle = ComboBoxStyle.DropDownList
        cboCustomer.FormattingEnabled = True
        cboCustomer.Location = New Point(113, 29)
        cboCustomer.Name = "cboCustomer"
        cboCustomer.Size = New Size(241, 23)
        cboCustomer.TabIndex = 0
        '
        'lblCustomer
        '
        lblCustomer.AutoSize = True
        lblCustomer.Location = New Point(24, 33)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(59, 15)
        lblCustomer.TabIndex = 0
        lblCustomer.Text = "Customer"
        '
        'tmrClock
        '
        tmrClock.Interval = 1000
        '
        'frmsales
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1224, 680)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        Controls.Add(pnlTop)
        Font = New Font("Segoe UI", 9F)
        Name = "frmsales"
        StartPosition = FormStartPosition.CenterScreen
        Text = "POS Sales"
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        CType(numQty, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvSaleItems, ComponentModel.ISupportInitialize).EndInit()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblInvoiceNo As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents lblQty As Label
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents txtProductSearch As TextBox
    Friend WithEvents lblProductSearch As Label
    Friend WithEvents dgvSaleItems As DataGridView
    Friend WithEvents btnAddItem As Button
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblBarcode As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents btnNewSale As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnHold As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblChangeCaption As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents txtPaidAmount As TextBox
    Friend WithEvents lblPaidAmount As Label
    Friend WithEvents rbBank As RadioButton
    Friend WithEvents rbCredit As RadioButton
    Friend WithEvents rbCash As RadioButton
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents lblNetAmount As Label
    Friend WithEvents lblNetCaption As Label
    Friend WithEvents lblDiscountTotal As Label
    Friend WithEvents lblDiscountCaption As Label
    Friend WithEvents lblSubTotal As Label
    Friend WithEvents lblSubTotalCaption As Label
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents colBarcode As DataGridViewTextBoxColumn
    Friend WithEvents colProductName As DataGridViewTextBoxColumn
    Friend WithEvents colQty As DataGridViewTextBoxColumn
    Friend WithEvents colRate As DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
    Friend WithEvents colProductID As DataGridViewTextBoxColumn
    Friend WithEvents tmrClock As Timer
End Class
