using AThueSach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AThueSach.Controllers
{
    public class OrderController : Controller
    {
        DataThueSachEntities db = new DataThueSachEntities();

        // GET: Order
        public ActionResult Index()
        {
            var orderproes = db.OrderProes.Where(x => x.Status == 1).ToList();
            return View(orderproes);
        }
        public ActionResult Detail(int id)
        {
            var item = db.OrderProes.Find(id);
            return View(item);
        }
        public ActionResult Partial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(x => x.IDOrder == id).ToList();
            return PartialView(items);
        }

        public ActionResult Add(string category)
        {
            var products = db.Products.Where(x => x.StatusPro == 0).ToList();
            return View(products);
        }
        public ActionResult ShowCart(string category)
        {
            var products = db.Products.Include(p => p.Category); //truy vấn 2 dữ liệu
            OrderPro _order = new OrderPro();
            _order.DateOrder = DateTime.Now;
            if (category == null)
            {
                products = db.Products.OrderByDescending(x => x.NamePro);
            }
            else
            {
                products = db.Products.OrderByDescending(x => x.ProductID).Where(x => x.Category == category);
            }
            int total_pro_item = 0;

            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            total_pro_item = cart.Total_product();
            ViewBag.AddToCart = total_pro_item;
            if (total_pro_item > 0)
                return View(cart);
            else
                return View("EmptyCart");
        }
        // Tạo mới giỏ hàng, nguồn được lấy từ Session
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            
            var _pro = db.Products.SingleOrDefault(s => s.ProductID == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "Order");
        }
        // Cập nhật số lượng và tính lại tổng tiền
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(Request.Form["idPro"]);
            int _quantity = int.Parse(Request.Form["carQuantity"]);
            cart.Update_quantity(id_pro, _quantity);

            return RedirectToAction("ShowCart", "Order");
        }
        // Xóa dòng sản phẩm trong giỏ hàng
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);

            return RedirectToAction("ShowCart", "Order");
        }

        // Các phương thức cho thanh toán
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                OrderPro _order = new OrderPro();
                _order.DateOrder = DateTime.Now;
                _order.Status = 1;
                _order.NameCus = (form["NameCustomer"]);
                _order.PhoneCus = (form["PhoneCustomer"]);
                db.OrderProes.Add(_order);
                foreach (var item in cart.Items)
                {
                    // lưu dòng sản phẩm vào chi tiết hóa đơn
                    OrderDetail _order_detail = new OrderDetail();
                    _order_detail.IDOrder = _order.ID;
                    _order_detail.IDProduct = item._product.ProductID;
                    _order_detail.NamePro = item._product.NamePro;
                    _order_detail.UnitPrice = (double)item._product.Price;
                    _order_detail.Quantity = item._quantity;
                    db.OrderDetails.Add(_order_detail);
                    //xử lý cập nhật lại số lượng tồn trong bảng Product
                    foreach (var p in db.Products.Where(s => s.ProductID == _order_detail.IDProduct)) //lấy ID Product đang có trong giỏ hàng
                    {
                        p.StatusPro = 1;
                    }
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "Order");
            }
            catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin"); ;
            }
        }
        // Thông báo thanh toán thành công
        public ActionResult CheckOut_Success()
        {
            return View();
        }
        public ActionResult TraSach(int ID)
        {
            OrderPro _order = db.OrderProes.Find(ID);
            _order.Status = 0;
            _order.DatePay = DateTime.Now;
            //foreach(var item in _order.OrderDetails)
            //{
            //    foreach(var p in db.Products.Where(s => s.ProductID == item.IDProduct))
            //    {
            //        p.StatusPro = 0;
            //    }
            //}
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DSTraSach()
        {
            var orderproes = db.OrderProes.Where(x => x.Status == 0).ToList();
            return View(orderproes); 
        }
    }
}