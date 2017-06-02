using SalesManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.DAL
{
    class CustomersDAL
    {
        public static DataTable getCustomersDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_customers", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addCustomer(Customer customer)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@address", SqlDbType.NVarChar);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);

            cmd.Parameters["@name"].Value = customer.Name;
            cmd.Parameters["@address"].Value = customer.Address;
            cmd.Parameters["@phone"].Value = customer.Phone;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editCustomer(Customer customer)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@address", SqlDbType.NVarChar);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);

            cmd.Parameters["@id"].Value = customer.Id;
            cmd.Parameters["@name"].Value = customer.Name;
            cmd.Parameters["@address"].Value = customer.Address;
            cmd.Parameters["@phone"].Value = customer.Phone;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteCustomer(int id)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_customer", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);

            cmd.Parameters["@id"].Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
