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
    class CategoriesDAL
    {
        public static DataTable getCategoriesDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_categories", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addCategory(Category category)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_category", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@description", SqlDbType.NVarChar);

            cmd.Parameters["@name"].Value = category.Name;
            cmd.Parameters["@description"].Value = category.Description;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editCategory(Category category)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_Category", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@description", SqlDbType.NVarChar);

            cmd.Parameters["@id"].Value = category.Id;
            cmd.Parameters["@name"].Value = category.Name;
            cmd.Parameters["@description"].Value = category.Description;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteCategory(int id)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_category", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);

            cmd.Parameters["@id"].Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
