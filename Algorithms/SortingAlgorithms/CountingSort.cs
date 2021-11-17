using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    //This is a Non-Comparison Sort
    //Space: O(k), k is the maximum value of the array
    //Time: Populate counts: O(n) + Iterate counts: O(k) = O(n + k) ~= O(n)
    //Time memory trade off.
    //Limitation: (1)Allocating extra space is not an issue
    //(2)Values are positive intergers
    //(3)Most of the values in the range are present
    public class CountingSort : Sort
    {
        public void SortAsc(int[] numbers)
        {
            if (numbers.Length == 0)
                return;

            var max = FindMax(numbers);
            var map = GenerateMap(numbers, max);
            Populate(numbers, map);
        }

        public int FindMax(int[] numbers)
        {
            var max = Int32.MinValue;
            foreach (var n in numbers)
                if (n > max)
                    max = n;

            return max;
        }

        public int[] GenerateMap(int[] numbers, int max)
        {
            var map = new int[max + 1];
            foreach(var n in numbers)
                map[n]++;

            return map;
        }

        public void Populate(int[] numbers, int[] map)
        {
            var index = 0;
            for(int i = 0; i < map.Length; i++)
            {
                var counter = map[i];
                while(counter > 0)
                {
                    numbers[index++] = i;
                    counter--;
                }
            }
        }
    }
}
