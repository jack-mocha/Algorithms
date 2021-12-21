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
            var alg = new WordBreak();
            var words = new string[]
            { "leet","code"};
            var res = alg.ExecuteTopDown("leetcode", words);
            Console.WriteLine(res);
        }
    }
}
