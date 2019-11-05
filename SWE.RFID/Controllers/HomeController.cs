﻿using SWE.RFID.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWE.RFID.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}