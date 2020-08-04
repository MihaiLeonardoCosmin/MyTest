using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCADT.ViewModels
{
    public class EditAngatViewModel: ControlContentWebSite
    {
        public int Id
        {
            get { return angajat.Id; }
            set { angajat.Id = value; }
        }

 


    }
}