using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuNet
{
    public class Solver
    {
        public Solver() { }

        public void PrintSolutionIfPossible(Grid grid)
        {
            var success = this.solve(grid.values, 0, 0);

            if (success)
            {
                Console.WriteLine(grid.ToString());
            }
            else
            {
                Console.WriteLine("No solution!");
            }

        }

        // verify the a certain number at a certain position
        public bool is_valid_move(int[,] grid, int row, int col, int number)
        {
            // check if the number is unique in the given row
            for (int i = 0; i < 9; i++)
            {

                if (grid[row, i] == number) return false;
            }

            // check if the number is unique in the given col

            for (int i = 0; i < 9; i++)
            {
                if (grid[i, col] == number) return false;
            }


            // check if the number is unique in its 9er block

            int corner_row = row - row % 3;
            int corner_col = col - col % 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[corner_row + i, corner_col + j] == number) return false;
                }
            }

            return true;

        }

        public bool solve(int[,] grid, int row, int col)
        {

            if (col == 9)
            {
                if (row == 8)
                {
                    return true;
                }
                row += 1;
                col = 0;
            }

            if (grid[row, col] > 0)
            {
                return this.solve(grid, row, col + 1);
            }

            for (int num = 1; num < 10; num++)
            {
                if (this.is_valid_move(grid, row, col, num))
                {
                    grid[row, col] = num;

                    if (this.solve(grid, row, col + 1))
                    {
                        return true;
                    }
                }

                grid[row, col] = 0;
            }


            return false;
        }
    }
}
