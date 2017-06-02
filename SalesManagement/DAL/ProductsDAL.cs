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
    class ProductsDAL
    {
        public static DataTable getProductsDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_products", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addProduct(Product Product)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@supplierId", SqlDbType.Int);
            cmd.Parameters.Add("@categoryId", SqlDbType.Int);
            cmd.Parameters.Add("@input", SqlDbType.Money);
            cmd.Parameters.Add("@output", SqlDbType.Money);

            cmd.Parameters["@name"].Value = Product.Name;
            if(Product.SupplierId <= 0)
            {
                cmd.Parameters["@supplierId"].Value = Convert.DBNull;
            }else
            {
                cmd.Parameters["@supplierId"].Value = Product.SupplierId;
            }

            if (Product.CategoryId <= 0)
            {
                cmd.Parameters["@categoryId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@categoryId"].Value = Product.CategoryId;
            }

            if (Product.Input <= 0)
            {
                cmd.Parameters["@input"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@input"].Value = Product.Input;
            }

            if (Product.Output <= 0)
            {
                cmd.Parameters["@output"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@output"].Value = Product.Output;
            }    

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editProduct(Product Product)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@supplierId", SqlDbType.Int);
            cmd.Parameters.Add("@categoryId", SqlDbType.Int);
            cmd.Parameters.Add("@input", SqlDbType.Money);
            cmd.Parameters.Add("@output", SqlDbType.Money);

            cmd.Parameters["@id"].Value = Product.Id;
            cmd.Parameters["@name"].Value = Product.Name;

            if (Product.SupplierId <= 0)
            {
                cmd.Parameters["@supplierId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@supplierId"].Value = Product.SupplierId;
            }

            if (Product.CategoryId <= 0)
            {
                cmd.Parameters["@categoryId"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@categoryId"].Value = Product.CategoryId;
            }

            if (Product.Input <= 0)
            {
                cmd.Parameters["@input"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@input"].Value = Product.Input;
            }

            if (Product.Output <= 0)
            {
                cmd.Parameters["@output"].Value = Convert.DBNull;
            }
            else
            {
                cmd.Parameters["@output"].Value = Product.Output;
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteProduct(int id)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_product", conn);
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
                sql = "select SupplierId from Suppliers";
            }else
            {
                sql = "select CategoryId from Categories";
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
