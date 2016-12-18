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

            AI ai1 = new AI();
            AI ai2 = new AI();
            while (t1.CheckWinner() == 2)
            {
                t1.Move(ai1.GetMove(t1.GetBoardState()));
                t1.PrintBoard();
                Console.WriteLine("");
                Console.WriteLine("");
                if (t1.CheckWinner() != 2)
                    break;

                t1.Move(ai2.GetMove(t1.GetBoardState()));
                t1.PrintBoard();
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
