using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("OrderLines", Schema = "Sales")]
    public partial class OrderLines
    {
        [Key]
        [Column("OrderLineID")]
        public int OrderLineId { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TaxRate { get; set; }
        public int PickedQuantity { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.OrderLines))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.OrderLines))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(PackageTypeId))]
        [InverseProperty(nameof(PackageTypes.OrderLines))]
        public virtual PackageTypes PackageType { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.OrderLines))]
        public virtual StockItems StockItem { get; set; }
    }
}
