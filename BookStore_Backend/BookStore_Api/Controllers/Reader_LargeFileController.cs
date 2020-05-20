using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace BookStore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reader_LargeFileController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public Reader_LargeFileController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("ReadFile")]
        [HttpGet]
        public IEnumerable<Book> GetAllBook()
        {
            List<Book> Books = new List<Book>();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Configuration.GetConnectionString("UserDbConnection");
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from Book";
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Books.Add(new Book
                        {
                            BookID = Convert.ToInt32(rd["BookID"]),
                            BookTitle = rd["BookTitle"].ToString(),
                            AuthorName = rd["AuthorName"].ToString(),
                            BookImage = rd["BookImage"].ToString(),
                            BookPrice = Convert.ToInt32(rd["BookPrice"]),
                            Description = rd["BookPrice"].ToString(),
                            Availability = Convert.ToInt32(rd["Availability"])
                        });

                    }
                }
                con.Close();
            }
            return Books;
        }

    }
}