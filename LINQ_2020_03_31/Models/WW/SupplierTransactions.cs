using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("SupplierTransactions", Schema = "Purchasing")]
    public partial class SupplierTransactions
    {
        [Key]
        [Column("SupplierTransactionID")]
        public int SupplierTransactionId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("PurchaseOrderID")]
        public int? PurchaseOrderId { get; set; }
        [Column("PaymentMethodID")]
        public int? PaymentMethodId { get; set; }
        [StringLength(20)]
        public string SupplierInvoiceNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountExcludingTax { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TransactionAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OutstandingBalance { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FinalizationDate { get; set; }
        public bool? IsFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.SupplierTransactions))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty(nameof(PaymentMethods.SupplierTransactions))]
        public virtual PaymentMethods PaymentMethod { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty(nameof(PurchaseOrders.SupplierTransactions))]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Suppliers.SupplierTransactions))]
        public virtual Suppliers Supplier { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty(nameof(TransactionTypes.SupplierTransactions))]
        public virtual TransactionTypes TransactionType { get; set; }
    }
}
