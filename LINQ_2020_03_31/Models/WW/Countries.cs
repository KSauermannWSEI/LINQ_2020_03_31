using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Countries", Schema = "Application")]
    public partial class Countries
    {
        public Countries()
        {
            StateProvinces = new HashSet<StateProvinces>();
        }

        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Required]
        [StringLength(60)]
        public string CountryName { get; set; }
        [Required]
        [StringLength(60)]
        public string FormalName { get; set; }
        [StringLength(3)]
        public string IsoAlpha3Code { get; set; }
        public int? IsoNumericCode { get; set; }
        [StringLength(20)]
        public string CountryType { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        [Required]
        [StringLength(30)]
        public string Continent { get; set; }
        [Required]
        [StringLength(30)]
        public string Region { get; set; }
        [Required]
        [StringLength(30)]
        public string Subregion { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.Countries))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<StateProvinces> StateProvinces { get; set; }
    }
}
