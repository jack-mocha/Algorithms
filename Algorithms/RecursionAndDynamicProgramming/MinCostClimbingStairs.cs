using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MinCostClimbingStairs
    {
        public int Execute(int[] cost)
        {
            var memo = new Dictionary<int, int>();
            var res = MinCost(cost, cost.Length, memo);
            return res;
        }

        private int MinCost(int[] cost, int i, Dictionary<int, int> memo)
        {
            if (i <= 1)
                return 0;

            if (!memo.ContainsKey(i))
            {
                var v1 = MinCost(cost, i - 1, memo) + cost[i - 1];
                var v2 = MinCost(cost, i - 2, memo) + cost[i - 2];
                memo.Add(i, Math.Min(v1, v2));
            }

            return memo[i];
        }
    }
}
