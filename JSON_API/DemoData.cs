using JSON_API.Models;
using System;
using System.Collections.Generic;

namespace JSON_API
{
    public class DemoData
    {
        public static IEnumerable<Book> GetDemoBooks()
        {
            var books = new List<Book>();
            var random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                books.Add(new Book
                {
                    Id = i,
                    Name = "Book " + i,
                    Author = "Author" + (i % 3),
                    Pages = random.Next(100, 500)
                });
            }
            return books;
        }
    }
}