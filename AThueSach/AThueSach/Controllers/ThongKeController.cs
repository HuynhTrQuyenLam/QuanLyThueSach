using AThueSach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AThueSach.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Home
        private DataThueSachEntities db = new DataThueSachEntities();

        public ActionResult Index()
        {
            var order = db.OrderDetails.ToList();
            return View(order);
        }

    }
}