using System;
using System.Collections.Generic;
using ChinookApp.Helpers;
using ChinookApp.Models;
using ChinookApp.Repositories;

namespace ChinookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlClientCustomerHelper dbDataStore = new SqlClientCustomerHelper();

            ChinookUI chinookUI = new ChinookUI(dbDataStore);
            chinookUI.Start();
        }
    }
}
