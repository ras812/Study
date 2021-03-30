using System;
using System.Linq;

namespace Level1Space
{
    public static class Level1
    {
        public static bool MisterRobot(int N, int[] data)
        {
            int z = 0;
            int num = 1;
            int indexOfArray = 0;
            int count = 1;

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("{0} ", data[i]);
            }
            Console.WriteLine();

            while (data.Length != count)
            {
                if (num == data.Length - 1)
                {
                    count = data.Length;
                    Console.WriteLine("Exit WHILE");
                    break;
                }

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == num)
                    {
                        indexOfArray = i;

                        if (indexOfArray > num)
                        {
                            // two step left
                            z = 0;
                            z = data[indexOfArray];
                            data[indexOfArray] = data[indexOfArray - 1];
                            data[indexOfArray - 1] = data[indexOfArray - 2];
                            data[indexOfArray - 2] = z;
                            z = 0;
                            i = 0;
                        }
                        else if (indexOfArray == num)
                        {
                            // one step left
                            z = 0;
                            z = data[indexOfArray - 1];
                            data[indexOfArray - 1] = data[indexOfArray];
                            data[indexOfArray] = data[indexOfArray + 1];
                            data[indexOfArray + 1] = z;
                            z = 0;
                            i = 0;
                        }
                        else if (indexOfArray == num - 1)
                        {
                            num++;
                            Console.WriteLine(num);
                            count++;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("{0} ", data[i]);
            }

            if (data[data.Length - 1] == data.Length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] arr = new int[10000];

            for (int i = 0; i < arr.Length; i++)
            {
                int j = rnd.Next(1, 10001); // тут получаем случайное значение
                while (arr.Contains(j))
                {
                    j = rnd.Next(1, 10001); // тут проверяем
                }
                arr[i] = j; // тут сохраняем/запоминаем
            }
            Console.WriteLine(Level1.MisterRobot(0, arr));
            Console.ReadKey();
        }
    }
}
