using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Type;
using NHibernateTest.DomainClasses;

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
            var cfg = new StoreConfiguration();
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(@"Data Source=.;Initial Catalog=Employee;User ID=sa;Password=sa123")
                    .ShowSql()
                    )
                ////.Mappings(m =>
                ////    m.FluentMappings
                ////    .AddFromAssemblyOf<Kazemi>(type => type.Namespace.EndsWith("Entities")))
                ////.ExposeConfiguration(cfg => new SchemaExport(cfg)
                ////    .Create(true, true))
                ////.BuildSessionFactory();
                // new
            .Mappings(m =>
                    m.AutoMappings
                        .Add(
                        // your automapping setup here
                        AutoMap.AssemblyOf<Kazemi>(cfg)))
                .ExposeConfiguration(cfgg => new SchemaExport(cfgg)
                    .Create(true, true))
            .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
