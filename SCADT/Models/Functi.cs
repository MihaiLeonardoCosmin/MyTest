using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("FunctiAngajat")]
    public class Functi
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage ="Completati campul Denumire Functie")]
        [DisplayName("Denumire Functie")]
        public string Denumire { get; set; }
         
        public int IdFirma { get; set; }
        public string Base { get; set; }

        [NotMapped]
        public ICollection<Angajat> Angajats { get; set; }
    }
}