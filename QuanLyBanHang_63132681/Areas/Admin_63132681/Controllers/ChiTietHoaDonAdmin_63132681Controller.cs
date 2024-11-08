using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang_63132681.Models;

namespace QuanLyBanHang_63132681.Areas.Admin_63132681.Controllers
{
    public class ChiTietHoaDonAdmin_63132681Controller : Controller
    {
        private QuanLyBanHangN_63132681Entities db = new QuanLyBanHangN_63132681Entities();

        // GET: Admin_63132681/ChiTietHoaDonAdmin_63132681
        public ActionResult Index()
        {
            var chiTietHoaDons = db.ChiTietHoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(chiTietHoaDons.ToList());
        }

        // GET: Admin_63132681/ChiTietHoaDonAdmin_63132681/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    // Truy vấn danh sách chi tiết hóa đơn với mã hóa đơn tương ứng
        //    var chiTietHoaDonList = db.ChiTietHoaDons.Where(c => c.MaHoaDon == id).ToList();
           

        //    if (chiTietHoaDonList == null || chiTietHoaDonList.Count == 0)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(chiTietHoaDonList);
        //}


        public ActionResult Details(int? id)
        {
            using (QuanLyBanHangN_63132681Entities db = new QuanLyBanHangN_63132681Entities())
            {
                List<KhachHang> khachhang = db.KhachHangs.ToList();
                List<HoaDon> donhang = db.HoaDons.ToList();
                List<NhanVien> nhanvien = db.NhanViens.ToList();
                List<SanPham> sanpham = db.SanPhams.ToList();
                List<ChiTietHoaDon> ctdh = db.ChiTietHoaDons.ToList();

                var main = from h in db.HoaDons
                           join k in db.KhachHangs on h.MaKhachHang equals k.MaKhachHang
                           where (h.MaHoaDon == id)
                           select new CartModel_63132681
                           {
                               donhang = h,
                               khachhang = k
                           };

                var sub = from c in db.ChiTietHoaDons
                          join s in db.SanPhams on c.MaSanPham equals s.MaSanPham
                          where (c.MaHoaDon == id)
                          select new CartModel_63132681
                          {
                              ctdh = c,
                              sanpham = s,
                              SoLuong = c.SoLuong,
                              thanhTien = (double)c.SanPham.DonGia * c.SoLuong,
                          };

                ViewBag.main = main.ToList();
                ViewBag.sub = sub.ToList();

                return View();

            }



            //var chiTietDonHangs = db.ChiTietDonHangs.Include(c => c.DonHang).Include(c => c.SanPham);
            //return View(chiTietDonHangs.ToList());
        }

        // GET: Admin_63132681/ChiTietHoaDonAdmin_63132681/Create
        public ActionResult Create()
        {
            ViewBag.MaHoaDon = new SelectList(db.HoaDons, "MaHoaDon", "TenHoaDon");
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: Admin_63132681/ChiTietHoaDonAdmin_63132681/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHD,MaHoaDon,MaSanPham,SoLuong,DonGia")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chiTietHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoaDon = new SelectList(db.HoaDons, "MaHoaDon", "TenHoaDon", chiTietHoaDon.MaHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietHoaDon.MaSanPham);
            return View(chiTietHoaDon);
        }

        // GET: Admin_63132681/ChiTietHoaDonAdmin_63132681/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoaDon = new SelectList(db.HoaDons, "MaHoaDon", "TenHoaDon", chiTietHoaDon.MaHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietHoaDon.MaSanPham);
            return View(chiTietHoaDon);
        }

        // POST: Admin_63132681/ChiTietHoaDonAdmin_63132681/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHD,MaHoaDon,MaSanPham,SoLuong,DonGia")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoaDon = new SelectList(db.HoaDons, "MaHoaDon", "TenHoaDon", chiTietHoaDon.MaHoaDon);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietHoaDon.MaSanPham);
            return View(chiTietHoaDon);
        }

        // GET: Admin_63132681/ChiTietHoaDonAdmin_63132681/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            if (chiTietHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHoaDon);
        }

        // POST: Admin_63132681/ChiTietHoaDonAdmin_63132681/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHoaDon chiTietHoaDon = db.ChiTietHoaDons.Find(id);
            db.ChiTietHoaDons.Remove(chiTietHoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
