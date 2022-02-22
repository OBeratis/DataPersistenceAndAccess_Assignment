using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChinookApp.Helpers;
using ChinookApp.Models;
using ChinookApp.Repositories;

namespace ChinookApp
{
    public  class ChinookUI
    {
        SqlClientCustomerHelper _dataStorage = new SqlClientCustomerHelper();

        public ChinookUI(SqlClientCustomerHelper sqlClientCustomerHelper)
        {
            _dataStorage = sqlClientCustomerHelper;   
        }

        public void Start()
        {
            string downloadMenu = @"
	┌──────────────────────────────────────────────────────────┐
	│   Assignment 6 - Create a database and access it         │
	└──────────────────────────────────────────────────────────┘

	  Please select an option from the choices below.

	1) Read all customers
	2) Read customer by ID (e.g. Customer ID=7)
	3) Read customer by Name (Note: Also search by partial Name possible, e.g. Customername='Barne')
	4) Get page of customer (e.g. Start offset 5 and take 10 customers)
	5) Add a new customer
	6) Update an existing customer
	7) Get number of customers in each country
	8) Get top spenders
	9) Get customer genre (e.g. enter customer id=1-59)

	0) Exit

Select an option.. [0-9]?";

            string choice = "";
            int choiceId = 0;
            bool exitChoice = false;

            do
            {
                Console.Clear();
                Console.WriteLine(downloadMenu);
                choice = Console.ReadLine();
                if (!string.IsNullOrEmpty(choice) && Int32.TryParse(choice, out choiceId))
                {
                    switch (choiceId)
                    {
                        case 0:
                            exitChoice = true;
                            break;
                        case 1:
                            ReadAllCustomers(_dataStorage);
                            break;
                        case 2:
                            ReadCustomerById(_dataStorage);
                            break;
                        case 3:
                            ReadCostumerByName(_dataStorage);
                            break;
                        case 4:
                            GetPageOfCustomers(_dataStorage);
                            break;
                        case 5:
                            InsertNewCustomer(_dataStorage);
                            break;
                        case 6:
                            UpdateExistingCustomer(_dataStorage);
                            break;
                        case 7:
                            GetCustomerCountries(_dataStorage);
                            break;
                        case 8:
                            GetTopSpenders(_dataStorage);
                            break;
                        case 9:
                            GetMostCustomerGenre(_dataStorage);
                            break;
                        default:
                            break;
                    }

                    if (choiceId > 0 && choiceId <= 9)
                    {
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
            }
            while (exitChoice == false);
        }

        private void ReadAllCustomers(SqlClientCustomerHelper repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        private void ReadCustomerById(SqlClientCustomerHelper repository)
        {
            PrintCustomer(repository.GetCustomer(7));
        }

        private void ReadCostumerByName(SqlClientCustomerHelper repository)
        {
            PrintCustomer(repository.GetCustomer("Barne"));
        }

        private void GetPageOfCustomers(SqlClientCustomerHelper repository)
        {
            PrintCustomers(repository.GetPageOfCustomers(5, 10));
        }

        private void InsertNewCustomer(SqlClientCustomerHelper repository)
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

        private void UpdateExistingCustomer(SqlClientCustomerHelper repository)
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

        private void GetCustomerCountries(SqlClientCustomerHelper repository)
        {
            PrintCustomersCountry(repository.GetCustomerCountries());
        }

        private void GetTopSpenders(SqlClientCustomerHelper repository)
        {
            PrintTopSpenders(repository.TopSpenders());
        }

        private void GetMostCustomerGenre(SqlClientCustomerHelper repository)
        {
            string choice = "";
            int choiceId = 0;
            bool validChoice = false;

            Console.WriteLine("--- Get customer most popular genre ---");

            // Start
            do
            {
                // Prompt for a choice
                Console.WriteLine("Please choice a customer by id between 1 and 59");
                choice = Console.ReadLine();

                if (!string.IsNullOrEmpty(choice) && Int32.TryParse(choice, out choiceId))
                {
                    if (choiceId >= 1 && choiceId < 60)
                    {
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Plase make sure you enter a valid id between 1 and 59");
                    }
                }
            } while (validChoice == false);

            PrintCustomerGenre(repository.TopPopularGenre(choiceId));

        }

        private void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        private void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email}");
        }

        private void PrintCustomersCountry(IEnumerable<CustomerCountry> countryCustomers)
        {
            foreach (var customer in countryCustomers)
            {
                Console.WriteLine($"{customer.Country} {customer.Count}");
            }
        }

        private void PrintTopSpenders(IEnumerable<CustomerSpender> topSpenders)
        {
            foreach (var spender in topSpenders)
            {
                Console.WriteLine($"{spender.CustomerId} {spender.LastName} {spender.Total}");
            }
        }

        private void PrintCustomerGenre(CustomerGenre customerGenre)
        {
            Console.WriteLine($"{customerGenre.CustomerId} {customerGenre.LastName} {customerGenre.LastName} --> {customerGenre.GenreName}");
        }

    }

}
