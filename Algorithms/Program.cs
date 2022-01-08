using Algorithms.RecursionAndDynamicProgramming;
using Algorithms.SearchingAlgorithms;
using Algorithms.SearchingAlgorithms.Problems;
using Algorithms.SortingAlgorithms.Problems;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var alg = new PaintHouseIII();
            const int m = 5;
            const int n = 2;
            var target = 3;
            //const int m = 4;
            //const int n = 3;
            //var target = 3;
            var houses = new int[m]
            {
                0,2,1,2,0
            };
            var costs = new int[m][]
            {
                new int[n] {1,10},
                new int[n] {10,1},
                new int[n] {10,1},
                new int[n] {1,10},
                new int[n] {5,1}
            };
            //var costs = new int[m][]
            //{
            //    new int[n] {1,5},
            //    new int[n] {4,1},
            //    new int[n] {1,3},
            //    new int[n] {4,4}
            //};

            //var costs = new int[m][]
            //{
            //    new int[n] {1,1,1},
            //    new int[n] {1,1,1},
            //    new int[n] {1,1,1},
            //    new int[n] {1,1,1}
            //};

            //var costs = new int[m][]
            //{
            //    new int[n] {5,4,1},
            //    new int[n] {1,2,1},
            //    new int[n] {4,4,2},
            //    new int[n] {5,2,5}
            //};

            //            var costs = new int[m][]
            //            {
            //                new int[n] {1,3},
            //new int[n] {4,5},
            //new int[n] {10,8},
            //new int[n] {9,3},
            //new int[n] {9,7},
            //new int[n] {9,6},
            //new int[n] {7,1},
            //new int[n] {6,2},
            //new int[n] {6,7}
            //            };

            var res = alg.MinCost(houses, costs, m, n, target);

            Console.WriteLine(res);
        }
    }
}
