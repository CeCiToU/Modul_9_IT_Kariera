using System.Linq;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace Greedy_Algorithms_1
{
    class Planet
    {
        public List<int> Elements { get; set; }

        public Planet(List<int> elements)
        {
            this.Elements = elements;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Universe = new List<int>() { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            List<Planet> planets = new List<Planet>()
            {
                new Planet(new List<int> { 20 }),
                new Planet(new List<int> { 1, 5, 20, 30 }),
                new Planet(new List<int> { 3, 7, 20, 30, 40 }),
                new Planet(new List<int> { 9, 30 }),
                new Planet(new List<int> { 11, 20, 30, 40 }),
                new Planet(new List<int> { 3, 7, 40 }),
            };


            List<Planet> selectedPlanets = SelectPlanetsByElements(planets);


            PrintResult(selectedPlanets);
        }

        private static void PrintResult(List<Planet> selectedPlanets)
        {
            Console.WriteLine($"Planets => {selectedPlanets.Count}");
            foreach (var planet in selectedPlanets)
            {
                Console.WriteLine("{ " + $"{string.Join(", ", planet.Elements)}" + " }");

            }
        }

        private static List<Planet> SelectPlanetsByElements(List<Planet> planets)
        {
            List<Planet> selectedPlanets = new List<Planet>();
            List<int> elements = new List<int>();

            planets = planets.OrderByDescending(x => x.Elements.Count).ToList();

            planets[0].Elements.Distinct();

            selectedPlanets.Add(planets[0]);
            string str = string.Join(",", planets[0].Elements);

            elements.AddRange(str.Split(",").Select(int.Parse));

            for (int i = 1; i < planets.Count; i++)
            {
                string planetString = string.Join(",", planets[i].Elements);
                int[] currentPlanetElements = planetString.Split(",").Select(int.Parse).ToArray();

                for (int j = 0; j < currentPlanetElements.Length; j++)
                {
                    if (!elements.Contains(currentPlanetElements[j]))
                    {
                        selectedPlanets.Add(planets[i]);
                        break;
                    }

                }
            }


            return selectedPlanets;
        }
    }
}