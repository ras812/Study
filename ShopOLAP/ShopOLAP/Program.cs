using System;
using System.Collections;

namespace Level1Space
{
    public static class Level1
    {
        public static string[] ShopOLAP(int N, string[] items)
        {
            Array.Sort(items);
            /*for (int i = 0; i < items.Length; i++)
            {
                Console.Write("{0} ", items[i]);
            }
            Console.WriteLine();*/
            string[,] parsedItems = new string[items.Length, 2];
            string temp = null;
            int spaceFinder = 0;

            for (int i = 0; i < items.Length; i++)
            {
                spaceFinder = 0;
                temp = null;

                for (int j = 0; j < items[i].Length; j++)
                {
                    if (items[i][j] != ' ' && spaceFinder == 0)
                    {
                        spaceFinder = 0;
                        temp += items[i][j];
                    }

                    if (items[i][j] == ' ')
                    {
                        parsedItems[i, 0] = temp;
                        temp = null;
                        spaceFinder = 1;
                        continue;
                    }

                    if (spaceFinder == 1)
                    {
                        temp += items[i][j];
                    }

                    if (j == items[i].Length - 1 && spaceFinder == 1)
                    {
                        parsedItems[i, 1] = temp;
                    }
                }
            }

            Console.WriteLine("Parsed string array:");
            for (int i = 0; i < parsedItems.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ", parsedItems[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("ArrayList:");

            ArrayList arr = new ArrayList();
            int sum = 0;

            for (int i = 0; i < parsedItems.GetUpperBound(0); i++)  // last array index in demension
            {
                if (parsedItems.GetUpperBound(0) == 0)
                {
                    sum = Convert.ToInt32(parsedItems[i, 1]);
                    arr.Add(parsedItems[i, 0] + " " + sum);
                    sum = 0;
                    break;
                }


                if (parsedItems.GetUpperBound(0) > 0)
                {
                    if (!parsedItems[i, 0].Equals(parsedItems[i + 1, 0]))
                    {
                        sum = Convert.ToInt32(parsedItems[i + 1, 1]);
                        arr.Add(parsedItems[i + 1, 0] + " " + sum);
                        sum = 0;
                        /*if (i == parsedItems.GetUpperBound(0) - 1)
                        {
                            sum = Convert.ToInt32(parsedItems[i + 1, 1]);
                            arr.Add(parsedItems[i + 1, 0] + " " + sum);
                            sum = 0;
                        }*/
                    }

                    if (parsedItems[i, 0].Equals(parsedItems[i + 1, 0]))
                    {
                        sum += Convert.ToInt32(parsedItems[i, 1]);
                        if (i <= parsedItems.GetUpperBound(0) - 1)
                        {
                            sum = sum + Convert.ToInt32(parsedItems[i + 1, 1]);
                            arr.Add(parsedItems[i, 0] + " " + sum);
                            sum = 0;
                        }
                    }
                }
            }

        string[] arrString = (string[])arr.ToArray(typeof(string));

        for (int i = 0; i < arrString.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }

            /*for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(parsedItems[i, 1]);
            }

            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write("{0} ",parsedItems[i, j]);
                }
                Console.WriteLine();
            }*/

            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // string[] shop = { "платье1 51", "сумка32 21", "платье1 11", "сумка23 21", "платье1 11", "сумка128 41", "платье1 11" };
            // string[] shop = { "платье1 51", "платье1 11", "платье1 11", "платье1 11", "платье2 11" };
            // string[] shop = { "платье1 51", "платье1 11", "платье1 11", "платье1 11", "платье1 11", "платье1 11" };
            string[] shop = { "платье1 51", "платье1 11", "платье2 11", "платье2 11", "платье3 11", "платье3 11" };


            Level1.ShopOLAP(0, shop);
            Console.ReadKey();
        }
    }
}
