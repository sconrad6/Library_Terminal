using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Terminal
{
    class Validator
    {
        public static bool YesOrNo(string input)
        {
            if(input == "y" || input == "yes")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please choose [y]es or [n]o. ");
                return false;
            }
        }

        public static bool OptionValidate(string input)
        {
            if(input == "checkout" || input == "return" || input == "add" || 
                input == "search by author" || input == "search by keyword" || 
                input == "author" || input == "artist" || input == "list" || 
                input == "list all" || input == "list all music")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Choice not recognized. Please choose again.");
                return false;
            }
        }

        public static bool AuthorValidate(List<LibraryMedia> list, string input)
        {
            foreach(LibraryMedia authors in list)
            {
                if (input == authors.Author)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool TitleValidate(List<LibraryMedia> list, string input)
        {
            foreach(LibraryMedia titles in list)
            {
                if (input == titles.Title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
