using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace SuperMarketQueue
{
    class SuperMarketQueueSolution
    {
        static ISupermarketRepository repository = new WintellectRepository();
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            string command = null;

            while (command != "End")
            {
                command = Console.ReadLine();

                ProcessCommand(command);
            }

            Console.WriteLine(result.ToString());
        }

        private static void ProcessCommand(string command)
        {
            string[] commandParts = command.Split(' ');
            string commandName = commandParts[0];

            switch(commandName)
            {
                case "Append":
                    string nameToAppend = commandParts[1];
                    repository.Append(nameToAppend);
                    result.AppendLine("OK");
                    break;
                case "Insert":
                    int position = int.Parse(commandParts[1]);
                    string nameToInsert = commandParts[2];

                    try
                    {
                        repository.Insert(position, nameToInsert);
                        result.AppendLine("OK");
                    }
                    catch (Exception)
                    {
                        result.AppendLine("Error");
                    }

                    break;
                case "Find":
                    string nameToFind = commandParts[1];
                    result.AppendLine(repository.Find(nameToFind).ToString());
                    break;
                case "Serve":
                    int countToServe = int.Parse(commandParts[1]);

                    try
                    {
                        var servedPeople = repository.Serve(countToServe);

                        string servedNameStr = string.Join(" ", servedPeople);
                        result.AppendLine(servedNameStr);
                    }
                    catch (Exception)
                    {
                        result.AppendLine("Error");
                    }
                    break;
                case "End":
                    break;
            }
        }
    }

    public interface ISupermarketRepository
    {
        void Append(string name);
        void Insert(int position, string name);
        int Find(string name);
        IList<string> Serve(int count);
    }

    class WintellectRepository : ISupermarketRepository
    {
        BigList<string> repository = new BigList<string>();
        Bag<string> names = new Bag<string>();


        public void Append(string name)
        {
            this.repository.Add(name);
            this.names.Add(name);
        }

        public void Insert(int position, string name)
        {
            this.repository.Insert(position, name);
            this.names.Add(name);
        }

        public int Find(string name)
        {
            return this.names.NumberOfCopies(name);
        }

        public IList<string> Serve(int count)
        {
            var servedName = this.repository.Range(0, count).ToList();

            this.repository.RemoveRange(0, count);
            this.names.RemoveMany(servedName);

            return servedName;
        }
    }
}
