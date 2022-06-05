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
    public partial class Tags : System.Web.UI.Page
    {
        private IList<Tag> test;
        private IList<Generic> types;

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
                test = db.GetTags();
            types = db.GetTagType();
                rptr2.DataSource = test;
            rptrTagType.DataSource=types;
                rptr2.DataBind();
            rptrTagType.DataBind();


           
        }

        protected void btnDeleteTag_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string tg=btn.CommandArgument.ToString();
            var db = (IRepo)Application["database"];
            db.DeleteTag(tg);
            LoadTableData();

        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            try
            {
                Generic gs = new Generic()
                {
                    Name = TextBoxTag.Text,
                    Id = int.Parse(TextBoxTypeID.Text)
                };
                
                var db = (IRepo)Application["database"];
            db.AddTag(gs);
            }
            catch (Exception)
            {

                return;
            }

            

            LoadTableData();
        }

        

        protected void rptr2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblHelper = e.Item.FindControl("fefe") as Label;

                int arg = int.Parse(lblHelper.Text);

                if (arg != 0)
                {
                    LinkButton btn = e.Item.FindControl("btnDeleteTag") as LinkButton;
                    btn.Visible = false;
                }
            }
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}