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
    class OrdersDAL
    {
        public static DataTable getOrdersDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_orders", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addOrder(Order Order)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_order", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@customerId", SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", SqlDbType.Int);
            cmd.Parameters.Add("@date", SqlDbType.Date);

            if (Order.CustomerId <= 0)
            {
                cmd.Parameters["@customerId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@customerId"].Value = Order.CustomerId;
            }

            if (Order.EmployeeId <= 0)
            {
                cmd.Parameters["@employeeId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@employeeId"].Value = Order.EmployeeId;
            }

            if(Order.Date == null)
            {
                cmd.Parameters["@date"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@date"].Value = Order.Date;
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editOrder(Order Order)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_order", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@customerId", SqlDbType.Int);
            cmd.Parameters.Add("@employeeId", SqlDbType.Int);
            cmd.Parameters.Add("@date", SqlDbType.Date);

            cmd.Parameters["@id"].Value = Order.Id;
            if (Order.CustomerId <= 0)
            {
                cmd.Parameters["@customerId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@customerId"].Value = Order.CustomerId;
            }

            if (Order.EmployeeId <= 0)
            {
                cmd.Parameters["@employeeId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@employeeId"].Value = Order.EmployeeId;
            }

            if (Order.Date == null)
            {
                cmd.Parameters["@date"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@date"].Value = Order.Date;
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteOrder(int id)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_order", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);

            cmd.Parameters["@id"].Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void loadCombobox(int comboBoxId, ComboBox comboBox)
        {
            string sql;
            if (comboBoxId == 1)
            {
                sql = "select CustomerId from Customers";
            }
            else
            {
                sql = "select EmployeeId from Employees";
            }
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;

            SqlConnection conn = DatabaseHelper.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            comboBox.Items.Clear();
            comboBox.Items.Add("");
            while (DR.Read())
            {
                int name = DR.GetInt32(0);
                comboBox.Items.Add(name);
            }
            conn.Close();
        }
    }
}
