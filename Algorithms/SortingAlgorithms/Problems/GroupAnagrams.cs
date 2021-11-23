using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms.Problems
{
    public class GroupAnagrams
    {
        public void Sort(string[] words)
        {
            var map = new Dictionary<string, List<string>>();
            
            //Construct the map
            foreach (var w in words) 
            {
                var key = SortChar(w); //if 2 words are anagram, after sorting, they are the same word
                if (map.ContainsKey(key))
                    map[key].Add(w);
                else
                    map.Add(key, new List<string> { w });
            }

            //Put everything back to the array
            var index = 0;
            foreach(var m in map)
                foreach (var w in m.Value)
                    words[index++] = w;
        }

        private string SortChar(string word)
        {
            var w = word.ToCharArray();
            Array.Sort(w);
            return new string(w);
        }
    }
}
