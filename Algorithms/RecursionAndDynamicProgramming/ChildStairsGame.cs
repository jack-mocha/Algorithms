using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class ChildStairsGame
    {
        //Top Down Recursive
        public int CountWays(int stairs)
        {
            if (stairs < 0)
                return 0;
            if (stairs == 0)
                return 1;

            //We multiply the values when it is "we do this then this".
            //We add them when it is "we do this or this".
            return CountWays(stairs - 1) + CountWays(stairs - 2) + CountWays(stairs - 3);
        }

        public int CountWaysMemoized(int stairs)
        {
            return CountWaysMemoized(stairs, new int[stairs + 1]);
        }

        //Top Down Dynamic Programming (Memoization)
        //We shouldn't recalculate the same value. Therefore, we cache the already calculated value.
        //When stairs is 37, it will overflow int32.
        private int CountWaysMemoized(int stairs, int[] memo)
        {
            if (stairs < 0)
                return 0;
            if (stairs == 0)
                return 1;

            if(memo[stairs] == 0)
                memo[stairs] = CountWaysMemoized(stairs - 1, memo) + CountWaysMemoized(stairs - 2, memo) + CountWaysMemoized(stairs - 3, memo);

            return memo[stairs];
        }
    }
}
