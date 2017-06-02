using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Entity
{
    class Employee
    {
        private int id;
        private string name;
        private DateTime birth;
        private string address;
        private string phone;

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

        public DateTime Birth
        {
            get
            {
                return birth;
            }

            set
            {
                birth = value;
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

        public Employee(int id, string name, DateTime birth, string address, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Birth = birth;
            this.Address = address;
            this.Phone = phone;
        }
    }
}
