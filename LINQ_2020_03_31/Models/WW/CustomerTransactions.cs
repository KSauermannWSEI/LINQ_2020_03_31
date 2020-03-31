using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("CustomerTransactions", Schema = "Sales")]
    public partial class CustomerTransactions
    {
        [Key]
        [Column("CustomerTransactionID")]
        public int CustomerTransactionId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [Column("PaymentMethodID")]
        public int? PaymentMethodId { get; set; }
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

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.CustomerTransactions))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(Invoices.CustomerTransactions))]
        public virtual Invoices Invoice { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.CustomerTransactions))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty(nameof(PaymentMethods.CustomerTransactions))]
        public virtual PaymentMethods PaymentMethod { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty(nameof(TransactionTypes.CustomerTransactions))]
        public virtual TransactionTypes TransactionType { get; set; }
    }
}
