using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Entities.Concrete.Category>, ICategoryDal
    {
        public NhCategoryDal(NhibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
