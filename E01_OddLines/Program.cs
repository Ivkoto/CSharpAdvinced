namespace E01_OddLines
{
    using System.IO;
    using System;
    using System.Text;

    class Program
    {
        static void Main()
        {
            Console.Write("Choose file path to read:  ");
            var inputFilePath = Console.ReadLine();
            //input file path: "../../oddLinesInput.txt"

            using (var reader = new StreamReader(inputFilePath))
            {
                var result = new StringBuilder();
                int lineNumber = 1;
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 1)
                    {
                        result.Append(line + Environment.NewLine);
                    }
                    lineNumber++;
                }
                Console.WriteLine(result.ToString());
            }
        }
    }
}
