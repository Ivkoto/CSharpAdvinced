using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace January_2020
{
    public static class StacksQueues
    {
        public static void AddRemoveSumNumbers()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbersToBeCalculate = new Stack<int>(input);
            int sum = 0;

            while (true)
            {
                string[] command = Console.ReadLine().ToLower().Split().ToArray();

                if (command[0] == "add")
                {
                    for (int i = 1; i < command.Count(); i++)
                    {
                        numbersToBeCalculate.Push(int.Parse(command[i]));
                    }
                }
                else if (command[0] == "remove")
                {
                    int removingCount = int.Parse(command[1]);
                    if (numbersToBeCalculate.Count() < removingCount)
                    {
                        continue;
                    }
                    for (int i = 0; i < removingCount; i++)
                    {
                        numbersToBeCalculate.Pop();
                    }
                }
                else
                {
                    break;
                }
            }

            foreach (var num in numbersToBeCalculate)
            {
                sum += num;
            }

            Console.WriteLine($"Sum: {sum}");
        }

        public static void ReverceString()
        {
            char[] input = Console.ReadLine().ToCharArray();
            var reverced = new Stack<char>();
            foreach (var element in input)
            {
                reverced.Push(element);
            }
            Console.WriteLine(string.Join("", reverced));
        }

        public static void CupsAndBottles()
        {
            int[] cupsCapacityInput = Console.ReadLine().Split(" ").Select(c => int.Parse(c)).ToArray();
            int[] bottleWithWater = Console.ReadLine().Split(" ").Select(b => int.Parse(b)).ToArray();

            int wastedWater = 0;

            Queue<int> cups = new Queue<int>(cupsCapacityInput);
            Stack<int> bottles = new Stack<int>(bottleWithWater);

            while (cups.Count > 0 && bottles.Count > 0)
            {

                var curCup = cups.Dequeue();

                while (curCup > 0)
                {
                    var curBottle = bottles.Pop();                    

                    if (curBottle > curCup)
                    {
                        wastedWater += curBottle - curCup;
                    }

                    curCup -= curBottle;
                }                                
            }

            //output:
            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(',', cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(',', bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }

    }
}
