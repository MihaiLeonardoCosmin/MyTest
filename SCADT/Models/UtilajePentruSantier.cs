using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCADT.Models
{
    [Table("UtilajePentruSantier")]
    public class UtilajePentruSantier
    {
        public int Id { get; set; }
        public string DenumireSantier { get; set; }
        public int keyUtilaje { get; set; }
        public int DenumireFirma { get; set; }

        [NotMapped]
        public List<Santier> infoSantier { get; set; }
    }
}