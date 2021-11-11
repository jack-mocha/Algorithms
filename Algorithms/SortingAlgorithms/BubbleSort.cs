using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    //Best case: O(1) e.g. [1,2,3]
    //Worst case: O(n^2) e.g. [3,2,1]
    public class BubbleSort : Sort
    {
        //Optimization 1: If the array is already sorted or partially sorted, no need to compare.
        //Optimization 2: Each iteration i, one item is push to the right position. No need to compare that item again.
        public void Sort(int[] numbers)
        {
            bool isSorted;
            for(int i = 0; i < numbers.Length; i++)
            {
                isSorted = true; //We assume the array is sorted in every iteration. This optimize the first for loop
                for(int j = 1; j < numbers.Length - i; j++) //Each iteration i, we push 1 item to the right position. Therefore, we do not need to compare it again. This optimize the 2nd for loop.
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        Swap(numbers, j, j - 1);
                        isSorted = false;
                    }
                }
                
                if (isSorted) //When no swap happens in the loop, everything is sorted.
                    return;
            }
        }

        private void Swap(int[] numbers, int i, int j)
        {
            var temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
