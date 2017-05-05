using System;
using System.IO;

namespace DemoMoq.Library
{
    public class Utility
    {
        public static void WriteLog(string message)
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";

            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath).Create();

            var filePath = $"{dirPath}log_{DateTime.Now.ToShortDateString()}.txt".Replace("/", "");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            using (var w = File.AppendText(filePath))
            {
                w.WriteLine("\n");
                w.WriteLine("[{0:yy-MM-dd-yyyy hh:mm:ss tt}]: {1}", DateTime.Now, message);
                w.WriteLine("\n");
                w.Close();
            }
        }
    }
}
