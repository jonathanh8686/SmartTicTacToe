// Smart TicTacToe - Learning through evolution
// By: Jonathan Hsieh - 12/15/2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// TODO: Add fitness and have a order to who survives
// TODO: Instead of having the 2 top survive, make it random with ~80% dying
namespace SmartTicTacToe
{
    struct Coord
    {
        public int X, Y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<AI> population = new List<AI>();
            List<AI> winners = new List<AI>();

            // Init the first popluation
            // Everything after this will be initalized through breeding
            for (int initPop = 0; initPop < 256; initPop++)
                population.Add(new AI(true));

            for (int gens = 0; gens < 10; gens++)
            {
                for (int i = 0; i < 7; i++)
                {
                    winners = new List<AI>();
                    for (int j = 0; j < population.Count; j += 2)
                    {
                        TicTacToe game = new TicTacToe();
                        int win = game.PlayGame(population[j], population[j + 1]);
                        if (win == 0)
                            winners.Add(population[j]);
                        else
                            winners.Add(population[j + 1]);
                    }
                    population = winners;
                }
                for (int initPop = 0; initPop < 254; initPop++)
                    population.Add(Breed.BreedAI(population[0], population[1], 5));  
            }

            for (int i = 0; i < 100; i++)
            {
                TicTacToe t1 = new TicTacToe();
                AI newAI = new AI(true);
                Console.WriteLine(t1.PlayGame(newAI, population[0]));
            }

            Console.ReadLine();
        }
    }
}
