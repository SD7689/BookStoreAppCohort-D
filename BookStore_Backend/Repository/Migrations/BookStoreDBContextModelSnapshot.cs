﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(BookStoreDBContext))]
    partial class BookStoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .IsRequired();

                    b.Property<bool>("Availability");

                    b.Property<string>("BookImage")
                        .IsRequired();

                    b.Property<double>("BookPrice");

                    b.Property<string>("BookTitle")
                        .IsRequired();

                    b.HasKey("BookID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Model.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("NumOfCopies");

                    b.HasKey("CartID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Model.CustomerAdress", b =>
                {
<<<<<<< HEAD
                    b.Property<int>("CustomerId");
=======
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("AddressType");

                    b.Property<string>("Citytown")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Landmark");

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Pincode");

<<<<<<< HEAD
                    b.HasKey("CustomerId");
=======
                    b.HasKey("Email");
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Email");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
