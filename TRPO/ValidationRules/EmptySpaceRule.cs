using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO.ValidationRules
{
    class EmptySpaceRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = value?.ToString().Trim();
            if (value == null)
                return new ValidationResult(false, "Заполните поле");

            if (input.Length == 0)
                return new ValidationResult(false, "Заполните поле");

            return ValidationResult.ValidResult;
        }
    }
}
