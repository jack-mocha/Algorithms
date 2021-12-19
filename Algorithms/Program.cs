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
            var alg = new LongestIncreasingSubsequence();
            var nums = new int[]
            { 10, 9, 2, 5, 3, 7, 101, 18};
//{ 1, 3, 6, 7, 9, 4, 10, 5, 6};
            //var res = alg.LengthOfLIS(nums);
            var res = alg.LengthOfLISTopDown(nums);
            Console.WriteLine(res);
        }
    }
}
