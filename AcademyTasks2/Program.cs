using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main() //this algorithm takes only n steps (and n for parse) and gives 90/100 in BgCoder :P
    {
        string line = Console.ReadLine();
        string[] input = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] problems = new int[input.Length];
        int variety = int.Parse(Console.ReadLine());
        bool isFoundMax = false;
        bool isFoundMin = false;
        bool isFound = false;

        for (int i = 0; i < input.Length; i++)
        {
            problems[i] = int.Parse(input[i]);
        }

        int min = int.MaxValue;
        int max = int.MinValue;
        int indexMin = 0;
        int indexMax = 0;

        for (int i = 0; i < problems.Length; i++)
        {
            if (problems[i] < min)
            {
                min = problems[i];
                indexMin = i;
            }
            if (problems[i] > max)
            {
                max = problems[i];
                indexMax = i;
            }
            if (max - min >= variety)
            {
                isFound = true;
                break;
            }
        }

        int pathToMax = 0;
        int pathToMin = 0;
        int result = 0;

        if (isFound == true)
        {
            if (indexMin < indexMax)
            {
                pathToMin = indexMin / 2 + indexMin % 2;
                pathToMax = (indexMax - indexMin) / 2 + (indexMax - indexMin) % 2;
                result = pathToMax + pathToMin;
                isFoundMax = true;
            }
            else
            {
                pathToMax = indexMax / 2 + indexMax % 2;
                pathToMin = (indexMin - indexMax) / 2 + (indexMin - indexMax) % 2;
                result = pathToMax + pathToMin;
                isFoundMin = true;
            }
        }
        else
        {
            Console.WriteLine(problems.Length);
        }

        if (isFoundMax == true)
        {
            Console.WriteLine(result + 1);
        }
        else if (isFoundMin == true)
        {
            Console.WriteLine(result + 1);
        }
    }
}
