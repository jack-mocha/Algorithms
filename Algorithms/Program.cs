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
            var maze = new bool[5][]{
                new bool[] {true,true,true,false,false},
                new bool[] {true,false,true,true,true},
                new bool[] {true,false,true,false,true},
                new bool[] {true,true,false,true,true},
                new bool[] {true,false,true,true,true}
            };

            var game = new RobotInGrid();
            game.GetPath(maze);
            Console.WriteLine("Trials: " + game.Trials);
            game.PrintPath();
            Console.WriteLine("==============================");
            game.GetPathDP(maze);
            Console.WriteLine("DP Trials: " + game.Trials);
            game.PrintPath();
            Console.WriteLine("==============================");
            game.GetPathBackTracking(maze);
            Console.WriteLine("DP Trials: " + game.Trials);
            game.PrintPath();
        }
    }
}
