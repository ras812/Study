using System;

namespace Level1Space
{
    public static class Level1
    {
        public static int SumOfThe(int N, int[] data)
        {
            int err = 0;
            int number = 0;
            for (int i = 0; i < data.Length; i++)   //  определяем,числа положительные?
            {
                if (data[i] >= 0)
                {
                    err = 1;
                }
                else
                {
                    err = 0;
                    break;
                }
            }

            if (err != 1)   // определяем, все ли числа отрицательные
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] < 0)
                    {
                        err = -1;
                    }
                    else
                    {
                        err = 0;
                        break;
                    }
                }
            }

            if (err == 1)   // если все числа в массиве положительные, выбираем самое большое
            {
                // Console.WriteLine("Positive num");
                number = data[0];
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i] > number)
                    {
                        number = data[i];
                    }
                }
                return number;
            }

            else if (err == -1) // если все отрицательные, выбираем самое маленькое
            {
                // Console.WriteLine("Negative num");
                number = data[0];
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i] < number)
                    {
                        number = data[i];
                    }
                }
                return number;
            }

            else    // если в массиве присутствую и положительные и отрицательные числа
            {
                // Console.WriteLine("Combined nums");
                for (int i = 0; i < data.Length; i++)
                {
                    number = 0;
                    for (int j = 0; j < data.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        number = number + data[j];
                    }

                    if (number == data[i])
                    {
                        break;
                    }
                }
                return number;
            }

        }
    }
    // class Program
    // {
    //    static void Main(string[] args)
    //    {
    //        int[] data = { 10, - 25, - 45, - 35, 5 };
    //        Console.WriteLine(Level1.SumOfThe(0, data));
    //        
    //    }
    // }
}
