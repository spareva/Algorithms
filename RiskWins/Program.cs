﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string startCombination = Console.ReadLine();
        string endCombination = Console.ReadLine();

        HashSet<string> visited = new HashSet<string>();

        int forbiddenCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < forbiddenCount; i++)
        {
            visited.Add(Console.ReadLine());
        }

        Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
        queue.Enqueue(new Tuple<string, int> (startCombination, 0));

        visited.Add(startCombination);
      
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Item1 == endCombination)
            {
                Console.WriteLine(current.Item2);
                return;
            }

            StringBuilder sb = new StringBuilder(current.Item1);

            for (int i = 0; i < 5; i++)
            {
                int digit = current.Item1[i] - '0';
                digit++;
                if (digit == 10)
                {
                    digit = 0;
                }

                sb[i] = (char)(digit + '0');
                var newNode = sb.ToString();

                if (!visited.Contains(newNode))
                {
                    visited.Add(newNode);
                    queue.Enqueue(new Tuple<string,int>(newNode, current.Item2 + 1));
                }

                sb[i] = current.Item1[i];
            }

            for (int i = 0; i < 5; i++)
            {
                int digit = current.Item1[i] - '0';
                digit--;
                if (digit == -1)
                {
                    digit = 9;
                }

                sb[i] = (char)(digit + '0');
                var newNode = sb.ToString();

                if (!visited.Contains(newNode))
                {
                    visited.Add(newNode);
                    queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                }

                sb[i] = current.Item1[i];
            }
        }
        Console.WriteLine(-1);
    }
}