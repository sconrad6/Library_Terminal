using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library_Terminal
{
    class MusicManager
    {
        public static List<Music> MusicReader(List<Music> musicList)
        {
            StreamReader reader = new StreamReader("../../../MusicList.txt");
            string line = reader.ReadLine();
            
            while (line != null)
            {
                string[] music = line.Split('|');
                musicList.Add(new Music(music[0], music[1], bool.Parse(music[2]), DateTime.Parse(music[3]))); //might need to cast as a bool and the DateTime can be parsed right here
                                                                                  // boolean is stored as  bit (0 & 1)
                                                                                  // if checked in DateTime = todays date in the text file -> hardcoded in
                                                                                  // checked out = datetime now + two weeks
                line = reader.ReadLine();
            }
            reader.Close();
            return musicList;
       
        }

        public static void ListMusic()
        {
            List<Music> musicList = new List<Music>();
            MusicReader(musicList);
            foreach (Music music in musicList)
            {
                Console.WriteLine($"\n{music.Title} by {music.Author}");
            }
        }

        // Take a book out
        public static void CheckOutMusic()
        {

        }

        // Return a book
        public static void ReturnMusic()
        {

        }

        public static void AddMusic(Music userMusic)
        {
            using (StreamWriter writer = new StreamWriter("../../../MusicList.txt", true))
            {
                writer.WriteLine(userMusic);
            }
        }
        //Change the due date

        //Add a book to the lis
    }
    }

