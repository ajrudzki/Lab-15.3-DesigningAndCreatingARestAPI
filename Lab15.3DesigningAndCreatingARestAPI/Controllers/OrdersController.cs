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
    [Route("Orders")]
    [ApiController]
    [Table("Orders")]
    public class OrdersController : ControllerBase
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");
        }

        [HttpGet]
        public List<Order> AllOrders()
        {
            List<Order> orders = Connection().GetAll<Order>().ToList();
            return orders;
        }

        [HttpGet("{orderid}")]
        public List<Order> OrderSearch(string OrderID)
        {
            List<Order> orderInfo = Connection().Query<Order>($"select * from Orders where OrderID like '%{OrderID}%'").AsList();
            return orderInfo;
        }

        [HttpDelete("delete{OrderID}")]
        public static void Delete(int orderid)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");

            db.Delete(new Order { OrderID = orderid });
        }
    }
}
