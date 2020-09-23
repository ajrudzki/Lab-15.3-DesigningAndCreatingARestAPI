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
    [Route("Products")]
    [ApiController]
    [Table("Products")]
    public class ProductsController : ControllerBase
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");
        }

        [HttpGet]
        public List<Product> AllProducts()
        {
            List<Product> products = Connection().GetAll<Product>().ToList();
            return products;
        }

        [HttpGet("{ProductName}")]
        public List<Product> Products(string productName)
        {
            List<Product> products = Connection().Query<Product>($"select * from Products where ProductName like '%{productName}%'").ToList<Product>();
            return products;
        }

        [HttpPost("addproduct")]
        public Product AddProduct(string productName, int supplierID, int categoryID, string quantityPerUnit, Decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, int discontinued)
        {
            Product prod = new Product() { ProductName = productName, SupplierID = supplierID, CategoryID = categoryID, QuantityPerUnit = quantityPerUnit, UnitPrice = unitPrice, UnitsInStock = unitsInStock, UnitsOnOrder = unitsOnOrder, ReorderLevel = reorderLevel, Discontinued = discontinued };
            Connection().Insert<Product>(prod);
            return prod;
        }
    }
}
