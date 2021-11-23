using Algorithms.RecursionAndDynamicProgramming;
using Algorithms.SearchingAlgorithms;
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
            //var alg = new GroupAnagrams();
            //var words = new string[] { "tar", "arc", "elbow", "bla", "rat", "car", "below" };
            //alg.Sort(words);

            var alg = new AnagramComparator();
            var words = new string[] { "tar", "arc", "elbow", "bla", "rat", "car", "below" };
            alg.Sort(words);
        }
    }
}
