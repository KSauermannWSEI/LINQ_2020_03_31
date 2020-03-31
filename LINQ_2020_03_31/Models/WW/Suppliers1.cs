using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    public partial class Suppliers1
    {
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
        [StringLength(50)]
        public string SupplierCategoryName { get; set; }
        [StringLength(50)]
        public string PrimaryContact { get; set; }
        [StringLength(50)]
        public string AlternateContact { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [Required]
        [Column("WebsiteURL")]
        [StringLength(256)]
        public string WebsiteUrl { get; set; }
        [StringLength(50)]
        public string DeliveryMethod { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        [StringLength(20)]
        public string SupplierReference { get; set; }
    }
}
