using HaberSistemi.Admin.CostumFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberSistemi.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [LoginFilter]//filter işlemi
        public ActionResult Index()
        {
            return View();
        }
    }
}