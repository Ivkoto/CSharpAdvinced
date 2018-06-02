namespace E01_ReverseString
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputString = Console.ReadLine().ToCharArray();
            string outputString = Reverse(inputString);
            Console.WriteLine(outputString);
        }

        private static string Reverse(char[] inputString)
        {
            Array.Reverse(inputString);
            var outputString = new string(inputString);
            return outputString;
        }
    }
}