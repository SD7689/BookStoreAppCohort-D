using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BookStoreRepositoryLayer
{
   public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> option) : base(option)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<CustomerAdress> Address { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
