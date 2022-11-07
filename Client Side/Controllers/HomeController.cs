using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using projectLibrary.DAL;
using projectLibrary.Models;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;

namespace Client_Side.Controllers
{


    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult AddReview(Client_Side.Models.Review r)
        {
            IRepo db = new DBRepo();
            int result=db.addReview(r);
            if (result==1)
            {
                return Json("Recenzija zaprimljena", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Nešto je pošlo po krivu", JsonRequestBehavior.AllowGet);
            }

        }
       
        public ActionResult AddReservation(Reservation r)
        {
             if (r.CaptchaStatus=="\"\"")
            {
                return Json("Molimo potvrdite da niste robot.", JsonRequestBehavior.AllowGet);
            }

            IRepo database = new DBRepo();
            int result = database.AddReservation(r);

            if (result == 0)
            {
                return Json("Molimo ispravno popunite polje za rezervaciju.", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Rezervacija zaprimljena.", JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public ActionResult GetTags(int id)
        {
            IRepo database = new DBRepo();
            IList<int> tagIds;

            tagIds = database.GetTaggedApts(id);

            IList<projectLibrary.Models.Tag> tags = new List<projectLibrary.Models.Tag>();

            foreach (var tagId in tagIds)
            {
                tags.Add(database.GetTag(tagId));
            }

            return Json(tags, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetReviews(int ApartmentId)
        {
            IRepo database = new DBRepo();
            IList<Client_Side.Models.Review> result;
            result = database.getReviews(ApartmentId);
            return Json(result, JsonRequestBehavior.AllowGet);

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

            if (newList.Count!=0)
            {



                HttpCookie UPTotalRooms = new HttpCookie("UPTotalRooms");
                // ADD EXCEPTION handling for when list is empty
                UPTotalRooms.Value = newList[0].TotalRooms.ToString();
                //out of range exception
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
            }


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