using SalesManagement.DAL;
using SalesManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.BUS
{
    class EmployeesBUS
    {
        public static DataTable getEmployeesDataTable()
        {
            return EmployeesDAL.getEmployeesDataTable();
        }

        public static void addEmployee(Employee employee)
        {
            EmployeesDAL.addEmployee(employee);
        }

        public static void editEmployee(Employee employee)
        {
            EmployeesDAL.editEmployee(employee);
        }

        public static void deleteEmployee(int id)
        {
            EmployeesDAL.deleteEmployee(id);
        }
    }
}
