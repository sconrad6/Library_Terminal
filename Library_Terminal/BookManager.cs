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
            foreach (Book music in bookList)
            {
                Console.WriteLine($"\n{music.Title} by {music.Author}\n{music.StatusCheck}");
            }
        }


    }
}
