using System;
using System.Collections.Generic;

namespace Library_Terminal
{
    class Music : LibraryInventory
    {
        public DateTime Due { get; set; }
        public bool StatusCheck { get; set; }
        
        public Music(string title, string author, bool statusCheck, DateTime due)
            : base (title, author)

        {
            StatusCheck = statusCheck;
            Due = due;
        }

        public DateTime DueDate()
        {
            return DateTime.Today;
        }

        public override string Status()
        {
            return null;
        }

        public override string ToString()
        {
            return $"{Title}|{Author}|{StatusCheck}|{Due}";
        }
    } 
}
