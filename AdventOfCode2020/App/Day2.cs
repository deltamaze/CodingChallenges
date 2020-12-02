using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace App
{
    static class Day2
    {
        public static void Run()
        {

            string input = File.ReadAllText("Day2Input.txt");
            string[] inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            int validCount = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                string targetString = inputArray[i];
                string[] stringSplit = targetString.Split('-', StringSplitOptions.None);
                int lowerRange = int.Parse(stringSplit[0]);
                stringSplit = stringSplit[1].Split(' ', StringSplitOptions.None);

                int upperRange = int.Parse(stringSplit[0]);




                string targetCharacter = stringSplit[1].Replace(":", "");
                string targetPassword = stringSplit[2];

                // parsed out segments, now validate rule
                char[] targetCharacters = targetPassword.ToCharArray();
                int charCount = 0;
                foreach (char character in targetCharacters)
                {
                    if(character == char.Parse(targetCharacter))
                    {
                        charCount += 1;
                    }
                }
                if (charCount >= lowerRange && charCount <= upperRange)
                {
                    validCount += 1;
                }

                // Console.WriteLine($"{targetString} : {lowerRange}|{upperRange}|{targetCharacter}|{targetPassword}");

            }
            
            // part 1
            Console.WriteLine(validCount.ToString());

            //part 2
            validCount = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                string targetString = inputArray[i];
                string[] stringSplit = targetString.Split('-', StringSplitOptions.None);
                int positionOne = int.Parse(stringSplit[0]) - 1; //no concept of index 0, so minus 1
                stringSplit = stringSplit[1].Split(' ', StringSplitOptions.None);

                int positionTwo = int.Parse(stringSplit[0]) - 1;




                string targetCharacter = stringSplit[1].Replace(":", "");
                string targetPassword = stringSplit[2];

                // parsed out segments, now validate rule
                char[] targetCharacters = targetPassword.ToCharArray();
                int trueCount = 0; // must be exactyl 1
                if(targetCharacters[positionOne] == char.Parse(targetCharacter))
                {
                    trueCount += 1;
                }
                if (targetCharacters[positionTwo] == char.Parse(targetCharacter))
                {
                    trueCount += 1;
                }
                if (trueCount == 1)
                {
                    validCount += 1;
                }

                // Console.WriteLine($"{targetString} : {lowerRange}|{upperRange}|{targetCharacter}|{targetPassword}");

            }

            // part 2
            Console.WriteLine(validCount.ToString());


        }
    }
}
