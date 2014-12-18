using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExtendedSharp.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NationalCodeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ErrorMessageString);
            var val = Convert.ToString(value);
            return IsNationalCode(val) ? ValidationResult.Success : new ValidationResult(ErrorMessageString);
        }

        protected static bool IsNationalCode(string nationalCode)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(nationalCode, @"^(?!(\d)\1{9})\d{10}$"))
                return false;
            var check = Convert.ToInt32(nationalCode.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
                .Sum() % 11;
            var isValidCode = sum < 2 && check == sum || sum >= 2 && check + sum == 11;
            if (!isValidCode) return false;
            Int64 code;
            return Int64.TryParse(nationalCode, out code);
        }
    }
}
