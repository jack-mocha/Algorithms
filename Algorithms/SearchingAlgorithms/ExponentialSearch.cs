using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SearchingAlgorithms
{
    public class ExponentialSearch
    {
        //Time: O(log i), i is the index of the element in the array.
        //Once we find the range, we use binary search to look for the target.
        public int Find(int[] numbers, int target)
        {
            var bound = 1;
            while (bound < numbers.Length && numbers[bound] < target)
                bound *= 2;

            var left = bound / 2;
            var right = Math.Min(bound, numbers.Length - 1);

            var index = Array.BinarySearch(numbers, left, right - left + 1, target);
            return index < 0 ? -1 : index;
        }
    }
}
