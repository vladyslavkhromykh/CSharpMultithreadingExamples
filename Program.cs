using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CSharpMultithreading
{
    internal class Program
    {

        ///<summary> Asynchronous Pattern (.NET 1.0 async solution) </summary>
        private static void AsynchronousPattern()
        {
            Console.WriteLine(nameof(AsynchronousPattern));
            WebRequest request = WebRequest.Create("uel");
            IAsyncResult result = request.BeginGetResponse(ReadResponse, null);

            void ReadResponse(IAsyncResult ar)
            {
                using (WebResponse response = request.EndGetResponse(ar))
                {
                    Stream stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 100));
                    Console.WriteLine();
                }
            }
        }

        ///<summary> Event-based asynchornous Pattern (.NET 2.0 async solution) </summary>
        private static void EventBasedAsyncPattern()
        {
            Console.WriteLine(nameof(EventBasedAsyncPattern));
            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += (sender, e) => { Console.WriteLine(e.Result.Substring(0, 100));};
                client.DownloadStringAsync(new Uri("url"));
                Console.WriteLine();
            }
        }

        ///<summary> Task-based asynchornous Pattern (.NET 4.5+ async solution) </summary>
        private static async Task TaskBasedAsyncPatternAsync()
        {
            Console.WriteLine(nameof(TaskBasedAsyncPatternAsync));
            using (var client = new WebClient())
            {
                string content = await client.DownloadStringTaskAsync("url");
                Console.WriteLine(content.Substring(0, 100));
                Console.WriteLine();
            }
        }
    }
}