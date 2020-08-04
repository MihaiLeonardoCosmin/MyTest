using SCADT.Models;
using SCADT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace SCADT.Controllers
{
    public class UtilajeController : BaseController
    {
        private UtilajRepository _utilaj = null;
        
        public UtilajeController()
        {
            _utilaj = new UtilajRepository(Context);
        }
        public ActionResult Index(int id)
        {
            var item = _utilaj.ListPersonalization(id);
            return View(item);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Utilaj utilaj)
        {
            utilaj.IdFirma = (int)Session["Id"];
            if (ModelState.IsValid)
            {
                _utilaj.Add(utilaj);
                TempData["check"] = "Utilaj adaugat cu succes";
                return RedirectToAction("Index", "Utilaje",new { id = Session["Id"] });
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var finde = _utilaj.Get(id);
            return View(finde);
        }
        [HttpPost]
        public ActionResult Edit(Utilaj utilaj)
        {
            utilaj.IdFirma = (int)Session["Id"];
            if (ModelState.IsValid)
            {
                _utilaj.Update(utilaj);
                TempData["check"] = "Utilajul a fost editat cu succes";
                return RedirectToAction("Index", "Utilaje", new { id = Session["id"] });
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var get = _utilaj.Get(id);
            return View(get);
        }
        public ActionResult Delete(int? id)
        {
            var get = _utilaj.Get((int)id);
            return View(get);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _utilaj.Delete(id);
            TempData["check"] = "Utilajul a fost sters cu succes";    
            return RedirectToAction("Index","Utilaje",new { id = Session["Id"] });
        }
    }
}