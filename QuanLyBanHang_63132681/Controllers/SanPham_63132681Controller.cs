using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang_63132681.Controllers
{
    public class SanPham_63132681Controller : Controller
    {
        QuanLyBanHangN_63132681Entities quanLyBanHangN_63132681Entities1 = new QuanLyBanHangN_63132681Entities();
        // GET: SanPham_63132681
        //public ActionResult Details(int id)
        //{
        //    var obj = quanLyBanHangN_63132681Entities1.SanPhams.Where(n=> n.MaSanPham == id).FirstOrDefault();
        //    return View(obj);
        //}


        public ActionResult Details(int id)
        {
            var currentProduct = quanLyBanHangN_63132681Entities1.SanPhams.Find(id);

            if (currentProduct == null)
            {
                return HttpNotFound();
            }

            // Lấy các sản phẩm liên quan
            var relatedProducts = quanLyBanHangN_63132681Entities1.SanPhams
                .Where(p => p.MaSanPham != id && p.MaLoaiSanPham == currentProduct.MaLoaiSanPham)
                .Take(4) // Lấy 4 sản phẩm tương tự (Bạn có thể điều chỉnh số lượng)
                .ToList();

            // Truyền dữ liệu sang View
            var viewModel = new SanPhamTuongTu_63132681
            {
                CurrentProduct = currentProduct,
                RelatedProducts = relatedProducts
            };

            return View(viewModel);
        }
    }
}