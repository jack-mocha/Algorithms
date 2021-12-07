using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MaximalSquare
    {
        public int FindMaxSquare(char[][] matrix)
        {
            var memo = new int[matrix.Length][];
            for(int i = 0; i < memo.Length; i++)
            {
                var arr = new int[matrix[0].Length];
                for (int j = 0; j < arr.Length; j++)
                    arr[j] = -1;

                memo[i] = arr;
            }
            var max = 0;
            var side = DP(matrix, matrix.Length - 1, matrix[0].Length - 1, memo, ref max);
            Print(memo);
            return max * max;
        }

        private int DP(char[][] matrix, int i, int j, int[][] memo, ref int max)
        {
            if (i < 0 || j < 0)
                return 0;

            if(memo[i][j] == -1)
            {
                var v1 = DP(matrix, i - 1, j, memo, ref max);
                var v2 = DP(matrix, i - 1, j - 1, memo, ref max);
                var v3 = DP(matrix, i, j - 1, memo, ref max);
                memo[i][j] = matrix[i][j] == '0' ? 0 : Math.Min(Math.Min(v1, v2), v3) + (matrix[i][j] - '0');
                //if(memo[i][j] == 3)
                //{
                //    Print(memo);
                //}
                max = Math.Max(max, memo[i][j]);
            }

            return memo[i][j];
        }

        private void Print(int[][] memo)
        {
            foreach(var m in memo)
            {
                foreach(var item in m)
                    Console.Write(item + ", ");
                Console.WriteLine();
            }
        }
    }
}
