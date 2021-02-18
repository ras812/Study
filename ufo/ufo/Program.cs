using System;

namespace ufo
{
    public static class Level1
    {
        public static int[] UFO(int N, int[] data, bool octal)
        {
            int pow = 0;
            int[] result = new int[data.Length];
            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                char[] tempCharArr = Convert.ToString(data[i]).ToCharArray();
                Array.Reverse(tempCharArr);
                sum = 0;
                for (int k = 0; k < tempCharArr.Length; k++)
                {
                    if (octal == true)
                    {
                        pow = 8;
                    }
                    else
                    {
                        pow = 16;
                    }
                    sum = sum + (Convert.ToInt32(Convert.ToString(tempCharArr[k])) * Convert.ToInt32(Math.Pow(pow, k)));
                    
                }
                result[i] = sum;
            }
            
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1234, 1777, 1234, 1777 };
            int[] rez = new int[data.Length];
            rez = Level1.UFO(2, data, true);
            for (int i = 0; i < rez.Length; i++)
            {
                Console.Write(" {0}", rez[i]);
            }
        }
    }
}
