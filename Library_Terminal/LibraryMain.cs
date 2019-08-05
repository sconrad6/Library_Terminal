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
            Console.WriteLine("\n\t\t ><><><><><><><><><><><><><><><><><><><><><><\n" +
                "\t\t >><<\tWELCOME TO THE VIRTUAL LIBRARY!\t >><<\n" +
                "\t\t ><><><><><><><><><><><><><><><><><><><><><><");
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
            string userInput;
            do 
            {
            Console.WriteLine("\t\t  WHAT WOULD YOU LIKE TO DO IN OUR BOOK SECTION?\n\n" +
                "\t[ CHECK OUT ] \t [ RETURN ] \t [ ADD ] \t [ LIST ALL BOOKS ] \n\n" +
                "\t\t[ SEARCH BY AUTHOR ]\t[ SEARCH BY KEYWORD ]\t[ EXIT ]\n");
            userInput = Console.ReadLine().ToLower();
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
                    case "list": MediaManager.ListLibrary(bookList); break;
                    case "list all": MediaManager.ListLibrary(bookList); break;
                    case "list all books":
                        MediaManager.ListLibrary(bookList);
                        break;
                    case "author": BookByAuthor(bookList); break;
                    case "search by author":
                        BookByAuthor(bookList);
                        break;
                    case "keyword": BookByKeyword(bookList); break;
                    case "search by keyword":
                        BookByKeyword(bookList);
                        break;
                    case "exit":
                        Console.WriteLine("\t\t\t\tGoodbye!");
                        Environment.Exit(0);
                        break;
                }
            } while (!Validator.OptionValidate(userInput));
        }

        public static void ReturnOrCheckoutMusic()
        {
            Console.WriteLine("\t\t  WHAT WOULD YOU LIKE TO DO IN OUR MUSIC SECTION?\n\n" +
                "\t[ CHECK OUT ] \t [ RETURN ] \t [ ADD ] \t [ LIST ALL MUSIC ] \n\n" +
                "\t\t[ SEARCH BY ARTIST ]\t[ SEARCH BY KEYWORD ]\t[ EXIT ]\n");
            string userInput = Console.ReadLine().ToLower(); // will either be checkout or return
            do
            {
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
                    case "list": MediaManager.ListLibrary(musicList); break;
                    case "list all": MediaManager.ListLibrary(musicList); break;
                    case "list all music":
                        MediaManager.ListLibrary(musicList);
                        break;
                    case "search by artist": MusicByArtist(musicList); break;
                    case "artist": MusicByArtist(musicList); break;
                    case "keyword": MusicByKeyword(musicList); break;
                    case "search by keyword":
                        MusicByKeyword(musicList);
                        break;
                    case "exit":
                        Console.WriteLine("\t\t\t\tGoodbye");
                        Environment.Exit(0);
                        break;
                }
            } while (Validator.OptionValidate(userInput));
        }

        // Would you like to display a list of books or music?
        public static void BookOrMusic()
        {
            Console.WriteLine("\t\t\t   WHAT ARE YOU INTERESTED IN?\n\t\t\t[ BOOKS ]\t\t[ MUSIC ]\n");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "books":
                    ReturnOrCheckoutBook();
                    break;
                case "book":
                    ReturnOrCheckoutBook();
                    break;
                case "music":
                    ReturnOrCheckoutMusic();
                    break;
            }
        }
        public static bool Continue()
        {
            Console.WriteLine("\n\tWOULD YOU LIKE TO CONTINUE?\t\t [ Y for yes ]\t\t[ N for no ]");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y" && Validator.YesOrNo(choice))
            {
                return true;
            }
            Console.WriteLine("\n\t\t\tHave a great day!");
            return false;
        }

        public static void AddUserMusic()
        {
            Console.WriteLine("\n\tTitle:");
            string title = Console.ReadLine();

            Console.WriteLine("\n\tArtist:");
            string artist = Console.ReadLine();

            LibraryMedia userMusic = new Music(title, artist, true, DateTime.Today);
            MediaManager.Add(userMusic);

            Console.WriteLine($"\n\t{title} by {artist} has been added to the library\n");
        }

        public static void AddUserBook()
        {
            Console.WriteLine("\n\tTitle:");
            string title = Console.ReadLine();

            Console.WriteLine("\n\tArtist:");
            string artist = Console.ReadLine();

            LibraryMedia userBook = new Book(title, artist, true, DateTime.Today);
            MediaManager.Add(userBook);

            Console.WriteLine($"\n\t{title} by {artist} has been added to the library\n");
        }

        public static void ReturnUserMusic(List<LibraryMedia> musicList)
        {
            Console.WriteLine("\t\t>X< Please enter the name of the song you want to return\n");
            string userInput = Console.ReadLine();
            MediaManager.Return(musicList, userInput);
        }

        public static void ReturnUserBook(List<LibraryMedia> bookList)
        {
            Console.WriteLine("\t\t>X< Please enter the title of the book you want to return\n");
            string userInput = Console.ReadLine();
            MediaManager.Return(bookList, userInput);
        }

        public static void UserBookCheckOut(List<LibraryMedia> bookList)
        {
            Console.WriteLine("\t\t>X< Please enter the title of the book you want to check out\n");
            string userInput = Console.ReadLine();
            MediaManager.CheckOut(bookList, userInput);
        }

        public static void UserMusicCheckOut(List<LibraryMedia> musicList)
        {
            Console.WriteLine("\t\t>X< Please enter the name of the song you want to check out\n");
            string userInput = Console.ReadLine();
            MediaManager.CheckOut(musicList, userInput);
        }

        public static void BookByAuthor(List<LibraryMedia> bookList)
        {
            Console.WriteLine("\t\t>X< Enter the author you would like to find\n");
            string userInput = Console.ReadLine();
            if (Validator.AuthorValidate(bookList, userInput))
            {
                MediaManager.SearchAuthor(userInput, bookList);
            }
        }

        public static void MusicByArtist(List<LibraryMedia> musicList)
        {
            Console.WriteLine("\t\t>X< Enter the artist you would like to find\n");
            string userInput = Console.ReadLine();
            if (Validator.AuthorValidate(musicList, userInput))
            {

                MediaManager.SearchAuthor(userInput, musicList);
            }
        }

        public static void BookByKeyword(List<LibraryMedia> bookList)
        {
            Console.WriteLine("\t\t>X< Enter a keyword to find a book\n");
            string userInput = Console.ReadLine();
            MediaManager.SearchKeyword(userInput, bookList);
        }

        public static void MusicByKeyword(List<LibraryMedia> musicList)
        {
            Console.WriteLine("\t\t>X< Enter a keyword to find a song\n");
            string userInput = Console.ReadLine();
            MediaManager.SearchKeyword(userInput, musicList);
        }
    }
}
