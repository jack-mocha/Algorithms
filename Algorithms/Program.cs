using Algorithms.RecursionAndDynamicProgramming;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new ChildStairsGame();
            var stairs = 5;
            var r1 = game.CountWays(stairs);
            Console.WriteLine("r1: " + r1);
            var r2 = game.CountWaysMemoized(stairs);
            Console.WriteLine("r2: " + r2);
        }
    }
}
