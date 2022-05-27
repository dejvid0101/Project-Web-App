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
                // make table refresh when updated
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
            var db = (IRepo)Application["database"];
            test=db.Retrieve(apartmanID);
            TextBox1.Text = test[0].Id.ToString();
            TextBox2.Text = test[0].TotalRooms.ToString();
            TextBox3.Text = test[0].MaxAdults.ToString();
            TextBox4.Text = test[0].MaxChildren.ToString();
            TextBox5.Text = test[0].BeachDistance.ToString();

            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int[] updateArgs=new int[5];
            updateArgs[0] = int.Parse(TextBox1.Text);
            updateArgs[1] = int.Parse(TextBox2.Text);
            updateArgs[2] = int.Parse(TextBox3.Text);
            updateArgs[3] = int.Parse(TextBox4.Text);
            updateArgs[4] = int.Parse(TextBox5.Text);
            var db = (IRepo)Application["database"];

            db.updateApt(updateArgs);                                                                                           

            LoadTableData();
        }
    }
}