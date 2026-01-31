Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class frmInvoicePrint
    ' ================================================
    ' VARIABLES
    ' ================================================
    Private connectionString As String = "Server=localhost;Database=posdb;Uid=root;Pwd=Ayyaan@8941;"
    Private invoiceSaleID As Integer
    Private invoiceNumber As String
    Private invoiceHeader As DataRow
    Private invoiceItems As DataTable
    Private currentFormat As String = "Thermal 80mm"
    Private invoiceText As String = ""

    ' ================================================
    ' CONSTRUCTOR
    ' ================================================
    Public Sub New(saleID As Integer, invoiceNo As String)
        InitializeComponent()

        invoiceSaleID = saleID
        invoiceNumber = invoiceNo
    End Sub

    ' ================================================
    ' FORM LOAD
    ' ================================================
    Private Sub frmInvoicePrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitializeControls()
            LoadInvoiceData()
            GenerateInvoicePreview()
        Catch ex As Exception
            MessageBox.Show($"Error loading invoice:{vbCrLf}{ex.Message}",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ' ================================================
    ' INITIALIZE CONTROLS
    ' ================================================
    Private Sub InitializeControls()
        Try
            If cboPrintFormat IsNot Nothing Then
                cboPrintFormat.Items.Clear()
                cboPrintFormat.Items.AddRange(New String() {
                    "Thermal 80mm",
                    "Thermal 58mm",
                    "A4 Format",
                    "Email Format"
                })
                cboPrintFormat.SelectedIndex = 0
            End If

            If txtInvoicePreview IsNot Nothing Then
                txtInvoicePreview.Font = New Font("Courier New", 9)
                txtInvoicePreview.ReadOnly = True
            End If
        Catch ex As Exception
            Throw New Exception($"Control initialization failed:  {ex.Message}")
        End Try
    End Sub

    ' ================================================
    ' LOAD DATA
    ' ================================================
    Private Sub LoadInvoiceData()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Get header
                Dim headerQuery As String = "SELECT 
                    s.InvoiceNo, s.SaleDate, s.TotalAmount, s.TaxAmount, 
                    s. DiscountAmount, s.NetAmount, s.PaidAmount, s.PaymentMethod,
                    c.CustomerName, 
                    COALESCE(c.Phone, 'N/A') as Phone, 
                    COALESCE(c.Email, 'N/A') as Email, 
                    COALESCE(c.Address, 'N/A') as Address,
                    COALESCE(u. FullName, u.Username, 'Cashier') as CashierName
                FROM sales s
                INNER JOIN customers c ON s.CustomerID = c.CustomerID
                LEFT JOIN users u ON s.CashierID = u.UserID
                WHERE s.SaleID = @SaleID"

                Dim cmdHeader As New MySqlCommand(headerQuery, conn)
                cmdHeader.Parameters.AddWithValue("@SaleID", invoiceSaleID)

                Dim dtHeader As New DataTable()
                Dim adapterHeader As New MySqlDataAdapter(cmdHeader)
                adapterHeader.Fill(dtHeader)

                If dtHeader.Rows.Count = 0 Then
                    Throw New Exception("Invoice not found!")
                End If

                invoiceHeader = dtHeader.Rows(0)

                ' Get items
                Dim itemsQuery As String = "SELECT 
                    ProductID, ProductName, Quantity, UnitPrice, 
                    Discount, TaxAmount, TotalPrice 
                FROM sale_details 
                WHERE SaleID = @SaleID
                ORDER BY ProductName"

                Dim cmdItems As New MySqlCommand(itemsQuery, conn)
                cmdItems.Parameters.AddWithValue("@SaleID", invoiceSaleID)

                invoiceItems = New DataTable()
                Dim adapterItems As New MySqlDataAdapter(cmdItems)
                adapterItems.Fill(invoiceItems)

                If invoiceItems.Rows.Count = 0 Then
                    Throw New Exception("No items found!")
                End If
            End Using
        Catch ex As Exception
            Throw New Exception($"Data load failed: {ex.Message}")
        End Try
    End Sub

    ' ================================================
    ' PRINT DIRECTLY - FOR AUTO PRINT
    ' ================================================
    Public Sub PrintDirectly()
        Try
            ' Load data if not already loaded
            If invoiceHeader Is Nothing Then
                LoadInvoiceData()
            End If

            ' Generate thermal 80mm format (default for auto print)
            invoiceText = GenerateThermal80mm()

            ' Print immediately
            Dim printDoc As New PrintDocument()

            ' Set paper size for thermal printer
            Dim paperSize As New PaperSize("Thermal80mm", 315, 1000) ' 80mm width
            printDoc.DefaultPageSettings.PaperSize = paperSize

            ' Set narrow margins
            printDoc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5)

            AddHandler printDoc.PrintPage, AddressOf PrintPage

            ' Print directly to default printer (no preview)
            printDoc.Print()

        Catch ex As Exception
            ' Silent fail for auto print
        End Try
    End Sub

    ' ================================================
    ' GENERATE PREVIEW
    ' ================================================
    Private Sub GenerateInvoicePreview()
        Try
            If invoiceHeader Is Nothing Then Return

            If cboPrintFormat.SelectedIndex < 0 Then
                cboPrintFormat.SelectedIndex = 0
            End If

            currentFormat = cboPrintFormat.Text

            Select Case currentFormat
                Case "Thermal 80mm"
                    invoiceText = GenerateThermal80mm()
                Case "Thermal 58mm"
                    invoiceText = GenerateThermal58mm()
                Case "A4 Format"
                    invoiceText = GenerateA4Format()
                Case "Email Format"
                    invoiceText = GenerateEmailFormat()
                Case Else
                    invoiceText = GenerateThermal80mm()
            End Select

            If txtInvoicePreview IsNot Nothing Then
                txtInvoicePreview.Text = invoiceText
            End If

        Catch ex As Exception
            If txtInvoicePreview IsNot Nothing Then
                txtInvoicePreview.Text = $"Preview Error:{vbCrLf}{ex.Message}"
            End If
        End Try
    End Sub

    ' ================================================
    ' THERMAL 80MM FORMAT
    ' ================================================
    Private Function GenerateThermal80mm() As String
        Dim inv As New Text.StringBuilder()

        Try
            If invoiceHeader Is Nothing OrElse invoiceItems Is Nothing Then
                Return "ERROR: Data not loaded!"
            End If

            ' Get data safely
            Dim invoiceNo As String = If(invoiceHeader("InvoiceNo") IsNot Nothing, invoiceHeader("InvoiceNo").ToString(), "N/A")
            Dim saleDate As DateTime = If(Not IsDBNull(invoiceHeader("SaleDate")), Convert.ToDateTime(invoiceHeader("SaleDate")), DateTime.Now)
            Dim cashierName As String = If(invoiceHeader("CashierName") IsNot Nothing, invoiceHeader("CashierName").ToString(), "Cashier")
            Dim customerName As String = If(invoiceHeader("CustomerName") IsNot Nothing, invoiceHeader("CustomerName").ToString(), "Customer")
            Dim phone As String = If(invoiceHeader("Phone") IsNot Nothing, invoiceHeader("Phone").ToString(), "N/A")
            Dim totalAmount As Decimal = If(Not IsDBNull(invoiceHeader("TotalAmount")), Convert.ToDecimal(invoiceHeader("TotalAmount")), 0)
            Dim discount As Decimal = If(Not IsDBNull(invoiceHeader("DiscountAmount")), Convert.ToDecimal(invoiceHeader("DiscountAmount")), 0)
            Dim tax As Decimal = If(Not IsDBNull(invoiceHeader("TaxAmount")), Convert.ToDecimal(invoiceHeader("TaxAmount")), 0)
            Dim netAmount As Decimal = If(Not IsDBNull(invoiceHeader("NetAmount")), Convert.ToDecimal(invoiceHeader("NetAmount")), 0)
            Dim paymentMethod As String = If(invoiceHeader("PaymentMethod") IsNot Nothing, invoiceHeader("PaymentMethod").ToString(), "Cash")

            ' Header - 40 chars wide for 80mm
            inv.AppendLine("========================================")
            inv.AppendLine("       YOUR STORE NAME")
            inv.AppendLine("     Point of Sale System")
            inv.AppendLine("========================================")
            inv.AppendLine("")
            inv.AppendLine($"Invoice:   {invoiceNo}")
            inv.AppendLine($"Date:  {saleDate:dd-MMM-yy HH:mm}")
            inv.AppendLine($"Cashier: {cashierName}")
            inv.AppendLine("----------------------------------------")
            inv.AppendLine($"Customer: {customerName}")
            If phone <> "N/A" AndAlso Not String.IsNullOrEmpty(phone) Then
                inv.AppendLine($"Phone: {phone}")
            End If
            inv.AppendLine("========================================")
            inv.AppendLine("ITEMS")
            inv.AppendLine("----------------------------------------")

            ' Items
            Dim totalQty As Integer = 0

            For Each row As DataRow In invoiceItems.Rows
                Dim product As String = If(row("ProductName") IsNot Nothing, row("ProductName").ToString(), "Product")
                Dim qty As Integer = If(Not IsDBNull(row("Quantity")), Convert.ToInt32(row("Quantity")), 0)
                Dim price As Decimal = If(Not IsDBNull(row("UnitPrice")), Convert.ToDecimal(row("UnitPrice")), 0)
                Dim total As Decimal = If(Not IsDBNull(row("TotalPrice")), Convert.ToDecimal(row("TotalPrice")), 0)

                ' Product name (max 38 chars)
                If product.Length > 38 Then
                    product = product.Substring(0, 35) & "..."
                End If
                inv.AppendLine(product)

                ' Quantity and price
                inv.AppendLine(String.Format("{0} x {1:N2} = {2:N2}", qty, price, total))
                inv.AppendLine("")

                totalQty += qty
            Next

            ' Totals
            inv.AppendLine("========================================")
            inv.AppendLine(String.Format("Subtotal:{0,28:N2}", totalAmount))

            If discount > 0 Then
                inv.AppendLine(String.Format("Discount:{0,28:N2}", discount))
            End If

            If tax > 0 Then
                inv.AppendLine(String.Format("Tax (18%):{0,27:N2}", tax))
            End If

            inv.AppendLine("========================================")
            inv.AppendLine(String.Format("NET TOTAL:{0,27:N2}", netAmount))
            inv.AppendLine("========================================")
            inv.AppendLine("")
            inv.AppendLine($"Payment:   {paymentMethod}")
            inv.AppendLine($"Total Items: {totalQty}")
            inv.AppendLine("")
            inv.AppendLine("   Thank you for your business!")
            inv.AppendLine("      Please visit again")
            inv.AppendLine("")
            inv.AppendLine("========================================")
            inv.AppendLine($"Printed:  {DateTime.Now:dd-MMM-yy HH:mm}")
            inv.AppendLine("========================================")
            inv.AppendLine("")
            inv.AppendLine("")

        Catch ex As Exception
            inv.AppendLine($"ERROR: {ex.Message}")
        End Try

        Return inv.ToString()
    End Function

    ' ================================================
    ' THERMAL 58MM FORMAT
    ' ================================================
    Private Function GenerateThermal58mm() As String
        Dim inv As New Text.StringBuilder()

        Try
            If invoiceHeader Is Nothing OrElse invoiceItems Is Nothing Then
                Return "ERROR: Data not loaded!"
            End If

            inv.AppendLine("==============================")
            inv.AppendLine("     YOUR STORE NAME")
            inv.AppendLine("==============================")
            inv.AppendLine("")
            inv.AppendLine($"Inv:  {invoiceHeader("InvoiceNo")}")
            inv.AppendLine($"Date: {Convert.ToDateTime(invoiceHeader("SaleDate")):dd-MMM-yy HH:mm}")
            inv.AppendLine("------------------------------")
            inv.AppendLine($"Customer:")
            inv.AppendLine($"{invoiceHeader("CustomerName")}")
            inv.AppendLine("------------------------------")
            inv.AppendLine("ITEMS")
            inv.AppendLine("------------------------------")

            Dim totalQty As Integer = 0

            For Each row As DataRow In invoiceItems.Rows
                Dim product As String = row("ProductName").ToString()
                If product.Length > 28 Then product = product.Substring(0, 25) & "..."

                Dim qty As Integer = Convert.ToInt32(row("Quantity"))
                Dim price As Decimal = Convert.ToDecimal(row("UnitPrice"))
                Dim total As Decimal = Convert.ToDecimal(row("TotalPrice"))

                inv.AppendLine(product)
                inv.AppendLine(String.Format("{0} x {1:N2} = {2:N2}", qty, price, total))
                inv.AppendLine("")
                totalQty += qty
            Next

            inv.AppendLine("==============================")
            inv.AppendLine(String.Format("TOTAL:  {0,16:N2}", Convert.ToDecimal(invoiceHeader("NetAmount"))))
            inv.AppendLine("==============================")
            inv.AppendLine("")
            inv.AppendLine($"Payment: {invoiceHeader("PaymentMethod")}")
            inv.AppendLine($"Items:  {totalQty}")
            inv.AppendLine("")
            inv.AppendLine("   Thank you!")
            inv.AppendLine("==============================")

        Catch ex As Exception
            inv.AppendLine($"ERROR: {ex.Message}")
        End Try

        Return inv.ToString()
    End Function

    ' ================================================
    ' A4 FORMAT
    ' ================================================
    Private Function GenerateA4Format() As String
        Dim inv As New Text.StringBuilder()

        Try
            If invoiceHeader Is Nothing OrElse invoiceItems Is Nothing Then
                Return "ERROR: Data not loaded!"
            End If

            inv.AppendLine("================================================================================")
            inv.AppendLine("                              YOUR STORE NAME")
            inv.AppendLine("                          Point of Sale System")
            inv.AppendLine("                    Address: Your Store Address")
            inv.AppendLine("                    Phone: +91-XXXXXXXXXX")
            inv.AppendLine("================================================================================")
            inv.AppendLine("")
            inv.AppendLine("                              TAX INVOICE")
            inv.AppendLine("")
            inv.AppendLine("================================================================================")
            inv.AppendLine("")
            inv.AppendLine(String.Format("Invoice No: {0,-35}    Date: {1}",
                invoiceHeader("InvoiceNo"),
                Convert.ToDateTime(invoiceHeader("SaleDate")).ToString("dd-MMM-yyyy hh:mm tt")))
            inv.AppendLine("")
            inv.AppendLine("--------------------------------------------------------------------------------")
            inv.AppendLine("BILL TO:")
            inv.AppendLine($"Customer: {invoiceHeader("CustomerName")}")
            inv.AppendLine("--------------------------------------------------------------------------------")
            inv.AppendLine("")
            inv.AppendLine("================================================================================")
            inv.AppendLine(String.Format("{0,-5} {1,-40} {2,8} {3,10} {4,12}", "No.", "Product", "Qty", "Rate", "Amount"))
            inv.AppendLine("================================================================================")

            Dim sr As Integer = 1
            For Each row As DataRow In invoiceItems.Rows
                Dim product As String = row("ProductName").ToString()
                If product.Length > 38 Then product = product.Substring(0, 35) & "..."

                inv.AppendLine(String.Format("{0,-5} {1,-40} {2,8} {3,10:N2} {4,12:N2}",
                    sr,
                    product,
                    Convert.ToInt32(row("Quantity")),
                    Convert.ToDecimal(row("UnitPrice")),
                    Convert.ToDecimal(row("TotalPrice"))))
                sr += 1
            Next

            inv.AppendLine("================================================================================")
            inv.AppendLine("")
            inv.AppendLine(String.Format("{0,65} {1,12: N2}", "Subtotal:", Convert.ToDecimal(invoiceHeader("TotalAmount"))))
            inv.AppendLine(String.Format("{0,65} {1,12:N2}", "Tax:", Convert.ToDecimal(invoiceHeader("TaxAmount"))))
            inv.AppendLine("                                                                ----------------")
            inv.AppendLine(String.Format("{0,65} {1,12:N2}", "NET AMOUNT:", Convert.ToDecimal(invoiceHeader("NetAmount"))))
            inv.AppendLine("================================================================================")
            inv.AppendLine("")
            inv.AppendLine($"Payment: {invoiceHeader("PaymentMethod")}")
            inv.AppendLine("")
            inv.AppendLine("                       Thank you for your business!")
            inv.AppendLine("================================================================================")

        Catch ex As Exception
            inv.AppendLine($"ERROR: {ex.Message}")
        End Try

        Return inv.ToString()
    End Function

    ' ================================================
    ' EMAIL FORMAT
    ' ================================================
    Private Function GenerateEmailFormat() As String
        Dim inv As New Text.StringBuilder()

        Try
            If invoiceHeader Is Nothing OrElse invoiceItems Is Nothing Then
                Return "ERROR: Data not loaded!"
            End If

            inv.AppendLine("Dear Customer,")
            inv.AppendLine("")
            inv.AppendLine("Thank you for your purchase!")
            inv.AppendLine("")
            inv.AppendLine("===============================================")
            inv.AppendLine($"Invoice:  {invoiceHeader("InvoiceNo")}")
            inv.AppendLine($"Date: {Convert.ToDateTime(invoiceHeader("SaleDate")):dd-MMM-yyyy hh:mm tt}")
            inv.AppendLine($"Customer: {invoiceHeader("CustomerName")}")
            inv.AppendLine("===============================================")
            inv.AppendLine("")
            inv.AppendLine("ITEMS:")
            inv.AppendLine("-----------------------------------------------")

            For Each row As DataRow In invoiceItems.Rows
                inv.AppendLine($"• {row("ProductName")}")
                inv.AppendLine($"  {row("Quantity")} x ₹{Convert.ToDecimal(row("UnitPrice")):N2} = ₹{Convert.ToDecimal(row("TotalPrice")):N2}")
                inv.AppendLine("")
            Next

            inv.AppendLine("-----------------------------------------------")
            inv.AppendLine($"Subtotal:    ₹{Convert.ToDecimal(invoiceHeader("TotalAmount")):N2}")
            inv.AppendLine($"Tax:         ₹{Convert.ToDecimal(invoiceHeader("TaxAmount")):N2}")
            inv.AppendLine("===============================================")
            inv.AppendLine($"TOTAL:       ₹{Convert.ToDecimal(invoiceHeader("NetAmount")):N2}")
            inv.AppendLine("===============================================")
            inv.AppendLine("")
            inv.AppendLine($"Payment: {invoiceHeader("PaymentMethod")}")
            inv.AppendLine("")
            inv.AppendLine("Best Regards,")
            inv.AppendLine("Your Store Name")

        Catch ex As Exception
            inv.AppendLine($"ERROR: {ex.Message}")
        End Try

        Return inv.ToString()
    End Function

    ' ================================================
    ' PRINT PAGE
    ' ================================================
    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        Try
            ' Font settings for thermal printer
            Dim font As New Font("Courier New", 8, FontStyle.Regular)
            Dim brush As New SolidBrush(Color.Black)
            Dim lineHeight As Single = font.GetHeight(e.Graphics)

            ' Starting position - left aligned
            Dim yPos As Single = e.MarginBounds.Top
            Dim leftMargin As Single = e.MarginBounds.Left

            ' Split text into lines
            Dim lines() As String = invoiceText.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)

            ' Print each line
            For Each line As String In lines
                ' Check if we need a new page
                If yPos + lineHeight > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    Exit For
                End If

                ' Draw the line
                e.Graphics.DrawString(line, font, brush, leftMargin, yPos)
                yPos += lineHeight
            Next

            ' Cleanup
            font.Dispose()
            brush.Dispose()

        Catch ex As Exception
            ' Silent fail
        End Try
    End Sub

    ' ================================================
    ' EVENT HANDLERS
    ' ================================================
    Private Sub cboPrintFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPrintFormat.SelectedIndexChanged
        GenerateInvoicePreview()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintInvoiceDocument()
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            If String.IsNullOrEmpty(invoiceText) Then
                MessageBox.Show("No invoice to copy!", "Info",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Clipboard.SetText(invoiceText)
            MessageBox.Show("Invoice copied to clipboard!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Copy error: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            cboPrintFormat.SelectedIndex = 3
            Clipboard.SetText(invoiceText)
            MessageBox.Show("Email format copied to clipboard!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Email error: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ================================================
    ' PRINT INVOICE DOCUMENT (WITH PREVIEW)
    ' ================================================
    Private Sub PrintInvoiceDocument()
        Try
            Dim printDoc As New PrintDocument()

            ' Set paper size based on format
            Select Case currentFormat
                Case "Thermal 80mm"
                    Dim paperSize As New PaperSize("Thermal80mm", 315, 1000)
                    printDoc.DefaultPageSettings.PaperSize = paperSize

                Case "Thermal 58mm"
                    Dim paperSize As New PaperSize("Thermal58mm", 228, 1000)
                    printDoc.DefaultPageSettings.PaperSize = paperSize

                Case Else
                    ' Use default A4
            End Select

            ' Set narrow margins
            printDoc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5)

            AddHandler printDoc.PrintPage, AddressOf PrintPage

            ' Show print preview
            Dim printPreview As New PrintPreviewDialog()
            printPreview.Document = printDoc
            printPreview.WindowState = FormWindowState.Maximized
            printPreview.ShowDialog()

        Catch ex As Exception
            MessageBox.Show($"Print error: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class