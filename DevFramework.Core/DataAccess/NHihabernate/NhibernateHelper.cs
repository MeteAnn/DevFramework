using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHihabernate
{
    public abstract class NhibernateHelper : IDisposable 
    {

        private static ISessionFactory _sessionFactory; //NHibernate oturum fabrikası için statik bir alan şöyle ki bütün uygulama boyunca tek bir oturum fabrikası kullanılır. Şu işe yarar ki, oturum fabrikası oluşturmak pahalı bir işlemdir ve uygulama boyunca tek bir örnek kullanmak performansı artırır.


        public virtual ISessionFactory SessionFactory //Oturum fabrikasına erişim sağlayan özellik.
        {
            get
            {


                return _sessionFactory ?? (_sessionFactory = InitializeFactory()); //Eğer oturum fabrikası henüz oluşturulmamışsa, InitializeFactory metodunu çağırarak oluşturur ve döner.



            }
        }



        protected abstract ISessionFactory InitializeFactory(); //Bu soyut metot, alt sınıflar tarafından oturum fabrikasının nasıl oluşturulacağını belirlemek için kullanılır.



        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession(); //Oturum fabrikasından yeni bir oturum açar ve döner.
        }

        public void Dispose() //IDisposable arayüzünden gelen Dispose metodu, kaynakları serbest bırakmak için kullanılır.
        {
            

            GC.SuppressFinalize(this); //Çöp toplayıcının finalize metodunu çağırmasını engeller.


        }
    }
}


//Buradaki kodlar genel olarak şu işe yarar ki, NHibernate kullanarak veritabanı işlemlerini gerçekleştirmek için bir temel sınıf sağlar. Oturum fabrikası oluşturma ve oturum açma işlemlerini yönetir, böylece alt sınıflar bu işlevselliği kullanabilir ve kendi özel oturum fabrikası yapılandırmalarını sağlayabilirler.