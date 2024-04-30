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

namespace UGG
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
            All_Images Images = new All_Images();
            Game_Modes Mode = new Game_Modes();
            ConsoleKeyInfo Key = new ConsoleKeyInfo();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("главное меню. 1 - начать игру, 3 - выйти из игры (2 - статистика, которой пока что нет)");
                Key = Console.ReadKey(true);
                switch (Key.Key)
                {
                    case ConsoleKey.D1:
                        Console.SetCursorPosition(0, 0);
                        Console.Write("тут выбор режима игры. 1 - режим с дробовиком на 6 патронов, каждый раунд дается два предмета.                                                                 ");
                        Key = Console.ReadKey(true);
                        switch (Key.Key)
                        {
                            case ConsoleKey.D1:
                                Mode.Play_Two_Players_Shotgun_Mode();
                                break;
                            default:
                                Console_WriteReadClear("вы нажали не на ту кнопку. enter для перехода на след. меню                                                                 ");
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        Console_WriteReadClear("она пока что не работает. enter для перехода на след. меню                                                                 ");
                        break;
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console_WriteReadClear("вы нажали не на ту кнопку. enter для перехода на след. меню                                                                 ");
                        break;
                }

            }
        }
    }
}
