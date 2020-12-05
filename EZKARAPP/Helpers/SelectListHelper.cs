    using EZKARAPP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EZKARAPP.Helpers
{
    public class SelectListHelper
    {
        protected DBEntities db;
        public SelectListHelper(DBEntities db)
        {
            this.db = db;
        }


        ///// <summary>
        /////  Get all gender types
        ///// </summary>
        ///// <param name="selectedValue"></param>
        ///// <param name="includeAll">include string (ALL)</param>
        ///// <param name="includeUnkown">include (Not Selected Value or Unknown), by default not included</param>
        ///// <returns>SelectList</returns>
        //public SelectList Genders(int selectedValue = 0, bool includeAll = false, bool includeUnkown=false)
        //{
        //    var genders = from g in db.zGenders
        //                  select g;

        //    if(!includeUnkown)
        //    {
        //       genders= genders.Where(a => a.Flag); 
        //    }

        //    SelectList items = new SelectList(genders.Select(a => new
        //    {
        //        id = a.GenderId,
        //        text = a.Gender
        //    }).OrderBy(a => a.text), "id", "text");

        //    if(includeAll)
        //    {
        //        return _AddAllItemToList(items, selectedValue);
        //    }
        //    return _AddEmptyItemToList(items, selectedValue);
        //}



        #region Empty
        public SelectList Empty()
        {
            return _AddEmptyItemToList(new SelectList(Enumerable.Empty<SelectListItem>()), 0);
        }
        #endregion

        #region _Helpers

        protected SelectList _AddAllItemToList(SelectList origList, int selectedValue = 0, SelectListItem firstItem = null)
        {
            List<SelectListItem> newList = origList.ToList();
            newList.Insert(0, firstItem ?? new SelectListItem { Value = "0", Text = "ALL" });
            return new SelectList(newList, "Value", "Text", selectedValue);
            //var selectedItem = newList.FirstOrDefault(item => item.Selected);
            //var selectedItemValue = String.Empty;
            //if (selectedItem != null)
            //{
            //    selectedItemValue = selectedItem.Value;
            //}

            //return new SelectList(newList, "Value", "Text", selectedItemValue);
        }

        protected SelectList _AddEmptyItemToList(SelectList origList, int selectedValue = 0, SelectListItem firstItem = null)
        {
            List<SelectListItem> newList = origList.ToList();
            newList.Insert(0, firstItem ?? new SelectListItem { Value = "", Text = "select an option" });
            return new SelectList(newList, "Value", "Text", selectedValue);
            //var selectedItem = newList.FirstOrDefault(item => item.Selected);
            //var selectedItemValue = String.Empty;
            //if (selectedItem != null)
            //{
            //    selectedItemValue = selectedItem.Value;
            //}

            //return new SelectList(newList, "Value", "Text", selectedItemValue);
        }

        protected SelectList _AddEmptyItemToList(SelectList origList, string selectedValue = null, SelectListItem firstItem = null)
        {
            List<SelectListItem> newList = origList.ToList();
            newList.Insert(0, firstItem ?? new SelectListItem { Value = "", Text = "select an option" });
            return new SelectList(newList, "Value", "Text", selectedValue);
        }

        protected MultiSelectList _AddEmptyItemToList(SelectList origList, int[] selectedValues, SelectListItem firstItem = null)
        {
            List<SelectListItem> newList = origList.ToList();
            newList.Insert(0, firstItem ?? new SelectListItem { Value = "", Text = "select an option" });
            return new MultiSelectList(newList, "Value", "Text", selectedValues);
            //var selectedItem = newList.FirstOrDefault(item => item.Selected);
            //var selectedItemValue = String.Empty;
            //if (selectedItem != null)
            //{
            //    selectedItemValue = selectedItem.Value;
            //}

            //return new SelectList(newList, "Value", "Text", selectedItemValue);
        }

        #endregion

    }
}