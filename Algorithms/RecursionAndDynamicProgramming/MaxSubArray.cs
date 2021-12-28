using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MaxSubArray
    {
        public int Execute(int[] nums)
        {
            ////DP Top Down
            //var memo = new int[nums.Length];
            //var max = Int32.MinValue;
            //for (int i = 0; i < nums.Length; i++)
            //    max = Math.Max(max, DP(nums, i, memo));

            //return max;

            ////DP Bottom Up
            //var memo = new int[nums.Length];
            //return DPBottomUp(nums, memo);

            ////Kadane's Alg
            return Kadane(nums);
        }

        private int DP(int[] nums, int i, int[] memo)
        {
            if (i == nums.Length)
                return 0;

            if (memo[i] == 0)
            {
                var v1 = nums[i] + DP(nums, i + 1, memo);
                var v2 = nums[i];
                memo[i] = v1 > v2 ? v1 : v2;
            }

            return memo[i];
        }

        private int DPBottomUp(int[] nums, int[] memo)
        {
            memo[nums.Length - 1] = nums[nums.Length - 1];
            var max = Int32.MinValue;

            for(int i = nums.Length - 2; i >= 0; i--)
            {
                var v1 = nums[i] + memo[i + 1];
                var v2 = nums[i];
                memo[i] = v1 > v2 ? v1 : v2;

                max = Math.Max(max, memo[i]);
            }
            
            max = Math.Max(max, memo[nums.Length - 1]);
            return max;
        }

        //Kadane's Algorithm
        private int Kadane(int[] nums)
        {
            // Initialize our variables using the first element.
            int currentSubarray = nums[0];
            int maxSubarray = nums[0];

            // Start with the 2nd element since we already used the first one.
            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];
                // If current_subarray is negative, throw it away. Otherwise, keep adding to it.
                currentSubarray = Math.Max(num, currentSubarray + num);
                maxSubarray = Math.Max(maxSubarray, currentSubarray);
            }

            return maxSubarray;
        }
    }
}
