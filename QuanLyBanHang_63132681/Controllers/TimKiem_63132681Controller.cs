using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace QuanLyBanHang_63132681.Controllers
{
    public class TimKiem_63132681Controller : Controller
    {
        QuanLyBanHangN_63132681Entities db = new QuanLyBanHangN_63132681Entities();
        [HttpGet]

        // GET: TimKiem_63132681
        public ActionResult TimKiem(string tukhoa, int? page)
        {
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pagesize = 5;
            int pagenumber = (page ??  1);
            // tìm kiếm theo tên sản phẩm
            var lssp = db.SanPhams.Where(n => n.TenSanPham.Contains(tukhoa));  
            ViewBag.Tukhoa = tukhoa;
            return View(lssp.OrderBy(n => n.TenSanPham).ToPagedList(pagenumber, pagesize));
        }


        [HttpPost]

        // GET: TimKiem_63132681
        public ActionResult TimKiem2(string tukhoa)
        {
            // gọi về hàm get tìm kiếm
            return RedirectToAction("TimKiem", new {@tukhoa = tukhoa});
        }
    }
}