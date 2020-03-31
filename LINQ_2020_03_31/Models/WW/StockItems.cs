using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("StockItems", Schema = "Warehouse")]
    public partial class StockItems
    {
        public StockItems()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            OrderLines = new HashSet<OrderLines>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        [Key]
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Required]
        [StringLength(100)]
        public string StockItemName { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("ColorID")]
        public int? ColorId { get; set; }
        [Column("UnitPackageID")]
        public int UnitPackageId { get; set; }
        [Column("OuterPackageID")]
        public int OuterPackageId { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [StringLength(20)]
        public string Size { get; set; }
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        [StringLength(50)]
        public string Barcode { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TaxRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RecommendedRetailPrice { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal TypicalWeightPerUnit { get; set; }
        public string MarketingComments { get; set; }
        public string InternalComments { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string Tags { get; set; }
        [Required]
        public string SearchDetails { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(ColorId))]
        [InverseProperty(nameof(Colors.StockItems))]
        public virtual Colors Color { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.StockItems))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(OuterPackageId))]
        [InverseProperty(nameof(PackageTypes.StockItemsOuterPackage))]
        public virtual PackageTypes OuterPackage { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Suppliers.StockItems))]
        public virtual Suppliers Supplier { get; set; }
        [ForeignKey(nameof(UnitPackageId))]
        [InverseProperty(nameof(PackageTypes.StockItemsUnitPackage))]
        public virtual PackageTypes UnitPackage { get; set; }
        [InverseProperty("StockItem")]
        public virtual StockItemHoldings StockItemHoldings { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        [InverseProperty("StockItem")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
