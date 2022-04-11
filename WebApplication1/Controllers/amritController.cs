using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    //git try
    public class amritController : Controller
    {
        // GET: amrit
        MainEntities db;
        public amritController()
        {
            db = new MainEntities();
        }

        public ActionResult Index()
        {
            List<employee> all_data = db.employees.ToList();
            return View(all_data);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SaveData(employee employee)
        {
            db.employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int eid)
        {
            employee data = db.employees.Find(eid);//find data using primary key

            return View(data);
        }

        public ActionResult UpdateData(employee employee)
        {

            db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}