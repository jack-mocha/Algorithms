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
            var alg = new MinimumDifficuotyOfAJobSchedule();
            var jobDifficulty = new int[] { 7, 1, 5, 3 };
            var difficulty = alg.MinDifficulty(jobDifficulty, 3);
            Console.WriteLine(difficulty);
        }
    }
}
