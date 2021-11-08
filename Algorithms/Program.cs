using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new PermutationsWithoutDups();
            var result = game.GetPerms2("abc");
            game.PrintAllPermutations(result);
        }
    }
}
