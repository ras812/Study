using System;

namespace SortSpace
{
    public static class Level1
    {
        public static string BigMinus(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if ((Convert.ToInt32(s1[i]) < Convert.ToInt32(s2[i]) && i > 0 && Convert.ToInt32(s1[0]) == Convert.ToInt32(s2[0]))
                        || (Convert.ToInt32(s1[0]) < Convert.ToInt32(s2[0])))
                    {
                        string c = null;
                        c = s1;
                        s1 = s2;
                        s2 = c;
                        break;

                    }
                }
            }

            else if (s1.Length < s2.Length)
            {
                string c = null;
                c = s1;
                s1 = s2;
                s2 = c;
            }

            char[] arrA = s1.ToCharArray();
            char[] arrB = s2.ToCharArray();
            Array.Reverse(arrA);
            Array.Reverse(arrB);

            string result = null;
            for (int i = 0; i < arrA.Length; i++)
            {
                if (i < s2.Length)
                {
                    if (Convert.ToInt32(arrA[i]) < Convert.ToInt32(arrB[i]))
                    {
                        result = result + (Convert.ToString(Convert.ToInt32(arrA[i]) + 10 - Convert.ToInt32(arrB[i])));
                        if (i != arrA.Length - 1)
                        {
                            arrA[i + 1] = Convert.ToChar(Convert.ToInt32(arrA[i + 1] - 1));
                        }
                    }
                    else
                    {
                        result = result + (Convert.ToString(Convert.ToInt32(arrA[i]) - Convert.ToInt32(arrB[i])));
                    }
                }
                else // (i >= b.Length)
                {
                    result = result + (Convert.ToString(arrA[i]));
                }
            }

            char[] arrResult = result.ToCharArray();
            Array.Reverse(arrResult);
            result = null;
            for (int i = 0; i < arrResult.Length; i++)
            {
                result = result + arrResult[i];
            }

            string res = null; // delete nulls
            int flag = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '0' && flag == 0)
                {
                    flag = 0;
                    continue;
                }
                if (result[i] != '0')
                {
                    flag = 1;
                }

                res = res + result[i];
            }

            return res;
        }
    }
}
