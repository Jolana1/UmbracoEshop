using NPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UmbracoEshop.lib.Repositories;
using UmbracoEshop.lib.Util;

namespace UmbracoEshop.lib.Models
{
    public class QuoteModel : _BaseModel                                                       /*tento model je vlastne obsah položiek košika*/
    {

        public string DateCreate { get; set; }
        public string DateFinished { get; set; }
        public string SessionId { get; set; }
        public string FinishedSessionId { get; set; }
        public int QuoteYear { get; set; }
        public int QuoteNumber { get; set; }

        public string QuotePriceNoVat { get; set; }
        public string QuotePriceWithVat { get; set; }

        public string QuoteState { get; set; }
        public string QuotePriceState { get; set; }
        public string Note { get; set; }


        public void CopyDataFrom(Quote src)
        {
            this.pk = src.pk;
            this.DateCreate = DateTimeUtil.GetDisplayDate(src.DateCreate);
            this.DateFinished = DateTimeUtil.GetDisplayDate(src.DateFinished);
            this.SessionId = src.SessionId;
            this.FinishedSessionId = src.FinishedSessionId;
            this.QuoteYear = src.QuoteYear;
            this.QuoteNumber = src.QuoteNumber;
            this.QuotePriceNoVat = PriceUtil.NumberToEditorString(src.QuotePriceNoVat);
            this.QuotePriceWithVat = PriceUtil.NumberToEditorString(src.QuotePriceWithVat);
            this.QuoteState = src.QuoteState;
            this.QuotePriceState = src.QuotePriceState;
            this.Note = src.Note;
        }

        public void CopyDataTo(Quote trg)
        {
            trg.pk = this.pk;
            trg.DateCreate = DateTimeUtil.DisplayDateToDate(this.DateCreate).Value;
            trg.DateFinished = DateTimeUtil.DisplayDateToDate(this.DateFinished);
            trg.SessionId = this.SessionId;
            trg.FinishedSessionId = this.FinishedSessionId;
            trg.QuoteYear = this.QuoteYear;
            trg.QuoteNumber = this.QuoteNumber;
            trg.QuotePriceNoVat = PriceUtil.NumberFromEditorString(this.QuotePriceNoVat);
            trg.QuotePriceWithVat = PriceUtil.NumberFromEditorString(this.QuotePriceWithVat);
            trg.QuoteState = this.QuoteState;
            trg.QuoteState = this.QuotePriceState;
            trg.Note = this.Note;

        }

        public static QuoteModel CreateCopyFrom(Quote src)
        {
            QuoteModel trg = new QuoteModel();
            trg.CopyDataFrom(src);

            return trg;
        }

        public static Quote CreateCopyFrom(QuoteModel src)
        {
            Quote trg = new Quote();
            src.CopyDataTo(trg);

            return trg;
        }
    }

    //public class QuoteListModel : List<QuoteModel>
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

    //    public QuoteListModel(HttpRequest request, int pageSize = 25)
    //    {
    //        this.CurrentRequest = request;
    //        this.PageSize = pageSize;
    //    }

    //    public List<QuoteModel> GetPageItems()
    //    {
    //        GridPageInfo cpi = this.Pager.GetCurrentPageInfo();

    //        List<QuoteModel> resultList = new List<QuoteModel>();
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

    //public class QuotePagingListModel : _PagingModel
    //{
    //    public List<QuoteModel> Items { get; set; }

    //    public static QuotePagingListModel CreateCopyFrom(Page<Quote> srcArray)
    //    {
    //        QuotePagingListModel trgArray = new QuotePagingListModel();
    //        trgArray.ItemsPerPage = (int)srcArray.ItemsPerPage;
    //        trgArray.TotalItems = (int)srcArray.TotalItems;
    //        trgArray.Items = new List<QuoteModel>(srcArray.Items.Count + 1);

    //        foreach (Quote src in srcArray.Items)
    //        {
    //            trgArray.Items.Add(QuoteModel.CreateCopyFrom(src));
    //        }

    //        return trgArray;
    //    }
    //}

    //public class QuoteFilterModel : _BaseUserPropModel
    //{

    //    [Display(Name = "Vyhľadávanie (názov, popis, web ...)")]
    //    public string SearchText { get; set; }


    //    public QuoteFilterModel()
    //    {
    //        this.PropId = ConfigurationUtil.PropId_QuoteFilterModel;
    //    }

    //    public static QuoteFilterModel CreateCopyFrom(NaplnspajzuUserProp src)
    //    {
    //        QuoteFilterModel trg = new QuoteFilterModel();
    //        if (src != null)
    //        {
    //            trg.CopyDataFrom(src);
    //        }
    //        trg.UpdateBeforeEdit();

    //        return trg;
    //    }

    //    public static NaplnspajzuUserProp CreateCopyFrom(QuoteFilterModel src)
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
    //        XmlElement mainNode = doc.CreateElement("QuoteFilterModel");
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

    //            string fullParent = "QuoteFilterModel";

    //            // Search text
    //            this.SearchText = XmlParamSet.LoadItem(doc, fullParent, "SearchText", string.Empty);
    //        }
    //    }
    //}

    //public class QuotePagerModel
    //{
    //    public string Url { get; set; }
    //    public string Name { get; set; }
    //    public bool IsCurrent { get; set; }
    //}

    //public class QuoteDropDown : CmpDropDown
    //{
    //    public QuoteDropDown()
    //    {
    //    }

    //    public static QuoteDropDown CreateFromRepository(bool allowNull, string emptyText = "[ nezadané ]")
    //    {
    //        QuoteProducerRepository repository = new QuoteProducerRepository();
    //        return QuoteDropDown.CreateCopyFrom(repository.GetPage(1, _PagingModel.AllItemsPerPage), allowNull, emptyText);
    //    }

    //    public static QuoteDropDown CreateCopyFrom(Page<QuoteProducer> dataList, bool allowNull, string emptyText)
    //    {
    //        QuoteDropDown ret = new QuoteDropDown();

    //        if (allowNull)
    //        {
    //            ret.AddItem(emptyText, Guid.Empty.ToString(), null);
    //        }
    //        foreach (QuoteProducer dataItem in dataList.Items)
    //        {
    //            QuoteModel dataModel = QuoteModel.CreateCopyFrom(dataItem);
    //            ret.AddItem(dataModel.NazovVyrobcu, dataModel.pk.ToString(), dataModel);
    //        }

    //        return ret;
    //    }
    //}

}


