using System;
using System.Collections.Generic;
using ChinookApp.Models;
using ChinookApp.Repositories;

namespace ChinookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new CustomerRepository();
            // ReadAllCustomers(repository);
            // ReadCustomerById(repository);
            ReadCostumerByName(repository);

        }

        static void ReadAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void ReadCustomerById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(7));
        }

        static void ReadCostumerByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer("Barne"));
        }

        static void InsertNewCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer();

            if (repository.AddNewCustomer(customer))
            {
                Console.WriteLine("Customer inserted successfully.");
            }
            else
            {
                Console.WriteLine("Error inserting customer!");
            }
        }

        static void UpdateExistingCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer();

            if (repository.UpdateCustomer(customer))
            {
                Console.WriteLine("Customer update successfully.");
            }
            else
            {
                Console.WriteLine("Error updating customer!");
            }
        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach( var customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email}");
        }
    }
}
