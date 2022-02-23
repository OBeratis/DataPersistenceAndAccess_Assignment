using ChinookApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ChinookApp.Models;

namespace ChinookApp.Helpers
{
    public class SqlClientCustomerHelper : ICustomerRepository
    {
        // Customer requirements

        /// <summary>
        /// 1. Read all Customers from database
        /// </summary>
        /// <returns>List of each customer details</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                                customer.Phone = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                                customer.Email = (!reader.IsDBNull(6) ? reader.GetString(6) : "");

                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }

        /// <summary>
        /// 2. Read a specific customer from database
        /// </summary>
        /// <param name="id">Customers unique id</param>
        /// <returns>Customer details as a class object</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer Where CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                                customer.Phone = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                                customer.Email = (!reader.IsDBNull(6) ? reader.GetString(6) : "");
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        /// <summary>
        /// 3. Read a specific customer from database
        /// </summary>
        /// <param name="lastname">Customers last name or first partial of a customers name</param>
        /// <returns>Customer details as a class object</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public Customer GetCustomer(string lastname)
        {
            Customer customer = new Customer();
            string sql = "SELECT TOP 1 CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer Where LastName like @LastName";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@LastName", $"%{lastname}%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                                customer.Phone = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                                customer.Email = (!reader.IsDBNull(6) ? reader.GetString(6) : "");
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        /// <summary>
        /// 4. Get a page of customers from the database
        /// </summary>
        /// <param name="offset">Beginning of the subset from the customer list</param>
        /// <param name="limit">Limit the customer list to this count</param>
        /// <returns>List of customer details</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public List<Customer> GetPageOfCustomers(int offset, int limit)
        {
            List<Customer> customers = new List<Customer>();
            // string sql = "SELECT * FROM Customer AS Page SKIP (@Offset) LIMIT(@limit)";
            string sql = "SELECT * FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        cmd.Parameters.AddWithValue("@limit", limit);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = (!reader.IsDBNull(1) ? reader.GetString(1) : "");
                                customer.LastName = (!reader.IsDBNull(2) ? reader.GetString(2) : "");
                                customer.Country = (!reader.IsDBNull(3) ? reader.GetString(3) : "");
                                customer.PostalCode = (!reader.IsDBNull(4) ? reader.GetString(4) : "");
                                customer.Phone = (!reader.IsDBNull(5) ? reader.GetString(5) : "");
                                customer.Email = (!reader.IsDBNull(6) ? reader.GetString(6) : "");

                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers.Skip(offset).Take(limit).ToList();
        }

        /// <summary>
        /// 5. Add a new customer to the database
        /// </summary>
        /// <param name="customer">Customer object with all details</param>
        /// <returns>True if customer was inserted successfully</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer (FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId) " +
                            "VALUES(@FirstName,@LastName,@Company,@Address,@City,@State,@Country,@PostalCode,@Phone,@Fax,@Email,@SupportRepId)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Company", customer.Company);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@City", customer.City);
                        cmd.Parameters.AddWithValue("@State", customer.State);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Fax", customer.Fax);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@SupportRepId", customer.SupportRepId);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        /// <summary>
        /// 6. Update an existing customer 
        /// </summary>
        /// <param name="customer">Customer object with all customer details</param>
        /// <returns>True if updating was successfully</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            /*
            string sql = "UPDATE Customer " +
                         "SET FirstName=@FirstName,LastName=@LastName,Company=@Company,Address=@Address,City=@City,State=@State" +
                         ",Country=@Country,PostalCode=@PostalCode,Phone=@Phone,Fax=@Fax,Email=@Email,SupportRepId=@SupportRepId " +
                         "WHERE CustomerId = @CustomerId";
            */
            string sql = "UPDATE Customer SET Fax=@Fax WHERE CustomerId = @CustomerId";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        // cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        // cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        // cmd.Parameters.AddWithValue("@Company", customer.Company);
                        // cmd.Parameters.AddWithValue("@Address", customer.Address);
                        //cmd.Parameters.AddWithValue("@City", customer.City);
                        //cmd.Parameters.AddWithValue("@State", customer.State);
                        //cmd.Parameters.AddWithValue("@Country", customer.Country);
                        //cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        //cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Fax", customer.Fax);
                        //cmd.Parameters.AddWithValue("@Email", customer.Email);
                        //cmd.Parameters.AddWithValue("@SupportRepId", customer.SupportRepId);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        /// <summary>
        /// 7. Get a list of customers on each country
        /// </summary>
        /// <returns>List of countries with country name and count of customers</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public List<CustomerCountry> GetCustomerCountries()
        {
            List<CustomerCountry> countryCustomers = new List<CustomerCountry>();
            string sql = "SELECT DISTINCT COUNTRY, COUNT(*) AS 'Count' FROM CUSTOMER GROUP BY COUNTRY ORDER BY 2 DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry customerCountry = new CustomerCountry();
                                customerCountry.Country = reader.GetString(0);
                                customerCountry.Count = reader.GetInt32(1);

                                countryCustomers.Add(customerCountry);
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countryCustomers;
        }

        /// <summary>
        /// 8. Return a list of all customers who are the highest spenders
        /// </summary>
        /// <returns>List of customers id, Lastname and total invoices</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public List<CustomerSpender> TopSpenders()
        {
            List<CustomerSpender> spenders = new List<CustomerSpender>();
            string sql = "SELECT CUSTOMER.CustomerId, CUSTOMER.LastName, INVOICE.Total FROM INVOICE" +
                         "   INNER JOIN CUSTOMER ON INVOICE.CustomerId = CUSTOMER.CustomerId" +
                         "   ORDER BY INVOICE.Total DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.CustomerId = reader.GetInt32(0);
                                customerSpender.LastName = reader.GetString(1);
                                customerSpender.Total = reader.GetDecimal(2);

                                spenders.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return spenders;
        }

        /// <summary>
        /// 9. Get the most popular genre of a given customer
        /// </summary>
        /// <param name="customerId">Customers id</param>
        /// <returns>Customer database unique Id, Firstname, Lastname and genre</returns>
        /// <exception cref="SqlException">In case of could not stablish a connection to sql server or other interaction with the database</exception>
        /// <exception cref="Exception">All other errors on this method display error message on console</exception>
        public CustomerGenre TopPopularGenre(int customerId)
        {
            CustomerGenre customerGenre = new CustomerGenre();

            string sql = "WITH                                                          " +
            "    Invoice_CTE (InvoiceId, CustomerId, Total) AS (                        " +
            "        SELECT TOP 1 InvoiceId, CustomerId, Total  FROM Invoice            " +
            "        WHERE CustomerId=@CustomerId                                       " +
            "        ORDER BY Total DESC                                                " +
            "    )                                                                      " +
            "select TOP 1 Customer.CustomerId, Customer.FirstName,                      " +
            "        Customer.LastName, Genre.Name from InvoiceLine                     " +
            "inner join Invoice_CTE ON Invoice_CTE.InvoiceId=InvoiceLine.InvoiceId      " +
            "inner join Customer ON Customer.CustomerId=Invoice_CTE.CustomerId          " +
            "inner join Track ON Track.TrackId=InvoiceLine.TrackId                      " +
            "inner join Genre ON Genre.GenreId=Track.GenreId                            " +
            "ORDER BY Track.Bytes DESC                                                  ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerGenre.CustomerId = reader.GetInt32(0);
                                customerGenre.FirstName = reader.GetString(1);
                                customerGenre.LastName = reader.GetString(2);
                                customerGenre.GenreName = reader.GetString(3);
                            }
                        }
                    }
                }
            }
            catch (SqlException exsql)
            {
                Console.WriteLine(exsql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customerGenre;
        }

    }
}
