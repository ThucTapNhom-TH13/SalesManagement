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
    class OrderDetailsBUS
    {
        public static DataTable getOrderDetailsDataTable()
        {
            return OrderDetailsDAL.getOrderDetailsDataTable();
        }

        public static void addOrderDetail(OrderDetail Order)
        {
            OrderDetailsDAL.addOrderDetail(Order);
        }

        public static void editOrderDetail(OrderDetail Order)
        {
            OrderDetailsDAL.editOrderDetail(Order);
        }

        public static void deleteOrderDetail(int orderId, int productId)
        {
            OrderDetailsDAL.deleteOrderDetail(orderId, productId);
        }

        public static void loadCombobox(int key, int id, ComboBox comboBox)
        {
            OrderDetailsDAL.loadCombobox(key, id, comboBox);
        }
    }
}
