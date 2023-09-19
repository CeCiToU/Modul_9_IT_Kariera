namespace Recursion
{
    internal class Program
    {
        static void Main()
        {
            /* Problem 1 from pptx -> Biggest common deviser
             
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine()); 

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Biggest common deviser is => ");
            Console.WriteLine(NOD(a, b));

            Console.WriteLine();

            */

            /* Problem 2 from pptx -> Fibonacci sequence
            
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Fib number is: ");
            Console.WriteLine(Fib(n));

            Console.WriteLine();

            */

            /* Problem 3 from pptx -> Least common multiple
             
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Least common multiple is => ");
            Console.WriteLine(NOK(a, b));

            Console.WriteLine();

            */


            //Main();
        }

        static int NOD(int a, int b)
            {

                if (a > b)
                {
                    a = a - b;
                }
                else if (b > a)
                {
                    b = b - a;
                }
                else if (a == b)
                {
                    return a;
                }

                int result = NOD(a, b);

                return result;
            }

            static int NOK(int a, int b)
            {
                int result = 0;

                result = a * b;

                result = result / NOD(a, b);

                return result;
            }

            static int Fib(int n)
            {
                if (n == 1 || n == 2)
                {
                    return 1;
                }
                else
                {
                    return Fib(n - 1) + Fib(n - 2);
                }
            }
        }
    }
}