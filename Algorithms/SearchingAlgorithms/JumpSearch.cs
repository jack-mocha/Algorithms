using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SearchingAlgorithms
{
    //BlockSize = square root of n
    //Time: O(square root of n)
    //BinarySearch is still faster.
    public class JumpSearch
    {
        public int Find(int[] numbers, int target)
        {
            var blockSize = (int)Math.Floor(Math.Sqrt(numbers.Length));
            var start = 0;
            var next = start + blockSize;
            while(start < numbers.Length && //Edge case
                numbers[next - 1] < target) //Last item of the block
            {
                start = next;
                next = next + blockSize;
                if (next > numbers.Length)
                    next = numbers.Length;
            }

            for(var i = start; i < next; i++)
            {
                if (numbers[i] == target)
                    return i;
            }

            return -1;
        }
    }
}
