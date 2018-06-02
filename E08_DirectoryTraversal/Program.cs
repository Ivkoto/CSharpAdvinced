namespace E08_DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var directory = "../../../../../../../../../../../../Windows10Upgrade";
            var reportFile = "../../report.txt";
            var dict = new Dictionary<string, Dictionary<string, double>>();
            var dir = new DirectoryInfo(directory);
            FileInfo[] files = dir.GetFiles("*.*");
            
            foreach (FileInfo file in files)
            {
                if (!dict.ContainsKey(file.Extension))
                {
                    dict[file.Extension] = new Dictionary<string, double>();
                }
                dict[file.Extension][file.Name] = file.Length / 128.00;

                using (var writer = new StreamWriter(reportFile))
                {
                    foreach (var pair in dict.OrderByDescending(d => d.Value.Count).ThenBy(d => d.Key))
                    {
                        var filesGroup = string.Join(Environment.NewLine, pair.Value
                            .OrderBy(v => v.Value).Select(kv => $"--{kv.Key} - {kv.Value :f3}kb"));

                        writer.Write($"{pair.Key}{Environment.NewLine}{filesGroup}{Environment.NewLine}");
                    }
                }                
            }
        }
    }
}
