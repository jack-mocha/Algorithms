using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class MinimumDifficultyOfAJobSchedule
    {
        private int[] _hardestJobRemaining;
        private int[] _jobDifficulty;
        private int totalDays;

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            totalDays = d;
            if (jobDifficulty.Length < totalDays)
                return -1;

            _hardestJobRemaining = new int[jobDifficulty.Length];
            var hardestJob = 0;
            for(int i = jobDifficulty.Length - 1; i >= 0; i--)
            {
                hardestJob = Math.Max(hardestJob, jobDifficulty[i]);
                _hardestJobRemaining[i] = hardestJob;
            }

            _jobDifficulty = jobDifficulty;
            var memo = new int[jobDifficulty.Length][];
            for (int i = 0; i < memo.Length; i++)
                memo[i] = new int[totalDays + 1];

            return DP(0, 1, memo);
        }

        private int DP(int i, int day, int[][] memo)
        {
            if (day == totalDays)
                return _hardestJobRemaining[i];

            if(memo[i][day] == 0)
            {
                var best = Int32.MaxValue;
                int hardest = 0;
                for(int j = i; j < _jobDifficulty.Length - (totalDays - day); j++)
                {
                    hardest = Math.Max(hardest, _jobDifficulty[j]);
                    best = Math.Min(best, hardest + DP(j + 1, day + 1, memo));
                }
                memo[i][day] = best;
            }

            return memo[i][day];
        }
    }
}
