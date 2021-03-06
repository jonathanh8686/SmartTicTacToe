﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTicTacToe
{
    class Breed
    {
        /// <summary>
        /// Takes in a list of parents and outputs parents.count/2 children
        /// </summary>
        /// <param name="parents">Parents to be bred</param>
        /// <param name="mutationFactor">1/mutationFactor chance of mutation</param>
        /// <returns></returns>
        public static List<AI> BreedAIList(List<AI> parents, int mutationFactor)
        {
            List<AI> children = new List<AI>();
            for (int i = 0; i < parents.Count; i+=2)
                children.Add(new AI(parents[i], parents[i + 1], mutationFactor));
            return children;
        }

        /// <summary>
        /// Takes two AIs and breeds their decisions together
        /// </summary>
        /// <param name="male">First AI to breed</param>
        /// <param name="female">Second AI to breed</param>
        /// <param name="mutationFactor">1/mutationFactor chance of mutation</param>
        /// <returns>Returns the new AI (The child of the male and female)</returns>
        public static AI BreedAI(AI male, AI female, int mutationFactor)
        {
            string[] allBoards = male.Decisions.Keys.ToArray();

            AI child = new AI(false);
            child.Decisions = new Dictionary<string, string>();
            string[] maleReactions = (from x in male.Decisions
                                      select x.Value).ToArray();

            string[] femaleReactions = (from x in female.Decisions
                                        select x.Value).ToArray();

            for (int breedReact = 0; breedReact < maleReactions.Length; breedReact++)
            {
                child.Decisions.Add(allBoards[breedReact], BreedReaction(maleReactions[breedReact],
                    femaleReactions[breedReact], mutationFactor));
            }

            return child;
        }

        /// <summary>
        /// Takes two strings and combines them, small mutations happen with chance mutationFactor/mutationFactor+2 chance
        /// </summary>
        /// <param name="maleReact">The Male reactions string for the breeding</param>
        /// <param name="femaleReact">The Female reactions string for the breeding</param>
        /// <param name="mutationFactor">The chance that the child mutates</param>
        /// <returns>Returns the child reaction</returns>
        private static string BreedReaction(string maleReact, string femaleReact, int mutationFactor)
        {
            Random random = new Random();
            string childReact = "";

            for (int breedString = 0; breedString < maleReact.Length; breedString++)
            {
                int ranint = random.Next(0, mutationFactor + 2);
                if (ranint == 0)
                {
                    if (!childReact.Contains(maleReact[breedString]))
                        childReact += maleReact[breedString];
                    else
                        childReact += MutateCharacter(childReact);
                }
                else if (ranint == 1)
                {
                    if (!childReact.Contains(femaleReact.ToCharArray()[breedString].ToString()))
                        childReact += femaleReact[breedString].ToString();
                    else
                        childReact += MutateCharacter(childReact);
                }
                else
                    childReact += MutateCharacter(childReact);

            }

            return childReact;
        }

        /// <summary>
        /// Takes the string and gets a random string that isn't already in the string
        /// </summary>
        /// <param name="childReact">The string to mutate - return can't already in in childReact</param>
        /// <returns>Returns a string that is not already in childReact</returns>
        private static string MutateCharacter(string childReact)
        {
            Random random = new Random();
            int tryPlace = random.Next(0, 9);
            while (childReact.Contains(tryPlace.ToString()))
                tryPlace = random.Next(0, 9);
            return tryPlace.ToString();
        }

        /// <summary>
        /// Using a TicTacToe instance, gets the fitness of the winner
        /// </summary>
        /// <param name="tictactoe">Game to analyze</param>
        /// <returns>Returns the fitness of the winner</returns>
        public static float GetWinnerFitness(TicTacToe tictactoe)
        {
            float rtnFitness = 0.0f;
            // TODO: Make more ways to get more fitness - moves needed to win etc.
            rtnFitness += 1.0f;
            return rtnFitness;
        }
    }
}
