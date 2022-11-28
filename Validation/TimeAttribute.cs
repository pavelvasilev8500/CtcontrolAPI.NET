using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CtcontrolAPIService.Validation
{
    public class TimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var regex = new Regex("(2[0-4]|1[0-9]|0[0-9]):(6[0]|[0-5][0-9]):(6[0]|[0-5][0-9])");
            if(value is string Time)
            {
                if (regex.IsMatch(Time))
                    return true;
                else
                    ErrorMessage = "Unacceptable time format";
            }
            return false;
        }
    }
}
