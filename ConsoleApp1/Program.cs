namespace E01_SortEvenNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
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