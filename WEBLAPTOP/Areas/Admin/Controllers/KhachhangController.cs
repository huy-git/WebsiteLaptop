using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;
namespace WEBLAPTOP.Areas.Admin.Controllers
{
    public class KhachhangController : Controller
    {
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        // GET: Admin/Khachhang
        public ActionResult Khachhang()
        {
            var khachhangs = db.Khachhangs.ToList();
            return View(khachhangs);
        }
        public JsonResult GetKhachhang()
        {
            QUANLILAPTOPEntities entities = new QUANLILAPTOPEntities();
            return Json(entities.Khachhangs);
        }
        public ActionResult create(Khachhang kh)
        {
            try
            {
                db.Khachhangs.Add(kh);
                db.SaveChanges();
                return Json(new { message = "đã thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { errorMessage = "tạo thông tin thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get(string maKH)
        {
            var rs = db.Khachhangs.Where(x => x.maKH == maKH).Select(x => new { maKh = x.maKH, tenKH = x.tenKH, Diachi = x.Diachi, SDT=x.SDT }).SingleOrDefault();
            return Json(new { dt = rs }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult edit(Khachhang kh)
        {
            db.Entry(kh).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult delete(string makh)
        {
            Khachhang kh = db.Khachhangs.Find(makh);
            db.Khachhangs.Remove(kh);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
