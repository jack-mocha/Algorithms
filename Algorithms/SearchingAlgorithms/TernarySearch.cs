using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SearchingAlgorithms
{
    //Time: O(log base 3 of n)
    //BinarySearch is faster than TernarySearch because BinarySearch has less comparison.
    public class TernarySearch
    {
        public int Find(int[] numbers, int target)
        {
            return Find(numbers, target, 0, numbers.Length - 1);
        }

        private int Find(int[] numbers, int target, int left, int right)
        {
            if (right < left)
                return -1;

            var partitionSize = (right - left) / 3;
            var mid1 = left + partitionSize;
            var mid2 = right - partitionSize;

            if (target == numbers[mid1])
                return mid1;
            if (target == numbers[mid2])
                return mid2;
            if (target < numbers[mid1])
                return Find(numbers, target, left, mid1 - 1);
            if (target > numbers[mid2])
                return Find(numbers, target, mid2 + 1, right);

            return Find(numbers, target, mid1 + 1, mid2 - 1);
        }
    }
}
