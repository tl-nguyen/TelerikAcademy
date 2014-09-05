namespace MongoChat.Controllers
{
    using System;
    using System.Collections.Generic;

    using MongoChat.Models;

    interface IChatController
    {
        void SendMessage(Message message);

        List<Message> GetAllMessages();

        List<Message> GetLastMessages(DateTime lastDate);
    }
}
