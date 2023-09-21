
// based on this youtube-video: https://www.youtube.com/watch?v=b_T-brYofN4

// what do I want? -> I want to write a sudoku-engine in C# that generates new sodokus for me to solve e.g. in a web-frontend like blazor

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Sudoku!");

// first write a global sudoku verifier -> checks if the given sudoku grid satisfies the sudoku rules (no duplicate in column, row and 9er block)

// recursion example
void print_number(int number)
{
    if (number == 0) return;
    Console.WriteLine(number);
    print_number(number - 1);
}

// verify the a certain number at a certain position
bool is_valid_move(int[,] grid, int row, int col, int number)
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

bool solve(int[,] grid, int row, int col)
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
        return solve(grid, row, col + 1);
    }

    for (int num = 1; num < 10; num++)
    {
        if (is_valid_move(grid, row, col, num))
        {
            grid[row, col] = num;

            if (solve(grid, row, col + 1))
            {
                return true;
            }
        }

        grid[row, col] = 0;
    }


    return false;
}


// [row, col]
int[,] grid = new int[9, 9] {
    {0, 0, 0, 0, 0, 0, 6, 8, 0},
    {0, 0, 0, 0, 7, 3, 0, 0, 9},
    {3, 0, 9, 0, 0, 0, 0, 4, 5},
    {4, 9, 0, 0, 0, 0, 0, 0, 0},
    {8, 0, 3, 0, 5, 0, 9, 0, 2},
    {0, 0, 0, 0, 0, 0, 0, 3, 6},
    {9, 6, 0, 0, 0, 0, 3, 0, 8},
    {7, 0, 0, 6, 8, 0, 0, 0, 0},
    {0, 2, 8, 0, 0, 0, 0, 0, 0},
};

var success = solve(grid, 0, 0);
Console.WriteLine(success);

for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        Console.Write(grid[i, j] + " ");
    }
    Console.WriteLine();
}
