namespace MongoChat.Controllers
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Linq;

    using MongoChat.Data;
    using MongoChat.Models;
    using MongoDB.Driver;

    public class ChatController : IChatController
    {
        private const string MessageCollectionName = "messages";
        private MongoContext ctx;
        private MongoCollection<Message> messageCollection;

        public ChatController()
        {
            this.ctx = new MongoContext("chatdb");
            this.messageCollection = ctx.Database.GetCollection<Message>(MessageCollectionName);
        }

        public void SendMessage(Models.Message message)
        {
            this.messageCollection.Insert(message);
        }

        public List<Models.Message> GetAllMessages()
        {
            var messages = this.messageCollection
                                .FindAll()
                                .ToList();

            return messages;
        }


        public List<Message> GetLastMessages(DateTime lastPostDateTime)
        {
            var messages = this.messageCollection
                                .FindAll()
                                .Where(m => m.Date > lastPostDateTime)
                                .ToList();

            return messages;
        }
    }
}
