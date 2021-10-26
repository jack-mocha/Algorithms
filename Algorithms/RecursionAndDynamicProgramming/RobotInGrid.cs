using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Algorithms.RecursionAndDynamicProgramming
{
    public class RobotInGrid
    {
        private List<Point> _path;
        public int Trials { get; private set; }

        //Robot can only go right or down.
        //There may be spots that are not availabe, which is marked as false in the matrix).
        //Find a path from top left to bottom right.
        public List<Point> GetPath(bool[][] maze)
        {
            if (maze == null || maze.Length == 0)
                return null;

            Initialize();
            var lastCellRowIdx = maze.Length - 1;
            var lastCellColIdx = maze[0].Length - 1;
            if (GetPath(maze, lastCellRowIdx, lastCellColIdx, _path))
                return _path;

            return null;
        }

        //When dealing with matrix, use row and col instead of x and y, because x and y can be misleading.
        //This is a Top Down approach starting from the last cell of the matrix and find out how to get to that cell.
        private bool GetPath(bool[][] maze, int row, int col, List<Point> path)
        {
            Trials++;
            if (col < 0 || row < 0 || !maze[row][col]) //out of obunds or the cell is not available
                return false;

            var isAtOrigin = row == 0 && col == 0;
            
            if(isAtOrigin || GetPath(maze, row, col - 1, path) || GetPath(maze, row - 1, col, path))
            {
                var point = new Point(row, col);
                path.Add(point);
                return true;
            }

            return false;
        }

        public List<Point> GetPathDP(bool[][] maze)
        {
            if (maze == null || maze.Length == 0)
                return null;

            Initialize();
            var lastCellRowIdx = maze.Length - 1;
            var lastCellColIdx = maze[0].Length - 1;
            var failedPoints = new HashSet<Point>();
            if (GetPathDP(maze, lastCellRowIdx, lastCellColIdx, _path, failedPoints))
                return _path;

            return null;
        }

        //Dynamic Programming approach.
        //We use a set to remember the failedPoints that we already visited. (row - 1, col - 1) is repeated.
        private bool GetPathDP(bool[][] maze, int row, int col, List<Point> path, HashSet<Point> failedPoints)
        {
            Trials++;
            if (col < 0 || row < 0 || !maze[row][col]) //out of obunds or the cell is not available
                return false;

            var point = new Point(row, col);
            if (failedPoints.Contains(point))
                return false;

            var isAtOrigin = row == 0 && col == 0;

            if (isAtOrigin || GetPathDP(maze, row, col - 1, path, failedPoints) || GetPathDP(maze, row - 1, col, path, failedPoints))
            {
                path.Add(point);
                return true;
            }

            failedPoints.Add(point);
            return false;
        }

        private void Initialize()
        {
            _path = new List<Point>();
            Trials = 0;
        }

        public void PrintPath()
        {
            foreach(var point in _path)
                Console.WriteLine("(" + point.X + ", " + point.Y + ")");
        }
    }
}
