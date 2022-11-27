using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using UmbracoEshop.lib.Util;
using UmbracoEshop.lib.Repositories;

namespace UmbracoEshop.lib.Models
{
    public class VyrobcaModel : _BaseModel
    {
        [Required(ErrorMessage = "Názov výrobcu musí byť zadaný")]
        [Display(Name = "Názov výrobcu")]
        public string NazovVyrobcu { get; set; }

        //[AllowHtml]
        //[Display(Name = "Popis výrobcu")]
        //public string VyrobcaDescription { get; set; }

        //[Display(Name = "Webová stránka")]
        //public string VyrobcaWeb { get; set; }

        public void CopyDataFrom(Vyrobca src)
        {
            this.pk = src.pk;
            this.NazovVyrobcu = src.NazovVyrobcu;
            //this.VyrobcaDescription = src.VyrobcaDescription;
            //this.VyrobcaWeb = src.VyrobcaWeb;
        }

        public void CopyDataTo(Vyrobca trg)
        {
            trg.pk = this.pk;
            trg.NazovVyrobcu = this.NazovVyrobcu;
            //trg.VyrobcaDescription = this.VyrobcaDescription;
            //trg.VyrobcaWeb = this.VyrobcaWeb;
        }

        public static VyrobcaModel CreateCopyFrom(Vyrobca src)
        {
            VyrobcaModel trg = new VyrobcaModel();
            trg.CopyDataFrom(src);

            return trg;
        }

        public static Vyrobca CreateCopyFrom(VyrobcaModel src)
        {
            Vyrobca trg = new Vyrobca();
            src.CopyDataTo(trg);

            return trg;
        }
    }

    //public class VyrobcaListModel : List<VyrobcaModel>
    //{
    //    public HttpRequest CurrentRequest { get; private set; }
    //    public string SessionId { get; set; }
    //    public int PageSize { get; private set; }

    //    private GridPagerModel currentPager;
    //    public GridPagerModel Pager
    //    {
    //        get
    //        {
    //            return GetPager();
    //        }
    //    }

    //    public VyrobcaListModel(HttpRequest request, int pageSize = 25)
    //    {
    //        this.CurrentRequest = request;
    //        this.PageSize = pageSize;
    //    }

    //    public List<VyrobcaModel> GetPageItems()
    //    {
    //        GridPageInfo cpi = this.Pager.GetCurrentPageInfo();

    //        List<VyrobcaModel> resultList = new List<VyrobcaModel>();
    //        for (int i = cpi.FirsItemIndex; i < this.Count && i < cpi.LastItemIndex + 1; i++)
    //        {
    //            resultList.Add(this[i]);
    //        }

    //        return resultList;
    //    }

    //    GridPagerModel GetPager()
    //    {
    //        if (this.currentPager == null || this.currentPager.ItemCnt != this.Count)
    //        {
    //            this.currentPager = new GridPagerModel(this.CurrentRequest, this.Count, this.PageSize);
    //        }

    //        return this.currentPager;
    //    }
    //}

    public class VyrobcaPagingListModel : _PagingModel
    {
        public List<VyrobcaModel> Items { get; set; }

        public static VyrobcaPagingListModel CreateCopyFrom(Page<Vyrobca> srcArray)
        {
            VyrobcaPagingListModel trgArray = new VyrobcaPagingListModel();
            trgArray.ItemsPerPage = (int)srcArray.ItemsPerPage;
            trgArray.TotalItems = (int)srcArray.TotalItems;
            trgArray.Items = new List<VyrobcaModel>(srcArray.Items.Count + 1);

            foreach (Vyrobca src in srcArray.Items)
            {
                trgArray.Items.Add(VyrobcaModel.CreateCopyFrom(src));
            }

            return trgArray;
        }
    }

    //public class VyrobcaFilterModel : _BaseUserPropModel
    //{

    //    [Display(Name = "Vyhľadávanie (názov, popis, web ...)")]
    //    public string SearchText { get; set; }


    //    public VyrobcaFilterModel()
    //    {
    //        this.PropId = ConfigurationUtil.PropId_VyrobcaFilterModel;
    //    }

    //    public static VyrobcaFilterModel CreateCopyFrom(NaplnspajzuUserProp src)
    //    {
    //        VyrobcaFilterModel trg = new VyrobcaFilterModel();
    //        if (src != null)
    //        {
    //            trg.CopyDataFrom(src);
    //        }
    //        trg.UpdateBeforeEdit();

    //        return trg;
    //    }

    //    public static NaplnspajzuUserProp CreateCopyFrom(VyrobcaFilterModel src)
    //    {
    //        src.UpdateAfterEdit();
    //        NaplnspajzuUserProp trg = new NaplnspajzuUserProp();
    //        src.CopyDataTo(trg);

    //        return trg;
    //    }


    //    public void UpdateBeforeEdit()
    //    {
    //        LoadPropValue(this.PropValue);
    //    }

    //    public void UpdateAfterEdit()
    //    {
    //        this.PropValue = SavePropValue();
    //    }

    //    private string SavePropValue()
    //    {
    //        // Create XML document
    //        XmlDocument doc = new XmlDocument();
    //        // Create main element
    //        XmlElement mainNode = doc.CreateElement("VyrobcaFilterModel");
    //        mainNode.SetAttribute("version", "1.0");
    //        doc.AppendChild(mainNode);

    //        // Search text
    //        XmlParamSet.SaveItem(doc, mainNode, "SearchText", this.SearchText);

    //        return doc.InnerXml;
    //    }

    //    private void LoadPropValue(string propValue)
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        if (!string.IsNullOrEmpty(propValue))
    //        {
    //            doc.LoadXml(propValue);

    //            string fullParent = "VyrobcaFilterModel";

    //            // Search text
    //            this.SearchText = XmlParamSet.LoadItem(doc, fullParent, "SearchText", string.Empty);
    //        }
    //    }
    //}

    //public class VyrobcaPagerModel
    //{
    //    public string Url { get; set; }
    //    public string Name { get; set; }
    //    public bool IsCurrent { get; set; }
    //}

    //public class VyrobcaDropDown : CmpDropDown
    //{
    //    public VyrobcaDropDown()
    //    {
    //    }

    //    public static VyrobcaDropDown CreateFromRepository(bool allowNull, string emptyText = "[ nezadané ]")
    //    {
    //        VyrobcaProducerRepository repository = new VyrobcaProducerRepository();
    //        return VyrobcaDropDown.CreateCopyFrom(repository.GetPage(1, _PagingModel.AllItemsPerPage), allowNull, emptyText);
    //    }

    //    public static VyrobcaDropDown CreateCopyFrom(Page<VyrobcaProducer> dataList, bool allowNull, string emptyText)
    //    {
    //        VyrobcaDropDown ret = new VyrobcaDropDown();

    //        if (allowNull)
    //        {
    //            ret.AddItem(emptyText, Guid.Empty.ToString(), null);
    //        }
    //        foreach (VyrobcaProducer dataItem in dataList.Items)
    //        {
    //            VyrobcaModel dataModel = VyrobcaModel.CreateCopyFrom(dataItem);
    //            ret.AddItem(dataModel.NazovVyrobcu, dataModel.pk.ToString(), dataModel);
    //        }

    //        return ret;
    //    }
    //}

}
