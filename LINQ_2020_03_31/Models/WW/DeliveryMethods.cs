using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("DeliveryMethods", Schema = "Application")]
    public partial class DeliveryMethods
    {
        public DeliveryMethods()
        {
            Customers = new HashSet<Customers>();
            Invoices = new HashSet<Invoices>();
            PurchaseOrders = new HashSet<PurchaseOrders>();
            Suppliers = new HashSet<Suppliers>();
        }

        [Key]
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Required]
        [StringLength(50)]
        public string DeliveryMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.DeliveryMethods))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<Invoices> Invoices { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        [InverseProperty("DeliveryMethod")]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}
