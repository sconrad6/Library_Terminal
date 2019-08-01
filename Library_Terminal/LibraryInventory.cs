using System;
namespace Library_Terminal
{
    public abstract class LibraryInventory
    {
        public string Title { get; set; }
        public string Author { get; set; }

        protected LibraryInventory(string title, string author)
        {
            Title = title;
            Author = author;
        }
        protected abstract string Status();
    }
}
