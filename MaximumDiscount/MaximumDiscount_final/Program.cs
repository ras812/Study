using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level1Space
{
    public static class Level1
    {
        public static int MaximumDiscount(int N, int[] price)
        {
            int z = 0;                  // временная переменная для сортировки
            int sumDiscount = 0;        // итоговое значение

            for (int i = 0; i < price.Length; i++)      // сортируем массив по убыванию
            {
                for (int j = 0; j < price.Length - 1; j++)
                {

                    if (price[j + 1] >= price[j])
                    {
                        z = price[j + 1];
                        price[j + 1] = price[j];
                        price[j] = z;
                    }
                }
            }

            for (int i = 0; i < price.Length; i++)      // отбираем каждый третий элемент массива и суммируем их
            {
                if ((i + 1) % 3 == 0 && price.Length >= 3)
                {
                    sumDiscount += price[i];
                }
                else if (price.Length < 3)  // если элементов массива изначально меньше чем 3 (три) выводим нулевой результат
                {
                    sumDiscount = 0;
                    break;
                }
            }

            return sumDiscount;
        }
    }
}
