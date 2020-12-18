using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode_Solution2
{
    public class Program
    {
        static readonly StreamReader sr = new StreamReader("C:\\AdventOfCode-Solution2\\Input Solution 2.txt");

        private static int CounterPartOne = 0;
        private static int CounterPartTwo = 0;
        public static String line;

        static void Main(string[] args)
        {
            line = sr.ReadLine();
            while (line != null)
            {
                #region Seperator and ToList
                String str = line;
                char[] seperator = { '-', ' ', ':' };
                
                String[] strlist = str.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                #endregion

                #region properties of strlist
                string minvalue = strlist[0];
                int valuemin = Convert.ToInt32(minvalue);
                
                string maxvalue = strlist[1];
                int valuemax = Convert.ToInt32(maxvalue);

                string containsletter = strlist[2];
                char letter = Convert.ToChar(containsletter);

                string input = strlist[3];
                string inputstring = strlist[3];
                char[] textarray = input.ToCharArray();

                string lines = new string(textarray);

                #endregion

                #region algorithm for min/max letters
                int countpart1 = input.Count(x => x == letter);
                if (countpart1 >= valuemin && countpart1 <= valuemax)
                {
                    CounterPartOne++;
                }
                #endregion

                int firstletter = valuemin - 1;
                int lastletter = valuemax - 1;

                if (textarray[firstletter] == letter ^ textarray[lastletter] == letter)
                {
                    CounterPartTwo++;
                    line = sr.ReadLine();
                }
                else
                {
                    line = sr.ReadLine();
                }
            } 
                //close the file
            sr.Close();
            Console.WriteLine(CounterPartOne + " Matches for Solution 1");
            Console.WriteLine(CounterPartTwo + " Matches for Solution 2");
            Console.ReadLine();
        }
    }
}

