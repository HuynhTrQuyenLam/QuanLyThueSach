using AThueSach.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AThueSach.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private DataThueSachEntities db = new DataThueSachEntities();

        public ActionResult Index(string category, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (page == null) page = 1;

            if (category == null)
            {
                var productList = db.Products.OrderByDescending(x => x.NamePro);//Sắp xếp tên giảm dần
                return View(productList.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var productList = db.Products.OrderByDescending(x => x.NamePro).Where(p => p.Category == category);
                return View(productList.ToPagedList(pageNumber, pageSize));
            }

        }

        public ActionResult Create()
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate");
            Product pro = new Product();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            List<Category> list = db.Categories.ToList();
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), filename));
                }
                ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", 1);
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //404
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //KTRA ID
            ViewBag.Category = new SelectList(db.Categories, "IDCate", "NameCate", product.Category); //SelectList
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,NamePro,StatusPro,DecriptionPro,Category,Price,PriceHire,Quantity")] Product product, HttpPostedFileBase ImagePro)
           
        {
            if (ModelState.IsValid)
            {
                 var productDB = db.Products.FirstOrDefault(p => p.ProductID == product.ProductID); //lấy đối tượng
                if (productDB != null)
                {
                    productDB.NamePro = product.NamePro; //proDB cập nhật lại bằng trong View
                    productDB.DecriptionPro = product.DecriptionPro;
                    productDB.Price = product.Price;
                    productDB.PriceHire = product.PriceHire;
                    productDB.StatusPro = product.StatusPro;
                    productDB.Quantity = product.Quantity;
                    productDB.Category = product.Category;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Categories, "IDCate", "NameCate", product.Category);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            return View(db.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                product = db.Products.Where(s => s.ProductID == id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin");
            }
        }

        public ActionResult Details(int id)
        {
            var prodt = db.Products.FirstOrDefault(pr => pr.ProductID == id);
            return View(prodt);
        }
    }
}