using System;
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
        private void Move(Coord movePos)
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
        /// <returns>Returns 0 for X Win, 1 for Y Win, and 2 for No Winner (3 for Tie)</returns>
        private int CheckWinner()
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

            bool isTie = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == 2)
                        isTie = false;
            if (isTie)
                return 3;

            return 2;
        }

        /// <summary>
        /// Prints out the board
        /// </summary>
        private void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(board[i, j] + " ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets the state of the board in a way the AI would understand
        /// </summary>
        /// <returns>Returns the state of the board as a string</returns>
        private string GetBoardState()
        {
            string boardState = "";
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    boardState += board[i, j];
            return boardState;
        }

        /// <summary>
        /// Plays a game between two AI's
        /// </summary>
        /// <param name="ai1">Player 1</param>
        /// <param name="ai2">Player 2</param>
        /// <returns>1 for X win, 2 for O win, 3 for Tie</returns>
        public int PlayGame(AI ai1, AI ai2)
        {
            while (CheckWinner() == 2)
            {
                Move(ai1.GetMove(GetBoardState()));
                if (CheckWinner() != 2)
                    break;
                Move(ai2.GetMove(GetBoardState()));
            }
            PrintBoard();
            return CheckWinner();
        }
    }
}
