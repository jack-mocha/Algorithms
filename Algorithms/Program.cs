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
            var algo = new MaximumLengthOfRepeatedSubarray();
            var nums1 = new int[] { 0,1,1,1,1 };
            var nums2 = new int[] { 1,0,1,0,1 };
            var res = algo.FindLength(nums1, nums2);
            Console.WriteLine(res);
        }
    }
}
