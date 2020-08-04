using SCADT.Models;
using SCADT.Repository;
using SCADT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace SCADT.Controllers
{
    public class HomeController : BaseController
    {
        protected SignUpRepository _signUp = null;
        public HomeController()
        {
            _signUp = new SignUpRepository(Context);
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Utilizator utilizator)
        {
            if (ModelState.IsValid)
            {
                _signUp.Add(utilizator);
                TempData["check"] = "Contul de utilizator a fost creat cu sucees";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Utilizator viewModel)
        {

            var finde = Context.signUp.Where(e => e.Firma == viewModel.Firma && e.Password == viewModel.Password).SingleOrDefault();
                if (finde != null)
                {
                    Session["Id"] = finde.Id;

                 
                return RedirectToAction("Index", "Index", new { id = (int)Session["Id"] });
            }
            else
            {
                TempData["check"] = "Acest cont de utilizator nu exista in baza de date";
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}