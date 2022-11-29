using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using UmbracoEshop.lib.Models;
using UmbracoEshop.lib.Repositories;
using UmbracoEshop.lib.Util;

namespace UmbracoEshop.lib.Controllers
{
    [PluginController("UmbracoEshop")]
    [Authorize(Roles = UmbracoEshopMemberRepository.UmbracoEshopMemberAdminRole)]
    public class VyrobokController : _BaseController
    {
        
        public ActionResult GetRecords(int page = 1, string sort = "NazovVyrobku", string sortDir = "ASC")
        {
            try
            {
                return GetRecordsView(page, sort, sortDir);
            }
            catch
            {
                //VyrobokFilterModel filter = GetNaplnspajzuVyrobokFilterForEdit();
                //if (filter != null)
                //{
                //    filter.SearchText = string.Empty;
                //    NaplnspajzuUserPropRepository repository = new NaplnspajzuUserPropRepository();
                //    repository.Save(this.CurrentSessionId, VyrobokFilterModel.CreateCopyFrom(filter));
                //}
                return GetRecordsView(page, sort, sortDir);
            }
        }
        ActionResult GetRecordsView(int page, string sort, string sortDir)
        {
            //VyrobokFilterModel filter = GetNaplnspajzuVyrobokFilterForEdit();

            VyrobokRepository repository = new VyrobokRepository();
            VyrobokPagingListModel model = VyrobokPagingListModel.CreateCopyFrom(
                repository.GetPage(page, _PagingModel.DefaultItemsPerPage, sort, sortDir));
            
            return View(model);
        }

        //[Authorize(Roles = "EcommerceAdmin")]
        public ActionResult InsertRecord()
        {
            return View("EditRecord", new VyrobokModel());
        }

        //[Authorize(Roles = "EcommerceAdmin")]
        public ActionResult EditRecord(string id)
        {
            VyrobokModel model = VyrobokModel.CreateCopyFrom(new VyrobokRepository().Get(new Guid(id)));

            return View(model);
        }
        [HttpPost]
        //[Authorize(Roles = "EcommerceAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRecord(VyrobokModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            if (!new VyrobokRepository().Save(VyrobokModel.CreateCopyFrom(model)))
            {
                ModelState.AddModelError("", "Nastala chyba pri zápise záznamu do systému. Skúste akciu zopakovať a ak sa chyba vyskytne znovu, kontaktujte nás prosím.");
            }
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            return this.RedirectToEshopUmbracoPage(ConfigurationUtil.EshopZoznamVyrobkovFormId);
        }


        //[Authorize(Roles = "EcommerceAdmin")]
        public ActionResult ConfirmDeleteRecord(string id)
        {
            VyrobokModel model = VyrobokModel.CreateCopyFrom(new VyrobokRepository().Get(new Guid(id)));

            return View(model);
        }
        [HttpPost]
        //[Authorize(Roles = "EcommerceAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(VyrobokModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            VyrobokRepository repository = new VyrobokRepository();
            try
            {
                if (!repository.Delete(VyrobokModel.CreateCopyFrom(model)))
                {
                    ModelState.AddModelError("", "Nastala chyba pri zápise záznamu do systému. Skúste akciu zopakovať a ak sa chyba vyskytne znovu, kontaktujte nás prosím.");
                }
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", "Výrobok nie je možné odstrániť.");
                this.Logger.Error(typeof(VyrobokController), "DeleteRecord error", exc);
            }
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            return this.RedirectToEshopUmbracoPage(ConfigurationUtil.EshopZoznamVyrobkovFormId);
        }


        //[Authorize(Roles = "EcommerceAdmin")]
        //public ActionResult GetFilter()
        //{
        //    return View(GetNaplnspajzuVyrobokFilterForEdit());
        //}
        //[HttpPost]
        //[Authorize(Roles = "EcommerceAdmin")]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveFilter(VyrobokFilterModel model)
        //{
        //    model.ModelErrors.Clear();
        //    if (model.ModelErrors.Count == 0)
        //    {
        //        NaplnspajzuUserPropRepository repository = new NaplnspajzuUserPropRepository();
        //        if (!repository.Save(this.CurrentSessionId, VyrobokFilterModel.CreateCopyFrom(model)))
        //        {
        //            model.ModelErrors.Add("Nastala chyba pri zápise záznamu do systému. Skúste akciu zopakovať a ak sa chyba vyskytne znovu, kontaktujte nás prosím.");
        //        }
        //    }
        //    if (model.ModelErrors.Count > 0)
        //    {
        //        return RedirectToCurrentUmbracoPageAfterSaveRecordFilter(model);
        //    }

        //    return RedirectToCurrentUmbracoPageAfterSaveRecordFilter();
        //}
        //RedirectToUmbracoPageResult RedirectToCurrentUmbracoPageAfterSaveRecordFilter(VyrobokFilterModel rec = null)
        //{
        //    SetNaplnspajzuVyrobokFilterForEdit(rec);
        //    return RedirectToCurrentUmbracoPage();
        //}
        //void SetNaplnspajzuVyrobokFilterForEdit(VyrobokFilterModel rec = null)
        //{
        //    TempData["stirilabVyrobokFilterForEdit"] = rec;
        //}
        //VyrobokFilterModel GetNaplnspajzuVyrobokFilterForEdit()
        //{
        //    if (TempData["stirilabVyrobokFilterForEdit"] == null)
        //    {
        //        NaplnspajzuUserPropRepository repository = new NaplnspajzuUserPropRepository();
        //        TempData["stirilabVyrobokFilterForEdit"] = VyrobokFilterModel.CreateCopyFrom(repository.Get(this.CurrentSessionId, ConfigurationUtil.PropId_VyrobokFilterModel));
        //    }

        //    return (VyrobokFilterModel)TempData["stirilabVyrobokFilterForEdit"];
        //}
    }
}
