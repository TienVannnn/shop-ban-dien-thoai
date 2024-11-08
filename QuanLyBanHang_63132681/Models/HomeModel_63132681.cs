using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang_63132681.Models
{
    public class HomeModel_63132681
    {
        public List<SanPham> listpro { get; set; }
        public List<LoaiSanPham> listca { get; set; }
        public bool IsUserLoggedIn { get; set; }

    }
}