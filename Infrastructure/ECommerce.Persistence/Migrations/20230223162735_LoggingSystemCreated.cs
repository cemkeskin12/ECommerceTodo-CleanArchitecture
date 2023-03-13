using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LoggingSystemCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d154c22c-e471-4b9c-b812-f48a19368df5"));

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Progress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5dd823d2-cefb-4a33-9aca-4ddbca45c3d4"), "9ff93901-1c5d-4a8b-a7f7-3940a38541d8", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 846, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 23, 7, 53, 21, 775, DateTimeKind.Local).AddTicks(2301), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Rustic Soft Tuna", 89905.69m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 15, 45, 463, DateTimeKind.Local).AddTicks(3863), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Small Fresh Tuna", 39096.23m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 19, 21, 33, 36, 586, DateTimeKind.Local).AddTicks(7431), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", true, "Small Rubber Shirt", 92094.66m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 13, 21, 57, 35, 320, DateTimeKind.Local).AddTicks(4301), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Practical Wooden Soap", 18316.34m });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("2a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("3c684b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("4a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("5c324b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 23, 19, 27, 34, 850, DateTimeKind.Local).AddTicks(8115));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd823d2-cefb-4a33-9aca-4ddbca45c3d4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d154c22c-e471-4b9c-b812-f48a19368df5"), "28cffe51-cf0c-4910-96b9-6bfa0fbf6ac0", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 470, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 15, 13, 23, 43, 556, DateTimeKind.Local).AddTicks(9133), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Ergonomic Granite Tuna", 7943.78m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 9, 17, 25, 17, 371, DateTimeKind.Local).AddTicks(8378), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "Fantastic Concrete Towels", 61936.12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 10, 23, 31, 30, 800, DateTimeKind.Local).AddTicks(2985), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", false, "Sleek Granite Towels", 63556.37m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 12, 18, 0, 23, 98, DateTimeKind.Local).AddTicks(6832), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Gorgeous Frozen Gloves", 48571.41m });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("2a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("3c684b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("4a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("5c324b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 19, 15, 7, 54, 474, DateTimeKind.Local).AddTicks(5679));
        }
    }
}
