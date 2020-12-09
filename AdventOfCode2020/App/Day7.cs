using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace App
{
    static class Day7
    {
        static string[] inputArray;
        public static void Run()
        {

            string input = File.ReadAllText("Day6Input.txt");
            inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            
            for (int i = 0; i < inputArray.Count(); i++)
            {
            
            }
            Console.WriteLine("Answer");

        }
    }
}
