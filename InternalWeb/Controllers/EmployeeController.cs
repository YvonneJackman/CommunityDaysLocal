namespace InternalWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Migrations;
    using Data.Model;
    
    public class EmployeeController : Controller
    {
        private CommunityDaysDb db = new CommunityDaysDb();

        // GET: /Employee/
        public ActionResult Index()
        {
            var employees = this.db.Employees.Include(e => e.Country).Include(e => e.Location).Include(e => e.Directorate).Include(e => e.Department);
            return this.View(employees.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int id = 0)
        {
            //Employee employee = db.Employees.Find(id); todo
            var employeeByLogin = this.db.Employees.Where(o => o.NTLogin.Equals(User.Identity.Name));
            Employee employee = employeeByLogin.FirstOrDefault();

            if (employee == null)
            {
                return this.HttpNotFound();
            }

            return this.View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.NTLogin = User.Identity.Name;
            ViewBag.CountryId = new SelectList(this.db.Country, "CountryId", "CountryName");
            ViewBag.LocationId = new SelectList(this.db.Location, "LocationId", "LocationName");
            ViewBag.DirectorateId = new SelectList(this.db.Directorate, "DirectorateId", "DirectorateName");
            ViewBag.DepartmentId = new SelectList(this.db.Department, "DepartmentId", "DepartmentName");
            return this.View();
        }

        // POST: /Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employee.NTLogin = User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.db.Employees.Add(employee);
                this.db.SaveChanges();
                var newId = employee.EmployeeId;
                return this.RedirectToAction("Details", newId);
            }

            ViewBag.CountryId = new SelectList(this.db.Country, "CountryId", "CountryName", employee.CountryId);
            ViewBag.LocationId = new SelectList(this.db.Location, "LocationId", "LocationName", employee.LocationId);
            ViewBag.DirectorateId = new SelectList(this.db.Directorate, "DirectorateId", "DirectorateName", employee.DirectorateId);
            ViewBag.DepartmentId = new SelectList(this.db.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return this.View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int id = 0)
        {
            ViewBag.NTLogin = User.Identity.Name;
            //Employee employee = db.Employees.Find(id); todo
            var employeeByLogin = this.db.Employees.Where(o => o.NTLogin.Equals(User.Identity.Name));
            Employee employee = employeeByLogin.FirstOrDefault();

            if (employee == null)
            {
                return this.RedirectToAction("Create");
            }

            ViewBag.CountryId = new SelectList(this.db.Country, "CountryId", "CountryName", employee.CountryId);
            ViewBag.LocationId = new SelectList(this.db.Location, "LocationId", "LocationName", employee.LocationId);
            ViewBag.DirectorateId = new SelectList(this.db.Directorate, "DirectorateId", "DirectorateName", employee.DirectorateId);
            ViewBag.DepartmentId = new SelectList(this.db.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return this.View(employee);
        }

        // POST: /Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            employee.NTLogin = User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.db.Entry(employee).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index", "Home");
            }

            ViewBag.CountryId = new SelectList(this.db.Country, "CountryId", "CountryName", employee.CountryId);
            ViewBag.LocationId = new SelectList(this.db.Location, "LocationId", "LocationName", employee.LocationId);
            ViewBag.DirectorateId = new SelectList(this.db.Directorate, "DirectorateId", "DirectorateName", employee.DirectorateId);
            ViewBag.DepartmentId = new SelectList(this.db.Department, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return this.View(employee);
        }
        
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id = 0)
        {
            //Employee employee = db.Employees.Find(id); todo
            var employeeByLogin = this.db.Employees.Where(o => o.NTLogin.Equals(User.Identity.Name));
            Employee employee = employeeByLogin.FirstOrDefault();

            if (employee == null)
            {
                return this.HttpNotFound();
            }

            return this.View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = this.db.Employees.Find(id);
            this.db.Employees.Remove(employee);
            this.db.SaveChanges();
            return this.RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}