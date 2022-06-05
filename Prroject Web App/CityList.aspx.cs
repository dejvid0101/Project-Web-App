using projectLibrary.DAL;
using projectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prroject_Web_App
{
    public partial class CityList : System.Web.UI.Page
    {
        private IList<Generic> cities;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] s = new string[2];
            s[0] = "admin";
            s[1] = "12345678";
            string[] d = (string[])Application["login"];
            if (d == null)
            {
                Response.Redirect("/");
            }
            if (d[0] == s[0] && d[1] == s[1])
            {

            }

            else
            {
                Response.Redirect("/");
            }

            if (!IsPostBack)
            {
                LoadTableData();
            }
        }

        private void LoadTableData()
        {
            var db = (IRepo)Application["database"];
            cities = db.GetCities();
            rptrCity.DataSource = cities;

            rptrCity.DataBind();
        }
    }
}