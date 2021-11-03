using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class Coins
    {
        public int GetNumOfWaysToRepresent(int cents)
        {
            var denoms = new List<int>()
            {
                25, 10, 5, 1
            };

            var map = new Dictionary<int, Dictionary<int, int>>();
            return GetNumOfWaysToRepresentDP(cents, denoms, 0, map);
            //return GetNumOfWaysToRepresent(cents, denoms, 0);
        }

        //This approach has many duplicates.
        private int GetNumOfWaysToRepresent(int cents, List<int> denoms, int index)
        {
            var coin = denoms[index];
            if(index == denoms.Count - 1)
            {
                var remaining = cents % coin;
                return remaining == 0 ? 1 : 0;
            }

            var ways = 0;
            for (int amount = 0; amount <= cents; amount += coin)
                ways += GetNumOfWaysToRepresent(cents - amount, denoms, index + 1);

            return ways;
        }

        //Use a dictionary of dictionary to cache results that are already calculated.
        private int GetNumOfWaysToRepresentDP(int cents, List<int> denoms, int index, Dictionary<int, Dictionary<int, int>> map)
        {
            if(map.ContainsKey(cents))
            {
                if (map[cents].ContainsKey(index))
                    if (map[cents][index] > 0)
                        return map[cents][index];
            }

            var coin = denoms[index];
            if (index == denoms.Count - 1)
            {
                var remaining = cents % coin;
                return remaining == 0 ? 1 : 0;
            }

            var numOfWays = 0;
            for (int amount = 0; amount <= cents; amount += coin)
                numOfWays += GetNumOfWaysToRepresent(cents - amount, denoms, index + 1);

            //Update cache
            UpdateMap(map, cents, index, numOfWays);

            return numOfWays;
        }

        private void UpdateMap(Dictionary<int, Dictionary<int, int>> map, int cents, int index, int numOfWays)
        {
            if (map.ContainsKey(cents))
                if (map[cents].ContainsKey(index))
                    map[cents][index] = numOfWays;
                else
                    map[cents].Add(index, numOfWays);
            else
                map.Add(cents, new Dictionary<int, int> { { index, numOfWays } });
        }
    }
}
