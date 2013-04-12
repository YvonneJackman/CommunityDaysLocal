namespace InternalWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        /// <summary>
        /// GET: /Admin/
        /// </summary>
        /// <returns>An ActionResult view</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}