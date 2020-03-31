using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("InvoiceLines", Schema = "Sales")]
    public partial class InvoiceLines
    {
        [Key]
        [Column("InvoiceLineID")]
        public int InvoiceLineId { get; set; }
        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
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
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LineProfit { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ExtendedPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(Invoices.InvoiceLines))]
        public virtual Invoices Invoice { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.InvoiceLines))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PackageTypeId))]
        [InverseProperty(nameof(PackageTypes.InvoiceLines))]
        public virtual PackageTypes PackageType { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.InvoiceLines))]
        public virtual StockItems StockItem { get; set; }
    }
}
