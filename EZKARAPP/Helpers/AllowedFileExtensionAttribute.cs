using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZKARAPP.Helpers
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowedFileExtensionAttribute : ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public AllowedFileExtensionAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;

            if (file != null)
            {
                var fileName = file.FileName;

                isValid = AllowedExtensions.Any(y => fileName.EndsWith(y));
            }

            if(isValid)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} must be of type of {string.Join(",",AllowedExtensions)}.");

        }
    }
}