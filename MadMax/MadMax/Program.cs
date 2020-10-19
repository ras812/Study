using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static int[] MadMax(int N, int[] Tele)
        {
            int temp = 0;

            if (Tele.Length == 1)
            {
                return Tele;
            }

            else if (Tele.Length == 3)
            {
                for (int i = 0; i < Tele.Length; i++)
                {
                    for (int j = 0; j < Tele.Length - 1; j++)
                    {
                        if (Tele[j] >= Tele[j + 1])
                        {
                            temp = Tele[j];
                            Tele[j] = Tele[j + 1];
                            Tele[j + 1] = temp;
                        }
                    }
                }
                temp = Tele[1];
                Tele[1] = Tele[2];
                Tele[2] = temp;

                // print
                /*Console.WriteLine();
                for (int k = 0; k < Tele.Length; k++)
                {
                    Console.Write(Tele[k] + " ");
                }*/
                // end print

                return Tele;
            }

            else
            {
                for (int i = 0; i < Tele.Length; i++)
                {
                    for (int j = 0; j < Tele.Length - 1; j++)
                    {
                        if (Tele[j] >= Tele[j + 1])
                        {
                            temp = Tele[j];
                            Tele[j] = Tele[j + 1];
                            Tele[j + 1] = temp;
                        }
                    }
                }

                for (int i = 0; i < (Tele.Length / 2) / 2; i++)
                {
                    temp = Tele[(Tele.Length / 2) + i];
                    Tele[(Tele.Length / 2) + i] = Tele[Tele.Length - 1 - i];
                    Tele[Tele.Length - 1 - i] = temp;
                }

                // print
                /*Console.WriteLine();
                for (int k = 0; k < Tele.Length; k++)
                {
                    Console.Write(Tele[k] + " ");
                }*/
                // end print

                return Tele;
            }

        }

        /*static void Main(string[] args)
        {
            int[] madMaxArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            //MadMax(9, madMaxArr);

            int[] newMadMaxArr = new int[madMaxArr.Length];
            for (int i = 0; i < newMadMaxArr.Length; i++)
            {
                newMadMaxArr[i] = MadMax(9, madMaxArr)[i];
            }
            Console.WriteLine();
            for (int i = 0; i < newMadMaxArr.Length; i++)
            {
                Console.Write(newMadMaxArr[i] + " ");
            }


            Console.ReadKey();
        }*/
    }
}
