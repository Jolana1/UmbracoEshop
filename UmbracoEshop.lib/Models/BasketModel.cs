using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbracoEshop.lib.Repositories;
using UmbracoEshop.lib.Util;

namespace UmbracoEshop.lib.Models
{
    public class BasketModel
    {
        public QuoteModel Quote { get; set; }

        public List<Product2QuoteModel> QuoteItems { get; set; }
        public BasketModel()
        {

        }
        public BasketModel(string sessionId)                                     /*Vytvorime si este aj druhy konstruktor BasketModel do ktoreho posleme sessionId a na zaklade neho sa automaticky nacita zoznam položiek z objektov Quote a QuoteItems*/
        {
            QuoteRepository quoteRep = new QuoteRepository();
            Quote quote = quoteRep.GetForSession(sessionId);
            this.Quote = QuoteModel.CreateCopyFrom(quote);                      /*Vytvorime si tu Quotemodel*/

            this.QuoteItems = new List<Product2QuoteModel>();                 /*tu si ukladame obsah položiek košika*/
            Product2QuoteRepository p2qRep = new Product2QuoteRepository();
            foreach (Product2Quote item in p2qRep.GetQuoteItems(quote.pk))   /*tato metoda nacita vsetky položky pre danu objednavku*/
            {
                this.QuoteItems.Add(Product2QuoteModel.CreateCopyFrom(item));

            }

        }

        public string PocetPoloziek()                                           
        {
            decimal numTotal = 0;
            foreach(Product2QuoteModel item in this.QuoteItems)
            {
                decimal num = PriceUtil.NumberFromEditorString(item.ItemPcs);
                numTotal += num;
            }
            /*return this.QuoteItems.Count.ToString(); */                     /*tato metoda return nam vracia celkovy počet produktov*/
            return PriceUtil.NumberToEditorString(numTotal);                /*tato metoda return nam vracia u každej položky kolko ich mame v skutocnosti*/
        }
        public string CenaCelkom()
        {
            return PriceUtil.GetPriceStringWithCurrency(this.Quote.QuotePriceWithVat);
        }
    } 
}
    




       
