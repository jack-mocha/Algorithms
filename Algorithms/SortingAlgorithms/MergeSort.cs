using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    public class MergeSort : Sort
    {
        //It is a Divide and Conquer algorithm.
        //Recursively divide a problem into smaller subproblems until it is easy to solve, and combine the solution to build the solution to the original problem.
        //Dividing: Best: O(log n) Worst: O(log n)
        //Merging: Best: O(n) Worst: O(n)
        //Total: Best: O(n logn n) Worst: O(n log n)
        //Space: O(n)
        //Note: Merge sort typically requires additional space. However, there is a in-place Merge Sort algorithm
        public void SortAsc(int[] numbers)
        {
            SortAscEx(numbers);
        }

        //This is a top-down recursion
        //Top-down recursion is like a tree. The original problem is the root. Subproblems are children
        //And you perform a depth first approach.
        private int[] SortAscEx(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers;

            var mid = numbers.Length / 2;
            var left = new int[mid];
            Array.Copy(numbers, left, mid);

            var right = new int[numbers.Length - mid];
            Array.Copy(numbers, mid, right, 0, numbers.Length - mid);
            
            left = SortAscEx(left);
            right = SortAscEx(right);

            var fIdx = 0;
            var sIdx = 0;
            var nIdx = 0;
            while(fIdx != left.Length && sIdx != right.Length)
            {
                if (left[fIdx] < right[sIdx])
                {
                    numbers[nIdx] = left[fIdx];
                    fIdx++;
                }
                else
                {
                    numbers[nIdx] = right[sIdx];
                    sIdx++;
                }
                nIdx++;
            }

            if(fIdx != left.Length)
            {
                for(int i = fIdx; i < left.Length; i++)
                {
                    numbers[nIdx] = left[fIdx];
                    nIdx++;
                }
            }
            else
            {
                if (sIdx != right.Length)
                {
                    for (int i = sIdx; i < right.Length; i++)
                    {
                        numbers[nIdx] = right[sIdx];
                        nIdx++;
                    }
                }
            }

            return numbers;
        }

        //Same logic as SortAsc, but a cleaner syntax
        public void SortAsc2(int[] numbers)
        {
            //Base Condition
            if (numbers.Length == 1)
                return;

            //Divide the array in half.
            var mid = numbers.Length / 2;
            var left = new int[mid];
            Array.Copy(numbers, left, mid);

            var right = new int[numbers.Length - mid];
            Array.Copy(numbers, mid, right, 0, numbers.Length - mid);

            SortAsc2(left); //array is passed by reference, so you don't need to return the array.
            SortAsc2(right);

            //Merge the smaller arrays.
            merge(left, right, numbers);
        }

        private void merge(int[] left, int[] right, int[] result)
        {
            var fIdx = 0;
            var sIdx = 0;
            var rIdx = 0;
            while (fIdx != left.Length && sIdx != right.Length)
            {
                if (left[fIdx] < right[sIdx])
                    result[rIdx++] = left[fIdx++];
                else
                    result[rIdx++] = right[sIdx++];
            }

            while (fIdx < left.Length)
                result[rIdx++] = left[fIdx++];
            while (sIdx < right.Length)
                result[rIdx++] = right[sIdx++];
        }
    }
}
