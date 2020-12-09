using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace App
{
    static class Day6
    {
        static string[] inputArray;
        public static void Run()
        {

            string input = File.ReadAllText("Day6Input.txt");
            inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            int runningTally = 0;
            int runningTallyPartTwo = 0;
            int groupCount = 0; ;
            Dictionary<char, int> form = new Dictionary<char, int>();
            for (int i = 0; i < inputArray.Count(); i++)
            {
                if(String.IsNullOrWhiteSpace(inputArray[i]))
                {
                    
                    runningTally = form.Keys.Count() + runningTally;
                    // only add point for part 1, if groupCount = hashtable Value count.
                    foreach(var item in form.Keys)
                    {
                        if(form[item] == groupCount)
                        {
                            runningTallyPartTwo += 1;
                        }
                    }
                    form = new Dictionary<char, int>();
                    Console.WriteLine(runningTallyPartTwo);
                    groupCount = 0;//reset
                }
                else
                {
                    groupCount += 1; // start count afer emtpy line
                }
                
                char[] lineAns = inputArray[i].ToCharArray();
                foreach (var character in lineAns)
                {
                    if(!form.Keys.Contains(character))
                    {
                        form.Add(character, 1);
                    }
                    else
                    {
                        form[character] = form[character] + 1;
                    }
                }
            }
            Console.WriteLine(runningTallyPartTwo);

        }
    }
}
