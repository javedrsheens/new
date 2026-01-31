Imports MySql.Data.MySqlClient


Public Class frmCustomers
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private isEditMode As Boolean = False
    Private selectedCustomerID As Integer = 0

    Private Sub frmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        SetupDataGridView()
        ClearFields()
        dbconn()

        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub SetupDataGridView()
        With dgvCustomers
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub LoadCustomers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          CustomerID,
                                          CustomerCode AS 'Code',
                                          CustomerName AS 'Name',
                                          Phone,
                                          Email,
                                          Address,
                                          City,
                                          LoyaltyPoints AS 'Points',
                                          CreditLimit AS 'Credit Limit',
                                          IsActive AS 'Active'
                                      FROM customers
                                      ORDER BY CustomerName"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCustomers.DataSource = dt
                FormatCustomerGrid()

                lblTotalCustomers.Text = $"Total Customers: {dt.Rows.Count}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatCustomerGrid()
        With dgvCustomers
            If .Columns.Count > 0 Then
                .Columns("CustomerID").Visible = False
                .Columns("Code").Width = 100
                .Columns("Name").Width = 200
                .Columns("Phone").Width = 120
                .Columns("Email").Width = 180
                .Columns("Address").Width = 200
                .Columns("City").Width = 100
                .Columns("Points").Width = 80
                .Columns("Credit Limit").Width = 100
                .Columns("Active").Width = 70

                .Columns("Points").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Credit Limit").DefaultCellStyle.Format = "N2"
                .Columns("Credit Limit").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateFields() Then
            SaveCustomer()
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtCustomerName.Text) Then
            MessageBox.Show("Please enter Customer Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerName.Focus()
            Return False
        End If

        If Not String.IsNullOrEmpty(txtPhone.Text) Then
            If txtPhone.Text.Length < 10 Then
                MessageBox.Show("Please enter a valid phone number (minimum 10 digits)", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPhone.Focus()
                Return False
            End If
        End If

        If Not String.IsNullOrEmpty(txtEmail.Text) Then
            If Not txtEmail.Text.Contains("@") Or Not txtEmail.Text.Contains(".") Then
                MessageBox.Show("Please enter a valid email address", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SaveCustomer()
        Try
            Using conn As New MySqlConnection(connectionString)
                ' Generate customer code if empty
                If String.IsNullOrWhiteSpace(txtCustomerCode.Text) Then
                    txtCustomerCode.Text = GenerateCustomerCode()
                End If

                Dim query As String = "INSERT INTO customers (CustomerCode, CustomerName, Phone, Email, Address, City, LoyaltyPoints, CreditLimit, IsActive)
                                      VALUES (@Code, @Name, @Phone, @Email, @Address, @City, @Points, @CreditLimit, @IsActive)"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Code", txtCustomerCode.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                cmd.Parameters.AddWithValue("@Points", If(String.IsNullOrEmpty(txtLoyaltyPoints.Text), 0, Convert.ToInt32(txtLoyaltyPoints.Text)))
                cmd.Parameters.AddWithValue("@CreditLimit", If(String.IsNullOrEmpty(txtCreditLimit.Text), 0, Convert.ToDecimal(txtCreditLimit.Text)))
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCustomers()
                ClearFields()
                txtCustomerName.Focus()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Duplicate entry
                MessageBox.Show("Customer Code already exists!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateCustomerCode() As String
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT CONCAT('C', LPAD(COALESCE(MAX(CAST(SUBSTRING(CustomerCode, 2) AS UNSIGNED)), 0) + 1, 4, '0')) 
                                      FROM customers 
                                      WHERE CustomerCode REGEXP '^C[0-9]+$'"
                Dim cmd As New MySqlCommand(query, conn)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                Return If(result IsNot Nothing, result.ToString(), "C0001")
            End Using
        Catch ex As Exception
            Return "C0001"
        End Try
    End Function

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateFields() Then
            UpdateCustomer()
        End If
    End Sub

    Private Sub UpdateCustomer()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "UPDATE customers SET 
                                      CustomerCode = @Code,
                                      CustomerName = @Name,
                                      Phone = @Phone,
                                      Email = @Email,
                                      Address = @Address,
                                      City = @City,
                                      LoyaltyPoints = @Points,
                                      CreditLimit = @CreditLimit,
                                      IsActive = @IsActive
                                      WHERE CustomerID = @CustomerID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID)
                cmd.Parameters.AddWithValue("@Code", txtCustomerCode.Text.Trim())
                cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim())
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim())
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim())
                cmd.Parameters.AddWithValue("@Points", If(String.IsNullOrEmpty(txtLoyaltyPoints.Text), 0, Convert.ToInt32(txtLoyaltyPoints.Text)))
                cmd.Parameters.AddWithValue("@CreditLimit", If(String.IsNullOrEmpty(txtCreditLimit.Text), 0, Convert.ToDecimal(txtCreditLimit.Text)))
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCustomers()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedCustomerID = 0 Then
            MessageBox.Show("Please select a customer to delete", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Prevent deleting walk-in customer
        If selectedCustomerID = 1 Then
            MessageBox.Show("Cannot delete Walk-in Customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If MessageBox.Show($"Are you sure you want to delete customer '{txtCustomerName.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteCustomer()
        End If
    End Sub

    Private Sub DeleteCustomer()
        Try
            Using conn As New MySqlConnection(connectionString)
                ' Soft delete - just mark as inactive
                Dim query As String = "UPDATE customers SET IsActive = FALSE WHERE CustomerID = @CustomerID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadCustomers()
                ClearFields()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvCustomers.Rows(e.RowIndex)

                selectedCustomerID = Convert.ToInt32(row.Cells("CustomerID").Value)
                txtCustomerCode.Text = row.Cells("Code").Value.ToString()
                txtCustomerName.Text = row.Cells("Name").Value.ToString()
                txtPhone.Text = If(row.Cells("Phone").Value IsNot Nothing, row.Cells("Phone").Value.ToString(), "")
                txtEmail.Text = If(row.Cells("Email").Value IsNot Nothing, row.Cells("Email").Value.ToString(), "")
                txtAddress.Text = If(row.Cells("Address").Value IsNot Nothing, row.Cells("Address").Value.ToString(), "")
                txtCity.Text = If(row.Cells("City").Value IsNot Nothing, row.Cells("City").Value.ToString(), "")
                txtLoyaltyPoints.Text = row.Cells("Points").Value.ToString()
                txtCreditLimit.Text = Convert.ToDecimal(row.Cells("Credit Limit").Value).ToString("0.00")
                chkActive.Checked = Convert.ToBoolean(row.Cells("Active").Value)

                ' Enable edit/delete buttons
                isEditMode = True
                txtCustomerCode.ReadOnly = True
                btnSave.Enabled = False
                btnUpdate.Enabled = True
                btnDelete.Enabled = True

                ' Load purchase history
                LoadCustomerPurchaseHistory(selectedCustomerID)

            Catch ex As Exception
                MessageBox.Show($"Error loading customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LoadCustomerPurchaseHistory(customerID As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          InvoiceNo AS 'Invoice',
                                          DATE_FORMAT(SaleDate, '%d-%m-%Y') AS 'Date',
                                          NetAmount AS 'Amount',
                                          PaymentMethod AS 'Payment',
                                          PaymentStatus AS 'Status'
                                      FROM sales
                                      WHERE CustomerID = @CustomerID
                                      ORDER BY SaleDate DESC
                                      LIMIT 10"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID)

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvPurchaseHistory.DataSource = dt

                If dgvPurchaseHistory.Columns.Count > 0 Then
                    dgvPurchaseHistory.Columns("Amount").DefaultCellStyle.Format = "N2"
                    dgvPurchaseHistory.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If

                ' Calculate total purchases
                Dim totalQuery As String = "SELECT 
                                               COUNT(*) AS TotalOrders,
                                               COALESCE(SUM(NetAmount), 0) AS TotalAmount
                                           FROM sales 
                                           WHERE CustomerID = @CustomerID"
                Dim cmdTotal As New MySqlCommand(totalQuery, conn)
                cmdTotal.Parameters.AddWithValue("@CustomerID", customerID)

                conn.Open()
                Dim reader As MySqlDataReader = cmdTotal.ExecuteReader()

                If reader.Read() Then
                    lblTotalOrders.Text = $"Total Orders: {reader("TotalOrders")}"
                    lblTotalSpent.Text = $"Total Spent: ₹ {Convert.ToDecimal(reader("TotalAmount")):N2}"
                End If

                reader.Close()
            End Using
        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtCustomerCode.Clear()
        txtCustomerName.Clear()
        txtPhone.Clear()
        txtEmail.Clear()
        txtAddress.Clear()
        txtCity.Clear()
        txtLoyaltyPoints.Text = "0"
        txtCreditLimit.Text = "0.00"
        chkActive.Checked = True

        selectedCustomerID = 0
        isEditMode = False
        txtCustomerCode.ReadOnly = False

        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False

        dgvPurchaseHistory.DataSource = Nothing
        lblTotalOrders.Text = "Total Orders: 0"
        lblTotalSpent.Text = "Total Spent: ₹ 0.00"

        txtCustomerName.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchCustomers()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchCustomers()
        End If
    End Sub

    Private Sub SearchCustomers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT 
                                          CustomerID,
                                          CustomerCode AS 'Code',
                                          CustomerName AS 'Name',
                                          Phone,
                                          Email,
                                          Address,
                                          City,
                                          LoyaltyPoints AS 'Points',
                                          CreditLimit AS 'Credit Limit',
                                          IsActive AS 'Active'
                                      FROM customers
                                      WHERE CustomerCode LIKE @Search 
                                      OR CustomerName LIKE @Search
                                      OR Phone LIKE @Search
                                      OR Email LIKE @Search
                                      OR City LIKE @Search
                                      ORDER BY CustomerName"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & txtSearch.Text.Trim() & "%")

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvCustomers.DataSource = dt
                FormatCustomerGrid()

                lblTotalCustomers.Text = $"Found:  {dt.Rows.Count} customers"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadCustomers()
    End Sub

    Private Sub btnGenerateCode_Click(sender As Object, e As EventArgs) Handles btnGenerateCode.Click
        txtCustomerCode.Text = GenerateCustomerCode()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToCSV()
    End Sub

    Private Sub ExportToCSV()
        Try
            If dgvCustomers.Rows.Count = 0 Then
                MessageBox.Show("No data to export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            sfd.FileName = $"Customers_{DateTime.Now:yyyyMMdd_HHmmss}. csv"

            If sfd.ShowDialog() = DialogResult.OK Then
                Dim csv As New System.Text.StringBuilder()

                ' Add headers
                For i As Integer = 0 To dgvCustomers.Columns.Count - 1
                    If dgvCustomers.Columns(i).Visible Then
                        csv.Append(dgvCustomers.Columns(i).HeaderText)
                        If i < dgvCustomers.Columns.Count - 1 Then
                            csv.Append(",")
                        End If
                    End If
                Next
                csv.AppendLine()

                ' Add rows
                For Each row As DataGridViewRow In dgvCustomers.Rows
                    For i As Integer = 0 To dgvCustomers.Columns.Count - 1
                        If dgvCustomers.Columns(i).Visible Then
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString().Replace(",", ";"), "")
                            csv.Append(cellValue)
                            If i < dgvCustomers.Columns.Count - 1 Then
                                csv.Append(",")
                            End If
                        End If
                    Next
                    csv.AppendLine()
                Next

                System.IO.File.WriteAllText(sfd.FileName, csv.ToString())

                MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If MessageBox.Show("Do you want to open the file? ", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(sfd.FileName)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show($"Error exporting:  {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Phone number validation - only allow numbers
    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "+"c Then
            e.Handled = True
        End If
    End Sub

    ' Loyalty Points - only allow numbers
    Private Sub txtLoyaltyPoints_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoyaltyPoints.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Credit Limit - allow numbers and decimal point
    Private Sub txtCreditLimit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCreditLimit.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "."c AndAlso txtCreditLimit.Text.Contains(". ") Then
            e.Handled = True
        End If
    End Sub

    ' Add loyalty points button
    Private Sub btnAddPoints_Click(sender As Object, e As EventArgs) Handles btnAddPoints.Click
        If selectedCustomerID = 0 Then
            MessageBox.Show("Please select a customer first", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim input As String = InputBox("Enter loyalty points to add:", "Add Loyalty Points", "0")

        If IsNumeric(input) Then
            Dim pointsToAdd As Integer = Convert.ToInt32(input)
            Dim currentPoints As Integer = If(String.IsNullOrEmpty(txtLoyaltyPoints.Text), 0, Convert.ToInt32(txtLoyaltyPoints.Text))

            Try
                Using conn As New MySqlConnection(connectionString)
                    Dim query As String = "UPDATE customers SET LoyaltyPoints = LoyaltyPoints + @Points WHERE CustomerID = @CustomerID"
                    Dim cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Points", pointsToAdd)
                    cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID)

                    conn.Open()
                    cmd.ExecuteNonQuery()

                    txtLoyaltyPoints.Text = (currentPoints + pointsToAdd).ToString()
                    MessageBox.Show($"{pointsToAdd} points added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCustomers()
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error adding points: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
