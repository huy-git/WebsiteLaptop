using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;
namespace WEBLAPTOP.Areas.Admin.Controllers
{
    public class DonhangController : Controller
    {
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
        // GET: Admin/Donhang
        public ActionResult Donhang()
        {
            var donhangs = db.DHs.ToList();
            return View(donhangs);
        }
        public JsonResult GetDonhang()
        {
            QUANLILAPTOPEntities entities = new QUANLILAPTOPEntities();
            return Json(entities.DHs);
        }
        [HttpPost]
        public JsonResult create(DH dh)
        {
            DH newdh = new DH();
            newdh.maDH = dh.maDH;
            newdh.maNV = dh.maNV;
            newdh.maKH = dh.maKH;
            newdh.Thanhtien = dh.Thanhtien;
            newdh.Ngayban = dh.Ngayban;
            newdh.hovaten = dh.hovaten;
            newdh.diachikhachhang = dh.diachikhachhang;
            newdh.diachigiaohang = dh.diachigiaohang;
            newdh.sodienthoaikhachhang = dh.sodienthoaikhachhang;
            newdh.sodiennguoinhan = dh.sodiennguoinhan;
            newdh.socmtndkh = dh.socmtndkh;
            newdh.socmtndnguoinhan = dh.socmtndnguoinhan;
            newdh.taikhoannh = dh.taikhoannh;
            newdh.tongsotien = dh.tongsotien;
            newdh.tienvat = dh.tienvat;
            newdh.trangthaidonhang = dh.trangthaidonhang;
            var ds = db.DHs.Add(newdh);

            db.SaveChanges();

            return Json(new
            {
                data = ds
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get(string maDH)
        {
            var rs = db.DHs.Find(maDH);
            return Json(rs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult edit(DH dh)
        {
            var entity = db.DHs.Find(dh.maDH);
            entity.maDH = dh.maDH;
            entity.maNV = dh.maNV;
            entity.maKH = dh.maKH;
            entity.Thanhtien = dh.Thanhtien;
            entity.Ngayban = dh.Ngayban;
            entity.hovaten = dh.hovaten;
            entity.diachikhachhang = dh.diachikhachhang;
            entity.diachigiaohang = dh.diachigiaohang;
            entity.sodienthoaikhachhang = dh.sodienthoaikhachhang;
            entity.sodiennguoinhan = dh.sodiennguoinhan;
            entity.socmtndkh = dh.socmtndkh;
            entity.socmtndnguoinhan = dh.socmtndnguoinhan;
            entity.taikhoannh = dh.taikhoannh;
            entity.tongsotien = dh.tongsotien;
            entity.tienvat = dh.tienvat;
            entity.trangthaidonhang = dh.trangthaidonhang;
            var ds = db.DHs.Add(entity);

            db.SaveChanges();

            return Json(new
            {
                data = ds
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult delete(string maDH)
        {
            DH dh = db.DHs.Find(maDH);
            db.DHs.Remove(dh);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
    