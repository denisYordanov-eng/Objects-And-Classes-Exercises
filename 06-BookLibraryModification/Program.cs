using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_BookLibraryModification
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
       
        static void Main(string[] args)
        {

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
                newBook.Add(book);
            }
            string givenDate = Console.ReadLine();

            DateTime dateTime = DateTime.ParseExact
                (givenDate, "dd.MM.yyyy",
                CultureInfo.InvariantCulture);

            var booksName = newBook.Where
                (a => a.ReleaseDate >= dateTime)
                .OrderBy(a => a.ReleaseDate)
                .ThenBy(a => a.BookName).ToList();
               
            foreach (var book in booksName)
            {
                string bookTitle = book.BookName;
                DateTime dateOfRealise = book.ReleaseDate;
                Console.WriteLine("{0} -> {1:dd.MM.yyyy}",bookTitle,dateOfRealise);
            }
        }
    }
}
