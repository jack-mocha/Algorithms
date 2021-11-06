using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new StackOfBox();
            var boxes = new List<Box>()
            {
                new Box{Height = 3, Depth = 3, Width = 3},
                new Box{Height = 1, Depth = 1, Width = 1},
                new Box{Height = 2, Depth = 2, Width = 2},
                new Box{Height = 4, Depth = 4, Width = 1},
                new Box{Height = 5, Depth = 5, Width = 5}
            };

            Console.WriteLine(game.CreateStack(boxes));
            Console.WriteLine(game.CreateStackDP(boxes));
        }
    }
}
