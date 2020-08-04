using SCADT.Models;
using SCADT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SCADT.Repository
{
    public class SignUpRepository : BaseRepository<Utilizator>
    {
         
        public SignUpRepository(DataBase date) : base(date) { }
        public override Utilizator Get(int id)
        {
            var utilizator = context.signUp.AsQueryable();
            return utilizator.Where(e => e.Id == id).SingleOrDefault();
        }

        public override IList<Utilizator> GetList()
        {
            throw new NotImplementedException();
        }
       
       

    }
}