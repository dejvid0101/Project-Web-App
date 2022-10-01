using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectLibrary.DAL;
using projectLibrary.Models;

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

        [HttpPost]
        // retrieve apts with attributes from db
        public ActionResult Index(IList<projectLibrary.Models.Apartman> um)
        {
            IList<projectLibrary.Models.Apartman> newlist=new List<projectLibrary.Models.Apartman>();
            IRepo db=new DBRepo();
            newlist=db.IndexFilter(um);
            return View(newlist);
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