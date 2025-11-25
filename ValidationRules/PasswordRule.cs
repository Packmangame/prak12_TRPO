using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace prak12.ValidationRules
{
    internal class PasswordRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 6)
            {
                return new ValidationResult(false, "Пароль должен содержать не менее 6 символов");
            }
            if (!input.Any(char.IsUpper))
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну заглавную букву");
            }

            return ValidationResult.ValidResult;
        }
    }
}
