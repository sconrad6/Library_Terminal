using System;
using System.Collections.Generic;

namespace Library_Terminal
{
    class LibraryMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the virtual library!");

            do
            {
                BookOrMusic();
                //MusicManager.ListMusic();
                

            } while (Continue());
            
        }


        public static void ReturnOrCheckoutBook()
        { 
            Console.WriteLine("Would you like to:\n" +
                "Check out a book\n" +
                "Return a book\n" +
                "Add a book\n" +
                "List the book library\n" +
                "Exit");
            string userInput = Console.ReadLine().ToLower(); // will either be checkout or return
            switch (userInput)
            {
                case "check out":

                    break;
                case "return":

                    break;
                case "add":

                    break;
                case "list":
                    
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
                    MusicManager.CheckOutMusic();
                    break;
                case "return":
                    MusicManager.ReturnMusic();
                    break;
                case "add":
                    AddMusic();
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


        //Would you like to search for a book or music?

        // would you like to search by author or keyword?

        // Please select the book you want to checkout

        // implement methods IsCheckedOut and maybe  DueDate
        // and set the DueDate approproately

        // would you like to continue?
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

        public static void AddMusic()
        {
            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Artist:");
            string artist = Console.ReadLine();

            Music newMusic = new Music(title, artist, true, DateTime.Now);
            MusicManager.AddMusic(newMusic);

            Console.WriteLine($"{title} by {artist} has been added to the library");
        }

    }
}
