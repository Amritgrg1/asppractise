using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
//hello world

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: amrit
        MainEntities db;
        public ProductController()
        {
            db = new MainEntities();
        }

        public ActionResult Index()
        {
            List<product> all_data = db.products.ToList();
            return View(all_data);
        }
        public ActionResult addproduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult index(DateTime? dat, DateTime? dats)
        {
            var results=db.products.Where(x=> x.pmdate>=dat && x.pmdate<=dats).ToList();
            return View(results);
        }
        public ActionResult SaveData(product product)
        {
            db.products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Editproduct(int pid)
        {
            product data = db.products.Find(pid);//find data using primary key

            return View(data);
        }

        public ActionResult UpdateData(product product)
        {

            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult deletedata(int pid)
        {
            product data = db.products.Find(pid);
            db.products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}