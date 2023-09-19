namespace Test
{
    class EightQueens
    {
        static int[] queens = new int[8];
        static bool[] rows = new bool[8];
        static bool[] diagonalsLeft = new bool[15];
        static bool[] diagonalsRight = new bool[15];

        static void PrintSolution()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (queens[row] == col)
                        Console.Write("Q ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PutQueens(int row)
        {
            if (row == 8)
            {
                PrintSolution();
                return;
            }

            for (int col = 0; col < 8; col++)
            {
                if (!rows[col] && !diagonalsLeft[row + col] && !diagonalsRight[row - col + 7])
                {
                    queens[row] = col;
                    rows[col] = true;
                    diagonalsLeft[row + col] = true;
                    diagonalsRight[row - col + 7] = true;

                    PutQueens(row + 1);

                    rows[col] = false;
                    diagonalsLeft[row + col] = false;
                    diagonalsRight[row - col + 7] = false;
                }
            }
        }

        static void Main()
        {
            PutQueens(0);
        }
    }
}