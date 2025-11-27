using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TRPO.Data;

namespace TRPO.ValidationRules
{
    class EmailRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Email не может быть пустым");
            }

            if (!input.Contains("@"))
            {
                return new ValidationResult(false, "Email должен содержать символ @");
            }

            
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(input))
            {
                return new ValidationResult(false, "Неверный формат email");
            }

           
            using (var context = new AppDbContext())
            {
                if (context.Users.Any(u => u.Email.ToLower() == input.ToLower()))
                {
                    return new ValidationResult(false, "Email уже используется другим пользователем");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
