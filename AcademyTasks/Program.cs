using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] input = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] problems = new int[input.Length];
        int variety = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < input.Length; i++)
        {
            problems[i] = int.Parse(input[i]);
        }

        int distance1 = 0;
        int distance2 = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        int count = 0;

        for (int i = 0; i < problems.Length; )
        {           
            count++;
            
            if (problems[i] > max)
            {
                max = problems[i];
            }
            if (problems[i] < min)
            {
                min = problems[i];
            }

            if (max - min >= variety)
            {
                Console.WriteLine(count);
                return;
            }

            if (i < problems.Length - 2)
            {
                distance1 = Math.Abs(problems[i] - problems[i + 1]);
                distance2 = Math.Abs(problems[i] - problems[i + 2]);

                if (distance1 > distance2)
                {
                    i += 1;
                }
                else
                {
                    i += 2;
                }
            }
            else break;
        }
        Console.WriteLine(problems.Length);
    }
}
