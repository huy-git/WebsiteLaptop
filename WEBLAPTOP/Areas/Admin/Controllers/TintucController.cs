using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;
namespace WEBLAPTOP.Areas.Admin.Controllers
{
    public class TintucController : Controller
    {
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        // GET: Admin/Tintuc
        public ActionResult Tintuc()
        {
            var tintuc = db.tintucs.ToList();
            return View(tintuc);
        }
        public JsonResult Gettintuc()
        {
            QUANLILAPTOPEntities entities = new QUANLILAPTOPEntities();
            return Json(entities.tintucs);
        }
        public ActionResult create(tintuc tt)
        {
            try
            {
                db.tintucs.Add(tt);
                db.SaveChanges();
                return Json(new { message = "đã thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { errorMessage = "tạo thông tin thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult get(string maTT)
        {
            var rs = db.tintucs.Where(x => x.maLoaiTT == maTT).Select(x => new { maNV = x.maNV, tieude = x.tieude, nguoidang = x.nguoidang,
           ngaydang=x.ngaydang,noidung=x.noidung,noidungCT=x.noidungCT}).SingleOrDefault();
            return Json(new { dt = rs }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult edit(tintuc tt)
        {
            db.Entry(tt).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult delete(string maTT)
        {
            tintuc tt = db.tintucs.Find(maTT);
            db.tintucs.Remove(tt);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}