using System;

namespace Level1Space
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
                for (int j = 0; j < tempCharArr.Length; j++)
                {
                    if (octal == true)
                    {
                        pow = 8;
                    }
                    else
                    {
                        pow = 16;
                    }
                    sum = sum + (Convert.ToInt32(Convert.ToString(tempCharArr[j])) * Convert.ToInt32(Math.Pow(pow, j)));

                }
                result[i] = sum;
            }

            return result;
        }
    }
}
