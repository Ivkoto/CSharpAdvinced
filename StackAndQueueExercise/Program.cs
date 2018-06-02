namespace StackAndQueueExercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {


        static void Main()
        {
            //E01_ReverseNumbersWithStack();
            //E02_BasicStackOperations();
            //E03_MaximumElement();
            //E04_BasicQueueOperations();
            //E05_CalculateSequenceQueue();
            //E06_TruckTour();
            //E07_BalancedParentheses();
            //E08_RecursiveFibonacci();
            //E09_StackFibonacii();
            //E10_SimpleTextEditor();
            //E11_PoisonousPlants();
        }

        private static void E11_PoisonousPlants()
        {
            
            var n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Take(n)
                .ToArray();

            var days = new int[n];
            var indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);                    
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexes.Push(i);
            }

            Console.WriteLine(days.Max());

        }


        public static Stack<string> oldValues;

        private static void E10_SimpleTextEditor()
        {
            int operationNumbers = int.Parse(Console.ReadLine());
            oldValues = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < operationNumbers; i++)
            {
                string[] operation = Console.ReadLine().Split(' ');

                switch (operation[0])
                {
                    case "1":
                        text = AppendValue(operation[1], text);
                        break;

                    case "2":
                        text = EraseElements(operation[1], text);
                        break;

                    case "3":
                        int indexToPrint = int.Parse(operation[1]);
                        Console.WriteLine(text[indexToPrint - 1]);
                        break;

                    case "4":
                        text = oldValues.Pop();
                        break;
                }
                //test info:
                //Console.WriteLine($"Result = { text}");
            }
        }

        private static string EraseElements(string value, string text)
        {
            oldValues.Push(text);
            text = text.Remove(text.Count() - int.Parse(value));
            return text;
        }

        private static string AppendValue(string value, string text)
        {
            oldValues.Push(text);
            text = string.Concat(text, value);
            return text;
        }

        

        private static void E09_StackFibonacii()
        {
            int n = int.Parse(Console.ReadLine());
            long[] input = new long[] { 0, 1 };
            Stack<long> fibonacciStack = new Stack<long>(input);
            long nextNumber = 0;

            for (int i = 0; i < n - 1; i++)
            {
                long secondNumber = fibonacciStack.Pop();
                long firstNumber = fibonacciStack.Pop();

                nextNumber = firstNumber + secondNumber;
                fibonacciStack.Push(secondNumber);
                fibonacciStack.Push(nextNumber);
            }
            Console.WriteLine(fibonacciStack.Peek());
        }



        public static long[] fibNumbers;

        private static void E08_RecursiveFibonacci()
        {
            int n = int.Parse(Console.ReadLine());
            fibNumbers = new long[n];

            var result = GetFibunacci(n);
            Console.WriteLine(result);
        }

        private static long GetFibunacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }
            return fibNumbers[n - 1] = GetFibunacci(n - 1) + GetFibunacci(n - 2);
        }



        private static void E07_BalancedParentheses()
        {
            string bracketsLine = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            char[] openBrackets = new char[] { '[', '{', '(' };

            for (int i = 0; i < bracketsLine.Length; i++)
            {
                if (openBrackets.Contains(bracketsLine[i]))
                {
                    stack.Push(bracketsLine[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (bracketsLine[i])
                    {
                        case ']':
                            if (stack.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case '}':
                            if (stack.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ')':
                            if (stack.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }

        private static void E06_TruckTour()
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < pumpsCount; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            for (int i = 0; i < pumpsCount; i++)
            {
                int tankFuel = 0;
                bool isTrue = true;

                for (int k = 0; k < pumpsCount; k++)
                {
                    int[] curPump = pumps.Dequeue();
                    tankFuel += curPump[0] - curPump[1];
                    if (tankFuel < 0)
                    {
                        isTrue = false;
                    }
                    pumps.Enqueue(curPump);
                }
                if (isTrue)
                {
                    Console.WriteLine(i);
                    break;
                }
                int[] startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);
            }

        }

        private static void E05_CalculateSequenceQueue()
        {
            long S = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();

            Queue<long> anslwer = new Queue<long>();
            anslwer.Enqueue(S);

            queue.Enqueue(S);
            while (anslwer.Count < 50)
            {
                S = queue.Peek() + 1;
                anslwer.Enqueue(S);
                queue.Enqueue(S);

                S = (queue.Peek() * 2) + 1;
                anslwer.Enqueue(S);
                queue.Enqueue(S);

                S = queue.Dequeue() + 2;
                anslwer.Enqueue(S);
                queue.Enqueue(S);
            }

            for (int k = 0; k < 50; k++)
            {
                Console.Write($"{anslwer.Dequeue()} ");
            }
        }

        private static void E04_BasicQueueOperations()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int N = input[0];   //elements to add
            int S = input[1];   //elements to dequeue
            int X = input[2];   //element to check is present in queue

            int[] inputElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(inputElements);

            for (int i = 0; i < S; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count != 0)
            {
                if (queue.Contains(X))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void E03_MaximumElement()
        {
            int inputCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> maxValues = new Stack<int>();
            int maxValue = int.MinValue;

            for (int i = 0; i < inputCount; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                    if (input[1] > maxValue)
                    {
                        maxValue = input[1];
                        maxValues.Push(maxValue);
                    }
                }
                else if (input[0] == 2)
                {
                    if (stack.Pop() == maxValue)
                    {
                        maxValues.Pop();
                        if (maxValues.Count != 0)
                        {
                            maxValue = maxValues.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (input[0] == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }

        private static void E02_BasicStackOperations()
        {
            int[] parameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int N = parameters[0]; //amount of elements to push
            int S = parameters[1]; //amount of elements to pop
            int X = parameters[2]; //element for check

            int[] stackInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();


            for (int i = 0; i < N - S; i++)
            {
                stack.Push(stackInput[i]);
            }

            if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }

        private static void E01_ReverseNumbersWithStack()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
