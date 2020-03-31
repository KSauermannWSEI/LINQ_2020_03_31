using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Suppliers", Schema = "Purchasing")]
    public partial class Suppliers
    {
        public Suppliers()
        {
            PurchaseOrders = new HashSet<PurchaseOrders>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            StockItems = new HashSet<StockItems>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
        }

        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
        [Column("SupplierCategoryID")]
        public int SupplierCategoryId { get; set; }
        [Column("PrimaryContactPersonID")]
        public int PrimaryContactPersonId { get; set; }
        [Column("AlternateContactPersonID")]
        public int AlternateContactPersonId { get; set; }
        [Column("DeliveryMethodID")]
        public int? DeliveryMethodId { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [StringLength(20)]
        public string SupplierReference { get; set; }
        [StringLength(50)]
        public string BankAccountName { get; set; }
        [StringLength(50)]
        public string BankAccountBranch { get; set; }
        [StringLength(20)]
        public string BankAccountCode { get; set; }
        [StringLength(20)]
        public string BankAccountNumber { get; set; }
        [StringLength(20)]
        public string BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string InternalComments { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [Required]
        [Column("WebsiteURL")]
        [StringLength(256)]
        public string WebsiteUrl { get; set; }
        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }
        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }
        [Required]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }
        [Required]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }
        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }
        [Required]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(AlternateContactPersonId))]
        [InverseProperty(nameof(People.SuppliersAlternateContactPerson))]
        public virtual People AlternateContactPerson { get; set; }
        [ForeignKey(nameof(DeliveryCityId))]
        [InverseProperty(nameof(Cities.SuppliersDeliveryCity))]
        public virtual Cities DeliveryCity { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty(nameof(DeliveryMethods.Suppliers))]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.SuppliersLastEditedByNavigation))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PostalCityId))]
        [InverseProperty(nameof(Cities.SuppliersPostalCity))]
        public virtual Cities PostalCity { get; set; }
        [ForeignKey(nameof(PrimaryContactPersonId))]
        [InverseProperty(nameof(People.SuppliersPrimaryContactPerson))]
        public virtual People PrimaryContactPerson { get; set; }
        [ForeignKey(nameof(SupplierCategoryId))]
        [InverseProperty(nameof(SupplierCategories.Suppliers))]
        public virtual SupplierCategories SupplierCategory { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<StockItems> StockItems { get; set; }
        [InverseProperty("Supplier")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
    }
}
