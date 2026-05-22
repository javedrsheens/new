Imports System.Data.SqlTypes
Imports MySql.Data.MySqlClient

Public Class frmMainDashboard

    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Public CurrentUserID As Integer
    Public CurrentUserName As String
    Public CurrentUserRole As String

    Private Sub frmMainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboardData()
        SetupMenuPermissions()
        UpdateDateTime()
        dbconn()

        ' Display user info
        lblUserName.Text = $"Welcome, {CurrentUserName}"
        lblUserRole.Text = CurrentUserRole

        ' Start timer for clock
        timerClock.Interval = 1000
        timerClock.Start()
    End Sub

    Private Sub LoadDashboardData()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Today's Sales
                Dim salesQuery As String = "SELECT COALESCE(SUM(NetAmount), 0) AS TodaySales, 
                                                   COUNT(*) AS TodayTransactions
                                           FROM sales 
                                           WHERE DATE(SaleDate) = CURDATE()"
                Dim cmdSales As New MySqlCommand(salesQuery, conn)
                Dim readerSales As MySqlDataReader = cmdSales.ExecuteReader()
                If readerSales.Read() Then
                    lblTodaySales.Text = $"₹ {Convert.ToDecimal(readerSales("TodaySales")):N2}"
                    lblTodayTransactions.Text = readerSales("TodayTransactions").ToString()
                End If
                readerSales.Close()

                ' Total Products
                Dim productQuery As String = "SELECT COUNT(*) AS TotalProducts, 
                                                     SUM(Stock) AS TotalStock
                                             FROM products 
                                             WHERE IsActive = TRUE"
                Dim cmdProduct As New MySqlCommand(productQuery, conn)
                Dim readerProduct As MySqlDataReader = cmdProduct.ExecuteReader()
                If readerProduct.Read() Then
                    lblTotalProducts.Text = readerProduct("TotalProducts").ToString()
                    lblTotalStock.Text = readerProduct("TotalStock").ToString()
                End If
                readerProduct.Close()

                ' Low Stock Alert
                Dim lowStockQuery As String = "SELECT COUNT(*) AS LowStockItems 
                                              FROM products 
                                              WHERE Stock <= MinStock AND IsActive = TRUE"
                Dim cmdLowStock As New MySqlCommand(lowStockQuery, conn)
                lblLowStock.Text = cmdLowStock.ExecuteScalar().ToString()

                ' Total Customers
                Dim customerQuery As String = "SELECT COUNT(*) FROM customers WHERE IsActive = TRUE"
                Dim cmdCustomer As New MySqlCommand(customerQuery, conn)
                lblTotalCustomers.Text = cmdCustomer.ExecuteScalar().ToString()

                ' This Month Sales
                Dim monthQuery As String = "SELECT COALESCE(SUM(NetAmount), 0) 
                                           FROM sales 
                                           WHERE MONTH(SaleDate) = MONTH(CURDATE()) 
                                           AND YEAR(SaleDate) = YEAR(CURDATE())"
                Dim cmdMonth As New MySqlCommand(monthQuery, conn)
                lblMonthSales.Text = $"₹ {Convert.ToDecimal(cmdMonth.ExecuteScalar()):N2}"

                ' Load Recent Sales
                LoadRecentSales()

                ' Load Low Stock Items
                LoadLowStockItems()

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading dashboard:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRecentSales()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT s.InvoiceNo, 
                                             c.CustomerName, 
                                             s.NetAmount, 
                                             s.PaymentMethod,
                                             DATE_FORMAT(s.SaleDate, '%h:%i %p') AS Time
                                      FROM sales s
                                      LEFT JOIN customers c ON s.CustomerID = c.CustomerID
                                      WHERE DATE(s.SaleDate) = CURDATE()
                                      ORDER BY s. SaleDate DESC
                                      LIMIT 10"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvRecentSales.DataSource = dt

                ' Format columns
                If dgvRecentSales.Columns.Count > 0 Then
                    dgvRecentSales.Columns("InvoiceNo").HeaderText = "Invoice"
                    dgvRecentSales.Columns("CustomerName").HeaderText = "Customer"
                    dgvRecentSales.Columns("NetAmount").HeaderText = "Amount (₹)"
                    dgvRecentSales.Columns("PaymentMethod").HeaderText = "Payment"
                    dgvRecentSales.Columns("Time").HeaderText = "Time"
                    dgvRecentSales.Columns("NetAmount").DefaultCellStyle.Format = "N2"
                    dgvRecentSales.Columns("NetAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading recent sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLowStockItems()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT ProductID, 
                                             ProductName, 
                                             Stock, 
                                             MinStock,
                                             UnitPrice
                                      FROM products
                                      WHERE Stock <= MinStock 
                                      AND IsActive = TRUE
                                      ORDER BY Stock ASC
                                      LIMIT 10"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvLowStock.DataSource = dt

                ' Format columns
                If dgvLowStock.Columns.Count > 0 Then
                    dgvLowStock.Columns("ProductID").HeaderText = "ID"
                    dgvLowStock.Columns("ProductName").HeaderText = "Product Name"
                    dgvLowStock.Columns("Stock").HeaderText = "Current Stock"
                    dgvLowStock.Columns("MinStock").HeaderText = "Min Stock"
                    dgvLowStock.Columns("UnitPrice").HeaderText = "Price (₹)"
                    dgvLowStock.Columns("UnitPrice").DefaultCellStyle.Format = "N2"

                    ' Highlight low stock in red
                    For Each row As DataGridViewRow In dgvLowStock.Rows
                        If Convert.ToInt32(row.Cells("Stock").Value) < Convert.ToInt32(row.Cells("MinStock").Value) Then
                            row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    Next
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading low stock:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupMenuPermissions()
        ' Set menu access based on user role
        Select Case CurrentUserRole
            Case "Admin"
                ' Admin has access to everything

            Case "Manager"
                ' Manager has most access except some admin functions
                btnUsers.Enabled = False

            Case "Cashier"
                ' Cashier has limited access
                btnPurchase.Enabled = False
                btnExpenses.Enabled = False
                btnUsers.Enabled = False
                btnSettings.Enabled = False
                btnReports.Enabled = False

            Case Else
                ' Staff - very limited
                btnPurchase.Enabled = False
                btnExpenses.Enabled = False
                btnUsers.Enabled = False
                btnSettings.Enabled = False
                btnReports.Enabled = False
                btnCustomers.Enabled = False
        End Select
    End Sub

    Private Sub UpdateDateTime()
        lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh:mm: ss tt")
    End Sub

    Private Sub timerClock_Tick(sender As Object, e As EventArgs) Handles timerClock.Tick
        UpdateDateTime()
    End Sub

    ' ============================================
    ' MENU BUTTON CLICK EVENTS
    ' ============================================

    Private Sub btnNewSale_Click(sender As Object, e As EventArgs) Handles btnNewSale.Click
        Dim frmSale As New frmsales
        frmSale.CurrentUserID = CurrentUserID
        frmSale.CurrentUserName = CurrentUserName
        frmSale.ShowDialog
        LoadDashboardData ' Refresh after closing
    End Sub

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Dim frmCust As New frmCustomers
        frmCust.ShowDialog
    End Sub

    Private Sub btnSuppliers_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        Dim frmSupp As New frmSuppliers
        frmSupp.ShowDialog
    End Sub

    Private Sub btnExpenses_Click(sender As Object, e As EventArgs) Handles btnExpenses.Click
        Dim frmExp As New frmExpenses
        frmExp.CurrentUserID = CurrentUserID
        frmExp.ShowDialog
    End Sub

    Private Sub btnDayBook_Click(sender As Object, e As EventArgs) Handles btnDayBook.Click
        Dim frmDay As New frmDayBook
        frmDay.ShowDialog
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Dim frmRep As New frmReports
        frmRep.ShowDialog
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        Dim frmUsr As New frmUsers
        frmUsr.ShowDialog
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim frmSet As New frmSettings
        frmSet.ShowDialog
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboardData
        MessageBox.Show("Dashboard refreshed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
            Dim frmLog As New frmLogin()
            frmLog.Show()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit
        End If
    End Sub

    Private Sub btnProducts_Click_1(sender As Object, e As EventArgs) Handles btnProducts.Click
        Dim frmProd As New frmProducts
        frmProd.ShowDialog
        LoadDashboardData
    End Sub

    Private Sub btnPurchase_Click_1(sender As Object, e As EventArgs) Handles btnPurchase.Click
        Dim frmPurch As New frmPurchase
        frmPurch.CurrentUserID = CurrentUserID
        frmPurch.ShowDialog()
    End Sub

    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs) Handles FontDialog1.Apply

    End Sub
    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        Dim frmCat As New frmCategories()
        frmCat.ShowDialog()
    End Sub

    Private Sub btnPaymentMethods_Click(sender As Object, e As EventArgs) Handles btnPaymentMethods.Click
        Dim frm As New frmPaymentMethods()
        frm.ShowDialog()
    End Sub

    Private Sub btnAccounts_Click(sender As Object, e As EventArgs) Handles btnAccounts.Click
        Dim frmAcc As New frmAccounts()
        frmAcc.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frmRPurch As New frmpurchasereturn
        frmRPurch.CurrentUserID = CurrentUserID
        frmRPurch.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frmcBOOK As New frmCASHBOOK
        frmcBOOK.CurrentUserID = CurrentUserID
        frmcBOOK.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim frmledger As New frmAccountLedger
        frmledger.CurrentUserID = CurrentUserID
        frmledger.ShowDialog()
    End Sub

    Private Sub btnpnl_Click(sender As Object, e As EventArgs) Handles btnpnl.Click
        Dim frmpnl As New frmProfitLoss
        frmpnl.CurrentUserID = CurrentUserID
        frmpnl.ShowDialog()
        LoadDashboardData() ' ✅ Refresh dashboard after closing P&L form
    End Sub

    ' ============================================
    ' TOOLBAR BUTTON HANDLERS (Button6/8/10/11/12)
    ' ============================================

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        LoadDashboardData()
        MessageBox.Show("Dashboard refreshed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frmSet As New frmSettings
        frmSet.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim frmDay As New frmDayBook
        frmDay.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim frmUsr As New frmUsers
        frmUsr.ShowDialog()
    End Sub

    ' ============================================
    ' NEW MODULE NAVIGATION
    ' ============================================

    Private Sub btnSalesReturn_Click(sender As Object, e As EventArgs) Handles btnSalesReturn.Click
        Dim frmSR As New frmSalesReturn
        frmSR.CurrentUserID = CurrentUserID
        frmSR.ShowDialog()
        LoadDashboardData()
    End Sub

    Private Sub btnSubcategories_Click(sender As Object, e As EventArgs) Handles btnSubcategories.Click
        Dim frmSub As New frmSubcategories
        frmSub.ShowDialog()
    End Sub

    Private Sub btnStockTracking_Click(sender As Object, e As EventArgs) Handles btnStockTracking.Click
        Dim frmST As New frmStockTracking
        frmST.CurrentUserID = CurrentUserID
        frmST.ShowDialog()
    End Sub

    Private Sub btnProductHistory_Click(sender As Object, e As EventArgs) Handles btnProductHistory.Click
        Dim frmPH As New frmProductHistory
        frmPH.CurrentUserID = CurrentUserID
        frmPH.ShowDialog()
    End Sub

    Private Sub btnTrialBalance_Click(sender As Object, e As EventArgs) Handles btnTrialBalance.Click
        Dim frmTB As New frmTrialBalance
        frmTB.CurrentUserID = CurrentUserID
        frmTB.ShowDialog()
    End Sub

    Private Sub btnPurchaseOrder_Click(sender As Object, e As EventArgs) Handles btnPurchaseOrder.Click
        Dim frmPO As New frmPurchaseOrder
        frmPO.CurrentUserID = CurrentUserID
        frmPO.ShowDialog()
    End Sub
End Class
