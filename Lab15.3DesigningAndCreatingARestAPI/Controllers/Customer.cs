using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab15._3DesigningAndCreatingARestAPI.Controllers
{
    public class Customer
    {
        [ExplicitKey]
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public static string Create(IDbConnection connection, Customer newCust)
        {
            string id = connection.Insert<Customer>(newCust).ToString();
            return id;
        }
    }
}
