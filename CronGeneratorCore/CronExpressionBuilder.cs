﻿using CronGeneratorCore.Enum;
using CronGeneratorCore.Model;

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
        /// cron value dùng vào ngày cuối cùng của tháng
        /// vd các ngày 29,30,31 không phải tháng nào cũng có, 
        /// nên phải dùng kèm cú pháp này để thay thế bằng ngày cuối cùng của tháng
        /// cú pháp build ra với ô tháng sẽ là 30|L
        /// </summary>
        private const string _endOfMonthOptionValue = "|L";

        /// <summary>
        /// các ngày không phải tháng nào cũng có
        /// </summary>
        private readonly int[] _dayNotInAllMonth = { 29, 30, 31 };

        /// <summary>
        /// format postgresql datetime
        /// </summary>
        private const string _dateTimeFormat = "yyyy-MM-dd";

        /// <summary>
        /// ngày bắt đầu
        /// </summary>
        private DateTime? _startTime;

        /// <summary>
        /// ngày kết thúc
        /// </summary>
        private DateTime? _endTime;

        /// <summary>
        /// build khoảng (range)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private string BuildRangeValue(int from, int to)
        {
            if (from == to)
            {
                return from.ToString();
            }
            if (from < to)
            {
                return $"{from}-{to}";
            }
            else
            {
                return $"{to}-{from}";
            }
        }

        /// <summary>
        /// build danh sách các giá trị thỏa mãn
        /// </summary>s
        /// <param name="listValue"></param>
        /// <returns></returns>
        private string BuildListvalue(List<int> listValue)
        {
            return string.Join(",", listValue.Where(x => x > 0).Distinct().ToList());
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
        /// thì mỗi tháng sẽ chạy job vào ngày của fromdate, nếu không có ngày của fromdate thì mặc định lấy ngày cuối cùng của tháng ở tháng đó
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetMonthly(int? dayOfTheMonth = null)
        {
            _cronExp.BuildMonth(_allValue);

            int? targetDay;
            if (dayOfTheMonth.HasValue)
            {
                targetDay = dayOfTheMonth.Value;
            }
            else if (_startTime.HasValue)
            {
                targetDay = _startTime.Value.Day;
            }
            else
            {
                throw new NotImplementedException($"Chưa cấu hình {nameof(_startTime)}");
            }

            if (targetDay.HasValue)
            {
                string dayOfMonthCron;
                // nếu ngày trong tháng rơi vào các trường hợp 29,30,31 thì mới phải custom
                // các trường hợp còn lại tháng nào cũng có
                if (_dayNotInAllMonth.Contains(targetDay.Value))
                {
                    dayOfMonthCron = targetDay.Value.ToString() + _endOfMonthOptionValue;
                }
                else
                {
                    dayOfMonthCron = targetDay.Value.ToString();
                }
                _cronExp.BuildDayOfMonth(dayOfMonthCron);
            }

            return this;
        }

        /// <summary>
        /// cấu hình biểu thức chạy hàng tuần
        /// thì mỗi tuần sẽ chạy vào thứ ứng với thứ của ngày fromdate
        /// </summary>
        /// <returns></returns>
        public CronExpressionBuilder SetWeekly(int? dayOfTheWeek = null)
        {
            if (dayOfTheWeek.HasValue)
            {
                _cronExp.BuildDayOfWeek(dayOfTheWeek.Value.ToString());
            }
            else
            {
                if (_startTime.HasValue)
                {
                    _cronExp.BuildDayOfWeek(((int)(_startTime.Value.DayOfWeek)).ToString());
                }
                else
                {
                    throw new NotImplementedException($"Chưa cấu hình {nameof(_startTime)}");
                }
            }
            return this;
        }

        /// <summary>
        /// build theo tần suất
        /// </summary>
        /// <param name="frequently">tần suất</param>
        /// <seealso cref="EnumCronFrequently"/>
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
            }
            throw new NotImplementedException($"Chưa cấu hình EnumCronFrequently: {frequently}");
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
            _startTime = start;
            _endTime = end;

            _cronExp.BuildStartTime(start.ToString(_dateTimeFormat));
            _cronExp.BuildEndTime(end.ToString(_dateTimeFormat));
            return this;
        }

        /// <summary>
        /// cấu hình ngày bắt đầu
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public CronExpressionBuilder SetStartTime(DateTime start)
        {
            _startTime = start;
            _cronExp.BuildStartTime(start.ToString(_dateTimeFormat));
            return this;
        }

        /// <summary>
        /// cấu hình ngày kết thúc
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public CronExpressionBuilder SetEndTime(DateTime end)
        {
            _endTime = end;
            _cronExp.BuildEndTime(end.ToString(_dateTimeFormat));
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
