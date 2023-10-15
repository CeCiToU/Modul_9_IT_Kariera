using System.Diagnostics;

namespace City_Business
{
     class Program
    {
        static void Main(string[] args)
        {
            int[] cities = new int[1000];
            try
            {
                cities = Console.ReadLine().Split().Select(int.Parse).Where(x => x > 0 && x < 10000).ToArray();
                if (cities.Length > 10000)
                {
                    throw new IndexOutOfRangeException();
                }

            }
            catch (IndexOutOfRangeException) { }

            int fuelNeededFromIndexZero = CalculateNeededFuel(0, cities);
            int fuelNeededFromIndexOne = CalculateNeededFuel(1, cities);

            if( fuelNeededFromIndexZero > fuelNeededFromIndexOne)
            {
                Console.WriteLine(fuelNeededFromIndexOne);
            }
            else
            {
                Console.WriteLine(fuelNeededFromIndexZero);
            }

        }

        private static int CalculateNeededFuel(int startIndex, int[] cities)
        {
            int currentFuelNeeded = cities[startIndex];
            for(int i = startIndex; i < cities.Length - 2; i++)
            {
                if (cities[i+ 1] < cities[i + 2])
                {
                    currentFuelNeeded += cities[i + 1];
                }
                else
                {
                    currentFuelNeeded += cities[i + 2];
                    i++;

                }
            }
            return currentFuelNeeded;
        }
    }
}