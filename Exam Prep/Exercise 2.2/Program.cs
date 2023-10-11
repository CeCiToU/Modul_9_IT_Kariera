namespace Permutations
{
    public class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<List<int>> permutations = GeneratePermutations(numbers);

            CountShifts(permutations);

            List<string> result = new List<string>();

            result = MySort(permutations);

            foreach (var permutation in result)
            {
                Console.WriteLine(string.Join(" ", permutation));
            }
        }

        private static List<string> MySort(List<List<int>> permutations)
        {
            List<string> sortedPermutations = new List<string>();
            for (int i = 0; i < permutations.Count; i++)
            {
                var currentPermutations = permutations[i];
                string currNum = string.Join(" ", currentPermutations);
                sortedPermutations.Add(currNum);
            }

            sortedPermutations.Sort();

            return sortedPermutations;
        }

        private static void CountShifts(List<List<int>> permutations)
        {

            for (int i = permutations.Count - 1; i >= 0; i--)
            {
                int counter = 0;
                for (int j = 0; j < permutations[i].Count - 1; j++)
                {
                    List<int> currentPermutation = permutations[i];
                    if (currentPermutation[j] > currentPermutation[j + 1])
                    {
                        counter++;
                    }
                }
                if (counter % 2 != 0 || counter == 0)
                {
                    permutations.RemoveAt(i);
                }
            }
        }



        private static List<List<int>> GeneratePermutations(int[] numbers)
        {
            List<List<int>> permutations = new List<List<int>>();
            GeneratePermutationsHelper(numbers, new List<int>(), permutations);
            return permutations;
        }

        private static void GeneratePermutationsHelper(int[] numbers, List<int> currentPermutation, List<List<int>> permutations)
        {
            if (currentPermutation.Count == numbers.Length)
            {
                permutations.Add(new List<int>(currentPermutation));
                return;
            }

            foreach (int number in numbers)
            {
                if (!currentPermutation.Contains(number))
                {
                    currentPermutation.Add(number);
                    GeneratePermutationsHelper(numbers, currentPermutation, permutations);
                    currentPermutation.RemoveAt(currentPermutation.Count - 1);
                }
            }
        }
    }
}