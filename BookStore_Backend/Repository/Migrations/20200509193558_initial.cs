﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
<<<<<<< HEAD:BookStore_Backend/Repository/Migrations/20200509193558_initial.cs
                    CustomerId = table.Column<int>(nullable: false),
=======
                    Email = table.Column<string>(nullable: false),
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a:BookStore_Backend/Repository/Migrations/20200511104325_initial.cs
                    FullName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Pincode = table.Column<int>(nullable: false),
                    Citytown = table.Column<string>(nullable: false),
                    Landmark = table.Column<string>(nullable: true),
                    AddressType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
<<<<<<< HEAD:BookStore_Backend/Repository/Migrations/20200509193558_initial.cs
                    table.PrimaryKey("PK_Address", x => x.CustomerId);
=======
                    table.PrimaryKey("PK_Address", x => x.Email);
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a:BookStore_Backend/Repository/Migrations/20200511104325_initial.cs
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookTitle = table.Column<string>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    BookImage = table.Column<string>(nullable: false),
                    BookPrice = table.Column<double>(nullable: false),
                    Availability = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    NumOfCopies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
