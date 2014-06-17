using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreeDPoint
{
    public static class PathStorage
    {
        public static void Save(Path path, string file)
        {
            File.WriteAllText(file, path.ToString());
        }

        public static string Load(string file)
        {
            string[] content = File.ReadAllLines(file);

            StringBuilder result = new StringBuilder();

            foreach (var point in content)
            {
                result.Append(point + "\n");
            }

            return result.ToString();
        }
    }
}
