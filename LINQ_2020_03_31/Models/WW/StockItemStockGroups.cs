using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("StockItemStockGroups", Schema = "Warehouse")]
    public partial class StockItemStockGroups
    {
        [Key]
        [Column("StockItemStockGroupID")]
        public int StockItemStockGroupId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Column("StockGroupID")]
        public int StockGroupId { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.StockItemStockGroups))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(StockGroupId))]
        [InverseProperty(nameof(StockGroups.StockItemStockGroups))]
        public virtual StockGroups StockGroup { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.StockItemStockGroups))]
        public virtual StockItems StockItem { get; set; }
    }
}
