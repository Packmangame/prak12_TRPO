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
    class LoginRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 5)
            {
                return new ValidationResult(false, "Логин должен содержать не менее 5 символов");
            }

            // Проверка уникальности логина
            using (var context = new AppDbContext())
            {
                if (context.Users.Any(u => u.Login.ToLower() == input.ToLower()))
                {
                    return new ValidationResult(false, "Логин уже используется другим пользователем");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
