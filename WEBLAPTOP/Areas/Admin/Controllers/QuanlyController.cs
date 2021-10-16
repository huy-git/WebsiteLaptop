using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;
namespace WEBLAPTOP.Areas.Admin.Controllers
{
    public class QuanlyController : Controller
    {
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        // GET: Admin/Quanly
        public ActionResult Quanly()
        {
            return View();
        }
    }
}