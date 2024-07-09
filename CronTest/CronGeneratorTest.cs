using CronGeneratorCore;

namespace CronTest
{
    /// <summary>
    /// class test việc generate biểu thức cron có thành công không
    /// </summary>
    [TestClass]
    public class CronGeneratorTest
    {
        public class CronGenerator1 : CronGenerator 
        {
            
        }

        /// <summary>
        /// test xem build thành công không
        /// </summary>
        [TestMethod]
        public void TestSimple()
        {
            Assert.IsTrue(true);
        }
    }
}