using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MaxSubarraySumCircular
    {
        public int Execute(int[] nums)
        {
            var curMax = nums[0];
            var maxSum = nums[0];
            var curMin = nums[0];
            var minSum = nums[0];
            var total = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                var n = nums[i];
                curMax = Math.Max(curMax + n, n);
                maxSum = Math.Max(curMax, maxSum);

                curMin = Math.Min(curMin + n, n);
                minSum = Math.Min(curMin, minSum);

                total = total + n;
            }

            //When all elements are negative
            if (total - minSum == 0)
                return maxSum;

            return Math.Max(maxSum, total - minSum);

        }

        public int MaxSubarraySumCircular2(int[] nums)
        {
            var curMax = nums[0];
            var maxSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                curMax = Math.Max(curMax + nums[i], nums[i]);
                maxSum = Math.Max(curMax, maxSum);
            }

            var n = nums.Length;
            var rightSums = new int[n];
            rightSums[n - 1] = nums[n - 1];
            var maxRightSums = new int[n];
            maxRightSums[n - 1] = nums[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rightSums[i] = rightSums[i + 1] + nums[i];
                maxRightSums[i] = Math.Max(rightSums[i], maxRightSums[i + 1]);
            }

            var leftSum = 0;
            for (int i = 0; i < n - 2; i++)
            {
                leftSum += nums[i];
                maxSum = Math.Max(maxSum, leftSum + maxRightSums[i + 2]);
            }

            return maxSum;
        }
    }
}
