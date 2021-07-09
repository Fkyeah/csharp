using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Third_Homework.Model.Validation
{
    public class LoginValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^[A-Za-z][a-zA-Z0-9-_\.]{1,19}$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value.ToString();
            if (regex.IsMatch(login)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Логин может состоять из цифр и букв с ограничением в 2-20 символов. Первый символ - буква!");

        }
    }
}
