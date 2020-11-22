using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        public static void WordSearch(int len, string s, string sub)
        {
            // len ширина выравнивания, s исходная строка, sub поисковое слово

            ArrayList arr = new ArrayList();
            int Flag = 0;

            Console.WriteLine("s: " + s);

            //while (s.Length > 0)
            //{

                Flag = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    // len количество символов выборки
                    if (s[s.Length - 1] == ' ' && len > s.Length) // если последний символ в выборке пробел и выборка меньше строки
                    {
                        Flag = i;   // количество символов подлежащих переносу
                    }

                    else if (s[s.Length - 1] != ' ' && len > s.Length) // если последний символ в выборке пробел и выборка меньше строки
                    {
                        Flag = i + 1;   // количество символов подлежащих переносу
                    }

                else if(s[len-1] != ' ' && len <= s.Length && i < len) // если последний символ в выборке НЕпробел и выборка меньше или ровна строки
                {
                        Flag = i + 1;
                    }

                    else
                    {
                        break;
                    }


                    
                    //s = s.Remove(0, i);
                    /*if (Convert.ToChar(s[i]) == ' ')
                    {
                        flag = i;
                    }*/

                    /*if (Convert.ToChar(s[i]) != ' ' && i == s.Length - 1)
                    {
                        flag = i;
                    }*/

                }

                Console.WriteLine("iFlag:" + Flag);

                //arr.Add(s.Substring(0, Flag));

                //s = s.Remove(0, Flag);



            //}

            string[] arrString = (string[]) arr.ToArray(typeof(string));

            for (int i = 0; i < arrString.Length; i++)
            {
                Console.WriteLine("arrString: " + arrString[i]);
            }

            Console.WriteLine("s: " + s);



           //return 0;
        }
        static void Main(string[] args)
        {
            string s = "0 2 ";
            string sub = "789";
            WordSearch(5, s, sub);
            
            Console.ReadKey();
        }
    }
}
