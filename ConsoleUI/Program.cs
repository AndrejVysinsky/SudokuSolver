using System;
using System.Threading;
using SudokuSolverLibrary;

namespace ConsoleUI
{
    class Program
    {
        /*
         * expected:
         * - has only 1 solution
         * - is 9x9
         * - empty cells are marked with 0
         */

        static int[][] grid = new int[][]
        {
            new int[]{0, 0, 7, 0, 0, 0, 0, 2, 0},
            new int[]{0, 9, 0, 2, 0, 0, 7, 5, 0},
            new int[]{0, 8, 4, 7, 0, 0, 0, 0, 0},
            new int[]{0, 7, 0, 0, 0, 0, 9, 0, 8},
            new int[]{0, 0, 0, 0, 4, 0, 0, 0, 0},
            new int[]{0, 4, 0, 8, 2, 0, 0, 3, 1},
            new int[]{0, 0, 0, 0, 6, 0, 0, 0, 7},
            new int[]{0, 0, 3, 0, 0, 5, 0, 0, 0},
            new int[]{9, 0, 0, 0, 0, 0, 5, 0, 6},
        };

        static void Main(string[] args)
        {
            PrintUnsolved();
            Solve();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintUnsolved()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.ForegroundColor = grid[i][j] == 0 ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(grid[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Solve()
        {
            var sudokuGrid = new SudokuGrid(grid);
            sudokuGrid.OnCellChanged += PrintCellChange;

            var sudokuSolver = new SudokuSolver(sudokuGrid);
            sudokuSolver.Solve();
        }

        static void PrintCellChange(int row, int col)
        {
            Console.SetCursorPosition(col * 2, row);
            
            Console.ForegroundColor = grid[row][col] == 0 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(grid[row][col]);

            Thread.Sleep(5);
        }
    }
}
