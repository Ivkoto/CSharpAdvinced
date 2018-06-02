namespace ManualStringProcessingLab
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //E01_StudentResult();

            //E02_ParseURLs();

            //E03_ParseTags();

            //E04_SpecialWords();

            //E05_ConcatenateString();
        }

        private static void E04_SpecialWords()
        {
            var separators = new char[] { ' ', '(', ')', '[', ']', '<', '>', ',', '-', '!', '?' };
            string[] words = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                dict[word] = 0;
                var index = text.IndexOf(word);
                while (index >= 0)
                {
                    dict[word]++;
                    var startIndex = index + word.Length;
                    index = text.IndexOf(word, startIndex);
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }

        private static void E05_ConcatenateString()
        {
            var count = int.Parse(Console.ReadLine());
            var words = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                words.Append($"{Console.ReadLine()} ");
            }
            Console.WriteLine(words);
        }

        private static void E03_ParseTags()
        {
            var text = Console.ReadLine();
            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            var startIndex = 0;

            while ((startIndex = text.IndexOf(openTag)) != -1)
            {
                var endIndex = text.IndexOf(closeTag);

                if (endIndex == -1)
                {
                    break;
                }
                var toBeReplaced = text.Substring(startIndex, endIndex + closeTag.Length - startIndex);
                var replaced = toBeReplaced.Replace(openTag, string.Empty).Replace(closeTag, string.Empty).ToUpper();
                text = text.Replace(toBeReplaced, replaced);
            }
            Console.WriteLine(text);
        }

        private static void E02_ParseURLs()
        {
            var url = Console.ReadLine()
                .Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);


            if (url.Length != 2 || url[1].IndexOf('/') > -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = url[0];
                var index = url[1].IndexOf('/');
                var server = url[1].Substring(0, index);
                var resources = url[1].Substring(index + 1);

                var stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("Protocol = {0}\nServer = {1}\nResources = {2}", protocol, server, resources));
                Console.WriteLine(stringBuilder);
            }

        }

        private static void E01_StudentResult()
        {
            var n = int.Parse(Console.ReadLine());
            var studentsList = new Queue<string>();
            var printInfo = new StringBuilder();
            printInfo.Append(string.Format("{0, -10}|{1, 7}|{2, 7}|{3, 7}|{4, 7}|\n", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < n; i++)
            {
                studentsList.Enqueue(Console.ReadLine());
            }

            foreach (var student in studentsList)
            {
                var info = student.Split(new[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                var scores = new double[] { double.Parse(info[1]), double.Parse(info[2]), double.Parse(info[3]) };
                printInfo.Append(string.Format("{0, -10}|{1, 7 :f2}|{2, 7 :f2}|{3, 7 :f2}|{4, 7 :f4}|\n\r", info[0], double.Parse(info[1]), double.Parse(info[2]), double.Parse(info[3]), scores.Average()));
            }
            Console.WriteLine(printInfo);
        }
    }
}
