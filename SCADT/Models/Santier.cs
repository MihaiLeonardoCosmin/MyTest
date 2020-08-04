using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Deployment.Internal;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("Santier")]
    public class Santier
    {
        public int Id { get; set; }
        public int IdFirma { get; set; }
        [Required(ErrorMessage ="Completati campul Denumire")]
        public string Denumire { get; set; }
        [Required(ErrorMessage = "Completati campul Adresa santierului")]
        [DisplayName("Adresa santierului")]
        public string Locatie { get; set; }
        [Required(ErrorMessage = "Completati campul Data inceperi")]
        [DisplayName("Data inceperi")]
        public DateTime DataInceperi { get; set; }
        [Required(ErrorMessage = "Completati campul data finalizari")]
        [DisplayName("Data Finalizari")]
        public DateTime DataFinalizari { get; set; }
        [Required(ErrorMessage = "Selectati stagiul lucrari")]
        [DisplayName("Stagiul lucrari")]
        public string Stagiu { get; set; }
        [Required(ErrorMessage = "Selectati un aganat")]
        [DisplayName("Angajat")]
        public int IdAngajat { get; set; }
        [Required(ErrorMessage = "Selectati un utilaj")]
        [DisplayName("Utilaj")]
        public int IdUtilaj { get; set; }

        public Angajat angajat { get; set; }
        public Utilaj utilaj { get; set; }

         
    }
}