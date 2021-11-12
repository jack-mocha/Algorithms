using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    //Best Case: O(n)
    //Worst Case: O(n^2)
    //The idea is to insert the current element to the right position by moving bigger numbers from the LHS of current to the right in each iteration.
    public class InsertionSort : Sort
    {
        public void SortAsc(int[] numbers)
        {
            var sortedTail = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(i > sortedTail) //Can eliminate this by starting from i = 1 in the above for loop.
                {
                    var current = numbers[i];
                    var sortedIdx = sortedTail;
                    while(sortedIdx >= 0 && current < numbers[sortedIdx])
                    {
                        numbers[sortedIdx + 1] = numbers[sortedIdx];
                        numbers[sortedIdx] = current;
                        sortedIdx--;
                    }

                    sortedTail++;
                }
            }
        }

        //This is a cleaner approach by eliminating some redundnat lines of SortAsc().
        public void SortAsc2(int[] numbers)
        {
            for(int i = 1; i < numbers.Length; i++)
            {
                var current = numbers[i];
                var sortedIdx = i - 1;
                while (sortedIdx >= 0 && numbers[sortedIdx] > current)
                {
                    numbers[sortedIdx + 1] = numbers[sortedIdx];
                    sortedIdx--;
                }
                numbers[sortedIdx + 1] = current;
            }
        }
    }
}
