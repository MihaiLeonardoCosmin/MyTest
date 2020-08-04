using SCADT.Models;
using SCADT.Repository;
using SCADT.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace SCADT.Controllers
{
    public class OperationAngajatController : BaseController
    {
         
        protected FunctiRepository _functie = null;
        protected AngajatRepository _angajatRepository = null;
        protected UtilajRepository _utilajRepository = null;
        private ShowAngajatiRepository _showAngajati = null;
        private SignUpRepository _signUp = null;
        
        public OperationAngajatController()
        {
            _functie = new FunctiRepository(Context);
            _angajatRepository = new AngajatRepository(Context);
            _utilajRepository = new UtilajRepository(Context);
            _signUp = new SignUpRepository(Context);
            _showAngajati = new ShowAngajatiRepository(Context);
        }

        public ActionResult ShowAngajati(int id)
        {

            var lista = Context.Angajati.Where(e => e.Firma == id).Include(s => s.FunctiAngajat);
            return View(lista.ToList());
        }

        public ActionResult AdaugaAngajat()
        {
            var context = new AddAngajatViewModel();
           
            context.Init(_functie,_angajatRepository,_utilajRepository,(int)Session["Id"]);
            return View(context);
        }
        [HttpPost]
        public ActionResult AdaugaAngajat(Angajat angajat)
        {
            angajat.Firma = (int)Session["id"];
            if (ModelState.IsValid)
            {
                _showAngajati.Add(angajat);
                TempData["check"] = "Angajat Adaugat cu suceess";
                return RedirectToAction("ShowAngajati", "OperationAngajat", new { id = Session["Id"] });
            }

            return View();
        }

        /* De Rezolvat maine */

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var finde = _showAngajati.Get((int)id);

            if (finde == null)
            {
                return HttpNotFound();
            }

            var ang = new EditAngatViewModel()
            {
                angajat = finde
            };

            ang.Init(_functie, _angajatRepository, _utilajRepository, (int)Session["Id"]);
            return View(ang);
        }
        [HttpPost]
        public ActionResult Edit(EditAngatViewModel a)
        {
            var ang = a.angajat;
            ang.Firma = (int)Session["Id"];

            if (ModelState.IsValid)
            {
                _showAngajati.Update(ang);
                TempData["check"] = "Angajatul a fost editat cu succes";
                return RedirectToAction("ShowAngajati", "OperationAngajat", new { id = Session["Id"] });
            }
             
            a.Init(_functie, _angajatRepository, _utilajRepository, (int)Session["Id"]);
            return View();
        }

        public ActionResult Detail(int id)
        {
            var item = _showAngajati.Get(id);
            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            var obj = _showAngajati.Get((int)id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _showAngajati.Delete(id);
            TempData["check"] = "Angajat sters cu sucees";
            return RedirectToAction("ShowAngajati", "OperationAngajat", new { id = Session["Id"] });
        }
        private void ValidateAngajat(Angajat angajat)
        {
            if (ModelState.IsValidField("angajat.Username") &&
                ModelState.IsValidField("angajat.Password"))
            {
                if (_showAngajati.CheckAngajat(angajat.Username, angajat.Password))
                {
                    ModelState.AddModelError("angajat.Username", "Acest utilizator exista in baza de date");
                }
            }
        }
        
        public ActionResult AddFunctie()
        {
            var con = new AddFunctieViewModel();
            return View(con);
        }
        [HttpPost]
        public ActionResult AddFunctie(AddAngajatViewModel func)
        {
            var item = func.Functi;
            item.IdFirma = (int)Session["Id"];
            if (ModelState.IsValid)
            {
                var finde = Context.Functie.Where(e => e.Denumire == item.Denumire).SingleOrDefault();
                if (finde == null)
                {
                    _functie.Add(item);
                    TempData["check"] = "Functia sa adaugat cu succes";
                    return RedirectToAction("ShowAngajati", "OperationAngajat", new { id = Session["Id"] });
                }
                ModelState.AddModelError("Functi.Denumire", "Aceasta functie exista in baza de date");
            }
            return View();
        }
        
    }
}