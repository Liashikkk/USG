using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace USG
{
    internal class Program
    {
        const int STD_OUTPUT_HANDLE = -11;

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleDisplayMode(IntPtr ConsoleHandle, uint Flags, IntPtr NewScreenBufferDimensions);
        public static void FullScreen()
        {
            var hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
            SetConsoleDisplayMode(hConsole, 1, IntPtr.Zero);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }
        public static void Console_WriteReadClear(string Text, int First_Num = 35, int Second_Num = 35)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Text);
            Console.SetCursorPosition(First_Num, Second_Num);
            Console.ReadLine();
        }
        public static void play()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("..\\console\\1.wav");
            player.Load();
            player.PlaySync();
        }
        static void Main(string[] args)
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
            FullScreen();

            All_Images Image = new All_Images();

            Game_Modes Mode = new Game_Modes();

            Random Random_Number = new Random();

            Console_WriteReadClear(Image.Set_Display);

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Main_Menu);
                Console.SetCursorPosition(67, 33);
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            bool Will = false;
                            while (!Will)
                            {
                                Console.SetCursorPosition(0, 0);
                                Console.Write(Image.Lore);
                                Console.SetCursorPosition(70, 32);
                                switch (Convert.ToInt32(Console.ReadLine()))
                                {
                                    case 1:
                                        while (!Will)
                                        {
                                            Console.SetCursorPosition(0, 0);
                                            Console.Write(Image.Game_Modes_Choose);
                                            Console.SetCursorPosition(69, 33);
                                            switch (Convert.ToInt32(Console.ReadLine()))
                                            {
                                                case 1:
                                                    Mode.Shotgun_Mode();
                                                    Will = true;
                                                    break;
                                                case 2:
                                                    Mode.DoubleBarreledShotgun_Mode();
                                                    Will = true;
                                                    break;
                                                default:
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        Will = true;
                                        break;
                                    default:
                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                        break;
                                }
                            }
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                            break;
                    }
                }
                catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
            }
        }
    }
}
