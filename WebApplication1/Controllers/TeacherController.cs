using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: amrit
        MainEntities db;
        public TeacherController()
        {
            db = new MainEntities();
        }

        public ActionResult Index()
        {
            List<teacher> all_data = db.teachers.ToList();
            return View(all_data);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SaveData(teacher teacher)
        {
            db.teachers.Add(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Editteacher(int tid)
        {
            teacher data = db.teachers.Find(tid);//find data using primary key

            return View(data);
        }

        public ActionResult UpdateData(teacher teacher)
        {

            db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}