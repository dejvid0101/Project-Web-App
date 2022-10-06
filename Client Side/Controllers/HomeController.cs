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
            IList<Generic> paths = null;
            foreach (Apartman apt in apts)
            {
                paths = database.GetImages(apt.Id);
                if (paths.Count>0)
                {
apt.HelperPicturePath = paths[0].Name;
                }
                
            }

            return View(apts);
        }

        [HttpPost]
        // retrieve apts with attributes from db
        public ActionResult Index(IList<projectLibrary.Models.Apartman> um)
        {
            IList<projectLibrary.Models.Apartman> newlist=new List<projectLibrary.Models.Apartman>();
            IRepo db=new DBRepo();
            newlist=db.IndexFilter(um);
            foreach (projectLibrary.Models.Apartman apt in newlist)
            {
                apt.DropDownEnum = um[0].DropDownEnum;
            }

            IList<Generic> paths = null;

            foreach (Apartman apt in newlist)
            {
                paths = db.GetImages(apt.Id);
                if (paths.Count > 0)
                {
                    apt.HelperPicturePath = paths[0].Name;
                }

            }

            HttpCookie UPTotalRooms = new HttpCookie("UPTotalRooms");
            // ADD EXCEPTION handling for when list is empty
            UPTotalRooms.Value = newlist[0].TotalRooms.ToString();
            UPTotalRooms.Expires.AddDays(5);

            HttpCookie UPMaxAdults = new HttpCookie("UPMaxAdults");
            UPMaxAdults.Value = newlist[0].MaxAdults.ToString();
            UPMaxAdults.Expires.AddDays(5);

            HttpCookie UPMaxChildren = new HttpCookie("UPMaxChildren");
            UPMaxChildren.Value = newlist[0].MaxChildren.ToString();
            UPMaxChildren.Expires.AddDays(5);

            HttpCookie UPSorting = new HttpCookie("UPSorting");
            UPSorting.Value = newlist[0].DropDownEnum.ToString();
            UPSorting.Expires.AddDays(5);

            Response.Cookies.Add(UPTotalRooms);
            Response.Cookies.Add(UPMaxAdults);
            Response.Cookies.Add(UPMaxChildren);
            Response.Cookies.Add(UPSorting);


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