using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Coins();
            var ways = game.GetNumOfWaysToRepresent(10);
            Console.WriteLine(ways);
        }
    }
}
