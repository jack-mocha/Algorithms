using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class PaintFence
    {
        private int k;
        public int NumWays(int n, int k)
        {
            this.k = k;
            var memo = new int[n + 1];
            return DP(n, memo);
        }

        private int DP(int i, int[] memo)
        {
            if (i == 1)
                return k;
            if (i == 2)
                return k * k;

            if (memo[i] == 0)
            {
                //1 * T(i - 1), where color(i - 1) is different from color(i - 2). Since DP(i) represents all differnt ways of painting i fences, we need to come up with a new equation.
                var sameColor = (k - 1) * DP(i - 2, memo);
                var diffColor = (k - 1) * DP(i - 1, memo);
                memo[i] = sameColor + diffColor;
            }

            return memo[i];
        }
    }
}
