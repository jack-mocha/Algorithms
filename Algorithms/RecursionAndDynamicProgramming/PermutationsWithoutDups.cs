using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class PermutationsWithoutDups
    {
        public List<string> GetPerms(string str)
        {
            if (str == null)
                return null;

            var permutations = new List<string>();
            if(str.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            var first = str[0].ToString();
            var remainder = str.Substring(1);
            var words = GetPerms(remainder);
            foreach(var word in words)
            {
                for(int i = 0; i <= word.Length; i++)
                {
                    var s = word.Insert(i, first);
                    permutations.Add(s);
                }
            }

            return permutations;
        }

        public void PrintAllPermutations(List<string> permutations)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for(int i = 0; i < permutations.Count; i++)
            {
                sb.Append(permutations[i]);
                if(i == permutations.Count - 1)
                    sb.Append("]");
                else
                    sb.Append(",");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
