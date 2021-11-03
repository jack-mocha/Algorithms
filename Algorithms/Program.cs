using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new PermutationsWithDups();
            var result = game.GetAllPermutations2("abcc");
            game.PrintAllPermutations(result);
        }
    }
}
