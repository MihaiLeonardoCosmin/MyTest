using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{
    public class ShowAngajatiRepository : BaseRepository<Angajat>
    {

        public ShowAngajatiRepository(DataBase context) : base(context)
        { }
        public override Angajat Get(int id)
        {
            return context.Angajati.Where(e => e.Id == id )
                .Include(a => a.FunctiAngajat)
                .SingleOrDefault();
        }

        public override IList<Angajat> GetList()
        {
            throw new NotImplementedException();
        }
        public bool CheckAngajat(string username,string password)
        {
            return context.Angajati
                .Any(cb => cb.Username == username &&
                    cb.Password == password);
        }
    }
}