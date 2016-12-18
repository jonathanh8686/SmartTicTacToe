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
        public void Move(Coord movePos)
        {
            board[movePos.x, movePos.y] = pturn;
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
        public int CheckWinner()
        {
            for (int a = 0; a < 2; a++)
            {
                for (int i = 0; i < 3; i++)
                {
                    // Horizontal Victory
                    if (board[i, 0] == a && board[i, 1] == a && board[i, 2] == a)
                        return a;

                    // Vertical Victory
                    if (board[0, i] == a && board[1, i] == a && board[2, i] == a)
                        return a;
                }

                //Top Left - Bottom Right
                if (board[0, 0] == a && board[1, 1] == a && board[2, 2] == a)
                    return a;

                // Top Right - Bottom Left
                if (board[0, 2] == a && board[1, 1] == a && board[2, 0] == a)
                    return a; 
            }

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

        /// <summary>
        /// Gets the state of the board in a way the AI would understand
        /// </summary>
        /// <returns>Returns the state of the board as a string</returns>
        public string GetBoardState()
        {
            string boardState = "";
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    boardState += board[i, j];
            return boardState;
        }
    }
}
