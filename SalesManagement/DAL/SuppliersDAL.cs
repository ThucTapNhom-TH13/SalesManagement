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
    class SuppliersDAL
    {
        public static DataTable getSuppliersDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_suppliers", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addSupplier(Supplier supplier)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_supplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@address", SqlDbType.NVarChar);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);

            cmd.Parameters["@name"].Value = supplier.Name;
            cmd.Parameters["@address"].Value = supplier.Address;
            cmd.Parameters["@phone"].Value = supplier.Phone;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editSupplier(Supplier supplier)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_supplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@address", SqlDbType.NVarChar);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);

            cmd.Parameters["@id"].Value = supplier.Id;
            cmd.Parameters["@name"].Value = supplier.Name;
            cmd.Parameters["@address"].Value = supplier.Address;
            cmd.Parameters["@phone"].Value = supplier.Phone;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteSupplier(int id)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_supplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);

            cmd.Parameters["@id"].Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
