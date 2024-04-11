﻿namespace Bookbox.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Double Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //nav Properties

        public Category Category { get; set; }
        public Author Author { get; set; }

    }
}
