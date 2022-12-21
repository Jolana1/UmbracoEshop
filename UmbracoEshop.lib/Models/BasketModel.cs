using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbracoEshop.lib.Repositories;

namespace UmbracoEshop.lib.Models
{
    public class BasketModel
    {
       public QuoteModel Quote { get; set; }
        
        public List<Product2QuoteModel> QuoteItems { get; set; }
        public BasketModel() 
        {
        }
        public BasketModel(string sessionId)                  /*Vytvorime si este aj druhy konstruktor BasketModel do ktoreho posleme sessionId a na zakladeneho sa moze sessionId automaticky nacita zoznam položiek z obj. Quote a QuoteItems*/
        {
            QuoteRepository quoteRep = new QuoteRepository();
            Quote quote = quoteRep.GetForSession(sessionId);
            this.Quote = QuoteModel.CreateCopyFrom(quote);     /*Vytvorime si tu Quotemodel*/

            this.QuoteItems = new List<Product2QuoteModel>();                 /*tu si ukladame obsah položiek košika*/
            Product2QuoteRepository p2qRep = new Product2QuoteRepository();
            foreach (Product2Quote item in p2qRep.GetQuoteItems(quote.pk))   /*tato metoda nacita vsetky položky pre danu objednavku*/
            {
                this.QuoteItems.Add(Product2QuoteModel.CreateCopyFrom(item));

            }


        
        public List<Product2Quote> QuoteItems { get; set; }

    }
}
