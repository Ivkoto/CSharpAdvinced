namespace E09_HTTP_Server
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class Program
    {
        private const int Port = 1337;
        private const string SourcePath = "../../Source";
        private const string ErrorPath = "../../Source/error.html";

        static void Main()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, Port);

            tcpListener.Start();
            Console.WriteLine($"Listening on port {Port}...");
            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, request.Length);

                    var requestData = Encoding.UTF8.GetString(request, 0, request.Length).Replace("\\", "/");
                    Console.WriteLine($"ReqData: {requestData}");

                    if (!string.IsNullOrEmpty(requestData))
                    {
                        var file = string.Empty;

                        var reqFirstLine = requestData.Substring(0, requestData.IndexOf(Environment.NewLine)).Split();
                        var url = reqFirstLine[1];
                        var statusLine = $"{reqFirstLine[2]} 200 OK";

                        if (url == "/")
                        {
                            file = $"{SourcePath}/index.html";
                        }
                        else
                        {
                            var reqFile = $"{SourcePath}{url.Substring(url.IndexOf('/'))}";

                            if (!reqFile.EndsWith(".html"))
                            {
                                reqFile += ".html";
                            }
                            if (File.Exists(reqFile))
                            {
                                file = reqFile;
                            }
                            else
                            {
                                file = ErrorPath;
                                statusLine = "HTTP/1.0 404 Not Found";
                            }
                        }
                        
                        /....
                    }
                }
            }
        }
    }
}
