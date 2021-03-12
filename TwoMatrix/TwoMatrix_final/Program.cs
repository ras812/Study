using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level1Space
{
    public static class Level1
    {
        public static bool TankRush(int H1, int W1, string S1, int H2, int W2, string S2)
        {
            int[,] mapS1 = new int[H1, W1];     // массив карты
            int[,] mapS2 = new int[H2, W2];     // массив карты обстрела
            string S1new = null;                // преобразованная строка S1 без пробелов
            string S2new = null;                // преобразованная строка S2 без пробелов
            bool artobstrel = false;            // итоговая переменная (не будет менять условие если не выполняется условие задачи)

            for (int i = 0; i < S1.Length; i++) // преобразование строки S1
            {
                if (S1[i] == ' ')
                {
                    continue;
                }
                S1new += S1[i];
            }

            for (int i = 0; i < S2.Length; i++) // преобразование строки S2
            {
                if (S2[i] == ' ')
                {
                    continue;
                }
                S2new += S2[i];
            }

            for (int i = 0; i < mapS1.GetUpperBound(0) + 1; i++)    // перемещение значений строки в двумерный массив mapS1
            {
                for (int j = 0; j < mapS1.GetUpperBound(1) + 1; j++)
                {
                    mapS1[i, j] = Convert.ToInt32(Convert.ToString(S1new[0]));
                    S1new = S1new.Remove(0, 1);
                }
            }

            for (int i = 0; i < mapS2.GetUpperBound(0) + 1; i++)    // перемещение значений строки в двумерный массив mapS2
            {
                for (int j = 0; j < mapS2.GetUpperBound(1) + 1; j++)
                {
                    mapS2[i, j] = Convert.ToInt32(Convert.ToString(S2new[0]));
                    S2new = S2new.Remove(0, 1);
                }
            }

            int bigFlag = -1;   // если массив mapS2 содержится внутри массива mapS1
            int midFlag = -1;   // если один из элементов массива mapS2 содержится в массиве mapS1

            for (int i = 0; i < (H1 - H2 + 1); i++)         // проходим по элементам массива mapS1 с условием, что при проверке вложенных элементов
            {                                               // не выйдем за его пределы
                for (int j = 0; j < (W1 - W2 + 1); j++)
                {
                    if (mapS1[i, j] == mapS2[0, 0])         // если мы нашли нулевой элемент в массиве mapS1
                    {
                        midFlag = -1;   // сброс флага

                        for (int m = 0; m < mapS2.GetUpperBound(0) + 1; m++)    // сравниваем элементы двух массивов в новой области
                        {

                            for (int n = 0; n < mapS2.GetUpperBound(1) + 1; n++)
                            {

                                if (mapS2[m, n] == mapS1[i + m, j + n]) // размерность меняется чтоб сравнить два разных массива
                                {
                                    midFlag = 1;    // если условие верно, переходим к проверке следующего элемента
                                    continue;
                                }
                                else
                                {
                                    midFlag = 0;    // если найдено несовпадение, прерываем работу вторичного цикла
                                    break;
                                }
                            }

                            if (midFlag == 0)   // выявлено несовпадение на предыдущем шаге, прерываем работу первичного цикла
                            {
                                break;
                            }
                        }
                    }

                    if (midFlag == 1)   // если в данном квадрате имеется полное совпадение массивов, стрелять будем сюда
                    {       
                        bigFlag = 1;
                        break;          // прерываем вторичный цикл при полном совпадении
                    }
                }

                if (bigFlag == 1)       // прерываем выполнение первичного цикла при совпедении и меняем итоговое значение переменной artobstrel
                {
                    artobstrel = true;
                    break;
                }                       // если результат будет отрицательный на протяжении работы первичного и вторичного массивов
            }                           // то значение переменной artobstrel не поменяется

            return artobstrel;
        }
    }
}
