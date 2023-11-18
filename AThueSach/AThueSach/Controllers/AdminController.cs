using AThueSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AThueSach.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private DataThueSachEntities db = new DataThueSachEntities();

        public ActionResult Index()
        {
            AdminUser nvSession = (AdminUser)Session["user"];

            var count = db.AdminUsers.Count(m => m.IDNV == nvSession.IDNV && m.Department == "Quản lý");
            if (count == 0)
            {
                return RedirectToAction("KhongCoQuyen");
            }
            else
            {
                var dsnhanvien = db.AdminUsers.ToList();
                return View(dsnhanvien);
            }
        }
        public ActionResult KhongCoQuyen()
        {
            return View();
        }
        // Thêm danh sách nhân viên 
        [HttpGet]
        public ActionResult Create()
        {
            // Danh thả xuống 
            var cv = new List<string>() { "Quản lý", "Nhân viên" };
            ViewBag.listcv = cv;

            List<AdminUser> list = db.AdminUsers.ToList();
            ViewBag.listNV = new SelectList(list, "IDNV", "HoTenNV", "");
            AdminUser nhanVien = new AdminUser();
            return View(nhanVien);
        }
        [HttpPost]
        public ActionResult Create(AdminUser nhanVien)
        {
            // Danh thả xuống 
            var cv = new List<string>() { "Quản lý", "Nhân viên" };
            ViewBag.listcv = cv;
            // Kiểm tra không được bỏ trống 
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(nhanVien.NameNV))
                    ModelState.AddModelError(string.Empty, "Họ Tên Nhân Viên Không Được Để Trống");
                if (string.IsNullOrEmpty(nhanVien.Username))
                    ModelState.AddModelError(string.Empty, "Username Không Được Để Trống ");
                if (string.IsNullOrEmpty(nhanVien.Password))
                    ModelState.AddModelError(string.Empty, "Mật Khẩu Không Được Để Trống");
                if (string.IsNullOrEmpty(nhanVien.Department))
                    ModelState.AddModelError(string.Empty, "Chức Vụ Không Được Để Trống");
                //Kiểm tra xem có trùng mã NV hay không
                if (string.IsNullOrEmpty(nhanVien.IDNV))
                {
                    ModelState.AddModelError(string.Empty, "Mã Nhân Viên Không Được Để Trống ");
                }
                var NV = db.AdminUsers.FirstOrDefault(k => k.IDNV == nhanVien.IDNV);
                if (NV != null)
                    ModelState.AddModelError(string.Empty, "Trùng Mã Nhân Viên");
                if (ModelState.IsValid)
                {
                    db.AdminUsers.Add(nhanVien);
                    db.SaveChanges();

                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        // Sửa danh sách nhân viên

        public ActionResult Edit(int? id)
        {
            var cv = new List<string>() { "Quản lý", "Nhân viên" };
            ViewBag.listcv = cv;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AdminUser adminUser = db.AdminUsers.Find(id);
            AdminUser adminUser = db.AdminUsers.FirstOrDefault(u => u.Id == id);
            if (adminUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.listNV = new SelectList(db.AdminUsers, "IDNV", "HoTenNV", "");
            return View(adminUser);
        }
        [HttpPost]
        public ActionResult Edit(int? Id, AdminUser model)
        {
            var cv = new List<string>() { "Quản lý", "Nhân viên" };
            ViewBag.listcv = cv;

            if (ModelState.IsValid)
            {
                // Tìm đổi tượng 
                var updateModel = db.AdminUsers.FirstOrDefault(u => u.Id == Id);
                if (updateModel != null)
                {
                    // Cập nhật thông tin NhanVien                
                    updateModel.NameNV = model.NameNV;
                    updateModel.Username = model.Username;
                    updateModel.Password = model.Password;
                    updateModel.Department = model.Department;

                }
                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}