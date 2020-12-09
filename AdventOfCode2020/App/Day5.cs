using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace App
{
    static class Day5
    {
        static string[] inputArray;
        public static void Run()
        {

            string input = File.ReadAllText("Day5Input.txt");
            inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            int maxSeat = 0;
            List<int> seats = new List<int>();
            foreach (var s in inputArray)
            {
                char[] c = s.ToCharArray();

                int up = 0;
                int down = 127;
                int right = 0;
                int left = 7;
                foreach (var item in c)
                {
                    if (item == 'F')
                    {
                        down = ((up + down) / 2);
                    }
                    if (item == 'B')
                    {
                        up = (up + down) / 2;
                        up += 1; // round up
                    }
                    if (item == 'L')
                    {
                        left = ((left + right) / 2);
                    }
                    if (item == 'R')
                    {
                        right = (left + right) / 2;
                        right += 1; // round up
                    }

                }
                int seatid = (up * 8) + left;
                if (seatid > maxSeat){
                    maxSeat = seatid;
                }
                seats.Add(seatid);
                //Console.WriteLine((up * 8) + left);
            }
            Console.WriteLine(maxSeat);
            seats.Sort();
            int prev = 0;
            foreach (var seat in seats)
            {
                if(seat - prev > 1)
                {
                    Console.WriteLine(seat-1);
                }
                prev = seat;
                // Console.WriteLine(seat);
            }
        }
    }
}
