using dufeksoft.lib.Mail;
using dufeksoft.lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UmbracoEshop.lib.Util;
using Mailer = UmbracoEshop.lib.Util.Mailer;

namespace UmbracoEshop.lib.Models
{
    public class OdoslanieSpravyModel
    {
        //[RequiredCurrentLang("Models/OdoslanieSpravyModel", "Meno a priezvisko musia byť zadané")]
        //[DisplayCurrentLang("Models/OdoslanieSpravyModel", "Meno a priezvisko")]
        //public string Name { get; set; }

        //[EmailCurrentLang("Models/OdoslanieSpravyModel", "Neplatný email")]
        //[RequiredCurrentLang("Models/OdoslanieSpravyModel", "E-mail musí byť zadaný")]
        //[DisplayCurrentLang("Models/OdoslanieSpravyModel", "E-mail")]
        //public string Email { get; set; }

        //[RequiredCurrentLang("Models/OdoslanieSpravyModel", "Text správy musí byť zadaný")]
        //[DisplayCurrentLang("Models/OdoslanieSpravyModel", "Text správy")]
        //public string Text { get; set; }

        //[RequiredCurrentLang("Models/OdoslanieSpravyModel", "Heslo musí byť zadané")]
        //[DisplayCurrentLang("Models/OdoslanieSpravyModel", "Heslo")]

        //public string Password { get; set; }


        //public string ConfirmPassword { get; set; }

        //[DisplayCurrentLang("Models/OdoslanieSpravyModel", "Potvrdenie hesla")]
        [Required(ErrorMessage = "Priezvisko a meno musí byť zadané")]
        [Display(Name = "Priezvisko a meno")]
        public string Name { get; set; }
        [Email(ErrorMessage = ModelUtil.invalidEmailErrMessage_Sk)]
        [Required(ErrorMessage = "E-mail musí byť zadaný")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Text správy musí byť zadaný")]
        [Display(Name = "Text správy")]
        public string Text { get; set; }

        [Display(Name = "Heslo")]
        public string Password { get; set; }
        [Display(Name = "Potvrdenie hesla")]
        public string ConfirmPassword { get; set; }

        public bool SendContactRequest()
        {
            List<TextTemplateParam> paramList = new List<TextTemplateParam> { };
            paramList.Add(new TextTemplateParam("NAME", this.Name));
            paramList.Add(new TextTemplateParam("EMAIL", this.Email));
            paramList.Add(new TextTemplateParam("TEXT", this.Text));

            // Odoslanie uzivatelovi
            Mailer.SendMailTemplate(
                "Vaša správa",
                TextTemplate.GetTemplateText("ContactSendSuccess_Sk", paramList),
                this.Email, null);

            return true;
        }
    }
}




