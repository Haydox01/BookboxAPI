﻿using Bookbox.Data;
using Bookbox.MapperConfig;
using Bookbox.Models;
using Bookbox.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Bookbox.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookBoxDbContext context;
        private readonly MappingProfiles mappings;

        public BookRepository(BookBoxDbContext context, MappingProfiles mappings)
        {
            this.context = context;
            this.mappings = mappings;
        }
        public async Task<Book> AddBook(Book book)
        {

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> DeleteBook(Guid id)
        {
            var Book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (Book == null)
            {
                return null;
            }
            context.Books.Remove(Book);
            await context.SaveChangesAsync();
            return Book;

        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }
      

        public async Task<List<Book>> GetBooksByTitle(string title)
        {

            // Use LINQ to filter books by title (case-insensitive)
            var booksWithTitle = await context.Books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();

            return booksWithTitle;

        }

        public async Task<List<Book>> GetBooksByAuthorName(string authorName)
        {
            var booksByAuthor = await context.Books.Where(b => b.AuthorName.Contains(authorName, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
            return booksByAuthor;

        }

        public async Task<Book> UpdateBook(Guid id, Book book)
        {
            var Book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (Book == null)
            {
               /* return null;*/
                throw new ArgumentException("Book not found", nameof(book));
            }
           /* var existingAuthor = await context.Authors.FirstOrDefaultAsync(a => string.Equals(a.Name, book.AuthorName, StringComparison.OrdinalIgnoreCase));
            var existingCategory = await context.Categories.FirstOrDefaultAsync(c => string.Equals(c.Name, book.CategoryName, StringComparison.OrdinalIgnoreCase));

            if (existingAuthor == null || existingCategory == null)
            {
                throw new ArgumentException("Author or Category not found", nameof(book));
            }*/

            Book.Title = book.Title;
            Book.Price = book.Price;
            Book.ISBN = book.ISBN;
           /* Book.CategoryName = book.CategoryName;
            Book.AuthorName = book.AuthorName;*/
            await context.SaveChangesAsync();
            return Book;

           


        }
    }
}








     
        




