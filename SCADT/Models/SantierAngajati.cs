using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("SantierAngajati")]
    public class SantierAngajati
    {
        public int Id { get; set; }
        public string Santier { get; set; }
        public int AngajatId { get; set; }
        public int Firmat { get; set; }

        [NotMapped]
        public List<Santier> infoSantier { get; set; }

    }
}