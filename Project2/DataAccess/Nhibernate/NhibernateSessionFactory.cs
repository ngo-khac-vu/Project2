using DataAccess.Nhibernate.Helper;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using System;
using System.Data.Common;
using System.Reflection;

namespace DataAccess.Nhibernate
{
    public class NhibernateSessionFactory : INhibernateSessionFactory, IDisposable
    {
        private ISessionFactory _sessionFactory;
        private System.Configuration.ConnectionStringSettings _connectionString;

        private const string NHibernateResourceNameKey = "NHConfigResourceName";
        private const string NhibernateRessourceAssembly = "NHConfigResourceAssembly";

        public NhibernateSessionFactory()
        {
            Load();
        }

        private void Load()
        {
            this.LoadConnectionStringsFromConfig();
            try
            {
                _sessionFactory = CreateSessionFactory();
            }
            catch (HibernateException ex)
            {
                throw new Exception($"Cannot create Session.", ex);
            }
        }

        private ISessionFactory CreateSessionFactory()
        {
            Configuration cfg = GetConfiguration(null);
            return cfg.BuildSessionFactory();
        }

        private void LoadConnectionStringsFromConfig()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count != 1)
            {
                throw new System.Configuration.ConfigurationErrorsException($"Must have exactly one connection string, but found {System.Configuration.ConfigurationManager.ConnectionStrings.Count}");
            }
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[0];
        }

        private string GetResourceName()
        {
            string resourceName = System.Configuration.ConfigurationManager.AppSettings[NHibernateResourceNameKey];
            if (string.IsNullOrEmpty(resourceName))
            {
                throw new System.Configuration.ConfigurationErrorsException($"No {NHibernateResourceNameKey} configuration found.");
            }

            return resourceName;
        }

        public ISession CreateSession()
        {
            DbConnection connection = BuildConnection();
            return _sessionFactory.WithOptions().Connection(connection).OpenSession();
        }

        private DbConnection BuildConnection()
        {
            string providerName = _connectionString.ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = _connectionString.ConnectionString;

            if (connection == null)
            {
                throw new System.Configuration.ConfigurationErrorsException($"Cannot build connection string");
            }
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot connect to connection string: path={connection.ConnectionString}.", ex);
            }

            return connection;
        }

        public void DisposeSession(ISession session)
        {
            throw new NotImplementedException();
        }

        public Configuration GetConfiguration(string connectionAlias)
        {
            Assembly assembly = GetAssemblyForResourceAssemblyName();
            string resourceName = this.GetResourceName();
            Configuration configuration = new Configuration();
            configuration.Configure(assembly, resourceName);
            SerializeDomainObjects(configuration);
            return configuration;
        }

        private void SerializeDomainObjects(Configuration configuration)
        {
            configuration.AddInputStream(HbmSerializer.Default.Serialize(AssemblyLoadingHelper.GetOrLoadAssembly("DataAccess")));
        }

        private Assembly GetAssemblyForResourceAssemblyName()
        {
            string resourceAssembly = System.Configuration.ConfigurationManager.AppSettings[NhibernateRessourceAssembly];
            if (string.IsNullOrEmpty(resourceAssembly))
            {
                throw new System.Configuration.ConfigurationErrorsException($"No {NhibernateRessourceAssembly} configuration found.");
            }
            Assembly asm = AssemblyLoadingHelper.GetOrLoadAssembly(resourceAssembly);
            return asm;
        }

        public void Dispose()
        {
        }
    }
}
