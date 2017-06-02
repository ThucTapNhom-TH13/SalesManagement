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
    class SuppliersBUS
    {
        public static DataTable getSuppliersDataTable()
        {
            return SuppliersDAL.getSuppliersDataTable();
        }

        public static void addSupplier(Supplier supplier)
        {
            SuppliersDAL.addSupplier(supplier);
        }

        public static void editSupplier(Supplier supplier)
        {
            SuppliersDAL.editSupplier(supplier);
        }

        public static void deleteSupplier(int id)
        {
            SuppliersDAL.deleteSupplier(id);
        }
    }
}
