using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    public class QuickSort : Sort
    {
        //Partitioning: Best: O(n) Worst:O(n)
        //# of times: Best: O(log n) Worst: O(n)
        //Total: Best: O(n log n) Worst: O(n^2)
        //Does not require additional space for copying the array like merge sort, but requires space for recursion calls.
        //Space: Best: O(log n) Worst: O(n), same as # of times.
        //Prefer quick sort than merge sort becaue it doesn't require as much space.
        public void SortAsc(int[] numbers) 
        {
            Partition(numbers, 0, numbers.Length - 1);
        }

        //We pick the last element as the pivot here. You can pick other locations as the pivot
        private void Partition(int[] numbers, int start, int end)
        {
            if (end - start <= 0)
                return;

            var pivot = numbers[end];
            var boundry = start - 1;
            for(int i = start; i < end; i++)
            {
                if(numbers[i] < pivot)
                {
                    boundry++;
                    Swap(numbers, i, boundry);
                }
            }
            boundry++;
            Swap(numbers, end, boundry);

            Partition(numbers, start, boundry - 1);
            Partition(numbers, boundry + 1, end);
        }

        //The logic is the same as SortAsc(), but in a cleaner syntax.
        public void SortAsc2(int[] numbers)
        {
            SortAsc2(numbers, 0, numbers.Length - 1);
        }

        private void SortAsc2(int[] numbers, int start, int end)
        {
            if (end - start < 0)
                return;

            var boundry = Partition2(numbers, start, end); //Partition

            SortAsc2(numbers, start, boundry - 1); //Sort left
            SortAsc2(numbers, boundry + 1, end); //Sort right
        }

        private int Partition2(int[] numbers, int start, int end)
        {
            var pivot = numbers[end];
            var boundry = start - 1;
            for (int i = start; i <= end; i++) // i <= end because end is a valid index(the index of the pivot) not a length
                if (numbers[i] <= pivot) // Add <= because of the above
                    Swap(numbers, i, ++boundry);

            return boundry; //The index of the pivot after it is moved to the correct position.
        }

        private void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
