using System;
using static System.Console;
using static System.Math;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter x: ");
            int x = Convert.ToInt32(ReadLine());
            Write("Enter y: ");
            int y = Convert.ToInt32(ReadLine());
            Write("Enter z: ");
            int z = Convert.ToInt32(ReadLine());

            double atmp1, atmp2;

            atmp1 = y - Sqrt(Abs(Pow(x, 3)));
            atmp2 = Sqrt(Pow(x, 3) + 5 * Pow(y, -z) + Pow(z, 2));

            double a = atmp1 / atmp2;
            double b = Sin(Pow(a, -x)) + y;

            WriteLine("a = " + a);
            Write("b = " + b);
        }
    }
}
