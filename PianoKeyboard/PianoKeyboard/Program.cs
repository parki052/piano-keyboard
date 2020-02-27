using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PianoKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.CursorVisible = false;
            PlayBeeps();
        }

        public enum Pitches
        {
            C = 523,
            Cs = 554,
            D = 587,
            Ds = 622,
            E = 659,
            F = 699,
            Fs = 740,
            G = 784,
            Gs = 831,
            A = 880,
            As = 932,
            B = 988,
            C2 = 1047
        }

        public static int[] GetPitches()
        {
            int[] pitches = new int[13];
            int indexer = 0;
            foreach (var pitch in Enum.GetValues(typeof(Pitches)))
            {
                pitches[indexer] = (int)pitch;
                indexer++;
            }
            return pitches;
        }

        public static void PlayBeeps()
        {
            int duration = 200;
            int[] pitches = GetPitches();
            int keyPressIndex = 0;
            bool quit = false;

            while (!quit)
            {
                Console.Clear();
                PrintKeyboard(999, true);

                ConsoleKeyInfo cki = Console.ReadKey(true);

                Console.Clear();
                switch (cki.Key)
                {
                    case ConsoleKey.A:

                        keyPressIndex = 2;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[0], duration);
                        break;

                    case ConsoleKey.W:

                        keyPressIndex = 4;
                        PrintKeyboard(keyPressIndex, false);
                        Console.Beep(pitches[1], duration);
                        break;

                    case ConsoleKey.S:

                        keyPressIndex = 7;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[2], duration);
                        break;

                    case ConsoleKey.E:

                        keyPressIndex = 9;
                        PrintKeyboard(keyPressIndex, false);
                        Console.Beep(pitches[3], duration);
                        break;

                    case ConsoleKey.D:

                        keyPressIndex = 12;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[4], duration);
                        break;

                    case ConsoleKey.F:

                        keyPressIndex = 17;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[5], duration);
                        break;

                    case ConsoleKey.T:

                        keyPressIndex = 19;
                        PrintKeyboard(keyPressIndex, false);
                        Console.Beep(pitches[6], duration);
                        break;

                    case ConsoleKey.G:

                        keyPressIndex = 22;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[7], duration);
                        break;

                    case ConsoleKey.Y:

                        keyPressIndex = 24;
                        PrintKeyboard(keyPressIndex, false);
                        Console.Beep(pitches[8], duration);
                        break;

                    case ConsoleKey.H:

                        keyPressIndex = 27;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[9], duration);
                        break;

                    case ConsoleKey.U:

                        keyPressIndex = 29;
                        PrintKeyboard(keyPressIndex, false);
                        Console.Beep(pitches[10], duration);
                        break;

                    case ConsoleKey.J:

                        keyPressIndex = 32;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[11], duration);
                        break;

                    case ConsoleKey.K:

                        keyPressIndex = 37;
                        PrintKeyboard(keyPressIndex, true);
                        Console.Beep(pitches[12], duration);
                        break;

                    case ConsoleKey.Escape:
                        quit = true;
                        break;

                    default:
                        break;


                }
            }
        }

        public static void PrintKeyboard(int keyPressIndex, bool isWhiteKey)
        {
            int[] blackKeyLineIndex = new int[] { 0, 2, 6, 7, 11, 14, 15, 17, 21, 22, 26, 27, 31, 34, 35, 39 };
            int[] whiteKeyLineIndex = new int[] { 0, 4, 5, 9, 10, 14, 15, 19, 20, 24, 25, 29, 30, 34, 35, 39 };
            Console.WriteLine("                     *****************");
            Console.WriteLine("                     ****Free Play****");
            Console.WriteLine("                     *****************");
            Console.WriteLine();
            WriteInColor("                 W    E        T   Y    U\n", ConsoleColor.Green);
            WriteInColor("               (Db) (Eb)     (Gb) (Ab) (Bb)\n", ConsoleColor.Cyan);
            Console.WriteLine("            _______________________________________");
            Console.WriteLine("            | |   ||   |  || |   ||   ||   |  ||   |");
            Console.WriteLine("            | |   ||   |  || |   ||   ||   |  ||   |");
            //print dynamic black key row
            Console.Write("            ");  
            for (int i = 0; i <= 39; i++)
            {
                bool haveIprintedYet = false;
                foreach (int z in blackKeyLineIndex)
                {
                    if (i == z)
                    {
                        Console.Write("|");
                        haveIprintedYet = true;
                    }
                }

                if (i == keyPressIndex && !isWhiteKey)
                {
                    WriteInColor("#", ConsoleColor.Red);
                    haveIprintedYet = true;
                }
                else if(!haveIprintedYet)
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
            Console.WriteLine("            | |___||___|  || |___||___||___|  ||   |");
            Console.WriteLine("            |   ||   ||   ||   ||   ||   ||   ||   |");
            //print dynamic white key row
            Console.Write("            ");
            for (int i = 0; i <= 39; i++)
            {
                bool haveIprintedYet = false;

                foreach (int z in whiteKeyLineIndex)
                {
                    if (i == z)
                    {
                        Console.Write("|");
                        haveIprintedYet = true;
                    }
                }

                if (i == keyPressIndex && isWhiteKey)
                {
                    WriteInColor("#", ConsoleColor.Red);
                    haveIprintedYet = true;
                }
                else if(!haveIprintedYet)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"            |___||___||___||___||___||___||___||___|");
            WriteInColor("             (C)  (D)  (E)  (F)  (G)  (A)  (B)  (C)\n", ConsoleColor.Cyan);
            WriteInColor("              A    S    D    F    G    H    J    K", ConsoleColor.Green);
            Console.WriteLine("\n\n");
            Console.WriteLine("              ********************************");
            Console.Write("              *          Legend:             *\n              *");
            WriteInColor("   (E)", ConsoleColor.Cyan);
            Console.Write("  = Musical Pitch       *\n              *");
            WriteInColor("    D", ConsoleColor.Green);
            Console.WriteLine("   = Letter on Keyboard  *");
            Console.WriteLine("              ********************************");
        }

        public static void WriteInColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
