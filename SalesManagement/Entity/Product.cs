using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Entity
{
    public class Product
    {
        private int id;
        private string name;
        private int supplierId;
        private int categoryId;
        private decimal input;
        private decimal output;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int SupplierId
        {
            get
            {
                return supplierId;
            }

            set
            {
                supplierId = value;
            }
        }

        public int CategoryId
        {
            get
            {
                return categoryId;
            }

            set
            {
                categoryId = value;
            }
        }

        public decimal Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
            }
        }

        public decimal Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        public Product(int id, string name, int supplierId, int categoryId, decimal input, decimal output)
        {
            this.Id = id;
            this.Name = name;
            this.SupplierId = supplierId;
            this.CategoryId = categoryId;
            this.Input = input;
            this.Output = output;
        }
    }
}
