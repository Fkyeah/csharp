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
    public class PasswordValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^(?=.{4,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value.ToString();
            if (regex.IsMatch(password)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Пароль должен содержать:\nХотя бы одно число\nХотя бы одну латинскую букву в верхнем и нижнем регистре\nСтрока не менее 4 символов");
        }
    }
}
