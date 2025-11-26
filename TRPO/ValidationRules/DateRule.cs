using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO.ValidationRules
{
    class DateRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime < DateTime.Now) 
                {
                    return new ValidationResult(false, "Дата создания не может быть в прошлом");
                }
                if (dateTime > DateTime.Now.AddDays(1))
                {
                    return new ValidationResult(false, "Дата создания не может быть в будущем");
                }

                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Неверный формат даты");
        }
    }
}
