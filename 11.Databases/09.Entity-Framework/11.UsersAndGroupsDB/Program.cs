using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.UsersAndGroupsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new UsersAndGroupsContainer())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Users.Add(new User
                        {
                            Name = "gosho",
                            Group = new Group { Name = "Admin"}
                        });
                    ctx.SaveChanges();

                    transaction.Commit();
                }
            }
        }
    }
}
