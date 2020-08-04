using SCADT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADTDB.Clase
{
    public class InitializareBazaDeDate : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var admin = new SignUp()
            {
                Nume = "Robert",
                Prenume = "Dorin",
                Adresa = "Cireasov",
                Judet = "OLT",
                AdresaEmail = "Dorin.Robert@yahoo.com",
                Localitate = "Slatina",
                NumeUtilizator = "Robert",
                Parola = "Robert13",
                Telefon = "0726029579"
            };
            context.SignUp.Add(admin);
            context.SaveChanges(); 
        }
    }
}
