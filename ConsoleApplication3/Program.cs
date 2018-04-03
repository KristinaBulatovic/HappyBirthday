using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace ConsoleApplication3
{
    
    class Program
    {

        static void Main(string[] args)
        {
            ConsoleColor[] boje = { ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Red };
            Random rnd = new Random();
           // int month = rnd.Next(0, 6);

            //Iscrtaj

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Grasshoper();
            }).Start();
            Thread.Sleep(1500);
            int r1;
            int r2;
            for (int i = 0; i < 50; i++)
            {
                r1 = rnd.Next(0, 6);
                r2 = rnd.Next(0, 6);
                if(r1 == r2) r2++;
                Iscrtaj(boje[r1], boje[r2]);
                Thread.Sleep(250);
                Console.Clear();
            }
            r1 = rnd.Next(0, 6);
            r2 = rnd.Next(0, 6);
            Iscrtaj2(boje[r1], boje[r2]);


            Console.ReadKey();
        }

        private static void Iscrtaj(ConsoleColor c1, ConsoleColor c2)
        {
            Console.BackgroundColor = c1;
            Console.ForegroundColor = c2;

            SetConsoleFont("Lucida Console");

            Console.OutputEncoding = Encoding.UTF8;
            //Grasshoper();
            string path = @"data.txt";
            string[] text = System.IO.File.ReadAllLines(path, Encoding.Unicode);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            foreach (string s in text)
            {
                for(int i = 0; i < (int)(30);i++) Console.Write(" ");
                Console.Write(s);
                for (int i = 0; i < (int)(75 - s.Length - 30); i++) Console.Write(" ");
                Console.WriteLine();
            }
        }

        private static void Iscrtaj2(ConsoleColor c1, ConsoleColor c2)
        {
            Console.BackgroundColor = c1;
            Console.ForegroundColor = c2;

            SetConsoleFont("Lucida Console");

            Console.OutputEncoding = Encoding.UTF8;
            //Grasshoper();
            string path = @"meda.txt";
            string[] text = System.IO.File.ReadAllLines(path);


            foreach (string s in text)
            {

                Console.Write(s);
                Console.WriteLine();
            }
        }

        private static void Grasshoper()
        {
            // but I don't remember where exactly.
            int C = 264;
            int D = 297;
            int E = 330;
            int F = 352;
            int G = 396;
            int A = 440;
            int Bb = 466;
            int B = 495;
            int C2 = 528;

            // Now, we need to set the tempo for a note, half note, quarter note, and eighth note.
            int note = 1000;
            int half = 1000 / 2;
            int quarter = 1000 / 4;
            int eighth = 1000 / 8;


            Thread.Sleep(2000);
            Console.Beep(C, eighth);
            Thread.Sleep(quarter);
            Console.Beep(C, eighth);
            Thread.Sleep(eighth);
            Console.Beep(D, half);
            Thread.Sleep(eighth);
            Console.Beep(C, half);
            Thread.Sleep(eighth);
            Console.Beep(F, half);
            Thread.Sleep(eighth);
            Console.Beep(E, note);
            Thread.Sleep(quarter);

            Console.Beep(C, eighth);
            Thread.Sleep(quarter);
            Console.Beep(C, eighth);
            Thread.Sleep(eighth);
            Console.Beep(D, half);
            Thread.Sleep(eighth);
            Console.Beep(C, half);
            Thread.Sleep(eighth);
            Console.Beep(G, half);
            Thread.Sleep(eighth);
            Console.Beep(F, note);

            Thread.Sleep(quarter);
            Console.Beep(C, eighth);
            Thread.Sleep(quarter);
            Console.Beep(C, eighth);
            Thread.Sleep(eighth);
            Console.Beep(C2, half);
            Thread.Sleep(eighth);
            Console.Beep(A, half);
            Thread.Sleep(eighth);
            Console.Beep(F, quarter);
            Thread.Sleep(eighth);
            Console.Beep(F, eighth);
            Thread.Sleep(eighth);
            Console.Beep(E, half);
            Thread.Sleep(eighth);
            Console.Beep(D, note);

            Thread.Sleep(quarter);
            Console.Beep(Bb, eighth);
            Thread.Sleep(quarter);
            Console.Beep(Bb, eighth);
            Thread.Sleep(eighth);
            Console.Beep(A, half);
            Thread.Sleep(eighth);
            Console.Beep(F, half);
            Thread.Sleep(eighth);
            Console.Beep(G, half);
            Thread.Sleep(eighth);
            Console.Beep(F, note);
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int SetConsoleFont(
            IntPtr hOut,
            uint dwFontNum
            );
        public static void SetConsoleFont(string fontName = "Lucida Console")
        {
            unsafe
            {
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                if (hnd != INVALID_HANDLE_VALUE)
                {
                    CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    // Set console font to Lucida Console.
                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    // Get some settings from current font.
                    newInfo.dwFontSize = new COORD(info.dwFontSize.X, info.dwFontSize.Y);
                    newInfo.FontWeight = 700;
                    SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }
    }
}
    
