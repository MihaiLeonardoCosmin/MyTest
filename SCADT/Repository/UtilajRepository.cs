using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{
    public class UtilajRepository : BaseRepository<Utilaj>
    {
        public UtilajRepository(DataBase context) : base(context) { }
        public override Utilaj Get(int id)
        {
            return context.Utilaje.Where(e => e.Id == id).SingleOrDefault();
        }

        public override IList<Utilaj> GetList()
        {
            throw new NotImplementedException();
        }
        public IList<Utilaj> ListPersonalization(int id)
        {
            return context.Utilaje.Where(e => e.IdFirma == id).OrderBy(s => s.Denumire).ToList();
        }
    }
}