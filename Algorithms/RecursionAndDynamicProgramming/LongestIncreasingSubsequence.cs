using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            var max = Int32.MinValue;
            foreach (var m in dp)
                max = Math.Max(m, max);

            return max;
        }

        public int LengthOfLISTopDown(int[] nums)
        {
            var memo = new int[nums.Length];
            Array.Fill(memo, 1);

            var max = Int32.MinValue;
            for(int i = nums.Length - 1; i >= 0; i--)
                max = Math.Max(max, DP(nums, i, memo));

            return max;
        }
        
        private int DP(int[] nums, int i, int[] memo)
        {
            //if (i == 0)
            //    return 1;

            //if (i < 0)
            //    return 0;

            if(memo[i] == 1)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] > nums[j]) //Because of this condition, we need a for loop in LengthOfLISTopDown to iterate through all items.
                        memo[i] = Math.Max(memo[i], DP(nums, j, memo) + 1);
                }
            }

            return memo[i];
        }
    }
}
