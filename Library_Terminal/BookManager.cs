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
        // Take a book out 

        // Return a book

        //Change the due date

        //Add a book to the list

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
            //close file
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

    }
}
