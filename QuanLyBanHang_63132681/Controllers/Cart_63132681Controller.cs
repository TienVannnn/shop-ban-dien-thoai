using QuanLyBanHang_63132681.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang_63132681.Controllers
{
    public class Cart_63132681Controller : Controller
    {
        QuanLyBanHangN_63132681Entities db = new QuanLyBanHangN_63132681Entities();
        // GET: Cart_63132681
        public ActionResult Index()
        {
            return View((List<CartModel_63132681>)Session["cart"]);
        }

        public ActionResult AddToCart(int id, int soluong)
        {
            if (Session["cart"] == null)
            {
                List<CartModel_63132681> cart = new List<CartModel_63132681>();
                cart.Add(new CartModel_63132681 { SanPham = db.SanPhams.Find(id), SoLuong = soluong });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel_63132681> cart = (List<CartModel_63132681>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].SoLuong += soluong;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel_63132681 { SanPham = db.SanPhams.Find(id), SoLuong = soluong });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        private int isExist(int id)
        {
            List<CartModel_63132681> cart = (List<CartModel_63132681>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].SanPham.MaSanPham.Equals(id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int Id)
        {
            List<CartModel_63132681> li = (List<CartModel_63132681>)Session["cart"];
            li.RemoveAll(x => x.SanPham.MaSanPham == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
    }
}