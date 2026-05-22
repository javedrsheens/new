<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductHistory
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
        lblSearch = New Label()
        txtProductSearch = New TextBox()
        btnSearchProduct = New Button()
        lblProductInfo = New Label()
        lblFromDate = New Label()
        dtpFromDate = New DateTimePicker()
        lblToDate = New Label()
        dtpToDate = New DateTimePicker()
        lblHistoryType = New Label()
        cboHistoryType = New ComboBox()
        btnLoad = New Button()
        btnExport = New Button()
        btnClose = New Button()
        dgvHistory = New DataGridView()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'lblSearch
        '
        lblSearch.AutoSize = True
        lblSearch.Location = New Point(12, 18)
        lblSearch.Name = "lblSearch"
        lblSearch.Size = New Size(87, 15)
        lblSearch.TabIndex = 0
        lblSearch.Text = "Product Search"
        '
        'txtProductSearch
        '
        txtProductSearch.Location = New Point(105, 15)
        txtProductSearch.Name = "txtProductSearch"
        txtProductSearch.Size = New Size(300, 23)
        txtProductSearch.TabIndex = 1
        '
        'btnSearchProduct
        '
        btnSearchProduct.Location = New Point(411, 14)
        btnSearchProduct.Name = "btnSearchProduct"
        btnSearchProduct.Size = New Size(110, 26)
        btnSearchProduct.TabIndex = 2
        btnSearchProduct.Text = "Search Product"
        btnSearchProduct.UseVisualStyleBackColor = True
        '
        'lblProductInfo
        '
        lblProductInfo.BorderStyle = BorderStyle.FixedSingle
        lblProductInfo.Location = New Point(12, 50)
        lblProductInfo.Name = "lblProductInfo"
        lblProductInfo.Size = New Size(980, 36)
        lblProductInfo.TabIndex = 0
        lblProductInfo.Text = "No product selected"
        lblProductInfo.TextAlign = ContentAlignment.MiddleLeft
        '
        'lblFromDate
        '
        lblFromDate.AutoSize = True
        lblFromDate.Location = New Point(12, 101)
        lblFromDate.Name = "lblFromDate"
        lblFromDate.Size = New Size(61, 15)
        lblFromDate.TabIndex = 0
        lblFromDate.Text = "From Date"
        '
        'dtpFromDate
        '
        dtpFromDate.Format = DateTimePickerFormat.Short
        dtpFromDate.Location = New Point(79, 97)
        dtpFromDate.Name = "dtpFromDate"
        dtpFromDate.Size = New Size(120, 23)
        dtpFromDate.TabIndex = 3
        '
        'lblToDate
        '
        lblToDate.AutoSize = True
        lblToDate.Location = New Point(215, 101)
        lblToDate.Name = "lblToDate"
        lblToDate.Size = New Size(47, 15)
        lblToDate.TabIndex = 0
        lblToDate.Text = "To Date"
        '
        'dtpToDate
        '
        dtpToDate.Format = DateTimePickerFormat.Short
        dtpToDate.Location = New Point(268, 97)
        dtpToDate.Name = "dtpToDate"
        dtpToDate.Size = New Size(120, 23)
        dtpToDate.TabIndex = 4
        '
        'lblHistoryType
        '
        lblHistoryType.AutoSize = True
        lblHistoryType.Location = New Point(405, 101)
        lblHistoryType.Name = "lblHistoryType"
        lblHistoryType.Size = New Size(72, 15)
        lblHistoryType.TabIndex = 0
        lblHistoryType.Text = "History Type"
        '
        'cboHistoryType
        '
        cboHistoryType.DropDownStyle = ComboBoxStyle.DropDownList
        cboHistoryType.FormattingEnabled = True
        cboHistoryType.Location = New Point(483, 97)
        cboHistoryType.Name = "cboHistoryType"
        cboHistoryType.Size = New Size(180, 23)
        cboHistoryType.TabIndex = 5
        '
        'btnLoad
        '
        btnLoad.Location = New Point(690, 95)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(90, 28)
        btnLoad.TabIndex = 6
        btnLoad.Text = "Load"
        btnLoad.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        btnExport.Location = New Point(786, 95)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(90, 28)
        btnExport.TabIndex = 7
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Location = New Point(882, 95)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 28)
        btnClose.TabIndex = 8
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'dgvHistory
        '
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.BackgroundColor = Color.White
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistory.Location = New Point(12, 136)
        dgvHistory.Name = "dgvHistory"
        dgvHistory.ReadOnly = True
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.Size = New Size(980, 432)
        dgvHistory.TabIndex = 9
        '
        'frmProductHistory
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1004, 580)
        Controls.Add(dgvHistory)
        Controls.Add(btnClose)
        Controls.Add(btnExport)
        Controls.Add(btnLoad)
        Controls.Add(cboHistoryType)
        Controls.Add(lblHistoryType)
        Controls.Add(dtpToDate)
        Controls.Add(lblToDate)
        Controls.Add(dtpFromDate)
        Controls.Add(lblFromDate)
        Controls.Add(lblProductInfo)
        Controls.Add(btnSearchProduct)
        Controls.Add(txtProductSearch)
        Controls.Add(lblSearch)
        Font = New Font("Segoe UI", 9.0!)
        Name = "frmProductHistory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Product History"
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblSearch As Label
    Friend WithEvents txtProductSearch As TextBox
    Friend WithEvents btnSearchProduct As Button
    Friend WithEvents lblProductInfo As Label
    Friend WithEvents lblFromDate As Label
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents lblToDate As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents lblHistoryType As Label
    Friend WithEvents cboHistoryType As ComboBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents dgvHistory As DataGridView
End Class
