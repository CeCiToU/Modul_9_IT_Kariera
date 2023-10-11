namespace Exam_Problem_Dictionary_AZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            List<string> words = new List<string>();

            words = GenerateWords();

            ContainWord(word, words);
        }

        private static void ContainWord(string word, List<string> words)
        {
            if (words.Contains(word))
            {
                Console.WriteLine(words.IndexOf(word) + 1);
            }
            else
            {
                Console.WriteLine("No FuFu");
            }
        }

        private static List<string> GenerateWords()
        {
            List<string> words = new List<string>();

            for (int i = 97; i <= 122; i++)
            {
                for (int j = 97; j <= 122; j++)
                {

                    if (i != j)
                    {
                        string currentWord = $"{(char)i}{(char)j}";
                        words.Add(currentWord);
                    }

                }
            }

            return words;
        }
    }
}