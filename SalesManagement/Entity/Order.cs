using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Entity
{
    class Order
    {
        private int id;
        private int customerId;
        private int employeeId;
        private DateTime date;

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

        public int CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
            }
        }

        public int EmployeeId
        {
            get
            {
                return employeeId;
            }

            set
            {
                employeeId = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public Order(int id, int customerId, int employeeId, DateTime date)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.EmployeeId = employeeId;
            this.Date = date;
        }
    }
}
