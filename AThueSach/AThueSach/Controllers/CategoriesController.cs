using AThueSach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AThueSach.Controllers
{
    public class CategoriesController : Controller
    {
        private DataThueSachEntities db = new DataThueSachEntities();

        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            //
            return View(categories);
        }

        [HttpGet] //Trả về view
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost] //Gọi khi mà người dùng gửi đi ấn submit
        public ActionResult Create(Category cate) //tham số cate kiểu Category
        {
            try //Những lệnh phát sinh
            {
                db.Categories.Add(cate); //thêm 1 cate vào db 
                db.SaveChanges(); //Lưu dữ liệu
                return RedirectToAction("Index"); //Chuyển hướng đến trang index
            }
            catch
            {
                return Content("Lỗi tạo mới Category"); 
            }
        }
        //Khi mà có hành đồng thêm dữ liệu mới thì cần sài http get - post
        ///////////////////////////////////////////////////////////////////////////////
        public ActionResult Details(string id)
        {
            return View(db.Categories.Where(s => s.IDCate == id).FirstOrDefault()); 
            //Trả về cái view với cái id truyền vô trùng với id trong cate
        }
        ///////////////////////////////////////////////////////////////////////////////
        public ActionResult Edit(string id)
        {
            return View(db.Categories.Where(s => s.IDCate == id).FirstOrDefault()); 
        }
        [HttpPost]
        public ActionResult Edit(string id, Category cate)
        {
            if (cate.Id > 0) //KTRA có tồn tại hong
            {

                db.Entry(cate).State = EntityState.Modified; //Tbao là mình đang cập nhật dữ liệu đang tồn tại 
            }
            else
            {
                db.Entry(cate).State = EntityState.Added; //Ngược lại nêu id ko có trong db thì tiến hành thêm cái đó
            }
            db.SaveChanges(); //Lưu vào db
            return RedirectToAction("Index"); //Chuyển hướng đến trang index
        }
        ///////////////////////////////////////////////////////////////////////////////
        public ActionResult Delete(string id)
        {
            return View(db.Categories.Where(s => s.IDCate == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, Category cate)
        {
            try
            {
                cate = db.Categories.Where(s => s.IDCate == id).FirstOrDefault();
                db.Categories.Remove(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin");
            }
        }
    }
}