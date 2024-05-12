using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace USG
{
    internal class Program
    {

        const int STD_OUTPUT_HANDLE = -11;

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
        public static void Console_WriteReadClear(string text)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(text);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            /*System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Play();
            player.Dispose();
            */
            
            FullScreen();

            All_Images Image = new All_Images();

            Game_Modes Mode = new Game_Modes();

            Random Random_Number = new Random();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Main_Menu);
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.Game_Modes_Choose);
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Mode.Shotgun_Mode();
                                break;
                            case 2:
                                Mode.DoubleBarreledShotgun_Mode();
                                break;
                            case 3:
                                break;
                            default:
                                Console_WriteReadClear(Image.This_Button_Isnt_Exists); 
                                break;
                        }
                        break;
                    case 2:
                        Console_WriteReadClear("она пока что не работает. enter для перехода на следующее меню                                                                 ");
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                        break;
                }
            }
        }
    }
}
