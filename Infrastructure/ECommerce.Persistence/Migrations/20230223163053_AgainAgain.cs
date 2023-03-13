using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgainAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dd823d2-cefb-4a33-9aca-4ddbca45c3d4"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Subcategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Subcategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Ratings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Ratings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "AttributeValues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AttributeValues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Attributes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Attributes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ec62d9c6-6dbc-418d-852c-5a7e0da3e4bf"), "30cc472d-2346-4518-bc2e-7111ee1690c1", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 350, DateTimeKind.Local).AddTicks(9788), null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(6326), null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(6321), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "DeletedDate", "Description", "Name", "Price", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 22, 19, 18, 37, 891, DateTimeKind.Local).AddTicks(5721), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Generic Metal Table", 59582.57m, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "DeletedDate", "Description", "IsDeleted", "Name", "Price", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 18, 22, 27, 9, 553, DateTimeKind.Local).AddTicks(901), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, "Fantastic Soft Table", 80135.02m, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "DeletedDate", "Description", "IsDeleted", "Name", "Price", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 14, 4, 7, 5, 428, DateTimeKind.Local).AddTicks(5415), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", false, "Ergonomic Plastic Shoes", 50179.91m, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8266bac2-053f-4aca-8fba-23193d018422"),
                columns: new[] { "CreatedDate", "DeletedDate", "Description", "Name", "Price", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 16, 7, 23, 45, 637, DateTimeKind.Local).AddTicks(9159), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Licensed Soft Keyboard", 28537.42m, null });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("2a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(7546), null, null });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("3c684b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(7539), null, null });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("4a674b75-a3e9-45eb-8dc5-65acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(7549), null, null });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("5c324b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(7532), null, null });

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: new Guid("7c674b75-a3e9-45eb-8dc5-64acb9bc1a69"),
                columns: new[] { "CreatedDate", "DeletedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 2, 23, 19, 30, 53, 356, DateTimeKind.Local).AddTicks(7536), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec62d9c6-6dbc-418d-852c-5a7e0da3e4bf"));

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Attributes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Attributes");

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
                columns: new[] { "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[] { new DateTime(2023, 2, 16, 16, 15, 45, 463, DateTimeKind.Local).AddTicks(3863), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", true, "Small Fresh Tuna", 39096.23m });

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
    }
}
