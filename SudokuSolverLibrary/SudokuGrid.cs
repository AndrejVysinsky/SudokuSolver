using System;

namespace SudokuSolverLibrary
{
    internal class SudokuGrid
    {
        private int[][] _grid;

        public event Action<int, int> NumberChanged;

        public SudokuGrid(int[][] grid)
        {
            _grid = grid;
        }

        public void SetCellNumber(int row, int col, int number)
        {
            _grid[row][col] = number;

            NumberChanged?.Invoke(row, col);
        }

        public int GetCellNumber(int row, int col)
        {
            return _grid[row][col];
        }

        public (int row, int col) GetNextCellPosition(int row, int col)
        {
            int newRow = row;
            int newCol = col;

            newCol++;
            if (newCol >= GetBoardLength())
            {
                newCol = 0;
                newRow++;
            }

            return (newRow, newCol);
        }

        public int GetBoardLength()
        {
            return _grid.Length;
        }

        public bool IsValidNumber(int row, int col, int number)
        {
            return !IsNumberInRowOrCol(row, col, number) && !IsNumberInSquare(row, col, number);
        }

        private bool IsNumberInRowOrCol(int row, int col, int number)
        {
            //check whole row and column
            for (int i = 0; i < _grid.Length; i++)
            {
                if (_grid[row][i] == number || _grid[i][col] == number)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumberInSquare(int row, int col, int number)
        {
            //check internal square
            int[] rowInterval = GetIntervalValues(row);
            int[] colInterval = GetIntervalValues(col);

            for (int i = rowInterval[0]; i <= rowInterval[1]; i++)
            {
                for (int j = colInterval[0]; j <= colInterval[1]; j++)
                {
                    if (_grid[i][j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int[] GetIntervalValues(int position)
        {
            if (position < 3)
            {
                return new int[] { 0, 2 };
            }
            else if (position < 6)
            {
                return new int[] { 3, 5 };
            }
            else
            {
                return new int[] { 6, 8 };
            }
        }
    }
}
