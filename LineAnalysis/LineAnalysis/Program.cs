using System;

namespace Level1Space
{
    public static class Level1
    {
        public static bool LineAnalysis(string line)
        {
            int count = 0;
            int arrIndexCount = 0;
            bool rez = false;
            
            if (line.Length == 1)
            {
                rez = true;
            }
            
            else if (line.Length > 1)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '*')
                    {
                        count++;
                    }
                }

                int[] arr = new int[count - 1];
                count = 0;

                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i] != '*')
                    {
                        count++;
                    }
                    else if (line[i] == '*')
                    {
                        arr[arrIndexCount] = count;
                        arrIndexCount++;
                        count = 0;
                    }
                }
                int z = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0} ", arr[i]);
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

                Console.WriteLine();
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("{0} ", arr[i]);
                }
                Console.WriteLine();

                if (arr.Length < 2)
                {
                    rez = true;
                }
                else if (arr.Length >= 2)
                {
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[0] != arr[i])
                        {
                            rez = false;
                            break;
                        }
                        else if (arr[0] == arr[i])
                        {
                            rez = true;
                        }
                    }
                }

            }
            Console.WriteLine(rez);
            return rez;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = "*..*..*..*..*..*..*..*";
            Level1.LineAnalysis(s);
            Console.ReadKey();
        }
    }
}
