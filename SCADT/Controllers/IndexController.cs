using Microsoft.SqlServer.Server;
using SCADT.Models;
using SCADT.Repository;
using SCADT.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCADT.Controllers
{
    public class IndexController : BaseController
    {
        protected SignUpRepository _signUp = null;  
        
        public IndexController()
        {
            _signUp = new SignUpRepository(Context); 
            
        }
        public ActionResult Index(int id)
        {
            if(id <= 0)
            {
                TempData["check"] = "Fara Hacking Te rog";
                return RedirectToAction("Index", "Home");
            }
            var utilizatorFirma = _signUp.Get(id);
            if (utilizatorFirma != null)
            {
                return View(utilizatorFirma);
            }
            else
            {
                TempData["check"] = "Acest cont nu exista in baza de date";
                return RedirectToAction("Index", "Home");
            }
        }

        
    }
}