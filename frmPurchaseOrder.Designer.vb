<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseOrder
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
        pnlHeader = New Panel()
        cboSupplier = New ComboBox()
        lblSupplier = New Label()
        dtpPODate = New DateTimePicker()
        lblPODate = New Label()
        lblPONumber = New Label()
        lblPONumberCaption = New Label()
        pnlSelection = New Panel()
        btnSearchProduct = New Button()
        txtProductSearch = New TextBox()
        lblProductSearch = New Label()
        cboFilterCategory = New ComboBox()
        lblFilterCategory = New Label()
        dgvProducts = New DataGridView()
        pnlCart = New Panel()
        btnRemoveFromCart = New Button()
        btnAddToCart = New Button()
        dgvCart = New DataGridView()
        colCartProductID = New DataGridViewTextBoxColumn()
        colCartProductName = New DataGridViewTextBoxColumn()
        colCartQty = New DataGridViewTextBoxColumn()
        colCartUnitPrice = New DataGridViewTextBoxColumn()
        colCartAmount = New DataGridViewTextBoxColumn()
        pnlSummary = New Panel()
        btnClose = New Button()
        btnPrint = New Button()
        btnGeneratePO = New Button()
        lblTotalAmount = New Label()
        lblTotalItems = New Label()
        pnlHeader.SuspendLayout()
        pnlSelection.SuspendLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        pnlCart.SuspendLayout()
        CType(dgvCart, ComponentModel.ISupportInitialize).BeginInit()
        pnlSummary.SuspendLayout()
        SuspendLayout()
        '
        'pnlHeader
        '
        pnlHeader.BackColor = Color.White
        pnlHeader.BorderStyle = BorderStyle.FixedSingle
        pnlHeader.Controls.Add(cboSupplier)
        pnlHeader.Controls.Add(lblSupplier)
        pnlHeader.Controls.Add(dtpPODate)
        pnlHeader.Controls.Add(lblPODate)
        pnlHeader.Controls.Add(lblPONumber)
        pnlHeader.Controls.Add(lblPONumberCaption)
        pnlHeader.Location = New Point(12, 12)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1160, 72)
        pnlHeader.TabIndex = 0
        '
        'cboSupplier
        '
        cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboSupplier.FormattingEnabled = True
        cboSupplier.Location = New Point(781, 23)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(340, 23)
        cboSupplier.TabIndex = 5
        '
        'lblSupplier
        '
        lblSupplier.AutoSize = True
        lblSupplier.Location = New Point(726, 27)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(49, 15)
        lblSupplier.TabIndex = 0
        lblSupplier.Text = "Supplier"
        '
        'dtpPODate
        '
        dtpPODate.Format = DateTimePickerFormat.Short
        dtpPODate.Location = New Point(553, 23)
        dtpPODate.Name = "dtpPODate"
        dtpPODate.Size = New Size(120, 23)
        dtpPODate.TabIndex = 4
        '
        'lblPODate
        '
        lblPODate.AutoSize = True
        lblPODate.Location = New Point(505, 27)
        lblPODate.Name = "lblPODate"
        lblPODate.Size = New Size(42, 15)
        lblPODate.TabIndex = 0
        lblPODate.Text = "PO Date"
        '
        'lblPONumber
        '
        lblPONumber.AutoSize = True
        lblPONumber.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        lblPONumber.Location = New Point(100, 23)
        lblPONumber.Name = "lblPONumber"
        lblPONumber.Size = New Size(105, 21)
        lblPONumber.TabIndex = 0
        lblPONumber.Text = "PO-0000-0000"
        '
        'lblPONumberCaption
        '
        lblPONumberCaption.AutoSize = True
        lblPONumberCaption.Location = New Point(18, 27)
        lblPONumberCaption.Name = "lblPONumberCaption"
        lblPONumberCaption.Size = New Size(69, 15)
        lblPONumberCaption.TabIndex = 0
        lblPONumberCaption.Text = "PO Number"
        '
        'pnlSelection
        '
        pnlSelection.BackColor = Color.White
        pnlSelection.BorderStyle = BorderStyle.FixedSingle
        pnlSelection.Controls.Add(btnSearchProduct)
        pnlSelection.Controls.Add(txtProductSearch)
        pnlSelection.Controls.Add(lblProductSearch)
        pnlSelection.Controls.Add(cboFilterCategory)
        pnlSelection.Controls.Add(lblFilterCategory)
        pnlSelection.Controls.Add(dgvProducts)
        pnlSelection.Location = New Point(12, 90)
        pnlSelection.Name = "pnlSelection"
        pnlSelection.Size = New Size(560, 496)
        pnlSelection.TabIndex = 1
        '
        'btnSearchProduct
        '
        btnSearchProduct.Location = New Point(452, 15)
        btnSearchProduct.Name = "btnSearchProduct"
        btnSearchProduct.Size = New Size(88, 28)
        btnSearchProduct.TabIndex = 4
        btnSearchProduct.Text = "Search"
        btnSearchProduct.UseVisualStyleBackColor = True
        '
        'txtProductSearch
        '
        txtProductSearch.Location = New Point(108, 18)
        txtProductSearch.Name = "txtProductSearch"
        txtProductSearch.Size = New Size(338, 23)
        txtProductSearch.TabIndex = 3
        '
        'lblProductSearch
        '
        lblProductSearch.AutoSize = True
        lblProductSearch.Location = New Point(15, 21)
        lblProductSearch.Name = "lblProductSearch"
        lblProductSearch.Size = New Size(87, 15)
        lblProductSearch.TabIndex = 0
        lblProductSearch.Text = "Product Search"
        '
        'cboFilterCategory
        '
        cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterCategory.FormattingEnabled = True
        cboFilterCategory.Location = New Point(108, 53)
        cboFilterCategory.Name = "cboFilterCategory"
        cboFilterCategory.Size = New Size(338, 23)
        cboFilterCategory.TabIndex = 2
        '
        'lblFilterCategory
        '
        lblFilterCategory.AutoSize = True
        lblFilterCategory.Location = New Point(47, 56)
        lblFilterCategory.Name = "lblFilterCategory"
        lblFilterCategory.Size = New Size(55, 15)
        lblFilterCategory.TabIndex = 0
        lblFilterCategory.Text = "Category"
        '
        'dgvProducts
        '
        dgvProducts.AllowUserToAddRows = False
        dgvProducts.BackgroundColor = Color.White
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(15, 91)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.ReadOnly = True
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProducts.Size = New Size(525, 385)
        dgvProducts.TabIndex = 5
        '
        'pnlCart
        '
        pnlCart.BackColor = Color.White
        pnlCart.BorderStyle = BorderStyle.FixedSingle
        pnlCart.Controls.Add(btnRemoveFromCart)
        pnlCart.Controls.Add(btnAddToCart)
        pnlCart.Controls.Add(dgvCart)
        pnlCart.Location = New Point(578, 90)
        pnlCart.Name = "pnlCart"
        pnlCart.Size = New Size(594, 496)
        pnlCart.TabIndex = 2
        '
        'btnRemoveFromCart
        '
        btnRemoveFromCart.Location = New Point(485, 14)
        btnRemoveFromCart.Name = "btnRemoveFromCart"
        btnRemoveFromCart.Size = New Size(90, 30)
        btnRemoveFromCart.TabIndex = 2
        btnRemoveFromCart.Text = "Remove"
        btnRemoveFromCart.UseVisualStyleBackColor = True
        '
        'btnAddToCart
        '
        btnAddToCart.Location = New Point(389, 14)
        btnAddToCart.Name = "btnAddToCart"
        btnAddToCart.Size = New Size(90, 30)
        btnAddToCart.TabIndex = 1
        btnAddToCart.Text = "Add To Cart"
        btnAddToCart.UseVisualStyleBackColor = True
        '
        'dgvCart
        '
        dgvCart.AllowUserToAddRows = False
        dgvCart.BackgroundColor = Color.White
        dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCart.Columns.AddRange(New DataGridViewColumn() {colCartProductID, colCartProductName, colCartQty, colCartUnitPrice, colCartAmount})
        dgvCart.Location = New Point(15, 56)
        dgvCart.Name = "dgvCart"
        dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCart.Size = New Size(560, 420)
        dgvCart.TabIndex = 3
        '
        'colCartProductID
        '
        colCartProductID.DataPropertyName = "ProductID"
        colCartProductID.HeaderText = "ProductID"
        colCartProductID.Name = "colCartProductID"
        colCartProductID.Visible = False
        '
        'colCartProductName
        '
        colCartProductName.DataPropertyName = "ProductName"
        colCartProductName.HeaderText = "Product Name"
        colCartProductName.Name = "colCartProductName"
        colCartProductName.ReadOnly = True
        colCartProductName.Width = 220
        '
        'colCartQty
        '
        colCartQty.DataPropertyName = "OrderQty"
        colCartQty.HeaderText = "Order Qty"
        colCartQty.Name = "colCartQty"
        colCartQty.Width = 90
        '
        'colCartUnitPrice
        '
        colCartUnitPrice.DataPropertyName = "UnitPrice"
        colCartUnitPrice.HeaderText = "Unit Price"
        colCartUnitPrice.Name = "colCartUnitPrice"
        colCartUnitPrice.Width = 90
        '
        'colCartAmount
        '
        colCartAmount.DataPropertyName = "Amount"
        colCartAmount.HeaderText = "Amount"
        colCartAmount.Name = "colCartAmount"
        colCartAmount.ReadOnly = True
        colCartAmount.Width = 110
        '
        'pnlSummary
        '
        pnlSummary.BackColor = Color.White
        pnlSummary.BorderStyle = BorderStyle.FixedSingle
        pnlSummary.Controls.Add(btnClose)
        pnlSummary.Controls.Add(btnPrint)
        pnlSummary.Controls.Add(btnGeneratePO)
        pnlSummary.Controls.Add(lblTotalAmount)
        pnlSummary.Controls.Add(lblTotalItems)
        pnlSummary.Location = New Point(12, 592)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(1160, 55)
        pnlSummary.TabIndex = 3
        '
        'btnClose
        '
        btnClose.Location = New Point(1055, 13)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(84, 28)
        btnClose.TabIndex = 4
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        btnPrint.Location = New Point(959, 13)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(84, 28)
        btnPrint.TabIndex = 3
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = True
        '
        'btnGeneratePO
        '
        btnGeneratePO.Location = New Point(848, 13)
        btnGeneratePO.Name = "btnGeneratePO"
        btnGeneratePO.Size = New Size(100, 28)
        btnGeneratePO.TabIndex = 2
        btnGeneratePO.Text = "Generate PO"
        btnGeneratePO.UseVisualStyleBackColor = True
        '
        'lblTotalAmount
        '
        lblTotalAmount.AutoSize = True
        lblTotalAmount.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalAmount.Location = New Point(231, 17)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(129, 20)
        lblTotalAmount.TabIndex = 0
        lblTotalAmount.Text = "Total Amount: 0.00"
        '
        'lblTotalItems
        '
        lblTotalItems.AutoSize = True
        lblTotalItems.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalItems.Location = New Point(18, 17)
        lblTotalItems.Name = "lblTotalItems"
        lblTotalItems.Size = New Size(94, 20)
        lblTotalItems.TabIndex = 0
        lblTotalItems.Text = "Total Items: 0"
        '
        'frmPurchaseOrder
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1184, 659)
        Controls.Add(pnlSummary)
        Controls.Add(pnlCart)
        Controls.Add(pnlSelection)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.0!)
        Name = "frmPurchaseOrder"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Purchase Order"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSelection.ResumeLayout(False)
        pnlSelection.PerformLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        pnlCart.ResumeLayout(False)
        CType(dgvCart, ComponentModel.ISupportInitialize).EndInit()
        pnlSummary.ResumeLayout(False)
        pnlSummary.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents dtpPODate As DateTimePicker
    Friend WithEvents lblPODate As Label
    Friend WithEvents lblPONumber As Label
    Friend WithEvents lblPONumberCaption As Label
    Friend WithEvents pnlSelection As Panel
    Friend WithEvents btnSearchProduct As Button
    Friend WithEvents txtProductSearch As TextBox
    Friend WithEvents lblProductSearch As Label
    Friend WithEvents cboFilterCategory As ComboBox
    Friend WithEvents lblFilterCategory As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents pnlCart As Panel
    Friend WithEvents btnRemoveFromCart As Button
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents colCartProductID As DataGridViewTextBoxColumn
    Friend WithEvents colCartProductName As DataGridViewTextBoxColumn
    Friend WithEvents colCartQty As DataGridViewTextBoxColumn
    Friend WithEvents colCartUnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents colCartAmount As DataGridViewTextBoxColumn
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnGeneratePO As Button
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblTotalItems As Label
End Class
