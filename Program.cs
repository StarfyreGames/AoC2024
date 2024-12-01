
using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
class Program 
{
    static void compareSeq(List<int> one, List<int> two)
    {
        List<int> differences = new List<int>();
        one.Sort();
        two.Sort();

        for (int i = 0; i < one.Count; i++) 
        {
            if (one[i] > two[i])
            {
                int a = one[i] - two[i];
                differences.Add(a);
            }
            else if (one[i] < two[i])
            {
                int b = two[i] - one[i];
                differences.Add(b);
            }
            else
            {
                differences.Add(0);
            }
        }

        int total = differences.Sum();
        Console.WriteLine($"Your total is : {total}");

    }
    static void Main()
    {
        // Get the directory where the executable is running
        string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string path = Path.Combine(directory,"AOC1.txt");
        List<int> leftItems = new List<int>();
        List<int> rightItems = new List<int>();
        try 
        { 
            using (StreamReader sr = new StreamReader(path)) 
            {
              string line; while ((line = sr.ReadLine()) != null) 
                {
                    line = line.Trim();
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int num1) && int.TryParse(parts[1], out int num2))
                    
                    {
                        leftItems.Add(num1);
                        rightItems.Add(num2);                        
                    } 
                    else 
                    { 
                        Console.WriteLine($"Invalid line format: {line}"); 
                    }
                    
                }
                Console.WriteLine("file processed");
            } 
        } 
        catch (Exception e) 
        { 
            Console.WriteLine($"The file could not be read: {e.Message}"); 
        }

        List<int> differences = new List<int>();       

        compareSeq(leftItems, rightItems);
    }

    
}