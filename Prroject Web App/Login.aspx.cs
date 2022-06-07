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
                LoadStatusTableData();
            }

            if (IsPostBack)
            {
                TextBox1.Text = null;
                TextBox2.Text = null;
                TextBox3.Text = null;
                TextBox4.Text = null;
                TextBox5.Text = null;
                TextBoxAddress.Text = null;
                TextBoxAptName.Text = null;
                TextBoxCity.Text = null;
                TextBoxOwner.Text = null;
                // set postback values to null
            }


        }

        private void LoadStatusTableData()
        {
            var db = (IRepo)Application["database"];
            test = db.getStatus();
            Repeater2.DataSource = test;

            Repeater2.DataBind();
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
            TextBoxOwner.Text = test[0].OwnerId.ToString();
            TextBoxCity.Text=test[0].CityId.ToString();
            TextBoxAddress.Text = test[0].Address;
            TextBoxAptName.Text = test[0].Name;

            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
            int[] updateArgs=new int[5];
            updateArgs[0] = int.Parse(TextBox1.Text);
            updateArgs[1] = int.Parse(TextBox2.Text);
            updateArgs[2] = int.Parse(TextBox3.Text);
            updateArgs[3] = int.Parse(TextBox4.Text);
            updateArgs[4] = int.Parse(TextBox5.Text);
            var db = (IRepo)Application["database"];

            
                db.updateApt(updateArgs);
            }
            catch (Exception)
            {

                Label2.Text = "Molimo odaberite apartman";
                return;
            }                                                                                          

            LoadTableData();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void BtnUpdateStatus_Click(object sender, EventArgs e)
        {
            string value = ddlStatus.SelectedItem.Value.Trim();
            int idStatus = 0;
            if (value == "Zauzeto")
            {
                idStatus = 1;
            }
            else if (value=="Rezervirano")
            {
                idStatus = 2;
            }
            else if (value=="Slobodno")
            {
                idStatus = 3;
            }

            if (string.IsNullOrEmpty(LabelID.Text))
            {
LabelName.Text = "Molimo odaberite vrijednost";
                return;
            }
                
            

            var db = (IRepo)Application["database"];

            try
            {
                db.updateStatus(int.Parse(LabelID.Text), idStatus);
            }
            catch (Exception)
            {

                LabelName.Text = "Molimo odaberite vrijednost";
                return;
            }

            LoadStatusTableData();

        }

        protected void LinkEditStatus_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string aptID = btn.CommandArgument.ToString();
            string[] vs = aptID.Split(':');
            LabelName.Text = vs[0];
            LabelID.Text = vs[1];
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                int id = int.Parse(TextBox1.Text);
                var db = (IRepo)Application["database"];
                db.softDeleteApt(id);
            }
            catch (Exception)
            {

                Label2.Text = "Molimo odaberite apartman";
                return;
            }

            LoadTableData();
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            try
            {
                Apartman a = new Apartman
                {
                    TotalRooms = int.Parse(TextBox2.Text),
                    MaxAdults = int.Parse(TextBox3.Text),
                    MaxChildren = int.Parse(TextBox4.Text),
                    BeachDistance = int.Parse(TextBox5.Text),
                    OwnerId = int.Parse(TextBoxOwner.Text),
                    CityId = int.Parse(TextBoxCity.Text),
                    Address = TextBoxAddress.Text,
                    Name = TextBoxAptName.Text
                };
                
                var db = (IRepo)Application["database"];
            db.addApt(a);
            }
            catch (Exception)
            {

                return;  
            }

            
            LoadTableData();
        }

        protected void BtnOwner_Click(object sender, EventArgs e)
        {
            Response.Redirect("Owners.aspx");
        }

        protected void btnCity_Click(object sender, EventArgs e)
        {
            Response.Redirect("CityList.aspx");
        }
    }
}