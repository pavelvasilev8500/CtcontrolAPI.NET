using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CtcontrolAPIService.Validation
{
    public class ComputerTypeAttribute : ValidationAttribute
    {
        private List<string> _type = new List<string>();

        public ComputerTypeAttribute()
        {
            _type.Add("Laptop");
            _type.Add("laptop");
            _type.Add("pc");
            _type.Add("Pc");
            _type.Add("PC");
        }

        public override bool IsValid(object? value)
        {
            if(value is string Type)
            {
                foreach(var type in _type)
                {
                    if (Type == type)
                        return true;
                    else
                        ErrorMessage = "Unacceptable type of pc";
                }
            }
            return false;
        }
    }
}
