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
                     AuthorId = Guid.Parse("a2bb4edf-0d1d-4ce9-bb8e-4eaf9ff55cda"),
                     CategoryId = Guid.Parse("b10f6364-aebc-49ed-8ce5-343aed2b783d"),
                     CategoryName = "Fiction",
                     Price = 1000,
                     ISBN = "978-3-16-148410-0"
                },
                new Book
                {
                    Id = Guid.Parse("c63b1c62-5ece-4aa8-b4ff-97dcf2908d9b"),
                    Title = "Sapiens",
                    AuthorId = Guid.Parse("i42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CategoryId = Guid.Parse("1555e61f-b2b7-4519-a7f4-93757881d682"),
                    CategoryName = "Science",
                    Price = 1200,
                    ISBN = "978-3-16-148410-1"
                },
                new Book
                {
                    Id = Guid.Parse("i32fd143-0c1f-4e10-8fb2-b420ae179274"),
                    Title = "A Brief History of Time",
                    AuthorId = Guid.Parse("g42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CategoryId = Guid.Parse("b42fd143-0c1f-4e10-8fb2-b420ae179283"),
                    CategoryName = "History",
                    Price = 1500,
                    ISBN = "978-3-16-148410-2"
                },
                new Book
                {
                    Id = Guid.Parse("j32fd143-0c1f-4e10-8fb2-b420ae179274"),
                    Title = "Clean Code",
                    AuthorId = Guid.Parse("j42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CategoryId = Guid.Parse("e42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CategoryName = "Programming",
                    Price = 2000,
                    ISBN = "978-3-16-148410-3"
                }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = Guid.Parse("a42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    FirstName = "John",
                    LastName = "Doe",
                    ShippingAddress = "123 Main St, Lagos"
                },
                new Customer
                {
                    Id = Guid.Parse("b42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    FirstName = "Jane",
                    LastName = "Smith",
                    ShippingAddress = "123 Main St, UK"
                },
                new Customer
                    {
                    Id = Guid.Parse("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    FirstName = "Tunde",
                    LastName = "Akinkunmi",
                    ShippingAddress = "123 Main St, Ibadan"
                },
                new Customer
                {
                    Id = Guid.Parse("d42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    FirstName = "Kim",
                    LastName = "Yun",
                    ShippingAddress = "123 Main St, North Korea"
                }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.Parse("a42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerId = Guid.Parse("a42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerName = "John Doe",
                    ShippingAddress = "123 Main St, Lagos",
                    BookId = Guid.Parse("g32fd143-0c1f-4e10-8fb2-b420ae179274"),
                    TotalAmount = 1000
                },
                new Order
                {
                    Id = Guid.Parse("b42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerId = Guid.Parse("b42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerName = "Jane Smith",
                    ShippingAddress = "123 Main St, UK",
                    BookId = Guid.Parse("h32fd143-0c1f-4e10-8fb2-b420ae179274"),
                    TotalAmount = 1200
                },
                new Order
                {
                    Id = Guid.Parse("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerId = Guid.Parse("c42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerName = "Tunde Akinkunmi",
                    ShippingAddress = "123 Main St, Ibadan",
                    BookId = Guid.Parse("i32fd143-0c1f-4e10-8fb2-b420ae179274"),
                    TotalAmount = 1500
                },
                new Order
                {
                    Id = Guid.Parse("d42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerId = Guid.Parse("d42fd143-0c1f-4e10-8fb2-b420ae179282"),
                    CustomerName = "Kim Yun",
                    ShippingAddress = "123 Main St, North Korea",
                    BookId = Guid.Parse("j32fd143-0c1f-4e10-8fb2-b420ae179274"),
                    TotalAmount = 2000
                });
            
                


        }
       
                                                                            



           

    }
}
