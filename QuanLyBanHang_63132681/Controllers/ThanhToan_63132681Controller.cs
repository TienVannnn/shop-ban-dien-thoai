using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang_63132681.Controllers
{
    public class ThanhToan_63132681Controller : Controller
       
    {
        private static int soHoaDon = 0;
        QuanLyBanHangN_63132681Entities db = new QuanLyBanHangN_63132681Entities();
        
        // GET: ThanhToan_63132681
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                // lấy thông tin từ giỏ hàng từ biến session
                var lscart = (List<CartModel_63132681>)Session["cart"];

                // gán dữ liệu cho hóa đơn
                HoaDon hd = new HoaDon();
                hd.TenHoaDon = "Đơn hàng - " + DateTime.Now.ToString("yyyyMMddHHmmss");
                hd.MaKhachHang = int.Parse(Session["idUser"].ToString());
                hd.NgayDat = DateTime.Now;
                // lưu thông tin dữ liệu vào bảng hóa đơn
                db.HoaDons.Add(hd);
                db.SaveChanges();

                // lấy mã hóa đơn vừa mới tạo để lưu vào bảng chi tiết đặt hàng
                int intmahd = hd.MaHoaDon;
                soHoaDon++;
                ViewBag.SoHoaDon = soHoaDon;

                List<ChiTietHoaDon> lsctdh = new List<ChiTietHoaDon>();
                foreach (var i in lscart)
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.MaHoaDon = intmahd;
                    ct.MaSanPham = i.SanPham.MaSanPham;
                    ct.SoLuong = i.SoLuong;
                    ct.DonGia = i.SanPham.DonGia;
                    lsctdh.Add(ct);
                }
                db.ChiTietHoaDons.AddRange(lsctdh);
                db.SaveChanges();
                // Xóa giỏ hàng sau khi thanh toán thành công
                Session["cart"] = null;
                Session["count"] = 0;
            }
           
            return View();
        }

    }
}