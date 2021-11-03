using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class ValidParenthesesCombinations
    {
        public void PrintValidParentheses(int pairs)
        {
            if (pairs <= 0)
                return;

            var parentheses = GetValidParentheses(pairs);
            foreach (var p in parentheses)
                Console.WriteLine(p);
        }

        //This approach is very similar to PermutationsWithoutDups
        //This works, but is not very efficient. => A lot of duplicates.
        private HashSet<string> GetValidParentheses(int pairs)
        {
            var combinations = new HashSet<string>();
            if (pairs == 0)
            {
                combinations.Add("");
                return combinations;
            }

            var parentheses = GetValidParentheses(pairs - 1);
            foreach(var p in parentheses)
            {
                //Insert a pair of parentheses inside every existing pair of parentheses, and one at the beginning of the string.
                //Any other places that we could insert parentheses, such as at the end of the string, would reduce to the earlier casees.
                for(int i = 0; i < p.Length; i++)
                {
                    if(p[i] == '(')
                    {
                        var s = InsertInside(p, i);
                        combinations.Add(s); //HashSet.Add() already checks contains.
                    }
                }
                combinations.Add("()" + p);
            }

            return combinations;
        }

        private string InsertInside(string str, int leftIndex)
        {
            var left = str.Substring(0, leftIndex + 1);
            var right = str.Substring(leftIndex + 1, str.Length - (leftIndex + 1));
            return left + "()" + right;
        }
    }
}
