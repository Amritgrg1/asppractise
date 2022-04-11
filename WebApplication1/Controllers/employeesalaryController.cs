using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class employeesalaryController : Controller
    {
        // GET: amrit
        MainEntities db;
        public employeesalaryController()
        {
            db = new MainEntities();
        }

        public ActionResult Index()
        {
            var employee_salary_details = db.employee_salary_details.ToList();
            //List<employee_salary_details> all_data = db.employee_salary_details.ToList();
           // return View(all_data);
           return View(employee_salary_details);
        }
        public ActionResult addsalary()
        {
            var emplist = db.employees.ToList();
            //ViewBag emplist = emplist;
            ViewBag.employeelist = new SelectList(emplist, "eid", "ename"); 
            return View();
        }
        [HttpPost]

        public ActionResult index(DateTime? dat ,DateTime? dats)
        {
            var results=db.employee_salary_details.Where(x=> x.paid_date >=dat && x.paid_date<=dats ).ToList();
            return View(results);
        }
        public ActionResult SaveData(employee_salary_details employeesalary)
        {
            db.employee_salary_details.Add(employeesalary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Editemployee(int employee_id)
        {
            employee_salary_details data = db.employee_salary_details.Find(employee_id);//find data using primary key

            return View(data);
        }

        public ActionResult UpdateData(employee_salary_details employeesalry)
        {

            db.Entry(employeesalry).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult deletedata(int id)
        {
            employee_salary_details data = db.employee_salary_details.Find(id);
            db.employee_salary_details.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}