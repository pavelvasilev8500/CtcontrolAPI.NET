using System.ComponentModel.DataAnnotations;

namespace CtcontrolAPIService.Validation
{
    public class StatusAttribute : ValidationAttribute
    {
        private List<string> _status = new List<string>();

        public StatusAttribute()
        {
            _status.Add("active");
            _status.Add("shutdown");
            _status.Add("sleep");
            _status.Add("reset");
        }

        public override bool IsValid(object? value)
        {
            if(value is string Status)
            {
                foreach(var status in _status) 
                {
                    if (Status == status)
                        return true;
                    else
                        ErrorMessage = "Unsypportet type";
                }
            }
            return false;
        }
    }
}
