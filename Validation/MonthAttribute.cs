using MongoDB.Driver.Core.Operations;
using System.ComponentModel.DataAnnotations;

namespace CtcontrolAPIService.Validation
{
    public class MonthAttribute : ValidationAttribute
    {
        private List<string> _month = new List<string>();
        public MonthAttribute()
        {
            _month.Add("Январь");
            _month.Add("январь");
            _month.Add("Февраль");
            _month.Add("февраль");
            _month.Add("Март");
            _month.Add("март");
            _month.Add("Апрель");
            _month.Add("апрель");
            _month.Add("Май");
            _month.Add("май");
            _month.Add("Июнь");
            _month.Add("июнь");
            _month.Add("Июль");
            _month.Add("июль");
            _month.Add("Август");
            _month.Add("август");
            _month.Add("Сентябрь");
            _month.Add("сентябрь");
            _month.Add("Октябрь");
            _month.Add("октябрь");
            _month.Add("Ноябрь");
            _month.Add("ноябрь");
            _month.Add("Декабрь");
            _month.Add("декабрь");
            _month.Add("January");
            _month.Add("january");
            _month.Add("February");
            _month.Add("february");
            _month.Add("March");
            _month.Add("march");
            _month.Add("April");
            _month.Add("april");
            _month.Add("May");
            _month.Add("may");
            _month.Add("June");
            _month.Add("june");
            _month.Add("July");
            _month.Add("july");
            _month.Add("August");
            _month.Add("august");
            _month.Add("September");
            _month.Add("september");
            _month.Add("October");
            _month.Add("october");
            _month.Add("November");
            _month.Add("november");
            _month.Add("December");
            _month.Add("december");
        }
        public override bool IsValid(object? value)
        {
            if(value is string Month)
            {
                foreach(var month in _month)
                {
                    if(Month == month) 
                        return true;
                    else
                        ErrorMessage = "Unacceptable month";
                }
            }
            return false;
        }
    }
}
