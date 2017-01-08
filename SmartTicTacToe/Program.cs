// Smart TicTacToe - Learning through evolution
// By: Jonathan Hsieh - 12/15/2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicTacToe
{
    struct Coord
    {
        public int x, y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe t1 = new TicTacToe();

            AI ai1 = new AI(true);
            AI ai2 = new AI(true);

            for (int i = 0; i < 500; i++)
            {
                t1.PlayGame(ai1, ai2); 
            }

            Console.ReadLine();
        }
    }
}
