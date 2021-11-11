using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    public abstract class Sort
    {
        public void Print(int[] numbers)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for(int i = 0; i < numbers.Length; i++)
            {
                sb.Append(numbers[i]);
                if (i == numbers.Length - 1)
                    sb.Append("]");
                else
                    sb.Append(", ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
