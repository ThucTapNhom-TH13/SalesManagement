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
    class CategoriesBUS
    {
        public static DataTable getCategoriesDataTable()
        {
            return CategoriesDAL.getCategoriesDataTable();
        }

        public static void addCategory(Category Category)
        {
            CategoriesDAL.addCategory(Category);
        }

        public static void editCategory(Category Category)
        {
            CategoriesDAL.editCategory(Category);
        }

        public static void deleteCategory(int id)
        {
            CategoriesDAL.deleteCategory(id);
        }

    }
}
