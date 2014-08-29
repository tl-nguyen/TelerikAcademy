using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildATreeWithFilesAndFolders
{
    class Folder
    {
        public string Name { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> ChildFolders { get; set; }

        public Folder (string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }
    }
}
