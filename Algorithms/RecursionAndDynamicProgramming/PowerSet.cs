using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class PowerSet
    {
        //An good example of buttom up approach
        public List<List<int>> GetSubsets(List<int> set)
        {
            if (set == null || set.Count == 0)
                return null;

            List<List<int>> allSubsets;
            allSubsets = new List<List<int>>();
            allSubsets.Add(new List<int>());

            //return GetSubsets(set, 0);
            return GetSubsets2(allSubsets, set, 0);
        }

        //I think this is more intuitive because it builds from from 1 -> n
        private List<List<int>> GetSubsets2(List<List<int>> allSubsets, List<int> set, int index)
        {
            if (set.Count == index)
                return allSubsets;

            var item = set[index];
            var moreSubsets = new List<List<int>>();
            foreach(var subsets in allSubsets)
            {
                var newSubset = new List<int>();
                newSubset.AddRange(subsets);
                newSubset.Add(item);
                moreSubsets.Add(newSubset);
            }
            allSubsets.AddRange(moreSubsets);
            return GetSubsets2(allSubsets, set, index + 1);
        }

        //I think this is less intuitive because it builds from n -> 1
        private List<List<int>> GetSubsets(List<int> set, int index)
        {
            List<List<int>> allSubSets;
            if(set.Count == index)
            {
                allSubSets = new List<List<int>>();
                allSubSets.Add(new List<int>());
            }
            else
            {
                allSubSets = GetSubsets(set, index + 1);
                int item = set[index];
                var moreSubSets = new List<List<int>>();
                foreach(var subset in allSubSets)
                {
                    var newSubSet = new List<int>();
                    newSubSet.AddRange(subset);
                    newSubSet.Add(item);
                    moreSubSets.Add(newSubSet);
                }
                allSubSets.AddRange(moreSubSets);
            }
            return allSubSets;
        }

        public void PrintSubsets(List<List<int>> sets)
        {
            foreach(var subsets in sets)
            {
                var sb = new StringBuilder();
                sb.Append("[");
                for(int i = 0; i < subsets.Count; i++)
                {
                    if (i == subsets.Count - 1)
                        sb.Append(subsets[i]);
                    else
                    {
                        sb.Append(subsets[i]);
                        sb.Append(",");
                    }
                }
                sb.Append("]");

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
