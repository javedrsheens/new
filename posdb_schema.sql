CREATE DATABASE IF NOT EXISTS posdb CHARACTER SET utf8mb4;
USE posdb;

CREATE TABLE IF NOT EXISTS roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL,
    Description VARCHAR(255) NULL,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_roles_name (RoleName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL,
    Role ENUM('Admin','Manager','Cashier','Staff') NOT NULL DEFAULT 'Staff',
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    LastLogin DATETIME NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_users_username (Username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS categories (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL,
    Description TEXT NULL,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_categories_name (CategoryName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS subcategories (
    SubcategoryID INT AUTO_INCREMENT PRIMARY KEY,
    SubcategoryName VARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    Description TEXT NULL,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_subcategories_category (CategoryID),
    KEY idx_subcategories_name (SubcategoryName),
    CONSTRAINT fk_subcategories_category FOREIGN KEY (CategoryID) REFERENCES categories(CategoryID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS suppliers (
    SupplierID INT AUTO_INCREMENT PRIMARY KEY,
    SupplierName VARCHAR(150) NOT NULL,
    ContactPerson VARCHAR(100) NULL,
    Phone VARCHAR(30) NULL,
    Email VARCHAR(100) NULL,
    Address VARCHAR(255) NULL,
    City VARCHAR(100) NULL,
    Balance DECIMAL(18,2) NOT NULL DEFAULT 0,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_suppliers_name (SupplierName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerName VARCHAR(150) NOT NULL,
    Phone VARCHAR(30) NULL,
    Email VARCHAR(100) NULL,
    Address VARCHAR(255) NULL,
    Balance DECIMAL(18,2) NOT NULL DEFAULT 0,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_customers_name (CustomerName),
    KEY idx_customers_phone (Phone)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS expense_categories (
    ExpenseCategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL,
    Description VARCHAR(255) NULL,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_expense_categories_name (CategoryName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS accounts (
    AccountID INT AUTO_INCREMENT PRIMARY KEY,
    AccountCode VARCHAR(20) NOT NULL,
    AccountName VARCHAR(100) NOT NULL,
    AccountType ENUM('Asset','Liability','Equity','Income','Expense') NOT NULL,
    ParentAccountID INT NULL,
    OpeningBalance DECIMAL(18,2) NOT NULL DEFAULT 0,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_accounts_code (AccountCode),
    KEY idx_accounts_name (AccountName),
    KEY idx_accounts_parent (ParentAccountID),
    CONSTRAINT fk_accounts_parent FOREIGN KEY (ParentAccountID) REFERENCES accounts(AccountID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS payment_methods (
    PaymentMethodID INT AUTO_INCREMENT PRIMARY KEY,
    MethodName VARCHAR(50) NOT NULL,
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    DisplayOrder INT NOT NULL DEFAULT 0,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_payment_methods_name (MethodName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    Barcode VARCHAR(100) NOT NULL,
    ProductName VARCHAR(150) NOT NULL,
    Description TEXT NULL,
    CategoryID INT NOT NULL,
    SubcategoryID INT NULL,
    SupplierID INT NULL,
    PurchasePrice DECIMAL(18,2) NOT NULL DEFAULT 0,
    UnitPrice DECIMAL(18,2) NOT NULL DEFAULT 0,
    CostPrice DECIMAL(18,2) NOT NULL DEFAULT 0,
    Stock DECIMAL(18,2) NOT NULL DEFAULT 0,
    MinStock DECIMAL(18,2) NOT NULL DEFAULT 0,
    MaxStock DECIMAL(18,2) NOT NULL DEFAULT 0,
    Unit VARCHAR(20) NOT NULL DEFAULT 'PCS',
    IsActive TINYINT(1) NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_products_barcode (Barcode),
    KEY idx_products_category (CategoryID),
    KEY idx_products_subcategory (SubcategoryID),
    KEY idx_products_supplier (SupplierID),
    KEY idx_products_name (ProductName),
    CONSTRAINT fk_products_category FOREIGN KEY (CategoryID) REFERENCES categories(CategoryID),
    CONSTRAINT fk_products_subcategory FOREIGN KEY (SubcategoryID) REFERENCES subcategories(SubcategoryID),
    CONSTRAINT fk_products_supplier FOREIGN KEY (SupplierID) REFERENCES suppliers(SupplierID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS sales (
    SaleID INT AUTO_INCREMENT PRIMARY KEY,
    InvoiceNo VARCHAR(50) NOT NULL,
    SaleDate DATETIME NOT NULL,
    CustomerID INT NULL,
    SubTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    DiscountAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    NetAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    PaidAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    ChangeAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    PaymentMethod VARCHAR(50) NULL,
    Status ENUM('Completed','Hold','Cancelled') NOT NULL DEFAULT 'Completed',
    UserID INT NULL,
    CashierID INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_sales_invoice (InvoiceNo),
    KEY idx_sales_customer (CustomerID),
    KEY idx_sales_user (UserID),
    KEY idx_sales_cashier (CashierID),
    KEY idx_sales_date (SaleDate),
    CONSTRAINT fk_sales_customer FOREIGN KEY (CustomerID) REFERENCES customers(CustomerID),
    CONSTRAINT fk_sales_user FOREIGN KEY (UserID) REFERENCES users(UserID),
    CONSTRAINT fk_sales_cashier FOREIGN KEY (CashierID) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS sales_items (
    SaleItemID INT AUTO_INCREMENT PRIMARY KEY,
    SaleID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity DECIMAL(18,2) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Discount DECIMAL(18,2) NOT NULL DEFAULT 0,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_sales_items_sale (SaleID),
    KEY idx_sales_items_product (ProductID),
    CONSTRAINT fk_sales_items_sale FOREIGN KEY (SaleID) REFERENCES sales(SaleID) ON DELETE CASCADE,
    CONSTRAINT fk_sales_items_product FOREIGN KEY (ProductID) REFERENCES products(ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS sales_returns (
    ReturnID INT AUTO_INCREMENT PRIMARY KEY,
    ReturnNo VARCHAR(50) NOT NULL,
    ReturnDate DATETIME NOT NULL,
    CustomerID INT NULL,
    InvoiceRef VARCHAR(20) NULL,
    SubTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    NetAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    Reason VARCHAR(100) NULL,
    Remarks TEXT NULL,
    UserID INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_sales_returns_no (ReturnNo),
    KEY idx_sales_returns_customer (CustomerID),
    KEY idx_sales_returns_user (UserID),
    CONSTRAINT fk_sales_returns_customer FOREIGN KEY (CustomerID) REFERENCES customers(CustomerID),
    CONSTRAINT fk_sales_returns_user FOREIGN KEY (UserID) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS sales_return_items (
    ReturnItemID INT AUTO_INCREMENT PRIMARY KEY,
    ReturnID INT NOT NULL,
    ProductID INT NOT NULL,
    Qty DECIMAL(18,2) NOT NULL,
    Rate DECIMAL(18,2) NOT NULL,
    Discount DECIMAL(18,2) NOT NULL DEFAULT 0,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_sales_return_items_return (ReturnID),
    KEY idx_sales_return_items_product (ProductID),
    CONSTRAINT fk_sales_return_items_return FOREIGN KEY (ReturnID) REFERENCES sales_returns(ReturnID) ON DELETE CASCADE,
    CONSTRAINT fk_sales_return_items_product FOREIGN KEY (ProductID) REFERENCES products(ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS purchases (
    PurchaseID INT AUTO_INCREMENT PRIMARY KEY,
    InvoiceNo VARCHAR(50) NULL,
    PurchaseNo VARCHAR(50) NULL,
    PurchaseDate DATETIME NOT NULL,
    SupplierID INT NULL,
    SubTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    NetAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    TaxAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    DiscountAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    PaidAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    DueAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    PaymentMethod VARCHAR(50) NULL,
    Status ENUM('Completed','Partial','Pending') NOT NULL DEFAULT 'Completed',
    UserID INT NULL,
    CreatedBy INT NULL,
    Notes TEXT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_purchases_invoice (InvoiceNo),
    UNIQUE KEY uq_purchases_purchase_no (PurchaseNo),
    KEY idx_purchases_supplier (SupplierID),
    KEY idx_purchases_user (UserID),
    KEY idx_purchases_created_by (CreatedBy),
    CONSTRAINT fk_purchases_supplier FOREIGN KEY (SupplierID) REFERENCES suppliers(SupplierID),
    CONSTRAINT fk_purchases_user FOREIGN KEY (UserID) REFERENCES users(UserID),
    CONSTRAINT fk_purchases_created_by FOREIGN KEY (CreatedBy) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS purchase_items (
    PurchaseItemID INT AUTO_INCREMENT PRIMARY KEY,
    PurchaseID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity DECIMAL(18,2) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_purchase_items_purchase (PurchaseID),
    KEY idx_purchase_items_product (ProductID),
    CONSTRAINT fk_purchase_items_purchase FOREIGN KEY (PurchaseID) REFERENCES purchases(PurchaseID) ON DELETE CASCADE,
    CONSTRAINT fk_purchase_items_product FOREIGN KEY (ProductID) REFERENCES products(ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS purchase_returns (
    ReturnID INT AUTO_INCREMENT PRIMARY KEY,
    ReturnNo VARCHAR(50) NOT NULL,
    ReturnDate DATETIME NOT NULL,
    SupplierID INT NULL,
    InvoiceRef VARCHAR(20) NULL,
    SubTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    NetAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    Reason VARCHAR(100) NULL,
    Remarks TEXT NULL,
    UserID INT NULL,
    CreatedBy INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_purchase_returns_no (ReturnNo),
    KEY idx_purchase_returns_supplier (SupplierID),
    KEY idx_purchase_returns_user (UserID),
    KEY idx_purchase_returns_created_by (CreatedBy),
    CONSTRAINT fk_purchase_returns_supplier FOREIGN KEY (SupplierID) REFERENCES suppliers(SupplierID),
    CONSTRAINT fk_purchase_returns_user FOREIGN KEY (UserID) REFERENCES users(UserID),
    CONSTRAINT fk_purchase_returns_created_by FOREIGN KEY (CreatedBy) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS purchase_return_items (
    ReturnItemID INT AUTO_INCREMENT PRIMARY KEY,
    ReturnID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity DECIMAL(18,2) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    KEY idx_purchase_return_items_return (ReturnID),
    KEY idx_purchase_return_items_product (ProductID),
    CONSTRAINT fk_purchase_return_items_return FOREIGN KEY (ReturnID) REFERENCES purchase_returns(ReturnID) ON DELETE CASCADE,
    CONSTRAINT fk_purchase_return_items_product FOREIGN KEY (ProductID) REFERENCES products(ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS purchase_orders (
    POID INT AUTO_INCREMENT PRIMARY KEY,
    PONumber VARCHAR(50) NOT NULL,
    PODate DATETIME NOT NULL,
    SupplierID INT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    Status ENUM('Pending','Ordered','Received','Cancelled') NOT NULL DEFAULT 'Pending',
    CreatedBy INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_purchase_orders_number (PONumber),
    KEY idx_purchase_orders_supplier (SupplierID),
    KEY idx_purchase_orders_created_by (CreatedBy),
    CONSTRAINT fk_purchase_orders_supplier FOREIGN KEY (SupplierID) REFERENCES suppliers(SupplierID),
    CONSTRAINT fk_purchase_orders_created_by FOREIGN KEY (CreatedBy) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS purchase_order_items (
    POItemID INT AUTO_INCREMENT PRIMARY KEY,
    POID INT NOT NULL,
    ProductID INT NOT NULL,
    OrderQty DECIMAL(18,2) NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_purchase_order_items_poid (POID),
    KEY idx_purchase_order_items_product (ProductID),
    CONSTRAINT fk_purchase_order_items_po FOREIGN KEY (POID) REFERENCES purchase_orders(POID) ON DELETE CASCADE,
    CONSTRAINT fk_purchase_order_items_product FOREIGN KEY (ProductID) REFERENCES products(ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS journal_entries (
    JournalID INT AUTO_INCREMENT PRIMARY KEY,
    EntryDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    ReferenceType VARCHAR(50) NULL,
    ReferenceID INT NULL,
    UserID INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_journal_entries_date (EntryDate),
    KEY idx_journal_entries_reference (ReferenceType, ReferenceID),
    KEY idx_journal_entries_user (UserID),
    CONSTRAINT fk_journal_entries_user FOREIGN KEY (UserID) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS journal_details (
    DetailID INT AUTO_INCREMENT PRIMARY KEY,
    JournalID INT NOT NULL,
    AccountID INT NOT NULL,
    DebitAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    CreditAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    Description VARCHAR(255) NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_journal_details_journal (JournalID),
    KEY idx_journal_details_account (AccountID),
    CONSTRAINT fk_journal_details_journal FOREIGN KEY (JournalID) REFERENCES journal_entries(JournalID) ON DELETE CASCADE,
    CONSTRAINT fk_journal_details_account FOREIGN KEY (AccountID) REFERENCES accounts(AccountID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS daybook (
    DayBookID INT AUTO_INCREMENT PRIMARY KEY,
    TransactionDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TransactionType VARCHAR(50) NOT NULL,
    ReferenceType VARCHAR(50) NULL,
    ReferenceID INT NULL,
    Description VARCHAR(255) NULL,
    PartyName VARCHAR(150) NULL,
    DebitAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    CreditAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    ReferenceNo VARCHAR(50) NULL,
    PaymentMethod VARCHAR(50) NULL,
    UserID INT NULL,
    RecordedBy INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_daybook_date (TransactionDate),
    KEY idx_daybook_type (TransactionType),
    KEY idx_daybook_reference (ReferenceType, ReferenceID),
    KEY idx_daybook_user (UserID),
    KEY idx_daybook_recorded_by (RecordedBy),
    CONSTRAINT fk_daybook_user FOREIGN KEY (UserID) REFERENCES users(UserID),
    CONSTRAINT fk_daybook_recorded_by FOREIGN KEY (RecordedBy) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS expenses (
    ExpenseID INT AUTO_INCREMENT PRIMARY KEY,
    ExpenseDate DATETIME NOT NULL,
    ExpenseCategoryID INT NOT NULL,
    Description VARCHAR(255) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    PaymentMethod VARCHAR(50) NULL,
    RecordedBy INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_expenses_category (ExpenseCategoryID),
    KEY idx_expenses_recorded_by (RecordedBy),
    KEY idx_expenses_date (ExpenseDate),
    CONSTRAINT fk_expenses_category FOREIGN KEY (ExpenseCategoryID) REFERENCES expense_categories(ExpenseCategoryID),
    CONSTRAINT fk_expenses_recorded_by FOREIGN KEY (RecordedBy) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS stock_movements (
    MovementID INT AUTO_INCREMENT PRIMARY KEY,
    ProductID INT NOT NULL,
    MovementDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    MovementType VARCHAR(50) NOT NULL,
    Quantity DECIMAL(18,2) NOT NULL,
    UnitCost DECIMAL(18,2) NOT NULL DEFAULT 0,
    ReferenceType VARCHAR(50) NULL,
    ReferenceID INT NULL,
    Notes VARCHAR(255) NULL,
    UserID INT NULL,
    CreatedBy INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_stock_movements_product (ProductID),
    KEY idx_stock_movements_type (MovementType),
    KEY idx_stock_movements_reference (ReferenceType, ReferenceID),
    CONSTRAINT fk_stock_movements_product FOREIGN KEY (ProductID) REFERENCES products(ProductID),
    CONSTRAINT fk_stock_movements_user FOREIGN KEY (UserID) REFERENCES users(UserID),
    CONSTRAINT fk_stock_movements_created_by FOREIGN KEY (CreatedBy) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS stock_history (
    HistoryID INT AUTO_INCREMENT PRIMARY KEY,
    ProductID INT NOT NULL,
    TransactionType VARCHAR(50) NOT NULL,
    QuantityChanged DECIMAL(18,2) NOT NULL,
    ReferenceID INT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_stock_history_product (ProductID),
    KEY idx_stock_history_reference (ReferenceID),
    CONSTRAINT fk_stock_history_product FOREIGN KEY (ProductID) REFERENCES products(ProductID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS settings (
    SettingID INT AUTO_INCREMENT PRIMARY KEY,
    SettingKey VARCHAR(100) NOT NULL,
    SettingValue TEXT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    UNIQUE KEY uq_settings_key (SettingKey)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS activity_log (
    LogID INT AUTO_INCREMENT PRIMARY KEY,
    UserID INT NULL,
    Action VARCHAR(50) NOT NULL,
    TableName VARCHAR(50) NULL,
    RecordID VARCHAR(50) NULL,
    Description VARCHAR(255) NULL,
    LogDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KEY idx_activity_log_user (UserID),
    KEY idx_activity_log_date (LogDate),
    CONSTRAINT fk_activity_log_user FOREIGN KEY (UserID) REFERENCES users(UserID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO roles (RoleName, Description, IsActive)
VALUES
    ('Admin', 'System Administrator', 1),
    ('Manager', 'Store Manager', 1),
    ('Cashier', 'POS Cashier', 1),
    ('Staff', 'General Staff', 1)
ON DUPLICATE KEY UPDATE Description = VALUES(Description), IsActive = VALUES(IsActive);

INSERT INTO settings (SettingKey, SettingValue)
VALUES
    ('CompanyName', 'Family Choice Shop'),
    ('CompanyAddress', 'Main Market, Your City'),
    ('CompanyPhone', '0000-0000000'),
    ('CompanyEmail', 'info@familychoiceshop.local'),
    ('InvoicePrefix', 'INV'),
    ('TaxRate', '0'),
    ('Currency', 'PKR')
ON DUPLICATE KEY UPDATE SettingValue = VALUES(SettingValue), UpdatedDate = CURRENT_TIMESTAMP;

INSERT INTO accounts (AccountCode, AccountName, AccountType, OpeningBalance, IsActive)
VALUES
    ('1000', 'Cash In Hand', 'Asset', 0, 1),
    ('1010', 'Bank', 'Asset', 0, 1),
    ('1100', 'Accounts Receivable', 'Asset', 0, 1),
    ('1200', 'Inventory', 'Asset', 0, 1),
    ('4000', 'Sales', 'Income', 0, 1),
    ('5000', 'Purchases', 'Expense', 0, 1),
    ('2000', 'Accounts Payable', 'Liability', 0, 1)
ON DUPLICATE KEY UPDATE AccountName = VALUES(AccountName), AccountType = VALUES(AccountType), IsActive = VALUES(IsActive);

INSERT INTO expense_categories (CategoryName, Description, IsActive)
VALUES
    ('Electricity', 'Electricity expense', 1),
    ('Rent', 'Rent expense', 1),
    ('Salaries', 'Salary expense', 1),
    ('Misc Expenses', 'Miscellaneous expense', 1)
ON DUPLICATE KEY UPDATE Description = VALUES(Description), IsActive = VALUES(IsActive);

INSERT INTO payment_methods (MethodName, IsActive, DisplayOrder)
VALUES
    ('Cash', 1, 1),
    ('Credit', 1, 2),
    ('Bank', 1, 3)
ON DUPLICATE KEY UPDATE IsActive = VALUES(IsActive), DisplayOrder = VALUES(DisplayOrder);

INSERT INTO users (Username, Password, FullName, Email, Role, IsActive)
VALUES ('admin', SHA2('admin123', 256), 'Administrator', 'admin@familychoiceshop.local', 'Admin', 1)
ON DUPLICATE KEY UPDATE FullName = VALUES(FullName), Email = VALUES(Email), Role = VALUES(Role), IsActive = VALUES(IsActive);
