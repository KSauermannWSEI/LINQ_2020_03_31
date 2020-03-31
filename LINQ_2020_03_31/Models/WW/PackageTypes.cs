using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("PackageTypes", Schema = "Warehouse")]
    public partial class PackageTypes
    {
        public PackageTypes()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            OrderLines = new HashSet<OrderLines>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            StockItemsOuterPackage = new HashSet<StockItems>();
            StockItemsUnitPackage = new HashSet<StockItems>();
        }

        [Key]
        [Column("PackageTypeID")]
        public int PackageTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.PackageTypes))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("PackageType")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("PackageType")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("PackageType")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty(nameof(StockItems.OuterPackage))]
        public virtual ICollection<StockItems> StockItemsOuterPackage { get; set; }
        [InverseProperty(nameof(StockItems.UnitPackage))]
        public virtual ICollection<StockItems> StockItemsUnitPackage { get; set; }
    }
}
