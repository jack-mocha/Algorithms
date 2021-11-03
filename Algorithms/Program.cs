using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new PermutationsWithoutDups();
            var result = game.GetPerms("abc");
            game.PrintAllPermutations(result);
        }
    }
}
