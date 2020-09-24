using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab15._3DesigningAndCreatingARestAPI.Controllers
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public Decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }


        public static string DeleteOrder(int orderid)
        {
            IDbConnection db = new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");

            List<Order> orders = db.Query<Order>($"DELETE FROM Orders WHERE OrderID = '{orderid}'").AsList();

            db.Delete(orders);

            return "Record has been Deleted";
        }
    }
}
