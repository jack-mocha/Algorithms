using Algorithms.RecursionAndDynamicProgramming;
using Algorithms.SortingAlgorithms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var alg = new BubbleSort();
            var numbers = new int[] { 8, 2, 4, 1, 3 };
            alg.Sort(numbers);
            alg.Print(numbers);
        }
    }
}
