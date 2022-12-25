using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbracoEshop.lib.Repositories;
using UmbracoEshop.lib.Util;

namespace UmbracoEshop.lib.Models
{
    public class Product2QuoteModel : _BaseModel
    {
        public Guid PkQuote { get; set; }
        public Guid PkProduct { get; set; }
        public string NonProductId { get; set; }
        public int ItemOrder { get; set; }
        public string ItemPcs { get; set; }
        public string UnitWeight { get; set; }
        public string UnitPriceNoVat { get; set; }
        public string UnitPriceWithVat { get; set; }
        public string VatPerc { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public int UnitTypeId { get; set; }

        public string JednotkovaCenaAMena()
        {
            return PriceUtil.GetPriceStringWithCurrency(this.UnitPriceWithVat);
        }
        public string CelkovaCenaAMena()
        {
            decimal unitPrice = PriceUtil.NumberFromEditorString(this.UnitPriceNoVat);
            decimal num = PriceUtil.NumberFromEditorString(this.ItemPcs);
            decimal totalPrice = unitPrice * num;

            return PriceUtil.GetPriceStringWithCurrency(PriceUtil.NumberToEditorString(totalPrice));
        }
        public void CopyDataFrom(Product2Quote src)
        {
            this.pk = src.pk;
            this.PkQuote = src.PkQuote;
            this.PkProduct = src.PkProduct;
            this.NonProductId= src.NonProductId;
            //this.ItemOrder = src.ItemOrder;
            this.ItemPcs = PriceUtil.NumberToEditorString(src.ItemPcs);
            this.UnitWeight = PriceUtil.NumberToEditorString(src.UnitWeight);
            this.UnitPriceNoVat = PriceUtil.NumberToEditorString(src.UnitPriceNoVat);
            this.UnitPriceWithVat = PriceUtil.NumberToEditorString(src.UnitPriceWithVat);
            this.VatPerc = PriceUtil.NumberToEditorString(src.VatPerc);
            this.ItemCode = src.ItemCode;
            this.ItemName = src.ItemName;
            this.UnitName = src.UnitName;
            this.UnitTypeId = src.UnitTypeId;
        }

        public void CopyDataTo(Product2Quote trg)
        {
            trg.pk = this.pk;
            trg.PkQuote= this.PkQuote;
            trg.PkProduct= this.PkProduct;
            trg.NonProductId= this.NonProductId;
            //trg.ItemOrder= this.ItemOrder;
            trg.ItemPcs = PriceUtil.NumberFromEditorString(this.ItemPcs);
            trg.UnitWeight = PriceUtil.NumberFromEditorString(this.UnitWeight);
            trg.UnitPriceNoVat = PriceUtil.NumberFromEditorString(this.UnitPriceNoVat);
            trg.UnitPriceWithVat = PriceUtil.NumberFromEditorString(this.UnitPriceWithVat);
            trg.VatPerc = PriceUtil.NumberFromEditorString(this.VatPerc);
            trg.ItemCode= this.ItemCode;
            trg.ItemName= this.ItemName;
            trg.UnitName= this.UnitName;
            trg.UnitTypeId= this.UnitTypeId;

        }

        public static Product2QuoteModel CreateCopyFrom(Product2Quote src)
        {
            Product2QuoteModel trg = new Product2QuoteModel();
            trg.CopyDataFrom(src);

            return trg;
        }

        public static Product2Quote CreateCopyFrom(Product2QuoteModel src)
        {
            Product2Quote trg = new Product2Quote();
            src.CopyDataTo(trg);

            return trg;
        }

    }
}
