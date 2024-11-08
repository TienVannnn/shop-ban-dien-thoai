using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang_63132681.Models
{
    public class CartModel_63132681
    {
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }

        public KhachHang khachhang { get; set; }
        public HoaDon donhang { get; set; }
        public ChiTietHoaDon ctdh { get; set; }

        public NhanVien nhanvien { get; set; }
        public LoaiSanPham loaisanpham { get; set; }
        public SanPham sanpham { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##0}")]
        public double thanhTien { get; set; }
    }
}