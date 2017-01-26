using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicTacToe
{
    
    class AI
    {

        public Dictionary<string, string> decisions = new Dictionary<string, string>();
        /// <summary>
        /// Constructor to create an AI with all boards inside
        /// </summary>
        public AI(bool hasDecisions)
        {
            if(hasDecisions)
                InitDecisions();
        }

        /// <summary>
        /// Constructor to create new AI using parents
        /// </summary>
        /// <param name="father">First AI</param>
        /// <param name="mother">Second AI</param>
        /// <param name="mutateFactor">The chance of a mutation, 1/mutationFactor</param>
        public AI(AI father, AI mother, int mutateFactor)
        {
            decisions = Breed.BreedAI(father, mother, mutateFactor).decisions;
        }

        /// <summary>
        /// Initalizes all the Decisions
        /// Use for AI's that will be breeded
        /// </summary>
        public void InitDecisions()
        {
            // Create Decisions
            string[] rawBoards = System.IO.File.ReadAllLines(@"boards.txt");
            for (int i = 0; i < rawBoards.Length; i++)
                decisions.Add(rawBoards[i], GetRandomReaction());
        }

        /// <summary>
        /// Gets the next move of board, depending on the boardState
        /// </summary>
        /// <param name="boardState">The current moves on the board</param>
        /// <returns>The coordinates of the next move</returns>
        public Coord GetMove(string boardState)
        {
            Coord moveCoord = new Coord();
            char[] decision = decisions[boardState].ToCharArray();
            foreach (char i in decision)
            {
                if(boardState.ToCharArray()[i - '0'] == '2')
                {
                    moveCoord.x = (i - '0') / 3;
                    moveCoord.y = (i - '0') % 3;
                }
            }
            return moveCoord;
        }

        /// <summary>
        /// Gets random reactions for every board
        /// (Permutations of 0,1,2,3,4,5,6,7,8)
        /// </summary>
        /// <returns>Returns a possible reaction</returns>
        public string GetRandomReaction()
        {
            string rtnString = "";
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            // Mix up the numbers 0-8 for a random reaction
            int[] arrDecs = numbers.OrderBy(x => rnd.Next()).ToArray();
            foreach (var intA in arrDecs)
                rtnString += intA.ToString();

            return rtnString;
        }


    }
}
