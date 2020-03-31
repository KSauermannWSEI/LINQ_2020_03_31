using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("Customers", Schema = "Sales")]
    public partial class Customers
    {
        public Customers()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InverseBillToCustomer = new HashSet<Customers>();
            InvoicesBillToCustomer = new HashSet<Invoices>();
            InvoicesCustomer = new HashSet<Invoices>();
            Orders = new HashSet<Orders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [Column("BillToCustomerID")]
        public int BillToCustomerId { get; set; }
        [Column("CustomerCategoryID")]
        public int CustomerCategoryId { get; set; }
        [Column("BuyingGroupID")]
        public int? BuyingGroupId { get; set; }
        [Column("PrimaryContactPersonID")]
        public int PrimaryContactPersonId { get; set; }
        [Column("AlternateContactPersonID")]
        public int? AlternateContactPersonId { get; set; }
        [Column("DeliveryMethodID")]
        public int DeliveryMethodId { get; set; }
        [Column("DeliveryCityID")]
        public int DeliveryCityId { get; set; }
        [Column("PostalCityID")]
        public int PostalCityId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CreditLimit { get; set; }
        [Column(TypeName = "date")]
        public DateTime AccountOpenedDate { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [StringLength(5)]
        public string DeliveryRun { get; set; }
        [StringLength(5)]
        public string RunPosition { get; set; }
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
        [InverseProperty(nameof(People.CustomersAlternateContactPerson))]
        public virtual People AlternateContactPerson { get; set; }
        [ForeignKey(nameof(BillToCustomerId))]
        [InverseProperty(nameof(Customers.InverseBillToCustomer))]
        public virtual Customers BillToCustomer { get; set; }
        [ForeignKey(nameof(BuyingGroupId))]
        [InverseProperty(nameof(BuyingGroups.Customers))]
        public virtual BuyingGroups BuyingGroup { get; set; }
        [ForeignKey(nameof(CustomerCategoryId))]
        [InverseProperty(nameof(CustomerCategories.Customers))]
        public virtual CustomerCategories CustomerCategory { get; set; }
        [ForeignKey(nameof(DeliveryCityId))]
        [InverseProperty(nameof(Cities.CustomersDeliveryCity))]
        public virtual Cities DeliveryCity { get; set; }
        [ForeignKey(nameof(DeliveryMethodId))]
        [InverseProperty(nameof(DeliveryMethods.Customers))]
        public virtual DeliveryMethods DeliveryMethod { get; set; }
        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.CustomersLastEditedByNavigation))]
        public virtual People LastEditedByNavigation { get; set; }
        [ForeignKey(nameof(PostalCityId))]
        [InverseProperty(nameof(Cities.CustomersPostalCity))]
        public virtual Cities PostalCity { get; set; }
        [ForeignKey(nameof(PrimaryContactPersonId))]
        [InverseProperty(nameof(People.CustomersPrimaryContactPerson))]
        public virtual People PrimaryContactPerson { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty(nameof(Customers.BillToCustomer))]
        public virtual ICollection<Customers> InverseBillToCustomer { get; set; }
        [InverseProperty(nameof(Invoices.BillToCustomer))]
        public virtual ICollection<Invoices> InvoicesBillToCustomer { get; set; }
        [InverseProperty(nameof(Invoices.Customer))]
        public virtual ICollection<Invoices> InvoicesCustomer { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Orders> Orders { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
