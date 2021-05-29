using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DataAccess.Configuration
{
    public class NhibernateConfiguration
    {
        private const string ConnectionStringAlias = "DefaultConnection";
        private static string _connectionString = "";

        static NhibernateConfiguration()
        {
        }

        public static void SetUpConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringAlias);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ConfigurationErrorsException("Cannot found connection string.");
            }
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
