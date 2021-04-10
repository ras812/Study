using System;

namespace Level1Space
{
    public static class Level1
    {
        public static string[] ShopOLAP(int N, string[] items)
        {
            Array.Sort(items);
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write("{0} ", items[i]);
            }
            Console.WriteLine();
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

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(parsedItems[i, 0]);
            }

            for (int i = 0; i < items.Length; i++)
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
            }

            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] shop = { "платье1 51", "сумка32 21", "платье1 11", "сумка23 21", "сумка128 41" };
            Level1.ShopOLAP(0, shop);
        }
    }
}
