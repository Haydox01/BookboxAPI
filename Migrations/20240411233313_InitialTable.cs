using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookbox.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "Nationality" },
                values: new object[,]
                {
                    { new Guid("6a845b75-8595-4073-8160-8e52118de055"), "Yuval Noah", "Israeli" },
                    { new Guid("96be4f0e-0880-40ad-a837-76e1cd73ab6e"), "Stephen Hawking", "British" },
                    { new Guid("a2bb4edf-0d1d-4ce9-bb8e-4eaf9ff55cda"), "Chinua Achebe", "Nigerian" },
                    { new Guid("af2dbcf9-721a-4184-9267-7d1a8a277174"), "Robert C Martin", "American" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1555e61f-b2b7-4519-a7f4-93757881d682"), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1292), "Science books", "Science", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1293) },
                    { new Guid("74fa4e60-3b0f-42db-bf16-35083dd4d108"), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1296), "Programming books", "Programming", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1297) },
                    { new Guid("b10f6364-aebc-49ed-8ce5-343aed2b783d"), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1255), "Fiction books", "Fiction", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1262) },
                    { new Guid("c42fd143-0c1f-4e10-8fb2-b420ae179282"), new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1287), "History books", "History", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1288) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "ShippingAddress" },
                values: new object[,]
                {
                    { new Guid("030dc7da-1017-4042-9d69-bd645339d425"), "Kim", "Yun", "123 Main St, North Korea" },
                    { new Guid("43d1b3c1-f27e-4b89-ad15-92de0f73507f"), "Tunde", "Akinkunmi", "123 Main St, Ibadan" },
                    { new Guid("5dba7a38-a3bb-426c-8783-bd94e6f3ed91"), "John", "Doe", "123 Main St, Lagos" },
                    { new Guid("db6d528f-24fb-4c71-b111-5c75f001028e"), "Jane", "Smith", "123 Main St, UK" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "AuthorName", "CategoryId", "CategoryName", "CreatedAt", "ISBN", "Price", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("211891b1-80d9-46ec-84cb-c0e89bcede5a"), new Guid("a2bb4edf-0d1d-4ce9-bb8e-4eaf9ff55cda"), "Chinua Achebe", new Guid("b10f6364-aebc-49ed-8ce5-343aed2b783d"), "Fiction", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1728), "978-3-16-148410-0", 1000.0, "Things Fall Apart", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1729) },
                    { new Guid("24da42a7-ef1f-4a90-bc18-ad1adbeedd76"), new Guid("96be4f0e-0880-40ad-a837-76e1cd73ab6e"), "Stephen Hawking", new Guid("c42fd143-0c1f-4e10-8fb2-b420ae179282"), "History", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1891), "978-3-16-148410-2", 1500.0, "A Brief History of Time", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1891) },
                    { new Guid("beba5dd7-504f-4edc-9e99-2ed8068dacf5"), new Guid("af2dbcf9-721a-4184-9267-7d1a8a277174"), "Robert C Martin", new Guid("74fa4e60-3b0f-42db-bf16-35083dd4d108"), "Programming", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1899), "978-3-16-148410-3", 2000.0, "Clean Code", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1899) },
                    { new Guid("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"), new Guid("6a845b75-8595-4073-8160-8e52118de055"), "Yuval Noah", new Guid("1555e61f-b2b7-4519-a7f4-93757881d682"), "Science", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1879), "978-3-16-148410-1", 1200.0, "Sapiens", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(1880) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BookId", "CustomerId", "CustomerName", "OrderDate", "ShippingAddress", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("200b0e05-980f-468c-835b-55f0481d03ae"), new Guid("211891b1-80d9-46ec-84cb-c0e89bcede5a"), new Guid("5dba7a38-a3bb-426c-8783-bd94e6f3ed91"), "John Doe", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2029), "123 Main St, Lagos", 1000.0 },
                    { new Guid("4f6f9661-2468-4988-86a4-2bbdb8656a68"), new Guid("24da42a7-ef1f-4a90-bc18-ad1adbeedd76"), new Guid("43d1b3c1-f27e-4b89-ad15-92de0f73507f"), "Tunde Akinkunmi", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2048), "123 Main St, Ibadan", 1500.0 },
                    { new Guid("64f7e1df-0267-4426-ae90-a48871ae967b"), new Guid("beba5dd7-504f-4edc-9e99-2ed8068dacf5"), new Guid("030dc7da-1017-4042-9d69-bd645339d425"), "Kim Yun", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2055), "123 Main St, North Korea", 2000.0 },
                    { new Guid("6dd829f1-cc00-4581-b09b-e9ce5e14b656"), new Guid("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"), new Guid("db6d528f-24fb-4c71-b111-5c75f001028e"), "Jane Smith", new DateTime(2024, 4, 11, 23, 33, 11, 722, DateTimeKind.Utc).AddTicks(2041), "123 Main St, UK", 1200.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
