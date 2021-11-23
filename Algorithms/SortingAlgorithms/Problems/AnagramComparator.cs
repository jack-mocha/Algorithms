using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Algorithms.SortingAlgorithms.Problems
{
    public class AnagramComparator : IComparer<string>
    {
        //This is another way to solve Group Anagrams by implementing IComparer.
        public void Sort(string[] words)
        {
            Array.Sort(words, new AnagramComparator());
        }

        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            return SortChars(x).CompareTo(SortChars(y));
        }

        private string SortChars(string word)
        {
            var w = word.ToCharArray();
            Array.Sort(w);
            return new string(w);
        }
    }
}
