using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("People", Schema = "Application")]
    public partial class People
    {
        public People()
        {
            BuyingGroups = new HashSet<BuyingGroups>();
            Cities = new HashSet<Cities>();
            Colors = new HashSet<Colors>();
            Countries = new HashSet<Countries>();
            CustomerCategories = new HashSet<CustomerCategories>();
            CustomerTransactions = new HashSet<CustomerTransactions>();
            CustomersAlternateContactPerson = new HashSet<Customers>();
            CustomersLastEditedByNavigation = new HashSet<Customers>();
            CustomersPrimaryContactPerson = new HashSet<Customers>();
            DeliveryMethods = new HashSet<DeliveryMethods>();
            InverseLastEditedByNavigation = new HashSet<People>();
            InvoiceLines = new HashSet<InvoiceLines>();
            InvoicesAccountsPerson = new HashSet<Invoices>();
            InvoicesContactPerson = new HashSet<Invoices>();
            InvoicesLastEditedByNavigation = new HashSet<Invoices>();
            InvoicesPackedByPerson = new HashSet<Invoices>();
            InvoicesSalespersonPerson = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
            OrdersContactPerson = new HashSet<Orders>();
            OrdersLastEditedByNavigation = new HashSet<Orders>();
            OrdersPickedByPerson = new HashSet<Orders>();
            OrdersSalespersonPerson = new HashSet<Orders>();
            PackageTypes = new HashSet<PackageTypes>();
            PaymentMethods = new HashSet<PaymentMethods>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            PurchaseOrdersContactPerson = new HashSet<PurchaseOrders>();
            PurchaseOrdersLastEditedByNavigation = new HashSet<PurchaseOrders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StateProvinces = new HashSet<StateProvinces>();
            StockGroups = new HashSet<StockGroups>();
            StockItemHoldings = new HashSet<StockItemHoldings>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            StockItems = new HashSet<StockItems>();
            SupplierCategories = new HashSet<SupplierCategories>();
            SupplierTransactions = new HashSet<SupplierTransactions>();
            SuppliersAlternateContactPerson = new HashSet<Suppliers>();
            SuppliersLastEditedByNavigation = new HashSet<Suppliers>();
            SuppliersPrimaryContactPerson = new HashSet<Suppliers>();
            SystemParameters = new HashSet<SystemParameters>();
            TransactionTypes = new HashSet<TransactionTypes>();
        }

        [Key]
        [Column("PersonID")]
        public int PersonId { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string PreferredName { get; set; }
        [Required]
        [StringLength(101)]
        public string SearchName { get; set; }
        public bool IsPermittedToLogon { get; set; }
        [StringLength(50)]
        public string LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[] HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string UserPreferences { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(20)]
        public string FaxNumber { get; set; }
        [StringLength(256)]
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.InverseLastEditedByNavigation))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<BuyingGroups> BuyingGroups { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Cities> Cities { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Colors> Colors { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<Countries> Countries { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<CustomerCategories> CustomerCategories { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        [InverseProperty(nameof(Customers.AlternateContactPerson))]
        public virtual ICollection<Customers> CustomersAlternateContactPerson { get; set; }
        [InverseProperty(nameof(Customers.LastEditedByNavigation))]
        public virtual ICollection<Customers> CustomersLastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Customers.PrimaryContactPerson))]
        public virtual ICollection<Customers> CustomersPrimaryContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<DeliveryMethods> DeliveryMethods { get; set; }
        [InverseProperty(nameof(People.LastEditedByNavigation))]
        public virtual ICollection<People> InverseLastEditedByNavigation { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        [InverseProperty(nameof(Invoices.AccountsPerson))]
        public virtual ICollection<Invoices> InvoicesAccountsPerson { get; set; }
        [InverseProperty(nameof(Invoices.ContactPerson))]
        public virtual ICollection<Invoices> InvoicesContactPerson { get; set; }
        [InverseProperty(nameof(Invoices.LastEditedByNavigation))]
        public virtual ICollection<Invoices> InvoicesLastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Invoices.PackedByPerson))]
        public virtual ICollection<Invoices> InvoicesPackedByPerson { get; set; }
        [InverseProperty(nameof(Invoices.SalespersonPerson))]
        public virtual ICollection<Invoices> InvoicesSalespersonPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty(nameof(Orders.ContactPerson))]
        public virtual ICollection<Orders> OrdersContactPerson { get; set; }
        [InverseProperty(nameof(Orders.LastEditedByNavigation))]
        public virtual ICollection<Orders> OrdersLastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Orders.PickedByPerson))]
        public virtual ICollection<Orders> OrdersPickedByPerson { get; set; }
        [InverseProperty(nameof(Orders.SalespersonPerson))]
        public virtual ICollection<Orders> OrdersSalespersonPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PackageTypes> PackageTypes { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PaymentMethods> PaymentMethods { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        [InverseProperty(nameof(PurchaseOrders.ContactPerson))]
        public virtual ICollection<PurchaseOrders> PurchaseOrdersContactPerson { get; set; }
        [InverseProperty(nameof(PurchaseOrders.LastEditedByNavigation))]
        public virtual ICollection<PurchaseOrders> PurchaseOrdersLastEditedByNavigation { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StateProvinces> StateProvinces { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockGroups> StockGroups { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItemHoldings> StockItemHoldings { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<StockItems> StockItems { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SupplierCategories> SupplierCategories { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SupplierTransactions> SupplierTransactions { get; set; }
        [InverseProperty(nameof(Suppliers.AlternateContactPerson))]
        public virtual ICollection<Suppliers> SuppliersAlternateContactPerson { get; set; }
        [InverseProperty(nameof(Suppliers.LastEditedByNavigation))]
        public virtual ICollection<Suppliers> SuppliersLastEditedByNavigation { get; set; }
        [InverseProperty(nameof(Suppliers.PrimaryContactPerson))]
        public virtual ICollection<Suppliers> SuppliersPrimaryContactPerson { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<SystemParameters> SystemParameters { get; set; }
        [InverseProperty("LastEditedByNavigation")]
        public virtual ICollection<TransactionTypes> TransactionTypes { get; set; }
    }
}
