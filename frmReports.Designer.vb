<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Label1 = New Label()
        TabControl1 = New TabControl()
        tabSales = New TabPage()
        Panel6 = New Panel()
        btnLoadSalesReport = New Button()
        Label2 = New Label()
        lblSalesTransactions = New Label()
        lblSalesTotalSales = New Label()
        Label7 = New Label()
        lblSalesNetAmount = New Label()
        lblSalesTax = New Label()
        Label3 = New Label()
        Label4 = New Label()
        lblSalesDiscount = New Label()
        Label6 = New Label()
        Panel4 = New Panel()
        dgvSalesReport = New DataGridView()
        Panel3 = New Panel()
        tabPurchase = New TabPage()
        dgvPurchaseReport = New DataGridView()
        Panel5 = New Panel()
        btnLoadPurchaseReport = New Button()
        Label5 = New Label()
        lblPurchaseTotal = New Label()
        lblPurchaseDue = New Label()
        Label21 = New Label()
        Label19 = New Label()
        lblPurchaseCount = New Label()
        Label13 = New Label()
        lblPurchasePaid = New Label()
        Label9 = New Label()
        Label16 = New Label()
        tabStock = New TabPage()
        dgvStockReport = New DataGridView()
        Panel7 = New Panel()
        btnLoadStockReport = New Button()
        Label17 = New Label()
        lblStockTotalItems = New Label()
        lblStockOutOfStock = New Label()
        lblStockLowStock = New Label()
        Label23 = New Label()
        Label24 = New Label()
        lblStockValue = New Label()
        Label26 = New Label()
        tabProfit = New TabPage()
        dgvProfitReport = New DataGridView()
        Panel8 = New Panel()
        btnLoadProfitReport = New Button()
        Label27 = New Label()
        lblProfitTotalSales = New Label()
        lblProfitPercent = New Label()
        lblProfitTotalProfit = New Label()
        Label33 = New Label()
        Label34 = New Label()
        lblProfitTotalCost = New Label()
        Label36 = New Label()
        tabSupplier = New TabPage()
        Panel13 = New Panel()
        lblSupplierTotalAmount = New Label()
        lblSupplierTotalDue = New Label()
        btnLoadSupplierReport = New Button()
        Label8 = New Label()
        lblSupplierTotalPurchases = New Label()
        lblSupplierCount = New Label()
        Label11 = New Label()
        lblSupplierTotalPaid = New Label()
        Label15 = New Label()
        Label18 = New Label()
        Label20 = New Label()
        dgvSupplierReport = New DataGridView()
        tabTopProducts = New TabPage()
        dgvTopProducts = New DataGridView()
        Panel10 = New Panel()
        btnLoadTopProducts = New Button()
        Label47 = New Label()
        lblTopProductsRevenue = New Label()
        tabPaymentMethod = New TabPage()
        dgvPaymentReport = New DataGridView()
        Panel11 = New Panel()
        btnLoadPaymentReport = New Button()
        tabCategorySales = New TabPage()
        dgvCategoryReport = New DataGridView()
        Panel12 = New Panel()
        btnLoadCategoryReport = New Button()
        Button1 = New Button()
        dtpToDate = New DateTimePicker()
        dtpFromDate = New DateTimePicker()
        btnExport = New Button()
        btnPrint = New Button()
        btnClose = New Button()
        Panel2 = New Panel()
        Label10 = New Label()
        Panel1.SuspendLayout()
        TabControl1.SuspendLayout()
        tabSales.SuspendLayout()
        Panel6.SuspendLayout()
        Panel4.SuspendLayout()
        CType(dgvSalesReport, ComponentModel.ISupportInitialize).BeginInit()
        tabPurchase.SuspendLayout()
        CType(dgvPurchaseReport, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        tabStock.SuspendLayout()
        CType(dgvStockReport, ComponentModel.ISupportInitialize).BeginInit()
        Panel7.SuspendLayout()
        tabProfit.SuspendLayout()
        CType(dgvProfitReport, ComponentModel.ISupportInitialize).BeginInit()
        Panel8.SuspendLayout()
        tabSupplier.SuspendLayout()
        Panel13.SuspendLayout()
        CType(dgvSupplierReport, ComponentModel.ISupportInitialize).BeginInit()
        tabTopProducts.SuspendLayout()
        CType(dgvTopProducts, ComponentModel.ISupportInitialize).BeginInit()
        Panel10.SuspendLayout()
        tabPaymentMethod.SuspendLayout()
        CType(dgvPaymentReport, ComponentModel.ISupportInitialize).BeginInit()
        Panel11.SuspendLayout()
        tabCategorySales.SuspendLayout()
        CType(dgvCategoryReport, ComponentModel.ISupportInitialize).BeginInit()
        Panel12.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveCaptionText
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1184, 46)
        Panel1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(156, 25)
        Label1.TabIndex = 0
        Label1.Text = "Reports Module"
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(tabSales)
        TabControl1.Controls.Add(tabPurchase)
        TabControl1.Controls.Add(tabStock)
        TabControl1.Controls.Add(tabProfit)
        TabControl1.Controls.Add(tabSupplier)
        TabControl1.Controls.Add(tabTopProducts)
        TabControl1.Controls.Add(tabPaymentMethod)
        TabControl1.Controls.Add(tabCategorySales)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 133)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1184, 540)
        TabControl1.TabIndex = 3
        ' 
        ' tabSales
        ' 
        tabSales.Controls.Add(Panel6)
        tabSales.Controls.Add(Panel4)
        tabSales.Controls.Add(Panel3)
        tabSales.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tabSales.Location = New Point(4, 24)
        tabSales.Name = "tabSales"
        tabSales.Padding = New Padding(3)
        tabSales.Size = New Size(1176, 512)
        tabSales.TabIndex = 0
        tabSales.Text = "SALES"
        tabSales.UseVisualStyleBackColor = True
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel6.Controls.Add(btnLoadSalesReport)
        Panel6.Controls.Add(Label2)
        Panel6.Controls.Add(lblSalesTransactions)
        Panel6.Controls.Add(lblSalesTotalSales)
        Panel6.Controls.Add(Label7)
        Panel6.Controls.Add(lblSalesNetAmount)
        Panel6.Controls.Add(lblSalesTax)
        Panel6.Controls.Add(Label3)
        Panel6.Controls.Add(Label4)
        Panel6.Controls.Add(lblSalesDiscount)
        Panel6.Controls.Add(Label6)
        Panel6.Dock = DockStyle.Left
        Panel6.ForeColor = Color.Black
        Panel6.Location = New Point(3, 3)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(245, 456)
        Panel6.TabIndex = 5
        ' 
        ' btnLoadSalesReport
        ' 
        btnLoadSalesReport.Location = New Point(5, 316)
        btnLoadSalesReport.Name = "btnLoadSalesReport"
        btnLoadSalesReport.Size = New Size(227, 39)
        btnLoadSalesReport.TabIndex = 1
        btnLoadSalesReport.Text = "SalesReport"
        btnLoadSalesReport.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(22, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(86, 21)
        Label2.TabIndex = 0
        Label2.Text = "Total Sales"
        ' 
        ' lblSalesTransactions
        ' 
        lblSalesTransactions.BackColor = Color.Gray
        lblSalesTransactions.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesTransactions.Location = New Point(135, 179)
        lblSalesTransactions.Name = "lblSalesTransactions"
        lblSalesTransactions.Size = New Size(107, 25)
        lblSalesTransactions.TabIndex = 2
        ' 
        ' lblSalesTotalSales
        ' 
        lblSalesTotalSales.BackColor = Color.Gray
        lblSalesTotalSales.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesTotalSales.Location = New Point(136, 13)
        lblSalesTotalSales.Name = "lblSalesTotalSales"
        lblSalesTotalSales.Size = New Size(106, 25)
        lblSalesTotalSales.TabIndex = 2
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(4, 183)
        Label7.Name = "Label7"
        Label7.Size = New Size(104, 21)
        Label7.TabIndex = 0
        Label7.Text = "Transactions:"
        ' 
        ' lblSalesNetAmount
        ' 
        lblSalesNetAmount.BackColor = Color.Gray
        lblSalesNetAmount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesNetAmount.Location = New Point(135, 140)
        lblSalesNetAmount.Name = "lblSalesNetAmount"
        lblSalesNetAmount.Size = New Size(106, 25)
        lblSalesNetAmount.TabIndex = 2
        ' 
        ' lblSalesTax
        ' 
        lblSalesTax.BackColor = Color.Gray
        lblSalesTax.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesTax.Location = New Point(135, 95)
        lblSalesTax.Name = "lblSalesTax"
        lblSalesTax.Size = New Size(106, 25)
        lblSalesTax.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(3, 56)
        Label3.Name = "Label3"
        Label3.Size = New Size(117, 21)
        Label3.TabIndex = 0
        Label3.Text = "Total Discount:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(3, 144)
        Label4.Name = "Label4"
        Label4.Size = New Size(104, 21)
        Label4.TabIndex = 0
        Label4.Text = "Net Amount:"
        ' 
        ' lblSalesDiscount
        ' 
        lblSalesDiscount.BackColor = Color.Gray
        lblSalesDiscount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesDiscount.Location = New Point(136, 56)
        lblSalesDiscount.Name = "lblSalesDiscount"
        lblSalesDiscount.Size = New Size(105, 25)
        lblSalesDiscount.TabIndex = 2
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(31, 95)
        Label6.Name = "Label6"
        Label6.Size = New Size(76, 21)
        Label6.TabIndex = 1
        Label6.Text = "Total Tax:"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        Panel4.Controls.Add(dgvSalesReport)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(3, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1170, 456)
        Panel4.TabIndex = 4
        ' 
        ' dgvSalesReport
        ' 
        dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSalesReport.Dock = DockStyle.Fill
        dgvSalesReport.Location = New Point(0, 0)
        dgvSalesReport.Name = "dgvSalesReport"
        dgvSalesReport.Size = New Size(1170, 456)
        dgvSalesReport.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(3, 459)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1170, 50)
        Panel3.TabIndex = 3
        ' 
        ' tabPurchase
        ' 
        tabPurchase.Controls.Add(dgvPurchaseReport)
        tabPurchase.Controls.Add(Panel5)
        tabPurchase.Location = New Point(4, 24)
        tabPurchase.Name = "tabPurchase"
        tabPurchase.Padding = New Padding(3)
        tabPurchase.Size = New Size(1176, 512)
        tabPurchase.TabIndex = 1
        tabPurchase.Text = "PURCHASE"
        tabPurchase.UseVisualStyleBackColor = True
        ' 
        ' dgvPurchaseReport
        ' 
        dgvPurchaseReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPurchaseReport.Dock = DockStyle.Fill
        dgvPurchaseReport.Location = New Point(248, 3)
        dgvPurchaseReport.Name = "dgvPurchaseReport"
        dgvPurchaseReport.Size = New Size(925, 506)
        dgvPurchaseReport.TabIndex = 7
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel5.Controls.Add(btnLoadPurchaseReport)
        Panel5.Controls.Add(Label5)
        Panel5.Controls.Add(lblPurchaseTotal)
        Panel5.Controls.Add(lblPurchaseDue)
        Panel5.Controls.Add(Label21)
        Panel5.Controls.Add(Label19)
        Panel5.Controls.Add(lblPurchaseCount)
        Panel5.Controls.Add(Label13)
        Panel5.Controls.Add(lblPurchasePaid)
        Panel5.Controls.Add(Label9)
        Panel5.Controls.Add(Label16)
        Panel5.Dock = DockStyle.Left
        Panel5.ForeColor = Color.Black
        Panel5.Location = New Point(3, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(245, 506)
        Panel5.TabIndex = 6
        ' 
        ' btnLoadPurchaseReport
        ' 
        btnLoadPurchaseReport.Location = New Point(5, 316)
        btnLoadPurchaseReport.Name = "btnLoadPurchaseReport"
        btnLoadPurchaseReport.Size = New Size(227, 39)
        btnLoadPurchaseReport.TabIndex = 1
        btnLoadPurchaseReport.Text = "PurchaseReport"
        btnLoadPurchaseReport.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(22, 17)
        Label5.Name = "Label5"
        Label5.Size = New Size(110, 21)
        Label5.TabIndex = 0
        Label5.Text = "PurchaseTotal"
        ' 
        ' lblPurchaseTotal
        ' 
        lblPurchaseTotal.BackColor = Color.Gray
        lblPurchaseTotal.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPurchaseTotal.Location = New Point(136, 13)
        lblPurchaseTotal.Name = "lblPurchaseTotal"
        lblPurchaseTotal.Size = New Size(106, 25)
        lblPurchaseTotal.TabIndex = 2
        ' 
        ' lblPurchaseDue
        ' 
        lblPurchaseDue.BackColor = Color.Gray
        lblPurchaseDue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPurchaseDue.Location = New Point(134, 144)
        lblPurchaseDue.Name = "lblPurchaseDue"
        lblPurchaseDue.Size = New Size(106, 25)
        lblPurchaseDue.TabIndex = 2
        ' 
        ' Label21
        ' 
        Label21.BackColor = Color.Gray
        Label21.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label21.Location = New Point(135, 144)
        Label21.Name = "Label21"
        Label21.Size = New Size(106, 25)
        Label21.TabIndex = 2
        ' 
        ' Label19
        ' 
        Label19.BackColor = Color.Gray
        Label19.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.Location = New Point(133, 144)
        Label19.Name = "Label19"
        Label19.Size = New Size(106, 25)
        Label19.TabIndex = 2
        ' 
        ' lblPurchaseCount
        ' 
        lblPurchaseCount.BackColor = Color.Gray
        lblPurchaseCount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPurchaseCount.Location = New Point(135, 95)
        lblPurchaseCount.Name = "lblPurchaseCount"
        lblPurchaseCount.Size = New Size(106, 25)
        lblPurchaseCount.TabIndex = 2
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(22, 56)
        Label13.Name = "Label13"
        Label13.Size = New Size(106, 21)
        Label13.TabIndex = 0
        Label13.Text = "PurchasePaid"
        ' 
        ' lblPurchasePaid
        ' 
        lblPurchasePaid.BackColor = Color.Gray
        lblPurchasePaid.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPurchasePaid.Location = New Point(136, 56)
        lblPurchasePaid.Name = "lblPurchasePaid"
        lblPurchasePaid.Size = New Size(105, 25)
        lblPurchasePaid.TabIndex = 2
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(3, 148)
        Label9.Name = "Label9"
        Label9.Size = New Size(107, 21)
        Label9.TabIndex = 1
        Label9.Text = "Purchase due"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(9, 95)
        Label16.Name = "Label16"
        Label16.Size = New Size(119, 21)
        Label16.TabIndex = 1
        Label16.Text = "PurchaseCount"
        ' 
        ' tabStock
        ' 
        tabStock.Controls.Add(dgvStockReport)
        tabStock.Controls.Add(Panel7)
        tabStock.Location = New Point(4, 24)
        tabStock.Name = "tabStock"
        tabStock.Padding = New Padding(3)
        tabStock.Size = New Size(1176, 512)
        tabStock.TabIndex = 2
        tabStock.Text = "STOCK"
        tabStock.UseVisualStyleBackColor = True
        ' 
        ' dgvStockReport
        ' 
        dgvStockReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStockReport.Dock = DockStyle.Fill
        dgvStockReport.Location = New Point(248, 3)
        dgvStockReport.Name = "dgvStockReport"
        dgvStockReport.Size = New Size(925, 506)
        dgvStockReport.TabIndex = 8
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel7.Controls.Add(btnLoadStockReport)
        Panel7.Controls.Add(Label17)
        Panel7.Controls.Add(lblStockTotalItems)
        Panel7.Controls.Add(lblStockOutOfStock)
        Panel7.Controls.Add(lblStockLowStock)
        Panel7.Controls.Add(Label23)
        Panel7.Controls.Add(Label24)
        Panel7.Controls.Add(lblStockValue)
        Panel7.Controls.Add(Label26)
        Panel7.Dock = DockStyle.Left
        Panel7.ForeColor = Color.Black
        Panel7.Location = New Point(3, 3)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(245, 506)
        Panel7.TabIndex = 7
        ' 
        ' btnLoadStockReport
        ' 
        btnLoadStockReport.Location = New Point(5, 316)
        btnLoadStockReport.Name = "btnLoadStockReport"
        btnLoadStockReport.Size = New Size(227, 39)
        btnLoadStockReport.TabIndex = 1
        btnLoadStockReport.Text = "StockReport"
        btnLoadStockReport.UseVisualStyleBackColor = True
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.Location = New Point(5, 13)
        Label17.Name = "Label17"
        Label17.Size = New Size(127, 21)
        Label17.TabIndex = 0
        Label17.Text = "StockTotalItems"
        ' 
        ' lblStockTotalItems
        ' 
        lblStockTotalItems.BackColor = Color.Gray
        lblStockTotalItems.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockTotalItems.Location = New Point(136, 13)
        lblStockTotalItems.Name = "lblStockTotalItems"
        lblStockTotalItems.Size = New Size(106, 25)
        lblStockTotalItems.TabIndex = 2
        ' 
        ' lblStockOutOfStock
        ' 
        lblStockOutOfStock.BackColor = Color.Gray
        lblStockOutOfStock.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockOutOfStock.Location = New Point(135, 140)
        lblStockOutOfStock.Name = "lblStockOutOfStock"
        lblStockOutOfStock.Size = New Size(106, 25)
        lblStockOutOfStock.TabIndex = 2
        ' 
        ' lblStockLowStock
        ' 
        lblStockLowStock.BackColor = Color.Gray
        lblStockLowStock.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockLowStock.Location = New Point(135, 95)
        lblStockLowStock.Name = "lblStockLowStock"
        lblStockLowStock.Size = New Size(106, 25)
        lblStockLowStock.TabIndex = 2
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label23.Location = New Point(3, 56)
        Label23.Name = "Label23"
        Label23.Size = New Size(90, 21)
        Label23.TabIndex = 0
        Label23.Text = "StockValue"
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label24.Location = New Point(3, 144)
        Label24.Name = "Label24"
        Label24.Size = New Size(137, 21)
        Label24.TabIndex = 0
        Label24.Text = "StockOutOfStock"
        ' 
        ' lblStockValue
        ' 
        lblStockValue.BackColor = Color.Gray
        lblStockValue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockValue.Location = New Point(136, 56)
        lblStockValue.Name = "lblStockValue"
        lblStockValue.Size = New Size(105, 25)
        lblStockValue.TabIndex = 2
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label26.Location = New Point(7, 95)
        Label26.Name = "Label26"
        Label26.Size = New Size(122, 21)
        Label26.TabIndex = 1
        Label26.Text = "StockLowStock"
        ' 
        ' tabProfit
        ' 
        tabProfit.Controls.Add(dgvProfitReport)
        tabProfit.Controls.Add(Panel8)
        tabProfit.Location = New Point(4, 24)
        tabProfit.Name = "tabProfit"
        tabProfit.Padding = New Padding(3)
        tabProfit.Size = New Size(1176, 512)
        tabProfit.TabIndex = 3
        tabProfit.Text = "PROFIT"
        tabProfit.UseVisualStyleBackColor = True
        ' 
        ' dgvProfitReport
        ' 
        dgvProfitReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProfitReport.Dock = DockStyle.Fill
        dgvProfitReport.Location = New Point(248, 3)
        dgvProfitReport.Name = "dgvProfitReport"
        dgvProfitReport.Size = New Size(925, 506)
        dgvProfitReport.TabIndex = 10
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel8.Controls.Add(btnLoadProfitReport)
        Panel8.Controls.Add(Label27)
        Panel8.Controls.Add(lblProfitTotalSales)
        Panel8.Controls.Add(lblProfitPercent)
        Panel8.Controls.Add(lblProfitTotalProfit)
        Panel8.Controls.Add(Label33)
        Panel8.Controls.Add(Label34)
        Panel8.Controls.Add(lblProfitTotalCost)
        Panel8.Controls.Add(Label36)
        Panel8.Dock = DockStyle.Left
        Panel8.ForeColor = Color.Black
        Panel8.Location = New Point(3, 3)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(245, 506)
        Panel8.TabIndex = 9
        ' 
        ' btnLoadProfitReport
        ' 
        btnLoadProfitReport.Location = New Point(5, 316)
        btnLoadProfitReport.Name = "btnLoadProfitReport"
        btnLoadProfitReport.Size = New Size(227, 39)
        btnLoadProfitReport.TabIndex = 1
        btnLoadProfitReport.Text = "ProfitReport"
        btnLoadProfitReport.UseVisualStyleBackColor = True
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label27.Location = New Point(3, 13)
        Label27.Name = "Label27"
        Label27.Size = New Size(141, 21)
        Label27.TabIndex = 0
        Label27.Text = "lblProfitTotalSales"
        ' 
        ' lblProfitTotalSales
        ' 
        lblProfitTotalSales.BackColor = Color.Gray
        lblProfitTotalSales.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProfitTotalSales.Location = New Point(150, 13)
        lblProfitTotalSales.Name = "lblProfitTotalSales"
        lblProfitTotalSales.Size = New Size(92, 25)
        lblProfitTotalSales.TabIndex = 2
        ' 
        ' lblProfitPercent
        ' 
        lblProfitPercent.BackColor = Color.Gray
        lblProfitPercent.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProfitPercent.Location = New Point(135, 140)
        lblProfitPercent.Name = "lblProfitPercent"
        lblProfitPercent.Size = New Size(106, 25)
        lblProfitPercent.TabIndex = 2
        ' 
        ' lblProfitTotalProfit
        ' 
        lblProfitTotalProfit.BackColor = Color.Gray
        lblProfitTotalProfit.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProfitTotalProfit.Location = New Point(135, 95)
        lblProfitTotalProfit.Name = "lblProfitTotalProfit"
        lblProfitTotalProfit.Size = New Size(106, 25)
        lblProfitTotalProfit.TabIndex = 2
        ' 
        ' Label33
        ' 
        Label33.AutoSize = True
        Label33.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label33.Location = New Point(3, 56)
        Label33.Name = "Label33"
        Label33.Size = New Size(119, 21)
        Label33.TabIndex = 0
        Label33.Text = "ProfitTotalCost"
        ' 
        ' Label34
        ' 
        Label34.AutoSize = True
        Label34.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label34.Location = New Point(3, 144)
        Label34.Name = "Label34"
        Label34.Size = New Size(106, 21)
        Label34.TabIndex = 0
        Label34.Text = "ProfitPercent"
        ' 
        ' lblProfitTotalCost
        ' 
        lblProfitTotalCost.BackColor = Color.Gray
        lblProfitTotalCost.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProfitTotalCost.Location = New Point(136, 56)
        lblProfitTotalCost.Name = "lblProfitTotalCost"
        lblProfitTotalCost.Size = New Size(105, 25)
        lblProfitTotalCost.TabIndex = 2
        ' 
        ' Label36
        ' 
        Label36.AutoSize = True
        Label36.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label36.Location = New Point(4, 95)
        Label36.Name = "Label36"
        Label36.Size = New Size(127, 21)
        Label36.TabIndex = 1
        Label36.Text = "ProfitTotalProfit"
        ' 
        ' tabSupplier
        ' 
        tabSupplier.Controls.Add(Panel13)
        tabSupplier.Controls.Add(dgvSupplierReport)
        tabSupplier.Location = New Point(4, 24)
        tabSupplier.Name = "tabSupplier"
        tabSupplier.Padding = New Padding(3)
        tabSupplier.Size = New Size(1176, 512)
        tabSupplier.TabIndex = 8
        tabSupplier.Text = "SUPPLIER"
        tabSupplier.UseVisualStyleBackColor = True
        ' 
        ' Panel13
        ' 
        Panel13.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel13.Controls.Add(lblSupplierTotalAmount)
        Panel13.Controls.Add(lblSupplierTotalDue)
        Panel13.Controls.Add(btnLoadSupplierReport)
        Panel13.Controls.Add(Label8)
        Panel13.Controls.Add(lblSupplierTotalPurchases)
        Panel13.Controls.Add(lblSupplierCount)
        Panel13.Controls.Add(Label11)
        Panel13.Controls.Add(lblSupplierTotalPaid)
        Panel13.Controls.Add(Label15)
        Panel13.Controls.Add(Label18)
        Panel13.Controls.Add(Label20)
        Panel13.Dock = DockStyle.Left
        Panel13.Location = New Point(3, 3)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(239, 506)
        Panel13.TabIndex = 12
        ' 
        ' lblSupplierTotalAmount
        ' 
        lblSupplierTotalAmount.BackColor = Color.Gray
        lblSupplierTotalAmount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplierTotalAmount.Location = New Point(36, 138)
        lblSupplierTotalAmount.Name = "lblSupplierTotalAmount"
        lblSupplierTotalAmount.Size = New Size(163, 25)
        lblSupplierTotalAmount.TabIndex = 16
        ' 
        ' lblSupplierTotalDue
        ' 
        lblSupplierTotalDue.BackColor = Color.Gray
        lblSupplierTotalDue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplierTotalDue.Location = New Point(38, 277)
        lblSupplierTotalDue.Name = "lblSupplierTotalDue"
        lblSupplierTotalDue.Size = New Size(163, 31)
        lblSupplierTotalDue.TabIndex = 15
        ' 
        ' btnLoadSupplierReport
        ' 
        btnLoadSupplierReport.Location = New Point(6, 408)
        btnLoadSupplierReport.Name = "btnLoadSupplierReport"
        btnLoadSupplierReport.Size = New Size(219, 46)
        btnLoadSupplierReport.TabIndex = 13
        btnLoadSupplierReport.Text = "LoadSupplierReport"
        btnLoadSupplierReport.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(58, 23)
        Label8.Name = "Label8"
        Label8.Size = New Size(115, 21)
        Label8.TabIndex = 3
        Label8.Text = "SupplierCount"
        ' 
        ' lblSupplierTotalPurchases
        ' 
        lblSupplierTotalPurchases.BackColor = Color.Gray
        lblSupplierTotalPurchases.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplierTotalPurchases.Location = New Point(36, 361)
        lblSupplierTotalPurchases.Name = "lblSupplierTotalPurchases"
        lblSupplierTotalPurchases.Size = New Size(165, 25)
        lblSupplierTotalPurchases.TabIndex = 8
        ' 
        ' lblSupplierCount
        ' 
        lblSupplierCount.BackColor = Color.Gray
        lblSupplierCount.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplierCount.Location = New Point(36, 61)
        lblSupplierCount.Name = "lblSupplierCount"
        lblSupplierCount.Size = New Size(163, 25)
        lblSupplierCount.TabIndex = 9
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(36, 320)
        Label11.Name = "Label11"
        Label11.Size = New Size(178, 21)
        Label11.TabIndex = 4
        Label11.Text = "SupplierTotalPurchases"
        ' 
        ' lblSupplierTotalPaid
        ' 
        lblSupplierTotalPaid.BackColor = Color.Gray
        lblSupplierTotalPaid.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSupplierTotalPaid.Location = New Point(36, 216)
        lblSupplierTotalPaid.Name = "lblSupplierTotalPaid"
        lblSupplierTotalPaid.Size = New Size(163, 25)
        lblSupplierTotalPaid.TabIndex = 11
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(36, 97)
        Label15.Name = "Label15"
        Label15.Size = New Size(165, 21)
        Label15.TabIndex = 5
        Label15.Text = "SupplierTotalAmount"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.Location = New Point(51, 178)
        Label18.Name = "Label18"
        Label18.Size = New Size(137, 21)
        Label18.TabIndex = 6
        Label18.Text = "SupplierTotalPaid"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.Location = New Point(51, 244)
        Label20.Name = "Label20"
        Label20.Size = New Size(135, 21)
        Label20.TabIndex = 7
        Label20.Text = "SupplierTotalDue"
        ' 
        ' dgvSupplierReport
        ' 
        dgvSupplierReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSupplierReport.Dock = DockStyle.Fill
        dgvSupplierReport.Location = New Point(3, 3)
        dgvSupplierReport.Name = "dgvSupplierReport"
        dgvSupplierReport.Size = New Size(1170, 506)
        dgvSupplierReport.TabIndex = 11
        ' 
        ' tabTopProducts
        ' 
        tabTopProducts.Controls.Add(dgvTopProducts)
        tabTopProducts.Controls.Add(Panel10)
        tabTopProducts.Location = New Point(4, 24)
        tabTopProducts.Name = "tabTopProducts"
        tabTopProducts.Padding = New Padding(3)
        tabTopProducts.Size = New Size(1176, 512)
        tabTopProducts.TabIndex = 5
        tabTopProducts.Text = "TOP PRODUCT"
        tabTopProducts.UseVisualStyleBackColor = True
        ' 
        ' dgvTopProducts
        ' 
        dgvTopProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTopProducts.Dock = DockStyle.Fill
        dgvTopProducts.Location = New Point(248, 3)
        dgvTopProducts.Name = "dgvTopProducts"
        dgvTopProducts.Size = New Size(925, 506)
        dgvTopProducts.TabIndex = 10
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel10.Controls.Add(btnLoadTopProducts)
        Panel10.Controls.Add(Label47)
        Panel10.Controls.Add(lblTopProductsRevenue)
        Panel10.Dock = DockStyle.Left
        Panel10.ForeColor = Color.Black
        Panel10.Location = New Point(3, 3)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(245, 506)
        Panel10.TabIndex = 9
        ' 
        ' btnLoadTopProducts
        ' 
        btnLoadTopProducts.Location = New Point(5, 316)
        btnLoadTopProducts.Name = "btnLoadTopProducts"
        btnLoadTopProducts.Size = New Size(227, 39)
        btnLoadTopProducts.TabIndex = 1
        btnLoadTopProducts.Text = "Load   SaleSReport"
        btnLoadTopProducts.UseVisualStyleBackColor = True
        ' 
        ' Label47
        ' 
        Label47.AutoSize = True
        Label47.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label47.Location = New Point(22, 17)
        Label47.Name = "Label47"
        Label47.Size = New Size(183, 21)
        Label47.TabIndex = 0
        Label47.Text = "lblTopProductsRevenue"
        ' 
        ' lblTopProductsRevenue
        ' 
        lblTopProductsRevenue.BackColor = Color.Gray
        lblTopProductsRevenue.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTopProductsRevenue.Location = New Point(55, 70)
        lblTopProductsRevenue.Name = "lblTopProductsRevenue"
        lblTopProductsRevenue.Size = New Size(106, 25)
        lblTopProductsRevenue.TabIndex = 2
        ' 
        ' tabPaymentMethod
        ' 
        tabPaymentMethod.Controls.Add(dgvPaymentReport)
        tabPaymentMethod.Controls.Add(Panel11)
        tabPaymentMethod.Location = New Point(4, 24)
        tabPaymentMethod.Name = "tabPaymentMethod"
        tabPaymentMethod.Padding = New Padding(3)
        tabPaymentMethod.Size = New Size(1176, 512)
        tabPaymentMethod.TabIndex = 6
        tabPaymentMethod.Text = "PAYMENT METHOD"
        tabPaymentMethod.UseVisualStyleBackColor = True
        ' 
        ' dgvPaymentReport
        ' 
        dgvPaymentReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPaymentReport.Dock = DockStyle.Fill
        dgvPaymentReport.Location = New Point(248, 3)
        dgvPaymentReport.Name = "dgvPaymentReport"
        dgvPaymentReport.Size = New Size(925, 506)
        dgvPaymentReport.TabIndex = 10
        ' 
        ' Panel11
        ' 
        Panel11.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel11.Controls.Add(btnLoadPaymentReport)
        Panel11.Dock = DockStyle.Left
        Panel11.ForeColor = Color.Black
        Panel11.Location = New Point(3, 3)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(245, 506)
        Panel11.TabIndex = 9
        ' 
        ' btnLoadPaymentReport
        ' 
        btnLoadPaymentReport.Location = New Point(3, 210)
        btnLoadPaymentReport.Name = "btnLoadPaymentReport"
        btnLoadPaymentReport.Size = New Size(227, 39)
        btnLoadPaymentReport.TabIndex = 1
        btnLoadPaymentReport.Text = "PaymentReport"
        btnLoadPaymentReport.UseVisualStyleBackColor = True
        ' 
        ' tabCategorySales
        ' 
        tabCategorySales.Controls.Add(dgvCategoryReport)
        tabCategorySales.Controls.Add(Panel12)
        tabCategorySales.Location = New Point(4, 24)
        tabCategorySales.Name = "tabCategorySales"
        tabCategorySales.Padding = New Padding(3)
        tabCategorySales.Size = New Size(1176, 512)
        tabCategorySales.TabIndex = 7
        tabCategorySales.Text = "CATAGERY SALES"
        tabCategorySales.UseVisualStyleBackColor = True
        ' 
        ' dgvCategoryReport
        ' 
        dgvCategoryReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCategoryReport.Dock = DockStyle.Fill
        dgvCategoryReport.Location = New Point(264, 3)
        dgvCategoryReport.Name = "dgvCategoryReport"
        dgvCategoryReport.Size = New Size(909, 506)
        dgvCategoryReport.TabIndex = 10
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel12.Controls.Add(btnLoadCategoryReport)
        Panel12.Dock = DockStyle.Left
        Panel12.ForeColor = Color.Black
        Panel12.Location = New Point(3, 3)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(261, 506)
        Panel12.TabIndex = 9
        ' 
        ' btnLoadCategoryReport
        ' 
        btnLoadCategoryReport.Location = New Point(5, 151)
        btnLoadCategoryReport.Name = "btnLoadCategoryReport"
        btnLoadCategoryReport.Size = New Size(227, 39)
        btnLoadCategoryReport.TabIndex = 1
        btnLoadCategoryReport.Text = "CategoryReport"
        btnLoadCategoryReport.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(5, 316)
        Button1.Name = "Button1"
        Button1.Size = New Size(227, 39)
        Button1.TabIndex = 1
        Button1.Text = "SupplierReport"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' dtpToDate
        ' 
        dtpToDate.Location = New Point(306, 6)
        dtpToDate.Name = "dtpToDate"
        dtpToDate.Size = New Size(277, 23)
        dtpToDate.TabIndex = 0
        ' 
        ' dtpFromDate
        ' 
        dtpFromDate.Location = New Point(12, 6)
        dtpFromDate.Name = "dtpFromDate"
        dtpFromDate.Size = New Size(256, 23)
        dtpFromDate.TabIndex = 0
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(12, 51)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(112, 23)
        btnExport.TabIndex = 1
        btnExport.Text = "Export to CSV"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnPrint
        ' 
        btnPrint.Location = New Point(156, 51)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(112, 23)
        btnPrint.TabIndex = 1
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(306, 51)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 23)
        btnClose.TabIndex = 1
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        Panel2.Controls.Add(btnClose)
        Panel2.Controls.Add(btnPrint)
        Panel2.Controls.Add(btnExport)
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(dtpFromDate)
        Panel2.Controls.Add(dtpToDate)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 46)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1184, 87)
        Panel2.TabIndex = 2
        ' 
        ' Label10
        ' 
        Label10.Location = New Point(0, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(100, 23)
        Label10.TabIndex = 0
        ' 
        ' frmReports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 673)
        Controls.Add(TabControl1)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "frmReports"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reports Module"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TabControl1.ResumeLayout(False)
        tabSales.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel4.ResumeLayout(False)
        CType(dgvSalesReport, ComponentModel.ISupportInitialize).EndInit()
        tabPurchase.ResumeLayout(False)
        CType(dgvPurchaseReport, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        tabStock.ResumeLayout(False)
        CType(dgvStockReport, ComponentModel.ISupportInitialize).EndInit()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        tabProfit.ResumeLayout(False)
        CType(dgvProfitReport, ComponentModel.ISupportInitialize).EndInit()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        tabSupplier.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        Panel13.PerformLayout()
        CType(dgvSupplierReport, ComponentModel.ISupportInitialize).EndInit()
        tabTopProducts.ResumeLayout(False)
        CType(dgvTopProducts, ComponentModel.ISupportInitialize).EndInit()
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        tabPaymentMethod.ResumeLayout(False)
        CType(dgvPaymentReport, ComponentModel.ISupportInitialize).EndInit()
        Panel11.ResumeLayout(False)
        tabCategorySales.ResumeLayout(False)
        CType(dgvCategoryReport, ComponentModel.ISupportInitialize).EndInit()
        Panel12.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabSales As TabPage
    Friend WithEvents tabPurchase As TabPage
    Friend WithEvents tabStock As TabPage
    Friend WithEvents tabProfit As TabPage
    Friend WithEvents tabTopProducts As TabPage
    Friend WithEvents tabPaymentMethod As TabPage
    Friend WithEvents tabCategorySales As TabPage
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSalesTotalSales As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblSalesTransactions As Label
    Friend WithEvents lblSalesTax As Label
    Friend WithEvents lblSalesNetAmount As Label
    Friend WithEvents lblSalesDiscount As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnLoadSalesReport As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents dgvSalesReport As DataGridView
    Friend WithEvents dgvPurchaseReport As DataGridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnLoadPurchaseReport As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPurchaseTotal As Label
    Friend WithEvents lblPurchaseCount As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblPurchasePaid As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents dgvStockReport As DataGridView
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnLoadStockReport As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents lblStockTotalItems As Label
    Friend WithEvents lblStockOutOfStock As Label
    Friend WithEvents lblStockLowStock As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblStockValue As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents dgvProfitReport As DataGridView
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btnLoadProfitReport As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblProfitTotalSales As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents lblProfitPercent As Label
    Friend WithEvents lblProfitTotalProfit As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents lblProfitTotalCost As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Label37 As Label
    Friend WithEvents lblSupplierTotalPurchases As Label
    Friend WithEvents lblSupplierCount As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents lblSupplierTotalPaid As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents lblSupplierTotalAmount As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents dgvTopProducts As DataGridView
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btnLoadTopProducts As Button
    Friend WithEvents Label47 As Label
    Friend WithEvents lblTopProductsRevenue As Label
    Friend WithEvents dgvPaymentReport As DataGridView
    Friend WithEvents Panel11 As Panel
    Friend WithEvents btnLoadPaymentReport As Button
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents dgvCategoryReport As DataGridView
    Friend WithEvents Panel12 As Panel
    Friend WithEvents btnLoadCategoryReport As Button
    Friend WithEvents tabSupplier As TabPage
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents label As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dgvSupplierReport As DataGridView
    Friend WithEvents btnLoadSupplierReport As Button
    Friend WithEvents lblPurchaseDue As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblSupplierTotalDue As Label
    Friend WithEvents lalbel1 As Label
    Friend WithEvents lAmount As Label
End Class
