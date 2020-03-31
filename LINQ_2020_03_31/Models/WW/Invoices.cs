using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Invoices", Schema = "Sales")]
    public partial class Invoices
    {
        public Invoices()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InvoiceLines = new HashSet<InvoiceLines>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        [Key]
        [Column("InvoiceID")]
        public int InvoiceId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("BillToCustomerID")]
        public int BillToCustomerId { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column("AccountsPersonID")]
        public int AccountsPersonId { get; set; }
        [Column("SalespersonPersonID")]
        public int SalespersonPersonId { get; set; }
        [Column("PackedByPersonID")]
        public int PackedByPersonId { get; set; }
        [Column(TypeName = "date")]
        public DateTime InvoiceDate { get; set; }
        [StringLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsCreditNote { get; set; }
        public string CreditNoteReason { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public int TotalDryItems { get; set; }
        public int TotalChillerItems { get; set; }
        [StringLength(5)]
        public string DeliveryRun { get; set; }
        [StringLength(5)]
        public string RunPosition { get; set; }
        public string ReturnedDeliveryData { get; set; }
        public DateTime? ConfirmedDeliveryTime { get; set; }
        [StringLength(4000)]
        public string ConfirmedReceivedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(AccountsPersonId))]
        [InverseProperty(nameof(People.InvoicesAccountsPerson))]
        public virtual People AccountsPerson { get; set; }
        [ForeignKey(nameof(BillToCustomerId))]
        [InverseProperty(nameof(Customers.InvoicesBillToCustomer))]
        public virtual Customers BillToCustomer { get; set; }
        [ForeignKey(nameof(ContactPersonId))]
        [InverseProperty(nameof(People.InvoicesContactPerson))]
        public virtual People ContactPerson { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.InvoicesCustomer))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty(nameof(DeliveryMethods.Invoices))]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.InvoicesLastEditedByNavigation))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.Invoices))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(PackedByPersonId))]
        [InverseProperty(nameof(People.InvoicesPackedByPerson))]
        public virtual People PackedByPerson { get; set; }
        [ForeignKey(nameof(SalespersonPersonId))]
        [InverseProperty(nameof(People.InvoicesSalespersonPerson))]
        public virtual People SalespersonPerson { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
