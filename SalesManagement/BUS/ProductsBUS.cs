using SalesManagement.DAL;
using SalesManagement.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement.BUS
{
    class ProductsBUS
    {
        public static DataTable getProductsDataTable()
        {
            return ProductsDAL.getProductsDataTable();
        }

        public static void addProduct(Product Product)
        {
            ProductsDAL.addProduct(Product);
        }

        public static void editProduct(Product Product)
        {
            ProductsDAL.editProduct(Product);
        }

        public static void deleteProduct(int id)
        {
            ProductsDAL.deleteProduct(id);
        }

        public static void loadCombobox(int comboBoxId, ComboBox comboBox)
        {
            ProductsDAL.loadCombobox(comboBoxId, comboBox);
        }
    }
}
