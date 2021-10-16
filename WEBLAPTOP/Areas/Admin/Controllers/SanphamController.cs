using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;
namespace WEBLAPTOP.Areas.Admin.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Admin/Sanpham
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        // GET: Admin/Sanpham
        public ActionResult Sanpham()
        {
            // var sanphams = ;
            return View(db.Sanphams.ToList());
        }
        public JsonResult GetSanpham()
        {
            QUANLILAPTOPEntities entities = new QUANLILAPTOPEntities();

            return Json(entities.Sanphams);
        }

        [HttpPost]
        public ActionResult create(Sanpham sp)
        {
            //, HttpPostedFileBase file
            //try
            //{
            //    if (file != null)
            //    {
            //        var index = 0;

            //        //check if file exist and rename
            //        var check = false;
            //        var files = Directory.GetFiles(Server.MapPath("~/IMG"));
            //        do
            //        {
            //            string fName = Path.GetFileNameWithoutExtension(file.FileName);
            //            string fExt = Path.GetExtension(file.FileName);
            //            var newFileName = String.Concat(fName, string.Format("_{0}", index), fExt);
            //            var fileExists = files.Where(s => s.Contains(newFileName)).ToList();
            //            if (fileExists == null || fileExists.Count == 0)
            //            {
            //                var pathNew = Server.MapPath("~/IMG/" + newFileName);
            //                file.SaveAs(pathNew);                           
            //                check = true;
            //            }
            //            else
            //            {
            //                index++;
            //            }
            //        } while (!check);
            //    }
            Guid getid = Guid.NewGuid();
            string id = getid.ToString();
            List<Sanpham> lsp = (List<Sanpham>)Session["Sanpham"];
            string sql = string.Format("insert into Sanpham (maLoai,maSP,tenSP,Giaban,Hinhanh) values('{0}','{1}','{2}',{3},'{4}')", sp.maLoai, getid ,sp.tenSP,sp.Giaban,sp.Hinhanh);
                var kq = db.Database.ExecuteSqlCommand(sql);

                return Json(new
                {
                    success=true,
                    message="Thành công"
                }, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(new
            //    {
            //        success = false,
            //        message = ex.Message
            //    }, JsonRequestBehavior.AllowGet);
            //}                    
        }
        public ActionResult get(string maSP)
        {
            var rs = db.Sanphams.Where(x => x.maSP == maSP).Select(x => new
            {
                maSP = x.maSP,
                tenSP = x.tenSP,
                Giaban = x.Giaban,
                Hinhanh = x.Hinhanh,
                maLoai = x.maLoai
            }).SingleOrDefault();
            return Json(new { dt = rs }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult edit(Sanpham sp)
        {
            Guid getid = new Guid();
            string id = getid.ToString(); 
            List<Sanpham> lsp = (List<Sanpham>)Session["Sanpham"];
            string sql = string.Format("update Sanpham set hinhanh='{0}',giaban={1},tenSP=N'{2}' where maSP='{3}'", sp.Hinhanh, sp.Giaban, sp.tenSP, sp.maSP);
            var kq = db.Database.ExecuteSqlCommand(sql);
            return Json(JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete(string maSP)
        {
            Sanpham sp= db.Sanphams.Find(maSP);
            db.Sanphams.Remove(sp);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}