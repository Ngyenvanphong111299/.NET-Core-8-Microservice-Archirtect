using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "This is Punjabi Samosa", "https://sukhis.com/wp-content/uploads/2019/07/Samosa-1.png", "Samosa", 15.0 },
                    { 2, "Entree", "This is Paneer Tikka Masala", "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg", "Paneer Tikka Masala", 13.99 },
                    { 3, "Dessert", "This is Sweet Pie", "https://www.196flavors.com/wp-content/uploads/2014/10/pithiviers-3-FP.jpg", "Sweet Pie", 10.99 },
                    { 4, "Appetizer", "This is Pav Bhaji", "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg", "Pav Bhaji", 15.0 },
                    { 5, "Entree", "This is Dosa", "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg", "Dosa", 22.989999999999998 },
                    { 6, "Dessert", "This is Gulab Jamun", "https://www.cookwithmanali.com/wp-content/uploads/2014/03/Paneer-Tikka-Masala-500x375.jpg", "Gulab Jamun", 10.99 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);
        }
    }
}
