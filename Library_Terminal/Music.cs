using System;
using System.Collections.Generic;

namespace Library_Terminal
{
    class Music : LibraryMedia {

        public Music(string title, string author, bool available, DateTime due)
            : base (title, author, available, due)

        {
          
        }


        public override string ToString()
        {
            return $"{Title}|{Author}|{Available}|{Due}";
        }
    } 
}
