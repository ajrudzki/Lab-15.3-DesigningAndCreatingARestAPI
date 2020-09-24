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
    public class Product
    {
        [Key]
        public long ProductID { get; set; }

        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }

        public static long Create(IDbConnection connection, Product newProd)
        {
            long id = connection.Insert<Product>(newProd);
            return id;
        }
    }
}
