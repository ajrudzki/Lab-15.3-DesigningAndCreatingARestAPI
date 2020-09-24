using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab15._3DesigningAndCreatingARestAPI.Controllers
{
    [Route("Customers")]
    [ApiController]
    [Table("Customers")]
    public class CustomersController : ControllerBase
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");
        }

        [HttpGet]
        public List<Customer> AllCustomers()
        {
            List<Customer> customers = Connection().GetAll<Customer>().ToList();
            return customers;
        }

        [HttpGet("{country}")]
        public List<Customer> CustomerSearch(string country)
        {
            List<Customer> customers = Connection().Query<Customer>($"select ContactName, Country from Customers where Country like '%{country}%'").AsList();

            return customers;
        }

        [HttpPost("addcustomer")]
        [Consumes("application/json")]
        public string AddCustomer([FromBody] Customer newCust)
        {
            string CustomerID = Customer.Create(Connection(), newCust);
            return CustomerID;
        }
    }
}
