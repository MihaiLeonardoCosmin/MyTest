using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("Utilaje")]
    public class Utilaj
    {
        public int Id { get; set; }
        public int IdFirma { get; set; }
        public string Denumire { get; set; } 

        public ICollection<Santier> Santeire { get; set; }
    }
}