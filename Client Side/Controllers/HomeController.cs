using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectLibrary.DAL;


namespace Client_Side.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IRepo database=new DBRepo();
            IList<projectLibrary.Models.Apartman> apts = database.GetData2();
            return View(apts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}