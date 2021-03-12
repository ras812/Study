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
            int[,] mapS1 = new int[H1, W1]; 
            int[,] mapS2 = new int[H2, W2];
            string S1new = null;
            string S2new = null;
            bool artobstrel = false;

            for (int i = 0; i < S1.Length; i++)
            {
                if (S1[i] == ' ')
                {
                    continue;   
                }
                S1new += S1[i];
            }

            for (int i = 0; i < S2.Length; i++)
            {
                if (S2[i] == ' ')
                {
                    continue;
                }
                S2new += S2[i];
            }

            for (int i = 0; i < mapS1.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mapS1.GetUpperBound(1) + 1; j++)
                {
                    mapS1[i, j] = Convert.ToInt32(Convert.ToString(S1new[0]));
                    S1new = S1new.Remove(0, 1);
                }
            }

            for (int i = 0; i < mapS2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mapS2.GetUpperBound(1) + 1; j++)
                {
                    mapS2[i, j] = Convert.ToInt32(Convert.ToString(S2new[0]));
                    S2new = S2new.Remove(0, 1);
                }
            }

            int bigFlag = -1;
            int midFlag = -1;

            for (int i = 0; i < (H1 - H2 + 1); i++)
            {
                for (int j = 0; j < (W1 - W2 + 1); j++)
                {
                    if (mapS1[i, j] == mapS2[0, 0])
                    {
                        midFlag = -1;

                        for (int m = 0; m < mapS2.GetUpperBound(0) + 1; m++)
                        {

                            for (int n = 0; n < mapS2.GetUpperBound(1) + 1; n++)
                            {

                                if (mapS2[m, n] == mapS1[i + m, j + n])
                                {
                                    midFlag = 1;
                                    continue;
                                }
                                else
                                {
                                    midFlag = 0;
                                    break;
                                }
                            }

                            if (midFlag == 0)
                            {
                                break;
                            }
                        }

                    }

                    if (midFlag == 1)
                    {
                        bigFlag = 1;
                        break;
                    }

                }

                if (bigFlag == 1)
                {
                    artobstrel = true;
                    break;
                }

            }

            return artobstrel;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int mapH1 = 2;
            int mapW1 = 2;
            string mapS1 = "11 01";
            int mapH2 = 2;
            int mapW2 = 2;
            string mapS2 = "11 11";
            Console.WriteLine(Level1.TankRush(mapH1, mapW1, mapS1, mapH2, mapW2, mapS2));
            Console.ReadKey();
        }
    }
}
