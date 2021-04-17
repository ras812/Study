﻿using System;
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
            int sum = 0;    // временная переменная для суммирования значений
            s = null;   // сброс стринговой переменной для нового блока

            for (int i = 0; i < parsedItems.GetUpperBound(0); i++)  // last array index in demension
            {

                if (parsedItems.GetUpperBound(0) > 0)   // если элементов больше чем один
                {
                    s = parsedItems[i, 0] + " ";    // в начале каждой итерации формируем строку со значением каждого итого элемента

                    if (!parsedItems[i, 0].Equals(parsedItems[i + 1, 0]))   // если текущее и последующее значение не совпадает
                    {
                        sum += Convert.ToInt32(parsedItems[i, 1]);
                        arr.Add(s + sum);
                        s = null;
                        sum = 0;
                    }

                    if (!parsedItems[i, 0].Equals(parsedItems[i + 1, 0]) && i == parsedItems.GetUpperBound(0) - 1)  // отдельно рассматриваем итерацию с последним элементом
                    {
                        s = parsedItems[i + 1, 0] + " ";
                        sum = Convert.ToInt32(parsedItems[i + 1, 1]);
                        arr.Add(s + sum);
                        s = null;
                        sum = 0;
                        continue;
                    }

                    if (parsedItems[i, 0].Equals(parsedItems[i + 1, 0]))    // если текущее значение и последующее совпадают
                    {

                        sum += Convert.ToInt32(parsedItems[i, 1]);
                    }

                    if (parsedItems[i, 0].Equals(parsedItems[i + 1, 0]) && i == parsedItems.GetUpperBound(0) - 1)
                    {
                        sum += Convert.ToInt32(parsedItems[i + 1, 1]);
                        arr.Add(s + sum);
                        s = null;
                        sum = 0;
                    }

                }

            }

            string[] arrString = (string[])arr.ToArray(typeof(string)); // преобразовываем динамический массив в стринговый массив фиксированной длинны

            return arrString;
        }
    }
}
