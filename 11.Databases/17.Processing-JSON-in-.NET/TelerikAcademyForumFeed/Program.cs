namespace TelerikAcademyForumFeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using System.Xml.Linq;
    using Newtonsoft.Json.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var webClient = new WebClient();
            string address = "http://forums.academy.telerik.com/feed/qa.rss";
            string filePath = @"..\..\..\TA-forum-feed.xml";

            webClient.DownloadFile(address, filePath);

            var xmlDoc = XDocument.Load(filePath);

            string jsonDoc = JsonConvert.SerializeXNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);

            var titles = GetTitle(jsonDoc);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            var poco = ConvertToPoco(jsonDoc);

            Console.WriteLine(poco);
        }

        private static object ConvertToPoco(string jsonDoc)
        {
            var template = new
            {
                Rss = new
                {
                    Channel = new
                    {
                        Title = "",
                        Link = "",
                        Description = ""
                    }
                }
            };

            var convertedObj = JsonConvert.DeserializeAnonymousType(jsonDoc, template);

            return convertedObj;
        }

        private static ICollection<JToken> GetTitle(string jsonDoc)
        {
            var jsonObj = JObject.Parse(jsonDoc);

            var titles = jsonObj["rss"]["channel"]["item"]
                                            .Select(i => i["title"])
                                            .ToList();

            return titles;
        }
    }
}
