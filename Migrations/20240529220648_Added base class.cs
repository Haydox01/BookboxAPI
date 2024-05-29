using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookbox.Migrations
{
    /// <inheritdoc />
    public partial class Addedbaseclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6a845b75-8595-4073-8160-8e52118de055"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2232), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("96be4f0e-0880-40ad-a837-76e1cd73ab6e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2226), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2227) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a2bb4edf-0d1d-4ce9-bb8e-4eaf9ff55cda"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2216), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("af2dbcf9-721a-4184-9267-7d1a8a277174"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2237), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2238) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("211891b1-80d9-46ec-84cb-c0e89bcede5a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2295), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2296) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("24da42a7-ef1f-4a90-bc18-ad1adbeedd76"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2322), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2323) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("beba5dd7-504f-4edc-9e99-2ed8068dacf5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2331), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2332) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2311), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2312) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1555e61f-b2b7-4519-a7f4-93757881d682"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1854), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1855) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74fa4e60-3b0f-42db-bf16-35083dd4d108"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1860), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1861) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b10f6364-aebc-49ed-8ce5-343aed2b783d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1809), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1817) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1847), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(1848) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("030dc7da-1017-4042-9d69-bd645339d425"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2416), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("43d1b3c1-f27e-4b89-ad15-92de0f73507f"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2410), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2411) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("5dba7a38-a3bb-426c-8783-bd94e6f3ed91"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2396), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("db6d528f-24fb-4c71-b111-5c75f001028e"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2404), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2405) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("200b0e05-980f-468c-835b-55f0481d03ae"),
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2479), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2477), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4f6f9661-2468-4988-86a4-2bbdb8656a68"),
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2506), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2505), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("64f7e1df-0267-4426-ae90-a48871ae967b"),
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2515), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2515), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2516) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("6dd829f1-cc00-4581-b09b-e9ce5e14b656"),
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2493), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2492), new DateTime(2024, 5, 29, 22, 6, 46, 881, DateTimeKind.Utc).AddTicks(2494) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("211891b1-80d9-46ec-84cb-c0e89bcede5a"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1728), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1729) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("24da42a7-ef1f-4a90-bc18-ad1adbeedd76"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1891), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1891) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("beba5dd7-504f-4edc-9e99-2ed8068dacf5"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1899), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1899) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1879), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1880) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1555e61f-b2b7-4519-a7f4-93757881d682"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1292), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74fa4e60-3b0f-42db-bf16-35083dd4d108"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1296), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1297) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b10f6364-aebc-49ed-8ce5-343aed2b783d"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1255), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1262) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1287), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1288) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("200b0e05-980f-468c-835b-55f0481d03ae"),
                column: "OrderDate",
                value: new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("4f6f9661-2468-4988-86a4-2bbdb8656a68"),
                column: "OrderDate",
                value: new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("64f7e1df-0267-4426-ae90-a48871ae967b"),
                column: "OrderDate",
                value: new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("6dd829f1-cc00-4581-b09b-e9ce5e14b656"),
                column: "OrderDate",
                value: new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2041));
        }
    }
}
