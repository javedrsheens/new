<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockTracking
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
        pnlFilters = New Panel()
        btnClose = New Button()
        btnExport = New Button()
        btnShowAll = New Button()
        btnFilter = New Button()
        txtSearch = New TextBox()
        lblSearch = New Label()
        cboFilterSupplier = New ComboBox()
        lblSupplier = New Label()
        cboFilterCategory = New ComboBox()
        lblCategory = New Label()
        pnlSummary = New Panel()
        lblLowStockCount = New Label()
        lblTotalSaleValue = New Label()
        lblTotalStockValue = New Label()
        lblTotalItems = New Label()
        dgvStock = New DataGridView()
        pnlFilters.SuspendLayout()
        pnlSummary.SuspendLayout()
        CType(dgvStock, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'pnlFilters
        '
        pnlFilters.BackColor = Color.White
        pnlFilters.BorderStyle = BorderStyle.FixedSingle
        pnlFilters.Controls.Add(btnClose)
        pnlFilters.Controls.Add(btnExport)
        pnlFilters.Controls.Add(btnShowAll)
        pnlFilters.Controls.Add(btnFilter)
        pnlFilters.Controls.Add(txtSearch)
        pnlFilters.Controls.Add(lblSearch)
        pnlFilters.Controls.Add(cboFilterSupplier)
        pnlFilters.Controls.Add(lblSupplier)
        pnlFilters.Controls.Add(cboFilterCategory)
        pnlFilters.Controls.Add(lblCategory)
        pnlFilters.Location = New Point(12, 12)
        pnlFilters.Name = "pnlFilters"
        pnlFilters.Size = New Size(1160, 70)
        pnlFilters.TabIndex = 0
        '
        'btnClose
        '
        btnClose.Location = New Point(1056, 22)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(84, 30)
        btnClose.TabIndex = 9
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        btnExport.Location = New Point(966, 22)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(84, 30)
        btnExport.TabIndex = 8
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        '
        'btnShowAll
        '
        btnShowAll.Location = New Point(876, 22)
        btnShowAll.Name = "btnShowAll"
        btnShowAll.Size = New Size(84, 30)
        btnShowAll.TabIndex = 7
        btnShowAll.Text = "Show All"
        btnShowAll.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        btnFilter.Location = New Point(786, 22)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(84, 30)
        btnFilter.TabIndex = 6
        btnFilter.Text = "Filter"
        btnFilter.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        txtSearch.Location = New Point(567, 25)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(201, 23)
        txtSearch.TabIndex = 5
        '
        'lblSearch
        '
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(518, 28)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(42, 15)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Search"
        '
        'cboFilterSupplier
        '
        cboFilterSupplier.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterSupplier.FormattingEnabled = True
        cboFilterSupplier.Location = New Point(321, 24)
        cboFilterSupplier.Name = "cboFilterSupplier"
        cboFilterSupplier.Size = New Size(178, 23)
        cboFilterSupplier.TabIndex = 3
        '
        'lblSupplier
        '
        lblSupplier.AutoSize = True
        lblSupplier.Location = New Point(266, 28)
        lblSupplier.Name = "lblSupplier"
        lblSupplier.Size = New Size(49, 15)
        lblSupplier.TabIndex = 0
        lblSupplier.Text = "Supplier"
        '
        'cboFilterCategory
        '
        cboFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterCategory.FormattingEnabled = True
        cboFilterCategory.Location = New Point(70, 24)
        cboFilterCategory.Name = "cboFilterCategory"
        cboFilterCategory.Size = New Size(178, 23)
        cboFilterCategory.TabIndex = 1
        '
        'lblCategory
        '
        lblCategory.AutoSize = True
        lblCategory.Location = New Point(15, 28)
        lblCategory.Name = "lblCategory"
        lblCategory.Size = New Size(55, 15)
        lblCategory.TabIndex = 0
        lblCategory.Text = "Category"
        '
        'pnlSummary
        '
        pnlSummary.BackColor = Color.White
        pnlSummary.BorderStyle = BorderStyle.FixedSingle
        pnlSummary.Controls.Add(lblLowStockCount)
        pnlSummary.Controls.Add(lblTotalSaleValue)
        pnlSummary.Controls.Add(lblTotalStockValue)
        pnlSummary.Controls.Add(lblTotalItems)
        pnlSummary.Location = New Point(12, 88)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(1160, 60)
        pnlSummary.TabIndex = 1
        '
        'lblLowStockCount
        '
        lblLowStockCount.AutoSize = True
        lblLowStockCount.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblLowStockCount.Location = New Point(878, 19)
        lblLowStockCount.Name = "lblLowStockCount"
        lblLowStockCount.Size = New Size(126, 20)
        lblLowStockCount.TabIndex = 0
        lblLowStockCount.Text = "Low Stock Count: 0"
        '
        'lblTotalSaleValue
        '
        lblTotalSaleValue.AutoSize = True
        lblTotalSaleValue.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalSaleValue.Location = New Point(565, 19)
        lblTotalSaleValue.Name = "lblTotalSaleValue"
        lblTotalSaleValue.Size = New Size(153, 20)
        lblTotalSaleValue.TabIndex = 0
        lblTotalSaleValue.Text = "Total Sale Value: 0.00"
        '
        'lblTotalStockValue
        '
        lblTotalStockValue.AutoSize = True
        lblTotalStockValue.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalStockValue.Location = New Point(278, 19)
        lblTotalStockValue.Name = "lblTotalStockValue"
        lblTotalStockValue.Size = New Size(163, 20)
        lblTotalStockValue.TabIndex = 0
        lblTotalStockValue.Text = "Total Stock Value: 0.00"
        '
        'lblTotalItems
        '
        lblTotalItems.AutoSize = True
        lblTotalItems.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalItems.Location = New Point(14, 19)
        lblTotalItems.Name = "lblTotalItems"
        lblTotalItems.Size = New Size(94, 20)
        lblTotalItems.TabIndex = 0
        lblTotalItems.Text = "Total Items: 0"
        '
        'dgvStock
        '
        dgvStock.AllowUserToAddRows = False
        dgvStock.BackgroundColor = Color.White
        dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStock.Location = New Point(12, 154)
        dgvStock.Name = "dgvStock"
        dgvStock.ReadOnly = True
        dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStock.Size = New Size(1160, 484)
        dgvStock.TabIndex = 2
        '
        'frmStockTracking
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1184, 650)
        Controls.Add(dgvStock)
        Controls.Add(pnlSummary)
        Controls.Add(pnlFilters)
        Font = New Font("Segoe UI", 9.0!)
        Name = "frmStockTracking"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Stock Tracking"
        pnlFilters.ResumeLayout(False)
        pnlFilters.PerformLayout()
        pnlSummary.ResumeLayout(False)
        pnlSummary.PerformLayout()
        CType(dgvStock, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlFilters As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnShowAll As Button
    Friend WithEvents btnFilter As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents cboFilterSupplier As ComboBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents cboFilterCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents lblLowStockCount As Label
    Friend WithEvents lblTotalSaleValue As Label
    Friend WithEvents lblTotalStockValue As Label
    Friend WithEvents lblTotalItems As Label
    Friend WithEvents dgvStock As DataGridView
End Class
