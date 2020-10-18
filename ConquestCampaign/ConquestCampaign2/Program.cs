using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestCampaign
{
    public static class Level1
    {
        public static int ConquestCampaign(int N, int M, int L, int[] battalion)
        {
            int[,] battleGround = new int[N, M];
            int captured = 0;
            int countDays = 1;

            // create battle ground

            for (int i = 0; i < battleGround.GetLength(0); i++)
            {

                for (int j = 0; j < battleGround.GetLength(1); j++)
                {
                    battleGround[i, j] = 0;
                }
            }
            
            // 0 - not captured
            // 1 - marked for catpure
            // 2 - captured and catpure from this point
            // 3 - captured and do nothing
            // place landing zone and start first day

            for (int i = 0; i < battalion.Length; i++)
            {
                if (i % 2 != 0)
                {
                    battleGround[(battalion[i - 1] - 1), (battalion[i] - 1)] = 2;
                }
            }

            // capture
            
            while (captured == 0)
            {
                for (int i = 0; i < battleGround.GetLength(0); i++)
                {

                    for (int j = 0; j < battleGround.GetLength(1); j++)
                    {

                        if (battleGround[i, j] == 2)
                        {

                            if ((i - 1) >= 0 && (i - 1) < battleGround.GetLength(0))
                            {

                                if (battleGround[i - 1, j] == 0)
                                {
                                    battleGround[i - 1, j] = 1; // up
                                }
                            }

                            if ((i + 1) >= 0 && (i + 1) < battleGround.GetLength(0))
                            {

                                if (battleGround[i + 1, j] == 0)
                                {
                                    battleGround[i + 1, j] = 1; // down
                                }
                            }

                            if ((j - 1) >= 0 && (j - 1) < battleGround.GetLength(1))
                            {

                                if (battleGround[i, j - 1] == 0)
                                {
                                    battleGround[i, j - 1] = 1; //left
                                }
                            }

                            if ((j + 1) >= 0 && (j + 1) < battleGround.GetLength(1))
                            {

                                if (battleGround[i, j + 1] == 0)
                                {
                                    battleGround[i, j + 1] = 1; // right
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < battleGround.GetLength(0); i++)
                {

                    for (int j = 0; j < battleGround.GetLength(1); j++)
                    {

                        if (battleGround[i, j] == 1)
                        {
                            battleGround[i, j] = 2;
                        }

                        else if (battleGround[i, j] == 2)
                        {
                            battleGround[i, j] = 3;
                        }
                    }
                }

                for (int i = 0; i < battleGround.GetLength(0); i++)
                {

                    for (int j = 0; j < battleGround.GetLength(1); j++)
                    {

                        if (battleGround[i, j] == 0)
                        {
                            captured = 0; // not captured
                            break;
                        }
                        else
                        {
                            captured = 1;
                        }
                    }
                }
                

                countDays++;
                // PrintBattleGround

                /*Console.WriteLine("Today is {0} battle day", countDays);

                for (int i = 0; i < battleGround.GetLength(0); i++)
                {

                    for (int j = 0; j < battleGround.GetLength(1); j++)
                    {
                        Console.Write(battleGround[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();*/
            }

            return countDays;
        }

        /*static void Main(string[] args)
        {
            int[] arr = { 2, 2, 3, 4 };
            Console.WriteLine(ConquestCampaign(3, 4, 2, arr));
            Console.ReadKey();
        }*/
    }
}
