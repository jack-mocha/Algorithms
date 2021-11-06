using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class StackOfBox
    {
        public int CreateStack(List<Box> boxes)
        {
            boxes.Sort(new ByBoxHeight());
            var maxHeight = 0;
            for(int i = 0; i < boxes.Count; i++)
            {
                var height = CreateStack(boxes, i);
                maxHeight = Math.Max(maxHeight, height);
            }

            return maxHeight;
        }

        private int CreateStack(List<Box> boxes, int bottomIndex)
        {
            var bottom = boxes[bottomIndex];
            var maxHeight = 0;
            for(int i = bottomIndex + 1; i < boxes.Count; i++)
            {
                if(boxes[i].CanBeAbove(bottom))
                {
                    var height = CreateStack(boxes, i);
                    maxHeight = Math.Max(height, maxHeight);
                }
            }
            maxHeight += bottom.Height;
            return maxHeight;
        }

        //from big -> small
        private class ByBoxHeight : IComparer<Box>
        {
            public int Compare(Box x, Box y)
            {
                return y.Height.CompareTo(x.Height);
            }
        }

        public int CreateStackDP(List<Box> boxes)
        {
            boxes.Sort(new ByBoxHeight());
            var maxHeight = 0;
            var stackMap = new int[boxes.Count]; //Because we're only mapping from an index to a height, we can just use an integer array for our hash table.
            for (int i = 0; i < boxes.Count; i++)
            {
                var height = CreateStackDP(boxes, i, stackMap);
                maxHeight = Math.Max(maxHeight, height);
            }

            return maxHeight;
        }

        private int CreateStackDP(List<Box> boxes, int bottomIndex, int[] stackMap)
        {
            if (bottomIndex < boxes.Count && stackMap[bottomIndex] > 0)
                return stackMap[bottomIndex];

            var bottom = boxes[bottomIndex];
            var maxHeight = 0;
            for (int i = bottomIndex + 1; i < boxes.Count; i++)
            {
                if (boxes[i].CanBeAbove(bottom))
                {
                    var height = CreateStack(boxes, i);
                    maxHeight = Math.Max(height, maxHeight);
                }
            }
            maxHeight += bottom.Height;
            stackMap[bottomIndex] = maxHeight;
            return maxHeight;
        }
    }
}
