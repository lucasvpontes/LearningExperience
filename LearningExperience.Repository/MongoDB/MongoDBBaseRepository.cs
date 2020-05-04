using LearningExperience.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LearningExperience.Repository.MongoDB
{
    public class MongoDBBaseRepository
    {
        protected MongoClient client;
        protected MongoDatabase database;
        private static string user;
        private static string password;

        static MongoDBBaseRepository()
        {
            var authFilePath = ConfigurationManager.AppSettings["MongoDBAuthFile"];

            if (string.IsNullOrEmpty(authFilePath))
                throw new InvalidOperationException($"MongoDB authorization data as not found from '{ConfigurationManager.AppSettings["MongoDBAuthFile"]}' @ {authFilePath}");

            if (!File.Exists(authFilePath))
                throw new InvalidOperationException($"MongoDB Authorization file not found from '{ConfigurationManager.AppSettings["MongoDBAuthFile"]}' @ {authFilePath}");

            var lines = File.ReadAllLines(authFilePath);
            int userLine;
            int pwdLine;

            if (lines[0].StartsWith("user"))
            {
                userLine = 0;
                pwdLine = 1;
            }
            else
            {
                userLine = 1;
                pwdLine = 0;
            }

            user = lines[userLine].Substring(lines[userLine].IndexOf("=", StringComparison.Ordinal) + 1);
            password = lines[pwdLine].Substring(lines[pwdLine].IndexOf("=", StringComparison.Ordinal) + 1);
        }

        public MongoDBBaseRepository()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            string dbName = ConfigurationManager.AppSettings["MongoDBDatabase"];
            var conString = string.Format(connectionString, user, password);
            client = new MongoClient(conString);
            var server = client.GetServer();
            database = server.GetDatabase(dbName);
        }
    }
}
