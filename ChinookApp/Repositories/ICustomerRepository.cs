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
        public List<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);
        public Customer GetCustomer(string name);
        public List<Customer> GetPageOfCustomers(int limit, int offset);
        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public List<CustomerCountry> GetCustomerCountries();
        public List<CustomerSpender> TopSpenders();
        public CustomerGenre TopPopularGenre(int id);
    }
}
