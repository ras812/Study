using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static string PatternUnlock(int N, int[] hits)
        {
            double n = Math.Sqrt(2);    // корень из 2
            // матрица значений переходов
            double[,] arr = { 
                { 1, 0, 1, 0, 0, n, 1, 0, n, 1 },
                { 2, 1, 0, 1, n, 1, n, n, 1, n },
                { 3, 0, 1, 0, 1, n, 0, 1, n, 0 },
                { 4, 0, n, 1, 0, 1, 0, 0, 0, 0 },
                { 5, n, 1, n, 1, 0, 1, 0, 0, 0 },
                { 6, 1, n, 0, 0, 1, 0, 0, 0, 0 },
                { 7, 0, n, 1, 0, 0, 0, 0, 1, 0 },
                { 8, n, 1, n, 0, 0, 0, 1, 0, 1 },
                { 9, 1, n, 0, 0, 0, 0, 0, 1, 0 } };

            double sum = 0.0; // для работы с double

            string res = null;
            string tempStr = null;

            for (int i = 0; i < hits.Length - 1; i++) // проходим по всем элементам заданного массива за исключением последнего значения
            {
                for (int j = 0; j < arr.GetUpperBound(0) + 1; j++)  // построчный переход!!!возвращает ИНДЕКС последнего элемента пространства, не колличество элементов пространства!!!
                {
                    if (hits[i] == arr[j, 0])   // если элемент массива hits[i] равен значению первого элемента из матрицы arr[j, 0]
                    {
                        sum = sum + arr[j, hits[i + 1]];    // тогда прибавляем значение этого перехода к итоговой сумме
                    }
                }
            }

            res = Convert.ToString(Math.Round(sum, 5) * 100000);    // переводим в строковое значение из числового
            
            for (int i = 0; i < res.Length; i++)    // удаляем нули как символы из строки
            {
                if (res[i] != '0')
                {
                    tempStr = tempStr + res[i]; // помещаем во временную строку не нулевые значения
                }
            }

            res = null; // обнуляем результирующую строку
            for (int i = 0; i < tempStr.Length; i++)   // реверс строки
            {
                res = res + tempStr[i];
            }

            return res;
        }
        
        /*static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 2, 7, 2, 9 };
            Console.WriteLine("Result: {0}", PatternUnlock(0, arr));
            Console.ReadKey();
        }*/
    }
}
