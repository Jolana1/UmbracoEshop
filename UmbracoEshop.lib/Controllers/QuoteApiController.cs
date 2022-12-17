using System;
//using System.Web.UI.WebControls;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Umbraco.Core.Serialization;
using Umbraco.Web.Mvc;
using UmbracoEshop.lib.Repositories;

namespace UmbracoEshop.lib.Controllers
{
    [PluginController("UmbracoEshop")]
    public class QuoteApiController : _BaseApiController
    {
        public string AddProductToQuote(string id)
        {

            try
            {
                string[] items = id.Split('|');                                  /*Z Js getRecords.cshtml sme si id parameter cez znak pipe '|'(palicku) poslali dva spojene parametre pkkod produktu a sessionId*/

                Guid pkProduct = new Guid(items[0]);
                string sessionId = items[1];

                QuoteRepository quoteRep = new QuoteRepository();                /*Na zaklade sessionid sme si nacitali prislušnú objednavku*/
                Quote quote = quoteRep.GetForSession(sessionId);                

                VyrobokRepository rep = new VyrobokRepository();                 
                Vyrobok vyrobok = rep.Get(pkProduct);                            /*Na zaklade pkProduct sme si nacitali prislušný produkt*/

                Product2QuoteRepository repP2q = new Product2QuoteRepository();   /*Na zaklade toho vyššie sme vytvorili novu polozku objednavky s jej parametrami a nakoniec uložili do databazy eshopQuote,eshopProduct2Quote*/
                //Product2Quote quoteItem = new Product2Quote();
                Product2Quote quoteItem = repP2q.Get(quote.pk, vyrobok.pk);
                if (quoteItem == null)                                            /*do hodnoty null nemozem priradovat najprv si musim vytvorit new objekt Product2Quote*/
                {
                quoteItem = new Product2Quote();
                quoteItem.PkQuote = quote.pk;                                      /*K akej objednavke-parameter*/
                quoteItem.PkProduct = pkProduct;                                   /*K akemu vyrobku-produktu*/
                quoteItem.ItemCode = vyrobok.KodVyrobku;                           /*K akemu kodu*/
                quoteItem.ItemName = vyrobok.NazovVyrobku;                         /*K akemu nazvu atd.*/
                quoteItem.UnitPriceNoVat = vyrobok.CenaVyrobku;                    /*cena bez DPH*/
                quoteItem.UnitPriceWithVat = vyrobok.CenaVyrobku;                  /*cena z DPH*/
                quoteItem.ItemPcs = 1;                                             /*pocet kusov*/
                quoteItem.UnitName = "ks";                                         /*merna jednotka*/
                //repP2q.Save(quoteItem);
                }
                else
                {
                    quoteItem.ItemPcs += 1;
                }
                repP2q.Save(quoteItem);
                return string.Format("Pridané do košíka: {0}, {1}", vyrobok.KodVyrobku, vyrobok.NazovVyrobku);
            }
               

                //repP2q.Save(quoteItem);

                //return string.Format("Pridané do košíka: {0}, {1}", vyrobok.KodVyrobku, vyrobok.NazovVyrobku);
            //}
            catch (Exception exc)
            {
                return string.Format("Vznikla chyba pri pridávaní produktu: '{0}' do košíka.{1}", id, exc.ToString());

            }

        

        }
    }
}






   




