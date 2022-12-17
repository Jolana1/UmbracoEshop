using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoEshop.lib.Models;
using UmbracoEshop.lib.Repositories;

namespace UmbracoEshop.lib.Controllers
{
    [PluginController("UmbracoEshop")]
    public class QuoteController : _BaseController
    {
        public ActionResult Basket()
        {
            return View();
        }
    }
}