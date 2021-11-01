using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3 };
            var game = new PowerSet();
            var subsets = game.GetSubsets(numbers);
            game.PrintSubsets(subsets);
        }
    }
}
