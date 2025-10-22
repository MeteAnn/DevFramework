using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public class NhEntityRepositoryBase<TEntity>: IEntityRepository<TEntity> where TEntity : class, DevFramework.Core.Entities.IEntity, new() // burası şu işe yarar ki, TEntity türü DevFramework.Core.Entities.IEntity arayüzünü implemente eden sınıflarla sınırlanır.
    {



        private NhibernateHelper _nhibernateHelper; //NHibernate oturumlarını yönetmek için kullanılan yardımcı sınıfın bir örneğini tutar. Yani burası şurası şöyle ki, veritabanı işlemlerini gerçekleştirmek için NHibernate oturumlarını yönetir. Neden var burası çünkü NHibernate ile çalışırken oturumlar, veritabanı ile etkileşim kurmak için gereklidir ve bu yardımcı sınıf, oturumların oluşturulması ve yönetilmesi işlemlerini kolaylaştırır.

        public NhEntityRepositoryBase( NhibernateHelper nHibernateHelper) 
        {


            _nhibernateHelper = nHibernateHelper; //Yapıcı metot, dışarıdan bir NhibernateHelper örneği alır ve sınıfın özel alanına atar. Böylece bu sınıfın örnekleri, NHibernate oturumlarını yönetmek için gerekli olan yardımcı sınıfı kullanabilir.



        }



        public TEntity Add(TEntity entity) //Yeni bir varlık eklemek için kullanılan metot.
        {

            using (var session = _nhibernateHelper.OpenSession()) //NHibernate oturumu açar.

            {

                session.Save(entity); //Veritabanına yeni bir varlık ekler.
                return entity; //Eklenen varlığı döner. Nereye döner çünkü eklenen varlık veritabanına kaydedilir ve ardından çağıran tarafa döndürülür, böylece eklenen varlık üzerinde işlem yapmaya devam edilebilir. Nasıl yani hangi tarafa döner çünkü çağıran metot veya kod bloğu, eklenen varlığı kullanmak isteyebilir, örneğin eklenen varlığın kimliğini almak veya başka işlemler yapmak için.


            }


        }

        public void Delete(TEntity entity)
        {
            
            using (var session = _nhibernateHelper.OpenSession()) //NHibernate oturumu açar.
            {
                session.Delete(entity); //burada neden return etmiyoruz çünkü silme işlemi genellikle bir değer döndürmeyi gerektirmez. Silme işlemi başarılı bir şekilde tamamlandığında, varlık veritabanından kaldırılır ve çağıran tarafa geri döndürülmesi gereken bir bilgi yoktur. Silme işlemi genellikle yan etkili bir işlemdir; yani, varlık silinir ve bu işlem sonucunda geri döndürülecek bir değer yoktur. Bu nedenle, metot void olarak tanımlanmıştır ve herhangi bir değer döndürmez.
            }   




        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nhibernateHelper.OpenSession()) //NHibernate oturumu açar.
            {
                return session.Query<TEntity>().SingleOrDefault(filter); //Belirtilen filtreye uyan tek bir varlığı döner veya yoksa varsayılan değeri döner. Şöyle ki, bu metot, veritabanından belirli bir koşula uyan tek bir varlığı almak için kullanılır. Eğer filtreye uyan bir varlık bulunursa, o varlık döndürülür; eğer bulunamazsa, varsayılan değer (genellikle null) döndürülür. Bu, veritabanında belirli bir kriteri karşılayan tek bir kaydı almak için yaygın bir yöntemdir.
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null) //Varlıkların listesini almak için kullanılan metot. Filtre isteğe bağlıdır.
        {
            using (var session = _nhibernateHelper.OpenSession()) //NHibernate oturumu açar.
            {
                return filter == null //Eğer filtre belirtilmemişse
                    ? session.Query<TEntity>().ToList() //Eğer filtre belirtilmemişse, tüm varlıkları liste olarak döner.
                    : session.Query<TEntity>().Where(filter).ToList(); //Eğer filtre belirtilmişse, filtreye uyan varlıkları liste olarak döner.
            }
        }

        public TEntity Update(TEntity entity)
        {
           using (var session = _nhibernateHelper.OpenSession()) //NHibernate oturumu açar.
            {
                session.Update(entity); //Veritabanındaki varlığı günceller.
                return entity; //Güncellenen varlığı döner. Nereye döner çünkü güncellenen varlık veritabanında güncellendikten sonra çağıran tarafa döndürülür, böylece güncellenen varlık üzerinde işlem yapmaya devam edilebilir. Nasıl yani hangi tarafa döner çünkü çağıran metot veya kod bloğu, güncellenen varlığı kullanmak isteyebilir, örneğin güncellenen varlığın yeni değerlerini almak veya başka işlemler yapmak için.
            }
        }
    }
}
