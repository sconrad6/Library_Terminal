using System;
namespace Library_Terminal
{
    public abstract class LibraryMedia
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Due { get; set; }
        public bool Available { get; set; }

        protected LibraryMedia(string title, string author, bool available, DateTime due)
        {
            Title = title;
            Author = author;
            Due = due;
            Available = available;
        }
      
    } 
}
