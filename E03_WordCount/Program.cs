namespace E03_WordCount
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var wordFile = "../../word.txt";
            var textFile = "../../text.txt";

            var dict = new Dictionary<string, int>();

            var words = ReadFile(wordFile)
                .ToLower()
                .Split(new char[] { ' ', '\n', '\r', '\t', '-', '.', ',', ':', ';', '!', '?', '…' }, StringSplitOptions.RemoveEmptyEntries);

            var text = ReadFile(textFile)
                .ToLower()
                .Split(new char[] { ' ', '\n', '\r', '\t', '-', '.', ',', ':', ';', '!', '?', '…' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < text.Length; i++)
            {
                if (words.Contains(text[i]))
                {
                    AddToDictionary(dict, text[i]);
                }
            }

            PrintResultAndSaveInFile(dict);
        }

        private static void PrintResultAndSaveInFile(Dictionary<string, int> dict)
        {
            using (var writer = new StreamWriter("../../Result.txt"))
            {
                foreach (var pair in dict.OrderByDescending(k => k.Value))
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                    writer.Write($"{pair.Key} - {pair.Value}");
                    writer.WriteLine();
                }
                
            }
            
        }

        private static void AddToDictionary(Dictionary<string, int> dict, string curWord)
        {
            if (!dict.ContainsKey(curWord))
            {
                dict[curWord] = 1;
            }
            else
            {
                dict[curWord]++;
            }
        }

        private static string ReadFile(string inputFile)
        {
            var sb = new StringBuilder();
            string line = string.Empty;
            using (var reader = new StreamReader(inputFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(line + " ");
                }
            }
            return sb.ToString();
        }
    }
}
