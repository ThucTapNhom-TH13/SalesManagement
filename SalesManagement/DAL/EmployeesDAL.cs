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
    class EmployeesDAL
    {
        public static DataTable getEmployeesDataTable()
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand command = new SqlCommand("get_employees", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

        public static void addEmployee(Employee employee)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("add_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@birth", SqlDbType.Date);
            cmd.Parameters.Add("@address", SqlDbType.NVarChar);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);

            cmd.Parameters["@name"].Value = employee.Name;
            cmd.Parameters["@birth"].Value = employee.Birth;
            cmd.Parameters["@address"].Value = employee.Address;
            cmd.Parameters["@phone"].Value = employee.Phone;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void editEmployee(Employee employee)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("edit_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters.Add("@birth", SqlDbType.Date);
            cmd.Parameters.Add("@address", SqlDbType.NVarChar);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar);

            cmd.Parameters["@id"].Value = employee.Id;
            cmd.Parameters["@name"].Value = employee.Name;
            cmd.Parameters["@birth"].Value = employee.Birth;
            cmd.Parameters["@address"].Value = employee.Address;
            cmd.Parameters["@phone"].Value = employee.Phone;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void deleteEmployee(int id)
        {
            SqlConnection conn = DatabaseHelper.getConnection();
            SqlCommand cmd = new SqlCommand("delete_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);

            cmd.Parameters["@id"].Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
