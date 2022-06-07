using Infrastructure;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public static class BookDAL
    {
        private static readonly List<Book> _books = new List<Book>{ 
            new Book{ Id = 1, Author = "Pippo", Title="Titolo 1", Year = 2020 },
            new Book{ Id = 2, Author = "Pluto", Title="Titolo 2", Year = 2000 },
            new Book{ Id = 3, Author = "Paperino", Title="Titolo 3", Year = 1990 },
            new Book{ Id = 4, Author = "Topolin0", Title="Titolo 4", Year = 2014 }
        };

        public static IEnumerable<Book> GetBooks()
        {
            return _books;
        }
    }
}
