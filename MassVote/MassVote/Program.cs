using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassVote
{
    public static class Vote
    {
        public static string MassVote(int N, int[] Votes)
        {
            string rezStr = null;
            int[] votesReserv = new int [Votes.Length];
            int votesMax = 0;
            int z = 0;

            if (Votes.Length == 1)
            {
                rezStr = "majority winner 1";
            }
            else if (Votes.Length > 1)
            {
                for (int i = 0; i < Votes.Length; i++)
                {
                    votesReserv[i] = Votes[i];
                }

                z = votesReserv[0];
                for (int i = 0; i < votesReserv.Length; i++)
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

                // for (int i = 0; i < votesReserv.Length; i++)
                // {
                //     Console.Write("{0} ", votesReserv[i]);
                // }
                // Console.WriteLine();

                if (votesReserv[0] == votesReserv[1])
                {
                    rezStr = "no winner";
                }

                else
                {
                    votesMax = Votes[0];
                    int k = 1;
                    for (int i = 1; i < Votes.Length; i++)
                    {
                        if (Votes[i] >= votesMax)
                        {
                            votesMax = Votes[i];
                            k = i + 1;
                        }
                    }
                    Console.WriteLine(votesMax);
                    Console.WriteLine(k);
                    int sum = 0;
                    for (int i = 0; i < Votes.Length; i++)
                    {
                        sum = sum + Votes[i];
                    }

                    Console.WriteLine(sum);

                    double percent = (Convert.ToDouble(votesMax) / Convert.ToDouble(sum)) * 100000;
                    Console.WriteLine(percent);
                    percent = Math.Round(percent, 0);
                    Console.WriteLine(percent);
                    percent = percent / 1000;
                    Console.WriteLine(percent);

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
    class Program
    {
        static void Main(string[] args)
        {
            int[] Vot = { 30, 30, 30 };
            Console.WriteLine(Vote.MassVote(4, Vot));
            Console.ReadKey();
        }
    }
}
