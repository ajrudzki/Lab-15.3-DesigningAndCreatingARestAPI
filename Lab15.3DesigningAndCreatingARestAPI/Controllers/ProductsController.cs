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
    public class ProductsController : ControllerBase
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=DapperOverflow;user id=testuser;password=abc123");
        }
    }
}
