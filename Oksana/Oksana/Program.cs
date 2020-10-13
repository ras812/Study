using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static int odometer(int[] oksana)
        {
            int distance = 0;
            
            for (int i = 0; i < oksana.Length; i++)
            {
                if (i < 2 && i % 2 == 1)
                {
                    distance = oksana[i] * oksana[i-1];
                }
                else if (i % 2 == 1)
                {
                    distance = distance + (oksana[i - 1] * (oksana[i] - oksana[i - 2]));
                }
            }
            return distance;
        }
    
        /*static void Main(string[] args)
        {
            int[] arr = {20, 1, 30, 4};
            Console.WriteLine(odometer(arr));
            Console.ReadKey();
        }*/
    }
}
