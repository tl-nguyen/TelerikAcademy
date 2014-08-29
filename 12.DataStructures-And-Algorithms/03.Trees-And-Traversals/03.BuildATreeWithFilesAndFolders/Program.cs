using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildATreeWithFilesAndFolders
{
    class Program
    {
        public static Folder Tree = new Folder("C:\\Windows\\");
        static void Main(string[] args)
        {
            Console.WriteLine("Total size of Windows = {0} MB", BuildTree(Tree) / 1024000);
        }

        private static long BuildTree(Folder root)
        {
            var currentDir = new DirectoryInfo(root.Name);
            var currentDirSize = 0L;

            foreach (var file in currentDir.GetFiles())
            {
                root.Files.Add(new File(file.Name, file.Length));
                currentDirSize += file.Length;
            }

            foreach (string subDirectory in Directory.GetDirectories(root.Name))
            {
                try
                {
                    var recentFolder = new Folder(subDirectory);
                    root.ChildFolders.Add(recentFolder);
                    currentDirSize += BuildTree(recentFolder);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return currentDirSize;
        }
    }
}
