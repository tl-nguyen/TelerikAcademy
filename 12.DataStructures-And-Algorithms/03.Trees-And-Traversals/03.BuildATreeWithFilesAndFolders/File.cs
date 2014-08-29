using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildATreeWithFilesAndFolders
{
    class File
    {
        public string Name { get; set; }
        public int size { get; set; }

        public File(string name)
        {
            this.Name = name;
        }
    }
}
