namespace MongoChat.Data
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MongoDB.Driver;

    public class MongoContext
    {
        private string dbName;
        private ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["MongoDb"];

        public MongoDatabase Database { get; private set; }
        
        public MongoContext(string dbName)
        {
            this.dbName = dbName;
            this.Database = this.GetDatabase(this.connectionString.ConnectionString);
        }

        public MongoDatabase GetDatabase(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            var database = mongoServer.GetDatabase(dbName);

            return database;
        }
    }
}
