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
    [Table("countrylanguage")]
    public partial class Countrylanguage
    {
        [Key]
        [Column(TypeName = "char(3)")]
        public string CountryCode { get; set; }
        [Key]
        [Column(TypeName = "char(30)")]
        public string Language { get; set; }
        [Required]
        [Column(TypeName = "char(1)")]
        public string IsOfficial { get; set; }
        [Required]
        [Column(TypeName = "decimal(4,1)")]
        public byte[] Percentage { get; set; }

        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.Countrylanguages))]
        public virtual Country CountryCodeNavigation { get; set; }
    }
}
