using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Orders", Schema = "Sales")]
    public partial class Orders
    {
        public Orders()
        {
            InverseBackorderOrder = new HashSet<Orders>();
            Invoices = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("SalespersonPersonID")]
        public int SalespersonPersonId { get; set; }
        [Column("PickedByPersonID")]
        public int? PickedByPersonId { get; set; }
        [Column("ContactPersonID")]
        public int ContactPersonId { get; set; }
        [Column("BackorderOrderID")]
        public int? BackorderOrderId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpectedDeliveryDate { get; set; }
        [StringLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        [ForeignKey(nameof(BackorderOrderId))]
        [InverseProperty(nameof(Orders.InverseBackorderOrder))]
        public virtual Orders BackorderOrder { get; set; }
        [ForeignKey(nameof(ContactPersonId))]
        [InverseProperty(nameof(People.OrdersContactPerson))]
        public virtual People ContactPerson { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Orders))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.OrdersLastEditedByNavigation))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PickedByPersonId))]
        [InverseProperty(nameof(People.OrdersPickedByPerson))]
        public virtual People PickedByPerson { get; set; }
        [ForeignKey(nameof(SalespersonPersonId))]
        [InverseProperty(nameof(People.OrdersSalespersonPerson))]
        public virtual People SalespersonPerson { get; set; }
        [InverseProperty(nameof(Orders.BackorderOrder))]
        public virtual ICollection<Orders> InverseBackorderOrder { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<Invoices> Invoices { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
