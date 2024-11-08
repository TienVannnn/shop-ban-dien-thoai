using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QuanLyBanHang_63132681.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanHangN_63132681Entities quanLyBanHangN_63132681Entities = new QuanLyBanHangN_63132681Entities();
        public ActionResult Index()
        {
            HomeModel_63132681 objhome = new HomeModel_63132681();
            objhome.listca = quanLyBanHangN_63132681Entities.LoaiSanPhams.ToList();
            objhome.listpro = quanLyBanHangN_63132681Entities.SanPhams.ToList();
            objhome.IsUserLoggedIn = Session["idUser"] != null;
            return View(objhome);
        }

        [HttpGet]

        public ActionResult Register()
        {
            

            return View();
        }
        [HttpPost]
       
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang _user)
        {
            if (ModelState.IsValid)
            {
                var check = quanLyBanHangN_63132681Entities.KhachHangs.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.MatKhau = GetMD5(_user.MatKhau);
                    quanLyBanHangN_63132681Entities.Configuration.ValidateOnSaveEnabled = false;
                    quanLyBanHangN_63132681Entities.KhachHangs.Add(_user);
                    quanLyBanHangN_63132681Entities.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        //create a string MD5 mã hóa mật khẩu

        public static string GetMD5(string str)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string MatKhau)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(MatKhau);
                var khachHang = quanLyBanHangN_63132681Entities.KhachHangs
                    .Where(s => s.Email.Equals(Email) && s.MatKhau.Equals(f_password))
                    .FirstOrDefault();

                var nhanVien = quanLyBanHangN_63132681Entities.NhanViens
                    .Where(s => s.Email.Equals(Email) && s.MatKhau.Equals(MatKhau))
                    .FirstOrDefault();

                if (khachHang != null)
                {
                    // Đăng nhập thành công cho khách hàng
                    Session["FullName"] = khachHang.HoTen;
                    Session["Email"] = khachHang.Email;
                    Session["idUser"] = khachHang.MaKhachHang;

                    return RedirectToAction("Index");
                }
                else if (nhanVien != null)
                {
                    // Đăng nhập thành công cho nhân viên
                    Session["FullNameNV"] = nhanVien.HoTen;
                    Session["EmailNV"] = nhanVien.Email;
                    Session["idNV"] = nhanVien.MaNhanVien;
                    Session["QTC"] = String.Equals(nhanVien.QuyenTruyCap, "Admin", StringComparison.OrdinalIgnoreCase);

                   
                    if (nhanVien.QuyenTruyCap.Equals("Admin"))
                    {
                        Session["QTC"] = true;
                        // Nếu là Admin, đưa đến trang Admin
                        return Redirect("~/Admin_63132681/HomeAdmin_63132681/Index");
                    }
                    else
                    {
                        // Nếu không phải Admin, đưa đến trang admin nhưng không có chức năng thêm nhân viên, chỉ xem được hóa đơn và sản phẩm
                        Session["QTC"] = false;
                        
                        return Redirect("~/Admin_63132681/HomeAdmin_63132681/Index");
                    }
                }
                else
                {
                    // Đăng nhập thất bại
                    ViewBag.error = "Login failed";
                    return View(); // Đảm bảo trả về view để hiển thị thông báo lỗi
                }
            }
            return View();
        }



        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}