// Brian Hodge
// C00170400
// CMPS 358
// Project #9

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace World
{
    [Table("country")]
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Countrylanguages = new HashSet<Countrylanguage>();
        }

        [Key]
        [Column(TypeName = "char(3)")]
        public string Code { get; set; }
        [Required]
        [Column(TypeName = "char(52)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "char(20)")]
        public string Continent { get; set; }
        [Required]
        [Column(TypeName = "char(26)")]
        public string Region { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public byte[] SurfaceArea { get; set; }
        [Column(TypeName = "smallint")]
        public long? IndepYear { get; set; }
        [Column(TypeName = "int")]
        public long Population { get; set; }
        [Column(TypeName = "decimal(3,1)")]
        public byte[] LifeExpectancy { get; set; }
        [Column("GNP", TypeName = "decimal(10,2)")]
        public byte[] Gnp { get; set; }
        [Column("GNPOld", TypeName = "decimal(10,2)")]
        public byte[] Gnpold { get; set; }
        [Required]
        [Column(TypeName = "char(45)")]
        public string LocalName { get; set; }
        [Required]
        [Column(TypeName = "char(45)")]
        public string GovernmentForm { get; set; }
        [Column(TypeName = "char(60)")]
        public string HeadOfState { get; set; }
        [Column(TypeName = "int")]
        public long? Capital { get; set; }
        [Required]
        [Column(TypeName = "char(2)")]
        public string Code2 { get; set; }

        [InverseProperty(nameof(City.CountryCodeNavigation))]
        public virtual ICollection<City> Cities { get; set; }
        [InverseProperty(nameof(Countrylanguage.CountryCodeNavigation))]
        public virtual ICollection<Countrylanguage> Countrylanguages { get; set; }
    }
}
