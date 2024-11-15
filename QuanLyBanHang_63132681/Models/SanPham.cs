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
    using System.ComponentModel.DataAnnotations;

    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
        [DisplayName("Mã Sản Phẩm")]

        public int MaSanPham { get; set; }
        [DisplayName("Tên Sản Phẩm")]
        [Required(ErrorMessage = "Têm sản phẩm không được để trống")]
        public string TenSanPham { get; set; }
        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [DisplayName("Đơn Giá")]
        public int DonGia { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [DisplayName("Mô Tả")]
        public string MoTa { get; set; }
        [DisplayName("Ảnh Sản Phẩm")]
        public string AnhSanPham { get; set; }
        [DisplayName("Mã Loại Sản Phẩm")]
        public string MaLoaiSanPham { get; set; }
       
        private int _soLuongDaBan;
        [DisplayName("Số Lượng Đã Bán")]
        public int SoLuongDaBan
        {
            get { return _soLuongDaBan; }
            set
            {
                // Kiểm tra nếu giá trị mới nhỏ hơn 0, sẽ đặt giá trị là 0
                _soLuongDaBan = value < 0 ? 0 : value;
            }
        }
        [DisplayName("Tình Trạng")]

        public Nullable<bool> TinhTrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
