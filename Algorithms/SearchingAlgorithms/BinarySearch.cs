using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SearchingAlgorithms
{
    public class BinarySearch
    {
        //Only works on sorted list
        //Returns the index of the target, if it is found.
        public int SearchRecursive(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;

            return SearchRecursive2(numbers, 0, numbers.Length - 1, target);
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

        //Recursive implementation of SearchIterative2
        private int SearchRecursive2(int[] numbers, int start, int end, int target)
        {
            if (end - start <= 1)
            {
                if (numbers[start] == target)
                    return start;
                if (numbers[end] == target)
                    return end;
                return -1;
            }

            var middle = (start + end) / 2;

            if (numbers[middle] > target)
                return SearchRecursive2(numbers, start, middle, target);

            return SearchRecursive2(numbers, middle, end, target);
        }

        //Number of comparison is Log(2n) = Log(n) + 1
        public int SearchIterative(int[] numbers, int target)
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

        //In the scenario that comparison is expensive, this is one way to reduce the number of comparison to Log(n + 1)
        //The function finds target index and target index + 1.
        //Reference: https://www.geeksforgeeks.org/the-ubiquitous-binary-search-set-1/
        public int SearchIterative2(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length; //consider the target is the last element. This will make left find the last. It does not matter here but matters when you want to prefer left than right.

            while (right - left > 1)
            {
                var middle = (left + right) / 2;

                if (target < numbers[middle]) //prefer left to eventually find the target. If you add '=', it prefers right, except for when the target is the first element.
                    right = middle;
                else
                    left = middle;
            }

            if (numbers[left] == target)
                return left;
            else if (numbers[right] == target)
                return right;
            else
            return -1;
        }

        //The idea is to push the left index to the floor of the target
        //Edge cases:
        //(1) If all elements in the array are smaller than key, left pointer moves till last element.
        //(2) If all elements in the array are greater than key, it is an error condition.
        //(3) If all elements in the array equal and <= key, it is worst case input to our implementation.
        //Reference: https://www.geeksforgeeks.org/the-ubiquitous-binary-search-set-1/
        public int Floor(int[] numbers, int target)
        {
            if (target < numbers[0])
                return -1;

            return Floor(numbers, target, 0, numbers.Length); //It is important that right is numbers.Length.
        }

        private int Floor(int[] numbers, int target, int left, int right)
        {
            while (right - left > 1) //star
            {
                var middle = (left + right) / 2;

                if (target >= numbers[middle]) //star
                    left = middle;
                else
                    right = middle;
            }

            return numbers[left];
        }

        public int FloorRecursive(int[] numbers, int target)
        {
            if (target < numbers[0])
                return -1;

            return FloorRecursive(numbers, target, 0, numbers.Length);
        }

        private int FloorRecursive(int[] numbers, int target, int left, int right)
        {
            if (right - left <= 1)
                return numbers[left];

            var middle = (left + right) / 2;

            if (target >= numbers[middle])
                return FloorRecursive(numbers, target, middle, right);
            else
                return FloorRecursive(numbers, target, left, middle);
        }

        //Given a sorted array with possible duplicate elements. Find number of occurrences of input 'key' in log N time.
        //The idea is to find the left and right most occurrences of the key. Then you know the beginning and the end of the occurrence.
        //
        public int FindOccurrences(int[] numbers, int target)
        {
            if (numbers.Length == 0)
                return 0;

            var left = FindLeftMost(numbers, target);
            var right = FindRightMost(numbers, target);

            //This only finds the closes indices. Check if target can be found.
            return (numbers[left] == target && numbers[right] == target) ? (right - left + 1) : 0;
        }

        private int FindLeftMost(int[] numbers, int target)
        {
            var left = -1;
            var right = numbers.Length - 1; //Because you want the right index to land on the left most occurrence.

            while (right - left > 1)
            {
                var middle = (left + right) / 2;
                if (target <= numbers[middle])
                    right = middle;
                else
                    left = middle;
            }

            return right;
        }

        private int FindRightMost(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length; //Because you want the left index to land on the right most occurrence.

            while (right - left > 1)
            {
                var middle = (left + right) / 2;
                if (target < numbers[middle])
                    right = middle;
                else
                    left = middle;
            }

            return left;
        }
    }
}
