using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    //Time: O(n^2) both best and worst cases.
    //The idea is to find the min in every iteration and push it to the left(sorted area).
    public class SelectionSort : Sort
    {
        public void SortAsc(int[] numbers)
        {
            SortAsc(numbers, 0);
        }

        //Same idea as SortAsc2. I just replaced the first for loop with recursion.
        private void SortAsc(int[] numbers, int index)
        {
            if (index == numbers.Length)
                return;

            var minIndex = index;
            for(int i = index; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[minIndex])
                    minIndex = i;
            }
            Swap(numbers, index, minIndex);

            SortAsc(numbers, index + 1);
        }

        public void SortAsc2(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++) //This for loop holds number of passes
            {
                var minIndex = i; //minIndex should start at i not 0.
                for (int j = i; j < numbers.Length; j++) //j should start at i because before i, items are already sorted.
                    if (numbers[j] < numbers[minIndex]) //Swap < with > then you get SortDesc.
                        minIndex = j;
                Swap(numbers, i, minIndex);
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
