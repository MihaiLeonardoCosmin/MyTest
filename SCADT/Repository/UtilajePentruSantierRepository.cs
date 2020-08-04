using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCADT.Repository
{

    public class UtilajePentruSantierRepository : BaseRepository<UtilajePentruSantier>
    {
        public UtilajePentruSantierRepository(DataBase context) : base(context) { }
        public override UtilajePentruSantier Get(int id)
        {
            throw new NotImplementedException();
        }

        public override IList<UtilajePentruSantier> GetList()
        {
            throw new NotImplementedException();
        }
    }
}