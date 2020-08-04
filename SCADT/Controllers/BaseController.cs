using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCADT.Controllers
{
    public abstract class BaseController : Controller
    {
        private bool _dispose = false;
        protected DataBase Context = null;

        public BaseController()
        {
            Context =new  DataBase();
        }

        protected override void Dispose(bool disposing)
        {
            if (_dispose)
                return;
            if (disposing)
            {
                Context.Dispose();
            }
            _dispose = true;
            base.Dispose(disposing);
        }

    }
}