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
    public class VyrobcaController : _BaseController
    {
        
        public ActionResult GetRecords(int page = 1, string sort = "NazovVyrobcu", string sortDir = "ASC")
        {
            try
            {
                return GetRecordsView(page, sort, sortDir);
            }
            catch
            {
                //VyrobcaFilterModel filter = GetNaplnspajzuVyrobcaFilterForEdit();
                //if (filter != null)
                //{
                //    filter.SearchText = string.Empty;
                //    NaplnspajzuUserPropRepository repository = new NaplnspajzuUserPropRepository();
                //    repository.Save(this.CurrentSessionId, VyrobcaFilterModel.CreateCopyFrom(filter));
                //}
                return GetRecordsView(page, sort, sortDir);
            }
        }
        ActionResult GetRecordsView(int page, string sort, string sortDir)
        {
            //VyrobcaFilterModel filter = GetNaplnspajzuVyrobcaFilterForEdit();

            VyrobcaRepository repository = new VyrobcaRepository();
            VyrobcaPagingListModel model = VyrobcaPagingListModel.CreateCopyFrom(
                repository.GetPage(page, _PagingModel.DefaultItemsPerPage, sort, sortDir));
            
            return View(model);
        }

        //[Authorize(Roles = "EcommerceAdmin")]
        public ActionResult InsertRecord()
        {
            return View("EditRecord", new VyrobcaModel());
        }

        //[Authorize(Roles = "EcommerceAdmin")]
        public ActionResult EditRecord(string id)
        {
            VyrobcaModel model = VyrobcaModel.CreateCopyFrom(new VyrobcaRepository().Get(new Guid(id)));

            return View(model);
        }
        [HttpPost]
        //[Authorize(Roles = "EcommerceAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult SaveRecord(VyrobcaModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            if (!new VyrobcaRepository().Save(VyrobcaModel.CreateCopyFrom(model)))
            {
                ModelState.AddModelError("", "Nastala chyba pri zápise záznamu do systému. Skúste akciu zopakovať a ak sa chyba vyskytne znovu, kontaktujte nás prosím.");
            }
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            return this.RedirectToEshopUmbracoPage(ConfigurationUtil.EshopZoznamVyrobcovFormId);
        }


        //[Authorize(Roles = "EcommerceAdmin")]
        public ActionResult ConfirmDeleteRecord(string id)
        {
            VyrobcaModel model = VyrobcaModel.CreateCopyFrom(new VyrobcaRepository().Get(new Guid(id)));

            return View(model);
        }
        [HttpPost]
        //[Authorize(Roles = "EcommerceAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecord(VyrobcaModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            VyrobcaRepository repository = new VyrobcaRepository();
            try
            {
                if (!repository.Delete(VyrobcaModel.CreateCopyFrom(model)))
                {
                    ModelState.AddModelError("", "Nastala chyba pri zápise záznamu do systému. Skúste akciu zopakovať a ak sa chyba vyskytne znovu, kontaktujte nás prosím.");
                }
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("", "Výrobcu nie je možné odstrániť pretože je priradený k niektorým produktom.");
                this.Logger.Error(typeof(VyrobcaController), "DeleteRecord error", exc);
            }
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            return this.RedirectToEshopUmbracoPage(ConfigurationUtil.EshopZoznamVyrobcovFormId);
        }


        //[Authorize(Roles = "EcommerceAdmin")]
        //public ActionResult GetFilter()
        //{
        //    return View(GetNaplnspajzuVyrobcaFilterForEdit());
        //}
        //[HttpPost]
        //[Authorize(Roles = "EcommerceAdmin")]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveFilter(VyrobcaFilterModel model)
        //{
        //    model.ModelErrors.Clear();
        //    if (model.ModelErrors.Count == 0)
        //    {
        //        NaplnspajzuUserPropRepository repository = new NaplnspajzuUserPropRepository();
        //        if (!repository.Save(this.CurrentSessionId, VyrobcaFilterModel.CreateCopyFrom(model)))
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
        //RedirectToUmbracoPageResult RedirectToCurrentUmbracoPageAfterSaveRecordFilter(VyrobcaFilterModel rec = null)
        //{
        //    SetNaplnspajzuVyrobcaFilterForEdit(rec);
        //    return RedirectToCurrentUmbracoPage();
        //}
        //void SetNaplnspajzuVyrobcaFilterForEdit(VyrobcaFilterModel rec = null)
        //{
        //    TempData["stirilabVyrobcaFilterForEdit"] = rec;
        //}
        //VyrobcaFilterModel GetNaplnspajzuVyrobcaFilterForEdit()
        //{
        //    if (TempData["stirilabVyrobcaFilterForEdit"] == null)
        //    {
        //        NaplnspajzuUserPropRepository repository = new NaplnspajzuUserPropRepository();
        //        TempData["stirilabVyrobcaFilterForEdit"] = VyrobcaFilterModel.CreateCopyFrom(repository.Get(this.CurrentSessionId, ConfigurationUtil.PropId_VyrobcaFilterModel));
        //    }

        //    return (VyrobcaFilterModel)TempData["stirilabVyrobcaFilterForEdit"];
        //}
    }
}
