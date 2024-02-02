using System;

namespace JeuMorpion
{
    public class Player
    {
        public string name {get; }
        public char symbol {get; }
        public int points { get; set; }

        public Player(string name, char symbol)
        {
            this.name = name;
            this.symbol = symbol;
            this.points = 0;
        }

        public void AddPoint()
        {
            this.points++;
        }

        public override string ToString()
        {
            return $"{name} {symbol}: {points}";
        }
    }
}