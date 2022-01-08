using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class PaintHouseIII
    {
        private int colors;
        private int[][] cost;
        private int[] houses;
        public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
        {
            this.colors = n;
            this.cost = cost;
            this.houses = houses;

            //Initialize memo
            var memo = new int[m][][];
            for (int i = 0; i < m; i++)
            {
                memo[i] = new int[target][];
                for (int j = 0; j < memo[i].Length; j++)
                    memo[i][j] = new int[n];
            }
            var lowest = Int32.MaxValue;
            for (int i = colors - 1; i >= 0; i--)
            {
                var current = 0;
                if (houses[houses.Length - 1] != 0) //Since the last house was painted already, no need to try a different color.
                    current = DP(m - 1, target - 1, houses[houses.Length - 1] - 1, memo);
                else
                    current = DP(m - 1, target - 1, i, memo);

                if (current != -1)
                    lowest = Math.Min(lowest, current);
            }

            Print(memo);
            return lowest == Int32.MaxValue ? -1 : lowest;
        }

        private void Print(int[][][] memo)
        {
            for(int i = 0; i < memo.Length; i++)
                for(int j = 0; j < memo[i].Length; j++)
                    for(int k = 0; k < memo[i][j].Length; k++)
                        Console.WriteLine("i: {0}, j: {1}, k: {2}, value: {3}", i, j, k, memo[i][j][k]);
        }

        //Returns min cost of i houses, n neighborhoods, where the ith house is painted the selected color.
        private int DP(int i, int t, int curColor, int[][][] memo)
        {
            if (i < 0 && t != 0)
                return -1;
            else if (i < 0 && t == 0)
                return 0;

            if (t < 0)
                return -1;

            if (memo[i][t][curColor] == 0)
            {
                var lowest = Int32.MaxValue;
                if (i - 1 >= 0 && houses[i - 1] != 0) //Previous house was painted already
                {
                    var preValue = 0;
                    if (curColor == houses[i - 1] - 1)
                        preValue = DP(i - 1, t, curColor, memo);
                    else
                        preValue = DP(i - 1, t - 1, houses[i - 1] - 1, memo);

                    if (preValue != -1) //Since we are using Math.Min, preserve preValue as Int32.MaxValue when it equals to -1.
                        lowest = houses[i] != 0 ? preValue : cost[i][curColor] + preValue;
                }
                else
                {
                    var preValue = 0;
                    for (int j = 0; j < colors; j++)
                    {
                        if (i == 0) //Since when i - 1 == -1, t should stay the same.
                            preValue = DP(i - 1, t, j, memo);
                        else if (j == curColor)
                            preValue = DP(i - 1, t, j, memo);
                        else
                            preValue = DP(i - 1, t - 1, j, memo);

                        if (preValue != -1)
                            lowest = houses[i] != 0 ? Math.Min(lowest, preValue) : Math.Min(lowest, cost[i][curColor] + preValue);
                    }
                }

                memo[i][t][curColor] = lowest == Int32.MaxValue ? -1 : lowest;
            }

            return memo[i][t][curColor];
        }
    }
}
