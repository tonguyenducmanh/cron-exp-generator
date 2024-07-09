using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronGeneratorCore.Model
{
    /// <summary>
    /// Model lưu trữ các thông tin từ giây tới năm của 1 biểu thức
    /// -- cron_expression: tuân thủ biểu thức sau:
    /// -- * * * * * * *
    /// -- | | | | | | |
    /// -- | | | | | | +-- Năm (khoảng: 1900-3000)
    /// -- | | | | | +---- Ngày trong tuần (khoảng: 1-7, 1 = Chủ nhật)
    /// -- | | | | +------ Tháng (khoảng: 1-12)
    /// -- | | | +-------- Ngày trong tháng (khoảng: 1-31)
    /// -- | | +---------- Giờ (khoảng: 0-23)
    /// -- | +------------ Phút (khoảng: 0-59)
    /// -- +-------------- Giây (khoảng: 0-59)
    /// </summary>
    public class CronExpressionModel
    {
        private const string _allValue = "*";

        /// <summary>
        /// Giây
        /// </summary>
        private string _second { get; set; } = _allValue;

        /// <summary>
        /// Phút
        /// </summary>
        private string _minute { get; set; } = _allValue;

        /// <summary>
        /// Giờ
        /// </summary>
        private string _hour { get; set; } = _allValue;

        /// <summary>
        /// Ngày trong tháng
        /// </summary>
        private string _dayOfTheMonth { get; set; } = _allValue;

        /// <summary>
        /// Tháng
        /// </summary>
        private string _month { get; set; } = _allValue;

        /// <summary>
        /// Ngày trong tuần
        /// </summary>
        private string _dayOfTheWeek { get; set; } = _allValue;

        /// <summary>
        /// Năm
        /// </summary>
        private string _year { get; set; } = _allValue;

        /// <summary>
        /// build ra kết quả cuối cùng
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{_second} {_minute} {_hour} {_dayOfTheMonth} {_month} {_dayOfTheWeek} {_year}";
        }

        /// <summary>
        /// build ngày trong tuần
        /// </summary>
        /// <param name="dayOfWeek"></param>
        public void BuildDayOfWeek(string dayOfWeek)
        {
            _dayOfTheWeek = dayOfWeek;
        }

        /// <summary>
        /// build ngày trong tháng
        /// </summary>
        /// <param name="dayOfMonth"></param>
        public void BuildDayOfMonth(string dayOfMonth)
        {
            _dayOfTheMonth = dayOfMonth;
        }

        /// <summary>
        /// build năm
        /// </summary>
        /// <param name="year"></param>
        public void BuildYear(string year)
        {
            _year = year;
        }

        /// <summary>
        /// build giờ
        /// </summary>
        /// <param name="hour"></param>
        public void BuildHour(string hour)
        {
            _hour = hour;
        }

        /// <summary>
        /// build phút
        /// </summary>
        /// <param name="minute"></param>
        public void BuildMinute(string minute)
        {
            _minute = minute;
        }

        /// <summary>
        /// build giây
        /// </summary>
        /// <param name="second"></param>
        public void BuildSecond(string second)
        {
            _second = second;
        }
    }
}
