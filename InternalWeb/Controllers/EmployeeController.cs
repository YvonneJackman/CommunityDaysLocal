using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Model;
using Data.Migrations;

namespace InternalWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private CommunityDaysDb db = new CommunityDaysDb();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Country).Include(e => e.Location).Include(e => e.Directorate).Include(e => e.Department);
            return View(employees.ToList());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            //Employee employee = db.Employees.Find(id);
            var employeeByLogin = this.db.Employees.Where(o => o.NTLogin.Equals(User.Identity.Name));
            Employee employee = employeeByLogin.FirstOrDefault();

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            ViewBag.NTLogin = User.Identity.Name;
            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "CountryName");
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "LocationName");
            ViewBag.DirectorateId = new SelectList(db.Directorate, "DirectorateId", "DirectorateName");
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employee.NTLogin = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                var newId = employee.EmployeeId;
                return RedirectToAction("Details", newId);
            }

            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "CountryName", employee.CountryId);
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "LocationName", employee.LocationId);
            ViewBag.DirectorateId = new SelectList(db.Directorate, "DirectorateId", "DirectorateName", employee.DirectorateId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.NTLogin = User.Identity.Name;
            //Employee employee = db.Employees.Find(id);
            var employeeByLogin = this.db.Employees.Where(o => o.NTLogin.Equals(User.Identity.Name));
            Employee employee = employeeByLogin.FirstOrDefault();

            if (employee == null)
            {
                //return HttpNotFound();
                return RedirectToAction("Create");
            }
            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "CountryName", employee.CountryId);
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "LocationName", employee.LocationId);
            ViewBag.DirectorateId = new SelectList(db.Directorate, "DirectorateId", "DirectorateName", employee.DirectorateId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            employee.NTLogin = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "CountryName", employee.CountryId);
            ViewBag.LocationId = new SelectList(db.Location, "LocationId", "LocationName", employee.LocationId);
            ViewBag.DirectorateId = new SelectList(db.Directorate, "DirectorateId", "DirectorateName", employee.DirectorateId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Employee employee = db.Employees.Find(id);
            var employeeByLogin = this.db.Employees.Where(o => o.NTLogin.Equals(User.Identity.Name));
            Employee employee = employeeByLogin.FirstOrDefault();

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}