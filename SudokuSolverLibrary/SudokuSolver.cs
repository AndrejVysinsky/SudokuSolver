using System;

namespace SudokuSolverLibrary
{
    public class SudokuSolver
    {
        private SudokuGrid _sudokuGrid;

        private bool _isSolved;

        public SudokuSolver(SudokuGrid sudokuGrid)
        {
            _sudokuGrid = sudokuGrid;
            _isSolved = false;
        }

        public bool Solve()
        {
            if (_isSolved == false)
            {
                BackTracking(0, 0);
            }

            return _isSolved;
        }

        private void BackTracking(int row, int col)
        {
            if (row >= 9)
            {
                _isSolved = true;
                return;
            }

            if (_sudokuGrid.GetCellNumber(row, col) != 0)
            {
                var nextCellPosition = _sudokuGrid.GetNextCellPosition(row, col);
                BackTracking(nextCellPosition.row, nextCellPosition.col);
            }
            else
            {
                for (int number = 1; number <= 9; number++)
                {
                    if (_sudokuGrid.IsValidNumber(row, col, number))
                    {
                        _sudokuGrid.SetCellNumber(row, col, number);

                        var nextCellPosition = _sudokuGrid.GetNextCellPosition(row, col);
                        BackTracking(nextCellPosition.row, nextCellPosition.col);

                        if (_isSolved == false)
                        {
                            _sudokuGrid.SetCellNumber(row, col, 0);
                        }
                    }
                }
            }
        }
    }
}
