using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZKARAPP.Helpers
{
    /// <summary>  
    /// Allow file size attribute class  
    /// </summary>  
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MaxFileSizeAttribute : ValidationAttribute
    {

        public MaxFileSizeAttribute(int fileSize)
        {
            this.FileSize = fileSize;
        }

        #region Public / Protected Properties  

        /// <summary>  
        /// Gets or sets file size property. Default is 2MB (the value is in Bytes).  
        /// </summary>  
        public int FileSize { get; set; } = 2 * 1024 * 1024;

        #endregion

        #region Is valid method  

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Initialization  
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;

            // Settings.  
            int allowedFileSize = this.FileSize;

            // Verification.  
            if (file != null)
            {
                // Initialization.  
                var fileSize = file.ContentLength;

                // Settings.  
                isValid = fileSize <= allowedFileSize;
            }

            // Info  
            if (isValid)
            {
                //return isValid;
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} size must be less than {FileSize} Bytes.");

        }
        #endregion
    }
}