using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeshoFriends
{
    public struct Node
    {
        public Node(int id, int distance)
            : this()
        {
            this.Id = id;
            this.Distance = distance;
        }

        public int Id { get; set; }

        public int Distance { get; set; }
    }
}
