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
            int flag = 0;

            if (Votes.Length == 1)
            {
                rezStr = "majority winner 1";
            }
            else
            {
                if()
            }


            for (int i = 0; i < Votes.Length; i++)
            {
                for (int j = 0; j < Votes.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (Votes[i] == Votes[j])
                    {
                        flag = 1;
                        break;
                    }
                }
            }
            Console.WriteLine(flag);

            Console.WriteLine(rezStr);
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] Vot = { 10, 15, 10, 5 };
            Vote.MassVote(4, Vot);
            Console.ReadKey();
        }
    }
}
