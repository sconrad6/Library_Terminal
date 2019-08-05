using System;
namespace Library_Terminal
{
    class Book : LibraryMedia
    {
        public Book(string title, string author, bool available, DateTime due)
            : base (title, author, available, due)

        {
        
        }

        public override string ToString()
        {
            return $"{Title}|{Author}|{Available}|{Due}";
        }
    }
}
