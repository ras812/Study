using System;

namespace Level1Space
{
    public static class Level1
    {
        public static bool LineAnalysis(string line)
        {
            int count = 0;              // счетчик
            int arrIndexCount = 0;      // счетчик порядковых номеров массива arr[] 
            bool rez = false;           // результирующая переменная
            int z = 0;                  // буферная переменная для сортировки


            if (line.Length == 1)               // если исходная строка 
            {
                rez = true;
            }

            else if (line.Length > 1)
            {

                for (int i = 0; i < line.Length; i++)   // считаем колличество "*" в исходной строке
                {
                    if (line[i] == '*')
                    {
                        count++;
                    }
                }

                int[] arr = new int[count - 1];     // на основе подсчитанных значений создаем массив колличества элементов помещенных между "*"
                count = 0;                          // сбрасываем счетчик для вышестоящей задачи, т.к. будем использовать его в другой задаче

                for (int i = 1; i < line.Length; i++)   // считаем количество символов между "*" и записываем их полследовательно в массив
                {
                    if (line[i] != '*')
                    {
                        count++;                        // в этом диалоге переменная считает количество символов между "*"
                    }
                    else if (line[i] == '*')
                    {
                        arr[arrIndexCount] = count;
                        arrIndexCount++;
                        count = 0;
                    }
                }

                for (int i = 0; i < arr.Length; i++)      // сортируем массив по убыванию
                {
                    for (int j = 0; j < arr.Length - 1; j++)
                    {
                        if (arr[j + 1] >= arr[j])
                        {
                            z = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = z;
                        }
                    }
                }

                if (arr.Length < 2)     // если в массиве arr[] всего один элемент, то нам не с чем его сравнивать
                {
                    rez = true;
                }

                else if (arr.Length >= 2)   // сравниваем первый элемент массива arr[] с остальными
                {
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[0] != arr[i])   // если значение первого элемента не совпадает со всеми остальными, то начальная строка имеет ошибки
                        {
                            rez = false;
                            break;
                        }
                        else if (arr[0] == arr[i])  // если значение первого элемента совпадает со всеми остальными, то ошибок не обнаружено
                        {
                            rez = true;
                        }
                    }
                }

            }
            return rez;
        }
    }
}
