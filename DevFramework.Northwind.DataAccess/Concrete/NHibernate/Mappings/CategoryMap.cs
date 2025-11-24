using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    public class CategoryMap: ClassMap<Category>
    {


        public CategoryMap() {


            Table(@"Categories");

            LazyLoad();

            Id(x=>x.CategoryId).Column("CategoryID");


            Map(x => x.CategoryName).Column("CategoryName");




    }    }
}
