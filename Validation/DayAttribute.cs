using MongoDB.Driver.Core.Operations;
using System.ComponentModel.DataAnnotations;

namespace CtcontrolAPIService.Validation
{
    public class DayAttribute : ValidationAttribute
    {
        private List<string> _days = new List<string>();
        public DayAttribute()
        {
            _days.Add("Понедельник");
            _days.Add("понедельник");
            _days.Add("Вторник");
            _days.Add("вторник");
            _days.Add("Среда");
            _days.Add("среда");
            _days.Add("Четверг");
            _days.Add("четверг");
            _days.Add("Пятница");
            _days.Add("пятница");
            _days.Add("Суббота");
            _days.Add("суббота");
            _days.Add("Воскресенье");
            _days.Add("воскресенье");
            _days.Add("Monday");
            _days.Add("monday");
            _days.Add("Tuesday");
            _days.Add("tuesday");
            _days.Add("Wednesday");
            _days.Add("wednesday");
            _days.Add("Thursday");
            _days.Add("thursday");
            _days.Add("Friday");
            _days.Add("friday");
            _days.Add("Saturday");
            _days.Add("saturday");
            _days.Add("Sunday");
            _days.Add("sunday");
        }
        public override bool IsValid(object? value)
        {
            if(value is string Day)
            {
                foreach(var day in _days)
                {
                    if(Day == day) 
                        return true;
                    else
                        ErrorMessage = "Unacceptable day";
                }
            }
            return false;
        }
    }
}
