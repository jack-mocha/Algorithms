using Algorithms.RecursionAndDynamicProgramming;
using Algorithms.SearchingAlgorithms;
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
            var alg = new TernarySearch();
            var numbers = new int[] { 1, 3, 8, 7, 2 };
            var index = alg.Find(numbers, 7);
            Console.WriteLine(index);
        }
    }
}
