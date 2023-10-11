namespace Shortest_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split().Select(int.Parse).ToList();

            houses.Sort();

            int shortestPath = 0;

            shortestPath += houses[2] - houses[1];
            shortestPath += houses[1] - houses[0];

            Console.WriteLine(shortestPath);
        }
    }
}