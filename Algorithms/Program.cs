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
            var alg = new BucketSort();
            var numbers = new int[] {  };
            alg.SortAsc(numbers, 3);
            alg.Print(numbers);
        }
    }
}
