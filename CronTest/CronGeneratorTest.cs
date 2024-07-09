using CronGeneratorCore;
using CronGeneratorCore.Model;
using System.Collections.Generic;

namespace CronTest
{
    /// <summary>
    /// class test việc generate biểu thức cron có thành công không
    /// </summary>
    [TestClass]
    public class CronGeneratorTest
    {
        /// <summary>
        /// test xem build thành công không
        /// </summary>
        [TestMethod]
        public void TestSimple_Success()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// test xem build thành công 1 biểu thức không
        /// </summary>
        [TestMethod]
        public void TestBuilder_BuildSuccess()
        {
            CronExpressionModel cronExp = new CronExpressionBuilder().BuildHour(1).BuildDayOfWeek(new List<int>() { 1,2,3}).BuildDayOfMonth(1,12).GetResult();
            string cronExpression = cronExp.ToString();

            Assert.IsTrue(!string.IsNullOrEmpty(cronExpression));
        }
    }
}