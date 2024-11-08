using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang_63132681.Models
{
    public class SanPhamTuongTu_63132681
    {
        public SanPham CurrentProduct { get; set; }
        public List<SanPham> RelatedProducts { get; set; }
    }
}