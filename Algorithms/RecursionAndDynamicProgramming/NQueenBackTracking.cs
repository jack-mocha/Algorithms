using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class NQueenBackTracking
    {
        private const int GridSize = 8;
        public bool SolveNQ()
        {
            var board = new int[GridSize, GridSize];

            if(SolveNQUtil(board, 0))
            {
                PrintSolution(board);
                return true;
            }

            Console.WriteLine("Solution does not exist.");
            return false;
        }

        private bool SolveNQUtil(int[,] board, int col)
        {
            if (col >= GridSize)
                return true;

            for(int i = 0; i < GridSize; i++)
            {
                if(IsSafe(board, i, col))
                {
                    board[i, col] = 1;
                    
                    if (SolveNQUtil(board, col + 1))
                        return true;

                    board[i, col] = 0; //backtrack
                }
            }

            return false;
        }

        //Only need to check left side for attacking queens
        private bool IsSafe(int[,] board, int row, int col)
        {
            int i, j;
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            //check upper diagonal on left side
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            //check lower diagonal on left side
            for (i = row, j = col; j >= 0 && i < GridSize; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        private void PrintSolution(int[,] board)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                    Console.Write(" " + board[i, j]
                                      + " ");
                Console.WriteLine();
            }
        }
    }
}
