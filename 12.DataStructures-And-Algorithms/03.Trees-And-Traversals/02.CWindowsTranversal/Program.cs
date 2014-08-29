using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CWindowsTranversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileExtension = ".exe";
            string windowsPath = @"C:\Windows\";

            TranverseDir(windowsPath, fileExtension);
        }

        private static void TranverseDir(string dirPath, string fileExtension)
        {
            foreach (string file in Directory.GetFiles(dirPath))
            {
                if(file.EndsWith(fileExtension))
                {
                    Console.WriteLine(file);
                }
            }

            foreach (string subDirectory in Directory.GetDirectories(dirPath))
            {
                try
                {
                    TranverseDir(subDirectory, fileExtension);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
