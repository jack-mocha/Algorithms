using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MagicIndex
    {
        public int Trials { get; private set; }

        //If numbers[i] = i, i is the magic index.
        //Array is sorted, and only has distinct values.
        //Brute Force approch. 
        //Time: O(n)
        public int FindMagicIndex(int[] numbers)
        {
            Trials = 0;
            if (numbers == null || numbers.Length == 0)
                return -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                Trials++;
                if (numbers[i] == i)
                    return i;
            }

            return -1;
        }

        //Time: O(log n)
        public int FindMagicIndexBST(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;

            Trials = 0;
            return FindMagicIndexBST(numbers, 0, numbers.Length - 1);
        }

        private int FindMagicIndexBST(int[] numbers, int start, int end)
        {
            Trials++;
            if (end < start)
                return -1;

            var middle = (start + end) / 2;
            if (numbers[middle] == middle)
                return middle;

            if (numbers[middle] > middle)
                return FindMagicIndexBST(numbers, start, middle - 1);

            return FindMagicIndexBST(numbers, middle + 1, end);
        }

        //Numbers are non-distinct, but sorted.
        //Target can be on either side of the middle value.
        //Therefore, we first compare midIndex and midValue. Then we recursively search left and right sides.
        public int FindMagicIndexNonDistinct(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;

            Trials = 0;
            return FindMagicIndexNonDistinct(numbers, 0, numbers.Length - 1);
        }

        private int FindMagicIndexNonDistinct(int[] numbers, int start, int end)
        {
            Trials++;
            if (end < start)
                return -1;

            var midIndex = (start + end) / 2;
            var midValue = numbers[midIndex];

            if (midIndex == midValue)
                return midIndex;

            //Search Left
            var leftIndex = Math.Min(midIndex - 1, midValue);
            var left = FindMagicIndexNonDistinct(numbers, start, leftIndex);
            if (left > 0)
                return left;

            //Search Right
            var rightIndex = Math.Max(midIndex + 1, midValue);
            var right = FindMagicIndexNonDistinct(numbers, rightIndex, end);

            return right;
        }
    }
}
