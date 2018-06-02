namespace FunctionalProgrammingLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            //E01_SortEvenNumbers();

            //E02_SumNumbers();

            //E03_CountUppercaseWords();

            //E04_AddVAT();

            E05_FilterByAge();
        }
        private static void E05_FilterByAge()
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                people[input[0]] = int.Parse(input[1]);
            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = Tester(condition, age);

            Action<KeyValuePair<string, int>> printer = Printer(format);

            InvokePrinting(people, tester, printer);
        }

        private static void InvokePrinting(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Func<int, bool> Tester(string condition, int age)
        {
            if (condition.Equals("younger"))
            {
                return a => a < age;
            }
            else
            {
                return a => a >= age;
            }
        }

        private static Action<KeyValuePair<string, int>> Printer(string format)
        {
            switch (format)
            {
                case "name age":
                    return p => Console.WriteLine($"{p.Key} - {p.Value}");
                case "name":
                    return p => Console.WriteLine(p.Key);
                case "age":
                    return p => Console.WriteLine(p.Value);
                default:
                    return null;
            }
        }
        //End of E05
        private static void E04_AddVAT()
        {
            var input = Console.ReadLine();

            input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .Select(n => n *= 1.2)
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n:f2}"));
        }

        private static void E03_CountUppercaseWords()
        {
            var input = Console.ReadLine();
            input.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n)
                .Where(w => char.IsUpper(w[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }

        private static void E02_SumNumbers()
        {
            var input = Console.ReadLine();
            Console.WriteLine(input
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .Count());

            Console.WriteLine(input
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                .Sum());
        }

        private static void E01_SortEvenNumbers()
        {
            Console.WriteLine(string.Join(", ",
                            Console.ReadLine()
                            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .Where(n => n % 2 == 0)
                            .OrderBy(n => n)
                            .ToList()));
        }
    }
}