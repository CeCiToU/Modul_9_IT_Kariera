
namespace Mult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int mult = Mult(n, m);

            Console.WriteLine(mult);
        }

        private static int Mult(int n, int m)
        {
            int mult = m;

            if (n > 1)
            {
                return mult + Mult(n - 1, m);
            }

            return mult;
        }
    }
}