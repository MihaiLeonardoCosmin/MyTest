using SCADT.Models;
using SCADT.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Web;

namespace SCADT
{
    public class DataBase: DbContext
    {
        public DbSet<Utilizator> signUp { get; set; }
        public DbSet<Angajat> Angajati { get; set; }    
        public DbSet<Functi> Functie { get; set; }
        public DbSet<Utilaj> Utilaje { get; set; }
        public DbSet<Santier> Santiere { get; set; }
        public DbSet<SantierAngajati> Angajati_santier { get; set; }
        public DbSet<UtilajePentruSantier> Utilaje_santier { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angajat>().
                HasRequired<Functi>(s => s.FunctiAngajat)
                .WithMany(g => g.Angajats)
                .HasForeignKey<int>(s => s.Functie);

           
            modelBuilder.Entity<Santier>()
                .HasRequired<Angajat>(s => s.angajat)
                .WithMany(q => q.Santiere)
                .HasForeignKey<int>(r => r.IdAngajat);

            modelBuilder.Entity<Santier>()
                .HasRequired<Utilaj>(s => s.utilaj)
                .WithMany(h => h.Santeire)
                .HasForeignKey<int>(t => t.IdUtilaj);
        }

    }

}