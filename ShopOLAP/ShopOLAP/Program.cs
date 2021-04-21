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

            string[] saledItemsName = new string[arrString.Length]; // массив переменных типа Стринг
            int[] saledItemsNum = new int[arrString.Length];    // ддля правильной сортировки необходимо значения Стринг перевести в Инт
            
            for (int i = 0; i < arrString.Length; i++)  // формируем два массива
            {
                spaceFinder = 0;
                s = null;

                for (int j = 0; j < arrString[i].Length; j++)
                {
                    if (arrString[i][j] != ' ' && spaceFinder == 0)
                    {
                        spaceFinder = 0;
                        s += arrString[i][j];
                    }

                    if (arrString[i][j] == ' ')
                    {
                        saledItemsName[i] = s;
                        s = null;
                        spaceFinder = 1;
                        continue;
                    }

                    if (spaceFinder == 1)
                    {
                        s += arrString[i][j];
                    }

                    if (j == arrString[i].Length - 1 && spaceFinder == 1)
                    {
                        saledItemsNum[i] = Convert.ToInt32(s);
                    }
                }
            }

            // сортировка по возрастанию осуществляется по первому массиву saledItemsNum с учетом свяей значений в массиве saledItemsName
            Array.Sort(saledItemsNum, saledItemsName);

            // реверс значений массивов
            string tempS = null;
            int tempI = 0;

            for (int i = 0; i < saledItemsName.Length / 2; i++) // при делении на 2 нечетного числа, округление проводится в меньшую сторону
            {
                tempS = saledItemsName[i];
                saledItemsName[i] = saledItemsName[saledItemsName.Length - i - 1];
                saledItemsName[saledItemsName.Length - i - 1] = tempS;
                tempS = null;

                tempI = saledItemsNum[i];
                saledItemsNum[i] = saledItemsNum[saledItemsNum.Length - i - 1];
                saledItemsNum[saledItemsNum.Length - i - 1] = tempI;
                tempI = 0;
            }

            // сортировка значений массива внутри заданного диапазона
            int countNum = 1;   // счетчик одинаковых значений saledItemsNum, начинается с 1 т.к. один элемент по умолчинию уже найден
            int startIndex = 0; // индекс начального значения для осуществления сортировки внутри значений массива

            for (int i = 0; i < saledItemsNum.Length - 1; i++)  // лексиграфическая сортировка элементов с одинаковыми значениями saledItemsNum
            {
                if (saledItemsNum[i] == saledItemsNum[i + 1])
                {
                    startIndex = i; // индекс массива с котогро начинается сортировка
                    for (int j = i; j < saledItemsNum.Length - 1; j++)  // считаем колличество подряд идущих одинаковых элементов
                    {
                        if (saledItemsNum[j] == saledItemsNum[j + 1])
                        {
                            countNum++;
                        }
                        else
                        {
                            break;  // прерываем массив если последующее значение не равно текущему
                        }
                    }
                    Array.Sort(saledItemsName, startIndex, countNum);   // сортируем массив элементов в заданном диапазоне
                    i = startIndex + countNum - 1;  // после сортировки продолжаем поиск одинаковых элементов с нового места основного массива
                    startIndex = 0; // сбрасываем значение начального индекса
                    countNum = 1;   // сбрасываем счетчик для возможной следующей итерации
                }
            }

            for (int i = 0; i < arrString.Length; i++)
            {
                arrString[i] = saledItemsName[i] + " " + Convert.ToString(saledItemsNum[i]);
            }

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
            string[] shop = { "платье30 5", "платье20 3", "платье1 4", "платье1 6", "платье2 4", "платье2 6", "платье4 4", "платье4 6", "платье3 17", "платье3 19", "платье5 1", "платье5 1", "платье7 1", "платье7 1", "платье6 1", "платье6 1", "платье9 2", "платье9 2", "платье8 2", "платье8 2", "платье10 2", "платье10 2" };

            // Level1.Test.Testing();

            // Level1.ShopOLAP(0, shop);

            string[] arrS = Level1.ShopOLAP(0, shop);

            for (int i = 0; i < arrS.Length; i++)
            {
                Console.WriteLine("{0} ", arrS[i]);
            }

            Console.ReadKey();
        }
    }
}
