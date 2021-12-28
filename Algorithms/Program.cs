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
            var alg = new MaxSubArray();
            var nums = new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var res = alg.Execute(nums);

            Console.WriteLine(res);
        }
    }
}
