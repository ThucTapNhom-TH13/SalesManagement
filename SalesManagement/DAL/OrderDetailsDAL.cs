using SalesManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement.DAL
{
    class OrderDetailsDAL
    {
        public static DataTable getOrderDetailsDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_order_details", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addOrderDetail(OrderDetail Order)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_order_detail", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@orderId", SqlDbType.Int);
            cmd.Parameters.Add("@productId", SqlDbType.Int);
            cmd.Parameters.Add("@price", SqlDbType.Money);
            cmd.Parameters.Add("@quantity", SqlDbType.Int);
            cmd.Parameters.Add("@discount", SqlDbType.Money);

            cmd.Parameters["@orderId"].Value = Order.OrderId;
            cmd.Parameters["@productId"].Value = Order.ProductId;

            if (Order.Price <= 0)
            {
                cmd.Parameters["@price"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@price"].Value = Order.Price;
            }

            if (Order.Quantity <= 0)
            {
                cmd.Parameters["@quantity"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@quantity"].Value = Order.Quantity;
            }

            if (Order.Discount <= 0)
            {
                cmd.Parameters["@discount"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@discount"].Value = Order.Discount;
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editOrderDetail(OrderDetail Order)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_order_detail", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@orderId", SqlDbType.Int);
            cmd.Parameters.Add("@productId", SqlDbType.Int);
            cmd.Parameters.Add("@price", SqlDbType.Money);
            cmd.Parameters.Add("@quantity", SqlDbType.Int);
            cmd.Parameters.Add("@discount", SqlDbType.Money);

            cmd.Parameters["@orderId"].Value = Order.OrderId;
            cmd.Parameters["@productId"].Value = Order.ProductId;

            if (Order.Price <= 0)
            {
                cmd.Parameters["@price"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@price"].Value = Order.Price;
            }

            if (Order.Quantity <= 0)
            {
                cmd.Parameters["@quantity"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@quantity"].Value = Order.Quantity;
            }

            if (Order.Discount <= 0)
            {
                cmd.Parameters["@discount"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@discount"].Value = Order.Discount;
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteOrderDetail(int orderId, int productId)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_order_detail", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@orderId", SqlDbType.Int);
            cmd.Parameters.Add("@productId", SqlDbType.Int);

            cmd.Parameters["@orderId"].Value = orderId;
            cmd.Parameters["@productId"].Value = productId;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void loadCombobox(int key, int id, ComboBox comboBox)
        {
            string sql;
            if (key == 1)
            {
                sql = "select OrderId from Orders";
            }
            else
            {
                sql = @"select Products.ProductId 
                        from Products
                        where Products.ProductId not in (select ProductId
                                                         from OrderDetails 
                                                         where OrderId = " + id + ")";
            }
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;

            SqlConnection conn = DatabaseHelper.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            comboBox.Items.Clear();
            while (DR.Read())
            {
                int name = DR.GetInt32(0);
                comboBox.Items.Add(name);
            }
            conn.Close();
        }

    }
}
