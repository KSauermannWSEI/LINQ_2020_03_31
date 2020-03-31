using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Colors", Schema = "Warehouse")]
    public partial class Colors
    {
        public Colors()
        {
            StockItems = new HashSet<StockItems>();
        }

        [Key]
        [Column("ColorID")]
        public int ColorId { get; set; }
        [Required]
        [StringLength(20)]
        public string ColorName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.Colors))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("Color")]
        public virtual ICollection<StockItems> StockItems { get; set; }
    }
}
