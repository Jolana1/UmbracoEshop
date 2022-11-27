using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Mvc;

namespace UmbracoEshop.lib.Models
{
    public class _BaseModel
    {
        [Display(Name = "PK")]
        public Guid pk { get; set; }
        public List<string> ModelErrors = new List<string>();

        public _BaseModel()
        {
        }

        public virtual bool IsNew
        {
            get
            {
                return pk == null || pk == Guid.Empty;
            }
        }
    }
    public class _PagingModel
    {
        public const int DefaultItemsPerPage = 20;
        public const int AllItemsPerPage = 100000000;

        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public _PagingModel()
        {
            ItemsPerPage = DefaultItemsPerPage;
        }
    }

    public class _SeoViewPage : UmbracoViewPage
    {
        public override void Execute()
        {
        }

        //public _SeoModel GetCurrentSeoModel()
        //{
        //    if (this.TempData.ContainsKey(_SeoModel.TemDataKey))
        //    {
        //        return (_SeoModel)this.TempData[_SeoModel.TemDataKey];
        //    }
        //    else
        //    {
        //        IPublishedContent model = this.Model;

        //        return new _SeoModel()
        //        {
        //            MenuTitle = model.Value("menuTitle").ToString(),
        //            MetaTitle = model.Value("pageTitle").ToString(),
        //            MetaDescription = model.Value("metaDescription").ToString(),
        //        };
        //    }
        //}
    }
    public class UmbracoEshopViewPage : _SeoViewPage
    {
        public override void Execute()
        {
        }

        //public _EshopModel GetCurrentEshopModel()
        //{
        //    if (!this.TempData.ContainsKey(_EshopModel.TemDataKey))
        //    {
        //        this.TempData[_EshopModel.TemDataKey] = new _EshopModel() { CurrentProductCategory = null };
        //    }

        //    return (_EshopModel)this.TempData[_EshopModel.TemDataKey];
        //}
    }
}
