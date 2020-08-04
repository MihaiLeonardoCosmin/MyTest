using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{
    public class Angajati_Santier : BaseRepository<SantierAngajati>
    {
        public Angajati_Santier(DataBase context) : base(context) { }
        public override SantierAngajati Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<SantierAngajati> GetList()
        {
            throw new NotImplementedException();
        } 

    }
}