using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace App
{
    static class Day3
    {
        static string[] inputArray;
        public static void Run()
        {

            string input = File.ReadAllText("Day3Input.txt");
            inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            int x = 0;
            int y = 0;

            int treeCount = 0;
            int openCount = 0;

            while (y < inputArray.Length -1)
            {
                x = x + 3;
                y = y + 1;

                // if x > string length, slide it back to start
                if(x > inputArray[y].Length-1)
                {
                    x = x - inputArray[y].Length;
                }
                if(inputArray[y].ToCharArray()[x] == '#')
                {
                    treeCount += 1;
                }
                if (inputArray[y].ToCharArray()[x] == '.')
                {
                    openCount += 1;
                }
            }

            //part 1
            Console.WriteLine(treeCount);
            //part 2, take code of part 1, throw it into a method, then call method and store answer in array, then multiply together

            List<Vector2> vectors = new List<Vector2>();
            Int64 rollingAnswer = 1;
            vectors.Add(new Vector2(1, 1));
            vectors.Add(new Vector2(3, 1));
            vectors.Add(new Vector2(5, 1));
            vectors.Add(new Vector2(7, 1));
            vectors.Add(new Vector2(1, 2));

            foreach (Vector2 item in vectors)
            {
                int treeCounter = TreeCounter(item);
                rollingAnswer = rollingAnswer * treeCounter;
            }

            Console.WriteLine(rollingAnswer);



        }
        private static int TreeCounter(Vector2 vect)
        {
            int x = 0;
            int y = 0;

            int treeCount = 0;
            int openCount = 0;

            while (y < inputArray.Length - 1)
            {
                x = x + (int)Math.Round(vect.X, 0);
                y = y + (int)Math.Round(vect.Y, 0);

                // if x > string length, slide it back to start
                if (x > inputArray[y].Length - 1)
                {
                    x = x - inputArray[y].Length;
                }
                if (inputArray[y].ToCharArray()[x] == '#')
                {
                    treeCount += 1;
                }
                if (inputArray[y].ToCharArray()[x] == '.')
                {
                    openCount += 1;
                }
            }
            return treeCount;
        }
        
    }
}
