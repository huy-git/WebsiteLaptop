using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;

namespace WEBLAPTOP.Areas.Admin.Controllers
{
    public class NhanvienController : Controller
    {
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        // GET: Admin/Nhanvien
        public ActionResult Nhanvien()
        {
            var nhanviens = db.Nhanviens.ToList();
            return View(nhanviens);
        }
        public JsonResult GetNhanvien()
        {
            QUANLILAPTOPEntities entities = new QUANLILAPTOPEntities();
            return Json(entities.Nhanviens);
        }
        public ActionResult create(Nhanvien nv)
        {
            try
            {
                db.Nhanviens.Add(nv);
                db.SaveChanges();
                return Json(new { message = "đã thêm thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { errorMessage = "tạo thông tin thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult create(string tenNV, string Chucvu)
        //{
        //    Guid getid = Guid.NewGuid();
        //    string id = getid.ToString();
        //    List<Nhanvien> nv = (List<Nhanvien>)Session["Nhanvien"];
        //    string sql = string.Format("insert into Nhanvien(maNV,tenNV,Chucvu)  values('{0}','{1}','{2}')", id, tenNV, Chucvu);
        //    QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        //    var kq = db.Database.ExecuteSqlCommand(sql);
        //    return Json(new { message = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult get(string maNV)
        {
            var rs = db.Nhanviens.Where(x => x.maNV == maNV).Select(x => new { maNV = x.maNV, tenNV = x.tenNV, Chucvu = x.Chucvu }).SingleOrDefault();
            return Json(new {dt=rs }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult edit(Nhanvien nv)
        {
            db.Entry(nv).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult delete(string maNV)
        {
            Nhanvien nv = db.Nhanviens.Find(maNV);
            db.Nhanviens.Remove(nv);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}