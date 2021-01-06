using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020_DAY8
{
    class Program
    {
        static string filePath = "C:\\AdventOfCode-Solution2\\AOC2020-DAY8\\InputDay8.txt";
        static int totallines = File.ReadLines("C:\\AdventOfCode-Solution2\\AOC2020-DAY8\\InputDay8.txt").Count();
        static String line;

        private static int Number;
        private static string Instruction;
        static int index = 1;

        public static List<string> already = new List<string>();
        
        static int accumulator = 0;
        static int newaccumulator;
        static string ReadSpecificLine(string filePath, int lineNumber)
        {
            string content = null;
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    for (int i = 1; i < index; i++)
                    {
                        file.ReadLine();
                      
                        if (file.EndOfStream)
                        {
                            Console.WriteLine($"End of file.  The file only contains {i} lines.");
                           
                        }
                    }
                    content = file.ReadLine();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error reading the file: ");
                Console.WriteLine(e.Message);
            }

            return content;

        }



        static void Main(string[] args)
        {
            int num =0;
            while (index < totallines)
            {
                string lineContents = ReadSpecificLine(filePath, index);
                line = lineContents;
                Console.WriteLine(lineContents);

                String[] returnitems = Seperator();

                Instruction = returnitems[0];
                Number = Convert.ToInt32(returnitems[1]);

                num = index;
                already.Add(num.ToString());
                Console.WriteLine("Pageline: " + index + "       Instruction: " + Instruction + " Number: " + Number);

                InstructionChecker();

                Console.WriteLine("New Value = " + newaccumulator);
                Console.WriteLine();

                foreach(var item in already)
                {
                    if(Convert.ToInt32(item) == index)
                    {
                        Console.WriteLine("The program is looping number: "+ index+ " || Accumulator number: "+newaccumulator);
                        totallines = 0;
                    }

                }
            }
           

            Console.ReadLine();
        }



        static String[] Seperator()
        {
            String str = line;
            char[] seperator = {' '};
            //The char[] picks up a collection of characters that needs to be picked out of the string input.

            String[] strlist = str.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            //Foreach password input, the string gets seperated when one of the specific characters occur. And the characters will be placed in an seperated chararray.

            return strlist;
            //returns the chararrays to 
        }

        static void InstructionChecker()
        {
            if (Instruction == "acc")
            {
                newaccumulator += Number;  
                index++;

            }
            if (Instruction == "jmp")
            {
                index += Number;
            }
            if (Instruction == "nop")
            {
                index +=1;
            }
        }
    }
}
