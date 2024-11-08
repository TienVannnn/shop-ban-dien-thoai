﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyBanHang_63132681.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [DisplayName("Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Tên Hóa Đơn")]
        public string TenHoaDon { get; set; }
        [DisplayName("Ngày Đặt Hàng")]
        public System.DateTime NgayDat { get; set; }
        [DisplayName("Ngày Giao Hàng")]
        public Nullable<System.DateTime> NgayGiao { get; set; }
        [DisplayName("Mã Khách Hàng")]
        public Nullable<int> MaKhachHang { get; set; }
        [DisplayName("Mã Nhân Viên")]
        public Nullable<int> MaNhanVien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
