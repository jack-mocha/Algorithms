using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    //Both large and small are sorted.
    //Large has enough space at the end to hold small.
    //The idea is to go from the end of each array and put it back to the large array.
    public class SortedMerge
    {
        public void Merge(int[] large, int[] small)
        {
            var lIdx = large.Length - small.Length - 1;
            var sIdx = small.Length - 1;
            var current = large.Length - 1;

            while(lIdx >= 0 && sIdx >= 0)
            {
                if (large[lIdx] > small[sIdx])
                    large[current--] = large[lIdx--];
                else
                    large[current--] = small[sIdx--];
            }

            while(lIdx >= 0)
                large[current--] = large[lIdx--];
            while(sIdx >= 0)
                large[current--] = small[sIdx--];
        }
    }
}
