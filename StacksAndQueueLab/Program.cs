namespace StacksAndQueueLab
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            //exercise with Stack:

            //E01_ReverseString();
            //E02_SimpleCalculator();
            //E03_DecimalToBinaryConverter();
            //E04_4MatchingBrackets();
            //----------------------------------------

            //Exsercise with Queue:

            //E05_HotPotato();
            //E06_MathPotato();
        }

        private static void E06_MathPotato()
        {
            string[] input = Console.ReadLine().Split(' ');
            int cycles = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);


            int cycle = 1;

            while (queue.Count > 1)
            {  
                for (int i = 0; i < cycles - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public static class PrimeTool
        {
            public static bool IsPrime(int candidate)
            {
                // Test whether the parameter is a prime number.
                if ((candidate & 1) == 0)
                {
                    if (candidate == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Note:
                // ... This version was changed to test the square.
                // ... Original version tested against the square root.
                // ... Also we exclude 1 at the end.
                for (int i = 3; (i * i) <= candidate; i += 2)
                {
                    if ((candidate % i) == 0)
                    {
                        return false;
                    }
                }
                return candidate != 1;
            }
        }

        private static void E05_HotPotato()
        {
            string[] input = Console.ReadLine().Split(' ');
            Queue<string> queue = new Queue<string>(input);
            int number = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");

        }

        private static void E04_4MatchingBrackets()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int index = stack.Pop();
                    string reminder = input.Substring(index, i - index + 1);
                    Console.WriteLine(reminder);
                }
            }
        }

        private static void E03_DecimalToBinaryConverter()
        {
            int input = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input > 0)
                {
                    stack.Push(input % 2);
                    input /= 2;
                }
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }

        private static void E02_SimpleCalculator()
        {
            string[] input = Console.ReadLine().Split(' ');
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string operat = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());

                if (operat == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(stack.Peek());
        }

        private static void E01_ReverseString()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
