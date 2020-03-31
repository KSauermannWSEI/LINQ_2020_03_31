using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("StockItemHoldings", Schema = "Warehouse")]
    public partial class StockItemHoldings
    {
        [Key]
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        public int QuantityOnHand { get; set; }
        [Required]
        [StringLength(20)]
        public string BinLocation { get; set; }
        public int LastStocktakeQuantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.StockItemHoldings))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.StockItemHoldings))]
        public virtual StockItems StockItem { get; set; }
    }
}
