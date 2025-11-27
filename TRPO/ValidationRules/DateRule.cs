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
            var input = (value ?? "").ToString();
            if (!DateTime.TryParse(input, out DateTime dateValue))
            {
                return new ValidationResult(false, "Неверный формат даты");
            }
            if (dateValue < DateTime.Today)
            {
                return new ValidationResult(false, "Дата не может быть раньше");
            }

            return ValidationResult.ValidResult;
        }
    }
}
