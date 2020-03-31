using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("StockItemTransactions", Schema = "Warehouse")]
    public partial class StockItemTransactions
    {
        [Key]
        [Column("StockItemTransactionID")]
        public int StockItemTransactionId { get; set; }
        [Column("StockItemID")]
        public int StockItemId { get; set; }
        [Column("TransactionTypeID")]
        public int TransactionTypeId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("PurchaseOrderID")]
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.StockItemTransactions))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty(nameof(Invoices.StockItemTransactions))]
        public virtual Invoices Invoice { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.StockItemTransactions))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PurchaseOrderId))]
        [InverseProperty(nameof(PurchaseOrders.StockItemTransactions))]
        public virtual PurchaseOrders PurchaseOrder { get; set; }
        [ForeignKey(nameof(StockItemId))]
        [InverseProperty(nameof(StockItems.StockItemTransactions))]
        public virtual StockItems StockItem { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Suppliers.StockItemTransactions))]
        public virtual Suppliers Supplier { get; set; }
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty(nameof(TransactionTypes.StockItemTransactions))]
        public virtual TransactionTypes TransactionType { get; set; }
    }
}
