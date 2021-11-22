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
            var alg = new ExponentialSearch();
            var numbers = new int[] { 1, 3, 8, 10, 11, 13 };
            var index = alg.Find(numbers, 11);
            Console.WriteLine(index);
        }
    }
}
