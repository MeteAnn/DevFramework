using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>, IProductDal

    {



        public NhProductDal(NhibernateHelper nhibernateHelper):base(nhibernateHelper)
        {



            
        }

        public List<ProductDetail> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
