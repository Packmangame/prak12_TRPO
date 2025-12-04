using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO.ValidationRules
{
    public class PhoneRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length != 11 || input[0] != '7')
            {
                return new ValidationResult(false, "Номер должен иметь вид 7 ### ### ## ##");
            }
            return ValidationResult.ValidResult;
        }
    }
}
