using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15._3DesigningAndCreatingARestAPI.Controllers
{
    public class Order_Details
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public static string DeleteOrder(int orderid)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");

            List<Order> orders = db.Query<Order>($"DELETE FROM [Order Details] WHERE OrderID = '{orderid}'").AsList();

            db.Delete(orders);

            return "Record has been Deleted";
        }
    }
}
