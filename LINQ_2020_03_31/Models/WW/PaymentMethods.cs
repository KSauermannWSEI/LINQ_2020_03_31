using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("PaymentMethods", Schema = "Application")]
    public partial class PaymentMethods
    {
        public PaymentMethods()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        [Key]
        [Column("PaymentMethodID")]
        public int PaymentMethodId { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.PaymentMethods))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("PaymentMethod")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty("PaymentMethod")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
