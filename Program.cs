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

        private static int Minimalvalue;
        private static int Maximalvalue;
        private static char Letter;
        private static char[] Password;


        static void Main(string[] args)
        {
            
            line = sr.ReadLine();
            while (line != null)
            {

                String[] returneditems = Seperator();
            
                Minimalvalue = Convert.ToInt32(returneditems[0]);
                Maximalvalue = Convert.ToInt32(returneditems[1]);
                Letter = Convert.ToChar(returneditems[2]);
                Password = returneditems[3].ToCharArray();

                AlgorithmOne();
                AlgorihmTwo();
            } 
            sr.Close();
            Console.WriteLine(CounterPartOne + " Matches for Solution 1");
            Console.WriteLine(CounterPartTwo + " Matches for Solution 2");
            Console.ReadLine();
        }


        static String[] Seperator()
        {
            String str = line; 
            char[] seperator = { '-', ' ', ':' };
            //The char[] picks up a collection of characters that needs to be picked out of the string input.

            String[] strlist = str.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            //Foreach password input, the string gets seperated when one of the specific characters occur. And the characters will be placed in an seperated chararray.

            return strlist;
            //returns the chararrays to 
        }

        static void AlgorithmOne()
        {
            int countpart1 = Password.Count(x => x == Letter);
            if (countpart1 >= Minimalvalue && countpart1 <= Maximalvalue)
            {
                CounterPartOne++;
            }
        }

        static void AlgorihmTwo()
        {
            int firstletter = Minimalvalue - 1;
            int lastletter = Maximalvalue - 1;

            if (Password[firstletter] == Letter ^ Password[lastletter] == Letter)
            {
                CounterPartTwo++;
                line = sr.ReadLine();
            }
            else
            {
                line = sr.ReadLine();
            }
        }
    }
}

