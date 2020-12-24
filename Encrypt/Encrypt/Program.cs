﻿using System;

namespace Level1Space
{
    public static class Level1
    {
        public static string TheRabbitsFoot(string s, bool encode)
        {
            string sNoSpace = null;
            int matrixSqrtMin = 0; // строки матрицы
            int matrixSqrtMax = 0; // столбцы матрицы
            int count = 0;
            int stop = 0;
            string resString = null;


            if (encode == true)
            {

                // удаляем из строки пробелы
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        continue;
                    }
                    sNoSpace = sNoSpace + s[i];
                }

                // строки матрицы
                matrixSqrtMin = Convert.ToInt32(Math.Floor(Math.Sqrt(sNoSpace.Length)));

                // столбцы матрицы
                matrixSqrtMax = Convert.ToInt32(Math.Ceiling(Math.Sqrt(sNoSpace.Length)));

                // при необходимости, добавляем в матрицу еще одну строку
                if (matrixSqrtMin * matrixSqrtMax <= sNoSpace.Length)
                {
                    matrixSqrtMin = matrixSqrtMin + 1;
                }

                // создаем матрицу символов
                char[,] matrix = new char[matrixSqrtMin, matrixSqrtMax];

                // помещаем в матицу символы из строки друг за другом
                count = 0;

                for (int i = 0; i < matrixSqrtMin; i++)
                {
                    for (int j = 0; j < matrixSqrtMax; j++)
                    {
                        if (count > sNoSpace.Length - 1)
                        {
                            break;
                        }
                        matrix[i, j] = sNoSpace[count];
                        count++;
                    }
                }

                // формируем строку по правилу "символы по столбцам добавляя в конце пробел"
                count = 0;
                resString = null;
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {

                    for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                    {
                        resString = resString + matrix[i, count];
                    }

                    if (j < matrix.GetUpperBound(1))    // не ставим пробел в конце последнего символа
                    {
                        resString = resString + ' ';
                    }

                    count++;
                }

            }

            else if (encode == false)
            {
                // удаляем из строки пробелы
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        continue;
                    }
                    sNoSpace = sNoSpace + s[i];
                }

                // создаем матрицу символов
                // строки матрицы
                matrixSqrtMin = Convert.ToInt32(Math.Floor(Math.Sqrt(sNoSpace.Length)));

                // столбцы матрицы
                matrixSqrtMax = Convert.ToInt32(Math.Ceiling(Math.Sqrt(sNoSpace.Length)));

                // если необходим, добавляем дополнительную строку в матрицу
                if (matrixSqrtMin * matrixSqrtMax <= sNoSpace.Length)
                {
                    matrixSqrtMin = matrixSqrtMin + 1;
                }

                // создаем матрицу символов
                char[,] matrix = new char[matrixSqrtMin, matrixSqrtMax];

                // добавляем в матрицу символы из строки
                count = 0;
                stop = 0;
                for (int j = 0; j < matrixSqrtMax; j++)
                {
                    // если существует остаток от деления,то подбираем символ с последней строки
                    if (j < sNoSpace.Length % matrixSqrtMax)
                    {
                        stop = matrixSqrtMin;
                    }
                    else
                    {
                        stop = matrixSqrtMin - 1;
                    }

                    for (int i = 0; i < stop; i++)
                    {
                        if (count > sNoSpace.Length - 1)
                        {
                            break;
                        }
                        matrix[i, j] = sNoSpace[count];
                        count++;
                    }
                }

                // формируем результирующую строку
                count = 0;
                resString = null;
                for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                {

                    for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                    {
                        if (count > sNoSpace.Length - 1)
                        {
                            break;
                        }
                        resString = resString + matrix[i, j];
                        count++;
                    }

                }

            }

            return resString;
        }

        /*
        public static class Testing
        {
            private static string s = null;
            private static bool encode = true;

            public static void Test()
            {
                Console.WriteLine("Тест функции TheRabbitsFoot:");
                s = "отдай мою кроличью лапку";
                encode = true;
                Console.WriteLine("Начальная строка: {0}", s);
                Console.WriteLine("Результирующая строка: {0}",TheRabbitsFoot(s, encode));
                s = "омоюу толл дюиа акчп йрьк";
                encode = false;
                Console.WriteLine("Начальная строка: {0}", s);
                Console.WriteLine("Результирующая строка: {0}", TheRabbitsFoot(s, encode));
                s = "The quick brown fox jumps over the lazy dog";
                encode = true;
                Console.WriteLine("Начальная строка: {0}", s);
                Console.WriteLine("Результирующая строка: {0}", TheRabbitsFoot(s, encode));
                s = "Tcnmrz hkfpty eboshd qrxoeo uojvlg iwuea";
                encode = false;
                Console.WriteLine("Начальная строка: {0}", s);
                Console.WriteLine("Результирующая строка: {0}", TheRabbitsFoot(s, encode));
                s = "Расшифровка зашифрованной строки не даёт исходный результат";
                encode = true;
                Console.WriteLine("Начальная строка: {0}", s);
                Console.WriteLine("Результирующая строка: {0}", TheRabbitsFoot(s, encode));
                s = "Рврсддл акотань саврёыт шзаотйа ианкирт фшнисе  рионхз офйеоу";
                encode = false;
                Console.WriteLine("Начальная строка: {0}", s);
                Console.WriteLine("Результирующая строка: {0}", TheRabbitsFoot(s, encode));
            }
        }

        static void Main(string[] args)
        {
            Testing.Test();
            Console.ReadKey();
        }
        */
    }

}
