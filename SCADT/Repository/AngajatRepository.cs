using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{
    public class AngajatRepository : BaseRepository<Angajat>
    {
        public AngajatRepository(DataBase context) : base(context) { }

        public override Angajat Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<Angajat> GetList()
        {
            return context.Angajati.OrderBy(e => e.Nume).ToList();
        }
        public IList<Angajat> ListaPersonalizate(int id)
        {
            return context.Angajati.Where(e => e.Firma == id).OrderBy(e => e.Nume).ToList();
        }
    }
}