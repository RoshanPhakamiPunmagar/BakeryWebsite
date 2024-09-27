using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryWebsite.Migrations
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: initial.cs
     * Date: 27/09/2024
     * Purpose: Defines the initial migration for the BakeryWebsite application.
     *          This migration creates the Products table in the database,
     *          which holds information about the bakery products.
     *
     * ******************************************************
     */
    public partial class initial : Migration
    {
        // Method that defines the operations to apply when the migration is executed
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",  // Name of the table to create
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)  // Primary key column for the product ID
                        .Annotation("SqlServer:Identity", "1, 1"),  // Auto-incrementing identity column
                    Name = table.Column<string>(nullable: true),  // Column for product name
                    Price = table.Column<decimal>(type: "decimal(7, 2)", nullable: false),  // Column for product price with precision
                    Description = table.Column<string>(nullable: true),  // Column for product description
                    ImageUrl = table.Column<string>(nullable: true),  // Column for URL of product image
                    Category = table.Column<string>(nullable: true)  // Column for product category
                },
                constraints: table =>
                {
                    // Define the primary key for the Products table
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        // Method that defines the operations to revert the migration
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");  // Drop the Products table if this migration is reverted
        }
    }
}
