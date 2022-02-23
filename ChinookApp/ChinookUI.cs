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
        // ICustomerRepository _dataStorage = new CustomerRepository();
        SqlClientCustomerHelper _dataStorage = new SqlClientCustomerHelper();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customerRepository"></param>
        public ChinookUI(SqlClientCustomerHelper customerRepository)
        {
            _dataStorage = customerRepository;   
        }

        /// <summary>
        /// Start the ChinookApp with a simple console menu
        /// Exit with 0
        /// </summary>
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
	6) Update an existing customer (e.g. Customer ID=20, change Fax for costumer)
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


        /// <summary>
        /// Read and display all customers on console
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void ReadAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        /// <summary>
        /// Read and display customer find Id
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void ReadCustomerById(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer(7));
        }

        /// <summary>
        /// Read and display customer find by partial name 
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void ReadCostumerByName(ICustomerRepository repository)
        {
            PrintCustomer(repository.GetCustomer("Barne"));
        }

        /// <summary>
        /// Get page of 10 customers and display on console
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void GetPageOfCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetPageOfCustomers(5, 10));
        }

        /// <summary>
        ///  Insert a new customer into chinook database and return success message.
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void InsertNewCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer();
            customer.FirstName = "Hazel";
            customer.LastName = "Zhang";
            customer.Company = "OneLogin";
            customer.Address = "Main Rd";
            customer.City = "Greenville";
            customer.State = "SC";
            customer.Country = "USA";
            customer.PostalCode = "12345";
            customer.Phone = "";
            customer.Fax = "";
            customer.Email = "hazel.zhang@onelogin.com";
            customer.SupportRepId = 6;

            if (repository.AddNewCustomer(customer))
            {
                Console.WriteLine("Customer inserted successfully.");
            }
            else
            {
                Console.WriteLine("Error inserting customer!");
            }
        }

        /// <summary>
        /// Update a existing customer and return success message
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void UpdateExistingCustomer(ICustomerRepository repository)
        {
            Customer customer = new Customer();
            customer.CustomerId = 20;
            customer.Fax = "+1 (650) 644-3359";

            if (repository.UpdateCustomer(customer))
            {
                Console.WriteLine("Customer update successfully.");
            }
            else
            {
                Console.WriteLine("Error updating customer!");
            }
        }

        /// <summary>
        /// Get and display the count of all customers on each country
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void GetCustomerCountries(ICustomerRepository repository)
        {
            PrintCustomersCountry(repository.GetCustomerCountries());
        }

        /// <summary>
        /// Get and display the highest spenders 
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void GetTopSpenders(ICustomerRepository repository)
        {
            PrintTopSpenders(repository.TopSpenders());
        }

        /// <summary>
        /// Get and display customer genre, choose which customer do you want to display 
        /// </summary>
        /// <param name="repository">Interact with chinook database</param>
        private void GetMostCustomerGenre(ICustomerRepository repository)
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

        #region Display Helpers
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
        #endregion

    }

}
