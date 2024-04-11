using Bookbox.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

namespace Bookbox.Data
{
    public class BookBoxDbContext : DbContext
    {
    public BookBoxDbContext(DbContextOptions<BookBoxDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse ("b10f6364-aebc-49ed-8ce5-343aed2b783d"),
                    Name = "Fiction",
                    Description = "Fiction books"
                },
                new Category
                {
                    Id = Guid.Parse("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    Name = "History",
                    Description = "History books"
                },
                new Category
                {
                    Id = Guid.Parse("1555e61f-b2b7-4519-a7f4-93757881d682"),
                    Name = "Science",
                    Description = "Science books"
                },
                new Category
                {
                    Id = Guid.Parse("74fa4e60-3b0f-42db-bf16-35083dd4d108"),
                    Name = "Programming",
                    Description = "Programming books"
                }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.Parse("a2bb4edf-0d1d-4ce9-bb8e-4eaf9ff55cda"),
                    Name = "Chinua Achebe",
                    Nationality = "Nigerian"
                    
                },
                new Author
                {
                    Id = Guid.Parse("96be4f0e-0880-40ad-a837-76e1cd73ab6e"),
                    Name = "Stephen Hawking",
                    Nationality = "British"
                   
                },
                new Author
                {
                    Id = Guid.Parse("6a845b75-8595-4073-8160-8e52118de055"),
                    Name = "Yuval Noah",
                    Nationality = "Israeli"
                 
                },
                new Author
                {
                    Id = Guid.Parse("af2dbcf9-721a-4184-9267-7d1a8a277174"),
                    Name = "Robert C Martin",
                    Nationality = "American"
                    
                }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book 
                { 
                     Id = Guid.Parse("211891b1-80d9-46ec-84cb-c0e89bcede5a"),
                     Title = "Things Fall Apart",
                     AuthorName = "Chinua Achebe",
                     CategoryId = Guid.Parse("b10f6364-aebc-49ed-8ce5-343aed2b783d"),
                     CategoryName = "Fiction",
                     Price = 1000,
                     ISBN = "978-3-16-148410-0"
                },
                new Book
                {
                    Id = Guid.Parse("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"),
                    Title = "Sapiens",
                    AuthorName = "Yuval Noah",
                    CategoryId = Guid.Parse("1555e61f-b2b7-4519-a7f4-93757881d682"),
                    CategoryName = "Science",
                    Price = 1200,
                    ISBN = "978-3-16-148410-1"
                },
                new Book
                {
                    Id = Guid.Parse("24da42a7-ef1f-4a90-bc18-ad1adbeedd76"),
                    Title = "A Brief History of Time",
                    AuthorName = "Stephen Hawking",
                    CategoryId = Guid.Parse("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CategoryName = "History",
                    Price = 1500,
                    ISBN = "978-3-16-148410-2"
                },
                new Book
                {
                    Id = Guid.Parse("beba5dd7-504f-4edc-9e99-2ed8068dacf5"),
                    Title = "Clean Code",
                    AuthorName = "Robert C Martin",
                    CategoryId = Guid.Parse("74fa4e60-3b0f-42db-bf16-35083dd4d108"),
                    CategoryName = "Programming",
                    Price = 2000,
                    ISBN = "978-3-16-148410-3"
                }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = Guid.Parse("5dba7a38-a3bb-426c-8783-bd94e6f3ed91"),
                    FirstName = "John",
                    LastName = "Doe",
                    ShippingAddress = "123 Main St, Lagos"
                },
                new Customer
                {
                    Id = Guid.Parse("db6d528f-24fb-4c71-b111-5c75f001028e"),
                    FirstName = "Jane",
                    LastName = "Smith",
                    ShippingAddress = "123 Main St, UK"
                },
                new Customer
                    {
                    Id = Guid.Parse("43d1b3c1-f27e-4b89-ad15-92de0f73507f"),
                    FirstName = "Tunde",
                    LastName = "Akinkunmi",
                    ShippingAddress = "123 Main St, Ibadan"
                },
                new Customer
                {
                    Id = Guid.Parse("030dc7da-1017-4042-9d69-bd645339d425"),
                    FirstName = "Kim",
                    LastName = "Yun",
                    ShippingAddress = "123 Main St, North Korea"
                }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.Parse("200b0e05-980f-468c-835b-55f0481d03ae"),
                    CustomerId = Guid.Parse("5dba7a38-a3bb-426c-8783-bd94e6f3ed91"),
                    CustomerName = "John Doe",
                    ShippingAddress = "123 Main St, Lagos",
                    BookId = Guid.Parse("211891b1-80d9-46ec-84cb-c0e89bcede5a"),
                    TotalAmount = 1000
                },
                new Order
                {
                    Id = Guid.Parse("6dd829f1-cc00-4581-b09b-e9ce5e14b656"),
                    CustomerId = Guid.Parse("db6d528f-24fb-4c71-b111-5c75f001028e"),
                    CustomerName = "Jane Smith",
                    ShippingAddress = "123 Main St, UK",
                    BookId = Guid.Parse("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"),
                    TotalAmount = 1200
                },
                new Order
                {
                    Id = Guid.Parse("4f6f9661-2468-4988-86a4-2bbdb8656a68"),
                    CustomerId = Guid.Parse("43d1b3c1-f27e-4b89-ad15-92de0f73507f"),
                    CustomerName = "Tunde Akinkunmi",
                    ShippingAddress = "123 Main St, Ibadan",
                    BookId = Guid.Parse("24da42a7-ef1f-4a90-bc18-ad1adbeedd76"),
                    TotalAmount = 1500
                },
                new Order
                {
                    Id = Guid.Parse("64f7e1df-0267-4426-ae90-a48871ae967b"),
                    CustomerId = Guid.Parse("030dc7da-1017-4042-9d69-bd645339d425"),
                    CustomerName = "Kim Yun",
                    ShippingAddress = "123 Main St, North Korea",
                    BookId = Guid.Parse("beba5dd7-504f-4edc-9e99-2ed8068dacf5"),
                    TotalAmount = 2000
                });
            
                


        }
       
                                                                            



           

    }
}
