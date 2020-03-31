using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("SupplierCategories", Schema = "Purchasing")]
    public partial class SupplierCategories
    {
        public SupplierCategories()
        {
            Suppliers = new HashSet<Suppliers>();
        }

        [Key]
        [Column("SupplierCategoryID")]
        public int SupplierCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.SupplierCategories))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("SupplierCategory")]
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}
