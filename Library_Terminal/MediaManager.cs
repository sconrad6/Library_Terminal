using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Terminal
{
    public class MediaManager
    {
        public static void ListLibrary(List<LibraryMedia> mediaList)
        {
            foreach (LibraryMedia media in mediaList)
            {
                Console.WriteLine($"\n{media.Title} by {media.Author}.  Available? {media.Available}");
            }
        }

        public static void Add(LibraryMedia media)
        {
            string mediaType;
            if (media is Book)
            {
                mediaType = "BookList.txt";
            }
            else
            {
                mediaType = "MusicList.txt";
            }
            using (StreamWriter write = new StreamWriter($"../../../{mediaType}", true))
            {
                write.WriteLine(media);
            }
        }

        public static void Return(List<LibraryMedia> mediaList, string userInput)
        {
            foreach (LibraryMedia media in mediaList)
            {
                if (userInput.Contains(media.Title))
                {
                    media.Available = true;
                    media.Due = DateTime.Today;
                    Console.WriteLine($"{media.Title} has been returned");
                    return;
                }
            }
            Console.Write("This item cannot be found");
        }

        public static void CheckOut(List<LibraryMedia> mediaList, string userInput)
        {
            foreach (LibraryMedia media in mediaList)
            {
                if (userInput.Contains(media.Title) && media.Available)
                {
                    Console.WriteLine($"Do you want to check out {media.Title}? Y/N");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        media.Available = false;
                        media.Due = DateTime.Today.AddDays(14);
                        Console.WriteLine($"{media.Title} is due on {media.Due}");

                    }
                }
            }
        }

        public static void SearchAuthor(string userInput, List<LibraryMedia> mediaList)
        {
            foreach (LibraryMedia media in mediaList)
            {
                if (userInput.Contains(media.Author))
                {
                    Console.WriteLine($"{media.Author}, {media.Title}");
                }
            }
        }

        public static void SearchKeyword(string userInput, List<LibraryMedia> mediaList)
        {
            foreach (LibraryMedia media in mediaList)
            {
                if (media.Title.Contains(userInput))
                {
                    Console.WriteLine($"{media.Title} by {media.Author}");
                }
            }
        }

    }
}
