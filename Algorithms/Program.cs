using Algorithms.RecursionAndDynamicProgramming;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { -5, -3, 0, 3, 5, 10, 20, 27, 30, 35 };
            var game = new MagicIndex();
            Console.WriteLine($"Brout Force: {game.FindMagicIndex(numbers)}, Trials: {game.Trials}");
            Console.WriteLine($"BST Approach: {game.FindMagicIndexBST(numbers)}, Trials: {game.Trials}");

            var nonDistinctNumbers = new int[] { -10, -5, 2, 2, 2, 3, 4, 5, 9, 12, 13 };
            Console.WriteLine($"Non-Distinc Numbers: {game.FindMagicIndexNonDistinct(nonDistinctNumbers)}, Trials: {game.Trials}");
        }
    }
}
