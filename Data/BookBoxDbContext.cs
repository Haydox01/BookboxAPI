using Bookbox.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
                    Id = Guid.NewGuid(),
                    Name = "Fiction",
                    Description = "Fiction books"
              },
              new Category
              {
                  Id = Guid.NewGuid(),
                  Name = "History",
                  Description = "History books"
              },
              new Category
              {
                  Id = Guid.NewGuid(),
                  Name = "Science",
                  Description = "Science books"
              },
              new Category
              {
                  Id = Guid.NewGuid(),
                  Name = "Technology",
                  Description = "Technology books"
              }
                                                                                       );

            modelBuilder.Entity<Author>().HasData(
              new Author
              {
                  Id = Guid.NewGuid(),
                  FirstName = "Chinua",
                  LastName = "Achebe",
              });
        }

    }
}
