using System;
using System.Collections.Generic;
using System.Collections;

namespace SortSpace
{
    public static class SortLevel
    {
        public static int[] WordSearch(int len, string s, string subs)
        {
            // len кол-во символов ширина выравнивания, s исходная строка, sub поисковое слово
            // динамический массив (неопределенного колиичества элементов)
            ArrayList arr = new ArrayList();
            // флаг - то место в строке, где будем прерывать работу цикла
            int flag = 0;

            // цикл прохода по строке. Обрезаем с начала основной строки символы, пока в основной строке есть символы.
            while (s.Length > 0)
            {
                // если первый символ "пробел", то удаляем его из строки
                if (s[0] == ' ')
                {
                    s = s.Remove(0, 1);
                    continue;
                }

                else
                {
                    // чтоб не запутаться, приводим все значения к "индексам"
                    if (len - 1 < s.Length - 1)    // индексы символов (индексы разбивки меньше последнего индекса строки)
                    {
                        flag = 0;   // обнуляем флаг в начале каждого нового цикла

                        for (int i = 0; i < len; i++)   // проходим по отрезку длинной в len
                        {
                            if (s[i] == ' ')    // если находим пробел
                            {
                                flag = i;   // записываем во флаг индекс (количество символов будет больше на +1)
                            }

                            else if (flag == 0) // если флаг не менял значений, значит пробелов небыло и придется обрезать строку в одно слово по длинне обрезки
                            {
                                flag = len;
                            }
                        }

                    }

                    else if (len - 1 >= s.Length - 1)   // индексы символов
                    {
                        flag = s.Length; // количество символов (обрезаем остаток строки)
                    }

                    arr.Add(s.Substring(0, flag));  // количество символов (добавляем обрезанную строку в массив как элемент массива)
                    s = s.Remove(0, flag);  // количество символов (отрезаем от основной строки, то что добавили в массив)
                }
            }

            // конвертируем из динамического массива arr в массив фиксированной длинны arrString
            string[] arrString = (string[])arr.ToArray(typeof(string));

            // for (int i = 0; i < arrString.Length; i++)
            // {
            //    Console.WriteLine("arrString: " + arrString[i]);
            // }

            // Console.WriteLine("s: " + s);

            // создаем массив с итоговыми значениями
            int[] search = new int[arrString.Length];
            // буферная строка для сравнения значений
            string compareString = "";
            // цикл поиска равнозначных значений
            for (int i = 0; i < arrString.Length; i++)
            {

                for (int j = 0; j < arrString[i].Length; j++)
                {
                    if (arrString[i][j] != ' ') // добавляем символы в буферную строку
                    {
                        compareString = compareString + arrString[i][j];
                    }

                    if (arrString[i][j] == ' ' || j + 1 == arrString[i].Length)   // если пробел или конец строки, то проверяем на соответствие
                    {
                        if (compareString.Equals(subs) == true)
                        {
                            search[i] = 1;
                            compareString = null;
                            break;
                        }

                        else
                        {
                            search[i] = 0;
                            compareString = null;
                        }

                        continue;
                    }

                }

            }

            // for (int i = 0; i < search.Length; i++)
            // {
            //    Console.WriteLine(search[i]);
            // }

            return search;
        }
        // static void Main(string[] args)
        // {
        //    string s = "Пустые строки в такой разбивке полностью исключаются. Если ширина разбивки меньше какого-то слова, то это слово разбивается на несколько (с переносом на следующую строку).";
        //    string subs = "слово";
        //    int[] rez = WordSearch(10, s, subs);
        //    for (int i = 0; i < rez.Length; i++)
        //    {
        //        Console.WriteLine(rez[i]);
        //    }
        //    Console.ReadKey();
        // }
    }
}
