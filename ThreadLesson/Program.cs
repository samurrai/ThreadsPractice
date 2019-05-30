using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread soundThread = new Thread(new ThreadStart(PlayMusic));
            soundThread.IsBackground = true;
            soundThread.Start();

            string text = Console.ReadLine();
            Thread saveToFileThread = new Thread(new ParameterizedThreadStart(SaveToFile));
            saveToFileThread.Start(text);
        }

        private static void PlayMusic()
        {
            SoundPlayer soundPlayer = new SoundPlayer("paul-mauriat-badinerie-bach.wav");
            soundPlayer.Play();
        }

        private static void SaveToFile(object text)
        {
            using (var reader = new StreamWriter("1.txt"))
            {
                reader.WriteLine(text as string);
            }
        }
    }
}
