Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class frmPurchaseOrder
    Private connectionString As String = "server=localhost;username=root;password=Ayyaan@8941;port=3306;database=posdb"
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property CurrentUserID As Integer

    Private cartTable As DataTable
    Private lastPrintedLines As List(Of String) = New List(Of String)()

    Private Sub frmPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SetupCartTable()
            SetupGrids()
            LoadSuppliers()
            LoadCategories()
            LoadProducts()
            GeneratePONumber()
            dtpPODate.Value = DateTime.Now
        Catch ex As Exception
            MessageBox.Show($"Error loading purchase order form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupCartTable()
        cartTable = New DataTable()
        cartTable.Columns.Add("ProductID", GetType(Integer))
        cartTable.Columns.Add("ProductName", GetType(String))
        cartTable.Columns.Add("OrderQty", GetType(Decimal))
        cartTable.Columns.Add("UnitPrice", GetType(Decimal))
        cartTable.Columns.Add("Amount", GetType(Decimal))
        dgvCart.AutoGenerateColumns = False
        dgvCart.DataSource = cartTable
    End Sub

    Private Sub SetupGrids()
        For Each grid As DataGridView In {dgvProducts, dgvCart}
            With grid
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .BackgroundColor = Color.White
                .BorderStyle = BorderStyle.Fixed3D
                .RowHeadersVisible = False
                .EnableHeadersVisualStyles = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            End With
        Next

        dgvProducts.ReadOnly = True
        dgvCart.ReadOnly = False
        colCartProductName.ReadOnly = True
        colCartAmount.ReadOnly = True
        colCartQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colCartUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colCartAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colCartQty.DefaultCellStyle.Format = "N2"
        colCartUnitPrice.DefaultCellStyle.Format = "N2"
        colCartAmount.DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub LoadSuppliers()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim adapter As New MySqlDataAdapter("SELECT SupplierID, SupplierName FROM suppliers WHERE IsActive = 1 ORDER BY SupplierName", conn)
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

    Private Sub LoadCategories()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim dt As New DataTable()
                dt.Columns.Add("CategoryID", GetType(Integer))
                dt.Columns.Add("CategoryName", GetType(String))
                dt.Rows.Add(0, "All Categories")
                Dim adapter As New MySqlDataAdapter("SELECT CategoryID, CategoryName FROM categories WHERE IsActive = 1 ORDER BY CategoryName", conn)
                adapter.Fill(dt)
                cboFilterCategory.DataSource = dt
                cboFilterCategory.DisplayMember = "CategoryName"
                cboFilterCategory.ValueMember = "CategoryID"
                cboFilterCategory.SelectedValue = 0
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GeneratePONumber()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) + 1 FROM purchase_orders WHERE YEAR(PODate) = @POYear", conn)
                    cmd.Parameters.AddWithValue("@POYear", DateTime.Now.Year)
                    Dim seq As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    lblPONumber.Text = $"PO-{DateTime.Now:yyyy}-{seq:0000}"
                End Using
            End Using
        Catch
            lblPONumber.Text = $"PO-{DateTime.Now:yyyy}-{DateTime.Now:HHmm}"
        End Try
    End Sub

    Private Sub LoadProducts()
        Try
            Using conn As New MySqlConnection(connectionString)
                Dim sql As String = "SELECT p.ProductID, p.Barcode, p.ProductName, c.CategoryName AS Category, p.Stock, p.MinStock, p.CostPrice " &
                                    "FROM products p LEFT JOIN categories c ON p.CategoryID = c.CategoryID " &
                                    "WHERE p.IsActive = 1 AND (@CategoryID = 0 OR p.CategoryID = @CategoryID) " &
                                    "AND (@SearchText = '' OR p.Barcode LIKE @LikeSearch OR p.ProductName LIKE @LikeSearch) ORDER BY p.ProductName"
                Dim adapter As New MySqlDataAdapter(sql, conn)
                adapter.SelectCommand.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(If(cboFilterCategory.SelectedValue Is Nothing, 0, cboFilterCategory.SelectedValue)))
                adapter.SelectCommand.Parameters.AddWithValue("@SearchText", txtProductSearch.Text.Trim())
                adapter.SelectCommand.Parameters.AddWithValue("@LikeSearch", $"%{txtProductSearch.Text.Trim()}%")
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvProducts.DataSource = dt
                FormatProductGrid()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatProductGrid()
        Try
            If dgvProducts.Columns.Count = 0 Then Return
            If dgvProducts.Columns.Contains("ProductID") Then dgvProducts.Columns("ProductID").Visible = False
            If dgvProducts.Columns.Contains("Barcode") Then dgvProducts.Columns("Barcode").Width = 110
            If dgvProducts.Columns.Contains("ProductName") Then dgvProducts.Columns("ProductName").Width = 180
            If dgvProducts.Columns.Contains("Category") Then dgvProducts.Columns("Category").Width = 110
            If dgvProducts.Columns.Contains("Stock") Then dgvProducts.Columns("Stock").Width = 70
            If dgvProducts.Columns.Contains("MinStock") Then dgvProducts.Columns("MinStock").Width = 70
            If dgvProducts.Columns.Contains("CostPrice") Then
                dgvProducts.Columns("CostPrice").DefaultCellStyle.Format = "N2"
                dgvProducts.Columns("CostPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvProducts.Columns("CostPrice").Width = 80
            End If
        Catch
        End Try
    End Sub

    Private Sub AddSelectedProductToCart()
        If dgvProducts.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim productID As Integer = Convert.ToInt32(dgvProducts.CurrentRow.Cells("ProductID").Value)
            Dim productName As String = dgvProducts.CurrentRow.Cells("ProductName").Value.ToString()
            Dim unitPrice As Decimal = Convert.ToDecimal(dgvProducts.CurrentRow.Cells("CostPrice").Value)

            For Each row As DataRow In cartTable.Rows
                If Convert.ToInt32(row("ProductID")) = productID Then
                    row("OrderQty") = Convert.ToDecimal(row("OrderQty")) + 1D
                    row("Amount") = Convert.ToDecimal(row("OrderQty")) * Convert.ToDecimal(row("UnitPrice"))
                    UpdateSummary()
                    Return
                End If
            Next

            Dim newRow As DataRow = cartTable.NewRow()
            newRow("ProductID") = productID
            newRow("ProductName") = productName
            newRow("OrderQty") = 1D
            newRow("UnitPrice") = unitPrice
            newRow("Amount") = unitPrice
            cartTable.Rows.Add(newRow)
            UpdateSummary()
        Catch ex As Exception
            MessageBox.Show($"Error adding product to cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellDoubleClick
        If e.RowIndex >= 0 Then AddSelectedProductToCart()
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        AddSelectedProductToCart()
    End Sub

    Private Sub btnRemoveFromCart_Click(sender As Object, e As EventArgs) Handles btnRemoveFromCart.Click
        If dgvCart.SelectedRows.Count = 0 Then Return
        For Each gridRow As DataGridViewRow In dgvCart.SelectedRows
            If gridRow.Index >= 0 AndAlso gridRow.Index < cartTable.Rows.Count Then
                cartTable.Rows.RemoveAt(gridRow.Index)
            End If
        Next
        UpdateSummary()
    End Sub

    Private Sub dgvCart_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCart.CellEndEdit
        If e.RowIndex < 0 OrElse e.RowIndex >= cartTable.Rows.Count Then Return
        Try
            Dim row As DataRow = cartTable.Rows(e.RowIndex)
            Dim qty As Decimal
            Dim unitPrice As Decimal
            If Not Decimal.TryParse(If(dgvCart.Rows(e.RowIndex).Cells("colCartQty").Value, "1").ToString(), qty) OrElse qty <= 0D Then qty = 1D
            If Not Decimal.TryParse(If(dgvCart.Rows(e.RowIndex).Cells("colCartUnitPrice").Value, "0").ToString(), unitPrice) OrElse unitPrice < 0D Then unitPrice = 0D
            row("OrderQty") = qty
            row("UnitPrice") = unitPrice
            row("Amount") = qty * unitPrice
            UpdateSummary()
        Catch ex As Exception
            MessageBox.Show($"Error updating cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateSummary()
        Dim totalItems As Decimal = 0D
        Dim totalAmount As Decimal = 0D
        For Each row As DataRow In cartTable.Rows
            totalItems += Convert.ToDecimal(row("OrderQty"))
            totalAmount += Convert.ToDecimal(row("Amount"))
        Next
        lblTotalItems.Text = $"Total Items: {totalItems:N2}"
        lblTotalAmount.Text = $"Total Amount: {totalAmount:N2}"
    End Sub

    Private Function ValidatePO() As Boolean
        If cboSupplier.SelectedValue Is Nothing OrElse cboSupplier.SelectedIndex < 0 Then
            MessageBox.Show("Please select a supplier.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSupplier.Focus()
            Return False
        End If
        If cartTable.Rows.Count = 0 Then
            MessageBox.Show("Add at least one product to cart.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnGeneratePO_Click(sender As Object, e As EventArgs) Handles btnGeneratePO.Click
        If Not ValidatePO() Then Return

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using transaction = conn.BeginTransaction()
                    Try
                        Dim poID As Integer
                        Dim totalAmount As Decimal = 0D
                        For Each row As DataRow In cartTable.Rows
                            totalAmount += Convert.ToDecimal(row("Amount"))
                        Next

                        Using cmd As New MySqlCommand("INSERT INTO purchase_orders (PONumber, PODate, SupplierID, TotalAmount, Status, CreatedBy) VALUES (@PONumber, @PODate, @SupplierID, @TotalAmount, 'Pending', @CreatedBy)", conn, transaction)
                            cmd.Parameters.AddWithValue("@PONumber", lblPONumber.Text)
                            cmd.Parameters.AddWithValue("@PODate", dtpPODate.Value)
                            cmd.Parameters.AddWithValue("@SupplierID", Convert.ToInt32(cboSupplier.SelectedValue))
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
                            cmd.Parameters.AddWithValue("@CreatedBy", CurrentUserID)
                            cmd.ExecuteNonQuery()
                            poID = Convert.ToInt32(cmd.LastInsertedId)
                        End Using

                        For Each row As DataRow In cartTable.Rows
                            Using cmd As New MySqlCommand("INSERT INTO purchase_order_items (POID, ProductID, OrderQty, UnitPrice, Amount) VALUES (@POID, @ProductID, @OrderQty, @UnitPrice, @Amount)", conn, transaction)
                                cmd.Parameters.AddWithValue("@POID", poID)
                                cmd.Parameters.AddWithValue("@ProductID", Convert.ToInt32(row("ProductID")))
                                cmd.Parameters.AddWithValue("@OrderQty", Convert.ToDecimal(row("OrderQty")))
                                cmd.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(row("UnitPrice")))
                                cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(row("Amount")))
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        transaction.Commit()
                    Catch
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MessageBox.Show("Purchase order generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BuildPrintLines()
            GeneratePONumber()
            cartTable.Rows.Clear()
            UpdateSummary()
        Catch ex As Exception
            MessageBox.Show($"Error generating purchase order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuildPrintLines()
        lastPrintedLines = New List(Of String) From {
            "FAMILY CHOICE SHOP",
            "PURCHASE ORDER",
            "----------------------------------------",
            $"PO No   : {lblPONumber.Text}",
            $"Date    : {dtpPODate.Value:dd-MMM-yyyy}",
            $"Supplier: {cboSupplier.Text}",
            "----------------------------------------"
        }

        For Each row As DataRow In cartTable.Rows
            lastPrintedLines.Add(row("ProductName").ToString())
            lastPrintedLines.Add($"Qty: {Convert.ToDecimal(row("OrderQty")):N2}  Rate: {Convert.ToDecimal(row("UnitPrice")):N2}  Amt: {Convert.ToDecimal(row("Amount")):N2}")
        Next

        lastPrintedLines.Add("----------------------------------------")
        lastPrintedLines.Add(lblTotalItems.Text)
        lastPrintedLines.Add(lblTotalAmount.Text)
    End Sub

    Private Sub ShowPrintPreview()
        Try
            BuildPrintLines()
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintPurchaseOrderPage
            Using preview As New PrintPreviewDialog()
                preview.Document = printDoc
                preview.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error showing print preview: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPurchaseOrderPage(sender As Object, e As PrintPageEventArgs)
        Dim yPos As Integer = 20
        For Each line As String In lastPrintedLines
            e.Graphics.DrawString(line, New Font("Consolas", 9), Brushes.Black, 20, yPos)
            yPos += 20
        Next
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ShowPrintPreview()
    End Sub

    Private Sub btnSearchProduct_Click(sender As Object, e As EventArgs) Handles btnSearchProduct.Click
        LoadProducts()
    End Sub

    Private Sub txtProductSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadProducts()
        End If
    End Sub

    Private Sub cboFilterCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterCategory.SelectedIndexChanged
        If Me.IsHandleCreated Then LoadProducts()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class
