using AThueSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AThueSach.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private DataThueSachEntities db = new DataThueSachEntities();

        public ActionResult DangNhap()
        {

            return View();
        }
        // code xử lý DN
        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            // Check trong db           
            var NV = db.AdminUsers.SingleOrDefault(m => m.Username.ToLower() == user.ToLower() && m.Password == password);
            if (NV != null)
            {
                // tao session và gán giá trị 
                Session["user"] = NV;
                return Redirect("/Admin/Index");
            }
            else
            {
                // Lỗi khi tài khoản không đúng 
                TempData["error"] = "Tài khoản đăng nhập không đúng ";
                return View();
            }

        }
        public ActionResult DangXuat()
        {
            // xóa session 
            Session.Remove("user");
            // xóa session form authent 
            FormsAuthentication.SignOut();
            return Redirect("/Login/DangNhap");

        }
    }
}