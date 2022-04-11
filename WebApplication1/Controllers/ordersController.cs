using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ordersController : Controller
    {
        // GET: amrit
        MainEntities db;
        public ordersController()
        {
            db = new MainEntities();
        }

        public ActionResult Index()
        {
            var orders = db.orders.ToList();
            //List<employee_salary_details> all_data = db.employee_salary_details.ToList();
            // return View(all_data);
            return View(orders);
        }
        public ActionResult addorders()
        {
            var emplist = db.products.ToList();
            //ViewBag emplist = emplist;
            ViewBag.employeelist = new SelectList(emplist, "pid", "pname");
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(order order)
        {
            db.orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Editorders(int oid)
        {
            var emplist = db.products.ToList();
            //ViewBag emplist = emplist;
            ViewBag.employeelist = new SelectList(emplist, "pid", "pname");
            order data = db.orders.Find(oid);//find data using primary key

            return View(data);
        }

        public ActionResult UpdateData(order order)
        {

            db.Entry(order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult deletedata(int oid)
        {
            order data = db.orders.Find(oid);
            db.orders.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}