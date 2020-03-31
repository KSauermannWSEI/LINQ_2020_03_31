using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("TransactionTypes", Schema = "Application")]
    public partial class TransactionTypes
    {
        public TransactionTypes()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        [Key]
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.TransactionTypes))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("TransactionType")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty("TransactionType")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [InverseProperty("TransactionType")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
