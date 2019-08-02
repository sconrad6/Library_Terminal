using System;
namespace Library_Terminal
{
    class Book : LibraryInventory
    {
        public DateTime Due { get; set; }
        public bool StatusCheck { get; set; }

        public Book(string title, string author, bool statusCheck, DateTime due)
            : base(title, author)

        {
            StatusCheck = statusCheck;
            Due = due;

        }

        public DateTime DueDate()
        {
            return DateTime.Today;
        }

        protected override string Status()
        {
            return null;
        }
    }
}
