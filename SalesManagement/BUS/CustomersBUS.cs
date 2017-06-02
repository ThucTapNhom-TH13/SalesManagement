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
    class CustomersBUS
    {
        public static DataTable getCustomersDataTable()
        {
            return CustomersDAL.getCustomersDataTable();
        }

        public static void addCustomer(Customer customer)
        {
            CustomersDAL.addCustomer(customer);
        }

        public static void editCustomer(Customer customer)
        {
            CustomersDAL.editCustomer(customer);
        }

        public static void deleteCustomer(int id)
        {
            CustomersDAL.deleteCustomer(id);
        }
    }
}
