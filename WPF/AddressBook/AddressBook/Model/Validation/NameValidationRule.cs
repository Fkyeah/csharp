using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AddressBook.Model.Validation
{
    class NameValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^[A-Za-zА-Яа-я]{2,50}$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value.ToString();
            if (regex.IsMatch(login)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Имя и фамилия могут состоять из букв с ограничением в 2-50 символов.\nПервый символ должен начинаться с буквы");
        }
    }
}
