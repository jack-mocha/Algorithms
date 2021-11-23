using Algorithms.RecursionAndDynamicProgramming;
using Algorithms.SearchingAlgorithms;
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
            var alg = new SortedMerge();
            var large = new int[] { 1, 3, 8, 0, 0 };
            var small = new int[] { 2, 7 };
            alg.Merge(large, small);
        }
    }
}
