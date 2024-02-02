using System;
using System.Threading;

namespace JeuMorpion
{
    public class UserInterface
    {
        private Game game;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Press any key to start");
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(100);
            }
            Console.Clear();
            game = new Game();
            game.Launch();
        }
    }
}