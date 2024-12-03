using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class Day3
    {

        static void Main()
        {
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string path = Path.Combine(directory, "AOC3.txt");
            int total = 0;
            bool process = false;
            List<string> goodmatches = new List<string>();
            List<string> badmatches = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line; while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
                        string pattern2 = @"mul\((\d+),(\d+)\)";

                        MatchCollection matches = Regex.Matches(line, pattern);                


                        foreach(Match item in matches)
                        {
                            string match = item.Value;

                            if (match == "do()")
                            {
                                process = true;
                            }
                            else if (match == "don't()")
                            {
                                process = false;
                            }                            
                            else
                            {
                                if (process)
                                {
                                    //goodmatches.Add(match);
                                    Match match1 = Regex.Match(match, pattern2);

                                    int num1 = int.Parse(match1.Groups[1].Value);
                                    int num2 = int.Parse(match1.Groups[2].Value);

                                    int result = num1 * num2;
                                    total += result;
                                }
                                //else
                                //{
                                //    badmatches.Add(match);
                                //}
                            }
                            
                        }


                        //foreach (Match match in matches)
                        //{

                        //    if (match.Success)
                        //    {
                        //        int num1 = int.Parse(match.Groups[1].Value);
                        //        int num2 = int.Parse(match.Groups[2].Value);

                        //        int result = num1 * num2;
                        //        total += result;
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("The pattern could not be found");
                        //    }

                        //}
                    }
                    Console.WriteLine("file processed");

                    

                    Console.WriteLine($"the total for all matches is : {total}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file could not be read: {e.Message}");
            }
            Console.ReadLine();
        
        }

    }
}
