using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class WordBreak
    {
        public bool Execute(string s, IList<string> wordDict) //Bottom up
        {
            var dp = new bool[s.Length + 1];
            for (int i = 0; i < s.Length; i++)
            {
                foreach (var word in wordDict)
                {
                    // Make sure to stay in bounds while checking criteria
                    if (i >= word.Length - 1 && (i == word.Length - 1 || dp[i - word.Length]))
                    {
                        if (s.Substring(i - word.Length + 1, word.Length).Equals(word))
                        {
                            dp[i] = true;
                            break;
                        }
                    }
                }
            }

            return dp[s.Length - 1];
        }

        public bool ExecuteTopDown(string s, IList<string> wordDict)
        {
            var memo = new int[s.Length];
            Array.Fill(memo, -1);
            return DP(s, wordDict, s.Length - 1, memo);
        }

        public bool DP(string s, IList<string> wordDict, int i, int[] memo)
        {
            if (i < 0)
                return true;

            if (memo[i] == -1)
            {
                foreach (var word in wordDict)
                {
                    if (i >= word.Length - 1 && DP(s, wordDict, i - word.Length, memo)) //dropped (i == word.Length - 1) because the base case takes care of it.
                    {
                        if (s.Substring(i - word.Length + 1, word.Length).Equals(word))
                        {
                            memo[i] = 1;
                            break;
                        }
                    }
                }
            }

            if (memo[i] == -1) //This substring cannot be formed with wordDict
                memo[i] = 0;

            return memo[i] == 1;
        }
    }
}
