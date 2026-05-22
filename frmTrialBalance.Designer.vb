<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrialBalance
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
        lblAsOf = New Label()
        dtpAsOf = New DateTimePicker()
        btnGenerate = New Button()
        btnExport = New Button()
        btnPrint = New Button()
        btnClose = New Button()
        dgvTrialBalance = New DataGridView()
        colAccountCode = New DataGridViewTextBoxColumn()
        colAccountName = New DataGridViewTextBoxColumn()
        colAccountType = New DataGridViewTextBoxColumn()
        colDebit = New DataGridViewTextBoxColumn()
        colCredit = New DataGridViewTextBoxColumn()
        pnlSummary = New Panel()
        lblBalanceCheck = New Label()
        lblTotalCredit = New Label()
        lblTotalDebit = New Label()
        CType(dgvTrialBalance, ComponentModel.ISupportInitialize).BeginInit()
        pnlSummary.SuspendLayout()
        SuspendLayout()
        '
        'lblAsOf
        '
        lblAsOf.AutoSize = True
        lblAsOf.Location = New Point(12, 20)
        lblAsOf.Name = "lblAsOf"
        lblAsOf.Size = New Size(55, 15)
        lblAsOf.TabIndex = 0
        lblAsOf.Text = "As Of Date"
        '
        'dtpAsOf
        '
        dtpAsOf.Format = DateTimePickerFormat.Short
        dtpAsOf.Location = New Point(73, 16)
        dtpAsOf.Name = "dtpAsOf"
        dtpAsOf.Size = New Size(120, 23)
        dtpAsOf.TabIndex = 1
        '
        'btnGenerate
        '
        btnGenerate.Location = New Point(218, 15)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(90, 28)
        btnGenerate.TabIndex = 2
        btnGenerate.Text = "Generate"
        btnGenerate.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        btnExport.Location = New Point(314, 15)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(90, 28)
        btnExport.TabIndex = 3
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        btnPrint.Location = New Point(410, 15)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(90, 28)
        btnPrint.TabIndex = 4
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        btnClose.Location = New Point(506, 15)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 28)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        '
        'dgvTrialBalance
        '
        dgvTrialBalance.AllowUserToAddRows = False
        dgvTrialBalance.BackgroundColor = Color.White
        dgvTrialBalance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTrialBalance.Columns.AddRange(New DataGridViewColumn() {colAccountCode, colAccountName, colAccountType, colDebit, colCredit})
        dgvTrialBalance.Location = New Point(12, 60)
        dgvTrialBalance.Name = "dgvTrialBalance"
        dgvTrialBalance.ReadOnly = True
        dgvTrialBalance.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTrialBalance.Size = New Size(980, 454)
        dgvTrialBalance.TabIndex = 6
        '
        'colAccountCode
        '
        colAccountCode.DataPropertyName = "AccountCode"
        colAccountCode.HeaderText = "AccountCode"
        colAccountCode.Name = "colAccountCode"
        colAccountCode.ReadOnly = True
        colAccountCode.Width = 120
        '
        'colAccountName
        '
        colAccountName.DataPropertyName = "AccountName"
        colAccountName.HeaderText = "AccountName"
        colAccountName.Name = "colAccountName"
        colAccountName.ReadOnly = True
        colAccountName.Width = 280
        '
        'colAccountType
        '
        colAccountType.DataPropertyName = "AccountType"
        colAccountType.HeaderText = "AccountType"
        colAccountType.Name = "colAccountType"
        colAccountType.ReadOnly = True
        colAccountType.Width = 140
        '
        'colDebit
        '
        colDebit.DataPropertyName = "Debit"
        colDebit.HeaderText = "Debit"
        colDebit.Name = "colDebit"
        colDebit.ReadOnly = True
        colDebit.Width = 180
        '
        'colCredit
        '
        colCredit.DataPropertyName = "Credit"
        colCredit.HeaderText = "Credit"
        colCredit.Name = "colCredit"
        colCredit.ReadOnly = True
        colCredit.Width = 180
        '
        'pnlSummary
        '
        pnlSummary.BackColor = Color.White
        pnlSummary.BorderStyle = BorderStyle.FixedSingle
        pnlSummary.Controls.Add(lblBalanceCheck)
        pnlSummary.Controls.Add(lblTotalCredit)
        pnlSummary.Controls.Add(lblTotalDebit)
        pnlSummary.Location = New Point(12, 523)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(980, 55)
        pnlSummary.TabIndex = 7
        '
        'lblBalanceCheck
        '
        lblBalanceCheck.AutoSize = True
        lblBalanceCheck.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblBalanceCheck.Location = New Point(746, 16)
        lblBalanceCheck.Name = "lblBalanceCheck"
        lblBalanceCheck.Size = New Size(88, 20)
        lblBalanceCheck.TabIndex = 0
        lblBalanceCheck.Text = "✅ Balanced"
        '
        'lblTotalCredit
        '
        lblTotalCredit.AutoSize = True
        lblTotalCredit.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalCredit.Location = New Point(403, 16)
        lblTotalCredit.Name = "lblTotalCredit"
        lblTotalCredit.Size = New Size(137, 20)
        lblTotalCredit.TabIndex = 0
        lblTotalCredit.Text = "Total Credit: 0.00"
        '
        'lblTotalDebit
        '
        lblTotalDebit.AutoSize = True
        lblTotalDebit.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        lblTotalDebit.Location = New Point(23, 16)
        lblTotalDebit.Name = "lblTotalDebit"
        lblTotalDebit.Size = New Size(129, 20)
        lblTotalDebit.TabIndex = 0
        lblTotalDebit.Text = "Total Debit: 0.00"
        '
        'frmTrialBalance
        '
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1004, 590)
        Controls.Add(pnlSummary)
        Controls.Add(dgvTrialBalance)
        Controls.Add(btnClose)
        Controls.Add(btnPrint)
        Controls.Add(btnExport)
        Controls.Add(btnGenerate)
        Controls.Add(dtpAsOf)
        Controls.Add(lblAsOf)
        Font = New Font("Segoe UI", 9.0!)
        Name = "frmTrialBalance"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Trial Balance"
        CType(dgvTrialBalance, ComponentModel.ISupportInitialize).EndInit()
        pnlSummary.ResumeLayout(False)
        pnlSummary.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblAsOf As Label
    Friend WithEvents dtpAsOf As DateTimePicker
    Friend WithEvents btnGenerate As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents dgvTrialBalance As DataGridView
    Friend WithEvents colAccountCode As DataGridViewTextBoxColumn
    Friend WithEvents colAccountName As DataGridViewTextBoxColumn
    Friend WithEvents colAccountType As DataGridViewTextBoxColumn
    Friend WithEvents colDebit As DataGridViewTextBoxColumn
    Friend WithEvents colCredit As DataGridViewTextBoxColumn
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents lblBalanceCheck As Label
    Friend WithEvents lblTotalCredit As Label
    Friend WithEvents lblTotalDebit As Label
End Class
