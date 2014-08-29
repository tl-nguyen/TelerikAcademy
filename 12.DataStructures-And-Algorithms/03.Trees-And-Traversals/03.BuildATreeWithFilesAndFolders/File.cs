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
        public long size { get; set; }

        public File(string name, long size)
        {
            this.Name = name;
            this.size = size;
        }
    }
}
