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
        /// lấy ra giá trị hoặc giá trị *
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        private string GetvalueOrDefault(int? inputValue)
        {
            return inputValue.HasValue ? inputValue.Value.ToString() : _allValue;
        }

        /// <summary>
        /// build thứ trong tuần
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfWeek(int? dayOfWeek)
        {
            _cronExp.BuildDayOfWeek(GetvalueOrDefault(dayOfWeek));
            return this;
        }

        /// <summary>
        /// build ngày trong tháng
        /// </summary>
        /// <param name="dayOfMonth"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildDayOfMonth(int? dayOfMonth)
        {
            _cronExp.BuildDayOfMonth(GetvalueOrDefault(dayOfMonth));
            return this;
        }

        /// <summary>
        /// build tháng
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMonth(int? month)
        {
            _cronExp.BuildDayOfMonth(GetvalueOrDefault(month));
            return this;
        }

        /// <summary>
        /// build năm
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildYear(int? year)
        {
            _cronExp.BuildYear(GetvalueOrDefault(year));
            return this;
        }

        /// <summary>
        /// build giờ
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildHour(int? hour)
        {
            _cronExp.BuildHour(GetvalueOrDefault(hour));
            return this;
        }

        /// <summary>
        /// build phút
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildMinute(int? minute) 
        {
            _cronExp.BuildMinute(GetvalueOrDefault(minute));
            return this;
        }

        /// <summary>
        /// build giây
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public CronExpressionBuilder BuildSecond(int? second) 
        {
            _cronExp.BuildSecond(GetvalueOrDefault(second));
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
        /// lấy ra model kết quả
        /// </summary>
        /// <returns></returns>
        public CronExpressionModel GetResult()
        {
            return _cronExp;
        }
    }
}
