using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using JeuMorpion.Properties;

namespace JeuMorpion
{
    public class Game
    {
        private List<Player> listOfPlayer;
        private Map map;

        public Game()
        {
            listOfPlayer = new List<Player>();
            listOfPlayer.Add(new Player("Cross", '☓'));
            listOfPlayer.Add(new Player("Circle", '○'));
        }

        public void Launch()
        {
            bool play = true;
            bool first = false;
            while (play)
            {
                map = new Map();
                int index = 0;
                char winner = '_';
                int top = 1;
                int left = 1;
                Console.Clear();
                DisplayScore();
                while (winner == '_')
                {
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.Clear();
                        map.DisplayMap();
                        validInput = ValidInput(Cursor.Navigate(ref left, ref top), listOfPlayer[index].symbol);
                    }
                    if (first)
                        PutSymbolOnMap(left, top, listOfPlayer[index].symbol);
                    first = true;
                     index++;
                     if (index > 1)
                         index = 0;
                     winner = IsWinner();
                }
                Console.Clear();
                DisplayWinner(winner);
                DisplayScore();
                play = Restart();
            }
        }

        public void PutSymbolOnMap(int left, int top, char symbol)
        {
            map.tab[top, left] = symbol;
            Console.SetCursorPosition(top, left);
            Console.Write(symbol);
        }
        public bool ValidInput(int[] coordonnee, char symbol)
        {
            if (map.tab[coordonnee[1], coordonnee[0]] == '_')
                return true;
            Console.SetCursorPosition(coordonnee[0], coordonnee[1]);
            Console.Write('_');
            return false;
        }
        public bool Restart()
        {
            char answer = ' ';
            while (answer != 'N' && answer != 'Y')
            {
                Console.WriteLine(
                    "Do you want to play again ?\n"
                    + "Y - Play again\n"
                    + "N - Stop the game"
                );
                answer = Console.ReadLine()[0];
            }
            if (answer == 'N')
                return false;
            return true;
        }
        public char IsWinner()
        {
            char winner = '_';
            bool endGame = true;
            for (int i = 1; i < map.tab.GetLength(0); i+=2)
            {
                if (map.tab[1, i] == map.tab[3, i ] && map.tab[1 , i] == map.tab[5, i])
                    winner = map.tab[1, i];
                if (map.tab[i, 1] == map.tab[i, 3] && map.tab[i, 1] == map.tab[i, 5])
                    winner = map.tab[i, 1];
            }
            if (map.tab[1,1] == map.tab[3,3] && map.tab[1,1] == map.tab[5,5])
                winner = map.tab[1, 1];
            if (map.tab[1,5] == map.tab[3,3] && map.tab[1,5] == map.tab[5,1])
                winner = map.tab[1, 5];
            for (int i = 1; i < map.tab.GetLength(0); i+=2)
            {
                for (int j = 1; j < map.tab.GetLength(1); j+=2)
                {
                    if (map.tab[i, j] == '_')
                    {
                        endGame = false;
                        break;
                    }
                }
            }
            if (endGame)
                return 'e';
            return winner;
        }

        public void DisplayScore()
        {
            foreach (Player player in listOfPlayer)
            {
                Console.WriteLine(player.ToString());
            }
        }
        public void DisplayWinner(char winner)
        {
            if (winner == 'e')
            {
                Console.WriteLine("Equality: no winner!");
                return;
            }
            foreach (Player player in listOfPlayer)
            {
                if (player.symbol == winner)
                {
                    Console.WriteLine($"{player.name} {player.symbol} win this game!");
                    player.AddPoint();
                    return;
                }
            }
        }
    }
}