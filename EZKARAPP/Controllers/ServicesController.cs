﻿using EZKARAPP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZKARAPP.Controllers
{
    public class ServicesController : Controller
    {
        private DBEntities db;
        public ServicesController()
        {
            db = new DBEntities();
        }

    }
}