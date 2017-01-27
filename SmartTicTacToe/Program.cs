// Smart TicTacToe - Learning through evolution
// By: Jonathan Hsieh - 12/15/2016

using System;

namespace SmartTicTacToe
{
    struct Coord
    {
        public int X, Y;
    }
    class Program
    {
        private static void Main()
        {
            TicTacToe t1 = new TicTacToe();

            AI[] population = new AI[128];
            for (int initPop = 0; initPop < population.Length; initPop++)
                population[initPop] = new AI(true);

            int elimRounds = int.Parse(Math.Log(population.Length, 2).ToString()) - 1;
            for (int i = 0; i < elimRounds; i++)
            {
                AI[] winners = new AI[population.Length / 2];
                for (int j = 0; j < population.Length; j += 2)
                {
                    int winner = t1.PlayGame(population[j], population[j + 1]);
                    if (winner == 0 || winner == 1)
                        winners[j / 2] = population[j + winner];
                    if (winner == 3)
                        winners[j / 2] = population[j];
                }
                population = winners; 
            }

            Console.ReadLine();
        }
    }
}
