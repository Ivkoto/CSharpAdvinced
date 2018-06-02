namespace E02_StringLength
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var inputString = Console.ReadLine();
            Console.WriteLine(inputString.PadRight(20, '*'));            
        }
    }
}