namespace Fireplaces
{
    internal class Program
    {
        private static int[,] matrix;
        private static int fireplaces = 0;
        static void Main()
        {
            List<string> inputRow = Console.ReadLine().Split().ToList();
            int row = int.Parse(inputRow[0]);
            int column = int.Parse(inputRow[1]);

            matrix = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                int[] rows = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < rows.Length; j++)
                {
                    matrix[i, j] = rows[j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (DetectFire(i, j))
                    {
                        fireplaces++;
                    }
                }
            }

            Console.WriteLine(fireplaces);
        }

        private static bool DetectFire(int row, int column)
        {
            if (matrix[row, column] != 1)
            {
                return false;
            }

            ChangeFire(row, column);

            CheckFire(row - 1, column - 1);
            CheckFire(row - 1, column);
            CheckFire(row - 1, column + 1);

            CheckFire(row, column - 1);
            CheckFire(row, column + 1);

            CheckFire(row + 1, column - 1);
            CheckFire(row + 1, column);
            CheckFire(row + 1, column + 1);

            return true;
        }

        private static void CheckFire(int row, int column)
        {
            try
            {
                DetectFire(row, column);
            }
            catch { }
        }

        private static void ChangeFire(int row, int column)
        {
            matrix[row, column] = 2;
        }
    }
}