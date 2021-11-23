using Algorithms.RecursionAndDynamicProgramming;
using Algorithms.SearchingAlgorithms;
using Algorithms.SearchingAlgorithms.Problems;
using Algorithms.SortingAlgorithms.Problems;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var alg = new SearchInRotatedArray();
            var numbers = new int[] { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };
            var index = alg.Find(numbers, 3);
            Console.WriteLine(index);
        }
    }
}
