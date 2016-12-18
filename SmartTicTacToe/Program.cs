// Smart TicTacToe - Learning through evolution
// By: Jonathan Hsieh - 12/15/2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe t1 = new TicTacToe();
           
            t1.PrintBoard();
            Console.ReadLine();
        }
    }
}
