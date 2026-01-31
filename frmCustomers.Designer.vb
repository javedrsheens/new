<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomers
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
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnUpdate = New Button()
        btnSave = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        btnAddPoints = New Button()
        btnGenerateCode = New Button()
        txtCreditLimit = New TextBox()
        txtLoyaltyPoints = New TextBox()
        txtCity = New TextBox()
        txtAddress = New TextBox()
        txtEmail = New TextBox()
        txtPhone = New TextBox()
        txtCustomerName = New TextBox()
        txtCustomerCode = New TextBox()
        chkActive = New CheckBox()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TabPage2 = New TabPage()
        dgvCustomers = New DataGridView()
        btnExport = New Button()
        btnShowAll = New Button()
        btnSearch = New Button()
        txtSearch = New TextBox()
        lblTotalCustomers = New Label()
        Label10 = New Label()
        Label9 = New Label()
        TabPage3 = New TabPage()
        btnClose = New Button()
        dgvPurchaseHistory = New DataGridView()
        lblTotalOrders = New Label()
        lblTotalSpent = New Label()
        Label11 = New Label()
        lblTotal = New Label()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TabPage2.SuspendLayout()
        CType(dgvCustomers, ComponentModel.ISupportInitialize).BeginInit()
        TabPage3.SuspendLayout()
        CType(dgvPurchaseHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveCaptionText
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 45)
        Panel1.TabIndex = 0
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 45)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(800, 405)
        TabControl1.TabIndex = 1
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.White
        TabPage1.Controls.Add(TableLayoutPanel1)
        TabPage1.Controls.Add(btnAddPoints)
        TabPage1.Controls.Add(btnGenerateCode)
        TabPage1.Controls.Add(txtCreditLimit)
        TabPage1.Controls.Add(txtLoyaltyPoints)
        TabPage1.Controls.Add(txtCity)
        TabPage1.Controls.Add(txtAddress)
        TabPage1.Controls.Add(txtEmail)
        TabPage1.Controls.Add(txtPhone)
        TabPage1.Controls.Add(txtCustomerName)
        TabPage1.Controls.Add(txtCustomerCode)
        TabPage1.Controls.Add(chkActive)
        TabPage1.Controls.Add(Label8)
        TabPage1.Controls.Add(Label7)
        TabPage1.Controls.Add(Label6)
        TabPage1.Controls.Add(Label5)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(Label2)
        TabPage1.Controls.Add(Label1)
        TabPage1.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(792, 377)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Customer Details"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel1.Controls.Add(btnUpdate, 1, 0)
        TableLayoutPanel1.Controls.Add(btnSave, 0, 0)
        TableLayoutPanel1.Controls.Add(btnClear, 3, 0)
        TableLayoutPanel1.Controls.Add(btnDelete, 2, 0)
        TableLayoutPanel1.Location = New Point(302, 320)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(373, 49)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(96, 3)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(87, 43)
        btnUpdate.TabIndex = 0
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(3, 3)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(87, 43)
        btnSave.TabIndex = 0
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' btnClear
        ' 
        btnClear.Location = New Point(282, 3)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(87, 43)
        btnClear.TabIndex = 0
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(189, 3)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(87, 43)
        btnDelete.TabIndex = 0
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnAddPoints
        ' 
        btnAddPoints.Location = New Point(345, 236)
        btnAddPoints.Name = "btnAddPoints"
        btnAddPoints.Size = New Size(140, 25)
        btnAddPoints.TabIndex = 0
        btnAddPoints.Text = "AddPoints"
        btnAddPoints.UseVisualStyleBackColor = True
        ' 
        ' btnGenerateCode
        ' 
        btnGenerateCode.Location = New Point(345, 16)
        btnGenerateCode.Name = "btnGenerateCode"
        btnGenerateCode.Size = New Size(140, 25)
        btnGenerateCode.TabIndex = 0
        btnGenerateCode.Text = "Generate Code"
        btnGenerateCode.UseVisualStyleBackColor = True
        ' 
        ' txtCreditLimit
        ' 
        txtCreditLimit.Location = New Point(156, 272)
        txtCreditLimit.Name = "txtCreditLimit"
        txtCreditLimit.Size = New Size(183, 25)
        txtCreditLimit.TabIndex = 2
        ' 
        ' txtLoyaltyPoints
        ' 
        txtLoyaltyPoints.Location = New Point(156, 236)
        txtLoyaltyPoints.Name = "txtLoyaltyPoints"
        txtLoyaltyPoints.Size = New Size(183, 25)
        txtLoyaltyPoints.TabIndex = 2
        ' 
        ' txtCity
        ' 
        txtCity.Location = New Point(156, 197)
        txtCity.Name = "txtCity"
        txtCity.Size = New Size(183, 25)
        txtCity.TabIndex = 2
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(156, 159)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(183, 25)
        txtAddress.TabIndex = 2
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(156, 123)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(183, 25)
        txtEmail.TabIndex = 2
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(156, 86)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(183, 25)
        txtPhone.TabIndex = 2
        ' 
        ' txtCustomerName
        ' 
        txtCustomerName.Location = New Point(156, 49)
        txtCustomerName.Name = "txtCustomerName"
        txtCustomerName.Size = New Size(183, 25)
        txtCustomerName.TabIndex = 2
        ' 
        ' txtCustomerCode
        ' 
        txtCustomerCode.Location = New Point(156, 16)
        txtCustomerCode.Name = "txtCustomerCode"
        txtCustomerCode.Size = New Size(183, 25)
        txtCustomerCode.TabIndex = 2
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Location = New Point(16, 330)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(91, 21)
        chkActive.TabIndex = 1
        chkActive.Text = "CheckBox1"
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(18, 280)
        Label8.Name = "Label8"
        Label8.Size = New Size(80, 17)
        Label8.TabIndex = 0
        Label8.Text = "Credit Limit:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(19, 236)
        Label7.Name = "Label7"
        Label7.Size = New Size(96, 17)
        Label7.TabIndex = 0
        Label7.Text = "Loyalty Points:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(19, 197)
        Label6.Name = "Label6"
        Label6.Size = New Size(34, 17)
        Label6.TabIndex = 0
        Label6.Text = "City:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(19, 159)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 17)
        Label5.TabIndex = 0
        Label5.Text = "Address:       "
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(19, 123)
        Label4.Name = "Label4"
        Label4.Size = New Size(79, 17)
        Label4.TabIndex = 0
        Label4.Text = "Email:         "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(22, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 17)
        Label3.TabIndex = 0
        Label3.Text = "Phone Number:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(22, 49)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 17)
        Label2.TabIndex = 0
        Label2.Text = "Customer Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(19, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(105, 17)
        Label1.TabIndex = 0
        Label1.Text = "Customer Code:"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(dgvCustomers)
        TabPage2.Controls.Add(btnExport)
        TabPage2.Controls.Add(btnShowAll)
        TabPage2.Controls.Add(btnSearch)
        TabPage2.Controls.Add(txtSearch)
        TabPage2.Controls.Add(lblTotalCustomers)
        TabPage2.Controls.Add(Label10)
        TabPage2.Controls.Add(Label9)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(792, 377)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Search & List"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' dgvCustomers
        ' 
        dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCustomers.Location = New Point(14, 124)
        dgvCustomers.Name = "dgvCustomers"
        dgvCustomers.Size = New Size(770, 247)
        dgvCustomers.TabIndex = 3
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(499, 83)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(75, 23)
        btnExport.TabIndex = 2
        btnExport.Text = "Export cvs"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnShowAll
        ' 
        btnShowAll.Location = New Point(499, 28)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(75, 23)
        btnShowAll.TabIndex = 2
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(400, 28)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 23)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(159, 28)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(224, 23)
        txtSearch.TabIndex = 1
        ' 
        ' lblTotalCustomers
        ' 
        lblTotalCustomers.AutoSize = True
        lblTotalCustomers.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalCustomers.Location = New Point(159, 83)
        lblTotalCustomers.Name = "lblTotalCustomers"
        lblTotalCustomers.Size = New Size(121, 20)
        lblTotalCustomers.TabIndex = 0
        lblTotalCustomers.Text = "Total Customers:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(17, 83)
        Label10.Name = "Label10"
        Label10.Size = New Size(121, 20)
        Label10.TabIndex = 0
        Label10.Text = "Total Customers:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(79, 28)
        Label9.Name = "Label9"
        Label9.Size = New Size(59, 20)
        Label9.TabIndex = 0
        Label9.Text = "Search:"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(btnClose)
        TabPage3.Controls.Add(dgvPurchaseHistory)
        TabPage3.Controls.Add(lblTotalOrders)
        TabPage3.Controls.Add(lblTotalSpent)
        TabPage3.Controls.Add(Label11)
        TabPage3.Controls.Add(lblTotal)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Size = New Size(792, 377)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Purchase History"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(168, 332)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(244, 33)
        btnClose.TabIndex = 2
        btnClose.Text = "close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' dgvPurchaseHistory
        ' 
        dgvPurchaseHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPurchaseHistory.Location = New Point(7, 113)
        dgvPurchaseHistory.Name = "dgvPurchaseHistory"
        dgvPurchaseHistory.Size = New Size(777, 198)
        dgvPurchaseHistory.TabIndex = 1
        ' 
        ' lblTotalOrders
        ' 
        lblTotalOrders.AutoSize = True
        lblTotalOrders.Location = New Point(292, 56)
        lblTotalOrders.Name = "lblTotalOrders"
        lblTotalOrders.Size = New Size(80, 15)
        lblTotalOrders.TabIndex = 0
        lblTotalOrders.Text = "lblTotalOrders"
        ' 
        ' lblTotalSpent
        ' 
        lblTotalSpent.AutoSize = True
        lblTotalSpent.Location = New Point(206, 56)
        lblTotalSpent.Name = "lblTotalSpent"
        lblTotalSpent.Size = New Size(68, 15)
        lblTotalSpent.TabIndex = 0
        lblTotalSpent.Text = "Total Spent:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(120, 56)
        Label11.Name = "Label11"
        Label11.Size = New Size(80, 15)
        Label11.TabIndex = 0
        Label11.Text = "lblTotalOrders"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(34, 56)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(80, 15)
        lblTotal.TabIndex = 0
        lblTotal.Text = "lblTotalOrders"
        ' 
        ' frmCustomers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TabControl1)
        Controls.Add(Panel1)
        Name = "frmCustomers"
        Text = "frmCustomers"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(dgvCustomers, ComponentModel.ISupportInitialize).EndInit()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        CType(dgvPurchaseHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtLoyaltyPoints As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents txtCustomerCode As TextBox
    Friend WithEvents txtCreditLimit As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnGenerateCode As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents dgvCustomers As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvPurchaseHistory As DataGridView
    Friend WithEvents lblTotalOrders As Label
    Friend WithEvents lblTotalSpent As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnAddPoints As Button
End Class
