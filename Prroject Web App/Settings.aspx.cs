using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prroject_Web_App
{
    public partial class Settings : DefaultPage
    {
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
        }

        protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTheme.SelectedValue!="0")
            {
                HttpCookie themeCookie = new HttpCookie("theme");
                themeCookie.Expires.AddDays(10);
                themeCookie["theme"] = ((DropDownList)sender).SelectedValue;
                themeCookie["index"] = ((DropDownList)sender).ToString();

                Response.Cookies.Add(themeCookie);
                Response.Redirect(Request.Url.LocalPath);
            }
        }

        protected void ddlLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue != "0")
            {
                HttpCookie langCookie = new HttpCookie("lang");
                langCookie.Expires.AddDays(10);
                langCookie["lang"] = ((DropDownList)sender).SelectedValue;
                langCookie["index"] = ((DropDownList)sender).ToString();

                Response.Cookies.Add(langCookie);
                Response.Redirect(Request.Url.LocalPath);
            }
        }
    }
}