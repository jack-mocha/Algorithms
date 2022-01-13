using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MaximumLengthOfRepeatedSubarray
    {
        private int[] nums1;
        private int[] nums2;
        public int FindLength(int[] nums1, int[] nums2)
        {
            //return FindLengthTopDown(nums1, nums2);
            return FindLengthBottomUp(nums1, nums2);

        }

        public int FindLengthBottomUp(int[] nums1, int[] nums2)
        {
            int ans = 0;
            int[][] memo = new int[nums1.Length + 1][];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = new int[nums2.Length + 1];

            for (int i = nums1.Length - 1; i >= 0; --i)
            {
                for (int j = nums2.Length - 1; j >= 0; --j)
                {
                    if (nums1[i] == nums2[j])
                    {
                        memo[i][j] = memo[i + 1][j + 1] + 1;
                        if (ans < memo[i][j]) ans = memo[i][j];
                    }
                }
            }
            return ans;
        }

        public int FindLengthTopDown(int[] nums1, int[] nums2)
        {
            this.nums1 = nums1;
            this.nums2 = nums2;

            var memo = new int[this.nums1.Length][];
            for (int i = 0; i < this.nums1.Length; i++)
                memo[i] = new int[this.nums2.Length];

            var max = Int32.MinValue;
            for (int i = 0; i < nums1.Length; i++)
                for (int j = 0; j < nums2.Length; j++)
                    max = Math.Max(max, DP(i, j, memo));

            return max;
        }

        private int DP(int i, int j, int[][] memo)
        {
            if (i == nums1.Length || j == nums2.Length)
                return 0;

            if (memo[i][j] == 0)
            {
                if (nums1[i] == nums2[j])
                    memo[i][j] = DP(i + 1, j + 1, memo) + 1;
            }

            return memo[i][j];
        }

        private void Print(int[][] memo)
        {
            for(int i = 0; i < memo.Length; i++)
                for(int j = 0; j < memo[i].Length; j++)
                    //for(int k = 0; k < memo[i][j].Length; k++)
                        Console.WriteLine($"i: {i}, j: {j}, value: {memo[i][j]}");
                        //Console.WriteLine($"i: {i}, j: {j}, holding: {k}, value: {memo[i][j][k]}");
        }
    }
}
