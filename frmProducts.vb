Imports MySql.Data.MySqlClient
Public Class frmProducts
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    Private isEditMode As Boolean = False
    Private selectedProductID As String = ""

    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()
        LoadProducts()
        LoadCategories()
        LoadSuppliers()
        LoadUnits()
        SetupDataGridView()
        ClearFields()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        ' Auto-generate Product ID on form load
        GenerateNextProductID()
    End Sub

    Private Sub SetupDataGridView()
        With dgvProducts
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End With
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT p.ProductID, p.Barcode, p.ProductName, 
                                             c.CategoryName, s.SupplierName,
                                             p.UnitPrice, p.CostPrice, p.Stock, 
                                             p.MinStock, p.Unit, p.IsActive
                                      FROM products p
                                      LEFT JOIN categories c ON p.CategoryID = c.CategoryID
                                      LEFT JOIN suppliers s ON p.SupplierID = s.SupplierID
                                      ORDER BY p.ProductName"

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvProducts.DataSource = dt
                FormatProductGrid()

                lblTotalProducts.Text = $"Total Products: {dt.Rows.Count}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatProductGrid()
        With dgvProducts
            If .Columns.Count > 0 Then
                .Columns("ProductID").HeaderText = "Product ID"
                .Columns("ProductID").Width = 70
                .Columns("Barcode").HeaderText = "Barcode"
                .Columns("Barcode").Width = 100
                .Columns("ProductName").HeaderText = "Product Name"
                .Columns("ProductName").Width = 150
                .Columns("CategoryName").HeaderText = "Category"
                .Columns("CategoryName").Width = 100
                .Columns("SupplierName").HeaderText = "Supplier"
                .Columns("SupplierName").Width = 150
                .Columns("UnitPrice").HeaderText = "Price (₹)"
                .Columns("UnitPrice").Width = 70
                .Columns("UnitPrice").DefaultCellStyle.Format = "N2"
                .Columns("UnitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("CostPrice").HeaderText = "Cost (₹)"
                .Columns("CostPrice").Width = 80
                .Columns("CostPrice").DefaultCellStyle.Format = "N2"
                .Columns("CostPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Stock").HeaderText = "Stock"
                .Columns("Stock").Width = 60
                .Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("MinStock").HeaderText = "Min Stock"
                .Columns("MinStock").Width = 60
                .Columns("MinStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Unit").HeaderText = "Unit"
                .Columns("Unit").Width = 60
                .Columns("IsActive").HeaderText = "Active"
                .Columns("IsActive").Width = 55

                ' Highlight low stock rows
                For Each row As DataGridViewRow In .Rows
                    If row.Cells("Stock").Value IsNot Nothing AndAlso row.Cells("MinStock").Value IsNot Nothing Then
                        If Convert.ToInt32(row.Cells("Stock").Value) <= Convert.ToInt32(row.Cells("MinStock").Value) Then
                            row.DefaultCellStyle.BackColor = Color.LightCoral
                        End If
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub LoadCategories()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT CategoryID, CategoryName FROM categories WHERE IsActive = TRUE ORDER BY CategoryName"
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                cboCategory.DataSource = dt
                cboCategory.DisplayMember = "CategoryName"
                cboCategory.ValueMember = "CategoryID"
                cboCategory.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT SupplierID, SupplierName FROM suppliers WHERE IsActive = TRUE ORDER BY SupplierName"
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                cboSupplier.DataSource = dt
                cboSupplier.DisplayMember = "SupplierName"
                cboSupplier.ValueMember = "SupplierID"
                cboSupplier.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUnits()
        cboUnit.Items.Clear()
        cboUnit.Items.AddRange(New String() {"Piece", "Kg", "Gram", "Liter", "ML", "Box", "Pack", "Dozen", "Meter", "Feet"})
        cboUnit.SelectedIndex = 0
    End Sub

    ' Generate next Product ID automatically
    Private Sub GenerateNextProductID()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT CONCAT('P', LPAD(COALESCE(MAX(CAST(SUBSTRING(ProductID, 2) AS UNSIGNED)), 0) + 1, 3, '0')) 
                                      FROM products 
                                      WHERE ProductID REGEXP '^P[0-9]+$'"
                Dim cmd As New MySqlCommand(query, conn)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                txtProductID.Text = If(result IsNot Nothing AndAlso Not IsDBNull(result), result.ToString(), "P001")
            End Using
        Catch ex As Exception
            txtProductID.Text = "P001"
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateFields() Then
            SaveProduct()
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtProductID.Text) Then
            MessageBox.Show("Please enter Product ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductID.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Please enter Product Name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Return False
        End If

        If cboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Category", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse Not IsNumeric(txtUnitPrice.Text) Then
            MessageBox.Show("Please enter valid Unit Price", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitPrice.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub SaveProduct()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "INSERT INTO products (ProductID, Barcode, ProductName, CategoryID, SupplierID, 
                                                            Description, UnitPrice, CostPrice, Stock, MinStock, MaxStock, Unit, IsActive)
                                      VALUES (@ProductID, @Barcode, @ProductName, @CategoryID, @SupplierID, 
                                              @Description, @UnitPrice, @CostPrice, @Stock, @MinStock, @MaxStock, @Unit, @IsActive)"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim())
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim())
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim())
                cmd.Parameters.AddWithValue("@CategoryID", If(cboCategory.SelectedValue IsNot Nothing, cboCategory.SelectedValue, DBNull.Value))
                cmd.Parameters.AddWithValue("@SupplierID", If(cboSupplier.SelectedValue IsNot Nothing, cboSupplier.SelectedValue, DBNull.Value))
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text))
                cmd.Parameters.AddWithValue("@CostPrice", If(String.IsNullOrEmpty(txtCostPrice.Text), 0, Convert.ToDecimal(txtCostPrice.Text)))
                cmd.Parameters.AddWithValue("@Stock", If(String.IsNullOrEmpty(txtStock.Text), 0, Convert.ToInt32(txtStock.Text)))
                cmd.Parameters.AddWithValue("@MinStock", If(String.IsNullOrEmpty(txtMinStock.Text), 5, Convert.ToInt32(txtMinStock.Text)))
                cmd.Parameters.AddWithValue("@MaxStock", If(String.IsNullOrEmpty(txtMaxStock.Text), 1000, Convert.ToInt32(txtMaxStock.Text)))
                cmd.Parameters.AddWithValue("@Unit", cboUnit.Text)
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts()
                ClearFieldsAfterSave()
                ' Generate next Product ID automatically for the next entry
                GenerateNextProductID()
                txtProductName.Focus()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Duplicate entry
                MessageBox.Show("Product ID or Barcode already exists!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ValidateFields() Then
            UpdateProduct()
        End If
    End Sub

    Private Sub UpdateProduct()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "UPDATE products SET 
                                      Barcode = @Barcode,
                                      ProductName = @ProductName,
                                      CategoryID = @CategoryID,
                                      SupplierID = @SupplierID,
                                      Description = @Description,
                                      UnitPrice = @UnitPrice,
                                      CostPrice = @CostPrice,
                                      Stock = @Stock,
                                      MinStock = @MinStock,
                                      MaxStock = @MaxStock,
                                      Unit = @Unit,
                                      IsActive = @IsActive
                                      WHERE ProductID = @ProductID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", selectedProductID)
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim())
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim())
                cmd.Parameters.AddWithValue("@CategoryID", If(cboCategory.SelectedValue IsNot Nothing, cboCategory.SelectedValue, DBNull.Value))
                cmd.Parameters.AddWithValue("@SupplierID", If(cboSupplier.SelectedValue IsNot Nothing, cboSupplier.SelectedValue, DBNull.Value))
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text))
                cmd.Parameters.AddWithValue("@CostPrice", If(String.IsNullOrEmpty(txtCostPrice.Text), 0, Convert.ToDecimal(txtCostPrice.Text)))
                cmd.Parameters.AddWithValue("@Stock", If(String.IsNullOrEmpty(txtStock.Text), 0, Convert.ToInt32(txtStock.Text)))
                cmd.Parameters.AddWithValue("@MinStock", If(String.IsNullOrEmpty(txtMinStock.Text), 5, Convert.ToInt32(txtMinStock.Text)))
                cmd.Parameters.AddWithValue("@MaxStock", If(String.IsNullOrEmpty(txtMaxStock.Text), 1000, Convert.ToInt32(txtMaxStock.Text)))
                cmd.Parameters.AddWithValue("@Unit", cboUnit.Text)
                cmd.Parameters.AddWithValue("@IsActive", chkActive.Checked)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts()
                ClearFields()
                GenerateNextProductID()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(selectedProductID) Then
            MessageBox.Show("Please select a product to delete", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Are you sure you want to delete product '{txtProductName.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DeleteProduct()
        End If
    End Sub

    Private Sub DeleteProduct()
        Try
            Using conn As New MySqlConnection(connectionString)
                ' Soft delete - just mark as inactive
                Dim query As String = "UPDATE products SET IsActive = FALSE WHERE ProductID = @ProductID"

                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", selectedProductID)

                conn.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts()
                ClearFields()
                GenerateNextProductID()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)

                selectedProductID = row.Cells("ProductID").Value.ToString()
                txtProductID.Text = selectedProductID
                txtBarcode.Text = If(row.Cells("Barcode").Value IsNot Nothing, row.Cells("Barcode").Value.ToString(), "")
                txtProductName.Text = row.Cells("ProductName").Value.ToString()

                ' Set category
                If row.Cells("CategoryName").Value IsNot Nothing Then
                    cboCategory.Text = row.Cells("CategoryName").Value.ToString()
                End If

                ' Set supplier
                If row.Cells("SupplierName").Value IsNot Nothing Then
                    cboSupplier.Text = row.Cells("SupplierName").Value.ToString()
                End If

                txtUnitPrice.Text = Convert.ToDecimal(row.Cells("UnitPrice").Value).ToString("0.00")
                txtCostPrice.Text = Convert.ToDecimal(row.Cells("CostPrice").Value).ToString("0.00")
                txtStock.Text = row.Cells("Stock").Value.ToString()
                txtMinStock.Text = row.Cells("MinStock").Value.ToString()
                cboUnit.Text = row.Cells("Unit").Value.ToString()
                chkActive.Checked = Convert.ToBoolean(row.Cells("IsActive").Value)

                ' Load full details including description
                LoadProductDetails(selectedProductID)

                ' Enable edit/delete buttons
                isEditMode = True
                txtProductID.ReadOnly = True
                btnSave.Enabled = False
                btnUpdate.Enabled = True
                btnDelete.Enabled = True

            Catch ex As Exception
                MessageBox.Show($"Error loading product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LoadProductDetails(productID As String)
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT Description, MaxStock FROM products WHERE ProductID = @ProductID"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", productID)

                conn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    txtDescription.Text = If(reader("Description").ToString(), "")
                    txtMaxStock.Text = reader("MaxStock").ToString()
                End If

                reader.Close()
            End Using
        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
        GenerateNextProductID()
    End Sub

    ' New method: Clear fields after saving but keep category and supplier
    Private Sub ClearFieldsAfterSave()
        ' Store current category and supplier selections
        Dim savedCategoryIndex As Integer = cboCategory.SelectedIndex
        Dim savedSupplierIndex As Integer = cboSupplier.SelectedIndex
        Dim savedUnit As String = cboUnit.Text

        ' Clear all fields except Product ID (will be auto-generated)
        txtBarcode.Clear()
        txtProductName.Clear()
        txtDescription.Clear()
        txtUnitPrice.Clear()
        txtCostPrice.Clear()
        txtStock.Clear()
        txtMinStock.Text = "5"
        txtMaxStock.Text = "1000"
        chkActive.Checked = True

        ' Restore category and supplier selections
        cboCategory.SelectedIndex = savedCategoryIndex
        cboSupplier.SelectedIndex = savedSupplierIndex
        cboUnit.Text = savedUnit

        selectedProductID = ""
        isEditMode = False
        txtProductID.ReadOnly = True ' Keep it read-only for auto-generated IDs

        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub

    ' Original method: Clear all fields completely
    Private Sub ClearFields()
        txtProductID.Clear()
        txtBarcode.Clear()
        txtProductName.Clear()
        txtDescription.Clear()
        txtUnitPrice.Clear()
        txtCostPrice.Clear()
        txtStock.Clear()
        txtMinStock.Text = "5"
        txtMaxStock.Text = "1000"
        cboCategory.SelectedIndex = -1
        cboSupplier.SelectedIndex = -1
        cboUnit.SelectedIndex = 0
        chkActive.Checked = True

        selectedProductID = ""
        isEditMode = False
        txtProductID.ReadOnly = True ' Keep it read-only for auto-generated IDs

        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False

        txtProductName.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchProducts()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchProducts()
        End If
    End Sub

    Private Sub SearchProducts()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim query As String = "SELECT p.ProductID, p.Barcode, p.ProductName, 
                                             c.CategoryName, s.SupplierName,
                                             p.UnitPrice, p.CostPrice, p.Stock, 
                                             p.MinStock, p.Unit, p.IsActive
                                      FROM products p
                                      LEFT JOIN categories c ON p.CategoryID = c.CategoryID
                                      LEFT JOIN suppliers s ON p.SupplierID = s.SupplierID
                                      WHERE p.ProductID LIKE @Search 
                                      OR p.Barcode LIKE @Search
                                      OR p.ProductName LIKE @Search
                                      OR c.CategoryName LIKE @Search
                                      ORDER BY p.ProductName"

                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & txtSearch.Text.Trim() & "%")

                Dim dt As New DataTable()
                adapter.Fill(dt)

                dgvProducts.DataSource = dt
                FormatProductGrid()

                lblTotalProducts.Text = $"Found: {dt.Rows.Count} products"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        txtSearch.Clear()
        LoadProducts()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Manual button to generate Product ID (kept for compatibility)
    Private Sub btnGenerateID_Click(sender As Object, e As EventArgs) Handles btnGenerateID.Click
        GenerateNextProductID()
        txtProductName.Focus()
    End Sub

    Private Sub chkActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkActive.CheckedChanged

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        Dim frmCat As New frmCategories()
        frmCat.ShowDialog()
        LoadCategories() ' Refresh category dropdown
    End Sub

    Private Sub dgvProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellContentClick

    End Sub
End Class