using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level1Space
{
    public static class Level1
    {
        public static int Unmanned(int L, int N, int[][] track)
        {
            int trackLenght = 0;    // суммарное время автомобиля в пути
            bool svetofor = false;  // флаг, определяющий, есть ли в данной точки пути светофор
            int n = 0;              // время ожидание в точке нахождения светофора

            for (int i = 0; i < L; i++)     // проверяем каждую точку пути
            {
                for (int j = 0; j < N; j++) // ищем в данной точки пути светофор
                {
                    svetofor = false;   // предполагаем, что в данной точки пути светофора изначально нет

                    if (track[j][0] == i + 1)   // но если светофор всетаки находится
                    {
                        svetofor = true;    // то определяем, что он в данном месте есть
                        n = 1;  // добавляем единицу, так как в точку со светофором машина уже приехала

                        // x = (trackLenght + 1) % (track[j][1] + track[j][2]); // расчет остатка от деления по модулю по отношению к длинне общего пройденного времени в пути

                        // цикл выполняется пока светофор горит КРАСНЫМ
                        // [a, b, c]   x = n / |b+c| n-время в пути, если (x>=0 && x<=(b-1)), тогда горит красный
                        // и машина ожидает на светофоре накапливая время, до тех пор, пока не загорится ЗЕЛЕНЫЙ
                        while ((trackLenght + n) % (track[j][1] + track[j][2]) >= 0 && 
                               (trackLenght + n) % (track[j][1] + track[j][2]) <= (track[j][1] - 1))
                        {
                            n++;
                        }
                        break;  // прерываем цикл после его окончания
                    }

                }

                if (svetofor == false)  // если в данной точки пути машины не было светофора, то добавляем +1 к общему времени в пути
                {
                    trackLenght=trackLenght + 1;
                }

                else if(svetofor == true)   // если в данной точки пути есть светофор, то добавляем время ожидания в пути пока горит красный свет
                {
                    trackLenght = trackLenght + n;
                }

            }

            return trackLenght;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[][] svetofor = new int[][]
                {
                    new int[] { 3, 5, 5 },
                    new int[] { 5, 2, 2 },
                };

            Console.WriteLine(Level1.Unmanned(10, 2, svetofor));

            Console.ReadKey();
        }
    }
}
