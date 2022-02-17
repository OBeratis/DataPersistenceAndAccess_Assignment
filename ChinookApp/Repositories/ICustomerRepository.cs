using ChinookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookApp.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomer(string name);
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
    }
}
