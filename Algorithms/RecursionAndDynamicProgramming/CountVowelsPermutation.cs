using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class CountVowelsPermutation
    {
        private string vowels = "aeiou";
        private int n;
        private int MOD = 1000000007;
        public int Execute(int n)
        {
            if (n == 0)
                return 0;

            this.n = n;
            var memo = new long[n + 1][];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = new long[vowels.Length];

            //long count = 0;
            //for(int j = 0; j < vowels.Length; j++)
            //    count = (count + DP(1, j, memo)) % MOD;

            long count = 0;
            for (int j = 0; j < vowels.Length; j++)
                count = (count + DPTopDown(n - 1, j, memo)) % MOD;

            return (int)count;
        }

        private long DPTopDown(int i, int j, long[][] memo)
        {
            if (i == 0)
                return 1;

            if (memo[i][j] == 0)
            {
                long count = 0;
                if (vowels[j] == 'a')
                    count = DPTopDown(i - 1, vowels.IndexOf('e'), memo) + DPTopDown(i - 1, vowels.IndexOf('i'), memo) + DPTopDown(i - 1, vowels.IndexOf('u'), memo);
                else if (vowels[j] == 'e')
                    count = DPTopDown(i - 1, vowels.IndexOf('a'), memo) + DPTopDown(i - 1, vowels.IndexOf('i'), memo);
                else if (vowels[j] == 'i')
                    count = DPTopDown(i - 1, vowels.IndexOf('e'), memo) + DPTopDown(i - 1, vowels.IndexOf('o'), memo);
                else if (vowels[j] == 'o')
                    count = DPTopDown(i - 1, vowels.IndexOf('i'), memo);
                else if (vowels[j] == 'u')
                    count = DPTopDown(i - 1, vowels.IndexOf('i'), memo) + DPTopDown(i - 1, vowels.IndexOf('o'), memo);

                memo[i][j] = count % MOD;
            }

            return memo[i][j];
        }

        //# of strings of length i that ends with jth vowel
        private long DP(int i, int j, long[][] memo)
        {
            if (i == n)
                return 1;

            if (memo[i][j] == 0)
            {
                long count = 0;
                if (vowels[j] == 'a')
                    count = DP(i + 1, vowels.IndexOf('e'), memo);
                else if (vowels[j] == 'e')
                    count = DP(i + 1, vowels.IndexOf('a'), memo) + DP(i + 1, vowels.IndexOf('i'), memo);
                else if (vowels[j] == 'i')
                {
                    count = DP(i + 1, vowels.IndexOf('a'), memo) +
                        DP(i + 1, vowels.IndexOf('e'), memo) +
                        DP(i + 1, vowels.IndexOf('o'), memo) +
                        DP(i + 1, vowels.IndexOf('u'), memo);
                }
                else if (vowels[j] == 'o')
                    count = DP(i + 1, vowels.IndexOf('i'), memo) + DP(i + 1, vowels.IndexOf('u'), memo);
                else if (vowels[j] == 'u')
                    count = DP(i + 1, vowels.IndexOf('a'), memo);

                memo[i][j] = count % MOD;
            }

            return memo[i][j];
        }
    }
}
