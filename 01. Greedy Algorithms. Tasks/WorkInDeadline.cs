namespace Greedy_Algorithms_2
{
    class Work
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public int Deadline { get; set; }

        public double Prize { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Work> works = new List<Work>()
            {
                new Work { Index = 1, Name = "j1", Deadline = 2, Prize = 60 },
                new Work { Index = 2, Name = "j2", Deadline = 1, Prize = 100 },
                new Work { Index = 3, Name = "j3", Deadline = 3, Prize = 20 },
                new Work { Index = 4, Name = "j4", Deadline = 2, Prize = 40 },
                new Work { Index = 5, Name = "j5", Deadline = 1, Prize = 20 },
             };

            List<Work> selectedWorks = SelectMostPricedVersion(works);

            Console.WriteLine("Jobs: ");

            Console.WriteLine(string.Join(", ", selectedWorks));

            double sum = selectedWorks.Sum(x => x.Prize);

            Console.WriteLine($"Max sum is: {sum}");


        }

        static List<Work> SelectMostPricedVersion(List<Work> works)
        {
            List<Work> selectedWorks = new List<Work>();

            works = works.OrderByDescending(a => a.Prize).ToList();

            selectedWorks.Add(works[0]);

            int currentDeadline = works[0].Deadline;

            for(int i = 0; i < works.Count; i++)
            {
                if(currentDeadline < works[i].Deadline)
                {
                    currentDeadline = works[i].Deadline;
                    selectedWorks.Add(works[i]);
                }
            }


            return selectedWorks;
        }
    }
}