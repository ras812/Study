using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level1Space
{
    public static class Level1
    {
        public static int MaximumDiscount(int N, int[] price)
        {
            int z = 0;
            int sumDiscount = 0;

            for (int i = 0; i < price.Length; i++)
            {
                for (int j = 0; j < price.Length - 1; j++)
                {

                    if (price[j + 1] >= price[j])
                    {
                        z = price[j + 1];
                        price[j + 1] = price[j];
                        price[j] = z;
                    }
                }
            }

            for (int i = 0; i < price.Length; i++)
            {
                if ((i + 1) % 3 == 0 && price.Length >= 3)
                {
                    sumDiscount += price[i];
                }
                else if(price.Length < 3)
                {
                    sumDiscount = 0;
                    break;
                }
            }

            return sumDiscount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] price = { 400, 300, 350, 100, 200, 150, 250 };
            Console.WriteLine(Level1.MaximumDiscount(7, price));
            Console.ReadKey();
        }
    }
}
