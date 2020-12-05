using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZKARAPP.Helpers
{
    public class InAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        public InAttribute(string[] allowableValues)
        {
            this.AllowableValues = allowableValues;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString(),StringComparer.OrdinalIgnoreCase) == true)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} must only contain {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}");

           /// var msg = $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            //return new ValidationResult(msg);
        }
    }
}