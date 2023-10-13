namespace Food_Stamps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workedDays = int.Parse(Console.ReadLine());

            if (1 <= workedDays && workedDays <= 23)
            {
                Print(CalculateFoodStamps(StampSum(workedDays)));
            }
        }

        private static void Print(int stamps)
        {
            Console.WriteLine(stamps);
        }

        private static int StampSum(int days)
        {
            return days * 20;
        }

        private static int CalculateFoodStamps(int stampSum)
        {
            int numberOfStamps = 0;

            if (stampSum >= 100)
            {
                numberOfStamps += CalculateFoodStamps(stampSum - 100);
                return numberOfStamps + 1;
            }
            else if (stampSum >= 20)
            {
                numberOfStamps += CalculateFoodStamps(stampSum - 20);
                return numberOfStamps + 1;
            }

            return numberOfStamps;
        }
    }
}