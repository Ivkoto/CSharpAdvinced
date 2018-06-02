namespace E04_CopyBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            using (var source = new FileStream("../../pic.jpg", FileMode.Open, FileAccess.Read, FileShare.None))
            using (var coppy = new FileStream("../../picCopy.jpg", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var buffer = new byte[4096];
                double fileLenght = source.Length;
                while (true)
                {
                    var readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    coppy.Write(buffer, 0, readBytes);

                    Console.WriteLine("{0:P}", Math.Min(source.Position / fileLenght, 1));
                }
            }

        }
    }
}
