namespace RegularExpressions
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            //E01_MatchCount();

            //E02_WowelCount();

            //E03_NonDigitCount();

            //E04_ExtractIntegerNumbers();

            //E05_ExtractTags();

            //E06_ValidUserName();

            //E07_ValidTime();

            //E08_ExtractQuotations();
            
        }

        private static void E08_ExtractQuotations()
        {
            var text = Console.ReadLine();
            var pattern = @"(['|""])([\S\s]+?)\1";

            var regex = new Regex(pattern);
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }

        private static void E07_ValidTime()
        {
            var input = string.Empty;
            var pattern = @"\b(0?[0-9]|1[0-2])(:[0-5]?[0-9]){2}\s?(A|P)M\b";
            var regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(regex.IsMatch(input) ? "valid" : "invalid");
            }
        }

        private static void E06_ValidUserName()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var regex = new Regex(@"^[\w-]{3,16}$");
                var result = regex.Match(input);
                if (result.Value != string.Empty)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }

        private static void E05_ExtractTags()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var regex = new Regex("<.+?>");
                var matches = regex.Matches(input);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match);
                    }
                }

            }
        }

        private static void E04_ExtractIntegerNumbers()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }

        private static void E03_NonDigitCount()
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"\D");
            var count = regex.Matches(text).Count;
            Console.WriteLine($"Non-digits: {count}");
        }

        private static void E02_WowelCount()
        {
            var text = Console.ReadLine();

            var regex = new Regex("[AEIOUYaeiouy]");
            var count = regex.Matches(text).Count;
            Console.WriteLine($"Vowels: {count}");
        }

        private static void E01_MatchCount()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            Regex regex = new Regex(word);
            var matches = regex.Matches(text);
            Console.WriteLine(matches.Count);
        }
    }
}