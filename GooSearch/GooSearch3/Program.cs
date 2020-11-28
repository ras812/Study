using System;
using System.Collections.Generic;
using System.Collections;

namespace Level1Space
{
    public static class Level1
    {
        public static int[] WordSearch(int len, string s, string subs)
        {
            // len кол-во символов ширина выравнивания, s исходная строка, sub поисковое слово
            // динамический массив (неопределенного колиичества элементов)
            ArrayList arr = new ArrayList();
            // флаг - то место в строке, где будем прерывать работу цикла
            int flag = 0;

            // Console.WriteLine("Начальное значение базовой строки: " + s);

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
                    if (s.Length - 1 > len - 1)    // индексы символов (индексы разбивки меньше последнего индекса строки)
                    {
                        flag = 0;   // обнуляем флаг в начале каждого нового цикла

                        for (int i = 0; i < len; i++)   // проходим по отрезку длинной в len
                        {
                            if (s[i] == ' ')    // если находим пробел
                            {
                                flag = i;   // записываем во флаг индекс (количество символов будет больше на +1)
                            }

                            else if (flag == 0 || (s[i] != ' ' && s[i + 1] == ' ')) // если флаг не менял значений, значит пробелов небыло и придется обрезать строку в одно слово по длинне обрезки
                            {
                                flag = len;
                            }
                        }

                    }

                    else if (s.Length - 1 <= len - 1)   // индексы символов
                    {
                        flag = s.Length; // количество символов (обрезаем остаток строки)
                    }

                    arr.Add(s.Substring(0, flag));  // количество символов (добавляем обрезанную строку в массив как элемент массива)
                    s = s.Remove(0, flag);  // количество символов (отрезаем от основной строки, то что добавили в массив)
                }
            }

            // конвертируем из динамического массива arr в массив фиксированной длинны arrString
            string[] arrString = (string[])arr.ToArray(typeof(string));

            // Console.WriteLine("Формирование массива с разбивкой строк по ширине {0} символов.", len);

            // for (int i = 0; i < arrString.Length; i++)
            // {
            //     Console.WriteLine("Значение {0} элемента массива: " + arrString[i], i);
            // }

            // Console.WriteLine("Значение базовой строки после разбивки: " + s);

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

                    }

                }

            }

            return search;
        }
        // static void Main(string[] args)
        // {
            // string s = "1) stroka razbivaetsya na nabor strok cherez vyravnivanie po zadannoj shirine.";
            // string sub = "strok";
            // string s = "12345";
            // string sub = "345";
            // int[] rez = WordSearch(12, s, sub);
            // for (int i = 0; i < rez.Length; i++)
            // {
                // if (rez[i] == 1)
                // {
                    // Console.WriteLine("Значение {0} найдено в строке с индексом {1}.", sub, i);
                // }
                // else
                // {
                    // Console.WriteLine("Значение {0} не найдено в строке с индексом {1}.", sub, i);
                // }
            // }
            // Console.ReadKey();
        // }
    }
}
