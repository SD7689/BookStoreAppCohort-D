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

        public DbSet<Book> Book { get; set; }
        public DbSet<CustomerAdress> Address { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAdress>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
