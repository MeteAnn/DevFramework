using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAccess.Tests1
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {

            EfProductDal  efProductDal = new EfProductDal();

            var result = efProductDal.GetList();

            Assert.AreEqual(85, result.Count);





        }


        [TestMethod]
        public void Get_all_by_category_returns_filtered_products()
        {
            EfProductDal efProductDal = new EfProductDal();
            var result = efProductDal.GetList(p => p.CategoryId == 2);
            Assert.AreEqual(7, result.Count);
        }
    }
}
