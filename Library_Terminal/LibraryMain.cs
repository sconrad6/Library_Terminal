using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Terminal
{
    class LibraryMain
    {
        static List<Book> bookList = new List<Book>();
        static List<Music> musicList = new List<Music>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the virtual library!\n");
            BookManager.BookReader(bookList);
            MusicManager.MusicReader(musicList);
            do
            {
                PrintLibrary(musicList, bookList);
                BookOrMusic();
                //MusicManager.ListMusic();

            } while (Continue());
            BookManager.WriteBook(bookList);
            MusicManager.WriteMusic(musicList);
        }
        public static void ReturnOrCheckoutBook()
        { 
            Console.WriteLine("Would you like to:\n" +
                "Check out a book\n" +
                "Return a book\n" +
                "Add a book\n" +
                "List the book library\n" +
                "Exit");
            string userInput = Console.ReadLine().ToLower(); 
            switch (userInput)
            {
                case "check out":

                    break;
                case "return":
                    ReturnUserBook(bookList);
                    break;
                case "add":
                    AddUserBook();
                    break;
                case "list":
                    BookManager.ListBooks();
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }

        public static void ReturnOrCheckoutMusic()
        {
            Console.WriteLine("Would you like to:\n" +
                "Check out music\n" +
                "Return music\n" +
                "Add music\n" +
                "List the music library\n" +
                "Exit");
            string userInput = Console.ReadLine().ToLower(); // will either be checkout or return

            switch (userInput)
            {
                case "check out":
                    
                    break;
                case "return":
                    ReturnUserMusic(musicList);
                    break;
                case "add":
                    AddUserMusic();
                    break;
                case "list":
                    MusicManager.ListMusic();
                    break;
                case "exit":
                    Console.WriteLine("Goodbye");
                    Environment.Exit(0);
                    break;
            }
        }

        // Would you like to display a list of books or music?
        public static void BookOrMusic()
        {
            Console.WriteLine("Are you interested in books or music?");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "books":
                    ReturnOrCheckoutBook();
                    break;
                case "music":
                    ReturnOrCheckoutMusic();
                    break;
            }
        }
        public static bool Continue()
        {
            Console.WriteLine("Would you like to continue? Y/N");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                return true;
            }
            Console.WriteLine("Have a great day!");
            return false;
        }

        public static void AddUserMusic()
        {
            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Artist:");
            string artist = Console.ReadLine();

            Music userMusic = new Music(title, artist, true, DateTime.Today);
            MusicManager.AddMusic(userMusic);

            Console.WriteLine($"{title} by {artist} has been added to the library\n");
        }

        public static void AddUserBook()
        {
            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Artist:");
            string artist = Console.ReadLine();

            Book userBook = new Book(title, artist, true, DateTime.Today);
            BookManager.AddBook(userBook);

            Console.WriteLine($"{title} by {artist} has been added to the library\n");
        }

        public static void ReturnUserMusic(List<Music> musicList)
        {
            Console.WriteLine("Please enter the name of the song you want to return");
            string userInput = Console.ReadLine();
            MusicManager.ReturnMusic(userInput, musicList);
        }

        public static void ReturnUserBook(List<Book> bookList)
        {
            Console.WriteLine("Please enter the title of the book you want to return");
            string userInput = Console.ReadLine();
            BookManager.ReturnBook(userInput, bookList);
        }

        public static void PrintLibrary(List<Music> musicList, List<Book> bookList)
        {
            Console.WriteLine("MUSIC LIBRARY");
            string availability;
            
            foreach (Music music in musicList)
            {
                if (music.StatusCheck == true)
                {
                    availability = "Available";
                }
                else
                {
                    availability = "Not Available";
                }
                Console.WriteLine($"{music.Title} by {music.Author} is {availability}");
            }

            Console.WriteLine("BOOK LIBRARY");
            foreach (Book book in bookList)
            {
                if (book.StatusCheck == true)
                {
                    availability = "Available";
                }
                else
                {
                    availability = "Not Available";
                }
                Console.WriteLine($"{book.Title} by {book.Author} is {availability}");
            }
        }
    }
}
