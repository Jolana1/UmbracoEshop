using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Web.Mvc;
using UmbracoEshop.lib.Util;

namespace UmbracoEshop.lib.Controllers
{
    public class _BaseController : SurfaceController
    {
        public string DefaultImgPath
        {
            get
            {
                return this.HttpContext.Server.MapPath("~/Styles/Images");
            }
        }

        protected RedirectToUmbracoPageResult RedirectToEshopUmbracoPage(string pageKey)
        {
            return this.RedirectToUmbracoPage(GetPageId(pageKey));
        }
        protected RedirectToUmbracoPageResult RedirectToEshopUmbracoPage(string pageKey, string queryString)
        {
            return this.RedirectToUmbracoPage(GetPageId(pageKey), queryString);
        }

        int GetPageId(string pageKey)
        {
            return ConfigurationUtil.GetPageId(pageKey);
        }
    }

    public class _BaseControllerUtil
    {
        public string CurrentSessionId
        {
            get
            {
                return HttpContext.Current.Session.SessionID;
            }
        }
        public HttpRequest CurrentRequest
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        public string SiteRootUrl
        {
            get
            {
                System.Uri uri = this.CurrentRequest.Url;

                return string.Format("{0}://{1}{2}",
                    uri.Scheme,
                    uri.Host,
                    uri.IsDefaultPort ? "" : string.Format(":{0}", uri.Port));
            }
        }

        public string GetAbsoluteUrl(string relativeUrl)
        {
            return string.Format("{0}{1}", this.SiteRootUrl, relativeUrl);
        }
    }
}
