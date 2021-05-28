using NHibernate;
using NHibernate.Cfg;

namespace DataAccess.Nhibernate
{
    public interface INhibernateSessionFactory
    {
        ISession CreateSession();

        Configuration GetConfiguration(string connectionAlias);
    }
}
