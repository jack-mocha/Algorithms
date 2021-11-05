using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class EightQueens
    {
        private const int GridSize = 8;

        public List<int[]> PlaceQueens()
        {
            var result = new List<int[]>();
            PlaceQueens(0, new int[GridSize], result);

            return result;
        }

        private void PlaceQueens(int row, int[] columns, List<int[]> results)
        {
            if (row == GridSize)
                results.Add((int[])columns.Clone());
            else
            {
                for (int col = 0; col < GridSize; col++)
                {
                    if (CheckValid(columns, row, col))
                    {
                        columns[row] = col;
                        PlaceQueens(row + 1, columns, results);
                        columns[row] = 0;
                    }
                }
            }
        }

        private bool CheckValid(int[] columns, int row1, int column1)
        {
            for(int row2 = 0; row2 < row1; row2++)
            {
                var column2 = columns[row2];
                if (column1 == column2)
                    return false;

                var columnDistance = Math.Abs(column2 - column1);
                var rowDistance = row1 - row2;
                if (columnDistance == rowDistance)
                    return false;
            }

            return true;
        }
    }
}
