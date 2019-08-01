using System;
namespace Library_Terminal
{
    class Music : LibraryInventory
    {
        public string Due { get; set; }
        public string StatusCheck { get; set; }
        
        public Music(string title, string author, string statusCheck, string due)
            : base (title, author)

        {
            StatusCheck = statusCheck;
            Due = due;

        }

        protected override string DueDate()
        {
            return null;
        }

        protected override string Status()
        {
            return null;
        }
    }
}
