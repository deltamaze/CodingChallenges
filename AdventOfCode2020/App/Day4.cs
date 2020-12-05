using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;

namespace App
{
    static class Day4
    {
        static string[] inputArray;
        public static void Run()
        {

            //Part 1 
            string input = File.ReadAllText("Day4Input.txt");
            inputArray = input.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );


            int fileLineNum = 0;
            int passportLine = 0;
            int passportValidCount = 0;
            int passportInvalidCount = 0;
            Passport passport = new Passport();
            while (fileLineNum < inputArray.Length)
            {

                
                if (passportLine == 0)
                {
                    passport = new Passport();
                }
                if (String.IsNullOrWhiteSpace(inputArray[fileLineNum]))
                {
                    // check passport for valid fields
                    //var t1=Regex.Match(passport.pid, @"^\d{9}$").Success;
                    //var t2 = Regex.Match(passport.byr, @"^\d{4}$").Success && int.Parse(passport.byr) >= 1920 && int.Parse(passport.byr) <= 2002;
                    //var t3 = !String.IsNullOrWhiteSpace(passport.iyr) && Regex.Match(passport.iyr, @"^\d{4}$").Success && int.Parse(passport.iyr) >= 2010 && int.Parse(passport.iyr) <= 2020;
                    //var t4 = !String.IsNullOrWhiteSpace(passport.ecl) && (passport.ecl == "amb" || passport.ecl == "blu" || passport.ecl == "brn" || passport.ecl == "gry" || passport.ecl == "grn" || passport.ecl == "hzl" || passport.ecl == "oth");
                    //var t5 = !String.IsNullOrWhiteSpace(passport.eyr) && Regex.Match(passport.eyr, @"^\d{4}$").Success && int.Parse(passport.eyr) >= 2020 && int.Parse(passport.eyr) <= 2030;
                    //var t6 = !String.IsNullOrWhiteSpace(passport.hcl) && Regex.Match(passport.hcl, @"^#\w{6}$").Success;
                    //var t7 = !String.IsNullOrWhiteSpace(passport.hgt) && ((Regex.Match(passport.hgt, @"^\d{1,}cm$").Success && int.Parse(passport.hgt.Substring(0, 3)) >= 150 && int.Parse(passport.hgt.Substring(0, 3)) <= 193) || (Regex.Match(passport.hgt, @"^\d{1,}in$").Success && int.Parse(passport.hgt.Substring(0, 2)) >= 59 && int.Parse(passport.hgt.Substring(0, 2)) <= 76));
                    if ( !String.IsNullOrWhiteSpace(passport.pid) && Regex.Match(passport.pid, @"^\d{9}$").Success
                        && !String.IsNullOrWhiteSpace(passport.byr) && Regex.Match(passport.byr, @"^\d{4}$").Success && int.Parse(passport.byr) >= 1920 && int.Parse(passport.byr) <= 2002
                        && !String.IsNullOrWhiteSpace(passport.iyr) && Regex.Match(passport.iyr, @"^\d{4}$").Success && int.Parse(passport.iyr) >= 2010 && int.Parse(passport.iyr) <= 2020
                        && !String.IsNullOrWhiteSpace(passport.ecl) && (passport.ecl == "amb" ||  passport.ecl == "blu" || passport.ecl == "brn" || passport.ecl == "gry" || passport.ecl == "grn" || passport.ecl == "hzl" || passport.ecl == "oth")
                        && !String.IsNullOrWhiteSpace(passport.eyr) && Regex.Match(passport.eyr, @"^\d{4}$").Success && int.Parse(passport.eyr) >= 2020 && int.Parse(passport.eyr) <= 2030
                        && !String.IsNullOrWhiteSpace(passport.hcl) && Regex.Match(passport.hcl, @"^#\w{6}$").Success
                        && !String.IsNullOrWhiteSpace(passport.hgt) && ((Regex.Match(passport.hgt, @"^\d{1,}cm$").Success && int.Parse(passport.hgt.Substring(0,3)) >=150 && int.Parse(passport.hgt.Substring(0, 3)) <= 193) || (Regex.Match(passport.hgt, @"^\d{1,}in$").Success && int.Parse(passport.hgt.Substring(0, 2)) >= 59 && int.Parse(passport.hgt.Substring(0, 2)) <= 76))
                        )
                    {
                        passportValidCount += 1;
                    }
                    else
                    {
                        passportInvalidCount += 1;
                    }
                    passportLine = 0;
                    fileLineNum += 1;
                    continue;
                }
                var lineFields = inputArray[fileLineNum].Split(" ");
                foreach (var field in lineFields)
                {
                    var keyVal = field.Split(":");
                    if(keyVal[0] == "byr")
                    {
                        passport.byr = keyVal[1];
                    }
                    if (keyVal[0] == "iyr")
                    {
                        passport.iyr = keyVal[1];
                    }
                    if (keyVal[0] == "eyr")
                    {
                        passport.eyr = keyVal[1];
                    }
                    if (keyVal[0] == "hgt")
                    {
                        passport.hgt = keyVal[1];
                    }
                    if (keyVal[0] == "hcl")
                    {
                        passport.hcl = keyVal[1];
                    }
                    if (keyVal[0] == "ecl")
                    {
                        passport.ecl = keyVal[1];
                    }
                    if (keyVal[0] == "pid")
                    {
                        passport.pid = keyVal[1];
                    }
                    if (keyVal[0] == "cid")
                    {
                        passport.cid = keyVal[1];
                    }
                    // check for req 
                }
                passportLine += 1;
                fileLineNum += 1;
            }

            Console.WriteLine(passportValidCount);

        }
    }
    public class Passport
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }
    }
}
