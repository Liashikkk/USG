using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USG
{
    internal class All_Sounds
    {
        /*System.Media.SoundPlayer player = new System.Media.SoundPlayer("..\\console\\1.wav");
            player.Play();
            player.Stop


            while (true)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        mciSendString(@"open ..\\console\\1.wav type waveaudio alias lol", null, 0, IntPtr.Zero);
                        mciSendString(@"play lol", null, 0, IntPtr.Zero);
                        break;
                    case 2:
                        mciSendString($"stop lol", null, 0, new IntPtr());
                        break;
                    case 3:
                        player.Play();
                        break;
                    case 4:
                        player.Stop();
                        break;
                }
            }
            
             
             
             ConsoleKeyInfo key = new ConsoleKeyInfo();
            
            Thread lol = new Thread(play);
            lol.Start();
            while (lol.IsAlive)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Console.Write("a");
                }
            }
            Console.ReadLine();
            */
        public static void play()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("..\\console\\1.wav");
            player.Load();
            player.PlaySync();
        }
    }
}
