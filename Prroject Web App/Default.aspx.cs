using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prroject_Web_App
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["login"] != null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

                if (Page.IsValid)
            {
                string[] s=new string[2];
            s[0] = exampleInputEmail1.Text;
            s[1] = exampleInputPassword1.Text;

            Application["login"] = s;
                Response.Redirect("Login.aspx");


            }

            
        }
    }
}