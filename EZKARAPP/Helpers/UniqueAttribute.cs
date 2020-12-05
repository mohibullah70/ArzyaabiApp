using EZKARAPP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;

namespace EZKARAPP.Helpers
{
    public class UniqueAttribute : ValidationAttribute
    {
        public UniqueAttribute(Type tableType, string idProperty = null, bool isNullable = false, string[] noneClusterColumns = null, Type dataType = null, string message = null)
        {
            TableType = tableType;
            IdProperty = idProperty;
            IsNullable = isNullable;
            NoneClusterColumns = noneClusterColumns;
            IdDataType = dataType;
            Message = message;

            DataContext = new DBEntities();
        }
        //public UniqueAttribute(Type tableType, string message = null,bool isNullable =false)
        //{
        //    Message = message;
        //    TableType = tableType;
        //    DataContext = new DBEntities();

        //    IdDataType = typeof(int);

        //    IsNullable = isNullable;
        //}
        //public UniqueAttribute(Type tableType, string idProperty, string message = null, bool isNullable = false)
        //{
        //    IdProperty = idProperty;
        //    Message = message;
        //    TableType = tableType;
        //    DataContext = new DBEntities();

        //    IdDataType = typeof(int);

        //    IsNullable = isNullable;
        //}
        //public UniqueAttribute(Type tableType, string idProperty, string[] noneClusterColumns, string message = null, bool isNullable = false)
        //{
        //    IdProperty = idProperty;
        //    Message = message;
        //    TableType = tableType;
        //    NoneClusterColumns = noneClusterColumns;

        //    DataContext = new DBEntities();

        //    IdDataType = typeof(int);

        //    IsNullable = isNullable;
        //}

        //public UniqueAttribute(Type tableType, string idProperty, string[] noneClusterColumns, Type datatype, string message = null, bool isNullable = false)
        //{
        //    IdProperty = idProperty;
        //    Message = message;
        //    TableType = tableType;
        //    NoneClusterColumns = noneClusterColumns;

        //    DataContext = new DBEntities();

        //    IdDataType = datatype;

        //    IsNullable = isNullable;
        //}

        // [Ninject.Inject]
        public DBEntities DataContext { get; set; }
        private string IdProperty { get; set; }
        private string Message { get; set; }
        Type TableType { get; set; }
        Type IdDataType { get; set; }
        string[] NoneClusterColumns { get; set; }
        bool IsNullable { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var objectType = validationContext.ObjectType;

            var memberName = validationContext.MemberName;
            var validateeProperty = objectType.GetProperty(memberName);
            var validateeType = validateeProperty.PropertyType;
            var validatee = validateeProperty.GetValue(validationContext.ObjectInstance, null);

            //first check if IsNullable and value passed is null
            //so no need to check for uniqueness and  return true;
            if (validatee == null && IsNullable)
            {
                return ValidationResult.Success;
            }


            var table = DataContext.Set(TableType);

            IQueryable result;

            if (IdDataType == typeof(DateTime))
            {
                DateTime _datetime = Convert.ToDateTime(validatee.ToString());
                result = table.Where(validateeProperty.Name + "==@0", _datetime);
            }
            else
            {
                result = table.Where(validateeProperty.Name + "==@0", validatee);
            }

            if (NoneClusterColumns != null)
            {
                foreach (var item in NoneClusterColumns)
                {
                    var ncProperty = objectType.GetProperty(item);
                    var ncType = ncProperty.PropertyType;
                    var ncValue = ncProperty.GetValue(validationContext.ObjectInstance, null);

                    result = result.Where(item + "==@0", ncValue);
                }
            }

            int count = 0;


            if (IdProperty != null)
            {
                var idProperty = objectType.GetProperty(IdProperty);
                var idType = idProperty.PropertyType;
                var id = idProperty.GetValue(validationContext.ObjectInstance, null);
                if (idType == typeof(String))
                {
                    result = result.Where(IdProperty + "<>@0", id);
                }
                else
                {
                    if ((int)id > 0)
                    {
                        result = result.Where(IdProperty + "<>@0", id);
                    }
                }
            }


            count = result.Count();

            if (count == 0)
                return ValidationResult.Success;

            if (Message != null)
                return new ValidationResult(Message);

            var displayName = validateeProperty.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault() as DisplayAttribute;

            return new ValidationResult(string.Format("{0} must be unique", displayName != null ? displayName.GetName() : validateeProperty.Name));

        }
    }    
}