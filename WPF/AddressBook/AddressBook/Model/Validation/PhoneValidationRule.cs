using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AddressBook.Model.Validation
{
    class PhoneValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^[+][7]-[9][0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phoneNumber = value.ToString();
            if (regex.IsMatch(phoneNumber)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Номер телефона должен быть введен в формате: +7-xxx-xxx-xx-xx");
        }
    }
}
