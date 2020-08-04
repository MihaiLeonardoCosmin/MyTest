using SCADT.Models;
using SCADT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SCADT.ViewModels
{
    public abstract class ControlContentWebSite
    {

        public Angajat angajat { get; set; } = new Angajat();
        public Functi Functi { get; set; } = new Functi();
        public Santier Santier { get; set; } = new Santier();
        public SelectList FunctiAngajati { get; set; }
        public SelectList Denumire_angajati { get; set; }
        public SelectList utilaje { get; set; }

        public virtual void Init(FunctiRepository functie,AngajatRepository angajat,
            UtilajRepository Utilaje,
            int id)
        {
            FunctiAngajati = new SelectList(
                functie.GetList(), "Id", "Denumire") ;
            
            Denumire_angajati = new SelectList(angajat.ListaPersonalizate(id), "Id", "Nume");
            utilaje = new SelectList(Utilaje.ListPersonalization(id), "Id", "Denumire");

        }


    }
}