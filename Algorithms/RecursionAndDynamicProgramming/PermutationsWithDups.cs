using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class PermutationsWithDups
    {
        public List<string> GetAllPermutations2(string str)
        {
            var result = new List<string>();
            var map = BuildFreqTable(str);
            GetAllPermutations2(map, "", str.Length, result);
            return result;
        }

        private void GetAllPermutations2(Dictionary<char, int> map, string prefix, int remaining, List<string> result)
        {
            if(remaining == 0)
            {
                result.Add(prefix);
                return;
            }

            var keys = map.Keys.ToList();
            foreach(var key in keys)
            {
                var count = map[key];
                if(count > 0)
                {
                    map[key] = count - 1;
                    GetAllPermutations2(map, prefix + key, remaining - 1, result);
                    map[key] = count;
                }
            }
        }

        private Dictionary<char, int> BuildFreqTable(string str)
        {
            var map = new Dictionary<char, int>();
            foreach(var c in str)
            {
                if (map.ContainsKey(c))
                    map[c] = map[c] + 1;
                else
                    map.Add(c, 1);
            }

            return map;
        }

        //Simply add a set to check if the string is a duplicate.
        //This will take O(n!) time
        //Not good when the string is e.g. aaaaaaaaaa
        public List<string> GetAllPermutations(string str)
        {
            if (str == null)
                return null;

            var visited = new HashSet<string>();
            return GetAllPermutations(str, visited);
        }

        private List<string> GetAllPermutations(string str, HashSet<string> visited)
        {
            var permutations = new List<string>();
            if (str.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            var first = str[0].ToString();
            var remainder = str.Substring(1);
            var words = GetAllPermutations(remainder);
            foreach(var word in words)
            {
                for(int i = 0; i <= word.Length; i++)
                {
                    var newWord = word.Insert(i, first);
                    if(!visited.Contains(newWord))
                    {
                        visited.Add(newWord);
                        permutations.Add(newWord);
                    }
                }
            }

            return permutations;
        }

        public void PrintAllPermutations(List<string> permutations)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < permutations.Count; i++)
            {
                sb.Append(permutations[i]);
                if (i == permutations.Count - 1)
                    sb.Append("]");
                else
                    sb.Append(",");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
