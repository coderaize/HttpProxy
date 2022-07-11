using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyServerApp
{
    class LogMaker
    {
        public static string DetailedLogs { get; set; }

        public static void AddLogs(string text, bool isError = false)
        {
            try
            {
                string logsFile = Environment.CurrentDirectory + "\\Logs.txt";
                if (isError) { text = "[ERORR]" + DateTime.Now + "[]" + text + "[]"; }
                else { text = "\r\n---\r\n[LOG]" + DateTime.Now + "[]" + text + "[]"; }
                using (StreamWriter file = new StreamWriter(logsFile, true))
                {
                    file.WriteLine(text);
                }
            }
            catch { }
        }

        public static void DetailedAddLogs(string text, bool isError = false)
        {
            //if (isError) { text = "[ERORR]" + DateTime.Now + "[]" + text + "[]"; }
            //else { text = "[LOG]" + DateTime.Now + "[]" + text + "[]"; }
            DetailedLogs += text;

        }

        public void WriteToFile()
        {
            string logsDirectory = @"C:\proxy\Logs";
            string logsFile = logsDirectory + "\\logs1.txt";
            var source = new CancellationTokenSource();
            var token = source.Token;

            //Task.Run(() => {;
            //    var conf = new Configuration();
            //    conf.Encoding = Encoding.UTF8;
            //    conf.CultureInfo = CultureInfo.InvariantCulture;

            //    using (var stream = File.OpenWrite(logsFile))
            //    using (var writer = new StreamWriter(stream))

            //    {
            //        //writer.WriteHeader<Product>();
            //        //writer.NextRecord();

            //        while (true)
            //        {
            //            if (token.IsCancellationRequested)
            //            {
            //                writer.Flush();
            //                return;
            //            }
            //            while (_products.TryDequeue(out product))
            //            {

            //            }
            //        }
            //    }
            //}, token);

            //var task1 = Task.Run(() =>
            //{
            //    foreach (var number in Enumerable.Range(1, 10))
            //    {
            //        var product = new Product
            //        {
            //            Id = number,
            //            Name = "Product " + number,
            //            Price = Math.Round((10d * number) / DateTime.Now.Second, 2)
            //        };

            //        _products.Enqueue(product);

            //        Task.Delay(150).Wait();
            //    }
            //});

            //var task2 = Task.Run(() =>
            //{
            //    foreach (var number in Enumerable.Range(11, 10))
            //    {
            //        var product = new Product
            //        {
            //            Id = number,
            //            Name = "Product " + number,
            //            Price = Math.Round((10d * number) / DateTime.Now.Second, 2)
            //        };

            //        _products.Enqueue(product);

            //        Task.Delay(150).Wait();
            //    }
            //});

            //Task.WaitAll(task);
            //Console.WriteLine(Environment.NewLine);
            //Console.WriteLine("Press any key to exit ...");
            //Console.ReadKey();
            //source.Cancel();
        }
    }



}
