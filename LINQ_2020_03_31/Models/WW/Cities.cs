using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Cities", Schema = "Application")]
    public partial class Cities
    {
        public Cities()
        {
            CustomersDeliveryCity = new HashSet<Customers>();
            CustomersPostalCity = new HashSet<Customers>();
            SuppliersDeliveryCity = new HashSet<Suppliers>();
            SuppliersPostalCity = new HashSet<Suppliers>();
            SystemParametersDeliveryCity = new HashSet<SystemParameters>();
            SystemParametersPostalCity = new HashSet<SystemParameters>();
        }

        [Key]
        [Column("CityID")]
        public int CityId { get; set; }
        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.Cities))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty(nameof(StateProvinces.Cities))]
        public virtual StateProvinces StateProvince { get; set; }
        [InverseProperty(nameof(Customers.DeliveryCity))]
        public virtual ICollection<Customers> CustomersDeliveryCity { get; set; }
        [InverseProperty(nameof(Customers.PostalCity))]
        public virtual ICollection<Customers> CustomersPostalCity { get; set; }
        [InverseProperty(nameof(Suppliers.DeliveryCity))]
        public virtual ICollection<Suppliers> SuppliersDeliveryCity { get; set; }
        [InverseProperty(nameof(Suppliers.PostalCity))]
        public virtual ICollection<Suppliers> SuppliersPostalCity { get; set; }
        [InverseProperty(nameof(SystemParameters.DeliveryCity))]
        public virtual ICollection<SystemParameters> SystemParametersDeliveryCity { get; set; }
        [InverseProperty(nameof(SystemParameters.PostalCity))]
        public virtual ICollection<SystemParameters> SystemParametersPostalCity { get; set; }
    }
}
