internal class Program
{
    static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split().ToArray();
        int n = int.Parse(Console.ReadLine());
        string[] priorityElements = Console.ReadLine().Split().ToArray();
        elements.Distinct();

        try
        {
            if (elements.Length > 20 || n > 20)
            {
                throw new IndexOutOfRangeException();
            }

        }
        catch (IndexOutOfRangeException) { }

        List<string> combinations = GenerateCombinations(elements, n);

        combinations = MySort(combinations, priorityElements, n);

        combinations = MyDistinct(combinations);

        foreach (string combination in combinations)
        {
            Console.WriteLine(combination);
        }
    }

    private static List<string> MyDistinct(IEnumerable<string> inputList)
    {
        List<string> resultList = new List<string>();
        foreach (string item in inputList)
        {
            bool isDuplicate = false;
            string[] itemWords = item.Split(' ');
            Array.Sort(itemWords);
            string sortedItem = string.Join(" ", itemWords);

            foreach (string resultItem in resultList)
            {
                string[] resultWords = resultItem.Split(' ');
                Array.Sort(resultWords);
                string sortedResult = string.Join(" ", resultWords);

                if (sortedItem == sortedResult)
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                resultList.Add(item);
            }
        }

        return resultList;
    }

    private static List<string> MySort(List<string> combinations, string[] priorityElements, int n)
    {
        List<string> sortedList = new List<string>();
        for (int i = 0; i < combinations.Count; i++)
        {
            List<string> currentCombination = combinations[i].Split().ToList();
            for (int j = priorityElements.Length - 1; j >= 0; j--)
            {
                if (combinations[i].Contains(priorityElements[j]))
                {
                    string currentElement = currentCombination[j];
                    string priorityElement = priorityElements[j];
                    int index = IndexOf(currentCombination, priorityElements[j]);
                    currentCombination.RemoveAt(index);
                    currentCombination.Insert(0, priorityElement);
                }
            }
            currentCombination = currentCombination.Distinct().ToList();
            if (currentCombination.Count == n)
            {
                sortedList.Add(string.Join(" ", currentCombination));

            }
        }

        return sortedList;
    }

    private static int IndexOf(List<string> currComb, string currElement)
    {
        for (int i = 0; i < currComb.Count; i++)
        {
            if (currComb[i] == currElement)
            {
                return i;
            }
        }

        return -1;
    }

    static List<string> GenerateCombinations(string[] elements, int n)
    {
        List<string> result = new List<string>();
        GenerateCombinationsRecursive(elements, n, 0, new string[n], result);
        return result;
    }

    static void GenerateCombinationsRecursive(string[] elements, int n, int currentIndex, string[] combination, List<string> result)
    {
        if (currentIndex == n)
        {
            result.Add(string.Join(" ", combination));
            return;
        }

        for (int i = 0; i < elements.Length; i++)
        {
            combination[currentIndex] = elements[i];
            GenerateCombinationsRecursive(elements, n, currentIndex + 1, combination, result);
        }
    }
}