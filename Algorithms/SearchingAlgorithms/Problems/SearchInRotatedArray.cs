using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SearchingAlgorithms.Problems
{
    public class SearchInRotatedArray
    {
        private int count;
        public int Find(int[] numbers, int target)
        {
            return Find2(numbers, target, 0, numbers.Length - 1);
        }


        //The idea is modify binary search so that it search both left and right.
        //If you look at the count, you'll see that this is not a very good algorithm. Worst case converge to O(n)
        private int Find(int[] numbers, int target, int left, int right)
        {
            if (right < left)
                return -1;

            count++;
            var mid = (left + right) / 2;
            if (numbers[mid] == target)
                return mid;

            int leftResult = Find(numbers, target, left, mid - 1);
            if (leftResult >= 0)
                return leftResult;

            int rightResult = Find(numbers, target, mid + 1, right);
            return rightResult;
        }

        //Better performance than Find()
        //O(log n) when all elements are unique.
        //O(n) when there are many duplicates
        private int Find2(int[] numbers, int target, int left, int right)
        {
            if (right < left)
                return -1;

            count++;
            var middle = (left + right) / 2;
            if (numbers[middle] == target)
                return middle;

            if(numbers[left] < target) //Left is normally ordered
            {
                if (numbers[left] <= target && target < numbers[middle])
                    return Find2(numbers, target, left, middle - 1); //search left
                else
                    return Find2(numbers, target, middle + 1, right); //search right
            }
            else if(numbers[middle] < numbers[right]) //Right is normally ordered
            {
                if (numbers[middle] < target && target <= numbers[right])
                    return Find2(numbers, target, middle + 1, right); //search right
                else
                    return Find2(numbers, target, left, middle - 1); //search left
            }
            else
            {
                var location = -1;
                if (numbers[left] == numbers[middle]) //e.g. {30, , , , 30, , , , 25} 
                    location = Find2(numbers, target, middle + 1, right); //search right

                if (location == -1 && numbers[middle] == numbers[right]) //e.g. {40, , , , 30, , , , 30} or {30, , , , 30, , , , 30} 
                    location = Find2(numbers, target, left, middle - 1);

                return location;
            }
        }

    }
}
