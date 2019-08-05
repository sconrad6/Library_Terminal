using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Terminal
{
    class BookManager : MediaManager
    {

        public static List<LibraryMedia> BookReader(List<LibraryMedia> bookList)
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
        
        public static void WriteBook(List<LibraryMedia> bookList)
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
