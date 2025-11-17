using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;




namespace DevFramework.DataAccess.Tests.EntityFrameworkTests
{


    [TestClass] // Bu özellik bu sınıfın birim testi sınıfı olduğunu belirtir. Şöyle ki, bu sınıf içinde birim test metotları bulunur ve bu metotlar, uygulamanın belirli bölümlerini izole bir şekilde test etmek için kullanılır. Neden var burası çünkü birim testleri, yazılım geliştirme sürecinde kodun doğruluğunu ve güvenilirliğini sağlamak için önemlidir. Nasıl yani bu sınıf içinde bulunan metotlar, uygulamanın belirli işlevlerini test eder ve bu sayede hataların erken tespit edilmesini sağlar.
    public class EntityFrameworkTests
    {




        [TestMethod]
        public void Get_all_returns_all_products() // Bu metot, "Get_all_returns_all_products" adını taşıyor ve birim testi olarak işaretlenmiş. Şöyle ki, bu metot, uygulamanın belirli bir işlevini test etmek için kullanılır. Neden var burası çünkü bu metot, uygulamanın ürünleri doğru bir şekilde alıp almadığını kontrol eder. Nasıl yani, bu metot içinde yazılan kod, ürünlerin doğru bir şekilde alındığını doğrulamak için kullanılır.
        {



            EfProductDal productDal = new EfProductDal(); // EfProductDal sınıfından bir örnek oluşturur. Şöyle ki, bu sınıf, Entity Framework kullanarak ürün verilerine erişim sağlar. Neden var burası çünkü bu sınıf, veritabanı işlemlerini gerçekleştirmek için kullanılır. Nasıl yani, bu sınıfın örneği üzerinden ürün verilerine erişim sağlanır.


            var result = productDal.GetList(); // productDal örneği üzerinden GetAll() metodunu çağırır ve tüm ürünleri alır. Şöyle ki, bu metod, veritabanındaki tüm ürünleri döner. Neden var burası çünkü bu metot, ürün verilerini almak için kullanılır. Nasıl yani, bu metot çağrıldığında, veritabanındaki tüm ürünler result değişkenine atanır.



            Assert.AreEqual(85, result.Count);

        }



    }
}
