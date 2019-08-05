using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Terminal
{
    class LibraryMain
    {
        static List<LibraryMedia> bookList = new List<LibraryMedia>();
        static List<LibraryMedia> musicList = new List<LibraryMedia>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the virtual library!\n");
            BookManager.BookReader(bookList);
            MusicManager.MusicReader(musicList);
            do
            {
                BookOrMusic();

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
                "Search by author\n" +
                "Search by keyword\n" +
                "Exit");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "check out":
                    UserBookCheckOut(bookList);
                    break;
                case "return":
                    ReturnUserBook(bookList);
                    break;
                case "add":
                    AddUserBook();
                    break;
                case "list":
                    MediaManager.ListLibrary(bookList);
                    break;
                case "search by author":
                    BookByAuthor(bookList);
                    break;
                case "search by keyword":
                    BookByKeyword(bookList);
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
                "Search by artist" +
                "Search by keyword\n" +
                "Exit");
            string userInput = Console.ReadLine().ToLower(); // will either be checkout or return

            switch (userInput)
            {
                case "check out":
                    UserMusicCheckOut(musicList);
                    break;
                case "return":
                    ReturnUserMusic(musicList);
                    break;
                case "add":
                    AddUserMusic();
                    break;
                case "list":
                    MediaManager.ListLibrary(musicList);
                    break;
                case "search by artist":
                    MusicByArtist(musicList);
                    break;
                case "search by keyword":
                    MusicByKeyword(musicList);
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

            LibraryMedia userMusic = new Music(title, artist, true, DateTime.Today);
            MediaManager.Add(userMusic);

            Console.WriteLine($"{title} by {artist} has been added to the library\n");
        }

        public static void AddUserBook()
        {
            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Artist:");
            string artist = Console.ReadLine();

            LibraryMedia userBook = new Book(title, artist, true, DateTime.Today);
            MediaManager.Add(userBook);

            Console.WriteLine($"{title} by {artist} has been added to the library\n");
        }

        public static void ReturnUserMusic(List<LibraryMedia> musicList)
        {
            Console.WriteLine("Please enter the name of the song you want to return");
            string userInput = Console.ReadLine();
            MediaManager.Return(musicList, userInput);
        }

        public static void ReturnUserBook(List<LibraryMedia> bookList)
        {
            Console.WriteLine("Please enter the title of the book you want to return");
            string userInput = Console.ReadLine();
            MediaManager.Return(bookList, userInput);
        }

        public static void UserBookCheckOut(List<LibraryMedia> bookList)
        {
            Console.WriteLine("Please enter the title of the book you want to check out");
            string userInput = Console.ReadLine();
            MediaManager.CheckOut(bookList, userInput);
        }

        public static void UserMusicCheckOut(List<LibraryMedia> musicList)
        {
            Console.WriteLine("Please enter the name of the song you want to check out");
            string userInput = Console.ReadLine();
            MediaManager.CheckOut(musicList, userInput);
        }

        public static void BookByAuthor(List<LibraryMedia> bookList)
        {
            Console.WriteLine("Enter the author you would like to find");
            string userInput = Console.ReadLine();
            MediaManager.SearchAuthor(userInput, bookList);
        }

        public static void MusicByArtist(List<LibraryMedia> musicList)
        {
            Console.WriteLine("Enter the artist you would like to find");
            string userInput = Console.ReadLine();
            MediaManager.SearchAuthor(userInput, musicList);
        }

        public static void BookByKeyword(List<LibraryMedia> bookList)
        {
            Console.WriteLine("Enter a keyword to find a book");
            string userInput = Console.ReadLine();
            MediaManager.SearchKeyword(userInput, bookList);
        }

        public static void MusicByKeyword(List<LibraryMedia> musicList)
        {
            Console.WriteLine("Enter a keyword to find a song");
            string userInput = Console.ReadLine();
            MediaManager.SearchKeyword(userInput, musicList);
        }
    }
}
