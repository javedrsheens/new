<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainDashboard
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
        components = New ComponentModel.Container()
        lblUserName = New Label()
        lblUserRole = New Label()
        timerClock = New Timer(components)
        lblTodaySales = New Label()
        lblTodayTransactions = New Label()
        lblTotalProducts = New Label()
        lblLowStock = New Label()
        lblTotalCustomers = New Label()
        lblMonthSales = New Label()
        dgvLowStock = New DataGridView()
        btnUsers = New Button()
        btnExpenses = New Button()
        btnSettings = New Button()
        btnReports = New Button()
        btnCustomers = New Button()
        lblDateTime = New Label()
        btnNewSale = New Button()
        btnSuppliers = New Button()
        btnRefresh = New Button()
        btnExit = New Button()
        btnDayBook = New Button()
        btnLogout = New Button()
        Panel1 = New Panel()
        Label1 = New Label()
        Panel2 = New Panel()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        Panel7 = New Panel()
        Label15 = New Label()
        Panel6 = New Panel()
        Label9 = New Label()
        Label8 = New Label()
        Panel5 = New Panel()
        Label13 = New Label()
        Label14 = New Label()
        Label7 = New Label()
        Panel4 = New Panel()
        Label12 = New Label()
        Label10 = New Label()
        Label6 = New Label()
        lblTotalStock = New Label()
        Panel3 = New Panel()
        Label11 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        btnPurchase = New Button()
        dgvRecentSales = New DataGridView()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnProducts = New Button()
        ToolStrip2 = New ToolStrip()
        FontDialog2 = New FontDialog()
        Panel8 = New Panel()
        Panel9 = New Panel()
        FontDialog1 = New FontDialog()
        btnCategories = New Button()
        TableLayoutPanel2 = New TableLayoutPanel()
        btnPaymentMethods = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button8 = New Button()
        btnpnl = New Button()
        Button10 = New Button()
        Button11 = New Button()
        Button12 = New Button()
        btnAccounts = New Button()
        CType(dgvLowStock, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        GroupBox1.SuspendLayout()
        Panel7.SuspendLayout()
        Panel6.SuspendLayout()
        Panel5.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        CType(dgvRecentSales, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        Panel8.SuspendLayout()
        Panel9.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblUserName
        ' 
        lblUserName.BackColor = Color.Transparent
        lblUserName.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserName.Location = New Point(882, 20)
        lblUserName.Name = "lblUserName"
        lblUserName.Size = New Size(107, 30)
        lblUserName.TabIndex = 0
        lblUserName.Text = "👤 Admin"
        ' 
        ' lblUserRole
        ' 
        lblUserRole.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUserRole.ForeColor = Color.White
        lblUserRole.Location = New Point(1029, 24)
        lblUserRole.Name = "lblUserRole"
        lblUserRole.Size = New Size(150, 22)
        lblUserRole.TabIndex = 1
        lblUserRole.Text = "Administrator"
        ' 
        ' timerClock
        ' 
        ' 
        ' lblTodaySales
        ' 
        lblTodaySales.AutoSize = True
        lblTodaySales.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTodaySales.Location = New Point(33, 64)
        lblTodaySales.Name = "lblTodaySales"
        lblTodaySales.Size = New Size(83, 25)
        lblTodaySales.TabIndex = 2
        lblTodaySales.Text = "RS: 0.00"
        ' 
        ' lblTodayTransactions
        ' 
        lblTodayTransactions.AutoSize = True
        lblTodayTransactions.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTodayTransactions.Location = New Point(82, 131)
        lblTodayTransactions.Name = "lblTodayTransactions"
        lblTodayTransactions.Size = New Size(50, 25)
        lblTodayTransactions.TabIndex = 3
        lblTodayTransactions.Text = "0.00"
        ' 
        ' lblTotalProducts
        ' 
        lblTotalProducts.AutoSize = True
        lblTotalProducts.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalProducts.Location = New Point(62, 60)
        lblTotalProducts.Name = "lblTotalProducts"
        lblTotalProducts.Size = New Size(50, 25)
        lblTotalProducts.TabIndex = 4
        lblTotalProducts.Text = "0.00"
        ' 
        ' lblLowStock
        ' 
        lblLowStock.AutoSize = True
        lblLowStock.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLowStock.Location = New Point(79, 60)
        lblLowStock.Name = "lblLowStock"
        lblLowStock.Size = New Size(50, 25)
        lblLowStock.TabIndex = 6
        lblLowStock.Text = "0.00"
        ' 
        ' lblTotalCustomers
        ' 
        lblTotalCustomers.AutoSize = True
        lblTotalCustomers.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalCustomers.Location = New Point(71, 91)
        lblTotalCustomers.Name = "lblTotalCustomers"
        lblTotalCustomers.Size = New Size(50, 25)
        lblTotalCustomers.TabIndex = 6
        lblTotalCustomers.Text = "0.00"
        ' 
        ' lblMonthSales
        ' 
        lblMonthSales.AutoSize = True
        lblMonthSales.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMonthSales.Location = New Point(33, 90)
        lblMonthSales.Name = "lblMonthSales"
        lblMonthSales.Size = New Size(50, 25)
        lblMonthSales.TabIndex = 6
        lblMonthSales.Text = "0.00"
        ' 
        ' dgvLowStock
        ' 
        dgvLowStock.BackgroundColor = Color.White
        dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLowStock.Location = New Point(0, 0)
        dgvLowStock.Name = "dgvLowStock"
        dgvLowStock.Size = New Size(625, 246)
        dgvLowStock.TabIndex = 7
        ' 
        ' btnUsers
        ' 
        btnUsers.BackColor = Color.FromArgb(CByte(103), CByte(58), CByte(183))
        btnUsers.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnUsers.Location = New Point(851, 3)
        btnUsers.Name = "btnUsers"
        btnUsers.Size = New Size(100, 59)
        btnUsers.TabIndex = 8
        btnUsers.Text = "   👤 " & vbCrLf & "Users"
        btnUsers.UseVisualStyleBackColor = False
        ' 
        ' btnExpenses
        ' 
        btnExpenses.BackColor = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        btnExpenses.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnExpenses.Location = New Point(533, 3)
        btnExpenses.Name = "btnExpenses"
        btnExpenses.Size = New Size(100, 59)
        btnExpenses.TabIndex = 8
        btnExpenses.Text = "     💸" & vbCrLf & "Expenses"
        btnExpenses.UseVisualStyleBackColor = False
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.FromArgb(CByte(96), CByte(125), CByte(139))
        btnSettings.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnSettings.Location = New Point(957, 3)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(100, 59)
        btnSettings.TabIndex = 8
        btnSettings.Text = "   ⚙️" & vbCrLf & "Setting"
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        btnReports.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnReports.Location = New Point(639, 3)
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(100, 59)
        btnReports.TabIndex = 8
        btnReports.Text = "    📊" & vbCrLf & "Reports"
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' btnCustomers
        ' 
        btnCustomers.BackColor = Color.FromArgb(CByte(156), CByte(39), CByte(176))
        btnCustomers.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnCustomers.Location = New Point(321, 3)
        btnCustomers.Name = "btnCustomers"
        btnCustomers.Size = New Size(100, 59)
        btnCustomers.TabIndex = 8
        btnCustomers.Text = "     👥" & vbCrLf & "Customer"
        btnCustomers.UseVisualStyleBackColor = False
        ' 
        ' lblDateTime
        ' 
        lblDateTime.AutoSize = True
        lblDateTime.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDateTime.Location = New Point(164, 14)
        lblDateTime.Name = "lblDateTime"
        lblDateTime.Size = New Size(172, 30)
        lblDateTime.TabIndex = 9
        lblDateTime.Text = "🕐 02:15:30 PM"
        ' 
        ' btnNewSale
        ' 
        btnNewSale.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnNewSale.Dock = DockStyle.Fill
        btnNewSale.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewSale.Location = New Point(3, 3)
        btnNewSale.Name = "btnNewSale"
        btnNewSale.Size = New Size(100, 59)
        btnNewSale.TabIndex = 10
        btnNewSale.Text = "  💵 NewSale"
        btnNewSale.UseVisualStyleBackColor = False
        ' 
        ' btnSuppliers
        ' 
        btnSuppliers.BackColor = Color.FromArgb(CByte(255), CByte(87), CByte(34))
        btnSuppliers.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnSuppliers.Location = New Point(427, 3)
        btnSuppliers.Name = "btnSuppliers"
        btnSuppliers.Size = New Size(100, 59)
        btnSuppliers.TabIndex = 10
        btnSuppliers.Text = "   🏭" & vbCrLf & "Suppliers"
        btnSuppliers.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        btnRefresh.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnRefresh.Location = New Point(1063, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 59)
        btnRefresh.TabIndex = 10
        btnRefresh.Text = "    🔄" & vbCrLf & "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.FromArgb(CByte(158), CByte(158), CByte(158))
        btnExit.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnExit.Location = New Point(1169, 3)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(100, 59)
        btnExit.TabIndex = 10
        btnExit.Text = " ❌" & vbCrLf & "Exit"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' btnDayBook
        ' 
        btnDayBook.BackColor = Color.FromArgb(CByte(139), CByte(195), CByte(74))
        btnDayBook.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnDayBook.Location = New Point(745, 3)
        btnDayBook.Name = "btnDayBook"
        btnDayBook.Size = New Size(100, 59)
        btnDayBook.TabIndex = 10
        btnDayBook.Text = "    📒 " & vbCrLf & "DayBook"
        btnDayBook.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.Firebrick
        btnLogout.Location = New Point(1193, 13)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(79, 37)
        btnLogout.TabIndex = 10
        btnLogout.Text = "🔓Logout "
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkSlateBlue
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(btnLogout)
        Panel1.Controls.Add(lblUserName)
        Panel1.Controls.Add(lblUserRole)
        Panel1.Dock = DockStyle.Top
        Panel1.ForeColor = Color.White
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1284, 60)
        Panel1.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(20, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(391, 25)
        Label1.TabIndex = 0
        Label1.Text = "📊 POS Management System - Dashboard  "
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.WhiteSmoke
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(lblDateTime)
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 60)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1284, 62)
        Panel2.TabIndex = 12
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(16, 14)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 30)
        Label2.TabIndex = 10
        Label2.Text = "MashaAllah"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.White
        GroupBox1.Controls.Add(Panel7)
        GroupBox1.Controls.Add(Panel6)
        GroupBox1.Controls.Add(Panel5)
        GroupBox1.Controls.Add(Panel4)
        GroupBox1.Controls.Add(Panel3)
        GroupBox1.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(0, 128)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1292, 202)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Today's Summary"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.LightSkyBlue
        Panel7.Controls.Add(lblMonthSales)
        Panel7.Controls.Add(Label15)
        Panel7.Location = New Point(1034, 30)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(180, 172)
        Panel7.TabIndex = 4
        ' 
        ' Label15
        ' 
        Label15.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.Location = New Point(34, 27)
        Label15.Name = "Label15"
        Label15.Size = New Size(111, 45)
        Label15.TabIndex = 7
        Label15.Text = "      This " & vbCrLf & "Month Sale"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        Panel6.Controls.Add(Label9)
        Panel6.Controls.Add(Label8)
        Panel6.Controls.Add(lblTotalCustomers)
        Panel6.Location = New Point(773, 30)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(180, 172)
        Panel6.TabIndex = 3
        ' 
        ' Label9
        ' 
        Label9.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(3, 3)
        Label9.Name = "Label9"
        Label9.Size = New Size(58, 43)
        Label9.TabIndex = 8
        Label9.Text = "👥"
        ' 
        ' Label8
        ' 
        Label8.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(47, 34)
        Label8.Name = "Label8"
        Label8.Size = New Size(85, 48)
        Label8.TabIndex = 7
        Label8.Text = "   Total " & vbCrLf & "Costumers"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.LightCoral
        Panel5.Controls.Add(Label13)
        Panel5.Controls.Add(Label14)
        Panel5.Controls.Add(Label7)
        Panel5.Controls.Add(lblLowStock)
        Panel5.Location = New Point(542, 30)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(180, 172)
        Panel5.TabIndex = 2
        ' 
        ' Label13
        ' 
        Label13.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(52, 113)
        Label13.Name = "Label13"
        Label13.Size = New Size(99, 43)
        Label13.TabIndex = 7
        Label13.Text = "Items Needs" & vbCrLf & "  Reodrer"
        ' 
        ' Label14
        ' 
        Label14.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.Location = New Point(52, 24)
        Label14.Name = "Label14"
        Label14.Size = New Size(99, 29)
        Label14.TabIndex = 7
        Label14.Text = "Low Stock"
        ' 
        ' Label7
        ' 
        Label7.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(3, 16)
        Label7.Name = "Label7"
        Label7.Size = New Size(43, 37)
        Label7.TabIndex = 7
        Label7.Text = "⚠️ "
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.LightBlue
        Panel4.Controls.Add(Label12)
        Panel4.Controls.Add(Label10)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(lblTotalProducts)
        Panel4.Controls.Add(lblTotalStock)
        Panel4.Location = New Point(274, 30)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(180, 172)
        Panel4.TabIndex = 1
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(51, 95)
        Label12.Name = "Label12"
        Label12.Size = New Size(86, 20)
        Label12.TabIndex = 7
        Label12.Text = "Total Stock"
        ' 
        ' Label10
        ' 
        Label10.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(2, 3)
        Label10.Name = "Label10"
        Label10.Size = New Size(60, 31)
        Label10.TabIndex = 6
        Label10.Text = " 📦 "
        ' 
        ' Label6
        ' 
        Label6.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(27, 34)
        Label6.Name = "Label6"
        Label6.Size = New Size(120, 22)
        Label6.TabIndex = 5
        Label6.Text = "Total Products"
        ' 
        ' lblTotalStock
        ' 
        lblTotalStock.AutoSize = True
        lblTotalStock.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalStock.Location = New Point(62, 131)
        lblTotalStock.Name = "lblTotalStock"
        lblTotalStock.Size = New Size(50, 25)
        lblTotalStock.TabIndex = 5
        lblTotalStock.Text = "0.00"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightGreen
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(lblTodaySales)
        Panel3.Controls.Add(lblTodayTransactions)
        Panel3.Location = New Point(23, 30)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(180, 172)
        Panel3.TabIndex = 0
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(22, 95)
        Label11.Name = "Label11"
        Label11.Size = New Size(121, 20)
        Label11.TabIndex = 7
        Label11.Text = "Total Transtions" & vbCrLf
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(61, 11)
        Label5.Name = "Label5"
        Label5.Size = New Size(62, 50)
        Label5.TabIndex = 4
        Label5.Text = "Today's" & vbCrLf & "Sales"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(3, 3)
        Label4.Name = "Label4"
        Label4.Size = New Size(66, 50)
        Label4.TabIndex = 3
        Label4.Text = "💰"
        ' 
        ' btnPurchase
        ' 
        btnPurchase.BackColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnPurchase.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnPurchase.Location = New Point(109, 3)
        btnPurchase.Name = "btnPurchase"
        btnPurchase.Size = New Size(100, 59)
        btnPurchase.TabIndex = 9
        btnPurchase.Text = "      " & ChrW(55357) & ChrW(57042) & vbCrLf & "Purchase"
        btnPurchase.UseVisualStyleBackColor = False
        ' 
        ' dgvRecentSales
        ' 
        dgvRecentSales.BackgroundColor = Color.White
        dgvRecentSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRecentSales.Location = New Point(0, 0)
        dgvRecentSales.Name = "dgvRecentSales"
        dgvRecentSales.Size = New Size(650, 245)
        dgvRecentSales.TabIndex = 7
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 12
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel1.Controls.Add(btnNewSale, 0, 0)
        TableLayoutPanel1.Controls.Add(btnPurchase, 1, 0)
        TableLayoutPanel1.Controls.Add(btnProducts, 2, 0)
        TableLayoutPanel1.Controls.Add(btnCustomers, 3, 0)
        TableLayoutPanel1.Controls.Add(btnSuppliers, 4, 0)
        TableLayoutPanel1.Controls.Add(btnExit, 11, 0)
        TableLayoutPanel1.Controls.Add(btnExpenses, 5, 0)
        TableLayoutPanel1.Controls.Add(btnRefresh, 10, 0)
        TableLayoutPanel1.Controls.Add(btnReports, 6, 0)
        TableLayoutPanel1.Controls.Add(btnSettings, 9, 0)
        TableLayoutPanel1.Controls.Add(btnDayBook, 7, 0)
        TableLayoutPanel1.Controls.Add(btnUsers, 8, 0)
        TableLayoutPanel1.Dock = DockStyle.Bottom
        TableLayoutPanel1.Location = New Point(0, 684)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(1284, 65)
        TableLayoutPanel1.TabIndex = 13
        ' 
        ' btnProducts
        ' 
        btnProducts.BackColor = Color.FromArgb(CByte(255), CByte(152), CByte(0))
        btnProducts.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnProducts.Location = New Point(215, 3)
        btnProducts.Name = "btnProducts"
        btnProducts.Size = New Size(100, 59)
        btnProducts.TabIndex = 11
        btnProducts.Text = "     📦 " & vbCrLf & "Products"
        btnProducts.UseVisualStyleBackColor = False
        ' 
        ' ToolStrip2
        ' 
        ToolStrip2.Location = New Point(0, 122)
        ToolStrip2.Name = "ToolStrip2"
        ToolStrip2.Size = New Size(1284, 25)
        ToolStrip2.TabIndex = 14
        ToolStrip2.Text = "ToolStrip2"
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        Panel8.Controls.Add(dgvRecentSales)
        Panel8.Location = New Point(3, 336)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(650, 246)
        Panel8.TabIndex = 15
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(dgvLowStock)
        Panel9.Location = New Point(659, 336)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(625, 246)
        Panel9.TabIndex = 16
        ' 
        ' FontDialog1
        ' 
        ' 
        ' btnCategories
        ' 
        btnCategories.Location = New Point(3, 3)
        btnCategories.Name = "btnCategories"
        btnCategories.Size = New Size(100, 50)
        btnCategories.TabIndex = 17
        btnCategories.Text = "Catageries"
        btnCategories.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 12
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333333F))
        TableLayoutPanel2.Controls.Add(btnCategories, 0, 0)
        TableLayoutPanel2.Controls.Add(btnPaymentMethods, 2, 0)
        TableLayoutPanel2.Controls.Add(Button4, 3, 0)
        TableLayoutPanel2.Controls.Add(Button5, 4, 0)
        TableLayoutPanel2.Controls.Add(Button6, 11, 0)
        TableLayoutPanel2.Controls.Add(Button7, 5, 0)
        TableLayoutPanel2.Controls.Add(Button8, 10, 0)
        TableLayoutPanel2.Controls.Add(btnpnl, 6, 0)
        TableLayoutPanel2.Controls.Add(Button10, 9, 0)
        TableLayoutPanel2.Controls.Add(Button11, 7, 0)
        TableLayoutPanel2.Controls.Add(Button12, 8, 0)
        TableLayoutPanel2.Controls.Add(btnAccounts, 1, 0)
        TableLayoutPanel2.Dock = DockStyle.Bottom
        TableLayoutPanel2.Location = New Point(0, 619)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(1284, 65)
        TableLayoutPanel2.TabIndex = 17
        ' 
        ' btnPaymentMethods
        ' 
        btnPaymentMethods.BackColor = Color.FromArgb(CByte(33), CByte(150), CByte(243))
        btnPaymentMethods.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnPaymentMethods.Location = New Point(215, 3)
        btnPaymentMethods.Name = "btnPaymentMethods"
        btnPaymentMethods.Size = New Size(100, 59)
        btnPaymentMethods.TabIndex = 9
        btnPaymentMethods.Text = "Payment" & vbCrLf & "Methods"
        btnPaymentMethods.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.FromArgb(CByte(156), CByte(39), CByte(176))
        Button4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button4.Location = New Point(321, 3)
        Button4.Name = "Button4"
        Button4.Size = New Size(100, 59)
        Button4.TabIndex = 8
        Button4.Text = "Purchase Return"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.FromArgb(CByte(255), CByte(87), CByte(34))
        Button5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button5.Location = New Point(427, 3)
        Button5.Name = "Button5"
        Button5.Size = New Size(100, 59)
        Button5.TabIndex = 10
        Button5.Text = "Cashbook"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.FromArgb(CByte(158), CByte(158), CByte(158))
        Button6.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button6.Location = New Point(1169, 3)
        Button6.Name = "Button6"
        Button6.Size = New Size(100, 59)
        Button6.TabIndex = 10
        Button6.Text = " ❌" & vbCrLf & "Exit"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        Button7.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button7.Location = New Point(533, 3)
        Button7.Name = "Button7"
        Button7.Size = New Size(100, 59)
        Button7.TabIndex = 8
        Button7.Text = "Ledgers"
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Button8
        ' 
        Button8.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        Button8.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button8.Location = New Point(1063, 3)
        Button8.Name = "Button8"
        Button8.Size = New Size(100, 59)
        Button8.TabIndex = 10
        Button8.Text = "    🔄" & vbCrLf & "Refresh"
        Button8.UseVisualStyleBackColor = False
        ' 
        ' btnpnl
        ' 
        btnpnl.BackColor = Color.FromArgb(CByte(0), CByte(188), CByte(212))
        btnpnl.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnpnl.Location = New Point(639, 3)
        btnpnl.Name = "btnpnl"
        btnpnl.Size = New Size(100, 59)
        btnpnl.TabIndex = 8
        btnpnl.Text = "P/NL"
        btnpnl.UseVisualStyleBackColor = False
        ' 
        ' Button10
        ' 
        Button10.BackColor = Color.FromArgb(CByte(96), CByte(125), CByte(139))
        Button10.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button10.Location = New Point(957, 3)
        Button10.Name = "Button10"
        Button10.Size = New Size(100, 59)
        Button10.TabIndex = 8
        Button10.Text = "   ⚙️" & vbCrLf & "Setting"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' Button11
        ' 
        Button11.BackColor = Color.FromArgb(CByte(139), CByte(195), CByte(74))
        Button11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button11.Location = New Point(745, 3)
        Button11.Name = "Button11"
        Button11.Size = New Size(100, 59)
        Button11.TabIndex = 10
        Button11.Text = "    📒 " & vbCrLf & "DayBook"
        Button11.UseVisualStyleBackColor = False
        ' 
        ' Button12
        ' 
        Button12.BackColor = Color.FromArgb(CByte(103), CByte(58), CByte(183))
        Button12.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Button12.Location = New Point(851, 3)
        Button12.Name = "Button12"
        Button12.Size = New Size(100, 59)
        Button12.TabIndex = 8
        Button12.Text = "   👤 " & vbCrLf & "Users"
        Button12.UseVisualStyleBackColor = False
        ' 
        ' btnAccounts
        ' 
        btnAccounts.BackColor = Color.FromArgb(CByte(255), CByte(152), CByte(0))
        btnAccounts.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnAccounts.Location = New Point(109, 3)
        btnAccounts.Name = "btnAccounts"
        btnAccounts.Size = New Size(100, 59)
        btnAccounts.TabIndex = 11
        btnAccounts.Text = "Add Account"
        btnAccounts.UseVisualStyleBackColor = False
        ' 
        ' frmMainDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1284, 749)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(Panel9)
        Controls.Add(Panel8)
        Controls.Add(ToolStrip2)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(GroupBox1)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "frmMainDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmMainDashboard"
        WindowState = FormWindowState.Maximized
        CType(dgvLowStock, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(dgvRecentSales, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblUserName As Label
    Friend WithEvents lblUserRole As Label
    Friend WithEvents timerClock As Timer
    Friend WithEvents lblTodaySales As Label
    Friend WithEvents lblTodayTransactions As Label
    Friend WithEvents lblTotalProducts As Label
    Friend WithEvents lblLowStock As Label
    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents lblMonthSales As Label
    Friend WithEvents dgvLowStock As DataGridView
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnExpenses As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnCustomers As Button
    Friend WithEvents lblDateTime As Label
    Friend WithEvents btnNewSale As Button
    Friend WithEvents btnSuppliers As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDayBook As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnPurchase As Button
    Friend WithEvents dgvRecentSales As DataGridView
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblTotalStock As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnProducts As Button
    Friend WithEvents FontDialog2 As FontDialog
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents btnCategories As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnPaymentMethods As Button
    Friend WithEvents btnAccounts As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents btnpnl As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
End Class
