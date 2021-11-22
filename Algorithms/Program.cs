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
            var alg = new BinarySearch();
            var numbers = new int[] { 7 };
            var index = alg.FindOccurrences(numbers, 6);
            //var index = alg.SerachIterative(numbers, 6);
            Console.WriteLine(index);
        }
    }
}
