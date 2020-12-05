using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKARAPP.Helpers
{
    public class RequiredIntAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objectType = validationContext.ObjectType;

            var memberName = validationContext.MemberName;
            var validateeProperty = objectType.GetProperty(memberName);
            var validateeType = validateeProperty.PropertyType;
            var validatee = validateeProperty.GetValue(validationContext.ObjectInstance, null);


            if (validatee == null || int.Parse(validatee.ToString()) <= 0)
            {
                goto ErrorMessage;
            }

            return ValidationResult.Success;

        ErrorMessage:
            {
                var displayName = validateeProperty.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;

                return new ValidationResult(string.Format("{0} is required.", displayName == null ? validateeProperty.Name : displayName.GetName()));
            }
        }
    }
}
