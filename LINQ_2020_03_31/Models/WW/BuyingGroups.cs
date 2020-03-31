using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    [Table("BuyingGroups", Schema = "Sales")]
    public partial class BuyingGroups
    {
        public BuyingGroups()
        {
            Customers = new HashSet<Customers>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        [Key]
        [Column("BuyingGroupID")]
        public int BuyingGroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string BuyingGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        [ForeignKey(nameof(LastEditedBy))]
        [InverseProperty(nameof(People.BuyingGroups))]
        public virtual People LastEditedByNavigation { get; set; }
        [InverseProperty("BuyingGroup")]
        public virtual ICollection<Customers> Customers { get; set; }
        [InverseProperty("BuyingGroup")]
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
    }
}
