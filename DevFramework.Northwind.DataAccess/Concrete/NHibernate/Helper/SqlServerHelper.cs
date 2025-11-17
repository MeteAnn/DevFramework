using DevFramework.Core.DataAccess.NHihabernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helper
{
    public class SqlServerHelper : NhibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=True;";

            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012
                        .ConnectionString(connStr)
                )
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
