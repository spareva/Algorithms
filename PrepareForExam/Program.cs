using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static Dictionary<string, char> cyphers;
    static List<string> codes;
    static SortedSet<string> results;
    static int count;

    static void ParseInput()
    {
        string line = Console.ReadLine();
        string curNumber = "";
        char curLetter = ' ';

        for (int i = 0; i < line.Length; i++)
        {
            char curChar = line[i];

            if (char.IsLetter(curChar))
            {
                if (curNumber != "")
                {
                    cyphers.Add(curNumber, curLetter);
                    codes.Add(curNumber);
                    curNumber = "";
                }

                curLetter = curChar;
            }

            else if (char.IsNumber(curChar))
            {
                curNumber += curChar;
                if (i == line.Length - 1)
                {
                    cyphers.Add(curNumber, curLetter);
                    codes.Add(curNumber);
                }
            }
        }
    }

    static void AddResult(int[] arr)
    {
        string result = "";

        foreach (var number in arr)
        {
            result += cyphers[number.ToString()];
        }

        results.Add(result);
    }

    static void PrintResults()
    {
        Console.WriteLine(count);
        foreach (var str in results)
        {
            Console.WriteLine(str);
        }
    }

    static void GenerateCombinations(int curIndex, string message, StringBuilder result)
    {
        if (curIndex == message.Length)
        {
            count++;
            results.Add(result.ToString());
            return;
        }
        
        foreach (var cypher in cyphers)
        {
            if (message.Substring(curIndex).StartsWith(cypher.Key))
            {
                result.Append(cypher.Value);
                GenerateCombinations(curIndex + cypher.Key.Length, message, result);
                result.Length--;
            }
        }
    }

    static void Main()
    {
        string message = Console.ReadLine();
        cyphers = new Dictionary<string, char>();
        codes = new List<string>();
        results = new SortedSet<string>();    
        ParseInput();

        StringBuilder result = new StringBuilder();

        GenerateCombinations(0, message, result);
        
        PrintResults();
    }
}
