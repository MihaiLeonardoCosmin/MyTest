using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{
    public class SantierRepository : BaseRepository<Santier>
    {
        public SantierRepository(DataBase context) : base(context) {}

        public override Santier Get(int id)
        {
            return context.Santiere.Where(e => e.Id == id)
                .Include(a => a.angajat)
                .Include(s => s.utilaj)
                .SingleOrDefault();
        }

        public override IList<Santier> GetList()
        {
            return context.Santiere.OrderBy(e => e.Denumire)
                .Include(s => s.angajat)
                .Include(a => a.utilaj)
                .ToList();
        }

        
     

    }
}