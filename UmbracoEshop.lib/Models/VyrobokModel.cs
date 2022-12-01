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
    public class VyrobokModel : _BaseModel
    {
        [Required(ErrorMessage = "Kód výrobku musí byť zadaný")]
        [Display(Name = "Kód výrobku")]
        public string KodVyrobku { get; set; }

        [Required(ErrorMessage = "Názov výrobku musí byť zadaný")]
        [Display(Name = "Názov výrobku")]
        public string NazovVyrobku { get; set; }

        [Required(ErrorMessage = "Cena výrobku musí byť zadaná")]
        [Display(Name = "Cena výrobku")]
        public string CenaVyrobku { get; set; }

        [AllowHtml]
        [Display(Name = "Popis výrobku")]
        public string PopisVyrobku { get; set; }

        public string CenaVyrobkuAMena()
        {
            return PriceUtil.GetPriceStringWithCurrency(this.CenaVyrobku);
        }

        public void CopyDataFrom(Vyrobok src)
        {
            this.pk = src.pk;
            this.NazovVyrobku = src.NazovVyrobku;
            this.KodVyrobku = src.KodVyrobku;
            this.CenaVyrobku = PriceUtil.NumberToEditorString(src.CenaVyrobku);
            this.PopisVyrobku = src.PopisVyrobku;
            
            //this.VyrobokDescription = src.VyrobokDescription;
            //this.VyrobokWeb = src.VyrobokWeb;
        }

        public void CopyDataTo(Vyrobok trg)
        {
            trg.pk = this.pk;
            trg.NazovVyrobku = this.NazovVyrobku;
            trg.KodVyrobku = this.KodVyrobku;
            trg.CenaVyrobku = PriceUtil.NumberFromEditorString(this.CenaVyrobku);
            trg.PopisVyrobku = this.PopisVyrobku;


            //trg.VyrobokDescription = this.VyrobokDescription;
            //trg.VyrobokWeb = this.VyrobokWeb;
        }

        public static VyrobokModel CreateCopyFrom(Vyrobok src)
        {
            VyrobokModel trg = new VyrobokModel();
            trg.CopyDataFrom(src);

            return trg;
        }

        public static Vyrobok CreateCopyFrom(VyrobokModel src)
        {
            Vyrobok trg = new Vyrobok();
            src.CopyDataTo(trg);

            return trg;
        }
    }


    public class VyrobokPagingListModel : _PagingModel
    {
        public List<VyrobokModel> Items { get; set; }

        public static VyrobokPagingListModel CreateCopyFrom(Page<Vyrobok> srcArray)
        {
            VyrobokPagingListModel trgArray = new VyrobokPagingListModel();
            trgArray.ItemsPerPage = (int)srcArray.ItemsPerPage;
            trgArray.TotalItems = (int)srcArray.TotalItems;
            trgArray.Items = new List<VyrobokModel>(srcArray.Items.Count + 1);

            foreach (Vyrobok src in srcArray.Items)
            {
                trgArray.Items.Add(VyrobokModel.CreateCopyFrom(src));
            }

            return trgArray;
        }
    }
}