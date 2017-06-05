using SalesManagement.BUS;
using SalesManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement
{
    public partial class MainForm : Form
    {
        private const string ACTION_VIEW = "action view";
        private const string ACTION_ADD = "action add";
        private const string ACTION_EDIT = "action edit";
        private const string ACTION_SAVE = "action save";
        private const string ACTION_CANCEL = "action cancel";


        private const string ADD = "Thêm";
        private const string EDIT = "Sửa";
        private const string DELETE = "Xóa";
        private const string SAVE = "Lưu";
        private const string CANCEL = "Hủy";

        private const int TAB_SUPPLIERS = 1;
        private const int TAB_EMPLOYEES = 2;
        private const int TAB_CUSTOMERS = 3;
        private const int TAB_CATEGORIES = 4;
        private const int TAB_PRODUCTS = 5;
        private const int TAB_ORDERS = 6;
        private const int TAB_ORDER_DETAILS = 7;

        private string suppliersTabAction = ACTION_VIEW,
            employeesTabAction = ACTION_VIEW,
            customersTabAction = ACTION_VIEW,
            categoriesTabAction = ACTION_VIEW,
            productsTabAction = ACTION_VIEW,
            ordersTabAction = ACTION_VIEW,
            orderDetailsTabAction = ACTION_VIEW;

        private Control[] suppliersInfoViews,
            employeesInfoViews,
            customersInfoViews,
            categoriesInfoViews,
            productsInfoViews,
            ordersInfoViews,
            orderDetailsInfoViews;

        public MainForm()
        {
            InitializeComponent();
        }
        private void updateCustomersInfo()
        {
            int currentIndex;
            if (CustomersDataGridView.CurrentCell != null)
            {
                currentIndex = CustomersDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                currentIndex = 0;
            }

            if (CustomersDataGridView.Rows[currentIndex].Cells[0].Value != null)
            {
                textBoxCustomerId.Text = CustomersDataGridView.Rows[currentIndex].Cells[0].Value.ToString();
            }
            if (CustomersDataGridView.Rows[currentIndex].Cells[1].Value != null)
            {
                textBoxCustomerName.Text = CustomersDataGridView.Rows[currentIndex].Cells[1].Value.ToString();
            }
            if (CustomersDataGridView.Rows[currentIndex].Cells[2].Value != null)
            {
                textBoxCustomerAddress.Text = CustomersDataGridView.Rows[currentIndex].Cells[2].Value.ToString();
            }
            if (CustomersDataGridView.Rows[currentIndex].Cells[3].Value != null)
            {
                textBoxCustomerPhone.Text = CustomersDataGridView.Rows[currentIndex].Cells[3].Value.ToString();
            }
        }


        private Customer getCustomerFromInfoViews()
        {
            int id = textBoxCustomerId.Text.Equals("") ? -1 : Int32.Parse(textBoxCustomerId.Text);
            string name = textBoxCustomerName.Text;
            string address = textBoxCustomerAddress.Text;
            string phone = textBoxCustomerPhone.Text;

            Customer Customer = new Customer(id, name, address, phone);

            return Customer;
        }

        private void setCustomerInfoViewsReadOnly(bool id, bool name, bool birth, bool address, bool phone)
        {
            textBoxCustomerId.ReadOnly = id;
            textBoxCustomerName.ReadOnly = name;
            textBoxCustomerAddress.ReadOnly = address;
            textBoxCustomerPhone.ReadOnly = phone;
        }
        private void displayCustomers()
        {
            CustomersDataGridView.DataSource = CustomersBUS.getCustomersDataTable();

            updateCustomersInfo();
        }
        private void initTabsInfoViews()
        {
            suppliersInfoViews = new Control[4]
                    {
                        textBoxSupplierId,
                        textBoxSupplierName,
                        textBoxSupplierAddress,
                        textBoxSupplierPhone
                    };
            employeesInfoViews = new Control[5]
                    {
                        textBoxEmployeeId,
                        textBoxEmployeeName,
                        dateTimePickerEmployeeBirthDate,
                        textBoxEmployeeAddress,
                        textBoxEmployeePhone
                    };
            customersInfoViews = new Control[4]
                   {
                        textBoxCustomerId,
                        textBoxCustomerName,
                        textBoxCustomerAddress,
                        textBoxCustomerPhone
                   };
            categoriesInfoViews = new Control[3]
                   {
                        textBoxCategoryId,
                        textBoxCategoryName,
                        textBoxCategoryDescription
                   };
            productsInfoViews = new Control[6]
                    {
                        textBoxProductId,
                        textBoxProductName,
                        comboBoxProductsSupplierId,
                        comboBoxProductsCategoryId,
                        textBoxProductInputPrice,
                        textBoxProductOutputPrice
                    };
            ordersInfoViews = new Control[4]
                    {
                        textBoxOrderId,
                        comboBoxOrdersCustomerId,
                        comboBoxOrdersEmployeeId,
                        dateTimePickerOrderDate
                    };
            orderDetailsInfoViews = new Control[5]
                    {
                        comboBoxOrderDetailsOrderId,
                        comboBoxOrderDetailsProductId,
                        textBoxOrderDetailsPrice,
                        textBoxOrderDetailsQuantity,
                        textBoxOrderDetailsDiscount
                    };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // init tabs's controls.
            initTabsInfoViews();

            // Module 1: Suppliers.
            displaySuppliers();
            // init tabs's controls.
            
          

            // Module 2: Employees.
            displayEmployees();

            // Module 3: Customers.
            displayCustomers();

            // Module 4: Categories.
            displayCategories();

            // Module 5: Products.
            displayProducts();

            // Module 6: Orders.
            displayOrders();

            // Module 7: Order Details.
            displayOrderDetails();
        }

        /*************************************  Module 1: Suppliers - Start. *************************************/
        private void displayEmployees()
        {
            // set DataSource for employees data gridview
            employeesDataGridView.DataSource = EmployeesBUS.getEmployeesDataTable();

            // get employees info.
            updateEmployeesInfo();
        }


        private void updateEmployeesInfo()
        {
            int currentIndex;
            if (employeesDataGridView.CurrentCell != null)
            {
                currentIndex = employeesDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                currentIndex = 0;
            }

            if (employeesDataGridView.Rows[currentIndex].Cells[0].Value != null)
            {
                textBoxEmployeeId.Text = employeesDataGridView.Rows[currentIndex].Cells[0].Value.ToString();
            }
            if (employeesDataGridView.Rows[currentIndex].Cells[1].Value != null)
            {
                textBoxEmployeeName.Text = employeesDataGridView.Rows[currentIndex].Cells[1].Value.ToString();
            }
            if (employeesDataGridView.Rows[currentIndex].Cells[2].Value != null)
            {
                String[] dateTime = employeesDataGridView.Rows[currentIndex].Cells[2].Value.ToString().Split('/', ' ');
                if (dateTime.Length > 2)
                {
                    DateTime date = new DateTime(Int32.Parse(dateTime[2]), Int32.Parse(dateTime[0]), Int32.Parse(dateTime[1]));
                    dateTimePickerEmployeeBirthDate.Value = date;
                }
            }
            if (employeesDataGridView.Rows[currentIndex].Cells[3].Value != null)
            {
                textBoxEmployeeAddress.Text = employeesDataGridView.Rows[currentIndex].Cells[3].Value.ToString();
            }
            if (employeesDataGridView.Rows[currentIndex].Cells[4].Value != null)
            {
                textBoxEmployeePhone.Text = employeesDataGridView.Rows[currentIndex].Cells[4].Value.ToString();
            }
        }
        private Employee getEmployeeFromInfoViews()
        {
            int id = textBoxEmployeeId.Text.Equals("") ? -1 : Int32.Parse(textBoxEmployeeId.Text);
            string name = textBoxEmployeeName.Text;
            DateTime birth = dateTimePickerEmployeeBirthDate.Value;
            string address = textBoxEmployeeAddress.Text;
            string phone = textBoxEmployeePhone.Text;

            Employee employee = new Employee(id, name, birth, address, phone);

            return employee;
        }
        private void displaySuppliers()
        {
            // set DataSource for suppliers data gridview
            suppliersDataGridView.DataSource = SuppliersBUS.getSuppliersDataTable();

            // get suppliers info.
            updateSuppliersInfo();
        }


        private void updateSuppliersInfo()
        {
           int CurrentIndex = suppliersDataGridView.CurrentCell.RowIndex;

            if (suppliersDataGridView.Rows[CurrentIndex].Cells[0].Value != null)
            {
                textBoxSupplierId.Text = suppliersDataGridView.Rows[CurrentIndex].Cells[0].Value.ToString();
            }
            if (suppliersDataGridView.Rows[CurrentIndex].Cells[1].Value != null)
            {
                textBoxSupplierName.Text = suppliersDataGridView.Rows[CurrentIndex].Cells[1].Value.ToString();
            }
            if (suppliersDataGridView.Rows[CurrentIndex].Cells[2].Value != null)
            {
                textBoxSupplierAddress.Text = suppliersDataGridView.Rows[CurrentIndex].Cells[2].Value.ToString();
            }
            if (suppliersDataGridView.Rows[CurrentIndex].Cells[3].Value != null)
            {
                textBoxSupplierPhone.Text = suppliersDataGridView.Rows[CurrentIndex].Cells[3].Value.ToString();
            }
        }

        private void suppliersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateSuppliersInfo();
        }

        private void changeTabButtonsMode(int tab, String action)
        {
            Button[] buttons = new Button[3];
            Control[] controls = null;
            switch (tab)
            {
                case TAB_SUPPLIERS:
                    buttons[0] = suppliersAddButton;
                    buttons[1] = suppliersEditButton;
                    buttons[2] = suppliersDeleteButton;
                    controls = suppliersInfoViews;
                    break;
                case TAB_EMPLOYEES:
                    buttons[0] = employeesAddButton;
                    buttons[1] = employeesEditButton;
                    buttons[2] = employeesDeleteButton;
                    controls = employeesInfoViews;
                    break;
                case TAB_CUSTOMERS:
                    buttons[0] = customersAddButton;
                    buttons[1] = customersEditButton;
                    buttons[2] = customersDeleteButton;
                    controls = customersInfoViews;
                    break;
                case TAB_CATEGORIES:
                    buttons[0] = categoriesAddButton;
                    buttons[1] = categoriesEditButton;
                    buttons[2] = categoriesDeleteButton;
                    controls = categoriesInfoViews;
                    break;
                case TAB_PRODUCTS:
                    buttons[0] = productsAddButton;
                    buttons[1] = productsEditButton;
                    buttons[2] = productsDeleteButton;
                    controls = productsInfoViews;
                    break;
                case TAB_ORDERS:
                    buttons[0] = ordersAddButton;
                    buttons[1] = ordersEditButton;
                    buttons[2] = ordersDeleteButton;
                    controls = ordersInfoViews;
                    break;
                case TAB_ORDER_DETAILS:
                    buttons[0] = orderDetailsAddButton;
                    buttons[1] = orderDetailsEditButton;
                    buttons[2] = orderDetailsDeleteButton;
                    controls = orderDetailsInfoViews;
                    break;
            }

            bool[] isReadOnly = new bool[controls.Length];

            switch (action)
            {
                case ACTION_VIEW:
                    setTabButtonsEnabled(buttons, true, true, true);
                    setTabButtonsText(buttons, ADD, EDIT, DELETE);
                    for (int i = 0; i < controls.Length; i++)
                    {
                        isReadOnly[i] = true;
                    }
                    setInfoViewsReadOnly(controls, isReadOnly);
                    break;
                case ACTION_ADD:
                    setTabButtonsEnabled(buttons, true, true, false);
                    setTabButtonsText(buttons, SAVE, CANCEL, DELETE);
                    isReadOnly[0] = true;
                    for (int i = 1; i < controls.Length; i++)
                    {
                        isReadOnly[i] = false;
                    }
                    if (tab == TAB_ORDER_DETAILS)
                    {
                        isReadOnly[0] = false;
                    }
                    setInfoViewsReadOnly(controls, isReadOnly);
                    break;
                case ACTION_EDIT:
                    setTabButtonsEnabled(buttons, true, true, false);
                    setTabButtonsText(buttons, SAVE, CANCEL, DELETE);
                    isReadOnly[0] = true;
                    for (int i = 1; i < controls.Length; i++)
                    {
                        isReadOnly[i] = false;
                    }
                    if (tab == TAB_ORDER_DETAILS)
                    {
                        isReadOnly[1] = true;
                    }
                    setInfoViewsReadOnly(controls, isReadOnly);
                    break;
            }
        }

        /*
         * Set "Enabel" property for buttons.
         * @parameters:
         * - (Button[]) buttons: Buttons to set enabled in order: 'add button', 'edit button', 'delete button'.
         * - (bool) add, edit, delete: values to set enabel property for buttons. 
         */
        private void setTabButtonsEnabled(Button[] buttons, bool add, bool edit, bool delete)
        {
            buttons[0].Enabled = add;
            buttons[1].Enabled = edit;
            buttons[2].Enabled = delete;
        }

        private void setTabButtonsText(Button[] buttons, string add, string edit, string delete)
        {
            buttons[0].Text = add;
            buttons[1].Text = edit;
            buttons[2].Text = delete;
        }

        private void suppliersAddButton_Click(object sender, EventArgs e)
        {
            switch (employeesTabAction)
            {
                case ACTION_VIEW:
                    employeesTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_ADD);
                    clearInfoViews(employeesInfoViews);
                    break;
                case ACTION_ADD:
                    employeesTabAction = ACTION_VIEW;
                    Employee employee1 = getEmployeeFromInfoViews();
                    EmployeesBUS.addEmployee(employee1);
                    displayEmployees();
                    updateOrdersComboBoxes();
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    employeesTabAction = ACTION_VIEW;
                    Employee employee2 = getEmployeeFromInfoViews();
                    EmployeesBUS.editEmployee(employee2);
                    displayEmployees();
                    updateOrdersComboBoxes();
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_VIEW);
                    break;
            }
        }

        private Supplier getSupplierFromInfoViews()
        {
            int id = textBoxSupplierId.Text.Equals("") ? -1 : Int32.Parse(textBoxSupplierId.Text);
            string name = textBoxSupplierName.Text;
            string address = textBoxSupplierAddress.Text;
            string phone = textBoxSupplierPhone.Text;

            Supplier supplier = new Supplier(id, name, address, phone);

            return supplier;
        }

        private void clearInfoViews(Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
                if(control is ComboBox)
                {
                    ((ComboBox)control).Text = "";
                }
            }
        }

        private void setInfoViewsReadOnly(Control[] controls, params bool[] isReadOnly)
        {
            int i = 0;
            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).ReadOnly = isReadOnly[i];
                }
                else
                {
                    control.Enabled = !isReadOnly[i];
                }
                i++;
            }
        }

        private void suppliersEditButton_Click(object sender, EventArgs e)
        {
            switch (suppliersTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    suppliersTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_SUPPLIERS, ACTION_VIEW);
                    displaySuppliers();
                    break;
                case ACTION_VIEW:
                    suppliersTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_SUPPLIERS, ACTION_EDIT);
                    break;
            }
        }

        private void suppliersDeleteButton_Click(object sender, EventArgs e)
        {
            int id = textBoxSupplierId.Text.Equals("") ? -1 : Int32.Parse(textBoxSupplierId.Text);
            if (id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa nhà cung cấp số " + id + " không?",
                    "Xoá nhà cung cấp", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SuppliersBUS.deleteSupplier(id);
                    displaySuppliers();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn nhà cung cấp cần xóa!");
            }
        }
        /**********************************  Module 4: Categories - Start. ***********************************/

        private void displayCategories()
        {
            categoriesDataGridView.DataSource = CategoriesBUS.getCategoriesDataTable();

            updateCategoryInfo();
        }

        private void updateCategoryInfo()
        {
            int currentIndex;
            if (categoriesDataGridView.CurrentCell != null)
            {
                currentIndex = categoriesDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                currentIndex = 0;
            }

            if (categoriesDataGridView.Rows[currentIndex].Cells[0].Value != null)
            {
                textBoxCategoryId.Text = categoriesDataGridView.Rows[currentIndex].Cells[0].Value.ToString();
            }
            if (categoriesDataGridView.Rows[currentIndex].Cells[1].Value != null)
            {
                textBoxCategoryName.Text = categoriesDataGridView.Rows[currentIndex].Cells[1].Value.ToString();
            }
            if (categoriesDataGridView.Rows[currentIndex].Cells[2].Value != null)
            {
                textBoxCategoryDescription.Text = categoriesDataGridView.Rows[currentIndex].Cells[2].Value.ToString();
            }
        }

        private Category getCategoryFromInfoViews()
        {
            int id = textBoxCategoryId.Text.Equals("") ? -1 : Int32.Parse(textBoxCategoryId.Text);
            string name = textBoxCategoryName.Text;
            string description = textBoxCategoryDescription.Text;

            Category Category = new Category(id, name, description);

            return Category;
        }

        private void CategoriesEditButton_Click(object sender, EventArgs e)
        {
            switch (categoriesTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    categoriesTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_CATEGORIES, ACTION_VIEW);
                    displayCategories();
                    break;
                case ACTION_VIEW:
                    categoriesTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_CATEGORIES, ACTION_EDIT);
                    break;
            }

        }

        private void CategoriesDeleteButton_Click(object sender, EventArgs e)
        {
            int id = textBoxCategoryId.Text.Equals("") ? -1 : Int32.Parse(textBoxCategoryId.Text);
            if (id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa loại hàng số " + id + " không?",
                    "Xoá loại hàng", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CategoriesBUS.deleteCategory(id);
                    displayCategories();
                    updateProductsComboBoxes();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn loại hàng cần xóa!");
            }

        }

        private void CategoriesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateCategoryInfo();
        }

        private void CategoriesAddButton_Click(object sender, EventArgs e)
        {
            switch (categoriesTabAction)
            {
                case ACTION_VIEW:
                    categoriesTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_CATEGORIES, ACTION_ADD);
                    clearInfoViews(categoriesInfoViews);
                    break;
                case ACTION_ADD:
                    categoriesTabAction = ACTION_VIEW;
                    Category Category1 = getCategoryFromInfoViews();
                    CategoriesBUS.addCategory(Category1);
                    displayCategories();
                    updateProductsComboBoxes();
                    changeTabButtonsMode(TAB_CATEGORIES, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    categoriesTabAction = ACTION_VIEW;
                    Category Category2 = getCategoryFromInfoViews();
                    CategoriesBUS.editCategory(Category2);
                    displayCategories();
                    updateProductsComboBoxes();
                    changeTabButtonsMode(TAB_CATEGORIES, ACTION_VIEW);
                    break;
            }
        }

        /***********************************  Module 4: Categories - End. ************************************/
        /***********************************  Module 5: Products - Start. ***********************************/

        private void displayProducts()
        {
            productsDataGridView.DataSource = ProductsBUS.getProductsDataTable();

            updateProductInfo();

            updateProductsComboBoxes();
        }

        private void updateProductsComboBoxes()
        {
            ProductsBUS.loadCombobox(1, comboBoxProductsSupplierId);
            ProductsBUS.loadCombobox(2, comboBoxProductsCategoryId);
        }

        private void updateProductInfo()
        {
            int currentIndex;
            if (productsDataGridView.CurrentCell != null)
            {
                currentIndex = productsDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                currentIndex = 0;
            }

            if (productsDataGridView.Rows[currentIndex].Cells[0].Value != null)
            {
                textBoxProductId.Text = productsDataGridView.Rows[currentIndex].Cells[0].Value.ToString();
            }
            if (productsDataGridView.Rows[currentIndex].Cells[1].Value != null)
            {
                textBoxProductName.Text = productsDataGridView.Rows[currentIndex].Cells[1].Value.ToString();
            }
            if (productsDataGridView.Rows[currentIndex].Cells[2].Value != null)
            {
                comboBoxProductsSupplierId.Text = productsDataGridView.Rows[currentIndex].Cells[2].Value.ToString();
            }
            if (productsDataGridView.Rows[currentIndex].Cells[3].Value != null)
            {
                comboBoxProductsCategoryId.Text = productsDataGridView.Rows[currentIndex].Cells[3].Value.ToString();
            }
            if (productsDataGridView.Rows[currentIndex].Cells[4].Value != null)
            {
                textBoxProductInputPrice.Text = productsDataGridView.Rows[currentIndex].Cells[4].Value.ToString();
            }
            if (productsDataGridView.Rows[currentIndex].Cells[5].Value != null)
            {
                textBoxProductOutputPrice.Text = productsDataGridView.Rows[currentIndex].Cells[5].Value.ToString();
            }
        }

        private Product getProductFromInfoViews()
        {
            int id = textBoxProductId.Text.Equals("") ? -1 : Int32.Parse(textBoxProductId.Text);
            string name = textBoxProductName.Text;
            int supplierId = comboBoxProductsSupplierId.Text.Equals("") ? -1 :
                Int32.Parse(comboBoxProductsSupplierId.Text);
            int categoryId = comboBoxProductsCategoryId.Text.Equals("") ? -1 :
                Int32.Parse(comboBoxProductsCategoryId.Text);

            decimal input, output;
            try
            {
                input = Decimal.Parse(textBoxProductInputPrice.Text);
            }
            catch (Exception e)
            {
                input = -1;
            }

            try
            {
                output = Decimal.Parse(textBoxProductOutputPrice.Text);
            }
            catch (Exception e)
            {
                output = -1;
            }

            Product product = new Product(id, name, supplierId, categoryId, input, output);

            return product;
        }

        private void ProductsEditButton_Click(object sender, EventArgs e)
        {
            switch (productsTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    productsTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_PRODUCTS, ACTION_VIEW);
                    displayCategories();
                    break;
                case ACTION_VIEW:
                    productsTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_PRODUCTS, ACTION_EDIT);
                    break;
            }

        }

        private void ProductsDeleteButton_Click(object sender, EventArgs e)
        {
            int id = textBoxProductId.Text.Equals("") ? -1 : Int32.Parse(textBoxProductId.Text);
            if (id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa sản phẩm số " + id + " không?",
                    "Xoá sản phẩm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ProductsBUS.deleteProduct(id);
                    displayProducts();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm cần xóa!");
            }

        }

        private void ProductsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateProductInfo();
        }

        private void ProductsAddButton_Click(object sender, EventArgs e)
        {
            switch (productsTabAction)
            {
                case ACTION_VIEW:
                    productsTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_PRODUCTS, ACTION_ADD);
                    clearInfoViews(productsInfoViews);
                    break;
                case ACTION_ADD:
                    productsTabAction = ACTION_VIEW;
                    Product product1 = getProductFromInfoViews();
                    ProductsBUS.addProduct(product1);
                    displayProducts();
                    changeTabButtonsMode(TAB_PRODUCTS, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    productsTabAction = ACTION_VIEW;
                    Product product2 = getProductFromInfoViews();
                    ProductsBUS.editProduct(product2);
                    displayProducts();
                    changeTabButtonsMode(TAB_PRODUCTS, ACTION_VIEW);
                    break;
            }
        }

        /***********************************  Module 5: Products - End. ************************************/
        /***********************************  Module 6: Orders - Start. ************************************/

        private void displayOrders()
        {
            OrdersDataGridView.DataSource = OrdersBUS.getOrdersDataTable();

            updateOrderInfo();

            updateOrdersComboBoxes();
        }

        private void updateOrdersComboBoxes()
        {
            OrdersBUS.loadCombobox(1, comboBoxOrdersCustomerId);
            OrdersBUS.loadCombobox(2, comboBoxOrdersEmployeeId);
        }

        private void updateOrderInfo()
        {
            int currentIndex;
            if (OrdersDataGridView.CurrentCell != null)
            {
                currentIndex = OrdersDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                currentIndex = 0;
            }

            if (OrdersDataGridView.Rows[currentIndex].Cells[0].Value != null)
            {
                textBoxOrderId.Text = OrdersDataGridView.Rows[currentIndex].Cells[0].Value.ToString();
            }
            if (OrdersDataGridView.Rows[currentIndex].Cells[1].Value != null)
            {
                comboBoxOrdersCustomerId.Text = OrdersDataGridView.Rows[currentIndex].Cells[1].Value.ToString();
            }
            if (OrdersDataGridView.Rows[currentIndex].Cells[2].Value != null)
            {
                comboBoxOrdersEmployeeId.Text = OrdersDataGridView.Rows[currentIndex].Cells[2].Value.ToString();
            }
            if (OrdersDataGridView.Rows[currentIndex].Cells[3].Value != null)
            {
                String[] dateTime = OrdersDataGridView.Rows[currentIndex].Cells[3].Value.ToString().Split('/', ' ');
                if (dateTime.Length > 2)
                {
                    DateTime date = new DateTime(Int32.Parse(dateTime[2]), Int32.Parse(dateTime[0]), Int32.Parse(dateTime[1]));
                    dateTimePickerOrderDate.Value = date;
                }
                else
                {
                    dateTimePickerOrderDate.Value = DateTime.UtcNow;
                }
            }

        }

        private Order getOrderFromInfoViews()
        {
            int id = textBoxOrderId.Text.Equals("") ? -1 : Int32.Parse(textBoxOrderId.Text);
            int customerId = comboBoxOrdersCustomerId.Text.Equals("") ? -1 : Int32.Parse(comboBoxOrdersCustomerId.Text);
            int employeeId = comboBoxOrdersEmployeeId.Text.Equals("") ? -1 : Int32.Parse(comboBoxOrdersEmployeeId.Text);
            DateTime date = dateTimePickerOrderDate.Value;


            Order order = new Order(id, customerId, employeeId, date);

            return order;
        }

        private void comboBoxOrderDetailsOrderId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBoxOrderDetailsOrderId.Text.Equals("") ? -1 :
                Int32.Parse(comboBoxOrderDetailsOrderId.Text);
            comboBoxOrderDetailsProductId.Text = "";
            updateOrderDetailsComboBoxes(2, id, comboBoxOrderDetailsProductId);
        }

        private void suppliersTab_Click(object sender, EventArgs e)
        {

        }

        private void employeesAddButton_Click(object sender, EventArgs e)
        {
            switch (employeesTabAction)
            {
                case ACTION_VIEW:
                    employeesTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_ADD);
                    clearInfoViews(employeesInfoViews);
                    break;
                case ACTION_ADD:
                    employeesTabAction = ACTION_VIEW;
                    Employee employee1 = getEmployeeFromInfoViews();
                    EmployeesBUS.addEmployee(employee1);
                    displayEmployees();
                    updateOrdersComboBoxes();
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    employeesTabAction = ACTION_VIEW;
                    Employee employee2 = getEmployeeFromInfoViews();
                    EmployeesBUS.editEmployee(employee2);
                    displayEmployees();
                    updateOrdersComboBoxes();
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_VIEW);
                    break;
            }
        }

        private void employeesEditButton_Click(object sender, EventArgs e)
        {
            switch (employeesTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    employeesTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_VIEW);
                    displayEmployees();
                    break;
                case ACTION_VIEW:
                    employeesTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_EMPLOYEES, ACTION_EDIT);
                    break;
            }
        }

        private void employeesDeleteButton_Click(object sender, EventArgs e)
        {

            int id = textBoxEmployeeId.Text.Equals("") ? -1 : Int32.Parse(textBoxEmployeeId.Text);
            if (id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa nhân viên số " + id + " không?",
                    "Xoá nhân viên", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    EmployeesBUS.deleteEmployee(id);
                    displayEmployees();
                    updateOrdersComboBoxes();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn nhân viên cần xóa!");
            }
        }

        private void customersAddButton_Click(object sender, EventArgs e)
        {
            switch (customersTabAction)
            {
                case ACTION_VIEW:
                    customersTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_CUSTOMERS, ACTION_ADD);
                    clearInfoViews(customersInfoViews);
                    break;
                case ACTION_ADD:
                    customersTabAction = ACTION_VIEW;
                    Customer Customer1 = getCustomerFromInfoViews();
                    CustomersBUS.addCustomer(Customer1);
                    displayCustomers();
                    updateOrdersComboBoxes();
                    changeTabButtonsMode(TAB_CUSTOMERS, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    customersTabAction = ACTION_VIEW;
                    Customer Customer2 = getCustomerFromInfoViews();
                    CustomersBUS.editCustomer(Customer2);
                    displayCustomers();
                    updateOrdersComboBoxes();
                    changeTabButtonsMode(TAB_CUSTOMERS, ACTION_VIEW);
                    break;
            }
        }

        private void customersEditButton_Click(object sender, EventArgs e)
        {
            switch (customersTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    customersTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_CUSTOMERS, ACTION_VIEW);
                    displayCustomers();
                    break;
                case ACTION_VIEW:
                    customersTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_CUSTOMERS, ACTION_EDIT);
                    break;
            }
        }

        private void customersDeleteButton_Click(object sender, EventArgs e)
        {
            int id = textBoxCustomerId.Text.Equals("") ? -1 : Int32.Parse(textBoxCustomerId.Text);
            if (id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa khách hàng số " + id + " không?",
                    "Xoá khách hàng", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CustomersBUS.deleteCustomer(id);
                    displayCustomers();
                    updateOrdersComboBoxes();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn khách hàng cần xóa!");
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void salesManagementTabControl_MouseClick(object sender, MouseEventArgs e)
        {
            webBrowser1.Navigate("https://docs.google.com/document/d/1o3Ebu-LmSFUvatzSCy9NeV4EByuKcfNqd1Hr78hRSY0/edit");
        }

        private void OrdersEditButton_Click(object sender, EventArgs e)
        {
            switch (ordersTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    ordersTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_ORDERS, ACTION_VIEW);
                    displayOrders();
                    break;
                case ACTION_VIEW:
                    ordersTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_ORDERS, ACTION_EDIT);
                    break;
            }

        }

        private void OrdersDeleteButton_Click(object sender, EventArgs e)
        {
            int id = textBoxOrderId.Text.Equals("") ? -1 : Int32.Parse(textBoxOrderId.Text);
            if (id > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa hóa đơn số " + id + " không?",
                    "Xoá hóa đơn", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OrdersBUS.deleteOrder(id);
                    displayOrders();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn hóa đơn cần xóa!");
            }

        }

        private void OrdersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateOrderInfo();
        }

        private void OrdersAddButton_Click(object sender, EventArgs e)
        {
            switch (ordersTabAction)
            {
                case ACTION_VIEW:
                    ordersTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_ORDERS, ACTION_ADD);
                    clearInfoViews(ordersInfoViews);
                    break;
                case ACTION_ADD:
                    ordersTabAction = ACTION_VIEW;
                    Order order1 = getOrderFromInfoViews();
                    OrdersBUS.addOrder(order1);
                    displayOrders();
                    changeTabButtonsMode(TAB_ORDERS, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    ordersTabAction = ACTION_VIEW;
                    Order order2 = getOrderFromInfoViews();
                    OrdersBUS.editOrder(order2);
                    displayOrders();
                    changeTabButtonsMode(TAB_ORDERS, ACTION_VIEW);
                    break;
            }
        }

        /***********************************  Module 6: Orders - End. ************************************/

        /*******************************  Module 7: Order Details - Start. *******************************/

        private void displayOrderDetails()
        {
            orderDetailsDataGridView.DataSource = OrderDetailsBUS.getOrderDetailsDataTable();

            updateOrderDetailInfo();

            updateOrderDetailsComboBoxes(1, 0, comboBoxOrderDetailsOrderId);
        }

        private void updateOrderDetailsComboBoxes(int key, int id, ComboBox comboBox)
        {
            OrderDetailsBUS.loadCombobox(key, id, comboBox);
        }

        private void updateOrderDetailInfo()
        {
            int currentIndex;
            if (orderDetailsDataGridView.CurrentCell != null)
            {
                currentIndex = orderDetailsDataGridView.CurrentCell.RowIndex;
            }
            else
            {
                currentIndex = 0;
            }

            if (orderDetailsDataGridView.Rows[currentIndex].Cells[0].Value != null)
            {
                comboBoxOrderDetailsOrderId.Text = orderDetailsDataGridView.Rows[currentIndex].Cells[0].Value.ToString();
            }
            if (orderDetailsDataGridView.Rows[currentIndex].Cells[1].Value != null)
            {
                comboBoxOrderDetailsProductId.Text = orderDetailsDataGridView.Rows[currentIndex].Cells[1].Value.ToString();
            }
            if (orderDetailsDataGridView.Rows[currentIndex].Cells[2].Value != null)
            {
                textBoxOrderDetailsPrice.Text = orderDetailsDataGridView.Rows[currentIndex].Cells[2].Value.ToString();
            }
            if (orderDetailsDataGridView.Rows[currentIndex].Cells[3].Value != null)
            {
                textBoxOrderDetailsQuantity.Text = orderDetailsDataGridView.Rows[currentIndex].Cells[3].Value.ToString();
            }
            if (orderDetailsDataGridView.Rows[currentIndex].Cells[4].Value != null)
            {
                textBoxOrderDetailsDiscount.Text = orderDetailsDataGridView.Rows[currentIndex].Cells[4].Value.ToString();
            }
        }

        private OrderDetail getOrderDetailFromInfoViews()
        {
            int orderId = comboBoxOrderDetailsOrderId.Text.Equals("") ? -1 : Int32.Parse(comboBoxOrderDetailsOrderId.Text);
            int productId = comboBoxOrderDetailsProductId.Text.Equals("") ? -1 : Int32.Parse(comboBoxOrderDetailsProductId.Text);
            decimal price = textBoxOrderDetailsPrice.Text.Equals("") ? -1 : decimal.Parse(textBoxOrderDetailsPrice.Text);
            int quantity = textBoxOrderDetailsQuantity.Text.Equals("") ? -1 : Int32.Parse(textBoxOrderDetailsQuantity.Text);
            decimal discount = textBoxOrderDetailsDiscount.Text.Equals("") ? -1 : decimal.Parse(textBoxOrderDetailsDiscount.Text);

            OrderDetail order = new OrderDetail(orderId, productId, price, quantity, discount);

            return order;
        }

        private void OrderDetailsEditButton_Click(object sender, EventArgs e)
        {
            switch (orderDetailsTabAction)
            {
                case ACTION_ADD:
                case ACTION_EDIT:
                    orderDetailsTabAction = ACTION_VIEW;
                    changeTabButtonsMode(TAB_ORDER_DETAILS, ACTION_VIEW);
                    displayOrderDetails();
                    break;
                case ACTION_VIEW:
                    orderDetailsTabAction = ACTION_EDIT;
                    changeTabButtonsMode(TAB_ORDER_DETAILS, ACTION_EDIT);
                    break;
            }

        }

        private void OrderDetailsDeleteButton_Click(object sender, EventArgs e)
        {
            int id = comboBoxOrderDetailsOrderId.Text.Equals("") ? -1 : Int32.Parse(comboBoxOrderDetailsOrderId.Text);
            int id1 = comboBoxOrderDetailsProductId.Text.Equals("") ? -1 : Int32.Parse(comboBoxOrderDetailsProductId.Text);
            if (id > 0 && id1 > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa chi tiết hóa đơn này không?",
                    "Xoá chi tiết hóa đơn", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OrderDetailsBUS.deleteOrderDetail(id, id1);
                    displayOrderDetails();
                }
                else if (dialogResult == DialogResult.No)
                {
                    // Do nothing
                }
            }
            else
            {
                MessageBox.Show("Chọn chi tiết hóa đơn cần xóa!");
            }

        }

        private void OrderDetailsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateOrderDetailInfo();
        }

        private void OrderDetailsAddButton_Click(object sender, EventArgs e)
        {
            switch (orderDetailsTabAction)
            {
                case ACTION_VIEW:
                    orderDetailsTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_ORDER_DETAILS, ACTION_ADD);
                    clearInfoViews(orderDetailsInfoViews);
                    break;
                case ACTION_ADD:
                    orderDetailsTabAction = ACTION_VIEW;
                    OrderDetail od = getOrderDetailFromInfoViews();
                    OrderDetailsBUS.addOrderDetail(od);
                    displayOrderDetails();
                    changeTabButtonsMode(TAB_ORDER_DETAILS, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    orderDetailsTabAction = ACTION_VIEW;
                    OrderDetail od1 = getOrderDetailFromInfoViews();
                    OrderDetailsBUS.editOrderDetail(od1);
                    displayOrderDetails();
                    changeTabButtonsMode(TAB_ORDER_DETAILS, ACTION_VIEW);
                    break;
            }
        }

        /*******************************  Module 7: Order Details - End. ********************************/


    }
}
