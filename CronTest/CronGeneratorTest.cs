﻿using CronGeneratorCore;
using CronGeneratorCore.Enum;
using CronGeneratorCore.Model;

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
            CronExpressionModel cronExp = new CronExpressionBuilder()
                                            .BuildHour(1)
                                            .BuildDayOfWeek(new List<int>() { 1,2,3})
                                            .BuildDayOfMonth(1,12)
                                            .GetResult();
            string cronExpression = cronExp.ToString();

            Assert.AreEqual(cronExpression , "* * 1 1-12 * 1,2,3 * * *");
        }

        /// <summary>
        /// test xem build thành công 1 biểu thức từ ngày tới ngày không
        /// </summary>
        [TestMethod]
        public void TestBuilderFromDateToDate_BuildSuccess()
        {
            DateTime currentTime = new DateTime(2024, 02, 01);
            CronExpressionModel cronExp = new CronExpressionBuilder()
                                            .SetStartTimeAndEndtime(currentTime.AddDays(-30), currentTime)
                                            .GetResult();
            string cronExpression = cronExp.ToString();

            Assert.AreEqual(cronExpression, "* * * * * * * 2024-01-02 2024-02-01");
        }

        /// <summary>
        /// test xem build thành công 1 biểu thức từ ngày tới ngày không
        /// </summary>
        [TestMethod]
        public void TestBuilderFromDateToDateFrequently_BuildSuccess()
        {
            DateTime currentTime = new DateTime(2024, 02, 01);
            CronExpressionModel cronExp = new CronExpressionBuilder()
                                            .SetStartTimeAndEndtime(currentTime.AddDays(-30), currentTime)
                                            .SetWeekly(4)
                                            .GetResult();
            string cronExpression = cronExp.ToString();

            Assert.AreEqual(cronExpression, "* * * * * 4 * 2024-01-02 2024-02-01");
        }

        /// <summary>
        /// test xem build thành công 1 biểu thức từ ngày tới ngày không
        /// </summary>
        [TestMethod]
        public void TestBuilderMonthly_BuildSuccess()
        {
            DateTime currentTime = new DateTime(2024, 02, 01);
            CronExpressionModel cronExp = new CronExpressionBuilder()
                                            .SetStartTimeAndEndtime(currentTime.AddDays(-30), currentTime)
                                            .SetMonthly(30)
                                            .GetResult();
            string cronExpression = cronExp.ToString();

            Assert.AreEqual(cronExpression, "* * * 30|L * * * 2024-01-02 2024-02-01");
        }

        /// <summary>
        /// test xem build thành công 1 biểu thức theo tần suất
        /// </summary>
        [TestMethod]
        public void TestBuilderFrequently_BuildSuccess()
        {
            DateTime currentTime = new DateTime(2024, 02, 01);
            CronExpressionModel cronExp = new CronExpressionBuilder()
                                            .SetStartTimeAndEndtime(currentTime.AddDays(-30), currentTime)
                                            .SetFrequently((int)EnumCronFrequently.Monthly)
                                            .GetResult();
            string cronExpression = cronExp.ToString();

            Assert.AreEqual(cronExpression, "* * * 2 * * * 2024-01-02 2024-02-01");
        }
    }
}