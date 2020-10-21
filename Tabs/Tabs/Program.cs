using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static int[] SynchronizingTables(int N, int[] ids, int[] salary)
        {
            int temp = 0;
            int min;
            int max = ids[0]; // инициализируем первым элементом массива
            int minPrev = 0; // минимальное значение найденное в предыдущей итерации


            int[] itogArr = new int[salary.Length]; // временный массив для хранения индексов сортированных элементом массива ids[]

            // сортируем массив зарплат
            for (int i = 0; i < salary.Length; i++)
            {
                for (int j = 0; j < salary.Length-1; j++)
                {
                    if (salary[j] >= salary[j + 1])
                    {
                        temp = salary[j];
                        salary[j] = salary[j + 1];
                        salary[j + 1] = temp;
                    }
                }
            }

            // находим максимальное значение в массиве ids[]
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] > max)
                {
                    max = ids[i];
                }
            }

            for (int i = 0; i < ids.Length; i++)
            {
                min = max; // для инициализации поиска 

                for (int j = 0; j < ids.Length; j++)
                {
                    if (ids[j] > minPrev) // в каждой последующей итерации новое минимальное значение всегда больше предыдущего минимального
                    {
                        if (ids[j] < min)
                        {
                            min = ids[j];
                        }
                    }
                } 

                // находим индекс минимального значения в массиве ids[]
                for (int k = 0; k < ids.Length; k++)
                {
                    if (ids[k] == min)
                    {
                        itogArr[k] = salary[i]; // и присваиваем согдасно этому индексу значение из массива salary[] отсортированного по возрастанию
                    }
                }
                minPrev = min; // сужаем поиск минимального значения в массиве ids[]
            }

            // print itog
            //for (int i = 0; i < itogArr.Length; i++)
            //{
            //    Console.WriteLine(itogArr[i]);
            //}

            return itogArr;
        }

        /*static void Main(string[] args)
        {
            int[] ids = {50, 1, 1024};
            int[] salary = { 20, 100, 90};
            SynchronizingTables(5, ids, salary);
            Console.ReadKey();
        }*/
    }
}
