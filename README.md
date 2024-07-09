# project thực hiện build ra biểu thức cron expression dựa vào các tham số đầu vào cho trước

```
-- cron_expression: tuân thủ biểu thức sau:
-- * * * * * * *
-- | | | | | | |
-- | | | | | | +-- Year (range: 1900-3000)
-- | | | | | +---- Day of the week (range: 1-7, 1 = Sunday)
-- | | | | +------ Month (range: 1-12)
-- | | | +-------- Day of the month (range: 1-31)
-- | | +---------- Hour (range: 0-23)
-- | +------------ Minute (range: 0-59)
-- +-------------- Second (range: 0-59)
-- các logic hỗ trợ gồm:
---- * : toàn bộ giá trị phù hợp
---- giá trị cụ thể : vd 12
---- range giá trị: vd 1-5
---- list giá trị: vd 1,2,3
---- step value: vd */10 với * là phút thì lấy các phút chia hết cho 10
---- end of month: vd L với day_of_month thì lấy ngày cuối cùng của tháng
---- => lưu ý từ này chỉ dùng cho day of month
---- thứ tự ưu tiên ngày - năm giảm dần, các thứ tự ưu tiên giảm dần có thể bỏ

```

Cách sử dụng

```
CronExpressionModel cronExp = new CronExpressionBuilder()
                                .BuildHour(1)
                                .BuildDayOfWeek(new List<int>() { 1,2,3})
                                .BuildDayOfMonth(1,12)
                                .GetResult();
string cronExpression = cronExp.ToString();
```

hoặc

```
DateTime currentTime = DateTime.Now;
CronExpressionModel cronExp = new CronExpressionBuilder()
                                .SetStartTimeAndEndtime(currentTime.AddDays(-30), currentTime)
                                .GetResult();
string cronExpression = cronExp.ToString();
```
