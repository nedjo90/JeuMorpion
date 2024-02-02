using System;
using System.Threading;

namespace JeuMorpion.Properties
{
    public class Cursor
    {
        public static int[] Navigate(ref int left, ref int top)
        {
            bool pressSpaceBar = false; 
            while (!pressSpaceBar)
            {
                ConsoleKeyInfo keyRead = Console.ReadKey();
                if (keyRead.Key == ConsoleKey.Spacebar)
                    pressSpaceBar = true;
                if (keyRead.Key == ConsoleKey.LeftArrow && left - 2 >= 1)
                {
                    left -= 2;
                }
                if (keyRead.Key == ConsoleKey.RightArrow && left + 2 <= 5)
                {
                    left += 2;
                }
                if (keyRead.Key == ConsoleKey.UpArrow && top - 2 >= 1)
                {
                    top -= 2;
                }
                if (keyRead.Key == ConsoleKey.DownArrow && top + 2 <= 5)
                {
                    top += 2;
                }
                Console.SetCursorPosition(left, top);
            }
            return new int[] { left, top };
        }
    }
}