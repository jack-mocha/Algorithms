using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MinPathSum
    {
        private int[][] grid;
        public int Execute(int[][] grid)
        {
            this.grid = grid;
            var row = grid.Length;
            var col = grid[0].Length;
            var map = new int[row][];
            for (int i = 0; i < row; i++)
            {
                map[i] = new int[col];
                Array.Fill(map[i], Int32.MaxValue);
            }

            return DP(row - 1, col - 1, map);
        }

        private int DP(int row, int col, int[][] map)
        {
            if (row < 0 || col < 0)
                return 0;

            if (map[row][col] == Int32.MaxValue)
            {
                var min = 0;
                if(row - 1 < 0)
                    min = DP(row, col - 1, map);
                else if (col - 1 < 0)
                    min = DP(row - 1, col, map);
                else
                    min = Math.Min(DP(row - 1, col, map), DP(row, col - 1, map));

                map[row][col] = min + this.grid[row][col];
            }

            return map[row][col];
        }
    }
}
