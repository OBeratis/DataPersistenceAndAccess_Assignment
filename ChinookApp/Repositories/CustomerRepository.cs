using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using ChinookApp.Models;

namespace ChinookApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        // Customer requirements

        // 1.
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers;
        }

        // 2.
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        // 3.
        public Customer GetCustomer(string name)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer Where LastName like @LastName";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@LastName", $"%{name}%");

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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customer;
        }

        // 4.
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return customers.Skip(offset).Take(limit).ToList();
        }

        // 5.
        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "NSERT INTO Customer(FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId) " +
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        // 6.
        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer " +
                         "SET FirstName=@FirstName,LastName=@LastName,Company=@Company,Address=@Address,City=@City,State=@State" +
                         ",Country=@Country,PostalCode=@PostalCode,Phone=@Phone,Fax=@Fax,Email=@Email,SupportRepId=@SupportRepId";
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        // 7.
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countryCustomers;
        }

        // 8.
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return spenders;
        }

        // 9.
        public List<CustomerGenre> TopPopularGenre()
        {
            return new List<CustomerGenre>();
        }

    }
}
