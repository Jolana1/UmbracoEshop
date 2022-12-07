using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;

namespace UmbracoEshop.lib.Controllers
{
    [PluginController("UmbracoEshop")]
    public class QuoteApiController : _BaseApiController
    {
        public string AddProductToQuote(string id)
        {
            return "Je to OK";

        }
    }
}
