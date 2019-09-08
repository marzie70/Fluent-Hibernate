using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Type;

namespace NHibernateTest
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()



                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(@"Data Source=.;Initial Catalog=Employee;User ID=sa;Password=sa123")
                    .ShowSql()
                    )
                .Mappings(m =>
                    m.FluentMappings
                    .AddFromAssemblyOf<Kazemi>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                    .Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
