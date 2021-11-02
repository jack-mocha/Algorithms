using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class TowerOfHanoi
    {
        private Stack<int> disks = new Stack<int>();

        public void MoveDisks(int quantity, TowerOfHanoi destination, TowerOfHanoi buffer)
        {
            if (quantity <= 0)
                return;

            MoveDisks(quantity - 1, buffer, destination);
            MoveTopTo(destination);
            buffer.MoveDisks(quantity - 1, destination, this); //quantity - 1 represent all disks moved to the buffer during this iteration.
        }

        private void MoveTopTo(TowerOfHanoi destination)
        {
            var disk = disks.Pop();
            destination.Add(disk);
        }

        private void Add(int disk)
        {
            if(disks.Count > 0 && disks.Peek() <= disk)
                Console.WriteLine("Error placing disk " + disk);

            disks.Push(disk);
        }
    }
}
