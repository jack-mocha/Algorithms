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
            var alg = new MinPathSum();
            var nums = new int[3][]
            {
                new int[]{1,3,1},
                new int[]{1,5,1},
                new int[]{4,2,1},
            };
            var res = alg.Execute(nums);

            Console.WriteLine(res);
        }
    }
}
