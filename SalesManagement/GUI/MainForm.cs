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
        }

        /*************************************  Module 1: Suppliers - Start. *************************************/
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
            switch (suppliersTabAction)
            {
                case ACTION_VIEW:
                    suppliersTabAction = ACTION_ADD;
                    changeTabButtonsMode(TAB_SUPPLIERS, ACTION_ADD);
                    clearInfoViews(suppliersInfoViews);
                    break;
                case ACTION_ADD:
                    suppliersTabAction = ACTION_VIEW;
                    Supplier supplier1 = getSupplierFromInfoViews();
                    SuppliersBUS.addSupplier(supplier1);
                    displaySuppliers();
                    updateProductsComboBoxes();
                    changeTabButtonsMode(TAB_SUPPLIERS, ACTION_VIEW);
                    break;
                case ACTION_EDIT:
                    suppliersTabAction = ACTION_VIEW;
                    Supplier supplier2 = getSupplierFromInfoViews();
                    SuppliersBUS.editSupplier(supplier2);
                    displaySuppliers();
                    updateProductsComboBoxes();
                    changeTabButtonsMode(TAB_SUPPLIERS, ACTION_VIEW);
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
