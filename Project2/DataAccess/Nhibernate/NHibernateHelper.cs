using System.Configuration;
using System.Reflection;
using DataAccess.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;

namespace DataAccess.Nhibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private const string ConnectionStringAlias = "DefaultConnection";

        static NHibernateHelper()
        {
            _sessionFactory = FluentConfigure();
        }

        public static ISession GetCurrentSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static ISessionFactory FluentConfigure()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(cs => cs.Is(NhibernateConfiguration.GetConnectionString())))
                .Cache(c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
