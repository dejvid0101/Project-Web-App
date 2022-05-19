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
    public partial class Login : System.Web.UI.Page
    {

        private IList<Apartman> test;

        protected void Page_Load(object sender, EventArgs e)
        {



            var db = (IRepo)Application["database"];
            projectLibrary.Models.Apartman testApartman = db.Retrieve(3);



            exampleInputEmail1.Text = testApartman.ToString();

            string[] s=new string[2];
            s[0] = "admin";
            s[1] = "12345678";
            string[] d= (string[])Application["login"];
            if (d==null)
            {
                Response.Redirect("/");
            }
            if (d[0]==s[0]&&d[1]==s[1])
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
            test = db.GetData2();
            Repeater1.DataSource = test;
            
            Repeater1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn=sender as LinkButton;
            int apartmanID=int.Parse(btn.CommandArgument);

        }
    }
}