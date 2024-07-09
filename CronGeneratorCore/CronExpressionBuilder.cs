using CronGeneratorCore.Enum;
using CronGeneratorCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronGeneratorCore
{
    public class CronExpressionBuilder
    {
        /// <summary>
        /// biểu thức lưu trữ kết quả
        /// </summary>
        private CronExpressionModel _cronExp = new CronExpressionModel();

        /// <summary>
        /// cron value nhận mọi giá tị
        /// </summary>
        private const string _allValue = "*";

        /// <summary>
        /// cron value chạy vào ngày cuối cùng của tháng
        /// </summary>
        private const string _endOfMonthValue = "L";

        /// <summary>
        /// build khoảng (range)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private string BuildRangeValue(int from, int to)
        {
            if(from == to)
            {
                return from.ToString();
            }
            return $"{from}-{to}";
        }

        /// <summary>
        /// build danh sách các giá trị thỏa mãn
        /// </summary>s
        /// <param name="listValue"></param>
        /// <returns></returns>
        private string BuildListvalue(List<int> listValue)
        {
            return string.Join(",", listValue.Where(x => x > 0).ToList());
        }

        /// <summary>
        /// build thứ trong tuần
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfWeek(int dayOfWeek)
        {
            _cronExp.BuildDayOfWeek(dayOfWeek.ToString());
            return this;
        }

        /// <summary>
        /// build khoảng ngày trong tuần
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfWeek(int from, int to)
        {
            _cronExp.BuildDayOfWeek(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các ngày trong tuần
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfWeek(List<int> listValue)
        {
            _cronExp.BuildDayOfWeek(BuildListvalue(listValue));
            return this;
        }

        /// <summary>
        /// build ngày trong tháng
        /// </summary>
        /// <param name="dayOfMonth"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfMonth(int dayOfMonth)
        {
            _cronExp.BuildDayOfMonth(dayOfMonth.ToString());
            return this;
        }

        /// <summary>
        /// build khoảng ngày trong tháng
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfMonth(int from, int to)
        {
            _cronExp.BuildDayOfMonth(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các ngày trong tháng
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfMonth(List<int> listValue)
        {
            _cronExp.BuildDayOfMonth(BuildListvalue(listValue));
            return this;
        }


        /// <summary>
        /// build tháng
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMonth(int month)
        {
            _cronExp.BuildDayOfMonth(month.ToString());
            return this;
        }
        /// <summary>
        /// build khoảng tháng
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMonth(int from, int to)
        {
            _cronExp.BuildMonth(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các tháng
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMonth(List<int> listValue)
        {
            _cronExp.BuildMonth(BuildListvalue(listValue));
            return this;
        }
        /// <summary>
        /// build năm
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildYear(int year)
        {
            _cronExp.BuildYear(year.ToString());
            return this;
        }

        /// <summary>
        /// build khoảng năm
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildYear(int from, int to)
        {
            _cronExp.BuildYear(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các năm
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildYear(List<int> listValue)
        {
            _cronExp.BuildYear(BuildListvalue(listValue));
            return this;
        }

        /// <summary>
        /// build giờ
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildHour(int hour)
        {
            _cronExp.BuildHour(hour.ToString());
            return this;
        }

        /// <summary>
        /// build khoảng giờ
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildHour(int from, int to)
        {
            _cronExp.BuildHour(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các giờ
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildHour(List<int> listValue)
        {
            _cronExp.BuildHour(BuildListvalue(listValue));
            return this;
        }

        /// <summary>
        /// build phút
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMinute(int minute)
        {
            _cronExp.BuildMinute(minute.ToString());
            return this;
        }

        /// <summary>
        /// build khoảng phút
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMinute(int from, int to)
        {
            _cronExp.BuildMinute(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các phút
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMinute(List<int> listValue)
        {
            _cronExp.BuildMinute(BuildListvalue(listValue));
            return this;
        }

        /// <summary>
        /// build giây
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildSecond(int second)
        {
            _cronExp.BuildSecond(second.ToString());
            return this;
        }

        /// <summary>
        /// build khoảng giây
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildSecond(int from, int to)
        {
            _cronExp.BuildSecond(BuildRangeValue(from, to));
            return this;
        }

        /// <summary>
        /// build list các giây
        /// </summary>
        /// <param name="listValue"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildSecond(List<int> listValue)
        {
            _cronExp.BuildSecond(BuildListvalue(listValue));
            return this;
        }
        /// <summary>
        /// cấu hình biểu thức chạy hàng ngày
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetDaily()
        {
            _cronExp.BuildDayOfMonth(_allValue);
            return this;
        }

        /// <summary>
        /// cấu hình biểu thức chạy hàng tháng
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetMonthly()
        {
            _cronExp.BuildMonth(_allValue);
            return this;
        }

        /// <summary>
        /// cấu hình biểu thức chạy hàng năm
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetYearly()
        {
            _cronExp.BuildYear(_allValue);
            return this;
        }

        /// <summary>
        /// cấu hình biểu thức chạy hàng tuần
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetWeekly()
        {
            _cronExp.BuildDayOfWeek(_allValue);
            return this;
        }

        /// <summary>
        /// cấu hình tần suất chạy
        /// </summary>
        /// <param name="frequently"></param>
        /// <returns></returns>
        public CronExpressionBuilder SetFrequently(int frequently) 
        {
            switch (frequently)
            {
                case (int)EnumCronFrequently.Daily:
                    return SetDaily();
                case (int)EnumCronFrequently.Weekly:
                    return SetWeekly();
                case (int)EnumCronFrequently.Monthly:
                    return SetMonthly();
                case (int)EnumCronFrequently.Yearly:
                    return SetYearly();
            }
            return this;
        }

        /// <summary>
        /// cấu hình biểu thức chạy vào ngày cuối cùng của tháng
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetEndOfMonth()
        {
            _cronExp.BuildDayOfMonth(_endOfMonthValue);
            return this;
        }

        /// <summary>
        /// dựng thời điểm bắt đầu chạy, thời điểm kết thúc chạy
        /// </summary>
        /// <param name="start">ngày bắt đầu chạy</param>
        /// <param name="end">ngày kết thúc chạy</param>
        /// <returns></returns>
        public CronExpressionBuilder SetStartTimeAndEndtime(DateTime start, DateTime end)
        {
            BuildDayOfMonth(start.Day, end.Day);
            BuildMonth(start.Month, end.Month);
            BuildYear(start.Year, end.Year);
            return this;
        }

        /// <summary>
        /// lấy ra model kết quả
        /// </summary>
        /// <returns></returns>
        public CronExpressionModel GetResult()
        {
            return _cronExp;
        }
    }
}
