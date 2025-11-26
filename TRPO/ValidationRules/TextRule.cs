using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO.ValidationRules
{
    class TextRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!Regex.IsMatch(input, @"\p{IsCyrillic}"))
            {
                return new ValidationResult(false, "Поле должно состоять только из Рус. букв");
            }
            return ValidationResult.ValidResult;
        }
    }
}
