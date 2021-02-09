using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level1Space
{
    public static class Level1
    {
        public static string MassVote(int N, int[] Votes)
        {
            string rezStr = null;   // результирующая строка
            int[] votesReserv = new int[Votes.Length];  // временный массив для сортировки по убыванию
            int votesMax = 0;   // максимальное значение в массиве
            int z = 0;  // временная переменная для сортировки массива по убыванию
            int k = 0;  // порядковый номер (не индекс) максимального числа в массиве
            int sum = 0;    // сумма всех чисел голосов в массиве
            double percent = 0.000;   // процентное соотношение с точностью до трех знков после запятой

            if (Votes.Length == 1)  // если был только один кандидат и голосовали только за него
            {
                rezStr = "majority winner 1";
            }
            else if (Votes.Length > 1)  // если кандидатов было 2 и более
            {
                for (int i = 0; i < Votes.Length; i++)  // копируем основной массив голосов во временный
                {
                    votesReserv[i] = Votes[i];
                }

                z = votesReserv[0];
                for (int i = 0; i < votesReserv.Length; i++)    // сортируем его по убыванию
                {
                    for (int j = 1; j < votesReserv.Length; j++)
                    {
                        if (votesReserv[j] >= votesReserv[j - 1])
                        {
                            z = votesReserv[j - 1];
                            votesReserv[j - 1] = votesReserv[j];
                            votesReserv[j] = z;
                        }
                    }
                }

                if (votesReserv[0] == votesReserv[1])   // если хотябы первые два элемента массива будут самыми большими и равными по значению
                {                                       // тогда перевыборы
                    rezStr = "no winner";
                }

                else
                {
                    votesMax = Votes[0];
                    k = 1;
                    for (int i = 1; i < Votes.Length; i++)  // находим в основном массиве голосов максимальное значение 
                    {                                       // и определяем номер по порядку этого элемента
                        if (Votes[i] >= votesMax)
                        {
                            votesMax = Votes[i];
                            k = i + 1;
                        }
                    }

                    sum = 0;
                    for (int i = 0; i < Votes.Length; i++)  // находим сумму элементов массива
                    {
                        sum = sum + Votes[i];
                    }

                    // определяем процент с округлением до третьего знака после запятой
                    percent = (Convert.ToDouble(votesMax) / Convert.ToDouble(sum)) * 100000;
                    percent = Math.Round(percent, 0);
                    percent = percent / 1000;


                    // выбираем один из вариантов решения в зависимости от рассчитанного процента голосования
                    if (percent > Convert.ToDouble(50))
                    {
                        rezStr = "majority winner " + k;
                    }
                    else if (percent <= Convert.ToDouble(50))
                    {
                        rezStr = "minority winner " + k;
                    }

                }

            }

            return rezStr;
        }
    }
}
