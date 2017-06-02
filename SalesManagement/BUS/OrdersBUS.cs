using SalesManagement.DAL;
using SalesManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement.BUS
{
    class OrdersBUS
    {
        public static DataTable getOrdersDataTable()
        {
            return OrdersDAL.getOrdersDataTable();
        }

        public static void addOrder(Order Order)
        {
            OrdersDAL.addOrder(Order);
        }

        public static void editOrder(Order Order)
        {
            OrdersDAL.editOrder(Order);
        }

        public static void deleteOrder(int id)
        {
            OrdersDAL.deleteOrder(id);
        }

        public static void loadCombobox(int comboBoxId, ComboBox comboBox)
        {
            OrdersDAL.loadCombobox(comboBoxId, comboBox);
        }
    }
}
