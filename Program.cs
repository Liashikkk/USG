using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {
            /*System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Play();
            player.Dispose();
            */

            FullScreen();
            Console.ReadLine();
        }
    }
}
