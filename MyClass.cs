using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba_SP1
{
    class MyClass
    {
        public int flag = 0;
        public int interesant_flag = 0;
        public int countWORDcount = 0;
        public string LAIN;
        public string WORDD = "";

        public int interest(string Line, string ReadLine)
        {
            int CountOfLine = 0;
            int res = Convert.ToInt32(ReadLine.Count());
            string sumbol = (Line[0]).ToString();
            int sumbol_count = 0;
            interesant_flag = 0;
            countWORDcount = 0;


            if (ReadLine[1].ToString() != "%")
            {
                interesant_flag++;
                int coefis1 = 0;
                while (Line[coefis1].ToString() == sumbol)
                {
                    coefis1++;
                    CountOfLine++;
                    countWORDcount++;
                }
                WORDD += CountOfLine + "(" + sumbol + ")";
                flag += 2;
            }
            else
            {
                interesant_flag++;
                if (ReadLine[1].ToString() == "%")
                {
                    int count = 0;
                 
                    while (Line[count].ToString() == sumbol)
                    {

                        CountOfLine++;
                        count++;
                        countWORDcount++;
                    }
                    if (count > 1)
                    {
                        WORDD += count + "(" + sumbol + ")";
                        flag += 2;
                    }
                }
    
                else
                {
                    if (ReadLine[1].ToString() == sumbol)
                    {
                        int coefis3 = 0;
                        while (ReadLine[coefis3].ToString() == sumbol)
                        {
                            coefis3++;
                            CountOfLine++;
                            sumbol_count++;
                        }
                    }
                }
                

            }

         
            return CountOfLine;
        }

        public void Search()
        {
            int res11 = 0;
            int SumbolWord = 0;
            int res = 0;
            String[] stringg;
            string word;
            string line;
            FileStream file = new FileStream("e:\\123.txt", FileMode.Open);
            StreamReader read = new StreamReader(file);

            FileStream file1 = new FileStream("e:\\write.txt", FileMode.Open);
            word = Console.ReadLine();
            int ii = 0;
            while (ii < word.Length)
            {
                if (word[ii] != '%') SumbolWord++;
                else SumbolWord += 2;
                ii++;
            }

            if (word != null)
            {
                while ((line = read.ReadLine()) != null)
                {
                    StreamWriter read1 = new StreamWriter(file1);
                    stringg = line.Split(' ');

                    foreach (string lain in stringg)
                    {
                        int j = 0;
                        int i = 0;
                        flag = 0;
                        while (i < lain.Length)
                        {
                            if (word[j] == '%')
                            {
                                res11 = countWORDcount;
                                if ((res += interest(lain.Substring(res, lain.Count() - res), word.Substring(j, word.Count() - j))) != 0)
                                {
                                    i = res-1;
                                    j++;
                                }
                                else
                                {
                                    flag = 0;
                                    j = 0; WORDD = " ";
                                    break;
                                }
                                if (res11 >= 4 && countWORDcount == 1)
                                {
                                    i--;
                                    WORDD = WORDD.Substring(0, WORDD.Length - 8);
                                    WORDD += 2 + "(" + lain[i - 1] + ")";
                                    WORDD += res11 - 2 + "(" + lain[i - 1] + ")";
                                }
                            }
                            else
                            {
                                if (word[j] == lain[i])
                                {
                                    flag++; j++;  res += 1; WORDD += lain[i]; }
                                else { flag = 0; j = 0;  WORDD = " "; break; }
                            }
                            i++;
                            if (flag == SumbolWord)
                            {
                                LAIN += WORDD + " ";
                                i = lain.Length;
                            }
                        }
                        res = 0;
                        if (LAIN != " ") { read1.WriteLine(LAIN); }
                        WORDD = "";
                        LAIN = "";
                    }
                    read1.Close();
                }

                read.Close();

            }
        }
    }
}
