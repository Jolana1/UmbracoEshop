using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web;
using Umbraco.Web;

namespace UmbracoEshop.lib
{
    public class UmbracoEshopApp : UmbracoApplication
    {
        // Init. Set up handlers here.
        public override void Init()
        {
            HttpApplication objApplication = this as HttpApplication;

            objApplication.PreRequestHandlerExecute += PreRequestHandlerExecute;

            base.Init();
        }

        // Called when a session starts.
        private new void PreRequestHandlerExecute(object sender, EventArgs e)
        {
            // Get current session.
            HttpSessionState objSession = ((UmbracoApplication)sender).Context.Session;

            // Make sure that there is an active session.
            if (objSession != null)
            {
                // Work with the session here.
                objSession["umbracoEshopInit"] = 1;
            }
        }
    }
}
