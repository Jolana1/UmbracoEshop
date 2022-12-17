//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoEshop.lib.Models;
using UmbracoEshop.lib.Repositories;

namespace UmbracoEshop.lib.Controllers
{
    [PluginController("UmbracoEshop")]
    public class PublicProductController : _BaseController
    {
        public ActionResult GetRecords(int page = 1, string sort = "NazovVyrobku", string sortDir = "ASC")
        {
            try
            {
                return GetRecordsView(page, sort, sortDir);
            }
            catch
            {

                return GetRecordsView(page, sort, sortDir);
            }
        }

        ActionResult GetRecordsView(int page, string sort, string sortDir)
        {


            VyrobokRepository repository = new VyrobokRepository();
            VyrobokPagingListModel model = VyrobokPagingListModel.CreateCopyFrom(
                repository.GetPage(page, _PagingModel.AllItemsPerPage/*DefaultItemsPerPage*/, sort, sortDir)
                );

            model.SessionId = this.CurrentSessionId;

            return View(model);
        } 
    }
}