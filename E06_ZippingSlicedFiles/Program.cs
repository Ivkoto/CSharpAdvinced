namespace E05_SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var sourceFile = "../../video.mp4";
            var destinationFolder = "../../";
            var parts = 4;

            List<string> files = Slice(sourceFile, destinationFolder, parts);

            Assemble(files, destinationFolder);
        }

        private static void Assemble(List<string> files, string destinationFolder)
        {
            using (var writer = new FileStream("../../assembled.mp4", FileMode.Create, FileAccess.Write))
            {
                foreach (var file in files)
                {                    
                    using (var reader = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        using (var decompression = new GZipStream(reader, CompressionMode.Decompress, false))
                        {
                            var buffer = new byte[4096];
                            var readBytes = 0;
                            while ((readBytes = decompression.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                writer.Write(buffer, 0, readBytes);
                            }
                        }
                        
                    }
                }
            }
        }

        private static List<string> Slice(string sourceFile, string destinationFolder, int parts)
        {
            var files = new List<string>();
            using (var reader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var partSize = reader.Length / parts + reader.Length % parts;

                for (int i = 1; i <= parts; i++)
                {
                    var outputFile = Path.Combine(destinationFolder, $"Part-{i}.gz");

                    using (var writer = new FileStream(outputFile, FileMode.Create))
                    {
                        using (var compression = new GZipStream(writer, CompressionMode.Compress, false))
                        {
                            var buffer = new byte[partSize];

                            var readBytes = reader.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }
                            compression.Write(buffer, 0, readBytes);
                        }
                        
                    }
                    files.Add(outputFile);
                }
            }
            return files;
        }
    }
}
