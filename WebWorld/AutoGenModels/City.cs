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
    [Table("city")]
    public partial class City
    {
        [Key]
        [Column("ID", TypeName = "int")]
        public long Id { get; set; }
        [Required]
        [Column(TypeName = "char(35)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "char(3)")]
        public string CountryCode { get; set; }
        [Required]
        [Column(TypeName = "char(20)")]
        public string District { get; set; }
        [Column(TypeName = "int")]
        public long Population { get; set; }

        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.Cities))]
        public virtual Country CountryCodeNavigation { get; set; }
    }
}
