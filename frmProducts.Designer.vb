<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducts
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
        Panel2 = New Panel()
        Label14 = New Label()
        Panel3 = New Panel()
        btnAddCategory = New Button()
        Label15 = New Label()
        lblTotalProducts = New Label()
        txtSearch = New TextBox()
        chkActive = New CheckBox()
        Label1 = New Label()
        Panel4 = New Panel()
        Label5 = New Label()
        Label13 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnGenerateID = New Button()
        btnSearch = New Button()
        btnShowAll = New Button()
        btnClear = New Button()
        btnClose = New Button()
        btnSave = New Button()
        Panel1 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        dgvProducts = New DataGridView()
        txtBarcode = New TextBox()
        txtProductName = New TextBox()
        txtDescription = New TextBox()
        txtUnitPrice = New TextBox()
        txtCostPrice = New TextBox()
        txtStock = New TextBox()
        txtMaxStock = New TextBox()
        txtMinStock = New TextBox()
        cboCategory = New ComboBox()
        cboSupplier = New ComboBox()
        cboUnit = New ComboBox()
        txtProductID = New TextBox()
        Panel5 = New Panel()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Purple
        Panel2.Controls.Add(Label14)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1284, 44)
        Panel2.TabIndex = 1
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ForeColor = SystemColors.Control
        Label14.Location = New Point(3, 9)
        Label14.Name = "Label14"
        Label14.Size = New Size(198, 30)
        Label14.TabIndex = 0
        Label14.Text = "Add New Products"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(btnAddCategory)
        Panel3.Controls.Add(Label15)
        Panel3.Controls.Add(txtSearch)
        Panel3.Controls.Add(chkActive)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 44)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1284, 56)
        Panel3.TabIndex = 2
        ' 
        ' btnAddCategory
        ' 
        btnAddCategory.BackColor = Color.Purple
        btnAddCategory.Location = New Point(117, 21)
        btnAddCategory.Name = "btnAddCategory"
        btnAddCategory.Size = New Size(145, 32)
        btnAddCategory.TabIndex = 14
        btnAddCategory.Text = "ADD"
        btnAddCategory.UseVisualStyleBackColor = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label15.Location = New Point(456, 18)
        Label15.Name = "Label15"
        Label15.Size = New Size(119, 20)
        Label15.TabIndex = 15
        Label15.Text = "Search Products"
        ' 
        ' lblTotalProducts
        ' 
        lblTotalProducts.AutoSize = True
        lblTotalProducts.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        lblTotalProducts.Location = New Point(47, 530)
        lblTotalProducts.Name = "lblTotalProducts"
        lblTotalProducts.Size = New Size(37, 20)
        lblTotalProducts.TabIndex = 15
        lblTotalProducts.Text = "0.00"
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(580, 17)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(526, 23)
        txtSearch.TabIndex = 10
        ' 
        ' chkActive
        ' 
        chkActive.AutoSize = True
        chkActive.Location = New Point(28, 27)
        chkActive.Name = "chkActive"
        chkActive.Size = New Size(59, 19)
        chkActive.TabIndex = 1
        chkActive.Text = "Active"
        chkActive.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label1.Location = New Point(15, 136)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 20)
        Label1.TabIndex = 0
        Label1.Text = "Product ID:"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Label5)
        Panel4.Controls.Add(Label13)
        Panel4.Controls.Add(Label1)
        Panel4.Controls.Add(Label11)
        Panel4.Controls.Add(Label10)
        Panel4.Controls.Add(Label9)
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(Label7)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(Label3)
        Panel4.Controls.Add(Label2)
        Panel4.Dock = DockStyle.Left
        Panel4.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Panel4.Location = New Point(0, 100)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(117, 568)
        Panel4.TabIndex = 3
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label5.Location = New Point(40, 91)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 20)
        Label5.TabIndex = 14
        Label5.Text = "Unit"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label13.Location = New Point(26, 51)
        Label13.Name = "Label13"
        Label13.Size = New Size(66, 20)
        Label13.TabIndex = 9
        Label13.Text = "Supplier"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label11.Location = New Point(19, 15)
        Label11.Name = "Label11"
        Label11.Size = New Size(76, 20)
        Label11.TabIndex = 9
        Label11.Text = "Category "
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label10.Location = New Point(24, 480)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 20)
        Label10.TabIndex = 9
        Label10.Text = "Max _Stock"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label9.Location = New Point(24, 439)
        Label9.Name = "Label9"
        Label9.Size = New Size(77, 20)
        Label9.TabIndex = 8
        Label9.Text = "MIn_stock"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label8.Location = New Point(37, 400)
        Label8.Name = "Label8"
        Label8.Size = New Size(54, 20)
        Label8.TabIndex = 7
        Label8.Text = "Stock :"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label7.Location = New Point(28, 359)
        Label7.Name = "Label7"
        Label7.Size = New Size(75, 20)
        Label7.TabIndex = 6
        Label7.Text = "Sell Price:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label6.Location = New Point(24, 314)
        Label6.Name = "Label6"
        Label6.Size = New Size(80, 20)
        Label6.TabIndex = 5
        Label6.Text = "Cost Price:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label4.Location = New Point(20, 260)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 20)
        Label4.TabIndex = 3
        Label4.Text = "Description :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label3.Location = New Point(3, 218)
        Label3.Name = "Label3"
        Label3.Size = New Size(116, 20)
        Label3.TabIndex = 2
        Label3.Text = "Product Name :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold)
        Label2.Location = New Point(23, 176)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 20)
        Label2.TabIndex = 1
        Label2.Text = "Barcode:"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdate.Location = New Point(131, 3)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(122, 41)
        btnUpdate.TabIndex = 0
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Red
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(259, 3)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(122, 41)
        btnDelete.TabIndex = 0
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnGenerateID
        ' 
        btnGenerateID.BackColor = Color.Purple
        btnGenerateID.FlatStyle = FlatStyle.Flat
        btnGenerateID.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGenerateID.Location = New Point(387, 3)
        btnGenerateID.Name = "btnGenerateID"
        btnGenerateID.Size = New Size(122, 41)
        btnGenerateID.TabIndex = 0
        btnGenerateID.Text = "Genrate ID"
        btnGenerateID.UseVisualStyleBackColor = False
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.Maroon
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSearch.Location = New Point(515, 3)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(122, 41)
        btnSearch.TabIndex = 0
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnShowAll
        ' 
        btnShowAll.AllowDrop = True
        btnShowAll.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        btnShowAll.FlatStyle = FlatStyle.Flat
        btnShowAll.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnShowAll.Location = New Point(643, 3)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(122, 41)
        btnShowAll.TabIndex = 0
        btnShowAll.Text = "ShowAll"
        btnShowAll.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Fuchsia
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClear.Location = New Point(771, 3)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(122, 41)
        btnClear.TabIndex = 0
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(128), CByte(64), CByte(64))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Location = New Point(899, 3)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 41)
        btnClose.TabIndex = 0
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.Green
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.Location = New Point(3, 3)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(121, 41)
        btnSave.TabIndex = 0
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel2)
        Panel1.Controls.Add(dgvProducts)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(270, 100)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1014, 568)
        Panel1.TabIndex = 5
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.ColumnCount = 8
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 12.5F))
        TableLayoutPanel2.Controls.Add(btnSave, 0, 0)
        TableLayoutPanel2.Controls.Add(btnClear, 6, 0)
        TableLayoutPanel2.Controls.Add(btnShowAll, 5, 0)
        TableLayoutPanel2.Controls.Add(btnSearch, 4, 0)
        TableLayoutPanel2.Controls.Add(btnGenerateID, 3, 0)
        TableLayoutPanel2.Controls.Add(btnDelete, 2, 0)
        TableLayoutPanel2.Controls.Add(btnUpdate, 1, 0)
        TableLayoutPanel2.Controls.Add(btnClose, 7, 0)
        TableLayoutPanel2.Location = New Point(6, 517)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(1024, 48)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' dgvProducts
        ' 
        dgvProducts.BackgroundColor = SystemColors.ButtonHighlight
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Location = New Point(6, 6)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.Size = New Size(1005, 509)
        dgvProducts.TabIndex = 0
        ' 
        ' txtBarcode
        ' 
        txtBarcode.Location = New Point(5, 176)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(138, 25)
        txtBarcode.TabIndex = 1
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(5, 218)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(138, 25)
        txtProductName.TabIndex = 2
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(5, 260)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(138, 25)
        txtDescription.TabIndex = 3
        ' 
        ' txtUnitPrice
        ' 
        txtUnitPrice.Location = New Point(5, 354)
        txtUnitPrice.Name = "txtUnitPrice"
        txtUnitPrice.Size = New Size(138, 25)
        txtUnitPrice.TabIndex = 4
        ' 
        ' txtCostPrice
        ' 
        txtCostPrice.Location = New Point(5, 304)
        txtCostPrice.Name = "txtCostPrice"
        txtCostPrice.Size = New Size(138, 25)
        txtCostPrice.TabIndex = 5
        ' 
        ' txtStock
        ' 
        txtStock.Location = New Point(5, 390)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(138, 25)
        txtStock.TabIndex = 6
        ' 
        ' txtMaxStock
        ' 
        txtMaxStock.Location = New Point(5, 475)
        txtMaxStock.Name = "txtMaxStock"
        txtMaxStock.Size = New Size(138, 25)
        txtMaxStock.TabIndex = 10
        ' 
        ' txtMinStock
        ' 
        txtMinStock.Location = New Point(5, 434)
        txtMinStock.Name = "txtMinStock"
        txtMinStock.Size = New Size(138, 25)
        txtMinStock.TabIndex = 11
        ' 
        ' cboCategory
        ' 
        cboCategory.FormattingEnabled = True
        cboCategory.Location = New Point(5, 15)
        cboCategory.Name = "cboCategory"
        cboCategory.Size = New Size(138, 25)
        cboCategory.TabIndex = 12
        ' 
        ' cboSupplier
        ' 
        cboSupplier.FormattingEnabled = True
        cboSupplier.Location = New Point(5, 51)
        cboSupplier.Name = "cboSupplier"
        cboSupplier.Size = New Size(138, 25)
        cboSupplier.TabIndex = 13
        ' 
        ' cboUnit
        ' 
        cboUnit.FormattingEnabled = True
        cboUnit.Location = New Point(5, 91)
        cboUnit.Name = "cboUnit"
        cboUnit.Size = New Size(138, 25)
        cboUnit.TabIndex = 13
        ' 
        ' txtProductID
        ' 
        txtProductID.Location = New Point(5, 136)
        txtProductID.Name = "txtProductID"
        txtProductID.Size = New Size(138, 25)
        txtProductID.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(txtProductID)
        Panel5.Controls.Add(cboUnit)
        Panel5.Controls.Add(lblTotalProducts)
        Panel5.Controls.Add(cboSupplier)
        Panel5.Controls.Add(cboCategory)
        Panel5.Controls.Add(txtMinStock)
        Panel5.Controls.Add(txtMaxStock)
        Panel5.Controls.Add(txtStock)
        Panel5.Controls.Add(txtCostPrice)
        Panel5.Controls.Add(txtUnitPrice)
        Panel5.Controls.Add(txtDescription)
        Panel5.Controls.Add(txtProductName)
        Panel5.Controls.Add(txtBarcode)
        Panel5.Dock = DockStyle.Left
        Panel5.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Panel5.Location = New Point(117, 100)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(153, 568)
        Panel5.TabIndex = 4
        ' 
        ' frmProducts
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1284, 668)
        Controls.Add(Panel1)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Name = "frmProducts"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Product Management"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnGenerateID As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents txtCostPrice As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtMaxStock As TextBox
    Friend WithEvents txtMinStock As TextBox
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents cboUnit As ComboBox
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblTotalProducts As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label15 As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents btnAddCategory As Button
End Class
