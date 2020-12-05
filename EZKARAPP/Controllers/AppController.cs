using EZKARAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZKARAPP.Controllers
{
    public abstract class AppController : Controller
    {
        protected DBEntities db = new DBEntities();
       
        public void SweetAlert(string message, SweetAlertType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            TempData["notification"] = msg;
        }
    }
}