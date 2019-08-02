using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Terminal
{
    class BookManager
    {

        public static List<Book> BookReader(List<Book> bookList)
        {
            StreamReader reader = new StreamReader("../../../BookList.txt");
            string line = reader.ReadLine();

            while (line != null)
            {
                string[] books = line.Split('|');
                bookList.Add(new Book(books[0], books[1], bool.Parse(books[2]), DateTime.Parse(books[3])));
                line = reader.ReadLine();
            }
            reader.Close();
            return bookList;
        }
        
        public static void ListBooks()
        {
            List<Book> bookList = new List<Book>();
            BookReader(bookList);
            foreach (Book book in bookList)
            {
                Console.WriteLine($"\n{book.Title} by {book.Author}");
            }
        }

        public static void AddBook(Book userBook)
        {
            using (StreamWriter writer = new StreamWriter("../../../BookList.txt", true)) // false at the end
            {// inside foreach loop
                writer.WriteLine(userBook);
            }
        }

        public static void ReturnBook(string userInput, List<Book> bookList)
        {
            bool found = false;
            foreach (Book book in bookList)
            {
                if (userInput.Contains(book.Title))
                {
                    found = true;
                    book.StatusCheck = true;
                    book.Due = DateTime.Today;
                    Console.WriteLine($"{book.Title} has been returned");
                }
            }
            if (!found)
            {
                Console.WriteLine("This book is not from our library");
            }
        }

        public static void WriteBook(List<Book> bookList)
        {
            using (StreamWriter writer = new StreamWriter("../../../BookList.txt", false))
            {
                foreach (Book book in bookList)
                {
                    writer.WriteLine(book);
                }
                writer.Close();
            }
            
        }

        public static void CheckOut(List<Book> bookList, string userInput)
        {
            foreach (Book book in bookList)
            {
                if (userInput.Contains(book.Title) && book.StatusCheck)
                {
                    Console.WriteLine("Do you want to check this book out? Y/N");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        book.StatusCheck = false;
                        book.Due = DateTime.Today.AddDays(14);
                        Console.WriteLine($"{book.Title} is due on {book.Due}");
                       
                    }
                    
                }
            }

        }
        public static void SearchArtist(string userInput, List<Book> bookList)
        {
            foreach (Book book in bookList)
            {
                if (userInput.Contains(book.Author))
                {
                    Console.WriteLine($"{book.Author}, {book.Title}");
                }   
            }
        }

        public static void SearchKeyword(string userInput, List<Book> bookList)
        {
            foreach (Book book in bookList)
            {
                if (book.Title.Contains(userInput))
                {
                    Console.WriteLine($"{book.Title} by {book.Author}");
                }
            }
        }
    }
}
