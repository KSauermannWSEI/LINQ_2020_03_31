using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("PurchaseOrderLines", Schema = "Purchasing")]
    public partial class PurchaseOrderLines
    {
        [Key]
        [Column("PurchaseOrderLineID")]
        public int PurchaseOrderLineId { get; set; }
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        public int OrderedOuters { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public int ReceivedOuters { get; set; }
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ExpectedUnitPricePerOuter { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.PurchaseOrderLines))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PackageTypeId))]
        [InverseProperty(nameof(PackageTypes.PurchaseOrderLines))]
        public virtual PackageTypes PackageType { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty(nameof(PurchaseOrders.PurchaseOrderLines))]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.PurchaseOrderLines))]
        public virtual StockItems StockItem { get; set; }
    }
}
