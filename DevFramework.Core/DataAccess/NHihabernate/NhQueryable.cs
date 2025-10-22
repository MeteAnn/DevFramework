using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public class NhQueryable<T> : IQueryableRepository<T> where T : class, DevFramework.Core.Entities.IEntity, new() // burası şu işe yarar ki, T türü DevFramework.Core.Entities.IEntity arayüzünü implemente eden sınıflarla sınırlanır. daha detaylı anlatmak gerekirse bu kodlar şu işe yarar ki, belirli bir türdeki varlıklar üzerinde sorgulama yapabilen bir repository (depo) sınıfı sağlar. Neden var burası çünkü veritabanı işlemlerini gerçekleştirmek için NHibernate kullanılır ve bu sınıf, NHibernate ile çalışırken sorgulama işlemlerini kolaylaştırır. Nasıl yani hangi türlerle çalışır çünkü T türü, DevFramework.Core.Entities.IEntity arayüzünü implemente eden sınıflarla sınırlanır, yani sadece bu arayüzü implemente eden varlık türleriyle çalışabilir.
    {

        private NhibernateHelper _nhibernateHelper; //NHibernate oturumlarını yönetmek için kullanılan yardımcı sınıfın bir örneğini tutar. Yani burası şurası şöyle ki, veritabanı işlemlerini gerçekleştirmek için NHibernate oturumlarını yönetir. Neden var burası çünkü NHibernate ile çalışırken oturumlar, veritabanı ile etkileşim kurmak için gereklidir ve bu yardımcı sınıf, oturumların oluşturulması ve yönetilmesi işlemlerini kolaylaştırır.

        private IQueryable<T> _entities; //Sorgulama işlemleri için kullanılan IQueryable türünde bir alan. Yani burası şurası şöyle ki, veritabanındaki T türündeki varlıklar üzerinde sorgulama yapabilmek için kullanılır. Neden var burası çünkü IQueryable arayüzü, LINQ (Language Integrated Query) sorgularını destekler ve bu sayede veritabanı üzerinde esnek ve güçlü sorgulamalar yapılabilir. Nasıl yani hangi türlerle çalışır çünkü T türü, DevFramework.Core.Entities.IEntity arayüzünü implemente eden sınıflarla sınırlanır, yani sadece bu arayüzü implemente eden varlık türleriyle çalışabilir.



        public NhQueryable(NhibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper; //Yapıcı metot, dışarıdan bir NhibernateHelper örneği alır ve sınıfın özel alanına atar. Böylece bu sınıfın örnekleri, NHibernate oturumlarını yönetmek için gerekli olan yardımcı sınıfı kullanabilir.

        }

        public IQueryable<T> Table
        {


            get { return this.Entities; }


        }

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null) //Eğer _entities alanı henüz oluşturulmamışsa,
                {
                    using (var session = _nhibernateHelper.OpenSession()) //NHibernate oturumu açar.
                    {
                        _entities = session.Query<T>(); //Veritabanındaki T türündeki varlıklar üzerinde sorgulama yapabilmek için IQueryable türünde bir koleksiyon oluşturur.
                    }
                }
                return _entities; //Oluşturulan IQueryable koleksiyonunu döner.
            }


        }
}
