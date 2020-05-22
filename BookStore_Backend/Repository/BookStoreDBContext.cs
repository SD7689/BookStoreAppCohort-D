using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Repository
{
   public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> option) : base(option)
        {

        }

        public DbSet<BookCL> Book { get; set; }
        public DbSet<CustomerCL> Address { get; set; }
        public DbSet<CartCL> Cart { get; set; }
        public DbSet<UserCL> Users { get; set; }
    }
}
