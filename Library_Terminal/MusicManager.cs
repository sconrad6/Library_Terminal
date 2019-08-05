using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library_Terminal
{
    class MusicManager

    {
        public static List<LibraryMedia> MusicReader(List<LibraryMedia> musicList)
        {
            StreamReader reader = new StreamReader("../../../MusicList.txt");
            string line = reader.ReadLine();
            
            while (line != null)
            {
                string[] music = line.Split('|');
                musicList.Add(new Music(music[0], music[1], bool.Parse(music[2]), DateTime.Parse(music[3])));                                                                  
                line = reader.ReadLine();
            }
            reader.Close();
            return musicList;
       
        }

        public static void WriteMusic(List<LibraryMedia> musicList)
        {
            using (StreamWriter writer = new StreamWriter("../../../MusicList.txt", false))
            {
                foreach (Music music in musicList)
                {
                    writer.WriteLine(music);
                }
                writer.Close();
            }
        }
    }
}

