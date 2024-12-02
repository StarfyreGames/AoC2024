using System;
using System.Collections.Generic;
using System.IO;

public class Class1
{
    static int safeCount = 0;

    static void LineActions(List<int> list)
    {
        int score = 0; // 1 for going up, 0 for going down 2 for equal 3 for too different
        int lineScore = 0; //1 for SAFE 0 for UNSAFE
        bool goingUP, goingDOWN, safeLine;

        int previousScore = 4;
        int difference = 0;
        
        if (list[0] > list[1])
        {
            previousScore = 0;
            difference = list[0] - list[1];
        }
        else if (list[0] < list[1])
        {
            previousScore = 1;
            difference = list[1] - list[0];
        }

        if (difference > 3 || difference < 1)
        {
            lineScore = 0;
        }
        else
        {
            for (int i = 2; i < list.Count; i++)
            {

                if (list[i] > list[i - 1])
                {
                    goingUP = true;
                    goingDOWN = false;
                    difference = (list[i] - list[i - 1]);
                    if (difference > 3 || difference < 1)
                    {
                        lineScore = 0;
                        break;
                    }
                    else
                    {
                        score = 1;
                    }
                }
                else if (list[i] < list[i - 1])
                {
                    goingDOWN = true;
                    goingUP = false;
                    difference = list[i-1] - list[i];
                    if ((difference > 3) || (difference < 1))
                    {
                        lineScore = 0;
                        break;
                    }
                    else
                    {
                        score = 0;
                    }
                }
                else
                {
                    goingDOWN = false;
                    goingUP = false;
                    score = 2;
                    lineScore = 0;
                    break;
                }

                if (previousScore != score)
                {
                    lineScore = 0;
                    break;
                }
                else
                {
                    lineScore = 1;                    
                    continue;
                }
            }
        }
        
        if (lineScore == 1)
        {
            safeLine = true;
            safeCount++;
        }
        else
        {
            safeLine = false;
        }
        
    }

    static void AOC2Main()
    {
        string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string path = Path.Combine(directory, "AOC2.txt");

        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line; while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    List<int> parts = new List<int>();
                    string[] items = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in items)
                    {
                        parts.Add(int.Parse(item));
                    }
                    LineActions(parts);
                    parts.Clear();
                }
                Console.WriteLine("File Processed");
                Console.WriteLine($"Your report has {safeCount} reports");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The file could not be read: {e.Message}");
        }
        Console.WriteLine("Done what I can");
        Console.ReadLine();
    }
}

