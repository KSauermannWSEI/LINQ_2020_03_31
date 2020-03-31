using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("SystemParameters", Schema = "Application")]
    public partial class SystemParameters
    {
        [Key]
        [Column("SystemParameterID")]
        public int SystemParameterId { get; set; }
        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }
        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Required]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }
        [Required]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }
        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [Required]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }
        [Required]
        public string ApplicationSettings { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(DeliveryCityId))]
        [InverseProperty(nameof(Cities.SystemParametersDeliveryCity))]
        public virtual Cities DeliveryCity { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.SystemParameters))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PostalCityId))]
        [InverseProperty(nameof(Cities.SystemParametersPostalCity))]
        public virtual Cities PostalCity { get; set; }
    }
}
