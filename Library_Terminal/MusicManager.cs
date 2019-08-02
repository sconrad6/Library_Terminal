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

        // Return a music
        public static void ReturnMusic(string userInput, List<Music> musicList)
        {
            bool found = false;
            foreach (Music music in musicList)
            {
                if (userInput.Contains(music.Title))
                {
                    found = true;
                    music.StatusCheck = true;
                    music.Due = DateTime.Today;
                    Console.WriteLine($"{music.Title} has been returned");
                }
            }
            if (!found)
            {
                Console.WriteLine("This song is not from our library");
            }
        }

        public static void AddMusic(Music userMusic)
        {
            using (StreamWriter writer = new StreamWriter("../../../MusicList.txt", true))
            {
                writer.WriteLine(userMusic);
            }
        }

        public static void SearchArtist(string userInput, List<Music> musicList)
        {
            foreach (Music music in musicList)
            {
                if (userInput.Contains(music.Author))
                {
                    Console.WriteLine($"{music.Title} by {music.Author}");
                }
            }
        }


        public static void WriteMusic(List<Music> musicList)
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

        public static void CheckOut(List<Music> musicList, string userInput)
        {
            foreach (Music music in musicList)
            {
                if (userInput.Contains(music.Title) && music.StatusCheck)
                {
                    Console.WriteLine("Do you want to check this book out? Y/N");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        music.StatusCheck = false;
                        music.Due = DateTime.Today.AddDays(14);
                        Console.WriteLine($"{music.Title} is due on {music.Due}");

                    }

                }
            }

        }

        public static void SearchKeyword(string userInput, List<Music> musicList)
        {
            foreach (Music music in musicList)
            {
                if (music.Title.Contains(userInput))
                {
                    Console.WriteLine($"{music.Title} by {music.Author}");
                }
            }
        }

    }
}

