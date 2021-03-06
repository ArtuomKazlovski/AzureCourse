﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Azure.Search;
using StackExchange.Redis;

namespace BookStore.Helpers
{
    public static class AzureHelpers
    {
        public const string PlayersIndexName = "players";
        public const string BooksIndexName = "books-pooling-index";

        public static SearchServiceClient CreateSearchServiceClient()
        {
            var appSettings = ConfigurationManager.AppSettings;

            string searchServiceName = appSettings["SearchServiceName"];
            string adminApiKey = appSettings["SearchServiceAdminApiKey"];

            SearchServiceClient serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(adminApiKey));
            return serviceClient;
        }

        public static ConnectionMultiplexer CreateRedisConnection()
        {
            var redisConnection = ConfigurationManager.ConnectionStrings["redis"].ConnectionString;

            return ConnectionMultiplexer.Connect(redisConnection);
        }
    }
}