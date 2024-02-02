using System;

namespace JeuMorpion
{
    public class Map
    {
        public char[,] tab = new char[,]
        {
            {' ','⎽','⎽','⎽','⎽','⎽',' '},
            {'│','_','│','_','│','_','│'},
            {'├',' ','┼',' ','┼',' ','┤'},
            {'│','_','│','_','│','_','│'},
            {'├',' ','┼',' ','┼',' ','┤'},
            {'│','_','│','_','│','_','│'},
            {' ','‾','‾','‾','‾','‾',' '}
        };

        public void DisplayMap()
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(
                "↑ UP\t"
                + "↓ DOWN\n"
                + "→ RIGHT\t"
                + "← LEFT\n"
                + "␣ SPACE to enter X or O"
                );
        }
    }
}