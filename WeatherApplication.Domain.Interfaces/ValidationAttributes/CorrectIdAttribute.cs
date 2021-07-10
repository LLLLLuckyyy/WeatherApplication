using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Domain.Interfaces.ValidationAttributes
{
    public class CorrectIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var id = (int)value;
                if (id > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
