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
            var alg = new MaximalSquare();
            //var matrix = new char[2][]
            //{
            //    new char[] {'1', '1'},
            //    new char[] {'1', '0'}
            //};
            var matrix = new char[6][]
            {
                new char[] { '1', '0', '1', '1', '0', '1' },
                new char[] { '1', '1', '1', '1', '1', '1' },
                new char[] { '0', '1', '1', '0', '1', '1' },
                new char[] { '1', '1', '1', '0', '1', '0' },
                new char[] { '0', '1', '1', '1', '1', '1' },
                new char[] { '1', '1', '0', '1', '1', '1' }
            };
            var area = alg.FindMaxSquare(matrix);
            Console.WriteLine(area);
        }
    }
}
