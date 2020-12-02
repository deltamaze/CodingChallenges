using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace App
{
    static class Day1
    {
        public static void Run()
        {

            string input = File.ReadAllText("Day1Input.txt");
            var inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            List<int> parsedInput = inputArray.Select(s => int.Parse(s)).ToList();

            // part 1

            //find two entries that sum to 2020
            int numOneIndex = -1;
            int numTwoIndex = -1;
            for (int i = 0; i < parsedInput.Count; i++)
            {
                for (int j = 0; j < parsedInput.Count; j++)
                {
                    if (i == j)
                    {
                        continue; // 
                    }
                    if (parsedInput[i] + parsedInput[j] == 2020)
                    {
                        numOneIndex = i;
                        numTwoIndex = j;
                    }
                }
            }

            //multipy to get answer
            Console.WriteLine(parsedInput[numOneIndex] * parsedInput[numTwoIndex]);

            //part 2
            numOneIndex = -1;
            numTwoIndex = -1;
            int numThreeIndex = -1;

            for (int i = 0; i < parsedInput.Count; i++)
            {
                for (int j = 0; j < parsedInput.Count; j++)
                {
                    for (int k = 0; k < parsedInput.Count; k++)
                    {
                        if (i == j || i ==k || j == k)
                        {
                            continue; // 
                        }
                        if (parsedInput[i] + parsedInput[j] + parsedInput[k] == 2020)
                        {
                            numOneIndex = i;
                            numTwoIndex = j;
                            numThreeIndex = k;
                        }

                    }
                }
            }
            //multipy to get answer
            Console.WriteLine(parsedInput[numOneIndex] * parsedInput[numTwoIndex] * parsedInput[numThreeIndex]);

        }
    }
}
