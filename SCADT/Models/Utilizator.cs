using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("Firma")]
    public class Utilizator
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Completati campul Firma")]
        public string Firma { get; set; }
        [Required(ErrorMessage = "Completati campul Jud")]
        public string Jud { get; set; }
        [Required(ErrorMessage = "Completati campul Localitate")]
        public string Localitate { get; set; }
        [Required(ErrorMessage = "Completati campul Adresa")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Completati campul Nr")]
        public string Nr { get; set; }
        [Required(ErrorMessage = "Completati campul Cod de inregistrare")]
        [DisplayName("Cod de inregistrare")]
        public string CodDeInregistrare { get; set; }
        [Required(ErrorMessage = "Completati campul  Numar de inregistrare")]
        [DisplayName("Numar de inregistrare")]
        public string NrInregistrare { get; set; }
        [Required(ErrorMessage = "Completati campul Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

       
    }
}