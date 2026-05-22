<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesReturn
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
        components = New System.ComponentModel.Container()
        pnlTop = New Panel()
        lblDateTime = New Label()
        lblReturnNo = New Label()
        lblTitle = New Label()
        pnlLeft = New Panel()
        lblQty = New Label()
        numQty = New NumericUpDown()
        txtProductSearch = New TextBox()
        lblProductSearch = New Label()
        dgvReturnItems = New DataGridView()
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
        btnClose = New Button()
        btnClear = New Button()
        btnSave = New Button()
        txtRemarks = New TextBox()
        lblRemarks = New Label()
        cboReturnReason = New ComboBox()
        lblReturnReason = New Label()
        lblNetTotal = New Label()
        lblNetCaption = New Label()
        lblDiscount = New Label()
        lblDiscountCaption = New Label()
        lblSubTotal = New Label()
        lblSubTotalCaption = New Label()
        txtInvoiceRef = New TextBox()
        lblInvoiceRef = New Label()
        cboCustomer = New ComboBox()
        lblCustomer = New Label()
        tmrClock = New Timer(components)
        pnlTop.SuspendLayout()
        pnlLeft.SuspendLayout()
        CType(numQty, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvReturnItems, ComponentModel.ISupportInitialize).BeginInit()
        pnlRight.SuspendLayout()
        SuspendLayout()
        '
        'pnlTop
        '
        pnlTop.BackColor = Color.Navy
        pnlTop.Controls.Add(lblDateTime)
        pnlTop.Controls.Add(lblReturnNo)
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
        lblDateTime.Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        lblDateTime.ForeColor = Color.White
        lblDateTime.Location = New Point(912, 46)
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New Size(90, 19)
        lblDateTime.TabIndex = 2
        lblDateTime.Text = "Date && Time"
        '
        'lblReturnNo
        '
        lblReturnNo.AutoSize = True
        lblReturnNo.Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold)
        lblReturnNo.ForeColor = Color.White
        lblReturnNo.Location = New Point(20, 44)
        lblReturnNo.Name = "lblReturnNo"
        lblReturnNo.Size = New Size(121, 21)
        lblReturnNo.TabIndex = 1
        lblReturnNo.Text = "RET-0000-0000"
        '
        'lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18.0!, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(14, 9)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(388, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Sales Return - Family Choice Shop"
        '
        'pnlLeft
        '
        pnlLeft.BackColor = Color.White
        pnlLeft.BorderStyle = BorderStyle.FixedSingle
        pnlLeft.Controls.Add(lblQty)
        pnlLeft.Controls.Add(numQty)
        pnlLeft.Controls.Add(txtProductSearch)
        pnlLeft.Controls.Add(lblProductSearch)
        pnlLeft.Controls.Add(dgvReturnItems)
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
        'dgvReturnItems
        '
        dgvReturnItems.AllowUserToAddRows = False
        dgvReturnItems.BackgroundColor = Color.White
        dgvReturnItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvReturnItems.Columns.AddRange(New DataGridViewColumn() {colBarcode, colProductName, colQty, colRate, colDiscount, colAmount, colProductID})
        dgvReturnItems.Location = New Point(18, 98)
        dgvReturnItems.Name = "dgvReturnItems"
        dgvReturnItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvReturnItems.Size = New Size(769, 457)
        dgvReturnItems.TabIndex = 5
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
        colDiscount.ReadOnly = True
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
        btnAddItem.Font = New Font("Segoe UI Semibold", 9.75!, FontStyle.Bold)
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
        pnlRight.Controls.Add(btnClose)
        pnlRight.Controls.Add(btnClear)
        pnlRight.Controls.Add(btnSave)
        pnlRight.Controls.Add(txtRemarks)
        pnlRight.Controls.Add(lblRemarks)
        pnlRight.Controls.Add(cboReturnReason)
        pnlRight.Controls.Add(lblReturnReason)
        pnlRight.Controls.Add(lblNetTotal)
        pnlRight.Controls.Add(lblNetCaption)
        pnlRight.Controls.Add(lblDiscount)
        pnlRight.Controls.Add(lblDiscountCaption)
        pnlRight.Controls.Add(lblSubTotal)
        pnlRight.Controls.Add(lblSubTotalCaption)
        pnlRight.Controls.Add(txtInvoiceRef)
        pnlRight.Controls.Add(lblInvoiceRef)
        pnlRight.Controls.Add(cboCustomer)
        pnlRight.Controls.Add(lblCustomer)
        pnlRight.Location = New Point(830, 93)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(382, 575)
        pnlRight.TabIndex = 2
        '
        'btnClose
        '
        btnClose.Font = New Font("Segoe UI Semibold", 9.75!, FontStyle.Bold)
        btnClose.Location = New Point(198, 505)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(156, 42)
        btnClose.TabIndex = 10
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        btnClear.Font = New Font("Segoe UI Semibold", 9.75!, FontStyle.Bold)
        btnClear.Location = New Point(198, 445)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(156, 42)
        btnClear.TabIndex = 9
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        btnSave.Font = New Font("Segoe UI Semibold", 9.75!, FontStyle.Bold)
        btnSave.Location = New Point(24, 445)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(156, 102)
        btnSave.TabIndex = 8
        btnSave.Text = "Save Return"
        btnSave.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        txtRemarks.Location = New Point(24, 322)
        txtRemarks.Multiline = True
        txtRemarks.Name = "txtRemarks"
        txtRemarks.ScrollBars = ScrollBars.Vertical
        txtRemarks.Size = New Size(330, 99)
        txtRemarks.TabIndex = 7
        '
        'lblRemarks
        '
        lblRemarks.AutoSize = True
        lblRemarks.Font = New Font("Segoe UI", 9.75!, FontStyle.Bold)
        lblRemarks.Location = New Point(24, 302)
        lblRemarks.Name = "lblRemarks"
        lblRemarks.Size = New Size(59, 17)
        lblRemarks.TabIndex = 0
        lblRemarks.Text = "Remarks"
        '
        'cboReturnReason
        '
        cboReturnReason.DropDownStyle = ComboBoxStyle.DropDownList
        cboReturnReason.FormattingEnabled = True
        cboReturnReason.Location = New Point(24, 265)
        cboReturnReason.Name = "cboReturnReason"
        cboReturnReason.Size = New Size(330, 23)
        cboReturnReason.TabIndex = 6
        '
        'lblReturnReason
        '
        lblReturnReason.AutoSize = True
        lblReturnReason.Font = New Font("Segoe UI", 9.75!, FontStyle.Bold)
        lblReturnReason.Location = New Point(24, 245)
        lblReturnReason.Name = "lblReturnReason"
        lblReturnReason.Size = New Size(96, 17)
        lblReturnReason.TabIndex = 0
        lblReturnReason.Text = "Return Reason"
        '
        'lblNetTotal
        '
        lblNetTotal.AutoSize = True
        lblNetTotal.Font = New Font("Segoe UI", 21.75!, FontStyle.Bold)
        lblNetTotal.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        lblNetTotal.Location = New Point(178, 191)
        lblNetTotal.Name = "lblNetTotal"
        lblNetTotal.Size = New Size(76, 40)
        lblNetTotal.TabIndex = 0
        lblNetTotal.Text = "0.00"
        '
        'lblNetCaption
        '
        lblNetCaption.AutoSize = True
        lblNetCaption.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblNetCaption.Location = New Point(24, 202)
        lblNetCaption.Name = "lblNetCaption"
        lblNetCaption.Size = New Size(79, 21)
        lblNetCaption.TabIndex = 0
        lblNetCaption.Text = "Net Total"
        '
        'lblDiscount
        '
        lblDiscount.AutoSize = True
        lblDiscount.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblDiscount.Location = New Point(178, 156)
        lblDiscount.Name = "lblDiscount"
        lblDiscount.Size = New Size(42, 21)
        lblDiscount.TabIndex = 0
        lblDiscount.Text = "0.00"
        '
        'lblDiscountCaption
        '
        lblDiscountCaption.AutoSize = True
        lblDiscountCaption.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblDiscountCaption.Location = New Point(24, 156)
        lblDiscountCaption.Name = "lblDiscountCaption"
        lblDiscountCaption.Size = New Size(74, 21)
        lblDiscountCaption.TabIndex = 0
        lblDiscountCaption.Text = "Discount"
        '
        'lblSubTotal
        '
        lblSubTotal.AutoSize = True
        lblSubTotal.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblSubTotal.Location = New Point(178, 121)
        lblSubTotal.Name = "lblSubTotal"
        lblSubTotal.Size = New Size(42, 21)
        lblSubTotal.TabIndex = 0
        lblSubTotal.Text = "0.00"
        '
        'lblSubTotalCaption
        '
        lblSubTotalCaption.AutoSize = True
        lblSubTotalCaption.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblSubTotalCaption.Location = New Point(24, 121)
        lblSubTotalCaption.Name = "lblSubTotalCaption"
        lblSubTotalCaption.Size = New Size(76, 21)
        lblSubTotalCaption.TabIndex = 0
        lblSubTotalCaption.Text = "Sub Total"
        '
        'txtInvoiceRef
        '
        txtInvoiceRef.Location = New Point(24, 82)
        txtInvoiceRef.Name = "txtInvoiceRef"
        txtInvoiceRef.Size = New Size(330, 23)
        txtInvoiceRef.TabIndex = 5
        '
        'lblInvoiceRef
        '
        lblInvoiceRef.AutoSize = True
        lblInvoiceRef.Font = New Font("Segoe UI", 9.75!, FontStyle.Bold)
        lblInvoiceRef.Location = New Point(24, 62)
        lblInvoiceRef.Name = "lblInvoiceRef"
        lblInvoiceRef.Size = New Size(112, 17)
        lblInvoiceRef.TabIndex = 0
        lblInvoiceRef.Text = "Original Invoice #"
        '
        'cboCustomer
        '
        cboCustomer.DropDownStyle = ComboBoxStyle.DropDownList
        cboCustomer.FormattingEnabled = True
        cboCustomer.Location = New Point(24, 31)
        cboCustomer.Name = "cboCustomer"
        cboCustomer.Size = New Size(330, 23)
        cboCustomer.TabIndex = 4
        '
        'lblCustomer
        '
        lblCustomer.AutoSize = True
        lblCustomer.Font = New Font("Segoe UI", 9.75!, FontStyle.Bold)
        lblCustomer.Location = New Point(24, 11)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(65, 17)
        lblCustomer.TabIndex = 0
        lblCustomer.Text = "Customer"
        '
        'tmrClock
        '
        tmrClock.Interval = 1000
        '
        'frmSalesReturn
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1224, 681)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        Controls.Add(pnlTop)
        Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "frmSalesReturn"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sales Return"
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        CType(numQty, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvReturnItems, ComponentModel.ISupportInitialize).EndInit()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblReturnNo As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents lblQty As Label
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents txtProductSearch As TextBox
    Friend WithEvents lblProductSearch As Label
    Friend WithEvents dgvReturnItems As DataGridView
    Friend WithEvents colBarcode As DataGridViewTextBoxColumn
    Friend WithEvents colProductName As DataGridViewTextBoxColumn
    Friend WithEvents colQty As DataGridViewTextBoxColumn
    Friend WithEvents colRate As DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
    Friend WithEvents colProductID As DataGridViewTextBoxColumn
    Friend WithEvents btnAddItem As Button
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents lblBarcode As Label
    Friend WithEvents pnlRight As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents cboReturnReason As ComboBox
    Friend WithEvents lblReturnReason As Label
    Friend WithEvents lblNetTotal As Label
    Friend WithEvents lblNetCaption As Label
    Friend WithEvents lblDiscount As Label
    Friend WithEvents lblDiscountCaption As Label
    Friend WithEvents lblSubTotal As Label
    Friend WithEvents lblSubTotalCaption As Label
    Friend WithEvents txtInvoiceRef As TextBox
    Friend WithEvents lblInvoiceRef As Label
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents tmrClock As Timer
End Class
