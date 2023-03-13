using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleUserSeedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 9, 17, 25, 17, 371, DateTimeKind.Local).AddTicks(8378), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", true, "Fantastic Concrete Towels", 61936.12m });

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
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 12, 18, 0, 23, 98, DateTimeKind.Local).AddTicks(6832), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", true, "Gorgeous Frozen Gloves", 48571.41m });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d154c22c-e471-4b9c-b812-f48a19368df5"));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 610, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 11, 13, 19, 9, 217, DateTimeKind.Local).AddTicks(2736), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "Tasty Fresh Car", 47606.56m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 17, 1, 9, 48, 844, DateTimeKind.Local).AddTicks(4629), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, "Intelligent Soft Shoes", 28762.31m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 11, 17, 59, 51, 354, DateTimeKind.Local).AddTicks(7959), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", true, "Awesome Cotton Shoes", 80547.02m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 12, 11, 27, 13, 313, DateTimeKind.Local).AddTicks(2492), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, "Licensed Concrete Mouse", 95092.63m });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("2a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("3c684b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("4a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("5c324b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 18, 19, 24, 58, 621, DateTimeKind.Local).AddTicks(4551));
        }
    }
}
