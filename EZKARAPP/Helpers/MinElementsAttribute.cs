using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZKARAPP.Helpers
{
    public class MinElementsAttribute : ValidationAttribute
    {
        public MinElementsAttribute(int minElements, string message = null)
        {
            this.minElements = minElements;
            this.message = message;
        }
        private readonly int minElements;
        private readonly string message;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList;

            var result = list ?.Count >= minElements;

            return result ? ValidationResult.Success : new ValidationResult($"{validationContext.DisplayName} requires at least {minElements} element" + (minElements > 1 ? "s" : string.Empty));

            

            //if (Message != null)
            //    return new ValidationResult(Message);

            //var displayName = validateeProperty.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
            //var vsdisplayName = vsProperty.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
            //if (displayName != null && vsdisplayName != null)
            //    return new ValidationResult(string.Format("{0} must be less than or equal {1}", displayName.GetName(), vsdisplayName.GetName()));

            //return new ValidationResult(string.Format("{0} must be less than or equal {1}", validateeProperty.Name, vsProperty.Name));

        }
    }
}
