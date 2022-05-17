using Assignment2_userLogin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AddMethod()
        {
            BasicController bm = new BasicController();
            double res = bm.Add(10, 10);
            Assert.AreEqual(res, 20);
        }
        [TestMethod]
        public void Test_SubstractMethod()
        {
            BasicController bm = new BasicController();
            double res = bm.Substract(10, 10);
            Assert.AreEqual(res, 0);
        }
        [TestMethod]
        public void Test_DivideMethod()
        {
            BasicController bm = new BasicController();
            double res = bm.divide(10, 5);
            Assert.AreEqual(res, 2);
        }
        [TestMethod]
        public void Test_MultiplyMethod()
        {
            BasicController bm = new BasicController();
            double res = bm.Multiply(10, 10);
            Assert.AreEqual(res, 100);
        }

    }
}
