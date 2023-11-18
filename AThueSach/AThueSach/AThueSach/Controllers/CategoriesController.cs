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
        private ThueSachDBEntities db = new ThueSachDBEntities();

        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                db.Categories.Add(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Lỗi tạo mới Category");
            }
        }

        public ActionResult Details(string id)
        {
            return View(db.Categories.Where(s => s.IDCate == id).FirstOrDefault());
        }

        public ActionResult Edit(string id)
        {
            return View(db.Categories.Where(s => s.IDCate == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, Category cate)
        {
            if (cate.Id > 0)
            {

                db.Entry(cate).State = EntityState.Modified;
            }
            else
            {
                db.Entry(cate).State = EntityState.Added;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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