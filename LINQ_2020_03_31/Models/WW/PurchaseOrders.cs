using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("PurchaseOrders", Schema = "Purchasing")]
    public partial class PurchaseOrders
    {
        public PurchaseOrders()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        [Key]
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExpectedDeliveryDate { get; set; }
        [StringLength(20)]
        public string SupplierReference { get; set; }
        public bool IsOrderFinalized { get; set; }
        public string Comments { get; set; }
        public string InternalComments { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(ContactPersonId))]
        [InverseProperty(nameof(People.PurchaseOrdersContactPerson))]
        public virtual People ContactPerson { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty(nameof(DeliveryMethods.PurchaseOrders))]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.PurchaseOrdersLastEditedByNavigation))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Suppliers.PurchaseOrders))]
        public virtual Suppliers Supplier { get; set; }
        [InverseProperty("PurchaseOrder")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty("PurchaseOrder")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [InverseProperty("PurchaseOrder")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
