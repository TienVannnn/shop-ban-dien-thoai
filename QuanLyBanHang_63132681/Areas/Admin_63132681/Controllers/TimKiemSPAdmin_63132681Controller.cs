using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang_63132681.Areas.Admin_63132681.Controllers
{
    public class TimKiemSPAdmin_63132681Controller : Controller
        
    {
        QuanLyBanHangN_63132681Entities db= new QuanLyBanHangN_63132681Entities();
        // GET: Admin_63132681/TimKiemSPAdmin_63132681
        [HttpGet]
        public ActionResult TimKiemSanPham(string tensp = "")
        {
            // Khởi tạo query ban đầu
            var sp = db.SanPhams.AsQueryable();


            // Kiểm tra và thêm điều kiện tìm kiếm sản phẩm gần đúng
            if (!string.IsNullOrEmpty(tensp))
            {
                tensp = tensp.ToUpper(); // Chuyển chuỗi tìm kiếm thành chữ hoa
                sp = sp.Where(s => ( s.TenSanPham.ToUpper()).Contains(tensp));
            }
            // Lấy danh sách sinh viên sau khi áp dụng điều kiện
            var tksp = sp.ToList();

            if (tksp.Count == 0)
            {
                ViewBag.TB = "Không có thông tin sản phẩm tìm kiếm.";
            }


            return View(tksp);
        }
    }
}