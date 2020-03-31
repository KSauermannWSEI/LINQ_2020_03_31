using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    public partial class Customers1
    {
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(50)]
        public string CustomerCategoryName { get; set; }
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
        [StringLength(50)]
        public string BuyingGroupName { get; set; }
        [Required]
        [Column("WebsiteURL")]
        [StringLength(256)]
        public string WebsiteUrl { get; set; }
        [StringLength(50)]
        public string DeliveryMethod { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        [StringLength(5)]
        public string DeliveryRun { get; set; }
        [StringLength(5)]
        public string RunPosition { get; set; }
    }
}
