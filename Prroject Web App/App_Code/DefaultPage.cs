using System;

namespace Prroject_Web_App
{
    public class DefaultPage: System.Web.UI.Page
    {
        public DefaultPage()
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            if (Request.Cookies["theme"]!=null)
            {
                if (Request.Cookies["theme"]["theme"]!=null)
                {
                    Theme = Request.Cookies["theme"]["theme"];
                }

            }

            base.OnPreInit(e);
        }
    }
}