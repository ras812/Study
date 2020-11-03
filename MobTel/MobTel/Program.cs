using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static string PatternUnlock(int N, int[] hits)
        {
            double n=0.00000;
            double sum = 0.00000;
            int lastDigit = 0;
            int tempNum = 0;
            int digitNums = 0;
            int itog = 0;
            string itogString = null;



            for (int i = 0; i < hits.Length - 1; i++)
            {

                if (
                    (hits[i] == 1 && ((hits[i + 1]) == 2 || (hits[i + 1]) == 6 || (hits[i + 1]) == 9)) ||
                    (hits[i] == 3 && ((hits[i + 1]) == 2 || (hits[i + 1]) == 4 || (hits[i + 1]) == 7)) ||
                    (hits[i] == 2 && ((hits[i + 1]) == 1 || (hits[i + 1]) == 3 || (hits[i + 1]) == 5 || (i + 1) == 8)) ||
                    (hits[i] == 5 && ((hits[i + 1]) == 2 || (hits[i + 1]) == 4 || (hits[i + 1]) == 6)) ||
                    (hits[i + 1] == 5 && ((hits[i]) == 2 || (hits[i]) == 4 || (hits[i]) == 6)) ||
                    (hits[i] == 8 && ((hits[i + 1]) == 2 || (hits[i + 1]) == 7 || (hits[i + 1]) == 9)) ||
                    (hits[i + 1] == 8 && ((hits[i]) == 2 || (hits[i]) == 7 || (hits[i]) == 9)) ||
                    (hits[i] == 6 && (hits[i + 1] == 1 || hits[i + 1] == 5)) ||
                    (hits[i] == 9 && (hits[i + 1] == 1 || hits[i + 1] == 8)) ||
                    (hits[i] == 7 && (hits[i + 1] == 8 || hits[i + 1] == 3)) ||
                    (hits[i] == 4 && (hits[i + 1] == 3 || hits[i + 1] == 5))
                   )
                {
                    n = 1;
                }

                if (
                    (hits[i] == 2 && (hits[i + 1] == 4 || hits[i + 1] == 6 || hits[i + 1] == 7 || hits[i + 1] == 9)) ||
                    (hits[i + 1] == 2 && (hits[i] == 4 || hits[i] == 6 || hits[i] == 7 || hits[i] == 9)) ||
                    ((hits[i] == 1 || hits[i] == 3) && (hits[i+1] == 5 || hits[i+1] == 8))
                   )
                {
                    n=1.41421;
                }

                sum = sum + n;
                // Console.WriteLine("Sum: {0}", sum);
            }

            itog = Convert.ToInt32(sum * 100000);

            digitNums = Convert.ToString(itog).Length;

            for (int i = 0; i < digitNums; i++)
            {
                lastDigit = itog % 10;

                if (lastDigit != 0)
                {
                    tempNum = (tempNum * 10) + lastDigit;        
                }

                itog = itog / 10;

                // Console.WriteLine("Remove zero: {0}", tempNum);
            }

            digitNums = Convert.ToString(tempNum).Length;
            lastDigit = 0;

            for (int i = 0; i < digitNums; i++)
            {
                lastDigit = tempNum % 10;
                itog = itog * 10 + lastDigit;
                tempNum = tempNum / 10;
                // Console.WriteLine("Revers: {0}",itog);
            }

            itogString = Convert.ToString(itog);

            return itogString;
        }

        /*static void Main(string[] args)
        {
            int[] arr = { 1, 9 };
            Console.WriteLine("Result: {0}", PatternUnlock(0, arr));

            Console.ReadKey();
        }*/
    }
}
