using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static int squirrel(int N)
        {
            // факториал
            int factorial = 1;
            for (int i = 1; i < (N + 1); i++)
            {
                factorial = factorial * i;
            }

            // первое число символа
            int m = factorial;
            while (m != m % 10)
            {
                m = m / 10;
            }

            // Console.WriteLine("Первая цифра факториала: {0}", m);
            // Console.WriteLine("Факториал числа !{0} равен: {1}", n, factorial);
            return m;
        }

        /*static void Main(string[] args)
        {
            Console.WriteLine(Squirrel(10));
            Console.ReadKey();
        }*/
    }
}
