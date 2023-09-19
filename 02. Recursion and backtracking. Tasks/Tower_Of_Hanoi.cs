using System.ComponentModel.Design;

namespace Tower_Of_Hanoi
{
    internal class Program
    {
        static void Main()
        {

            Start();
            Main();
        }

        private static void Start()
        {
            List<string> solution = new List<string>();

            PrintHeader();

            int numberOfDisks = int.Parse(Console.ReadLine());


            while (numberOfDisks < 1)
            {
                Console.WriteLine("Enter number bigger than 0!\n");
                PrintHeader();
                numberOfDisks = int.Parse(Console.ReadLine());
            }

            TowerOfHanoi(numberOfDisks, 1, 2, 3, solution);

            PrintFooter(solution, numberOfDisks);
        }

        private static void PrintHeader()
        {
            Console.Write("Number of disks: ");
        }

        private static void PrintFooter(List<string> solution, int numberOfDisks)
        {
            Console.Write("\nThe game needs ");
            Console.Write(Math.Pow(2, numberOfDisks) - 1);
            Console.WriteLine(" moves to be solved!\n\nThis is the solution: \n");

            for (int i = 0; i < solution.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {solution[i]}");
            }
        }

        private static void TowerOfHanoi(int numberOfDisks, int sourceTower, int helpTower, int targetTower, List<string> solution)
        {
            if (numberOfDisks == 1)
            {
                string str = $"{sourceTower} --> {targetTower}";
                solution.Add(str);

                return;
            }

            TowerOfHanoi(numberOfDisks - 1, sourceTower, targetTower, helpTower, solution);

            string str2 = $"{sourceTower} --> {targetTower}";
            solution.Add(str2);

            TowerOfHanoi(numberOfDisks - 1, helpTower, sourceTower, targetTower, solution);
        }
    }
}