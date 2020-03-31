using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("StockGroups", Schema = "Warehouse")]
    public partial class StockGroups
    {
        public StockGroups()
        {
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
        }

        [Key]
        [Column("StockGroupID")]
        public int StockGroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.StockGroups))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("StockGroup")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("StockGroup")]
        public virtual ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
    }
}
