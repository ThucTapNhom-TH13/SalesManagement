using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Entity
{
    class OrderDetail
    {
        int orderId;
        int productId;
        decimal price;
        int quantity;
        decimal discount;

        public int OrderId
        {
            get
            {
                return orderId;
            }

            set
            {
                orderId = value;
            }
        }

        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public OrderDetail(int order, int product, decimal price, int quantity, decimal discount)
        {
            this.OrderId = order;
            this.ProductId = product;
            this.Price = price;
            this.Quantity = quantity;
            this.Discount = discount;
        }
    }
}
