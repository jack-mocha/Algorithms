using System;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class Box
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        internal bool CanBeAbove(Box bottom)
        {
            return bottom.Height > this.Height && 
                bottom.Width > this.Width && 
                bottom.Depth > this.Depth;
        }
    }
}