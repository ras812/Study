using System;
using System.Collections;

namespace Level1Space
{
    public static class Level1
    {
        public static string[] ShopOLAP(int N, string[] items)
        {
            if (items.Length == 1)
            {
                return items;
            }

            Array.Sort(items); // сортируем массив по возрастанию
            string[,] parsedItems = new string[items.Length, 2]; // инициализируем массив в две колонки
            string s = null;    // стринговая переменная для хранения временных значений
            int spaceFinder = 0;    // флаг поиска пробелов
            int sum = 0;    // временная переменная для суммирования значений

            for (int i = 0; i < items.Length; i++)  // формируем массив в два столбца
            {
                spaceFinder = 0;
                s = null;

                for (int j = 0; j < items[i].Length; j++)
                {
                    if (items[i][j] != ' ' && spaceFinder == 0)
                    {
                        spaceFinder = 0;
                        s += items[i][j];
                    }

                    if (items[i][j] == ' ')
                    {
                        parsedItems[i, 0] = s;
                        s = null;
                        spaceFinder = 1;
                        continue;
                    }

                    if (spaceFinder == 1)
                    {
                        s += items[i][j];
                    }

                    if (j == items[i].Length - 1 && spaceFinder == 1)
                    {
                        parsedItems[i, 1] = s;
                    }
                }
            }

            ArrayList arr = new ArrayList();    // инициализируем динамический массив
            s = null;   // сброс стринговой переменной для нового блока

            for (int i = 0; i < parsedItems.GetUpperBound(0); i++)  // last array index in demension
            {

                    s = parsedItems[i, 0] + " ";    // в начале каждой итерации формируем строку со значением каждого И-того элемента

                    if (!parsedItems[i, 0].Equals(parsedItems[i + 1, 0]))   // если текущее и последующее значение не совпадает
                    {
                        sum += Convert.ToInt32(parsedItems[i, 1]);
                        arr.Add(s + Convert.ToString(sum));
                        s = null;
                        sum = 0;
                    }

                    if (!parsedItems[i, 0].Equals(parsedItems[i + 1, 0]) && i == parsedItems.GetUpperBound(0) - 1)  // отдельно рассматриваем итерацию с последним элементом
                    {
                        s = parsedItems[i + 1, 0] + " ";
                        sum = Convert.ToInt32(parsedItems[i + 1, 1]);
                        arr.Add(s + Convert.ToString(sum));
                        s = null;
                        sum = 0;
                        //continue;
                    }

                    if (parsedItems[i, 0].Equals(parsedItems[i + 1, 0]))    // если текущее значение и последующее совпадают
                    {
                        sum += Convert.ToInt32(parsedItems[i, 1]);
                    }

                    if (parsedItems[i, 0].Equals(parsedItems[i + 1, 0]) && i == parsedItems.GetUpperBound(0) - 1)
                    {
                        sum += Convert.ToInt32(parsedItems[i + 1, 1]);
                        arr.Add(s + Convert.ToString(sum));
                        s = null;
                        sum = 0;
                    }

            }

            string[] arrString = (string[])arr.ToArray(typeof(string)); // преобразовываем динамический массив в стринговый массив фиксированной длинны

            return arrString;
        }

        public static class Test
        {
            public static void Testing()
            {
                string[] test1 = { "платье1 1" };
                Console.WriteLine(System.Linq.Enumerable.SequenceEqual(test1, Level1.ShopOLAP(0, test1)));

                string[] test21 = { "платье1 1", "платье1 2" };
                string[] test22 = { "платье1 3" };
                // string s1 = test22[0];
                // string s2 = Level1.ShopOLAP(0, test21)[0];

                // Console.WriteLine(test22 == Level1.ShopOLAP(0, test21)); // неработает
                // Console.WriteLine(test22.Equals(Level1.ShopOLAP(0, test21)));    // неработает
                // Console.WriteLine(s1 == s2); // работает с одним элементом
                Console.WriteLine(System.Linq.Enumerable.SequenceEqual(test22, Level1.ShopOLAP(0, test21)));

                string[] test31 = { "платье1 1", "сумка1 1", "платье1 1", "сумка1 1", "платье1 1", "сумка1 1" };
                string[] test32 = { "платье1 3", "сумка1 3" };

                Console.WriteLine(System.Linq.Enumerable.SequenceEqual(test32, Level1.ShopOLAP(0, test31)));

                string[] test41 = { "платье1 1", "сумка1 1", "платье2 1", "сумка2 1", "платье3 1", "сумка3 1" };
                string[] test42 = { "платье1 1", "платье2 1", "платье3 1", "сумка1 1", "сумка2 1", "сумка3 1" };

                Console.WriteLine(System.Linq.Enumerable.SequenceEqual(test42, Level1.ShopOLAP(0, test41)));

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // string[] shop = { "платье1 1" };
            // string[] shop = { "платье1 1", "сумка1 2" };
            // string[] shop = { "платье1 1", "платье1 2"};
            // string[] shop = { "платье1 1", "сумка1 1", "платье1 1", "сумка1 1", "платье1 1", "сумка1 1" };
            // string[] shop = { "платье1 1", "платье1 2", "платье1 3", "платье1 4", "платье1 5", "платье1 6" };
            // string[] shop = { "платье1 1", "сумка1 1", "платье2 1", "сумка2 1", "платье3 1", "сумка3 1" };

            // string[] shop = { "платье1 51", "платье1 11", "платье1 11", "платье1 11", "платье1 11", "платье1 11" };
            // string[] shop = { "платье1 2", "платье1 4", "платье2 3", "платье2 5", "платье3 7", "платье3 9", "платье4 11", "платье4 11" };

            Level1.Test.Testing();

            /*string[] arrS = Level1.ShopOLAP(0, shop);

            for (int i = 0; i < arrS.Length; i++)
            {
                Console.WriteLine("{0} ", arrS[i]);
            }*/

            Console.ReadKey();
        }
    }
}
