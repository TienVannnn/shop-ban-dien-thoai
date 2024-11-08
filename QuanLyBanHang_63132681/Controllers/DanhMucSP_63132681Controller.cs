using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QuanLyBanHang_63132681.Controllers
{
    public class DanhMucSP_63132681Controller : Controller
    {
        QuanLyBanHangN_63132681Entities db = new QuanLyBanHangN_63132681Entities();
        // GET: DanhMucSP_63132681
        public ActionResult Index()
        {
            var ls = db.LoaiSanPhams.ToList();
            return View(ls);
        }
        public ActionResult DanhMucSanPham_63132681(string id, int? page)
        {
            if (page == null) page = 1;

            // 1. Lọc sản phẩm theo id
            var dsproducts = db.SanPhams.Where(n => n.MaLoaiSanPham == id).OrderBy(x => x.MaSanPham);

            // 2. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 3. Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 4. Trả về các Link được phân trang theo kích thước và số trang.
            var pagedList = dsproducts.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
    }
}

