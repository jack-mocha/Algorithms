using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class ShowRecursion
    {
        public void Execute(int n)
        {
            Execute(n, n);
        }

        private void Execute(int total, int n)
        {
            if (n < 0)
                return;
            Console.WriteLine(GetTabs(total - n) + "n: " + n + " 1");
            Execute(total, n - 1);
            Console.WriteLine(GetTabs(total - n) + "n: " + n + " 2");
            Execute(total, n - 1);
        }

        private string GetTabs(int number)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < number; i++)
                sb.Append("\t");

            return sb.ToString();
        }
    }
}
