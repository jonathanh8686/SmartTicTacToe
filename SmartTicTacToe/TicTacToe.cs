﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTicTacToe
{
    /// <summary>
    /// Used to create instances of game
    /// The "Main Game" class
    /// </summary>
    class TicTacToe
    {
        // Class used as the main game class
        // Create instances of game

        int[,] board = new int[3, 3];
        int pturn = 0; // 0 = X's Turn  1 = O's Turn
        /// <summary>
        /// Initalizes the board to all = 3
        /// </summary>
        public TicTacToe()
        {
            // Code used for initalizing the board - All values as 2
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = 2;
        }

        /// <summary>
        /// Gets the position to set = to pturn and makes a move there
        /// </summary>
        /// <param name="xpos">X Coord for move</param>
        /// <param name="ypos">Y Coord for move</param>
        public void Move(int xpos, int ypos)
        {
            board[xpos, ypos] = pturn;
            if (pturn == 0)
                pturn = 1;
            else
                pturn = 0;

            if (CheckWinner() != 2)
                Console.WriteLine(CheckWinner());
        }

        /// <summary>
        /// Check if there is a winner in the board
        /// </summary>
        /// <returns>Returns 0 for X Win, 1 for Y Win, and 2 for No Winner</returns>
        private int CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                // Horizontal Victory
                if (board[i, 0] != 2 && board[i, 1] != 2 && board[i, 2] != 2)
                    return board[i, 0];

                // Vertical Victory
                if (board[0, i] != 2 && board[1, i] != 2 && board[2, i] != 2)
                    return board[0, i];
            }

            //Top Left - Bottom Right
            if (board[0, 0] != 2 && board[1, 1] != 2 && board[2, 2] != 2)
                return board[0, 0];

            // Top Right - Bottom Left
            if (board[0, 2] != 2 && board[1, 1] != 2 && board[2, 0] != 2)
                return board[0, 2];

            return 2;
        }

        /// <summary>
        /// Prints out the board
        /// </summary>
        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}