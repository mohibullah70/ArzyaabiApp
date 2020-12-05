using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZKARAPP.Helpers
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        public RequiredIfAttribute(string dependentProperty, object dependentValue)
        {
            DependentProperty = dependentProperty;
            DependentValue = dependentValue;
        }

        private string DependentProperty { get; set; }
        Object DependentValue { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objectType = validationContext.ObjectType;

            var dependentProperty = objectType.GetProperty(DependentProperty);
            var dependentType = dependentProperty.PropertyType;
            var dependentValue = dependentProperty.GetValue(validationContext.ObjectInstance, null);


            var memberName = validationContext.MemberName;
            var validateeProperty = objectType.GetProperty(memberName);
            var validateeType = validateeProperty.PropertyType;
            var validatee = validateeProperty.GetValue(validationContext.ObjectInstance, null);

            if (dependentValue.ToString().Trim() == DependentValue.ToString())
            {
                if (validateeType == typeof(int) || validateeType == typeof(int?))
                {
                    if (validatee == null || int.Parse(validatee.ToString()) == 0)
                    {
                        goto ErrorMessage;
                    }
                }
                if (validateeType == typeof(string))
                {
                    if (validatee == null)
                    {
                        goto ErrorMessage;
                    }
                }
            }

            return ValidationResult.Success;

        ErrorMessage:
            {
                var displayName = validateeProperty.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;
                var displayName2 = dependentProperty.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;

                return new ValidationResult(string.Format("{0} is required if {1} is entered.", displayName == null ? validateeProperty.Name : displayName.GetName(), displayName2 == null ? dependentProperty.Name : displayName2.GetName()));
            }



        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRule(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessageString,
                ValidationType = "requiredif",
            };
            rule.ValidationParameters["dependentproperty"] = (context as ViewContext).ViewData.TemplateInfo.GetFullHtmlFieldId(DependentProperty);
            rule.ValidationParameters["dependentvalue"] = DependentValue is bool ? DependentValue.ToString().ToLower() : DependentValue;

            yield return rule;
        }
    }
}