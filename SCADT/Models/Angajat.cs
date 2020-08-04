using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("TESA")]
    public class Angajat
    {
        public int Id { get; set; }
        public int Firma{ get; set; }

        [Required(ErrorMessage ="Selectati Functia Angajatului")]
        public int Functie { get; set; }
        [Required(ErrorMessage ="Completati campul Nume")]
        public string Nume { get; set; }
        [Required(ErrorMessage = "Completati campul Prenume")]
        public string Prenume { get; set; }
        [Required(ErrorMessage = "Completati campul Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Completati campul Telefon")]
        [DisplayName("Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "Completati campul Utilizator")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Completati campul Password")]
        [DisplayName("Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        public Functi FunctiAngajat { get; set; }

        [NotMapped]
        public ICollection<Santier> Santiere { get; set; }
    }
}