// what do I want? -> I want to write a sudoku-engine in C# that generates new sodokus for me to solve e.g. in a web-frontend like blazor

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Sudoku!");

// first write a global sudoku verifier -> checks if the given sudoku grid satisfies the sudoku rules (no duplicate in column, row and 9er block)

// recursion example
void print_number(int number){
    if(number == 0) return;
    Console.WriteLine(number);
    print_number(number - 1);
}

// verify the a certain number at a certain position
bool verify_number(int[,] grid, int row, int col, int number){
    // check if the number is unique in the given row
    for(int i = 0; i < 9; i++){

        if(grid[row,i] == number) return false;
    }

    // check if the number is unique in the given col

    for(int i = 0; i < 9; i++){
        if(grid[i, col] == number) return false;
    }

    return true;

    // check if the number is unique in its 9er block
}


// [row, col]
int [,] grid = new int [9,9] {
    {0,0,0,0,0,0,6,8,0},
    {0,0,0,0,7,3,0,0,9},
    {3,0,9,0,0,0,0,4,5},
    {4,9,0,0,0,0,0,0,0},
    {8,0,3,0,5,0,9,0,2},
    {0,0,0,0,0,0,0,3,6},
    {9,6,0,0,0,0,3,0,8},
    {7,0,0,6,8,0,0,0,0},
    {0,2,8,0,0,0,0,0,0},
};

verify_number(grid, 0,0,10);