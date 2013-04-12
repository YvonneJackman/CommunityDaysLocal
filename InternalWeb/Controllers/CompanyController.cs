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

    public class CompanyController : Controller
    {
        private CommunityDaysDb db = new CommunityDaysDb();

        /// <summary>
        /// GET: /Company/
        /// </summary>
        /// <returns>An ActionResult view</returns>
        public ActionResult Index()
        {
            return this.View(this.db.Company.ToList());
        }

        /// <summary>
        /// GET: /Company/Details/5
        /// </summary>
        /// <param name="id">The company id</param>
        /// <returns>An ActionResult view</returns>
        public ActionResult Details(int id = 0)
        {
            Company company = this.db.Company.Find(id);
            if (company == null)
            {
                return this.HttpNotFound();
            }

            return this.View(company);
        }

        /// <summary>
        /// GET: /Company/Create
        /// </summary>
        /// <returns>An ActionResult view</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// POST: /Company/Create
        /// </summary>
        /// <param name="company">The company object</param>
        /// <returns>An ActionResult view</returns>
        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                this.db.Company.Add(company);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(company);
        }

        /// <summary>
        /// GET: /Company/Edit/5
        /// </summary>
        /// <param name="id">The company id</param>
        /// <returns>An ActionResult view</returns>
        public ActionResult Edit(int id = 0)
        {
            Company company = this.db.Company.Find(id);
            if (company == null)
            {
                return this.HttpNotFound();
            }

            return this.View(company);
        }

        /// <summary>
        /// POST: /Company/Edit/5
        /// </summary>
        /// <param name="company">The company object</param>
        /// <returns>An ActionResult view</returns>
        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(company).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(company);
        }

        /// <summary>
        /// GET: /Company/Delete/5
        /// </summary>
        /// <param name="id">The company id</param>
        /// <returns>An ActionResult view</returns>
        public ActionResult Delete(int id = 0)
        {
            Company company = this.db.Company.Find(id);
            if (company == null)
            {
                return this.HttpNotFound();
            }

            return this.View(company);
        }

        /// <summary>
        /// POST: /Company/Delete/5
        /// </summary>
        /// <param name="id">The company id</param>
        /// <returns>An ActionResult view</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = this.db.Company.Find(id);
            this.db.Company.Remove(company);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">Boolean to indicate disposal</param>
        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}