using projectLibrary.DAL;
using projectLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prroject_Web_App
{
    public partial class Images : System.Web.UI.Page
    {
        private IList<Apartman> test;
        private IList<Generic> imgs;

        
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

        private void LoadImgTableData(int ApartmanId)
        {
            var db = (IRepo)Application["database"];
            imgs = db.GetImages(ApartmanId);
            RepeaterImg.DataSource = imgs;

            RepeaterImg.DataBind();
        }

        private void LoadTableData()
        {
            var db = (IRepo)Application["database"];
            test = db.GetData2();
            Repeater1.DataSource = test;

            Repeater1.DataBind();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Before attempting to perform operations
            // on the file, verify that the FileUpload 
            // control contains a file.
            if (FileUpload1.HasFile)
            {
                string Path = new FileInfo(AppDomain.CurrentDomain.BaseDirectory).Directory.Parent.FullName;
                
                string fileName = FileUpload1.FileName;

                // Append the name of the file to upload to the path.

                string savePath =  Path +@"\Prroject Web App\zz\"+ fileName;


                // Call the SaveAs method to save the 
                // uploaded file to the specified path.
                // This example does not perform all
                // the necessary error checking.               
                // If a file with the same name
                // already exists in the specified path,  
                // the uploaded file overwrites it.
                FileUpload1.SaveAs(savePath);

                // Notify the user of the name of the file
                // was saved under.
                UploadStatusLabel.Text = "Your file was saved as " + fileName;
                LabelAptFileName.Text = fileName;
            }
            else
            {
                // Notify the user that a file was not uploaded.
                UploadStatusLabel.Text = "You did not specify a file to upload.";
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int apartmanID = int.Parse(btn.CommandArgument);
            LoadImgTableData(apartmanID);
            
            LabelAptName.Text= "Apt ID:"+apartmanID.ToString();
            LabelAptId.Text= apartmanID.ToString();

            LinkAppendImg.Text = "Append file to " + LabelAptName.Text;
            LinkAppendImg.Visible = true;

        }

        protected void LinkAppendImg_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile&&(LabelAptFileName.Text == null || LabelAptFileName.Text == ""))
            {
                LabelAptName.ForeColor = System.Drawing.Color.Red;
                LabelAptName.Text = "You didn't choose a file.";
                return;
            }
if (LabelAptFileName.Text==null||LabelAptFileName.Text=="")
            {
                LabelAptName.Text = "You didn't upload a file.";
                return ;
            }
            int aptID = int.Parse(LabelAptId.Text);

            var db = (DBRepo)Application["database"];
            

            
            db.AppendImg($@"zz\{LabelAptFileName.Text}", aptID);
            LoadImgTableData(aptID);
        }
    }
}