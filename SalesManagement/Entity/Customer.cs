using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Entity
{
    class Customer
    {
        int id;
        string name;
        string address;
        string phone;

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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public Customer(int id, string name, string address, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }
    }
}
