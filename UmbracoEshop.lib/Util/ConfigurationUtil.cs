using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoEshop.lib.Util
{
    public class ConfigurationUtil
    {
        public const string LoginFormId = "eshop.LoginFormId";
        public const string AfterLoginFormId = "eshop.AfterLoginFormId";
        public const string AfterPasswordResetFormId = "eshop.AfterPasswordResetFormId";
        public const string EshopZoznamVyrobcovFormId = "eshop.ZoznamVyrobcovFormId";
        public const string EshopZoznamVyrobkovFormId = "eshop.ZoznamVyrobkovFormId";



        public static int GetPageId(string pageKey)
        {
            return int.Parse(ConfigurationManager.AppSettings[pageKey]);
        }

        public static string GetCfgValue(string cfgKey)
        {
            return ConfigurationManager.AppSettings[cfgKey];
        }
    }
}
