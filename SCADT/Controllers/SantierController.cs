using SCADT.Models;
using SCADT.Repository;
using SCADT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using System.Web.Mvc;

namespace SCADT.Controllers
{
    public class SantierController : BaseController
    {
        protected SantierRepository _santier = null;
        protected AngajatRepository _angajat = null;
        protected UtilajRepository _utilaj = null;
        protected FunctiRepository _functi = null;
        protected Angajati_Santier _angajati_santier = null;
        protected UtilajePentruSantierRepository _utilaje_santier = null;
        public SantierController()
        {
            _santier = new SantierRepository(Context);
            _angajat = new AngajatRepository(Context);
            _utilaj = new UtilajRepository(Context);
            _functi = new FunctiRepository(Context);
            _angajati_santier = new Angajati_Santier(Context);
            _utilaje_santier = new UtilajePentruSantierRepository(Context);
        }

        public ActionResult Index(int? id)
        {
            if(id <= 0)
            {
                return RedirectToAction("Index", "Index");
            }
            var item = Context.Santiere.Where(e => e.IdFirma == id).ToList();
            return View(item);
        }


        public ActionResult Create()
        {
            var context = new AddSantierViewModel();
            context.Init(_functi, _angajat, _utilaj, (int)Session["Id"]);
            return View(context);
        }

        [HttpPost]
        public ActionResult CreateSantier(List<Santier> santier)
        {
            foreach (Santier item in santier)
            {
                Session["DenummireSantier"] = item.Denumire;
                _santier.Add(item);
            }
            return Json(new { message = "Yes", JsonRequestBehavior.AllowGet });
        }


        [HttpPost]
        public ActionResult AdaugaAngajati(List<SantierAngajati> dateAngajat)
        {
            foreach(SantierAngajati santier in dateAngajat)
            {
                _angajati_santier.Add(santier);
            } 

            return Json(new { message = "Bravo",JsonRequestBehavior.AllowGet});
        } 

        [HttpPost]
        public ActionResult UtilajePentruSantier(List<UtilajePentruSantier> utilajeSanteir)
        {
            foreach (UtilajePentruSantier item in utilajeSanteir)
            {
                _utilaje_santier.Add(item);
            }

            return Json(new { message = "Nice", JsonRequestBehavior.AllowGet });
        }

        public ActionResult Edit(int id)
        {
            var finde = _santier.Get(id);
            if(finde == null)
            {
                return HttpNotFound();
            }

            var sant = new AddSantierViewModel()
            {
                Santier = finde
            };
            sant.Init(_functi, _angajat, _utilaj, (int)Session["Id"]);
            return View(sant);
        }
        [HttpPost]
        public ActionResult Edit(AddSantierViewModel santer)
        {
            var editare = santer.Santier;
            editare.IdFirma = (int)Session["Id"];
            if (ModelState.IsValid)
            {
                _santier.Update(editare);
                TempData["Check"] = "Santier editat cu succes";
                return RedirectToAction("Index", "Santier", new { id = Session["Id"] });
            }

            return View();
        }

        public ActionResult Detail(int id)
        {
            var item = _santier.Get(id);
            return View(item);
        }
       
    }
}