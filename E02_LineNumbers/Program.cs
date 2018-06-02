namespace E01_OddLines
{
    using System.IO;
    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Choose file path to read:  ");
            var inputFilePath = Console.ReadLine();
            //input file path: "../../oddLinesInput.txt"

            Console.Write("Choose file path to save: ");
            var outputFilePath = Console.ReadLine();
            //outpu file path: "../../.lineNumbersResult.txt"

            using (var reader = new StreamReader(inputFilePath))
            {
                using (var writer = new StreamWriter(outputFilePath))
                {
                    var line = string.Empty;
                    int lineNumber = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{lineNumber} {line}");
                        lineNumber++;
                    }
                }

            }
        }
    }
}
