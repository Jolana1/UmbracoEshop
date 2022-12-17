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
       public Quote QuoteData { get; set; }
        
        public List<Product2Quote> QuoteItems { get; set; }

    }
}
