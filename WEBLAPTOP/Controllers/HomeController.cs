using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBLAPTOP.Models;

namespace WEBLAPTOP.Controllers
{
    public class HomeController : Controller
    {
        QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();

        public ActionResult Index()
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            ViewBag.SPKM = db.Sanphams.OrderBy(x => x.maSP).Take(8).ToList();
            ViewBag.SPM = db.Sanphams.OrderBy(x => x.Giaban).Take(8).ToList();
            ViewBag.SPNB = db.Sanphams.OrderBy(x => x.tenSP).Take(8).ToList();
            ViewBag.danhmuc = db.LoaiSPs.ToList();
            return View();
        }

        public ActionResult LoaiSP(string maloai)
        {
            var loai = db.LoaiSPs.Where(x => x.maLoai == maloai).ToList().FirstOrDefault();
            ViewBag.Loai = loai;
            ViewBag.ds = db.LoaiSPs.ToList();
            return View();
        }

        public ActionResult Chitiet(string maSP)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            string sql = string.Format("select * from CTSP where [maSP]='{0}'", maSP);
            var sanphams = db.Database.SqlQuery<CTSP>(sql).SingleOrDefault();
            string sql1 = string.Format("select * from Sanpham where [maSP]='{0}'", maSP);
            var sanphams1 = db.Database.SqlQuery<Sanpham>(sql1).SingleOrDefault();
            sanphams.Sanpham = sanphams1;
            ViewBag.SanPhams = sanphams;
            return View();
        }
        public ActionResult ChitietTT(string macttt)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            var tintuc = db.tintucs.Where(s => s.maTT == macttt).ToList().FirstOrDefault();
           ViewBag.Tintucs = tintuc;
            return View();
        }
        public ActionResult loaiTT(string maLoaiTT)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            var loaitt = db.loaiTTs.Where(s => s.maLoaiTT == maLoaiTT).ToList();
            //Danh sách loại tin tức
            ViewBag.loaitts = loaitt;
            return View();
        }
        [HttpGet]
        public ActionResult giohang(string id, int soluong)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            List<Models.shopcart> gh = new List<shopcart>();
            string sql = string.Format("select * from Sanpham where [maSP]='{0}'", id);
            var sanphams = db.Database.SqlQuery<Sanpham>(sql).SingleOrDefault();
           
            if (Session["giohang"] == null)
            {

                Models.shopcart sp = new shopcart()
                {
                    id = sanphams.maSP,
                    tensp = sanphams.tenSP,
                    dongia = sanphams.Giaban.ToString(),
                    soluong = soluong.ToString(),
                    thanhtien = (sanphams.Giaban * soluong).ToString(),
                    anh = sanphams.Hinhanh
                };
                gh.Add(sp);

            }
            else
            {
                gh = (List<Models.shopcart>)Session["giohang"];
                var thuattoan = gh.FirstOrDefault(s => s.id == id);
                if (thuattoan != null)
                {
                    thuattoan.soluong = (int.Parse(thuattoan.soluong) + soluong).ToString();
                    thuattoan.thanhtien = (int.Parse(thuattoan.dongia.Replace(".", "")) * int.Parse(thuattoan.soluong)).ToString();
                }
                else
                {
                    Models.shopcart sp = new shopcart()
                    {
                        id = sanphams.maSP,
                        tensp = sanphams.tenSP,
                        dongia = sanphams.Giaban.ToString(),
                        soluong = soluong.ToString(),
                        thanhtien = (sanphams.Giaban * soluong).ToString(),
                        anh = sanphams.Hinhanh
                    };
                    gh.Add(sp);
                }
            }
            Session["giohang"] = gh;
            return RedirectToAction("Thanhtoanshow");
        }
        [HttpGet]
        public ActionResult xoagiohangsp(string id)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            List<Models.shopcart> gh = (List<Models.shopcart>)Session["giohang"];
            var item = gh.FirstOrDefault(s => s.id == id);
            gh.Remove(item);
            Session["giohang"] = gh;
            return RedirectToAction("Thanhtoanshow");
        }
        public ActionResult Thanhtoan()
        {
            var gh = (List<Models.shopcart>)Session["giohang"];
            return Json(gh, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Thanhtoanshow()
        {

            return View();
        }
        public ActionResult xacnhanthanhtoan()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ghihoadon(string tenkhachhang, string dc1, string dc2, string cmt1, string cmt2, string sdt1, string sdt2)
        {
            Guid getid = Guid.NewGuid();
            string id = getid.ToString();
            List<shopcart> gh = (List<shopcart>)Session["giohang"];
            int tongtien = 0;
            try
            {
                foreach (shopcart a in gh)
                {
                    tongtien += int.Parse(a.thanhtien.Replace(".", ""));
                }
            }
            catch
            {
                Console.WriteLine("Đặt mua thành công");
            }
            string makh = Session["name"] == null ? "kh0013" : Session["name"].ToString();
            string sql = string.Format("insert into DH (maDH,maKH,Thanhtien,Ngayban,hovaten,diachikhachhang,diachigiaohang,sodienthoaikhachhang,sodiennguoinhan,socmtndkh,socmtndnguoinhan,taikhoannh,tongsotien,tienvat,trangthaidonhang) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", id, makh, tongtien, DateTime.Now.ToString("yyyy-MM-dd"), tenkhachhang, dc1, dc2, sdt1, sdt2, cmt1, cmt2, "Nhan va tra tien", (tongtien + tongtien * 10 / 100), tongtien * 10 / 100, 0);
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            var kq = db.Database.ExecuteSqlCommand(sql);
            //insert tung san pham da mua vao don hang
            foreach (shopcart a in gh)
            {
                getid = Guid.NewGuid();
                sql = string.Format("insert into CTDHB (maDH,maCTDH,maSP,Giaban,Thanhtien) values('{0}','{1}','{2}','{3}','{4}')", id, getid, a.id, a.dongia.Replace(".", ""), a.thanhtien.Replace(".", ""));
                kq= db.Database.ExecuteSqlCommand(sql);
            }

            return RedirectToAction("Index", "Home");
          

        }
        public ActionResult Tintuc( string maLoaiTT)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            //var tintuc = db.loaiTTs.Where(s => s.maLoaiTT == maLoaiTT).ToList().FirstOrDefault();
            //ViewBag.tintuc = tintuc;
            var tintucs = db.loaiTTs.ToList();
            ViewBag.Tintucs = tintucs;
            return View();
        }
        
        
        public ActionResult Search(string keyword)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            var data = db.Sanphams.Where(x => x.tenSP.Contains(keyword)).ToList();
            ViewBag.data = data;
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            QUANLILAPTOPEntities db = new QUANLILAPTOPEntities();
            var username = fc["Username"];
            var password = fc["Password"];


            ViewBag.Username = username;
            ViewBag.Password = password;


            if (String.IsNullOrEmpty(username))
            {
                ViewBag.Error = "Username and Password can not be blank";
            }
            else
            {

                var user = db.logins.SingleOrDefault(m => m.username == username);

                if (user == null)
                {
                    ViewBag.Error = "User does not exists";
                }
                else
                {
                    if (user.password != password)
                    {
                        ViewBag.Error = "Wrong Password";
                    }
                    else
                    {

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}