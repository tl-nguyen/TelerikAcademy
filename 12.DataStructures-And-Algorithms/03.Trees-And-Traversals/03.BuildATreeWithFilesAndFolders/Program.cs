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
            BuildTree(Tree);
            Console.WriteLine();
        }

        private static void BuildTree(Folder root)
        {
            foreach (string file in Directory.GetFiles(root.Name))
            {
                root.Files.Add(new File(file));
            }

            foreach (string subDirectory in Directory.GetDirectories(root.Name))
            {
                try
                {
                    var recentFolder = new Folder(subDirectory);
                    root.ChildFolders.Add(recentFolder);
                    BuildTree(recentFolder);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
