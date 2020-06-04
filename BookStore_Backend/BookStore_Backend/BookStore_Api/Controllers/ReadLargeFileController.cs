using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace BookStoreWeb_Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReadLargeFileController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public ReadLargeFileController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [Route("ReadFile")]
        [HttpGet]
        public IEnumerable<BookCL> GetAllBook()
        {
            List<BookCL> Books = new List<BookCL>();
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
                        Books.Add(new BookCL
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