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
        [HttpGet]
        public ActionResult GetTags(int id)
        {
            IRepo database = new DBRepo();
            IList<int> tagIds;

            tagIds = database.GetTaggedApts(id);

            IList<projectLibrary.Models.Tag> tags=new List<projectLibrary.Models.Tag>();

            foreach (var tagId in tagIds)
            {
                tags.Add(database.GetTag(tagId));
            }
            
            return Json(tags,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            IRepo database = new DBRepo();
            IList<Apartman> apts;

            apts = database.Retrieve(id);

            IList<Generic> paths;

            foreach (Apartman a in apts)
            {
                
                paths = database.GetImages(a.Id);
                if (paths.Count > 0)
                {
                    // create image list attr on model to get all
                    a.HelperPicturePathCollection = paths;
                }

            }

            Apartman apt = apts[0];
           
            return View(apt);
        }

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

        // page doesn't refresh when receiving input from controller/server

        [HttpPost]
        // retrieve apts with attributes from db
        public ActionResult Index(Apartman um)
        {
            IList<projectLibrary.Models.Apartman> newList=new List<projectLibrary.Models.Apartman>();
            IRepo db=new DBRepo();
            newList=db.IndexFilter(um);
            foreach (projectLibrary.Models.Apartman apt in newList)
            {
                apt.DropDownEnum = um.DropDownEnum;
            }

            IList<Generic> paths = null;

            foreach (Apartman apt in newList)
            {
                paths = db.GetImages(apt.Id);
                if (paths.Count > 0)
                {
                    apt.HelperPicturePath = paths[0].Name;
                }

            }

            HttpCookie UPTotalRooms = new HttpCookie("UPTotalRooms");
            // ADD EXCEPTION handling for when list is empty
            UPTotalRooms.Value = newList[0].TotalRooms.ToString();
            UPTotalRooms.Expires.AddDays(5);

            HttpCookie UPMaxAdults = new HttpCookie("UPMaxAdults");
            UPMaxAdults.Value = newList[0].MaxAdults.ToString();
            UPMaxAdults.Expires.AddDays(5);

            HttpCookie UPMaxChildren = new HttpCookie("UPMaxChildren");
            UPMaxChildren.Value = newList[0].MaxChildren.ToString();
            UPMaxChildren.Expires.AddDays(5);

            HttpCookie UPSorting = new HttpCookie("UPSorting");
            UPSorting.Value = newList[0].DropDownEnum;
            UPSorting.Expires.AddDays(5);

            Response.Cookies.Add(UPTotalRooms);
            Response.Cookies.Add(UPMaxAdults);
            Response.Cookies.Add(UPMaxChildren);
            Response.Cookies.Add(UPSorting);


            return Json(newList,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetApts()
        {
            IRepo database = new DBRepo();
            IList<projectLibrary.Models.Apartman> apts = database.GetData2();
            IList<Generic> paths = null;
            foreach (Apartman apt in apts)
            {
                paths = database.GetImages(apt.Id);
                if (paths.Count > 0)
                {
                    apt.HelperPicturePath = paths[0].Name;
                }

            }

            return Json(apts,JsonRequestBehavior.AllowGet);
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