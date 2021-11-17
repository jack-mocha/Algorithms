using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SearchingAlgorithms
{
    public class BinarySearch
    {
        //Returns the index of the target, if it is found.
        public int SearchRecursive(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;

            return SearchRecursive(numbers, 0, numbers.Length - 1, target);
        }

        private int SearchRecursive(int[] numbers, int start, int end, int target)
        {
            if (end < start)
                return -1;

            var middle = (start + end) / 2;

            if (numbers[middle] == target)
                return middle;

            if (numbers[middle] > target)
                return SearchRecursive(numbers, start, middle - 1, target);

            return SearchRecursive(numbers, middle + 1, end, target);
        }

        public int SerachIterative(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while(left <= right)
            {
                var middle = (left + right) / 2;
                if (numbers[middle] == target)
                    return middle;

                if (target < numbers[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }
    }
}
