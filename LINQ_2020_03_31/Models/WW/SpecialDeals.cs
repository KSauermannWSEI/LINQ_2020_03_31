using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("SpecialDeals", Schema = "Sales")]
    public partial class SpecialDeals
    {
        [Key]
        [Column("SpecialDealID")]
        public int SpecialDealId { get; set; }
        [Column("StockItemID")]
        public int? StockItemId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("BuyingGroupID")]
        public int? BuyingGroupId { get; set; }
        [Column("CustomerCategoryID")]
        public int? CustomerCategoryId { get; set; }
        [Column("StockGroupID")]
        public int? StockGroupId { get; set; }
        [Required]
        [StringLength(30)]
        public string DealDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? DiscountPercentage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(BuyingGroupId))]
        [InverseProperty(nameof(BuyingGroups.SpecialDeals))]
        public virtual BuyingGroups BuyingGroup { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.SpecialDeals))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(CustomerCategoryId))]
        [InverseProperty(nameof(CustomerCategories.SpecialDeals))]
        public virtual CustomerCategories CustomerCategory { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.SpecialDeals))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StockGroupId))]
        [InverseProperty(nameof(StockGroups.SpecialDeals))]
        public virtual StockGroups StockGroup { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.SpecialDeals))]
        public virtual StockItems StockItem { get; set; }
    }
}
