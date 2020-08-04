using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{
    public class FunctiRepository : BaseRepository<Functi>
    {
 
        public FunctiRepository(DataBase date) : base(date) { }

        public override Functi Get(int id)
        {
            throw new NotImplementedException();
        }
        
        public override IList<Functi> GetList()
        {
            return context.Functie.OrderBy(e => e.Denumire).ToList();
        }


    }
}