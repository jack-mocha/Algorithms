using Algorithms.RecursionAndDynamicProgramming;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //var game = new EightQueens();
            //game.PlaceQueens();

            var game = new NQueenBackTracking();
            game.SolveNQ();
        }
    }
}
