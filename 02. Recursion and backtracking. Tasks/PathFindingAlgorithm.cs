namespace Path_Finder
{
    internal class Program
    {
        static char[,] matrix;
        static List<char> path = new List<char>();


        static void Main()
        {
            Console.Write("Enter 'x': ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Enter 'y': ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("Draw matrix!");
            matrix = new char[x,y];

            for (int i = 0; i < x; i++)
            {
                string inputRow = Console.ReadLine();
                char[] rowValues = inputRow.Split().Select(char.Parse).ToArray();

                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = rowValues[j];
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("All paths:");
            FindPaths(0, 0, 'S');

            Console.WriteLine();
            Console.WriteLine();

            Main();
        }

        static void FindPaths(int row, int col, char direction)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (direction != 'S')
            {
                path.Add(direction);
            }
            if (matrix[row, col] == 'e')
            {

                Console.WriteLine(string.Join("->", path));
            }
            else if (matrix[row, col] == '-')
            {
                matrix[row, col] = 'v';


                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');

                matrix[row, col] = '-';
            }

            if (path.Count > 0)
            {
                path.RemoveAt(path.Count - 1);
            }
        }


    }
}