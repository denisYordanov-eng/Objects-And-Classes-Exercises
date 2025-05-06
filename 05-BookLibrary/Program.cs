using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BookLibrary
{
    class Program
    {
        class Book
        {
            public string BookName { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Isbn { get; set; }
            public decimal Price { get; set; }
        }

        class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }
        class AuthorSales
        {
            public string Author { get; set; }
            public decimal Sales { get; set; }
        }
        static void Main(string[] args)
        {
            var library = new Library()
            {
                Name = "Siela",
                Books = new List<Book>()
            };

            int booksCount = int.Parse(Console.ReadLine());

           
            List<Book> newBook = new List<Book>();

            for (int i = 0; i < booksCount; i++)
            {
                string[] inputLine = Console.ReadLine().Split(' ').ToArray();

                string bookName = inputLine[0];
                string author = inputLine[1];
                string publisher = inputLine[2];
                DateTime releaseDate = DateTime.ParseExact
                    (inputLine[3], "dd.MM.yyyy",
                    CultureInfo.InvariantCulture);
                string isbn = inputLine[4];
                decimal price = decimal.Parse(inputLine[5]);

                Book book = new Book()
                {
                    BookName = bookName,
                    Author = author,
                    Publisher = publisher,
                    ReleaseDate = releaseDate,
                    Isbn = isbn,
                    Price = price,

                };
                //newBook.Add(book);
                library.Books.Add(book);
            }
            var authors = library.Books
                .Select(a => a.Author)
                .Distinct()
                .ToArray();

            var authorsData = new List<AuthorSales>();
            foreach (var author in authors)
            {
                var authorSells = library.Books
                    .Where(a => a.Author == author).Sum(a => a.Price);

                var authorInfo = new AuthorSales()
                {
                    Author = author,
                    Sales = authorSells,
                };
                authorsData.Add(authorInfo);
            }
                authorsData = authorsData
                .OrderByDescending(a => a.Sales)
                .ThenBy(a => a.Author)
                .ToList();

            foreach (var authorSale in authorsData)
            {
                var writer = authorSale.Author;
                var allPrice = authorSale.Sales;
                Console.WriteLine($"{writer} -> {allPrice:F2}");
            }
        }
    }
}
