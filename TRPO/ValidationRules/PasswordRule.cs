using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO.ValidationRules
{
    internal class PasswordRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 8)
            {
                return new ValidationResult(false, "Пароль должен содержать не менее 8 символов");
            }
            if (!input.Any(char.IsDigit))
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну цифру");
            }
            if (!input.Any(char.IsLower))
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну строчную букву");
            }
            if (!input.Any(char.IsUpper))
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну заглавную букву");
            }
            if (!input.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы один специальный символ");
            }

            return ValidationResult.ValidResult;
        }
    }
}

